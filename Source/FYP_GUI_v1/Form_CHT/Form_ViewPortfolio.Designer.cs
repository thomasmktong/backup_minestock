namespace FYP_GUI_v1
{
    partial class Form_ViewPortfolio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ViewPortfolio));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_stockChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox_stockCode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_addStock = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_rmStock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_calculateOptimal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_key = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_portfolio = new System.Windows.Forms.DataGridView();
            this.dataGridView_summary = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_portfolio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_summary)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_stockChart,
            this.toolStripSeparator1,
            this.toolStripTextBox_stockCode,
            this.toolStripButton_addStock,
            this.toolStripButton_rmStock,
            this.toolStripSeparator2,
            this.toolStripButton_calculateOptimal,
            this.toolStripSeparator3,
            this.toolStripButton_key});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(839, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_stockChart
            // 
            this.toolStripButton_stockChart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_stockChart.Image")));
            this.toolStripButton_stockChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_stockChart.Name = "toolStripButton_stockChart";
            this.toolStripButton_stockChart.Size = new System.Drawing.Size(105, 22);
            this.toolStripButton_stockChart.Text = "View stock chart";
            this.toolStripButton_stockChart.Click += new System.EventHandler(this.toolStripButton_stockChart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox_stockCode
            // 
            this.toolStripTextBox_stockCode.Name = "toolStripTextBox_stockCode";
            this.toolStripTextBox_stockCode.Size = new System.Drawing.Size(135, 25);
            this.toolStripTextBox_stockCode.Text = "<Enter stock code here>";
            this.toolStripTextBox_stockCode.Click += new System.EventHandler(this.toolStripTextBox_stockCode_Click);
            // 
            // toolStripButton_addStock
            // 
            this.toolStripButton_addStock.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_addStock.Image")));
            this.toolStripButton_addStock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addStock.Name = "toolStripButton_addStock";
            this.toolStripButton_addStock.Size = new System.Drawing.Size(46, 22);
            this.toolStripButton_addStock.Text = "Add";
            this.toolStripButton_addStock.Click += new System.EventHandler(this.toolStripButton_addStock_Click);
            // 
            // toolStripButton_rmStock
            // 
            this.toolStripButton_rmStock.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_rmStock.Image")));
            this.toolStripButton_rmStock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_rmStock.Name = "toolStripButton_rmStock";
            this.toolStripButton_rmStock.Size = new System.Drawing.Size(66, 22);
            this.toolStripButton_rmStock.Text = "Remove";
            this.toolStripButton_rmStock.Click += new System.EventHandler(this.toolStripButton_rmStock_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_calculateOptimal
            // 
            this.toolStripButton_calculateOptimal.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_calculateOptimal.Image")));
            this.toolStripButton_calculateOptimal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_calculateOptimal.Name = "toolStripButton_calculateOptimal";
            this.toolStripButton_calculateOptimal.Size = new System.Drawing.Size(157, 22);
            this.toolStripButton_calculateOptimal.Text = "Calculate optimal weighting";
            this.toolStripButton_calculateOptimal.Click += new System.EventHandler(this.toolStripButton_calculateOptimal_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_key
            // 
            this.toolStripButton_key.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_key.Image")));
            this.toolStripButton_key.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_key.Name = "toolStripButton_key";
            this.toolStripButton_key.Size = new System.Drawing.Size(96, 22);
            this.toolStripButton_key.Text = "Key on figures";
            this.toolStripButton_key.Click += new System.EventHandler(this.toolStripButton_key_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_portfolio);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_summary);
            this.splitContainer1.Size = new System.Drawing.Size(839, 355);
            this.splitContainer1.SplitterDistance = 665;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridView_portfolio
            // 
            this.dataGridView_portfolio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_portfolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_portfolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_portfolio.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_portfolio.Name = "dataGridView_portfolio";
            this.dataGridView_portfolio.Size = new System.Drawing.Size(665, 355);
            this.dataGridView_portfolio.TabIndex = 0;
            this.dataGridView_portfolio.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_portfolio_CellValueChanged);
            // 
            // dataGridView_summary
            // 
            this.dataGridView_summary.AllowUserToAddRows = false;
            this.dataGridView_summary.AllowUserToDeleteRows = false;
            this.dataGridView_summary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_summary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_summary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Value});
            this.dataGridView_summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_summary.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_summary.Name = "dataGridView_summary";
            this.dataGridView_summary.RowHeadersVisible = false;
            this.dataGridView_summary.Size = new System.Drawing.Size(170, 355);
            this.dataGridView_summary.TabIndex = 0;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // Form_ViewPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 380);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_ViewPortfolio";
            this.Text = "Portfolio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_ViewPortfolio_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_portfolio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_summary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_stockChart;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView_portfolio;
        private System.Windows.Forms.DataGridView dataGridView_summary;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_calculateOptimal;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_stockCode;
        private System.Windows.Forms.ToolStripButton toolStripButton_addStock;
        private System.Windows.Forms.ToolStripButton toolStripButton_rmStock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_key;
    }
}