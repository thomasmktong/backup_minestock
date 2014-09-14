namespace FYP_GUI_v1
{
    partial class Form_ClusterSSEC
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
            this.trackBar_lotsd = new System.Windows.Forms.TrackBar();
            this.textBox_lotsd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar_noctbd = new System.Windows.Forms.TrackBar();
            this.textBox_noctbd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_logPath = new System.Windows.Forms.TextBox();
            this.button_logPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_clusterPath = new System.Windows.Forms.TextBox();
            this.button_clusterPath = new System.Windows.Forms.Button();
            this.button_stockPath = new System.Windows.Forms.Button();
            this.textBox_stockPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_lotsd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_noctbd)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBar_lotsd);
            this.groupBox1.Controls.Add(this.textBox_lotsd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.trackBar_noctbd);
            this.groupBox1.Controls.Add(this.textBox_noctbd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // trackBar_lotsd
            // 
            this.trackBar_lotsd.Location = new System.Drawing.Point(10, 124);
            this.trackBar_lotsd.Minimum = 2;
            this.trackBar_lotsd.Name = "trackBar_lotsd";
            this.trackBar_lotsd.Size = new System.Drawing.Size(203, 42);
            this.trackBar_lotsd.TabIndex = 4;
            this.trackBar_lotsd.Value = 5;
            // 
            // textBox_lotsd
            // 
            this.textBox_lotsd.Location = new System.Drawing.Point(170, 98);
            this.textBox_lotsd.Name = "textBox_lotsd";
            this.textBox_lotsd.Size = new System.Drawing.Size(43, 20);
            this.textBox_lotsd.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Length of the sequences divided:";
            // 
            // trackBar_noctbd
            // 
            this.trackBar_noctbd.Location = new System.Drawing.Point(10, 43);
            this.trackBar_noctbd.Maximum = 20;
            this.trackBar_noctbd.Minimum = 2;
            this.trackBar_noctbd.Name = "trackBar_noctbd";
            this.trackBar_noctbd.Size = new System.Drawing.Size(203, 42);
            this.trackBar_noctbd.TabIndex = 2;
            this.trackBar_noctbd.Value = 8;
            // 
            // textBox_noctbd
            // 
            this.textBox_noctbd.Location = new System.Drawing.Point(170, 17);
            this.textBox_noctbd.Name = "textBox_noctbd";
            this.textBox_noctbd.Size = new System.Drawing.Size(43, 20);
            this.textBox_noctbd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of cluster to be divided:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_logPath);
            this.groupBox2.Controls.Add(this.button_logPath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_clusterPath);
            this.groupBox2.Controls.Add(this.button_clusterPath);
            this.groupBox2.Controls.Add(this.button_stockPath);
            this.groupBox2.Controls.Add(this.textBox_stockPath);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(242, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 168);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cluster log:";
            // 
            // textBox_logPath
            // 
            this.textBox_logPath.Location = new System.Drawing.Point(83, 104);
            this.textBox_logPath.Name = "textBox_logPath";
            this.textBox_logPath.Size = new System.Drawing.Size(222, 20);
            this.textBox_logPath.TabIndex = 7;
            // 
            // button_logPath
            // 
            this.button_logPath.Location = new System.Drawing.Point(311, 102);
            this.button_logPath.Name = "button_logPath";
            this.button_logPath.Size = new System.Drawing.Size(75, 23);
            this.button_logPath.TabIndex = 6;
            this.button_logPath.Text = "Browse";
            this.button_logPath.UseVisualStyleBackColor = true;
            this.button_logPath.Click += new System.EventHandler(this.button_logPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cluster result:";
            // 
            // textBox_clusterPath
            // 
            this.textBox_clusterPath.Location = new System.Drawing.Point(83, 74);
            this.textBox_clusterPath.Name = "textBox_clusterPath";
            this.textBox_clusterPath.Size = new System.Drawing.Size(222, 20);
            this.textBox_clusterPath.TabIndex = 4;
            // 
            // button_clusterPath
            // 
            this.button_clusterPath.Location = new System.Drawing.Point(311, 72);
            this.button_clusterPath.Name = "button_clusterPath";
            this.button_clusterPath.Size = new System.Drawing.Size(75, 23);
            this.button_clusterPath.TabIndex = 3;
            this.button_clusterPath.Text = "Browse";
            this.button_clusterPath.UseVisualStyleBackColor = true;
            this.button_clusterPath.Click += new System.EventHandler(this.button_clusterPath_Click);
            // 
            // button_stockPath
            // 
            this.button_stockPath.Location = new System.Drawing.Point(311, 42);
            this.button_stockPath.Name = "button_stockPath";
            this.button_stockPath.Size = new System.Drawing.Size(75, 23);
            this.button_stockPath.TabIndex = 2;
            this.button_stockPath.Text = "Browse";
            this.button_stockPath.UseVisualStyleBackColor = true;
            this.button_stockPath.Click += new System.EventHandler(this.button_stockPath_Click);
            // 
            // textBox_stockPath
            // 
            this.textBox_stockPath.Location = new System.Drawing.Point(83, 44);
            this.textBox_stockPath.Name = "textBox_stockPath";
            this.textBox_stockPath.Size = new System.Drawing.Size(222, 20);
            this.textBox_stockPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Stock data:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_status);
            this.groupBox3.Location = new System.Drawing.Point(12, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(622, 266);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(7, 20);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_status.Size = new System.Drawing.Size(609, 240);
            this.textBox_status.TabIndex = 0;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(243, 459);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(328, 459);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form_ClusterSSEC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 493);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_ClusterSSEC";
            this.Text = "Identical Fix Length Sequence Discovery";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_lotsd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_noctbd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar_noctbd;
        private System.Windows.Forms.TextBox textBox_noctbd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_stockPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_stockPath;
        private System.Windows.Forms.TextBox textBox_logPath;
        private System.Windows.Forms.Button button_logPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_clusterPath;
        private System.Windows.Forms.Button button_clusterPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.TrackBar trackBar_lotsd;
        private System.Windows.Forms.TextBox textBox_lotsd;
        private System.Windows.Forms.Label label5;
    }
}