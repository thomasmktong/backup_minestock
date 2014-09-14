namespace FYP_GUI_v1
{
    partial class Form_Autosubset
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
            this.button_browseStock = new System.Windows.Forms.Button();
            this.textBox_stockPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_minStocksInCluster = new System.Windows.Forms.TextBox();
            this.button_browseCluster = new System.Windows.Forms.Button();
            this.textBox_clusterPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton_univSet = new System.Windows.Forms.RadioButton();
            this.radioButton_subset = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_browseLog = new System.Windows.Forms.Button();
            this.textBox_logPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_browseStock);
            this.groupBox1.Controls.Add(this.textBox_stockPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processing stocks";
            // 
            // button_browseStock
            // 
            this.button_browseStock.Location = new System.Drawing.Point(323, 17);
            this.button_browseStock.Name = "button_browseStock";
            this.button_browseStock.Size = new System.Drawing.Size(75, 23);
            this.button_browseStock.TabIndex = 2;
            this.button_browseStock.Text = "Browse";
            this.button_browseStock.UseVisualStyleBackColor = true;
            this.button_browseStock.Click += new System.EventHandler(this.button_browseStock_Click);
            // 
            // textBox_stockPath
            // 
            this.textBox_stockPath.Location = new System.Drawing.Point(71, 19);
            this.textBox_stockPath.Name = "textBox_stockPath";
            this.textBox_stockPath.Size = new System.Drawing.Size(246, 20);
            this.textBox_stockPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data path:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_minStocksInCluster);
            this.groupBox2.Controls.Add(this.button_browseCluster);
            this.groupBox2.Controls.Add(this.textBox_clusterPath);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 99);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criteria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mimimum:";
            // 
            // textBox_minStocksInCluster
            // 
            this.textBox_minStocksInCluster.Location = new System.Drawing.Point(71, 69);
            this.textBox_minStocksInCluster.Name = "textBox_minStocksInCluster";
            this.textBox_minStocksInCluster.Size = new System.Drawing.Size(62, 20);
            this.textBox_minStocksInCluster.TabIndex = 5;
            // 
            // button_browseCluster
            // 
            this.button_browseCluster.Location = new System.Drawing.Point(323, 40);
            this.button_browseCluster.Name = "button_browseCluster";
            this.button_browseCluster.Size = new System.Drawing.Size(75, 23);
            this.button_browseCluster.TabIndex = 4;
            this.button_browseCluster.Text = "Browse";
            this.button_browseCluster.UseVisualStyleBackColor = true;
            this.button_browseCluster.Click += new System.EventHandler(this.button_browseCluster_Click);
            // 
            // textBox_clusterPath
            // 
            this.textBox_clusterPath.Location = new System.Drawing.Point(71, 42);
            this.textBox_clusterPath.Name = "textBox_clusterPath";
            this.textBox_clusterPath.Size = new System.Drawing.Size(246, 20);
            this.textBox_clusterPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Clusters:";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(136, 421);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(217, 421);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton_univSet);
            this.groupBox3.Controls.Add(this.radioButton_subset);
            this.groupBox3.Location = new System.Drawing.Point(13, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(404, 44);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Automation flow";
            // 
            // radioButton_univSet
            // 
            this.radioButton_univSet.AutoSize = true;
            this.radioButton_univSet.Location = new System.Drawing.Point(204, 19);
            this.radioButton_univSet.Name = "radioButton_univSet";
            this.radioButton_univSet.Size = new System.Drawing.Size(106, 17);
            this.radioButton_univSet.TabIndex = 1;
            this.radioButton_univSet.Text = "Use universal set";
            this.radioButton_univSet.UseVisualStyleBackColor = true;
            this.radioButton_univSet.CheckedChanged += new System.EventHandler(this.radioButton_univSet_CheckedChanged);
            // 
            // radioButton_subset
            // 
            this.radioButton_subset.AutoSize = true;
            this.radioButton_subset.Checked = true;
            this.radioButton_subset.Location = new System.Drawing.Point(11, 19);
            this.radioButton_subset.Name = "radioButton_subset";
            this.radioButton_subset.Size = new System.Drawing.Size(78, 17);
            this.radioButton_subset.TabIndex = 0;
            this.radioButton_subset.TabStop = true;
            this.radioButton_subset.Text = "Use subset";
            this.radioButton_subset.UseVisualStyleBackColor = true;
            this.radioButton_subset.CheckedChanged += new System.EventHandler(this.radioButton_subset_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_status);
            this.groupBox4.Location = new System.Drawing.Point(13, 278);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(404, 135);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status";
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(7, 20);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_status.Size = new System.Drawing.Size(391, 109);
            this.textBox_status.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_browseLog);
            this.groupBox5.Controls.Add(this.textBox_logPath);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(13, 224);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(404, 48);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Logging";
            // 
            // button_browseLog
            // 
            this.button_browseLog.Location = new System.Drawing.Point(323, 18);
            this.button_browseLog.Name = "button_browseLog";
            this.button_browseLog.Size = new System.Drawing.Size(75, 23);
            this.button_browseLog.TabIndex = 2;
            this.button_browseLog.Text = "Browse";
            this.button_browseLog.UseVisualStyleBackColor = true;
            this.button_browseLog.Click += new System.EventHandler(this.button_browseLog_Click);
            // 
            // textBox_logPath
            // 
            this.textBox_logPath.Location = new System.Drawing.Point(71, 20);
            this.textBox_logPath.Name = "textBox_logPath";
            this.textBox_logPath.Size = new System.Drawing.Size(246, 20);
            this.textBox_logPath.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Log path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Clusters with stocks more than:";
            // 
            // Form_Autosubset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 451);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Autosubset";
            this.Text = "Use Subset for Following Action";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_browseStock;
        private System.Windows.Forms.TextBox textBox_stockPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_minStocksInCluster;
        private System.Windows.Forms.Button button_browseCluster;
        private System.Windows.Forms.TextBox textBox_clusterPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton_univSet;
        private System.Windows.Forms.RadioButton radioButton_subset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_browseLog;
        private System.Windows.Forms.TextBox textBox_logPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}