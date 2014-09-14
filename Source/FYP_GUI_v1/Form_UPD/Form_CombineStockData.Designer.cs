namespace FYP_GUI_v1
{
    partial class Form_CombineStockData
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_noDays = new System.Windows.Forms.TextBox();
            this.radioButton_custom = new System.Windows.Forms.RadioButton();
            this.radioButton_yrly = new System.Windows.Forms.RadioButton();
            this.radioButton_mthly = new System.Windows.Forms.RadioButton();
            this.radioButton_weekly = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.button_browseLog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_stockOutput = new System.Windows.Forms.TextBox();
            this.button_browseOutput = new System.Windows.Forms.Button();
            this.button_browseInput = new System.Windows.Forms.Button();
            this.textBox_stockInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_noDays);
            this.groupBox1.Controls.Add(this.radioButton_custom);
            this.groupBox1.Controls.Add(this.radioButton_yrly);
            this.groupBox1.Controls.Add(this.radioButton_mthly);
            this.groupBox1.Controls.Add(this.radioButton_weekly);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From daily to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "days";
            // 
            // textBox_noDays
            // 
            this.textBox_noDays.Location = new System.Drawing.Point(292, 19);
            this.textBox_noDays.Name = "textBox_noDays";
            this.textBox_noDays.Size = new System.Drawing.Size(49, 20);
            this.textBox_noDays.TabIndex = 4;
            // 
            // radioButton_custom
            // 
            this.radioButton_custom.AutoSize = true;
            this.radioButton_custom.Location = new System.Drawing.Point(204, 20);
            this.radioButton_custom.Name = "radioButton_custom";
            this.radioButton_custom.Size = new System.Drawing.Size(82, 17);
            this.radioButton_custom.TabIndex = 3;
            this.radioButton_custom.Text = "Customized:";
            this.radioButton_custom.UseVisualStyleBackColor = true;
            this.radioButton_custom.CheckedChanged += new System.EventHandler(this.radioButton_custom_CheckedChanged);
            // 
            // radioButton_yrly
            // 
            this.radioButton_yrly.AutoSize = true;
            this.radioButton_yrly.Location = new System.Drawing.Point(144, 20);
            this.radioButton_yrly.Name = "radioButton_yrly";
            this.radioButton_yrly.Size = new System.Drawing.Size(54, 17);
            this.radioButton_yrly.TabIndex = 2;
            this.radioButton_yrly.Text = "Yearly";
            this.radioButton_yrly.UseVisualStyleBackColor = true;
            this.radioButton_yrly.CheckedChanged += new System.EventHandler(this.radioButton_yrly_CheckedChanged);
            // 
            // radioButton_mthly
            // 
            this.radioButton_mthly.AutoSize = true;
            this.radioButton_mthly.Location = new System.Drawing.Point(75, 20);
            this.radioButton_mthly.Name = "radioButton_mthly";
            this.radioButton_mthly.Size = new System.Drawing.Size(62, 17);
            this.radioButton_mthly.TabIndex = 1;
            this.radioButton_mthly.Text = "Monthly";
            this.radioButton_mthly.UseVisualStyleBackColor = true;
            this.radioButton_mthly.CheckedChanged += new System.EventHandler(this.radioButton_mthly_CheckedChanged);
            // 
            // radioButton_weekly
            // 
            this.radioButton_weekly.AutoSize = true;
            this.radioButton_weekly.Checked = true;
            this.radioButton_weekly.Location = new System.Drawing.Point(7, 20);
            this.radioButton_weekly.Name = "radioButton_weekly";
            this.radioButton_weekly.Size = new System.Drawing.Size(61, 17);
            this.radioButton_weekly.TabIndex = 0;
            this.radioButton_weekly.TabStop = true;
            this.radioButton_weekly.Text = "Weekly";
            this.radioButton_weekly.UseVisualStyleBackColor = true;
            this.radioButton_weekly.CheckedChanged += new System.EventHandler(this.radioButton_weekly_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_log);
            this.groupBox2.Controls.Add(this.button_browseLog);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_stockOutput);
            this.groupBox2.Controls.Add(this.button_browseOutput);
            this.groupBox2.Controls.Add(this.button_browseInput);
            this.groupBox2.Controls.Add(this.textBox_stockInput);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 110);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Log:";
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(60, 77);
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.Size = new System.Drawing.Size(235, 20);
            this.textBox_log.TabIndex = 7;
            // 
            // button_browseLog
            // 
            this.button_browseLog.Location = new System.Drawing.Point(301, 75);
            this.button_browseLog.Name = "button_browseLog";
            this.button_browseLog.Size = new System.Drawing.Size(75, 23);
            this.button_browseLog.TabIndex = 6;
            this.button_browseLog.Text = "Browse";
            this.button_browseLog.UseVisualStyleBackColor = true;
            this.button_browseLog.Click += new System.EventHandler(this.button_browseLog_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output:";
            // 
            // textBox_stockOutput
            // 
            this.textBox_stockOutput.Location = new System.Drawing.Point(60, 47);
            this.textBox_stockOutput.Name = "textBox_stockOutput";
            this.textBox_stockOutput.Size = new System.Drawing.Size(235, 20);
            this.textBox_stockOutput.TabIndex = 4;
            // 
            // button_browseOutput
            // 
            this.button_browseOutput.Location = new System.Drawing.Point(301, 45);
            this.button_browseOutput.Name = "button_browseOutput";
            this.button_browseOutput.Size = new System.Drawing.Size(75, 23);
            this.button_browseOutput.TabIndex = 3;
            this.button_browseOutput.Text = "Browse";
            this.button_browseOutput.UseVisualStyleBackColor = true;
            this.button_browseOutput.Click += new System.EventHandler(this.button_browseOutput_Click);
            // 
            // button_browseInput
            // 
            this.button_browseInput.Location = new System.Drawing.Point(301, 15);
            this.button_browseInput.Name = "button_browseInput";
            this.button_browseInput.Size = new System.Drawing.Size(75, 23);
            this.button_browseInput.TabIndex = 2;
            this.button_browseInput.Text = "Browse";
            this.button_browseInput.UseVisualStyleBackColor = true;
            this.button_browseInput.Click += new System.EventHandler(this.button_browseInput_Click);
            // 
            // textBox_stockInput
            // 
            this.textBox_stockInput.Location = new System.Drawing.Point(60, 17);
            this.textBox_stockInput.Name = "textBox_stockInput";
            this.textBox_stockInput.Size = new System.Drawing.Size(235, 20);
            this.textBox_stockInput.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Input:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_status);
            this.groupBox3.Location = new System.Drawing.Point(13, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(382, 195);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(7, 20);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.Size = new System.Drawing.Size(369, 169);
            this.textBox_status.TabIndex = 0;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(126, 388);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(207, 388);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form_CombineStockData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 423);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_CombineStockData";
            this.Text = "Change the Data Period";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_noDays;
        private System.Windows.Forms.RadioButton radioButton_custom;
        private System.Windows.Forms.RadioButton radioButton_yrly;
        private System.Windows.Forms.RadioButton radioButton_mthly;
        private System.Windows.Forms.RadioButton radioButton_weekly;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_stockOutput;
        private System.Windows.Forms.Button button_browseOutput;
        private System.Windows.Forms.Button button_browseInput;
        private System.Windows.Forms.TextBox textBox_stockInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Button button_browseLog;
    }
}