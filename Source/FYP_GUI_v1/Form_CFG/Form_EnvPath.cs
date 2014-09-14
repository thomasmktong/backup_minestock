using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FYP_Common;

namespace FYP_GUI_v1
{
    public partial class Form_EnvPath : Form
    {
        public Form_EnvPath()
        {
            InitializeComponent();

            // customize
            this.loadPathFromObject();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogOpen = new OpenFileDialog();
            DialogOpen.DefaultExt = "exe";
            DialogOpen.Filter = "EXE file (*.exe)|*.exe|All files (*.*)|*.*";
            DialogOpen.AddExtension = true;
            DialogOpen.RestoreDirectory = true;
            DialogOpen.Title = "Select Program";
            DialogOpen.InitialDirectory = Application.ExecutablePath;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = DialogOpen.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogOpen = new OpenFileDialog();
            DialogOpen.DefaultExt = "exe";
            DialogOpen.Filter = "EXE file (*.exe)|*.exe|All files (*.*)|*.*";
            DialogOpen.AddExtension = true;
            DialogOpen.RestoreDirectory = true;
            DialogOpen.Title = "Select Program";
            DialogOpen.InitialDirectory = Application.ExecutablePath;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = DialogOpen.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogOpen = new OpenFileDialog();
            DialogOpen.DefaultExt = "exe";
            DialogOpen.Filter = "EXE file (*.exe)|*.exe|All files (*.*)|*.*";
            DialogOpen.AddExtension = true;
            DialogOpen.RestoreDirectory = true;
            DialogOpen.Title = "Select Program";
            DialogOpen.InitialDirectory = Application.ExecutablePath;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = DialogOpen.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogOpen = new OpenFileDialog();
            DialogOpen.DefaultExt = "exe";
            DialogOpen.Filter = "EXE file (*.exe)|*.exe|All files (*.*)|*.*";
            DialogOpen.AddExtension = true;
            DialogOpen.RestoreDirectory = true;
            DialogOpen.Title = "Select Program";
            DialogOpen.InitialDirectory = Application.ExecutablePath;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = DialogOpen.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogOpen = new OpenFileDialog();
            DialogOpen.DefaultExt = "exe";
            DialogOpen.Filter = "EXE file (*.exe)|*.exe|All files (*.*)|*.*";
            DialogOpen.AddExtension = true;
            DialogOpen.RestoreDirectory = true;
            DialogOpen.Title = "Select Program";
            DialogOpen.InitialDirectory = Application.ExecutablePath;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = DialogOpen.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogOpen = new OpenFileDialog();
            DialogOpen.DefaultExt = "exe";
            DialogOpen.Filter = "EXE file (*.exe)|*.exe|All files (*.*)|*.*";
            DialogOpen.AddExtension = true;
            DialogOpen.RestoreDirectory = true;
            DialogOpen.Title = "Select Program";
            DialogOpen.InitialDirectory = Application.ExecutablePath;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = DialogOpen.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogOpen = new OpenFileDialog();
            DialogOpen.DefaultExt = "exe";
            DialogOpen.Filter = "EXE file (*.exe)|*.exe|All files (*.*)|*.*";
            DialogOpen.AddExtension = true;
            DialogOpen.RestoreDirectory = true;
            DialogOpen.Title = "Select Program";
            DialogOpen.InitialDirectory = Application.ExecutablePath;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = DialogOpen.FileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogOpen = new OpenFileDialog();
            DialogOpen.DefaultExt = "exe";
            DialogOpen.Filter = "EXE file (*.exe)|*.exe|All files (*.*)|*.*";
            DialogOpen.AddExtension = true;
            DialogOpen.RestoreDirectory = true;
            DialogOpen.Title = "Select Program";
            DialogOpen.InitialDirectory = Application.ExecutablePath;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = DialogOpen.FileName;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox16.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox16.Text = comp_fbd.SelectedPath;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox15.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox15.Text = comp_fbd.SelectedPath;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox14.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox14.Text = comp_fbd.SelectedPath;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox13.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox13.Text = comp_fbd.SelectedPath;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox12.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox12.Text = comp_fbd.SelectedPath;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox11.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox11.Text = comp_fbd.SelectedPath;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox10.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox10.Text = comp_fbd.SelectedPath;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox9.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox9.Text = comp_fbd.SelectedPath;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox17.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox17.Text = comp_fbd.SelectedPath;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog comp_fbd = new FolderBrowserDialog();
            comp_fbd.SelectedPath = textBox18.Text;

            if (comp_fbd.ShowDialog() == DialogResult.OK)
            {
                textBox18.Text = comp_fbd.SelectedPath;
            }
        }

