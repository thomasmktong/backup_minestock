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
    public partial class Form_WatchList : Form
    {
        private MainForm pointer_MainForm = null;

        public Form_WatchList(MainForm pointer)
        {
            InitializeComponent();

            // customization
            Model_WatchList.LoadList();
            dataGridView1.DataSource = Model_WatchList.list;
            this.pointer_MainForm = pointer;
        }

        private void toolStripButton_add_Click(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(toolStripTextBox_stockCode.Text, out i))
            {
                dataGridView1.DataSource = null;
                Model_WatchList.list.Add(new Model_WatchList(toolStripTextBox_stockCode.Text));
                dataGridView1.DataSource = Model_WatchList.list;
                toolStripTextBox_stockCode.Text = "<Enter stock code here>";
            }
        }

        private void toolStripButton_remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Model_WatchList.list.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }

        private void toolStripTextBox_stockCode_Click(object sender, EventArgs e)
        {
            toolStripTextBox_stockCode.Text = "";
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Model_WatchList.UpdateList();
            dataGridView1.Refresh();
        }

        private void Form_WatchList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Model_WatchList.WriteList();
        }

        private void toolStripButton_chart_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Stock temp = Model_WatchList.list[dataGridView1.SelectedRows[0].Index].GetStockInstance();
                // List<Stock> stockList = new List<Stock>();
                // for (int i = 0; i < Model_WatchList.list.Count; i++)
                // {
                //     stockList.Add(Model_WatchList.list[i].GetStockInstance());
                // }
                Form_StockChart form_st = new Form_StockChart(temp);
                form_st.MdiParent = pointer_MainForm;
                form_st.Show();
            }
        }
    }
}
