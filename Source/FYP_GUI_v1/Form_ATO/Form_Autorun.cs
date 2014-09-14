using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FYP_Common;
using System.Collections;
using System.IO;

namespace FYP_GUI_v1
{
    public partial class Form_Autorun : Form
    {
        private MainForm pointer_MainForm = null;

        public Form_Autorun(MainForm pointer)
        {
            InitializeComponent();
            this.pointer_MainForm = pointer;
            this.textBox_log.Text = Config.LOG_PATH_DEFAULT;

            textBox_log.Enabled = checkBox1.Checked;
            textBox_status.Enabled = checkBox1.Checked;
            button_browse.Enabled = checkBox1.Checked;
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_log.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_log.Text = comp_fbd.SelectedPath;
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                "Start now? The program will be helt for a while, please wait until the process finish.",
                "Running Seperate Process",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    Stack<Model_Automator> recursiveCheckStack = new Stack<Model_Automator>();
                    bool proceedToRun = true;
                    logging_reset();

                    if (checkBox1.Checked)
                    {
                        logging_log("Validating inputs...");
                    }
                    else
                    {
                        textBox_status.Text += "\r\n\r\nValidating inputs...";
                    }

                    // checking the validity of automation sequence
                    for (int i = 0; i < Model_Automator.list.Count; i++)
                    {
                        // if form input are not ok, display problematic fields and stop running the sequence
                        Model_Automator eachModel = Model_Automator.list[i];
                        eachModel.ResetRecursionParam();
                        Form eachForm = pointer_MainForm.getRespectiveForm(eachModel.Action);
                        ((Form_Automatable)eachForm).Show_withAutomationSettings(eachModel);
                        eachForm.Hide();
                        string invalid = ((Form_Automatable)eachForm).Form_Validate(null);
                        logging_log("#" + (i + 1) + " Invalid: [ " + invalid + "]");
                        if (invalid.Trim().Length != 0) proceedToRun = false;

                        // if form is defines operations on subset, check if proper starting/closing done, do preprocessing
                        if (eachForm.GetType().IsEquivalentTo(typeof(Form_Autosubset)))
                        {
                            Form_Autosubset form_ass = (Form_Autosubset)eachForm;
                            if (form_ass.Form_IsStart())
                            {
                                recursiveCheckStack.Push(eachModel);
                                eachModel.recursionIdentifer = recursiveCheckStack.Count;
                            }
                            else if (recursiveCheckStack.Count == 0)
                            {
                                proceedToRun = false;
                                logging_log("#" + (i + 1) + " Invalid: Automation Sequence!");
                            }
                            else
                            {
                                recursiveCheckStack.Pop().recursionPointer = i;
                            }
                        }

                        // release memory
                        eachForm.Close();
                    }

                    // check if there is any un-end-ed operation on subset
                    if (recursiveCheckStack.Count > 0)
                    {
                        proceedToRun = false;
                        logging_log("#" + Model_Automator.list.Count + " Invalid: Automation Sequence!");
                    }

                    // if ok shart to run
                    if (proceedToRun)
                    {
                        if (checkBox1.Checked)
                        {
                            logging_log("\nStart automation...");
                        }
                        else
                        {
                            textBox_status.Text += "\r\n\r\nStart automation...";
                        }
                        this.recursive_execution(0, Model_Automator.list.Count, "");
                    }

                    // if all ok
                    if (checkBox1.Checked)
                    {
                        logging_log("OK!");
                    }
                    else
                    {
                        textBox_status.Text += "\r\n\r\nOK!";
                    }
                }
                catch (Exception ex)
                {
                    if (checkBox1.Checked)
                    {
                        logging_log(ex.ToString());
                    }
                    else
                    {
                        textBox_status.Text += "\r\n\r\n" + ex.ToString();
                    }
                }
            }
        }

        private void recursive_execution(int start, int stop, string pathSuffix)
        {
            for (int i = start; i < stop; i++)
            {
                Model_Automator eachModel = Model_Automator.list[i];
                Form eachForm = pointer_MainForm.getRespectiveForm(eachModel.Action);

                if (!eachForm.GetType().IsEquivalentTo(typeof(Form_Autosubset)))
                {
                    // if the current form is a normal form, just execute it
                    ((Form_Automatable)eachForm).Show_withAutomationSettings(eachModel);
                    ((Form_Automatable)eachForm).Form_UpdatePathSettings(pathSuffix);
                    eachForm.Hide();
                    logging_log(((Form_Automatable)eachForm).Form_Execute(null, true));
                    eachForm.Close();
                }
                else
                {
                    // if the current form marks a start or end of recursive subset, do the following
                    if (eachModel.recursionPointer > 0)
                    {
                        // read param, normally this is read in form but this one this an exception
                        ((Form_Automatable)eachForm).Show_withAutomationSettings(eachModel);
                        eachForm.Hide();
                        Form_Autoseqdef eachSeqDef = ((Form_Autoseqsible)eachForm).GetSeqDef();
                        eachForm.Close();

                        // read and loop the available clusters
                        foreach (string eachClusterFileName in Directory.GetFiles(eachSeqDef.clusterPath + @"\" + pathSuffix))
                        {
                            if (eachClusterFileName.EndsWith(".xml"))
                            {
                                Cluster eachCluster = XMLHelper.ClusterFromXML(eachClusterFileName);
                                string pathSuffix_thisCluster = pathSuffix + @"\" + eachCluster.clusterCode;

                                // see what the criteria is
                                if (eachSeqDef.criteria == Form_Autoseqdef.Criteria.CLUSTER_WITH_STOCKS_MORE_THAN)
                                {
                                    if (eachCluster.stockCodeList.Count >= eachSeqDef.minimumStocks)
                                    {
                                        // if there are any temp path, revert first
                                        foreach (string eachStockFileName in Directory.GetFiles(eachSeqDef.dataPath))
                                        {
                                            if (eachStockFileName.Contains(".non_"))
                                            {
                                                File.Move(eachStockFileName, Path.ChangeExtension(eachStockFileName, "xml"));
                                            }
                                        }

                                        // process stock folder and temp-ly rename stocks other than this cluster
                                        foreach (string eachStockFileName in Directory.GetFiles(eachSeqDef.dataPath))
                                        {
                                            // now rename the stocks according to the cluster
                                            if (eachStockFileName.EndsWith(".xml"))
                                            {
                                                string extensionId = pathSuffix_thisCluster.Substring(1).Replace("\\", "_");
                                                bool isInCluster = false;

                                                foreach (int eachStockCodeOfCluster in eachCluster.stockCodeList)
                                                {
                                                    if (Path.GetFileNameWithoutExtension(eachStockFileName).Equals(eachStockCodeOfCluster + ""))
                                                    {
                                                        isInCluster = true;
                                                        break;
                                                    }
                                                }

                                                if (isInCluster == false)
                                                {
                                                    File.Move(eachStockFileName, Path.ChangeExtension(eachStockFileName, "non_" + extensionId));
                                                }
                                            }
                                        }

                                        // enter recursive function
                                        this.recursive_execution(i + 1, eachModel.recursionPointer, pathSuffix_thisCluster);
                                    }
                                }
                                else if (eachSeqDef.criteria == Form_Autoseqdef.Criteria.CLUSTER_MARKED_AS_SIGNIFICANT)
                                {
                                    // if (eachCluster.significant == true)
                                    if (true)
                                    {
                                        // if there are any temp path, revert first
                                        foreach (string eachStockFileName in Directory.GetFiles(eachSeqDef.dataPath))
                                        {
                                            if (eachStockFileName.Contains(".non_"))
                                            {
                                                File.Move(eachStockFileName, Path.ChangeExtension(eachStockFileName, "xml"));
                                            }
                                        }

                                        // process stock folder and temp-ly rename stocks other than this cluster
                                        foreach (string eachStockFileName in Directory.GetFiles(eachSeqDef.dataPath))
                                        {
                                            // now rename the stocks according to the cluster
                                            if (eachStockFileName.EndsWith(".xml"))
                                            {
                                                string extensionId = pathSuffix_thisCluster.Substring(1).Replace("\\", "_");
                                                bool isInCluster = false;

                                                foreach (int eachStockCodeOfCluster in eachCluster.stockCodeList)
                                                {
                                                    if (Path.GetFileNameWithoutExtension(eachStockFileName).Equals(eachStockCodeOfCluster + ""))
                                                    {
                                                        isInCluster = true;
                                                        break;
                                                    }
                                                }

                                                if (isInCluster == false)
                                                {
                                                    File.Move(eachStockFileName, Path.ChangeExtension(eachStockFileName, "non_" + extensionId));
                                                }
                                            }
                                        }

                                        // enter recursive function
                                        this.recursive_execution(i + 1, eachModel.recursionPointer, pathSuffix + @"\" + pathSuffix_thisCluster);
                                    }
                                }
                            }
                        }
                        i = eachModel.recursionPointer - 1;
                    }
                    else
                    {
                        // end of an recursive subset, reset the stocks folder
                        ((Form_Automatable)eachForm).Show_withAutomationSettings(eachModel);
                        eachForm.Hide();
                        Form_Autoseqdef eachSeqDef = ((Form_Autoseqsible)eachForm).GetSeqDef();
                        eachForm.Close();

                        foreach (string eachStockFileName in Directory.GetFiles(eachSeqDef.dataPath))
                        {
                            // if there are any temp path, revert first
                            if (eachStockFileName.Contains(".non_"))
                            {
                                File.Move(eachStockFileName, Path.ChangeExtension(eachStockFileName, "xml"));
                            }
                        }
                    }
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logging_reset()
        {
            if (checkBox1.Checked)
            {
                this.textBox_status.Text = "";
                LogHelper.NewLogger(typeof(Form_Autorun), textBox_log.Text);
            }
            else
            {
                this.textBox_status.Text = "You have disabled logging.";
            }
        }

        private void logging_log(string msg)
        {
            if (checkBox1.Checked)
            {
                this.textBox_status.Text += msg + "\r\n";
                LogHelper.GetLogger(typeof(Form_Autorun)).Log(msg);
            }
        }

        // obsolete
        //private LogHelper logging_custom()
        //{
        //    return LogHelper.GetLogger(typeof(Form_Autorun));
        //}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_log.Enabled = checkBox1.Checked;
            textBox_status.Enabled = checkBox1.Checked;
            button_browse.Enabled = checkBox1.Checked;
        }
    }
}