        private void checkBox_keepDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_keepDefault.Checked)
            {
                Config.Default();
            }
            else
            {
                // read file
            }

            loadPathFromObject();

            button1.Enabled = textBox1.Enabled = !checkBox_keepDefault.Checked;
            button2.Enabled = textBox2.Enabled = !checkBox_keepDefault.Checked;
            button3.Enabled = textBox3.Enabled = !checkBox_keepDefault.Checked;
            button4.Enabled = textBox4.Enabled = !checkBox_keepDefault.Checked;
            button5.Enabled = textBox5.Enabled = !checkBox_keepDefault.Checked;
            button6.Enabled = textBox6.Enabled = !checkBox_keepDefault.Checked;
            button7.Enabled = textBox7.Enabled = !checkBox_keepDefault.Checked;
            button8.Enabled = textBox8.Enabled = !checkBox_keepDefault.Checked;
            button9.Enabled = textBox9.Enabled = !checkBox_keepDefault.Checked;
            button10.Enabled = textBox10.Enabled = !checkBox_keepDefault.Checked;
            button11.Enabled = textBox11.Enabled = !checkBox_keepDefault.Checked;
            button12.Enabled = textBox12.Enabled = !checkBox_keepDefault.Checked;
            button13.Enabled = textBox13.Enabled = !checkBox_keepDefault.Checked;
            button14.Enabled = textBox14.Enabled = !checkBox_keepDefault.Checked;
            button15.Enabled = textBox15.Enabled = !checkBox_keepDefault.Checked;
            button16.Enabled = textBox16.Enabled = !checkBox_keepDefault.Checked;
            button17.Enabled = textBox17.Enabled = !checkBox_keepDefault.Checked;
            button18.Enabled = textBox18.Enabled = !checkBox_keepDefault.Checked;
        }

        private void loadPathFromObject()
        {
            textBox1.Text = Config.GET_STOCK_DATA_EXE;
            textBox2.Text = Config.GET_TBILL_DATA_EXE;
            textBox3.Text = Config.CLUSTER_STOCK_DATA_EXE;
            textBox4.Text = Config.CATEGORIZE_STOCK_DATA_EXE;
            textBox5.Text = Config.FILTER_STOCK_DATA_EXE;
            textBox6.Text = Config.TIMING_STOCK_DATA_EXE;
            textBox7.Text = Config.COMPILE_STOCK_DATA_EXE;
            textBox8.Text = Config.OPTIMIZE_PORTFOLIO_EXE;

            textBox16.Text = Config.ENVIRONMENT_PATH_DEFAULT;
            textBox15.Text = Config.DATA_PATH_DEFAULT;
            textBox14.Text = Config.CLUSTER_PATH_DEFAULT;
            textBox13.Text = Config.STOCK_PATH_DEFAULT;
            textBox12.Text = Config.GENUS_PATH_DEFAULT;
            textBox11.Text = Config.INDEX_PATH_DEFAULT;
            textBox10.Text = Config.TBILL_PATH_DEFAULT;
            textBox9.Text = Config.STAT_PATH_DEFAULT;

            textBox17.Text = Config.EXPORT_PATH_DEFAULT;
            textBox18.Text = Config.LOG_PATH_DEFAULT;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                Config.GET_STOCK_DATA_EXE = textBox1.Text;
                Config.GET_TBILL_DATA_EXE = textBox2.Text;
                Config.CLUSTER_STOCK_DATA_EXE = textBox3.Text;
                Config.CATEGORIZE_STOCK_DATA_EXE = textBox4.Text;
                Config.FILTER_STOCK_DATA_EXE = textBox5.Text;
                Config.TIMING_STOCK_DATA_EXE = textBox6.Text;
                Config.COMPILE_STOCK_DATA_EXE = textBox7.Text;
                Config.OPTIMIZE_PORTFOLIO_EXE = textBox8.Text;

                Config.ENVIRONMENT_PATH_DEFAULT = textBox16.Text;
                Config.DATA_PATH_DEFAULT = textBox15.Text;
                Config.CLUSTER_PATH_DEFAULT = textBox14.Text;
                Config.STOCK_PATH_DEFAULT = textBox13.Text;
                Config.GENUS_PATH_DEFAULT = textBox12.Text;
                Config.INDEX_PATH_DEFAULT = textBox11.Text;
                Config.TBILL_PATH_DEFAULT = textBox10.Text;
                Config.STAT_PATH_DEFAULT = textBox9.Text;

                Config.EXPORT_PATH_DEFAULT = textBox17.Text;
                Config.LOG_PATH_DEFAULT = textBox18.Text;

                Config.Write();

                MessageBox.Show("Changes saved.", "Environment Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                MessageBox.Show("Changes fail to save. Please check log for details.", "Environment Path",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
