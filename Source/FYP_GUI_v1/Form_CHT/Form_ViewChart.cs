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
using System.Collections;
using System.Reflection;

namespace FYP_GUI_v1
{
    // **********
    // Note: 
    // color combo box by renuka krishnan: http://www.c-sharpcorner.com/UploadFile/renuka11/Comboboxtoselectcolors03192009153558PM/Comboboxtoselectcolors.aspx
    // **********
    public partial class Form_ViewChart : Form
    {
        private List<Model_ShockChart> chartLines = new List<Model_ShockChart>();
        private MainForm pointer_MainForm = null;

        public Form_ViewChart(MainForm pointer)
        {
            InitializeComponent();
            textBox_sysPath.Text = Config.STOCK_PATH_DEFAULT;
            this.pointer_MainForm = pointer;

            colorManipulation();
            listBox_lineList.DataSource = chartLines;
            listBox_lineList.DisplayMember = "ToString";
        }

        private void colorManipulation()
        {
            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.comboBox_color.Items.Add(c.Name);
            }
            this.comboBox_color.SelectedItem = "Blue";
        }

        private void comboBox_color_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
            }
        }

        private void radioButton_group_CheckedChanged()
        {
            if (radioButton_stock.Checked)
            {
                textBox_sysPath.Text = Config.STOCK_PATH_DEFAULT;
            }
            else if (radioButton_index.Checked)
            {
                textBox_sysPath.Text = Config.INDEX_PATH_DEFAULT;
            }
        }

        private void radioButton_stock_CheckedChanged(object sender, EventArgs e)
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

        private void button_addLine_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBox_sysPath.Text + @"\" + comboBox_item.SelectedItem + ".xml";
                Stock stock = XMLHelper.StockFromXML(path);
                Color color = Model_ShockChart.getLineColor(comboBox_color.SelectedItem.ToString());
                listBox_lineList.DataSource = null;
                chartLines.Add(new Model_ShockChart(stock, color));
                listBox_lineList.DataSource = chartLines;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (listBox_lineList.SelectedIndex >= 0)
            {
                chartLines.RemoveAt(listBox_lineList.SelectedIndex);
                listBox_lineList.DataSource = null;
                listBox_lineList.DataSource = chartLines;
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            Form_StockChart form_sc = new Form_StockChart(textBox_title.Text.Trim(), chartLines);
            form_sc.MdiParent = pointer_MainForm;
            form_sc.Show();
        }
    }
}
