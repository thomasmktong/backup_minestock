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
using Equin.ApplicationFramework;

namespace FYP_GUI_v1
{
    public partial class Form_ViewResult : Form
    {
        private bool portfolioLinked = false;
        private MainForm pointer_MainForm = null;

        private TreeNode allStocksNode = null;
        private TreeNode mainNode = null;

        public Form_ViewResult(MainForm pointer)
        {
            InitializeComponent();
            this.pointer_MainForm = pointer;

            // fetch clustering result from environment every time when this form shows
            this.allStocksNode = new TreeNode();
            this.allStocksNode.Name = "allStocksNode";
            this.allStocksNode.Text = "All stocks";
            this.treeView1.Nodes.Add(allStocksNode);

            this.mainNode = new TreeNode();
            this.mainNode.Name = "mainNode";
            this.mainNode.Text = "Cluster";
            this.treeView1.Nodes.Add(mainNode);
            this.RecuriveTreePopulation(Config.CLUSTER_PATH_DEFAULT, Config.CLUSTER_PATH_DEFAULT, mainNode);
            mainNode.Expand();
        }

        private void RecuriveTreePopulation(String rootPath, string mamaPath, TreeNode mamaNode)
        {
            foreach (string eachPathEntry in Directory.GetFileSystemEntries(mamaPath))
            {
                TreeNode node = new TreeNode();
                node.Name = eachPathEntry.Replace(rootPath, "");

                if (File.Exists(eachPathEntry))
                {
                    if (eachPathEntry.EndsWith(".xml"))
                    {
                        node.Text = "Cluster " + Path.GetFileNameWithoutExtension(eachPathEntry);

                        // check if there is sub cluster
                        if (Directory.Exists(eachPathEntry.Replace(".xml", "")))
                        {
                            this.RecuriveTreePopulation(rootPath, eachPathEntry.Replace(".xml", ""), node);
                        }
                    }
                    else
                    {
                        continue;
                    }
                    mamaNode.Nodes.Add(node);
                }

                if (Directory.Exists(eachPathEntry) && !File.Exists(eachPathEntry + ".xml"))
                {
                    node.Text = eachPathEntry.Substring(eachPathEntry.LastIndexOf('\\') + 1);
                    this.RecuriveTreePopulation(rootPath, eachPathEntry, node);
                    mamaNode.Nodes.Add(node);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == this.allStocksNode)
                {
                    this.toolStripButton_filterInsuff.Enabled = true;

                    BindingList<Model_ViewResult> modelList = new BindingList<Model_ViewResult>();

                    foreach (string fileName in Directory.GetFiles(Config.STAT_PATH_DEFAULT))
                    {
                        if (fileName.EndsWith(".xml") && !fileName.EndsWith(Statistic.FAKE_FILE_FILE_NAME + ".xml"))
                        {
                            try
                            {
                                Statistic eachStat = (Statistic)XMLHelper.ObjectFromXML(fileName, typeof(Statistic));
                                Model_ViewResult eachItemInTable = new Model_ViewResult(eachStat);
                                modelList.Add(eachItemInTable);
                            }
                            catch (Exception ex)
                            {
                                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
                            }
                        }
                    }

                    BindingListView<Model_ViewResult> temp = new BindingListView<Model_ViewResult>(modelList);
                    this.dataGridView1.DataSource = temp;
                    if (portfolioLinked) maintainPortfolioLinkage();
                }
                else if (treeView1.SelectedNode == this.mainNode)
                {
                    this.toolStripButton_filterInsuff.Enabled = false;
                    this.dataGridView1.DataSource = null;
                }
                else
                {
                    this.toolStripButton_filterInsuff.Enabled = false;
                    string clusterPath = Config.CLUSTER_PATH_DEFAULT + treeView1.SelectedNode.Name;

                    if (File.Exists(clusterPath))
                    {
                        if (clusterPath.EndsWith(".xml"))
                        {
                            // **********
                            // Binding list view by http://blw.sourceforge.net/
                            // **********

                            Cluster cluster = XMLHelper.ClusterFromXML(clusterPath);
                            BindingList<Model_ViewResult> modelList = new BindingList<Model_ViewResult>();

                            foreach (int eachStockCode in cluster.stockCodeList)
                            {
                                string statPath = Config.STAT_PATH_DEFAULT + @"\" + eachStockCode + ".xml";

                                Statistic eachStat = (Statistic)XMLHelper.ObjectFromXML(statPath, typeof(Statistic));
                                Model_ViewResult eachItemInTable = new Model_ViewResult(eachStat);
                                modelList.Add(eachItemInTable);
                            }

                            BindingListView<Model_ViewResult> temp = new BindingListView<Model_ViewResult>(modelList);
                            this.dataGridView1.DataSource = temp;
                            if (portfolioLinked) maintainPortfolioLinkage();
                        }
                        else
                        {
                            return;
                        }

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

        private void toolStripButton_stockChart_Click(object sender, EventArgs e)
        {
            try
            {
                string code = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
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

        private void toolStripButton_linkPortfolio_Click(object sender, EventArgs e)
        {
            this.portfolioLinked = !portfolioLinked;
            if (portfolioLinked && maintainPortfolioLinkage())
            {
                toolStripButton_linkPortfolio.Text = "Unlink portfolio";
            }
            else
            {
                toolStripButton_linkPortfolio.Text = "Link portfolio";
                this.ResetTreeNodeColor(mainNode);
                this.ResetGriaViewColor(dataGridView1);
                portfolioLinked = false;
            }
        }

        private bool maintainPortfolioLinkage()
        {
            if (dataGridView1.DataSource != null && Model_ViewPortfolio.list != null)
            {
                this.ResetGriaViewColor(dataGridView1);

                foreach (Model_ViewPortfolio portfolioElm in Model_ViewPortfolio.list)
                {
                    // highlight the current data grid view
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value != null &&
                            dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(portfolioElm.StockCode))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
                maintainPortfolioLinkage_recursive(mainNode, Model_ViewPortfolio.list);
                return true;
            }
            else
            {
                MessageBox.Show("Please load the portfolio first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool maintainPortfolioLinkage_recursive(TreeNode searchRoot, BindingList<Model_ViewPortfolio> searchElmList)
        {
            searchRoot.BackColor = Color.White;
            bool toReturn = false;

            try
            {
                foreach (TreeNode eachClusterNode in searchRoot.Nodes)
                {
                    bool subResult = maintainPortfolioLinkage_recursive(eachClusterNode, searchElmList);

                    if (subResult)
                    {
                        eachClusterNode.BackColor = Color.Yellow;
                        toReturn = true;
                    }
                    else
                    {
                        string path = Config.CLUSTER_PATH_DEFAULT + eachClusterNode.Name;
                        Cluster clusterElmList = XMLHelper.ClusterFromXML(path);

                        foreach (int eachStockCode in clusterElmList.stockCodeList)
                        {
                            bool toBreak = false;

                            foreach (Model_ViewPortfolio eachSearchElm in searchElmList)
                            {
                                if (eachStockCode == int.Parse(eachSearchElm.StockCode))
                                {
                                    eachClusterNode.BackColor = Color.Yellow;
                                    toBreak = true;
                                    toReturn = true;
                                    break;
                                }
                                if (toBreak) break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger(typeof(MainForm)).FullLog(ex.ToString(), "IGNORE");
            }
            return toReturn;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (portfolioLinked) maintainPortfolioLinkage();
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            if (portfolioLinked) maintainPortfolioLinkage();
        }

        private void Form_ViewResult_Enter(object sender, EventArgs e)
        {
            if (portfolioLinked) maintainPortfolioLinkage();
        }

        private void ResetTreeNodeColor(TreeNode node)
        {
            node.BackColor = Color.White;
            foreach (TreeNode eachNode in node.Nodes) ResetTreeNodeColor(eachNode);
        }

        private void ResetGriaViewColor(DataGridView view)
        {
            for (int i = 0; i < view.Rows.Count; i++)
            {
                view.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void toolStripButton_filterUnder_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value != null &&
                    double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) <= 0)
                {
                    dataGridView1.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void toolStripButton_addPortfolio_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null && Model_ViewPortfolio.list != null)
            {
                string code = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                Model_ViewPortfolio model_vp = new Model_ViewPortfolio();
                model_vp.StockCode = code;
                Model_ViewPortfolio.list.Add(model_vp);
                Model_ViewPortfolio.UpdateList();
                Model_ViewPortfolio.ResetWeighting();
            }
            else
            {
                MessageBox.Show("Please load the portfolio first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton_filterInsuff_Click(object sender, EventArgs e)
        {
            try
            {
                Statistic fakeStat = (Statistic)XMLHelper.ObjectFromXML(Config.STAT_PATH_DEFAULT + "\\" +
                    Statistic.FAKE_FILE_FILE_NAME + ".xml", typeof(Statistic));

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string code = dataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
                    Statistic stock = (Statistic)XMLHelper.ObjectFromXML(Config.STAT_PATH_DEFAULT + "\\" + code + ".xml", typeof(Statistic));

                    if (stock.sampleCount < fakeStat.sampleCount)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                        i--;
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

        private void toolStripButton_key_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Model_Key.results_key(), "Key on Figures", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
