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
    public partial class Form_ViewPortfolio : Form
    {
        private MainForm pointer_MainForm = null;

        public Form_ViewPortfolio(MainForm pointer)
        {
            InitializeComponent();

            // customization
            this.pointer_MainForm = pointer;

            // summary grid view
            string[][] gridAry = new string[12][];

            gridAry[0] = new string[] { "Present:", "" };
            gridAry[1] = new string[] { "E(R), % p.a.", "" };
            gridAry[2] = new string[] { "Shapre", "" };
            gridAry[3] = new string[] { "Beta", "" };
            gridAry[4] = new string[] { "Alpha", "" };
            gridAry[5] = new string[] { "%VaR, 5%", "" };
            gridAry[6] = new string[] { "Optimized:", "" };
            gridAry[7] = new string[] { "E(R), % p.a.", "" };
            gridAry[8] = new string[] { "Shapre", "" };
            gridAry[9] = new string[] { "Beta", "" };
            gridAry[10] = new string[] { "Alpha", "" };
            gridAry[11] = new string[] { "%VaR, 5%", "" };


            for (int i = 0; i < gridAry.Length; i++)
            {
                dataGridView_summary.Rows.Add(gridAry[i]);
            }

            dataGridView_summary.Rows[0].DefaultCellStyle.Font = new Font(dataGridView_summary.Font, FontStyle.Bold);
            dataGridView_summary.Rows[6].DefaultCellStyle.Font = new Font(dataGridView_summary.Font, FontStyle.Bold);

            try
            {
                this.UpdatePortfolioScn();
                this.UpdateSummaryScn();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
            }
        }

        private void dataGridView_portfolio_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // update portfolio grid
            if (e.ColumnIndex != 0)
            {
                Model_ViewPortfolio.UpdateList();
                dataGridView_portfolio.Refresh();
            }
            else
            {
                Model_ViewPortfolio.ResetWeighting();
                Model_ViewPortfolio.UpdateList();
                dataGridView_portfolio.Refresh();
            }

            this.UpdateSummaryScn();
        }

        private void toolStripButton_stockChart_Click(object sender, EventArgs e)
        {
            try
            {
                string code = dataGridView_portfolio.
                    Rows[dataGridView_portfolio.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();

                string path = Config.STOCK_PATH_DEFAULT + @"\" + code + ".xml";
                Stock stock = XMLHelper.StockFromXML(path);
                Form_StockChart form_st = new Form_StockChart(stock);
                form_st.MdiParent = pointer_MainForm;
                form_st.Show();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
            }
        }

        private void Form_ViewPortfolio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Model_ViewPortfolio.WriteList();
        }

        private void toolStripButton_calculateOptimal_Click(object sender, EventArgs e)
        {
            Model_ViewPortfolio.WriteList();
            Form_CalcPortfolio form_cp = new Form_CalcPortfolio(this);
            form_cp.MdiParent = pointer_MainForm;
            form_cp.Show();
        }

        public void UpdatePortfolioScn()
        {
            Model_ViewPortfolio.LoadList();
            dataGridView_portfolio.DataSource = Model_ViewPortfolio.list;
            dataGridView_portfolio.Refresh();
        }

        public void UpdateSummaryScn()
        {
            try
            {
                double annualReturn = Model_ViewPortfolio.PortfolioReturn(Model_ViewPortfolio.CalculationMode.CURRENT);
                double annualSD = Model_ViewPortfolio.PortfolioVolatility(Model_ViewPortfolio.CalculationMode.CURRENT);
                double sharpe = Model_ViewPortfolio.PortfolioSharpe(Model_ViewPortfolio.CalculationMode.CURRENT);
                double beta = Model_ViewPortfolio.PortfolioBeta(Model_ViewPortfolio.CalculationMode.CURRENT);
                double alpha = Model_ViewPortfolio.PortfolioAlpha(Model_ViewPortfolio.CalculationMode.CURRENT);

                dataGridView_summary.Rows[1].Cells[1].Value = Math.Round(annualReturn * 100, 2);
                dataGridView_summary.Rows[2].Cells[1].Value = Math.Round(sharpe, 2);
                dataGridView_summary.Rows[3].Cells[1].Value = Math.Round(beta, 2);
                dataGridView_summary.Rows[4].Cells[1].Value = Math.Round(alpha, 2);
                dataGridView_summary.Rows[5].Cells[1].Value = Math.Round(annualSD / Math.Sqrt(250) * 100 * StatHelper.GetNormsInv(0.05), 2);

                if (Model_ViewPortfolio.PortfolioOptimized())
                {
                    annualReturn = Model_ViewPortfolio.PortfolioReturn(Model_ViewPortfolio.CalculationMode.TARGET);
                    annualSD = Model_ViewPortfolio.PortfolioVolatility(Model_ViewPortfolio.CalculationMode.TARGET);
                    sharpe = Model_ViewPortfolio.PortfolioSharpe(Model_ViewPortfolio.CalculationMode.TARGET);
                    beta = Model_ViewPortfolio.PortfolioBeta(Model_ViewPortfolio.CalculationMode.TARGET);
                    alpha = Model_ViewPortfolio.PortfolioAlpha(Model_ViewPortfolio.CalculationMode.TARGET);

                    dataGridView_summary.Rows[7].Cells[1].Value = Math.Round(annualReturn * 100, 2);
                    dataGridView_summary.Rows[8].Cells[1].Value = Math.Round(sharpe, 2);
                    dataGridView_summary.Rows[9].Cells[1].Value = Math.Round(beta, 2);
                    dataGridView_summary.Rows[10].Cells[1].Value = Math.Round(alpha, 2);
                    dataGridView_summary.Rows[11].Cells[1].Value = Math.Round(annualSD / Math.Sqrt(250) * 100 * StatHelper.GetNormsInv(0.05));
                }
                else
                {
                    for (int i = 7; i <= 11; i++)
                    {
                        dataGridView_summary.Rows[i].Cells[1].Value = "";
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                MessageBox.Show("Statistic files corrupted, please rerun compile statistic module.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton_addStock_Click(object sender, EventArgs e)
        {
            try
            {
                Model_ViewPortfolio temp = new Model_ViewPortfolio();
                temp.StockCode = toolStripTextBox_stockCode.Text;
                Model_ViewPortfolio.list.Add(temp);
                Model_ViewPortfolio.UpdateList();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
            }

            toolStripTextBox_stockCode.Text = "<Enter stock code here>";
        }

        private void toolStripButton_rmStock_Click(object sender, EventArgs e)
        {
            try
            {
                Model_ViewPortfolio.list.RemoveAt(dataGridView_portfolio.SelectedCells[0].RowIndex);
                Model_ViewPortfolio.ResetWeighting();
                Model_ViewPortfolio.UpdateList();
                dataGridView_portfolio.Refresh();
                this.UpdateSummaryScn();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
            }
        }

        private void toolStripTextBox_stockCode_Click(object sender, EventArgs e)
        {
            toolStripTextBox_stockCode.Text = "";
        }

        private void toolStripButton_key_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Model_Key.portfolio_key(), "Key on Figures", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
