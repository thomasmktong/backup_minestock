using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FYP_Common;

namespace FYP_GUI_v1
{
    public partial class MainForm : Form
    {
        public List<string> automatableList = new List<string>();
        private Form_WatchList form_watchList = null;
        private Form_Automator form_automator = null;
        private Form_ViewChart form_viewChart = null;
        private Form_ViewResult form_viewResult = null;
        private Form_ViewPortfolio form_viewPortfolio = null;

        private void initializeMapping()
        {
            automatableList.Add(stockToolStripMenuItem.ToString().Replace("...", ""));
            automatableList.Add(indexToolStripMenuItem.ToString().Replace("...", ""));
            automatableList.Add(treasuryToolStripMenuItem.ToString().Replace("...", ""));
            automatableList.Add(filterHolidayTicksToolStripMenuItem.ToString().Replace("...", ""));
            automatableList.Add(changeTheDataPeriodToolStripMenuItem.ToString().Replace("...", ""));
            // automatableList.Add("Use Subset for Following Action");
            automatableList.Add(compileStatisticsToolStripMenuItem.ToString().Replace("...", ""));
            automatableList.Add(discretizeByPriceChangeToolStripMenuItem.ToString().Replace("...", ""));
            automatableList.Add(discretizeByPriceLevelToolStripMenuItem.ToString().Replace("...", ""));
            automatableList.Add(kmeanClusteringMethodToolStripMenuItem.ToString().Replace("...", ""));
            automatableList.Add(identicalFixedLengthSequenceDiscoveryToolStripMenuItem.ToString().Replace("...", ""));
            automatableList.Add(similarMotifDiscoveryToolStripMenuItem.ToString().Replace("...", ""));
        }

        public Form getRespectiveForm(Object sender)
        {
            Form toReturn = null;

            //if (!automatableList.TryGetValue(sender.ToString().Replace("...", ""), out toReturn) || toReturn == null)
            if (true)
            {
                if (stockToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // data -> update data -> stock
                    toReturn = new Form_GetStockData();
                }
                else if (indexToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // data -> update data -> index
                    toReturn = new Form_GetStockData();
                    ((Form_GetStockData)toReturn).call_indexMode();
                }
                else if (treasuryToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // data -> update data -> treasury
                    toReturn = new Form_GetTbillData();
                }
                else if (filterHolidayTicksToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // data -> preprocess data -> filter holiday ticks
                    toReturn = new Form_FilterStockData();
                }
                else if (changeTheDataPeriodToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // data -> preprocess data -> change the data period
                    toReturn = new Form_CombineStockData();
                }
                else if (compileStatisticsToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // data -> preprocess data -> compile stat
                    toReturn = new Form_CompileStatistics();
                }
                else if (discretizeByPriceChangeToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // data -> preprocess data -> discretize by price change
                    toReturn = new Form_CatByUpDown();
                }
                else if (discretizeByPriceLevelToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // data -> preprocess data -> discretize by price level
                    toReturn = new Form_CatByAboveBelow();
                }
                else if (kmeanClusteringMethodToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // analyze -> k-means clustering method
                    toReturn = new Form_ClusterKmean();
                }
                else if (identicalFixedLengthSequenceDiscoveryToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // analyze -> identical fixed length length sequence discovery
                    toReturn = new Form_ClusterSSEC();
                }
                else if (similarMotifDiscoveryToolStripMenuItem.ToString().StartsWith(sender.ToString().Replace("...", "")))
                {
                    // analyze -> similar motif discovery
                    toReturn = new Form_ClusterMotif();
                }
                else if (sender.ToString().Equals("SUBSET-START"))
                {
                    // special, automational only
                    toReturn = new Form_Autosubset(true);
                }
                else if (sender.ToString().Equals("SUBSET-END"))
                {
                    // special, automational only
                    toReturn = new Form_Autosubset(false);
                }
            }

            // universal settings
            if (toReturn != null)
            {
                toReturn.MdiParent = this;
            }

            return toReturn;
        }

