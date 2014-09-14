namespace FYP_GUI_v1
{
    partial class Form_WatchList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_WatchList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_add = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_remove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_chart = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox_stockCode = new System.Windows.Forms.ToolStripTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.modelWatchListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelWatchListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_add,
            this.toolStripTextBox1,
            this.toolStripButton_remove,
            this.toolStripSeparator1,
            this.toolStripButton_chart});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(292, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_add
            // 
            this.toolStripButton_add.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_add.Image")));
            this.toolStripButton_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_add.Name = "toolStripButton_add";
            this.toolStripButton_add.Size = new System.Drawing.Size(46, 22);
            this.toolStripButton_add.Text = "Add";
            this.toolStripButton_add.Click += new System.EventHandler(this.toolStripButton_add_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(0, 25);
            // 
            // toolStripButton_remove
            // 
            this.toolStripButton_remove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_remove.Image")));
            this.toolStripButton_remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_remove.Name = "toolStripButton_remove";
            this.toolStripButton_remove.Size = new System.Drawing.Size(66, 22);
            this.toolStripButton_remove.Text = "Remove";
            this.toolStripButton_remove.Click += new System.EventHandler(this.toolStripButton_remove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_chart
            // 
            this.toolStripButton_chart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_chart.Image")));
            this.toolStripButton_chart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_chart.Name = "toolStripButton_chart";
            this.toolStripButton_chart.Size = new System.Drawing.Size(54, 22);
            this.toolStripButton_chart.Text = "Chart";
            this.toolStripButton_chart.Click += new System.EventHandler(this.toolStripButton_chart_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_stockCode});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(292, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripTextBox_stockCode
            // 
            this.toolStripTextBox_stockCode.Name = "toolStripTextBox_stockCode";
            this.toolStripTextBox_stockCode.Size = new System.Drawing.Size(250, 25);
            this.toolStripTextBox_stockCode.Text = "<Enter stock code here>";
            this.toolStripTextBox_stockCode.Click += new System.EventHandler(this.toolStripTextBox_stockCode_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(292, 524);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // modelWatchListBindingSource
            // 
            this.modelWatchListBindingSource.DataSource = typeof(FYP_GUI_v1.Model_WatchList);
            // 
            // Form_WatchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 574);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_WatchList";
            this.Text = "Watch List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_WatchList_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelWatchListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_add;
        private System.Windows.Forms.ToolStripButton toolStripButton_remove;
        private System.Windows.Forms.ToolStripButton toolStripButton_chart;
        private System.Windows.Forms.BindingSource modelWatchListBindingSource;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_stockCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}