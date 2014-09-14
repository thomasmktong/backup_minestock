namespace FYP_GUI_v1
{
    partial class Form_CompileStatistics
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
            this.textBox_tbillPath = new System.Windows.Forms.TextBox();
            this.button_browseTbill = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_logPath = new System.Windows.Forms.TextBox();
            this.button_browseLog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_outputPath = new System.Windows.Forms.TextBox();
            this.button_browseOutput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_indexPath = new System.Windows.Forms.TextBox();
            this.button_browseIndex = new System.Windows.Forms.Button();
            this.button_browseStock = new System.Windows.Forms.Button();
            this.textBox_stockPath = new System.Windows.Forms.TextBox();
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
            this.groupBox1.Controls.Add(this.textBox_tbillPath);
            this.groupBox1.Controls.Add(this.button_browseTbill);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_logPath);
            this.groupBox1.Controls.Add(this.button_browseLog);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_outputPath);
            this.groupBox1.Controls.Add(this.button_browseOutput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_indexPath);
            this.groupBox1.Controls.Add(this.button_browseIndex);
            this.groupBox1.Controls.Add(this.button_browseStock);
            this.groupBox1.Controls.Add(this.textBox_stockPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File path";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tbill:";
            // 
            // textBox_tbillPath
            // 
            this.textBox_tbillPath.Location = new System.Drawing.Point(51, 77);
            this.textBox_tbillPath.Name = "textBox_tbillPath";
            this.textBox_tbillPath.Size = new System.Drawing.Size(261, 20);
            this.textBox_tbillPath.TabIndex = 13;
            // 
            // button_browseTbill
            // 
            this.button_browseTbill.Location = new System.Drawing.Point(318, 75);
            this.button_browseTbill.Name = "button_browseTbill";
            this.button_browseTbill.Size = new System.Drawing.Size(75, 23);
            this.button_browseTbill.TabIndex = 12;
            this.button_browseTbill.Text = "Browse";
            this.button_browseTbill.UseVisualStyleBackColor = true;
            this.button_browseTbill.Click += new System.EventHandler(this.button_browseTbill_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Log:";
            // 
            // textBox_logPath
            // 
            this.textBox_logPath.Location = new System.Drawing.Point(51, 136);
            this.textBox_logPath.Name = "textBox_logPath";
            this.textBox_logPath.Size = new System.Drawing.Size(261, 20);
            this.textBox_logPath.TabIndex = 10;
            // 
            // button_browseLog
            // 
            this.button_browseLog.Location = new System.Drawing.Point(318, 133);
            this.button_browseLog.Name = "button_browseLog";
            this.button_browseLog.Size = new System.Drawing.Size(75, 23);
            this.button_browseLog.TabIndex = 9;
            this.button_browseLog.Text = "Browse";
            this.button_browseLog.UseVisualStyleBackColor = true;
            this.button_browseLog.Click += new System.EventHandler(this.button_browseLog_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output:";
            // 
            // textBox_outputPath
            // 
            this.textBox_outputPath.Location = new System.Drawing.Point(51, 106);
            this.textBox_outputPath.Name = "textBox_outputPath";
            this.textBox_outputPath.Size = new System.Drawing.Size(261, 20);
            this.textBox_outputPath.TabIndex = 7;
            // 
            // button_browseOutput
            // 
            this.button_browseOutput.Location = new System.Drawing.Point(318, 104);
            this.button_browseOutput.Name = "button_browseOutput";
            this.button_browseOutput.Size = new System.Drawing.Size(75, 23);
            this.button_browseOutput.TabIndex = 6;
            this.button_browseOutput.Text = "Browse";
            this.button_browseOutput.UseVisualStyleBackColor = true;
            this.button_browseOutput.Click += new System.EventHandler(this.button_browseOutput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Index:";
            // 
            // textBox_indexPath
            // 
            this.textBox_indexPath.Location = new System.Drawing.Point(51, 47);
            this.textBox_indexPath.Name = "textBox_indexPath";
            this.textBox_indexPath.Size = new System.Drawing.Size(261, 20);
            this.textBox_indexPath.TabIndex = 4;
            // 
            // button_browseIndex
            // 
            this.button_browseIndex.Location = new System.Drawing.Point(318, 45);
            this.button_browseIndex.Name = "button_browseIndex";
            this.button_browseIndex.Size = new System.Drawing.Size(75, 23);
            this.button_browseIndex.TabIndex = 3;
            this.button_browseIndex.Text = "Browse";
            this.button_browseIndex.UseVisualStyleBackColor = true;
            this.button_browseIndex.Click += new System.EventHandler(this.button_browseIndex_Click);
            // 
            // button_browseStock
            // 
            this.button_browseStock.Location = new System.Drawing.Point(318, 15);
            this.button_browseStock.Name = "button_browseStock";
            this.button_browseStock.Size = new System.Drawing.Size(75, 23);
            this.button_browseStock.TabIndex = 2;
            this.button_browseStock.Text = "Browse";
            this.button_browseStock.UseVisualStyleBackColor = true;
            this.button_browseStock.Click += new System.EventHandler(this.button_browseStock_Click);
            // 
            // textBox_stockPath
            // 
            this.textBox_stockPath.Location = new System.Drawing.Point(51, 17);
            this.textBox_stockPath.Name = "textBox_stockPath";
            this.textBox_stockPath.Size = new System.Drawing.Size(261, 20);
            this.textBox_stockPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_status);
            this.groupBox2.Location = new System.Drawing.Point(13, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 182);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(7, 20);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_status.Size = new System.Drawing.Size(386, 156);
            this.textBox_status.TabIndex = 0;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(135, 375);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(216, 375);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form_CompileStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 405);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_CompileStatistics";
            this.Text = "Compile Statistics";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_logPath;
        private System.Windows.Forms.Button button_browseLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_outputPath;
        private System.Windows.Forms.Button button_browseOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_indexPath;
        private System.Windows.Forms.Button button_browseIndex;
        private System.Windows.Forms.Button button_browseStock;
        private System.Windows.Forms.TextBox textBox_stockPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.TextBox textBox_tbillPath;
        private System.Windows.Forms.Button button_browseTbill;
        private System.Windows.Forms.Label label5;
    }
}