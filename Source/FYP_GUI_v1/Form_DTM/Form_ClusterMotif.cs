using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using FYP_Common;
using System.Threading;

namespace FYP_GUI_v1
{
    public partial class Form_ClusterMotif : Form, Form_Automatable
    {
        Process process = null;
        Model_Automator automationModel = null;

        public Form_ClusterMotif()
        {
            InitializeComponent();

            // **********
            // Note: refer this website: http://bytes.com/topic/c-sharp/answers/231936-track-bar-textedit
            // **********
            textBox_noctbd.DataBindings.Add("Text", trackBar_noctbd, "Value");
            textBox_stockPath.Text = Config.GENUS_PATH_DEFAULT;
            textBox_clusterPath.Text = Config.CLUSTER_PATH_DEFAULT;
            textBox_logPath.Text = Config.LOG_PATH_DEFAULT;
        }

        private void button_stockPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_stockPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_stockPath.Text = comp_fbd.SelectedPath;
            }
        }

        private void button_clusterPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_clusterPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_clusterPath.Text = comp_fbd.SelectedPath;
            }
        }

        private void button_logPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_logPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_logPath.Text = comp_fbd.SelectedPath;
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            LogHelper logger = LogHelper.NewLogger(typeof(Form_ClusterMotif), textBox_logPath.Text);
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

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (textBox_status.InvokeRequired)
            {
                textBox_status.Invoke(new MethodInvoker(delegate()
                {
                    LogHelper.GetLogger(typeof(Form_ClusterMotif)).Log(textBox_status.Text);
                }));
            }
        }

        public void Show_withAutomationSettings(Model_Automator automationModel)
        {
            this.automationModel = automationModel;
            this.Text = this.Text + " [Automation Setting]";
            this.button_cancel.Enabled = false;
            this.ControlBox = false;
            Reflector.AssignButtonEvent(button_start, new EventHandler(Form_ConfirmSettings)).Text = "OK";

            if (automationModel.Param1 != null && automationModel.Param2 != null &&
                automationModel.Param2 != null && automationModel.Param4 != null && automationModel.Param5 != null)
            {
                try
                {
                    trackBar_noctbd.Value = int.Parse((automationModel.Param1));
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                }

                textBox_noctbd.Text = automationModel.Param1;
                textBox_stockPath.Text = automationModel.Param2;
                textBox_clusterPath.Text = automationModel.Param3;
                textBox_logPath.Text = automationModel.Param4;
                textBox_multiper.Text = automationModel.Param5;
            }
            this.Show();
        }

        public void Form_ConfirmSettings(object sender, EventArgs e)
        {
            if (automationModel != null)
            {
                automationModel.Param1 = textBox_noctbd.Text;
                automationModel.Param2 = textBox_stockPath.Text;
                automationModel.Param3 = textBox_clusterPath.Text;
                automationModel.Param4 = textBox_logPath.Text;
                automationModel.Param5 = textBox_multiper.Text;
            }
            this.Close();
        }


        public string Form_Validate(LogHelper logger)
        {
            string toReturn = "";
            toReturn += Validator.fastCheck(textBox_noctbd, Validator.Identifier.INT);
            toReturn += Validator.fastCheck(textBox_stockPath, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_clusterPath, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_logPath, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_multiper, Validator.Identifier.DOUBLE);
            if (logger != null) logger.Log("Invalid: [ " + toReturn + "]");
            return toReturn;
        }

        public string Form_Execute(LogHelper logger, bool slient)
        {
            string toReturn = "";
            String file = Config.CLUSTER_STOCK_DATA_EXE;
            String command = 2 + " " + textBox_noctbd.Text + " " + textBox_stockPath.Text + " " + textBox_clusterPath.Text + " " + textBox_multiper.Text;

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
            textBox_clusterPath.Text += suffix;
        }
    }
}
