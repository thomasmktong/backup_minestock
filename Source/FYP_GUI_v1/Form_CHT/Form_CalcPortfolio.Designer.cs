namespace FYP_GUI_v1
{
    partial class Form_CalcPortfolio
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
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_logPath = new System.Windows.Forms.TextBox();
            this.button_logPath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_statPath = new System.Windows.Forms.Button();
            this.textBox_statPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_tbillPath = new System.Windows.Forms.TextBox();
            this.buttontbillPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_stockPath = new System.Windows.Forms.TextBox();
            this.button_stockPath = new System.Windows.Forms.Button();
            this.button_envPath = new System.Windows.Forms.Button();
            this.textBox_envPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_logPath);
            this.groupBox1.Controls.Add(this.button_logPath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button_statPath);
            this.groupBox1.Controls.Add(this.textBox_statPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_tbillPath);
            this.groupBox1.Controls.Add(this.buttontbillPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_stockPath);
            this.groupBox1.Controls.Add(this.button_stockPath);
            this.groupBox1.Controls.Add(this.button_envPath);
            this.groupBox1.Controls.Add(this.textBox_envPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File path";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Log:";
            // 
            // textBox_logPath
            // 
            this.textBox_logPath.Location = new System.Drawing.Point(81, 138);
            this.textBox_logPath.Name = "textBox_logPath";
            this.textBox_logPath.Size = new System.Drawing.Size(246, 20);
            this.textBox_logPath.TabIndex = 13;
            // 
            // button_logPath
            // 
            this.button_logPath.Location = new System.Drawing.Point(333, 136);
            this.button_logPath.Name = "button_logPath";
            this.button_logPath.Size = new System.Drawing.Size(75, 23);
            this.button_logPath.TabIndex = 12;
            this.button_logPath.Text = "Browse";
            this.button_logPath.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Statistics:";
            // 
            // button_statPath
            // 
            this.button_statPath.Location = new System.Drawing.Point(333, 106);
            this.button_statPath.Name = "button_statPath";
            this.button_statPath.Size = new System.Drawing.Size(75, 23);
            this.button_statPath.TabIndex = 10;
            this.button_statPath.Text = "Browse";
            this.button_statPath.UseVisualStyleBackColor = true;
            this.button_statPath.Click += new System.EventHandler(this.button_statPath_Click);
            // 
            // textBox_statPath
            // 
            this.textBox_statPath.Location = new System.Drawing.Point(81, 108);
            this.textBox_statPath.Name = "textBox_statPath";
            this.textBox_statPath.Size = new System.Drawing.Size(246, 20);
            this.textBox_statPath.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tbill:";
            // 
            // textBox_tbillPath
            // 
            this.textBox_tbillPath.Location = new System.Drawing.Point(81, 79);
            this.textBox_tbillPath.Name = "textBox_tbillPath";
            this.textBox_tbillPath.Size = new System.Drawing.Size(246, 20);
            this.textBox_tbillPath.TabIndex = 7;
            // 
            // buttontbillPath
            // 
            this.buttontbillPath.Location = new System.Drawing.Point(333, 77);
            this.buttontbillPath.Name = "buttontbillPath";
            this.buttontbillPath.Size = new System.Drawing.Size(75, 23);
            this.buttontbillPath.TabIndex = 6;
            this.buttontbillPath.Text = "Browse";
            this.buttontbillPath.UseVisualStyleBackColor = true;
            this.buttontbillPath.Click += new System.EventHandler(this.buttontbillPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stock:";
            // 
            // textBox_stockPath
            // 
            this.textBox_stockPath.Location = new System.Drawing.Point(81, 49);
            this.textBox_stockPath.Name = "textBox_stockPath";
            this.textBox_stockPath.Size = new System.Drawing.Size(246, 20);
            this.textBox_stockPath.TabIndex = 4;
            // 
            // button_stockPath
            // 
            this.button_stockPath.Location = new System.Drawing.Point(333, 47);
            this.button_stockPath.Name = "button_stockPath";
            this.button_stockPath.Size = new System.Drawing.Size(75, 23);
            this.button_stockPath.TabIndex = 3;
            this.button_stockPath.Text = "Browse";
            this.button_stockPath.UseVisualStyleBackColor = true;
            this.button_stockPath.Click += new System.EventHandler(this.button_stockPath_Click);
            // 
            // button_envPath
            // 
            this.button_envPath.Location = new System.Drawing.Point(333, 17);
            this.button_envPath.Name = "button_envPath";
            this.button_envPath.Size = new System.Drawing.Size(75, 23);
            this.button_envPath.TabIndex = 2;
            this.button_envPath.Text = "Browse";
            this.button_envPath.UseVisualStyleBackColor = true;
            this.button_envPath.Click += new System.EventHandler(this.button_envPath_Click);
            // 
            // textBox_envPath
            // 
            this.textBox_envPath.Location = new System.Drawing.Point(81, 19);
            this.textBox_envPath.Name = "textBox_envPath";
            this.textBox_envPath.Size = new System.Drawing.Size(246, 20);
            this.textBox_envPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Environment:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_status);
            this.groupBox2.Location = new System.Drawing.Point(13, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 155);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(6, 19);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_status.Size = new System.Drawing.Size(402, 130);
            this.textBox_status.TabIndex = 0;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(140, 349);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(222, 349);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form_CalcPortfolio
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 380);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_CalcPortfolio";
            this.Text = "Calculate Optimal Weighting";
            this.Leave += new System.EventHandler(this.Form_CalcPortfolio_Leave);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_envPath;
        private System.Windows.Forms.TextBox textBox_envPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_stockPath;
        private System.Windows.Forms.Button button_stockPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_statPath;
        private System.Windows.Forms.TextBox textBox_statPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_tbillPath;
        private System.Windows.Forms.Button buttontbillPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_logPath;
        private System.Windows.Forms.Button button_logPath;
    }
}