        private void display_form_watchList()
        {
            form_watchList = new Form_WatchList(this);
            form_watchList.MdiParent = this;
            form_watchList.StartPosition = FormStartPosition.Manual;
            relocate_form_watchList();
            form_watchList.Show();
        }

        private void relocate_form_watchList()
        {
            if (this.form_watchList != null)
            {
                form_watchList.Location = new Point((int)(this.Width - form_watchList.Width * 1.04), 0);
            }
        }

        private void display_form_automator()
        {
            form_automator = new Form_Automator(this);
            form_automator.MdiParent = this;
            form_automator.Show();
        }

        private void display_form_viewChart()
        {
            form_viewChart = new Form_ViewChart(this);
            form_viewChart.MdiParent = this;
            form_viewChart.Show();
        }

        private void display_form_viewResult()
        {
            form_viewResult = new Form_ViewResult(this);
            form_viewResult.MdiParent = this;
            form_viewResult.Show();
        }

        private void display_form_viewPortfolio()
        {
            form_viewPortfolio = new Form_ViewPortfolio(this);
            form_viewPortfolio.MdiParent = this;
            form_viewPortfolio.Show();
        }

        public MainForm()
        {
            InitializeComponent();

            // customization - logger
            LogHelper.NewLogger(typeof(MainForm), Config.LOG_PATH_DEFAULT);

            // customization - mapping table
            initializeMapping();

            // customization - live status
            liveCaptureToolStripMenuItem.Checked = Config.LIVE_STATUS;

            // customization - start up window
            display_form_watchList();

            Form_AboutBox form_ab = new Form_AboutBox();
            form_ab.MdiParent = this;
            form_ab.Show();
        }

        private void updateStockDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void updateIndexDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void updateTbillDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ExportStockData form_esd = new Form_ExportStockData();
            form_esd.MdiParent = this;
            form_esd.Show();
        }

        private void kmeanClusteringMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form eachForm in this.MdiChildren)
            {
                eachForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_AboutBox form_ab = new Form_AboutBox();
            form_ab.MdiParent = this;
            form_ab.Show();
        }

        private void resetEnvironmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result =
                MessageBox.Show(this, "Are you sure to reset the environment? This will remove all your data.", "Reset Environment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Directory.Delete(Config.ENVIRONMENT_PATH_DEFAULT, true);
                Config.TryCreateDirectory();
                Model_WatchList.LoadList();

                foreach (Form eachForm in this.MdiChildren)
                {
                    eachForm.Close();
                }

                display_form_watchList();
            }
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Config.ENVIRONMENT_PATH_DEFAULT);
        }

        private void liveCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (liveCaptureToolStripMenuItem.Checked == false)
            {
                var result =
                    MessageBox.Show(this, "Are you sure to enable life status log? This will degrade the performance.", "Live Capture Module Output", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    liveCaptureToolStripMenuItem.Checked = true;
                    Config.LIVE_STATUS = true;
                }
            }
            else
            {
                liveCaptureToolStripMenuItem.Checked = false;
                Config.LIVE_STATUS = false;
            }
        }

        private void discretizeByPriceChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void discretizeByPriceLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void identicalFixedLengthSequenceDiscoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void browseLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Config.LOG_PATH_DEFAULT);
        }

        private void filterHolidayTicksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void watchListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display_form_watchList();
        }

        private void similarMotifDiscoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void changeTheDataPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            relocate_form_watchList();
        }

        private void automatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display_form_automator();
        }

        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display_form_viewChart();
        }

        private void viewResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display_form_viewResult();
        }

        private void compileStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRespectiveForm(sender).Show();
        }

        private void portfolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display_form_viewPortfolio();
        }

        private void environmentPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_EnvPath form_ep = new Form_EnvPath();
            form_ep.MdiParent = this;
            form_ep.Show();
        }
    }
}
