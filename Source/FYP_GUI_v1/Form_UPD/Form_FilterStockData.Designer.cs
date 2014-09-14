namespace FYP_GUI_v1
{
    partial class Form_FilterStockData
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
            this.textBox_stockCode = new System.Windows.Forms.TextBox();
            this.radioButton_stock = new System.Windows.Forms.RadioButton();
            this.radioButton_index = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.button_browseLog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_browsePath = new System.Windows.Forms.Button();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_stockCode);
            this.groupBox1.Controls.Add(this.radioButton_stock);
            this.groupBox1.Controls.Add(this.radioButton_index);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Referencing data";
            // 
            // textBox_stockCode
            // 
            this.textBox_stockCode.Location = new System.Drawing.Point(100, 42);
            this.textBox_stockCode.Name = "textBox_stockCode";
            this.textBox_stockCode.Size = new System.Drawing.Size(58, 20);
            this.textBox_stockCode.TabIndex = 2;
            // 
            // radioButton_stock
            // 
            this.radioButton_stock.AutoSize = true;
            this.radioButton_stock.Location = new System.Drawing.Point(11, 43);
            this.radioButton_stock.Name = "radioButton_stock";
            this.radioButton_stock.Size = new System.Drawing.Size(83, 17);
            this.radioButton_stock.TabIndex = 1;
            this.radioButton_stock.TabStop = true;
            this.radioButton_stock.Text = "Stock code:";
            this.radioButton_stock.UseVisualStyleBackColor = true;
            this.radioButton_stock.CheckedChanged += new System.EventHandler(this.radioButton_stock_CheckedChanged);
            // 
            // radioButton_index
            // 
            this.radioButton_index.AutoSize = true;
            this.radioButton_index.Location = new System.Drawing.Point(11, 19);
            this.radioButton_index.Name = "radioButton_index";
            this.radioButton_index.Size = new System.Drawing.Size(51, 17);
            this.radioButton_index.TabIndex = 0;
            this.radioButton_index.TabStop = true;
            this.radioButton_index.Text = "Index";
            this.radioButton_index.UseVisualStyleBackColor = true;
            this.radioButton_index.CheckedChanged += new System.EventHandler(this.radioButton_index_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_log);
            this.groupBox2.Controls.Add(this.button_browseLog);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button_browsePath);
            this.groupBox2.Controls.Add(this.textBox_path);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Path settings";
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(53, 46);
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.Size = new System.Drawing.Size(282, 20);
            this.textBox_log.TabIndex = 5;
            // 
            // button_browseLog
            // 
            this.button_browseLog.Location = new System.Drawing.Point(341, 44);
            this.button_browseLog.Name = "button_browseLog";
            this.button_browseLog.Size = new System.Drawing.Size(75, 23);
            this.button_browseLog.TabIndex = 4;
            this.button_browseLog.Text = "Browse";
            this.button_browseLog.UseVisualStyleBackColor = true;
            this.button_browseLog.Click += new System.EventHandler(this.button_browseLog_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Log:";
            // 
            // button_browsePath
            // 
            this.button_browsePath.Location = new System.Drawing.Point(341, 18);
            this.button_browsePath.Name = "button_browsePath";
            this.button_browsePath.Size = new System.Drawing.Size(75, 23);
            this.button_browsePath.TabIndex = 2;
            this.button_browsePath.Text = "Browse";
            this.button_browsePath.UseVisualStyleBackColor = true;
            this.button_browsePath.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(52, 20);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(283, 20);
            this.textBox_path.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock:";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(147, 464);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(228, 464);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_status);
            this.groupBox3.Location = new System.Drawing.Point(13, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 281);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(6, 19);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_status.Size = new System.Drawing.Size(410, 256);
            this.textBox_status.TabIndex = 0;
            // 
            // Form_FilterStockData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 497);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_FilterStockData";
            this.Text = "Filter Holiday Ticks";
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
        private System.Windows.Forms.TextBox textBox_stockCode;
        private System.Windows.Forms.RadioButton radioButton_stock;
        private System.Windows.Forms.RadioButton radioButton_index;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_browsePath;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Button button_browseLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_log;
    }
}