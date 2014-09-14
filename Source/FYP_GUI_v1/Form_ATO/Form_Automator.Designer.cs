namespace FYP_GUI_v1
{
    partial class Form_Automator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Automator));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_save = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_load = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_start = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_remove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_setting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_up = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_down = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox_listOfActions = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_subset = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_univset = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_save,
            this.toolStripButton_load,
            this.toolStripButton_start,
            this.toolStripSeparator1,
            this.toolStripButton_add,
            this.toolStripButton_remove,
            this.toolStripButton_setting,
            this.toolStripSeparator2,
            this.toolStripButton_up,
            this.toolStripButton_down});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(636, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_save
            // 
            this.toolStripButton_save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_save.Image")));
            this.toolStripButton_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_save.Name = "toolStripButton_save";
            this.toolStripButton_save.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton_save.Text = "Save";
            this.toolStripButton_save.Click += new System.EventHandler(this.toolStripButton_save_Click);
            // 
            // toolStripButton_load
            // 
            this.toolStripButton_load.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_load.Image")));
            this.toolStripButton_load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_load.Name = "toolStripButton_load";
            this.toolStripButton_load.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton_load.Text = "Load";
            this.toolStripButton_load.Click += new System.EventHandler(this.toolStripButton_load_Click);
            // 
            // toolStripButton_start
            // 
            this.toolStripButton_start.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_start.Image")));
            this.toolStripButton_start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_start.Name = "toolStripButton_start";
            this.toolStripButton_start.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton_start.Text = "Start";
            this.toolStripButton_start.Click += new System.EventHandler(this.toolStripButton_start_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // toolStripButton_remove
            // 
            this.toolStripButton_remove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_remove.Image")));
            this.toolStripButton_remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_remove.Name = "toolStripButton_remove";
            this.toolStripButton_remove.Size = new System.Drawing.Size(66, 22);
            this.toolStripButton_remove.Text = "Remove";
            this.toolStripButton_remove.Click += new System.EventHandler(this.toolStripButton_remove_Click);
            // 
            // toolStripButton_setting
            // 
            this.toolStripButton_setting.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_setting.Image")));
            this.toolStripButton_setting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_setting.Name = "toolStripButton_setting";
            this.toolStripButton_setting.Size = new System.Drawing.Size(148, 22);
            this.toolStripButton_setting.Text = "Change selected settings";
            this.toolStripButton_setting.Click += new System.EventHandler(this.toolStripButton_setting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_up
            // 
            this.toolStripButton_up.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_up.Image")));
            this.toolStripButton_up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_up.Name = "toolStripButton_up";
            this.toolStripButton_up.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton_up.Text = "Move up";
            this.toolStripButton_up.Click += new System.EventHandler(this.toolStripButton_up_Click);
            // 
            // toolStripButton_down
            // 
            this.toolStripButton_down.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_down.Image")));
            this.toolStripButton_down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_down.Name = "toolStripButton_down";
            this.toolStripButton_down.Size = new System.Drawing.Size(82, 22);
            this.toolStripButton_down.Text = "Move down";
            this.toolStripButton_down.Click += new System.EventHandler(this.toolStripButton_down_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_listOfActions,
            this.toolStripSeparator3,
            this.toolStripButton_subset,
            this.toolStripButton_univset});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(636, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripComboBox_listOfActions
            // 
            this.toolStripComboBox_listOfActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_listOfActions.Name = "toolStripComboBox_listOfActions";
            this.toolStripComboBox_listOfActions.Size = new System.Drawing.Size(300, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_subset
            // 
            this.toolStripButton_subset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_subset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_subset.Image")));
            this.toolStripButton_subset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_subset.Name = "toolStripButton_subset";
            this.toolStripButton_subset.Size = new System.Drawing.Size(158, 22);
            this.toolStripButton_subset.Text = "Use subset for following action";
            this.toolStripButton_subset.Click += new System.EventHandler(this.toolStripButton_subset_Click);
            // 
            // toolStripButton_univset
            // 
            this.toolStripButton_univset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_univset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_univset.Image")));
            this.toolStripButton_univset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_univset.Name = "toolStripButton_univset";
            this.toolStripButton_univset.Size = new System.Drawing.Size(93, 22);
            this.toolStripButton_univset.Text = "Use universal set";
            this.toolStripButton_univset.Click += new System.EventHandler(this.toolStripButton_univset_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(636, 396);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // Form_Automator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 446);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_Automator";
            this.Text = "Automator - Untitled";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Automator_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_add;
        private System.Windows.Forms.ToolStripButton toolStripButton_remove;
        private System.Windows.Forms.ToolStripButton toolStripButton_setting;
        private System.Windows.Forms.ToolStripButton toolStripButton_save;
        private System.Windows.Forms.ToolStripButton toolStripButton_load;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_listOfActions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_up;
        private System.Windows.Forms.ToolStripButton toolStripButton_down;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton_start;
        private System.Windows.Forms.ToolStripButton toolStripButton_subset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_univset;

    }
}