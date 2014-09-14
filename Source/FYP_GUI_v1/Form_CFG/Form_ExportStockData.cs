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

namespace FYP_GUI_v1
{
    public partial class Form_ExportStockData : Form
    {
        public Form_ExportStockData()
        {
            InitializeComponent();
            textBox_exportPath.Text = Config.EXPORT_PATH_DEFAULT;
            textBox_sysPath.Text = Config.STOCK_PATH_DEFAULT;
        }

        private void radioButton_group_CheckedChanged()
        {
            if (radioButton_stock.Checked)
            {
                comboBox_addit.Enabled = true;
                comboBox_item.Enabled = true;

                comboBox_addit.Items.Clear();
                comboBox_addit.Items.Add("Real value");
                comboBox_addit.Items.Add("Discretized");
                comboBox_addit.SelectedIndex = 0;
            }
            else if (radioButton_index.Checked)
            {
                textBox_sysPath.Text = Config.INDEX_PATH_DEFAULT;
                comboBox_addit.Enabled = false;
                comboBox_item.Enabled = true;
            }
            else if (radioButton_tbill.Checked)
            {
                textBox_sysPath.Text = Config.TBILL_PATH_DEFAULT;
                comboBox_addit.Enabled = false;
                comboBox_item.Enabled = false;
            }
            else if (radioButton_cluster.Checked)
            {
                textBox_sysPath.Text = Config.CLUSTER_PATH_DEFAULT;
                comboBox_addit.Enabled = false;
                comboBox_item.Enabled = false;
            }
            else
            {
                textBox_sysPath.Text = Config.CLUSTER_PATH_DEFAULT;
                comboBox_addit.Enabled = false;
                comboBox_item.Enabled = false;
            }
        }

        private void radioButton_stock_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_group_CheckedChanged();
        }

