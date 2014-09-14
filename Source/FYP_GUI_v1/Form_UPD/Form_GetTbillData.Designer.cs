namespace FYP_GUI_v1
{
    partial class Form_GetTbillData
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
            this.label2 = new System.Windows.Forms.Label();
            this.button_log = new System.Windows.Forms.Button();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_lastUpdateTime = new System.Windows.Forms.Label();
            this.button_browse = new System.Windows.Forms.Button();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_log);
            this.groupBox1.Controls.Add(this.textBox_log);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label_lastUpdateTime);
            this.groupBox1.Controls.Add(this.button_browse);
            this.groupBox1.Controls.Add(this.textBox_path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Log path:";
            // 
            // button_log
            // 
            this.button_log.Location = new System.Drawing.Point(316, 48);
            this.button_log.Name = "button_log";
            this.button_log.Size = new System.Drawing.Size(75, 23);
            this.button_log.TabIndex = 6;
            this.button_log.Text = "Browse";
            this.button_log.UseVisualStyleBackColor = true;
            this.button_log.Click += new System.EventHandler(this.button_log_Click);
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(73, 50);
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.Size = new System.Drawing.Size(237, 20);
            this.textBox_log.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last update:";
            // 
            // label_lastUpdateTime
            // 
            this.label_lastUpdateTime.AutoSize = true;
            this.label_lastUpdateTime.Location = new System.Drawing.Point(70, 82);
            this.label_lastUpdateTime.Name = "label_lastUpdateTime";
            this.label_lastUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.label_lastUpdateTime.TabIndex = 3;
            this.label_lastUpdateTime.Text = "<Undefined>";
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(316, 18);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(75, 23);
            this.button_browse.TabIndex = 2;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(73, 20);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(237, 20);
            this.textBox_path.TabIndex = 1;
            this.textBox_path.TextChanged += new System.EventHandler(this.textBox_path_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Store path:";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(134, 314);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(215, 314);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_status);
            this.groupBox2.Location = new System.Drawing.Point(13, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 177);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(7, 20);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_status.Size = new System.Drawing.Size(384, 151);
            this.textBox_status.TabIndex = 0;
            // 
            // Form_GetTbillData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 346);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_GetTbillData";
            this.Text = "Get Treasury Data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_lastUpdateTime;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_log;
        private System.Windows.Forms.TextBox textBox_log;
    }
}