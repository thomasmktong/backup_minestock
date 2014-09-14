using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FYP_Common;
using System.Diagnostics;

namespace FYP_GUI_v1
{
    public partial class Form_CalcPortfolio : Form, Form_Automatable
    {
        Form_ViewPortfolio pointer_parentForm = null;
        Process process = null;

        public Form_CalcPortfolio(Form_ViewPortfolio form_vp)
        {
            InitializeComponent();

            // custom data
            pointer_parentForm = form_vp;

            textBox_envPath.Text = Config.ENVIRONMENT_PATH_DEFAULT;
            textBox_stockPath.Text = Config.STOCK_PATH_DEFAULT;
            textBox_tbillPath.Text = Config.TBILL_PATH_DEFAULT;
            textBox_statPath.Text = Config.STAT_PATH_DEFAULT;
            textBox_logPath.Text = Config.LOG_PATH_DEFAULT;
        }

        private void button_envPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_envPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_envPath.Text = comp_fbd.SelectedPath;
            }
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

        private void buttontbillPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_tbillPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_tbillPath.Text = comp_fbd.SelectedPath;
            }
        }

        private void button_statPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_statPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_statPath.Text = comp_fbd.SelectedPath;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            LogHelper logger = LogHelper.NewLogger(typeof(Form_CalcPortfolio), textBox_logPath.Text);
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

        public void Show_withAutomationSettings(Model_Automator automationModel)
        {
            // not a must to implement
        }

        public void Form_UpdatePathSettings(string suffix)
        {
            // no subgroup running available for this form
        }

        public void Form_ConfirmSettings(object sender, EventArgs e)
        {
            // not a must to implement
        }

        public string Form_Validate(FYP_Common.LogHelper logger)
        {
            string toReturn = "";
            toReturn += Validator.fastCheck(textBox_envPath, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_stockPath, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_tbillPath, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_statPath, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_logPath, Validator.Identifier.PATH);
            if (logger != null) logger.Log("Invalid: [ " + toReturn + "]");
            return toReturn;
        }

        public string Form_Execute(FYP_Common.LogHelper logger, bool slient)
        {
            string toReturn = "";
            String file = Config.OPTIMIZE_PORTFOLIO_EXE;
            String command = textBox_envPath.Text + " " + textBox_stockPath.Text + " " +
                textBox_tbillPath.Text + " " + textBox_statPath.Text;

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

            this.pointer_parentForm.UpdatePortfolioScn();
            this.pointer_parentForm.UpdateSummaryScn();
            return toReturn;
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
                    LogHelper.GetLogger(typeof(Form_CalcPortfolio)).Log(textBox_status.Text);
                }));
            }
        }

        private void Form_CalcPortfolio_Leave(object sender, EventArgs e)
        {
            this.pointer_parentForm.UpdatePortfolioScn();
            this.pointer_parentForm.UpdateSummaryScn();
        }
    }
}
