namespace FYP_GUI_v1
{
    partial class Form_ViewResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ViewResult));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_stockChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_addPortfolio = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_filterInsuff = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_filterUnder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_linkPortfolio = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_key = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_stockChart,
            this.toolStripButton_addPortfolio,
            this.toolStripSeparator1,
            this.toolStripButton_filterInsuff,
            this.toolStripButton_filterUnder,
            this.toolStripButton_linkPortfolio,
            this.toolStripSeparator2,
            this.toolStripButton_key});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(946, 25);
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
            // toolStripButton_addPortfolio
            // 
            this.toolStripButton_addPortfolio.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_addPortfolio.Image")));
            this.toolStripButton_addPortfolio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addPortfolio.Name = "toolStripButton_addPortfolio";
            this.toolStripButton_addPortfolio.Size = new System.Drawing.Size(102, 22);
            this.toolStripButton_addPortfolio.Text = "Add to portfolio";
            this.toolStripButton_addPortfolio.Click += new System.EventHandler(this.toolStripButton_addPortfolio_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_filterInsuff
            // 
            this.toolStripButton_filterInsuff.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_filterInsuff.Image")));
            this.toolStripButton_filterInsuff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_filterInsuff.Name = "toolStripButton_filterInsuff";
            this.toolStripButton_filterInsuff.Size = new System.Drawing.Size(179, 22);
            this.toolStripButton_filterInsuff.Text = "Filter stocks w. insufficient data";
            this.toolStripButton_filterInsuff.Click += new System.EventHandler(this.toolStripButton_filterInsuff_Click);
            // 
            // toolStripButton_filterUnder
            // 
            this.toolStripButton_filterUnder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_filterUnder.Image")));
            this.toolStripButton_filterUnder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_filterUnder.Name = "toolStripButton_filterUnder";
            this.toolStripButton_filterUnder.Size = new System.Drawing.Size(165, 22);
            this.toolStripButton_filterUnder.Text = "Filter underperformed stocks";
            this.toolStripButton_filterUnder.Click += new System.EventHandler(this.toolStripButton_filterUnder_Click);
            // 
            // toolStripButton_linkPortfolio
            // 
            this.toolStripButton_linkPortfolio.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_linkPortfolio.Image")));
            this.toolStripButton_linkPortfolio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_linkPortfolio.Name = "toolStripButton_linkPortfolio";
            this.toolStripButton_linkPortfolio.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton_linkPortfolio.Text = "Link portfolio";
            this.toolStripButton_linkPortfolio.Click += new System.EventHandler(this.toolStripButton_linkPortfolio_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(946, 410);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(131, 410);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(811, 410);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            // 
            // Form_ViewResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 435);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_ViewResult";
            this.Text = "View Results";
            this.Enter += new System.EventHandler(this.Form_ViewResult_Enter);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton_stockChart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_linkPortfolio;
        private System.Windows.Forms.ToolStripButton toolStripButton_filterUnder;
        private System.Windows.Forms.ToolStripButton toolStripButton_addPortfolio;
        private System.Windows.Forms.ToolStripButton toolStripButton_filterInsuff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_key;

    }
}