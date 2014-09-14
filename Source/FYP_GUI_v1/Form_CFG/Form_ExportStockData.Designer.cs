namespace FYP_GUI_v1
{
    partial class Form_ExportStockData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_index = new System.Windows.Forms.RadioButton();
            this.radioButton_tbill = new System.Windows.Forms.RadioButton();
            this.radioButton_mapping = new System.Windows.Forms.RadioButton();
            this.radioButton_cluster = new System.Windows.Forms.RadioButton();
            this.radioButton_stock = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_sysPath = new System.Windows.Forms.Button();
            this.textBox_sysPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_item = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_exportPath = new System.Windows.Forms.Button();
            this.textBox_exportPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_fileName = new System.Windows.Forms.TextBox();
            this.button_export = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox_addit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_index);
            this.groupBox1.Controls.Add(this.radioButton_tbill);
            this.groupBox1.Controls.Add(this.radioButton_mapping);
            this.groupBox1.Controls.Add(this.radioButton_cluster);
            this.groupBox1.Controls.Add(this.radioButton_stock);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exporting type";
            // 
            // radioButton_index
            // 
            this.radioButton_index.AutoSize = true;
            this.radioButton_index.Location = new System.Drawing.Point(70, 20);
            this.radioButton_index.Name = "radioButton_index";
            this.radioButton_index.Size = new System.Drawing.Size(51, 17);
            this.radioButton_index.TabIndex = 4;
            this.radioButton_index.TabStop = true;
            this.radioButton_index.Text = "Index";
            this.radioButton_index.UseVisualStyleBackColor = true;
            this.radioButton_index.CheckedChanged += new System.EventHandler(this.radioButton_index_CheckedChanged);
            // 
            // radioButton_tbill
            // 
            this.radioButton_tbill.AutoSize = true;
            this.radioButton_tbill.Location = new System.Drawing.Point(127, 20);
            this.radioButton_tbill.Name = "radioButton_tbill";
            this.radioButton_tbill.Size = new System.Drawing.Size(66, 17);
            this.radioButton_tbill.TabIndex = 3;
            this.radioButton_tbill.TabStop = true;
            this.radioButton_tbill.Text = "Treasury";
            this.radioButton_tbill.UseVisualStyleBackColor = true;
            this.radioButton_tbill.CheckedChanged += new System.EventHandler(this.radioButton_tbill_CheckedChanged);
            // 
            // radioButton_mapping
            // 
            this.radioButton_mapping.AutoSize = true;
            this.radioButton_mapping.Location = new System.Drawing.Point(70, 43);
            this.radioButton_mapping.Name = "radioButton_mapping";
            this.radioButton_mapping.Size = new System.Drawing.Size(130, 17);
            this.radioButton_mapping.TabIndex = 2;
            this.radioButton_mapping.TabStop = true;
            this.radioButton_mapping.Text = "Stock-cluster mapping";
            this.radioButton_mapping.UseVisualStyleBackColor = true;
            this.radioButton_mapping.CheckedChanged += new System.EventHandler(this.radioButton_mapping_CheckedChanged);
            // 
            // radioButton_cluster
            // 
            this.radioButton_cluster.AutoSize = true;
            this.radioButton_cluster.Location = new System.Drawing.Point(7, 43);
            this.radioButton_cluster.Name = "radioButton_cluster";
            this.radioButton_cluster.Size = new System.Drawing.Size(57, 17);
            this.radioButton_cluster.TabIndex = 1;
            this.radioButton_cluster.TabStop = true;
            this.radioButton_cluster.Text = "Cluster";
            this.radioButton_cluster.UseVisualStyleBackColor = true;
            this.radioButton_cluster.CheckedChanged += new System.EventHandler(this.radioButton_cluster_CheckedChanged);
            // 
            // radioButton_stock
            // 
            this.radioButton_stock.AutoSize = true;
            this.radioButton_stock.Location = new System.Drawing.Point(7, 20);
            this.radioButton_stock.Name = "radioButton_stock";
            this.radioButton_stock.Size = new System.Drawing.Size(53, 17);
            this.radioButton_stock.TabIndex = 0;
            this.radioButton_stock.TabStop = true;
            this.radioButton_stock.Text = "Stock";
            this.radioButton_stock.UseVisualStyleBackColor = true;
            this.radioButton_stock.CheckedChanged += new System.EventHandler(this.radioButton_stock_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_sysPath);
            this.groupBox2.Controls.Add(this.textBox_sysPath);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox_item);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Import from";
            // 
            // button_sysPath
            // 
            this.button_sysPath.Location = new System.Drawing.Point(186, 14);
            this.button_sysPath.Name = "button_sysPath";
            this.button_sysPath.Size = new System.Drawing.Size(75, 23);
            this.button_sysPath.TabIndex = 2;
            this.button_sysPath.Text = "Browse";
            this.button_sysPath.UseVisualStyleBackColor = true;
            this.button_sysPath.Click += new System.EventHandler(this.button_sysPath_Click);
            // 
            // textBox_sysPath
            // 
            this.textBox_sysPath.Location = new System.Drawing.Point(45, 17);
            this.textBox_sysPath.Name = "textBox_sysPath";
            this.textBox_sysPath.Size = new System.Drawing.Size(136, 20);
            this.textBox_sysPath.TabIndex = 1;
            this.textBox_sysPath.TextChanged += new System.EventHandler(this.textBox_sysPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // comboBox_item
            // 
            this.comboBox_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_item.FormattingEnabled = true;
            this.comboBox_item.Location = new System.Drawing.Point(45, 43);
            this.comboBox_item.Name = "comboBox_item";
            this.comboBox_item.Size = new System.Drawing.Size(136, 21);
            this.comboBox_item.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Item:";
            // 
            // button_exportPath
            // 
            this.button_exportPath.Location = new System.Drawing.Point(186, 19);
            this.button_exportPath.Name = "button_exportPath";
            this.button_exportPath.Size = new System.Drawing.Size(75, 23);
            this.button_exportPath.TabIndex = 3;
            this.button_exportPath.Text = "Browse";
            this.button_exportPath.UseVisualStyleBackColor = true;
            this.button_exportPath.Click += new System.EventHandler(this.button_exportPath_Click);
            // 
            // textBox_exportPath
            // 
            this.textBox_exportPath.Location = new System.Drawing.Point(45, 21);
            this.textBox_exportPath.Name = "textBox_exportPath";
            this.textBox_exportPath.Size = new System.Drawing.Size(136, 20);
            this.textBox_exportPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Path:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox_fileName);
            this.groupBox3.Controls.Add(this.button_exportPath);
            this.groupBox3.Controls.Add(this.textBox_exportPath);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(13, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 85);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Export to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "File:";
            // 
            // textBox_fileName
            // 
            this.textBox_fileName.Location = new System.Drawing.Point(45, 48);
            this.textBox_fileName.Name = "textBox_fileName";
            this.textBox_fileName.Size = new System.Drawing.Size(136, 20);
            this.textBox_fileName.TabIndex = 6;
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(68, 325);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(75, 23);
            this.button_export.TabIndex = 3;
            this.button_export.Text = "Export";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(149, 325);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 23);
            this.button_exit.TabIndex = 4;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox_addit);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(13, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(267, 52);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Additional option";
            // 
            // comboBox_addit
            // 
            this.comboBox_addit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_addit.Enabled = false;
            this.comboBox_addit.FormattingEnabled = true;
            this.comboBox_addit.Location = new System.Drawing.Point(87, 20);
            this.comboBox_addit.Name = "comboBox_addit";
            this.comboBox_addit.Size = new System.Drawing.Size(121, 21);
            this.comboBox_addit.TabIndex = 1;
            this.comboBox_addit.SelectedIndexChanged += new System.EventHandler(this.comboBox_addit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Please select:";
            // 
            // Form_ExportStockData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 360);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_ExportStockData";
            this.Text = "Export Stock Data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_cluster;
        private System.Windows.Forms.RadioButton radioButton_stock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_sysPath;
        private System.Windows.Forms.Button button_sysPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_exportPath;
        private System.Windows.Forms.Button button_exportPath;
        private System.Windows.Forms.ComboBox comboBox_item;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_fileName;
        private System.Windows.Forms.RadioButton radioButton_mapping;
        private System.Windows.Forms.RadioButton radioButton_tbill;
        private System.Windows.Forms.RadioButton radioButton_index;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox_addit;
        private System.Windows.Forms.Label label5;
    }
}