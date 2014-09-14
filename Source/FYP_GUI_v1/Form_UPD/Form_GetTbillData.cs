using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FYP_Common;
using System.Diagnostics;

namespace FYP_GUI_v1
{
    public partial class Form_GetTbillData : Form, Form_Automatable
    {
        Process process = null;
        Model_Automator automationModel = null;

        public Form_GetTbillData()
        {
            InitializeComponent();
            textBox_path.Text = Config.TBILL_PATH_DEFAULT;
            textBox_log.Text = Config.LOG_PATH_DEFAULT;
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_path.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = comp_fbd.SelectedPath;
            }
        }

        private void textBox_path_TextChanged(object sender, EventArgs e)
        {
            updateLastUpdateTime();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            LogHelper logger = LogHelper.NewLogger(typeof(Form_GetTbillData), textBox_log.Text);
            string msg = Form_Validate(logger);

            if (msg.Equals(""))
            {
                Form_Execute(logger, false);
            }
            else
            {
                MessageBox.Show("Invalid: [ " + msg + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // **********
        // Note: live std-out update from: http://www.codeguru.com/forum/showthread.php?threadid=460918
        // **********
        private void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (textBox_status.InvokeRequired && !String.IsNullOrEmpty(e.Data))
            {
                textBox_status.Invoke(new MethodInvoker(delegate()
                {
                    textBox_status.Text += e.Data + Environment.NewLine;
                    textBox_status.SelectionStart = textBox_status.Text.Length;
                    textBox_status.ScrollToCaret();
                    textBox_status.Refresh();
                }));
            }
        }

        // **********
        // Note: proc exit listener from: http://www.codeguru.com/forum/showthread.php?threadid=460918
        // **********
        private void process_OnExited(object sender, EventArgs e)
        {
            if (button_start.InvokeRequired)
            {
                button_start.Invoke(new MethodInvoker(delegate() { button_start.Enabled = true; }));
            }

            if (button_cancel.InvokeRequired)
            {
                button_cancel.Invoke(new MethodInvoker(delegate()
                {
                    button_cancel.Enabled = true;
                }));
            }

            if (label_lastUpdateTime.InvokeRequired)
            {
                button_cancel.Invoke(new MethodInvoker(delegate()
                {
                    updateLastUpdateTime();
                }));
            }

            if (textBox_status.InvokeRequired)
            {
                textBox_status.Invoke(new MethodInvoker(delegate()
                {
                    LogHelper.GetLogger(typeof(Form_GetTbillData)).Log(textBox_status.Text);
                }));
            }
        }

        private void button_log_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_log.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_log.Text = comp_fbd.SelectedPath;
            }
        }

        private void updateLastUpdateTime()
        {
            try
            {
                foreach (string filePath in Directory.GetFiles(textBox_path.Text))
                {
                    if (filePath.EndsWith(".xml"))
                    {
                        Tbill temp = XMLHelper.TbillFromXML(filePath);
                        label_lastUpdateTime.Text = temp.time.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                label_lastUpdateTime.Text = "<Undefined>";
            }
        }

        public void Show_withAutomationSettings(Model_Automator automationModel)
        {
            this.automationModel = automationModel;
            this.Text = this.Text + " [Automation Setting]";
            this.button_cancel.Enabled = false;
            this.ControlBox = false;
            Reflector.AssignButtonEvent(button_start, new EventHandler(Form_ConfirmSettings)).Text = "OK";

            if (automationModel.Param1 != null && automationModel.Param2 != null)
            {
                textBox_path.Text = automationModel.Param1;
                textBox_log.Text = automationModel.Param2;
            }
            this.Show();
        }

        public void Form_ConfirmSettings(object sender, EventArgs e)
        {
            if (automationModel != null)
            {
                automationModel.Param1 = textBox_path.Text;
                automationModel.Param2 = textBox_log.Text;
            }
            this.Close();
        }


        public string Form_Validate(LogHelper logger)
        {
            string toReturn = "";
            toReturn += Validator.fastCheck(textBox_path, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_log, Validator.Identifier.PATH);
            if (logger != null) logger.Log("Invalid: [ " + toReturn + "]");
            return toReturn;
        }

        public string Form_Execute(LogHelper logger, bool slient)
        {
            string toReturn = "";
            string file = Config.GET_TBILL_DATA_EXE;
            string command = textBox_path.Text;

            if (Config.LIVE_STATUS == true && slient == false)
            {
                textBox_status.Text = "";
                ProcessStartInfo psi = new ProcessStartInfo(file, command);
                psi.UseShellExecute = false;
                psi.ErrorDialog = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                button_start.Enabled = false;
                button_cancel.Enabled = false;

                if (process != null)
                {
                    process.Dispose();
                }

                process = new Process();
                process.StartInfo = psi;
                process.EnableRaisingEvents = true;
                // process.SynchronizingObject = this;
                process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
                process.Exited += new EventHandler(process_OnExited);
                process.Start();
                process.BeginOutputReadLine();
            }
            else
            {
                // **********
                // Note: Simple std-out capture from: http://www.java2s.com/Code/CSharp/Development-Class/RedirectingProcessOutput.htm
                // **********
                textBox_status.Text = "You have turned off live status update, please wait until the process finish.";

                if (slient || MessageBox.Show(this,
                    "Start now? The program will be helt for a while, please wait until the process finish.",
                    "Running Seperate Process",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    process = new Process();
                    process.StartInfo.FileName = file;
                    process.StartInfo.Arguments = command;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Start();

                    toReturn = process.StandardOutput.ReadToEnd();
                    textBox_status.Text = toReturn;
                    if (logger != null) logger.Log(toReturn);
                }
            }
            return toReturn;
        }


        public void Form_UpdatePathSettings(string suffix)
        {
            // do nothing
        }
    }
}
