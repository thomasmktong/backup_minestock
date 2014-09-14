namespace FYP_GUI_v1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treasuryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preprocessDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterHolidayTicksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTheDataPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discretizeByPriceChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discretizeByPriceLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.resetEnvironmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portfolioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kmeanClusteringMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identicalFixedLengthSequenceDiscoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.similarMotifDiscoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.automatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.environmentPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.monitorToolStripMenuItem,
            this.analyzeToolStripMenuItem,
            this.configueToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseToolStripMenuItem,
            this.browseLogToolStripMenuItem,
            this.toolStripSeparator6,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.browseToolStripMenuItem.Text = "Browse Environment";
            this.browseToolStripMenuItem.Click += new System.EventHandler(this.browseToolStripMenuItem_Click);
            // 
            // browseLogToolStripMenuItem
            // 
            this.browseLogToolStripMenuItem.Name = "browseLogToolStripMenuItem";
            this.browseLogToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.browseLogToolStripMenuItem.Text = "Browse Log";
            this.browseLogToolStripMenuItem.Click += new System.EventHandler(this.browseLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(169, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateDataToolStripMenuItem,
            this.preprocessDataToolStripMenuItem,
            this.toolStripSeparator3,
            this.resetEnvironmentToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // updateDataToolStripMenuItem
            // 
            this.updateDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.treasuryToolStripMenuItem});
            this.updateDataToolStripMenuItem.Name = "updateDataToolStripMenuItem";
            this.updateDataToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.updateDataToolStripMenuItem.Text = "Update Data";
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.stockToolStripMenuItem.Text = "Stock...";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.updateStockDataToolStripMenuItem_Click);
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.indexToolStripMenuItem.Text = "Index...";
            this.indexToolStripMenuItem.Click += new System.EventHandler(this.updateIndexDataToolStripMenuItem_Click);
            // 
            // treasuryToolStripMenuItem
            // 
            this.treasuryToolStripMenuItem.Name = "treasuryToolStripMenuItem";
            this.treasuryToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.treasuryToolStripMenuItem.Text = "Treasury...";
            this.treasuryToolStripMenuItem.Click += new System.EventHandler(this.updateTbillDataToolStripMenuItem_Click);
            // 
            // preprocessDataToolStripMenuItem
            // 
            this.preprocessDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterHolidayTicksToolStripMenuItem,
            this.changeTheDataPeriodToolStripMenuItem,
            this.compileStatisticsToolStripMenuItem,
            this.discretizeByPriceChangeToolStripMenuItem,
            this.discretizeByPriceLevelToolStripMenuItem});
            this.preprocessDataToolStripMenuItem.Name = "preprocessDataToolStripMenuItem";
            this.preprocessDataToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.preprocessDataToolStripMenuItem.Text = "Preprocess Data";
            // 
            // filterHolidayTicksToolStripMenuItem
            // 
            this.filterHolidayTicksToolStripMenuItem.Name = "filterHolidayTicksToolStripMenuItem";
            this.filterHolidayTicksToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.filterHolidayTicksToolStripMenuItem.Text = "Filter Holiday Ticks...";
            this.filterHolidayTicksToolStripMenuItem.Click += new System.EventHandler(this.filterHolidayTicksToolStripMenuItem_Click);
            // 
            // changeTheDataPeriodToolStripMenuItem
            // 
            this.changeTheDataPeriodToolStripMenuItem.Name = "changeTheDataPeriodToolStripMenuItem";
            this.changeTheDataPeriodToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.changeTheDataPeriodToolStripMenuItem.Text = "Change the Data Period...";
            this.changeTheDataPeriodToolStripMenuItem.Click += new System.EventHandler(this.changeTheDataPeriodToolStripMenuItem_Click);
            // 
            // compileStatisticsToolStripMenuItem
            // 
            this.compileStatisticsToolStripMenuItem.Name = "compileStatisticsToolStripMenuItem";
            this.compileStatisticsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.compileStatisticsToolStripMenuItem.Text = "Compile Statistics...";
            this.compileStatisticsToolStripMenuItem.Click += new System.EventHandler(this.compileStatisticsToolStripMenuItem_Click);
            // 
            // discretizeByPriceChangeToolStripMenuItem
            // 
            this.discretizeByPriceChangeToolStripMenuItem.Name = "discretizeByPriceChangeToolStripMenuItem";
            this.discretizeByPriceChangeToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.discretizeByPriceChangeToolStripMenuItem.Text = "Discretize by Price Change...";
            this.discretizeByPriceChangeToolStripMenuItem.Click += new System.EventHandler(this.discretizeByPriceChangeToolStripMenuItem_Click);
            // 
            // discretizeByPriceLevelToolStripMenuItem
            // 
            this.discretizeByPriceLevelToolStripMenuItem.Name = "discretizeByPriceLevelToolStripMenuItem";
            this.discretizeByPriceLevelToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.discretizeByPriceLevelToolStripMenuItem.Text = "Discretize by Price Level...";
            this.discretizeByPriceLevelToolStripMenuItem.Click += new System.EventHandler(this.discretizeByPriceLevelToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
            // 
            // resetEnvironmentToolStripMenuItem
            // 
            this.resetEnvironmentToolStripMenuItem.Name = "resetEnvironmentToolStripMenuItem";
            this.resetEnvironmentToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.resetEnvironmentToolStripMenuItem.Text = "Reset Environment";
            this.resetEnvironmentToolStripMenuItem.Click += new System.EventHandler(this.resetEnvironmentToolStripMenuItem_Click);
            // 
            // monitorToolStripMenuItem
            // 
            this.monitorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.watchListToolStripMenuItem,
            this.portfolioToolStripMenuItem,
            this.toolStripSeparator5,
            this.chartToolStripMenuItem});
            this.monitorToolStripMenuItem.Name = "monitorToolStripMenuItem";
            this.monitorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.monitorToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.monitorToolStripMenuItem.Text = "Monitor";
            // 
            // watchListToolStripMenuItem
            // 
            this.watchListToolStripMenuItem.Name = "watchListToolStripMenuItem";
            this.watchListToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.watchListToolStripMenuItem.Text = "Watch List";
            this.watchListToolStripMenuItem.Click += new System.EventHandler(this.watchListToolStripMenuItem_Click);
            // 
            // portfolioToolStripMenuItem
            // 
            this.portfolioToolStripMenuItem.Name = "portfolioToolStripMenuItem";
            this.portfolioToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.portfolioToolStripMenuItem.Text = "Portfolio";
            this.portfolioToolStripMenuItem.Click += new System.EventHandler(this.portfolioToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(135, 6);
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.chartToolStripMenuItem.Text = "View Chart...";
            this.chartToolStripMenuItem.Click += new System.EventHandler(this.chartToolStripMenuItem_Click);
            // 
            // analyzeToolStripMenuItem
            // 
            this.analyzeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kmeanClusteringMethodToolStripMenuItem,
            this.identicalFixedLengthSequenceDiscoveryToolStripMenuItem,
            this.similarMotifDiscoveryToolStripMenuItem,
            this.toolStripSeparator2,
            this.viewResultsToolStripMenuItem,
            this.toolStripSeparator4,
            this.automatorToolStripMenuItem});
            this.analyzeToolStripMenuItem.Name = "analyzeToolStripMenuItem";
            this.analyzeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.analyzeToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.analyzeToolStripMenuItem.Text = "Analyze";
            // 
            // kmeanClusteringMethodToolStripMenuItem
            // 
            this.kmeanClusteringMethodToolStripMenuItem.Name = "kmeanClusteringMethodToolStripMenuItem";
            this.kmeanClusteringMethodToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.kmeanClusteringMethodToolStripMenuItem.Text = "K-means Clustering Method...";
            this.kmeanClusteringMethodToolStripMenuItem.Click += new System.EventHandler(this.kmeanClusteringMethodToolStripMenuItem_Click);
            // 
            // identicalFixedLengthSequenceDiscoveryToolStripMenuItem
            // 
            this.identicalFixedLengthSequenceDiscoveryToolStripMenuItem.Name = "identicalFixedLengthSequenceDiscoveryToolStripMenuItem";
            this.identicalFixedLengthSequenceDiscoveryToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.identicalFixedLengthSequenceDiscoveryToolStripMenuItem.Text = "Identical Fixed Length Sequence Discovery...";
            this.identicalFixedLengthSequenceDiscoveryToolStripMenuItem.Click += new System.EventHandler(this.identicalFixedLengthSequenceDiscoveryToolStripMenuItem_Click);
            // 
            // similarMotifDiscoveryToolStripMenuItem
            // 
            this.similarMotifDiscoveryToolStripMenuItem.Name = "similarMotifDiscoveryToolStripMenuItem";
            this.similarMotifDiscoveryToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.similarMotifDiscoveryToolStripMenuItem.Text = "Similar Motif Discovery...";
            this.similarMotifDiscoveryToolStripMenuItem.Click += new System.EventHandler(this.similarMotifDiscoveryToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(289, 6);
            // 
            // viewResultsToolStripMenuItem
            // 
            this.viewResultsToolStripMenuItem.Name = "viewResultsToolStripMenuItem";
            this.viewResultsToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.viewResultsToolStripMenuItem.Text = "View Results";
            this.viewResultsToolStripMenuItem.Click += new System.EventHandler(this.viewResultsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(289, 6);
            // 
            // automatorToolStripMenuItem
            // 
            this.automatorToolStripMenuItem.Name = "automatorToolStripMenuItem";
            this.automatorToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.automatorToolStripMenuItem.Text = "Automator";
            this.automatorToolStripMenuItem.Click += new System.EventHandler(this.automatorToolStripMenuItem_Click);
            // 
            // configueToolStripMenuItem
            // 
            this.configueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liveCaptureToolStripMenuItem,
            this.toolStripSeparator7,
            this.environmentPathToolStripMenuItem});
            this.configueToolStripMenuItem.Name = "configueToolStripMenuItem";
            this.configueToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.configueToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.configueToolStripMenuItem.Text = "Configue";
            // 
            // liveCaptureToolStripMenuItem
            // 
            this.liveCaptureToolStripMenuItem.Name = "liveCaptureToolStripMenuItem";
            this.liveCaptureToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.liveCaptureToolStripMenuItem.Text = "Live Capture Module Output";
            this.liveCaptureToolStripMenuItem.Click += new System.EventHandler(this.liveCaptureToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(206, 6);
            // 
            // environmentPathToolStripMenuItem
            // 
            this.environmentPathToolStripMenuItem.Name = "environmentPathToolStripMenuItem";
            this.environmentPathToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.environmentPathToolStripMenuItem.Text = "Environment Path...";
            this.environmentPathToolStripMenuItem.Click += new System.EventHandler(this.environmentPathToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arrangeToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // arrangeToolStripMenuItem
            // 
            this.arrangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem});
            this.arrangeToolStripMenuItem.Name = "arrangeToolStripMenuItem";
            this.arrangeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.arrangeToolStripMenuItem.Text = "Arrange";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 719);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MineStock Workbench";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kmeanClusteringMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treasuryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetEnvironmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preprocessDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liveCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discretizeByPriceChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discretizeByPriceLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeTheDataPeriodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem identicalFixedLengthSequenceDiscoveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem similarMotifDiscoveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterHolidayTicksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watchListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portfolioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem automatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem viewResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem compileStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem environmentPathToolStripMenuItem;

    }
}

