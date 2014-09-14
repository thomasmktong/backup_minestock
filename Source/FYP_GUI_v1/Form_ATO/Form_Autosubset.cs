using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FYP_Common;
using System.IO;

namespace FYP_GUI_v1
{
    public partial class Form_Autosubset : Form, Form_Automatable, Form_Autoseqsible
    {
        Model_Automator automationModel = null;

        public Form_Autosubset(bool isStart)
        {
            InitializeComponent();
            this.textBox_stockPath.Text = Config.STOCK_PATH_DEFAULT;
            this.textBox_clusterPath.Text = Config.CLUSTER_PATH_DEFAULT;
            this.textBox_logPath.Text = Config.LOG_PATH_DEFAULT;
            textBox_minStocksInCluster.Text = "0";

            if (isStart)
            {
                radioButton_subset.Checked = true;
                radioButton_subset.Enabled = false;
                radioButton_univSet.Enabled = false;
            }
            else
            {
                radioButton_univSet.Checked = true;
                radioButton_subset.Enabled = false;
                radioButton_univSet.Enabled = false;
            }
        }

        public bool Form_IsStart()
        {
            return radioButton_subset.Checked;
        }

        private void Form_RadioButton()
        {
            if (radioButton_subset.Checked == true)
            {
                //radioButton_minStocksInCluster.Enabled = true;
                //radioButton_significantCluster.Enabled = true;
                textBox_clusterPath.Enabled = true;
                textBox_minStocksInCluster.Enabled = true;
                button_browseCluster.Enabled = true;
            }
            else
            {
                //radioButton_minStocksInCluster.Enabled = false;
                //radioButton_minStocksInCluster.Checked = false;
                //radioButton_significantCluster.Enabled = false;
                //radioButton_significantCluster.Checked = false;
                textBox_clusterPath.Enabled = false;
                textBox_clusterPath.Text = Config.CLUSTER_PATH_DEFAULT;
                textBox_minStocksInCluster.Enabled = false;
                textBox_minStocksInCluster.Text = "0";
                button_browseCluster.Enabled = false;
            }
        }

        private void radioButton_subset_CheckedChanged(object sender, EventArgs e)
        {
            this.Form_RadioButton();
        }

        private void radioButton_univSet_CheckedChanged(object sender, EventArgs e)
        {
            this.Form_RadioButton();
        }

        private void button_browseStock_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_stockPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_stockPath.Text = comp_fbd.SelectedPath;
            }
        }

        private void button_browseCluster_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_clusterPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_clusterPath.Text = comp_fbd.SelectedPath;
            }
        }

        private void button_browseLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_logPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_logPath.Text = comp_fbd.SelectedPath;
            }
        }

        public void Show_withAutomationSettings(Model_Automator automationModel)
        {
            this.automationModel = automationModel;
            this.Text = this.Text + " [Automation Setting]";
            this.button_cancel.Enabled = false;
            this.ControlBox = false;
            Reflector.AssignButtonEvent(button_ok, new EventHandler(Form_ConfirmSettings)).Text = "OK";

            if (automationModel.Param1 != null && automationModel.Param2 != null &&
                automationModel.Param2 != null && automationModel.Param4 != null &&
                automationModel.Param5 != null && automationModel.Param6 != null)
            {
                try
                {
                    radioButton_subset.Checked = (int.Parse(automationModel.Param2) != 0);
                    radioButton_univSet.Checked = (int.Parse(automationModel.Param2) == 0);
                    // radioButton_minStocksInCluster.Checked = (int.Parse(automationModel.Param3) != 0);
                    // radioButton_significantCluster.Checked = (int.Parse(automationModel.Param3) == 0);
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                }

                textBox_stockPath.Text = automationModel.Param1;
                textBox_clusterPath.Text = automationModel.Param4;
                textBox_minStocksInCluster.Text = automationModel.Param5;
                textBox_logPath.Text = automationModel.Param6;
            }
            this.Show();
        }

        public void Form_ConfirmSettings(object sender, EventArgs e)
        {
            if (automationModel != null)
            {
                automationModel.Param1 = textBox_stockPath.Text;
                automationModel.Param2 = radioButton_subset.Checked ? "1" : "0";
                // automationModel.Param3 = radioButton_minStocksInCluster.Checked ? "1" : "0";
                automationModel.Param3 = "1";
                automationModel.Param4 = textBox_clusterPath.Text;
                automationModel.Param5 = textBox_minStocksInCluster.Text;
                automationModel.Param6 = textBox_logPath.Text;
            }
            this.Close();
        }

        public string Form_Validate(FYP_Common.LogHelper logger)
        {
            string toReturn = "";
            toReturn += Validator.fastCheck(textBox_stockPath, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_clusterPath, Validator.Identifier.PATH);
            toReturn += Validator.fastCheck(textBox_minStocksInCluster, Validator.Identifier.INT);
            toReturn += Validator.fastCheck(textBox_logPath, Validator.Identifier.PATH);
            if (logger != null) logger.Log("Invalid: [ " + toReturn + "]");
            return toReturn;
        }

        public string Form_Execute(FYP_Common.LogHelper logger, bool slient)
        {
            throw new NotImplementedException();
        }

        private void radioButton_minStocksInCluster_CheckedChanged(object sender, EventArgs e)
        {
            // if (radioButton_minStocksInCluster.Checked)
            if (true)
            {
                textBox_minStocksInCluster.Enabled = true;
            }
            //else
            //{
            //    textBox_minStocksInCluster.Enabled = false;
            //}
        }

        public Form_Autoseqdef GetSeqDef()
        {
            Form_Autoseqdef form_asd = new Form_Autoseqdef();
            form_asd.dataPath = textBox_stockPath.Text;
            form_asd.clusterPath = textBox_clusterPath.Text;
            form_asd.logPath = textBox_logPath.Text;

            form_asd.automationFlow = radioButton_subset.Checked ?
                Form_Autoseqdef.AutomationFlow.USE_SUBSET : Form_Autoseqdef.AutomationFlow.USE_UNIVERSAL_SET;

            form_asd.criteria = Form_Autoseqdef.Criteria.CLUSTER_WITH_STOCKS_MORE_THAN;

            // form_asd.criteria = radioButton_minStocksInCluster.Checked ?
            //     Form_Autoseqdef.Criteria.CLUSTER_WITH_STOCKS_MORE_THAN : Form_Autoseqdef.Criteria.CLUSTER_MARKED_AS_SIGNIFICANT;

            try
            {
                form_asd.minimumStocks = int.Parse(textBox_minStocksInCluster.Text);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                form_asd.minimumStocks = 0;
            }

            return form_asd;
        }


        public void Form_UpdatePathSettings(string suffix)
        {
            // do nothing
        }
    }
}
