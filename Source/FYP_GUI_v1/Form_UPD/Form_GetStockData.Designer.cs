namespace FYP_GUI_v1
{
    partial class Form_GetStockData
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
            this.checkBox_getGem = new System.Windows.Forms.CheckBox();
            this.checkBox_getAll = new System.Windows.Forms.CheckBox();
            this.textBox_stockCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar_startDate = new System.Windows.Forms.MonthCalendar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.monthCalendar_endDate = new System.Windows.Forms.MonthCalendar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_logPath = new System.Windows.Forms.TextBox();
            this.button_logSelect = new System.Windows.Forms.Button();
            this.button_outSelect = new System.Windows.Forms.Button();
            this.textBox_outPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_getGem);
            this.groupBox1.Controls.Add(this.checkBox_getAll);
            this.groupBox1.Controls.Add(this.textBox_stockCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scope";
            // 
            // checkBox_getGem
            // 
            this.checkBox_getGem.AutoSize = true;
            this.checkBox_getGem.Location = new System.Drawing.Point(288, 20);
            this.checkBox_getGem.Name = "checkBox_getGem";
            this.checkBox_getGem.Size = new System.Drawing.Size(99, 17);
            this.checkBox_getGem.TabIndex = 3;
            this.checkBox_getGem.Text = "Get GEM stock";
            this.checkBox_getGem.UseVisualStyleBackColor = true;
            this.checkBox_getGem.CheckedChanged += new System.EventHandler(this.checkBox_getGem_CheckedChanged);
            // 
            // checkBox_getAll
            // 
            this.checkBox_getAll.AutoSize = true;
            this.checkBox_getAll.Location = new System.Drawing.Point(184, 20);
            this.checkBox_getAll.Name = "checkBox_getAll";
            this.checkBox_getAll.Size = new System.Drawing.Size(98, 17);
            this.checkBox_getAll.TabIndex = 2;
            this.checkBox_getAll.Text = "Get main board";
            this.checkBox_getAll.UseVisualStyleBackColor = true;
            this.checkBox_getAll.CheckedChanged += new System.EventHandler(this.checkBox_getAll_CheckedChanged);
            // 
            // textBox_stockCode
            // 
            this.textBox_stockCode.Location = new System.Drawing.Point(78, 17);
            this.textBox_stockCode.Name = "textBox_stockCode";
            this.textBox_stockCode.Size = new System.Drawing.Size(100, 20);
            this.textBox_stockCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock code:";
            // 
            // monthCalendar_startDate
            // 
            this.monthCalendar_startDate.Location = new System.Drawing.Point(12, 25);
            this.monthCalendar_startDate.MaxSelectionCount = 1;
            this.monthCalendar_startDate.Name = "monthCalendar_startDate";
            this.monthCalendar_startDate.ShowToday = false;
            this.monthCalendar_startDate.ShowTodayCircle = false;
            this.monthCalendar_startDate.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.monthCalendar_startDate);
            this.groupBox2.Location = new System.Drawing.Point(13, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 195);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Start date";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.monthCalendar_endDate);
            this.groupBox3.Location = new System.Drawing.Point(223, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 195);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "End date";
            // 
            // monthCalendar_endDate
            // 
            this.monthCalendar_endDate.Location = new System.Drawing.Point(12, 25);
            this.monthCalendar_endDate.MaxSelectionCount = 1;
            this.monthCalendar_endDate.Name = "monthCalendar_endDate";
            this.monthCalendar_endDate.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.textBox_logPath);
            this.groupBox4.Controls.Add(this.button_logSelect);
            this.groupBox4.Controls.Add(this.button_outSelect);
            this.groupBox4.Controls.Add(this.textBox_outPath);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(13, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(415, 78);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Log path:";
            // 
            // textBox_logPath
            // 
            this.textBox_logPath.Location = new System.Drawing.Point(79, 44);
            this.textBox_logPath.Name = "textBox_logPath";
            this.textBox_logPath.Size = new System.Drawing.Size(249, 20);
            this.textBox_logPath.TabIndex = 4;
            // 
            // button_logSelect
            // 
            this.button_logSelect.Location = new System.Drawing.Point(334, 42);
            this.button_logSelect.Name = "button_logSelect";
            this.button_logSelect.Size = new System.Drawing.Size(75, 23);
            this.button_logSelect.TabIndex = 3;
            this.button_logSelect.Text = "Browse";
            this.button_logSelect.UseVisualStyleBackColor = true;
            this.button_logSelect.Click += new System.EventHandler(this.button_logSelect_Click);
            // 
            // button_outSelect
            // 
            this.button_outSelect.Location = new System.Drawing.Point(334, 15);
            this.button_outSelect.Name = "button_outSelect";
            this.button_outSelect.Size = new System.Drawing.Size(75, 23);
            this.button_outSelect.TabIndex = 2;
            this.button_outSelect.Text = "Browse";
            this.button_outSelect.UseVisualStyleBackColor = true;
            this.button_outSelect.Click += new System.EventHandler(this.button_outSelect_Click);
            // 
            // textBox_outPath
            // 
            this.textBox_outPath.Location = new System.Drawing.Point(79, 17);
            this.textBox_outPath.Name = "textBox_outPath";
            this.textBox_outPath.Size = new System.Drawing.Size(249, 20);
            this.textBox_outPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Output path:";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(142, 499);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 7;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(223, 499);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 8;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_status);
            this.groupBox5.Location = new System.Drawing.Point(13, 353);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(415, 140);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Status";
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(7, 20);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_status.Size = new System.Drawing.Size(402, 110);
            this.textBox_status.TabIndex = 0;
            // 
            // Form_GetStockData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 529);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_GetStockData";
            this.Text = "Get Stock Data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_getAll;
        private System.Windows.Forms.TextBox textBox_stockCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar_startDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MonthCalendar monthCalendar_endDate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_logPath;
        private System.Windows.Forms.Button button_logSelect;
        private System.Windows.Forms.Button button_outSelect;
        private System.Windows.Forms.TextBox textBox_outPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.CheckBox checkBox_getGem;
    }
}