using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using FYP_GUI_v1;
using FYP_Common;

namespace FYP_GUI_v1
{
    public partial class Form_GetStockData : Form, Form_Automatable
    {
        Process process = null;
        Model_Automator automationModel = null;

        public Form_GetStockData()
        {
            InitializeComponent();
            textBox_outPath.Text = Config.STOCK_PATH_DEFAULT;
            textBox_logPath.Text = Config.LOG_PATH_DEFAULT;
            monthCalendar_startDate.SelectionStart = monthCalendar_endDate.SelectionStart.AddYears(-1);
            monthCalendar_startDate.SelectionEnd = monthCalendar_endDate.SelectionEnd.AddYears(-1);
        }

        public void call_indexMode()
        {
            textBox_outPath.Text = Config.INDEX_PATH_DEFAULT;
            textBox_stockCode.Text = "0";
            textBox_stockCode.Enabled = false;
            checkBox_getAll.Checked = false;
            checkBox_getAll.Enabled = false;
            checkBox_getGem.Checked = false;
            checkBox_getGem.Enabled = false;
            this.Text = this.Text.Replace("Stock", "Index");
        }

        private void checkBox_getAll_CheckedChanged(object sender, EventArgs e)
        {
            resetField();
        }

        private void checkBox_getGem_CheckedChanged(object sender, EventArgs e)
        {
            resetField();
        }

        private void resetField()
        {
            if (checkBox_getAll.Checked && !checkBox_getGem.Checked)
            {
                textBox_stockCode.Text = "-1";
                textBox_stockCode.Enabled = false;
            }
            else if (!checkBox_getAll.Checked && checkBox_getGem.Checked)
            {
                textBox_stockCode.Text = "-2";
                textBox_stockCode.Enabled = false;
            }
            else if (checkBox_getAll.Checked && checkBox_getGem.Checked)
            {
                textBox_stockCode.Text = "-3";
                textBox_stockCode.Enabled = false;
            }
            else
            {
                textBox_stockCode.Text = "";
                textBox_stockCode.Enabled = true;
            }
        }

        private void button_outSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_outPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_outPath.Text = comp_fbd.SelectedPath;
            }
        }

        private void button_logSelect_Click(object sender, EventArgs e)
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
            LogHelper logger = LogHelper.NewLogger(typeof(Form_GetStockData), textBox_logPath.Text);
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
                    LogHelper.GetLogger(typeof(Form_GetStockData)).Log(textBox_status.Text);
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
                automationModel.Param3 != null && automationModel.Param4 != null &&
                automationModel.Param5 != null)
            {
                if (automationModel.Param1.Equals("0"))
                {
                    textBox_stockCode.Enabled = false;
                    checkBox_getAll.Enabled = false;
                    checkBox_getGem.Enabled = false;
                }

                if (automationModel.Param1.Equals("-1"))
                {
                    textBox_stockCode.Enabled = false;
                    checkBox_getAll.Checked = true;
                    checkBox_getGem.Checked = false;
                }

                if (automationModel.Param1.Equals("-2"))
                {
                    textBox_stockCode.Enabled = false;
                    checkBox_getAll.Checked = false;
                    checkBox_getGem.Checked = true;
                }

                if (automationModel.Param1.Equals("-3"))
                {
                    textBox_stockCode.Enabled = false;
                    checkBox_getAll.Checked = true;
                    checkBox_getGem.Checked = true;
                }

                textBox_stockCode.Text = automationModel.Param1;

                try
                {
                    monthCalendar_startDate.SelectionStart =
                        new DateTime(int.Parse(automationModel.Param2.Substring(0, 4)),
                            int.Parse(automationModel.Param2.Substring(4, 2)),
                            int.Parse(automationModel.Param2.Substring(6, 2)));
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                    monthCalendar_startDate.SelectionStart = new DateTime(2003, 1, 1);
                }

                try
                {
                    monthCalendar_endDate.SelectionStart =
                        new DateTime(int.Parse(automationModel.Param3.Substring(0, 4)),
                            int.Parse(automationModel.Param3.Substring(4, 2)),
                            int.Parse(automationModel.Param3.Substring(6, 2)));
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                    monthCalendar_endDate.SelectionStart = DateTime.Now;
                }

                textBox_outPath.Text = automationModel.Param4;
                textBox_logPath.Text = automationModel.Param5;
            }
            this.Show();
        }

        public void Form_ConfirmSettings(object sender, System.EventArgs e)
        {
            if (automationModel != null)
            {
                automationModel.Param1 = textBox_stockCode.Text;
                automationModel.Param2 = String.Format("{0:yyyyMMdd}", monthCalendar_startDate.SelectionStart);
                automationModel.Param3 = String.Format("{0:yyyyMMdd}", monthCalendar_endDate.SelectionStart);
                automationModel.Param4 = textBox_outPath.Text;
                automationModel.Param5 = textBox_logPath.Text;
            }
            this.Close();
        }

        public string Form_Validate(LogHelper logger)
        {
            string toReturn = "";
            toReturn += Validator.fastCheck(textBox_stockCode, Validator.Identifier.INT);

            // no need to check monthCalendar_startDate
            // no need to check monthCalendar_endDate

            toReturn += Validator.fastCheck(textBox_outPath, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_logPath, Validator.Identifier.PATH);
            if (logger != null) logger.Log("Invalid: [ " + toReturn + "]");
            return toReturn;
        }

        public string Form_Execute(LogHelper logger, bool slient)
        {
            string toReturn = "";
            string file = Config.GET_STOCK_DATA_EXE;

            string command = textBox_stockCode.Text + " ";
            command += monthCalendar_startDate.SelectionStart.Year + " ";
            command += monthCalendar_startDate.SelectionStart.Month + " ";
            command += monthCalendar_startDate.SelectionStart.Day + " ";
            command += monthCalendar_endDate.SelectionStart.Year + " ";
            command += monthCalendar_endDate.SelectionStart.Month + " ";
            command += monthCalendar_endDate.SelectionStart.Day + " ";
            command += textBox_outPath.Text;

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