        private void radioButton_cluster_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_group_CheckedChanged();
        }

        private void radioButton_mapping_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_group_CheckedChanged();
        }

        private void radioButton_tbill_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_group_CheckedChanged();
        }

        private void radioButton_index_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_group_CheckedChanged();
        }

        private void textBox_sysPath_TextChanged(object sender, EventArgs e)
        {
            comboBox_item.Items.Clear();
            if (Directory.Exists(textBox_sysPath.Text))
            {
                try
                {
                    foreach (string filePath in Directory.GetFiles(textBox_sysPath.Text))
                    {
                        if (filePath.EndsWith(".xml"))
                        {
                            comboBox_item.Items.Add(Path.GetFileNameWithoutExtension(filePath));
                        }
                    }
                    if (comboBox_item.Items.Count > 0)
                    {
                        comboBox_item.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                }
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            string toPath = textBox_exportPath.Text + @"\" + textBox_fileName.Text + ".csv";

            if (!Directory.Exists(textBox_exportPath.Text) || textBox_fileName.Text.Length == 0)
            {
                MessageBox.Show(this, "Output path incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioButton_stock.Checked || radioButton_index.Checked)
            {
                string fromPath = textBox_sysPath.Text + @"\" + comboBox_item.SelectedItem + ".xml";
                Stock stock = XMLHelper.StockFromXML(fromPath);
                StreamWriter sw = new StreamWriter(toPath);

                if (comboBox_addit.SelectedIndex == 0)
                {
                    if (stock.stockCode > 0)
                    {
                        sw.WriteLine("Date,Open,High,Low,Close,Volume,Adj Close");
                    }
                    else
                    {
                        sw.WriteLine("Date,Open,High,Low,Close,Adj Close");
                    }
                }
                else
                {
                    sw.WriteLine("Date,Category");
                }

                foreach (Tick eachTick in stock.priceList)
                {
                    if (eachTick.GetType() == typeof(NumericTick))
                    {
                        if (eachTick.id == Identifier.N || true)
                        {
                            NumericTick numTick = (NumericTick)eachTick;

                            if (stock.stockCode > 0)
                            {
                                sw.WriteLine(String.Format("{0:yyyyMMdd}", numTick.Time) + "," + numTick.open + "," + numTick.high + "," +
                                    numTick.low + "," + numTick.close + "," + numTick.volume + "," + numTick.adjustedClose);
                            }
                            else
                            {
                                sw.WriteLine(String.Format("{0:yyyyMMdd}", numTick.Time) + "," + numTick.open + "," + numTick.high + "," +
                                    numTick.low + "," + numTick.close + "," + numTick.adjustedClose);
                            }
                        }
                    }
                    else
                    {
                        sw.WriteLine(String.Format("{0:yyyyMMdd}", eachTick.Time) + "," + ((GenusTick)eachTick).degreeOfChange);
                    }
                }

                sw.Flush();
                sw.Close();
            }
            else if (radioButton_tbill.Checked)
            {
                StreamWriter sw = new StreamWriter(toPath);

                if (Directory.Exists(textBox_sysPath.Text))
                {
                    sw.WriteLine("Period,Coupon,Price,Yield");

                    foreach (string eachTbillPath in Directory.GetFiles(textBox_sysPath.Text))
                    {
                        if (eachTbillPath.EndsWith(".xml"))
                        {
                            Tbill tbill = XMLHelper.TbillFromXML(eachTbillPath);
                            sw.WriteLine(tbill.GetStringPeriod() + "," + tbill.coupon + "," + tbill.GetDoublePrice(1000) + "," + tbill.ytm);
                        }
                    }

                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    MessageBox.Show(this, "System file not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButton_cluster.Checked)
            {
                if (Directory.Exists(textBox_sysPath.Text))
                {
                    int colCount = 0;
                    double temp = 0.0;
                    StreamWriter sw = new StreamWriter(toPath);
                    // List<string> ot = new List<string>();
                    Dictionary<string, string> ot = new Dictionary<string, string>();
                    string header = "";

                    foreach (string eachClusterPath in Directory.GetFiles(textBox_sysPath.Text))
                    {
                        if (eachClusterPath.EndsWith(".xml"))
                        {
                            Cluster cluster = XMLHelper.ClusterFromXML(eachClusterPath);
                            colCount++;

                            if (cluster.centroid[0].GetType() == typeof(NumericTick))
                            {
                                header = "Date";

                                for (int rowCount = 0; rowCount < cluster.centroid.Count; rowCount++)
                                {
                                    temp = double.IsInfinity(((NumericTick)cluster.centroid.ElementAt(rowCount)).change) ? 0 : ((NumericTick)cluster.centroid.ElementAt(rowCount)).change;
                                    
                                    if (colCount == 1)
                                    {
                                        ot.Add(String.Format("{0:yyyyMMdd}", cluster.centroid.ElementAt(rowCount).Time), temp + "");
                                    } else {
                                        ot[String.Format("{0:yyyyMMdd}", cluster.centroid.ElementAt(rowCount).Time)] += ("," + temp);
                                    }
                                }
                            }
                            else if (cluster.centroid[0].GetType() == typeof(FakeTick))
                            {
                                header = "Sequence";

                                foreach (Tick eachTick in cluster.centroid)
                                {
                                    if (colCount == 1)
                                    {
                                        ot.Add("'" + ((FakeTick)eachTick).key, ((FakeTick)eachTick).value + "");
                                    }
                                    else
                                    {
                                        ot["'" + ((FakeTick)eachTick).key] += ("," + ((FakeTick)eachTick).value);
                                    }
                                }
                            }
                        }
                    }

                    sw.Write(header);

                    for (int i = 1; i <= colCount; i++)
                    {
                        sw.Write(",Cluster" + i);
                    }

                    sw.WriteLine();

                    foreach (KeyValuePair<string, string> eachKYP in ot)
                    {
                        sw.WriteLine(eachKYP.Key + "," + eachKYP.Value);
                    }

                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    MessageBox.Show(this, "System file not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (Directory.Exists(textBox_sysPath.Text))
                {
                    StreamWriter sw = new StreamWriter(toPath);
                    sw.WriteLine("ClusterCode,StockCode");

                    foreach (string eachClusterPath in Directory.GetFiles(textBox_sysPath.Text))
                    {
                        if (eachClusterPath.EndsWith(".xml"))
                        {
                            Cluster cluster = XMLHelper.ClusterFromXML(eachClusterPath);

                            foreach (int stockCode in cluster.stockCodeList)
                            {
                                sw.WriteLine(Path.GetFileNameWithoutExtension(eachClusterPath) + "," + stockCode);
                            }
                        }
                    }

                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    MessageBox.Show(this, "System file not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show(this, "Operation done.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_sysPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_sysPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_sysPath.Text = comp_fbd.SelectedPath;
            }
        }

        private void button_exportPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox_exportPath.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_exportPath.Text = comp_fbd.SelectedPath;
            }
        }

        private void comboBox_addit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_addit.SelectedIndex == 0)
            {
                textBox_sysPath.Text = Config.STOCK_PATH_DEFAULT;
            }
            else
            {
                textBox_sysPath.Text = Config.GENUS_PATH_DEFAULT;
            }
        }
    }
}
