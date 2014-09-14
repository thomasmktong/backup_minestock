namespace FYP_GUI_v1
{
    partial class Form_ViewChart
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
            this.radioButton_stock = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_addLine = new System.Windows.Forms.Button();
            this.comboBox_color = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_sysPath = new System.Windows.Forms.Button();
            this.textBox_sysPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_item = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_export = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox_lineList = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_index);
            this.groupBox1.Controls.Add(this.radioButton_stock);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add type";
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
            this.groupBox2.Controls.Add(this.button_addLine);
            this.groupBox2.Controls.Add(this.comboBox_color);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button_sysPath);
            this.groupBox2.Controls.Add(this.textBox_sysPath);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox_item);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add line";
            // 
            // button_addLine
            // 
            this.button_addLine.Location = new System.Drawing.Point(260, 69);
            this.button_addLine.Name = "button_addLine";
            this.button_addLine.Size = new System.Drawing.Size(75, 23);
            this.button_addLine.TabIndex = 5;
            this.button_addLine.Text = "Add";
            this.button_addLine.UseVisualStyleBackColor = true;
            this.button_addLine.Click += new System.EventHandler(this.button_addLine_Click);
            // 
            // comboBox_color
            // 
            this.comboBox_color.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_color.FormattingEnabled = true;
            this.comboBox_color.Location = new System.Drawing.Point(45, 71);
            this.comboBox_color.Name = "comboBox_color";
            this.comboBox_color.Size = new System.Drawing.Size(209, 21);
            this.comboBox_color.TabIndex = 4;
            this.comboBox_color.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox_color_DrawItem);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Color:";
            // 
            // button_sysPath
            // 
            this.button_sysPath.Location = new System.Drawing.Point(260, 15);
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
            this.textBox_sysPath.Size = new System.Drawing.Size(209, 20);
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
            this.comboBox_item.Size = new System.Drawing.Size(209, 21);
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
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(106, 348);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(75, 23);
            this.button_export.TabIndex = 3;
            this.button_export.Text = "Chart";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(187, 348);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 23);
            this.button_exit.TabIndex = 4;
            this.button_exit.Text = "Cancel";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_delete);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox_title);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.listBox_lineList);
            this.groupBox3.Location = new System.Drawing.Point(13, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 163);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chart settings";
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(260, 46);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 1;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "List:";
            // 
            // textBox_title
            // 
            this.textBox_title.Location = new System.Drawing.Point(45, 20);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(209, 20);
            this.textBox_title.TabIndex = 1;
            this.textBox_title.Text = "Custom Chart";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Title:";
            // 
            // listBox_lineList
            // 
            this.listBox_lineList.FormattingEnabled = true;
            this.listBox_lineList.Location = new System.Drawing.Point(45, 46);
            this.listBox_lineList.Name = "listBox_lineList";
            this.listBox_lineList.ScrollAlwaysVisible = true;
            this.listBox_lineList.Size = new System.Drawing.Size(209, 108);
            this.listBox_lineList.TabIndex = 0;
            // 
            // Form_ViewChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 380);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_ViewChart";
            this.Text = "View Chart";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_stock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_sysPath;
        private System.Windows.Forms.Button button_sysPath;
        private System.Windows.Forms.ComboBox comboBox_item;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.RadioButton radioButton_index;
        private System.Windows.Forms.Button button_addLine;
        private System.Windows.Forms.ComboBox comboBox_color;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_lineList;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.Label label5;
    }
}