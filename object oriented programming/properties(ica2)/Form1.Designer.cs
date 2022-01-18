namespace Chris_ica02
{
    partial class Form1
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
            this.OpacityTrackBar = new System.Windows.Forms.TrackBar();
            this.XtrackBar = new System.Windows.Forms.TrackBar();
            this.YtrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AllBalls = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XtrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YtrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // OpacityTrackBar
            // 
            this.OpacityTrackBar.Location = new System.Drawing.Point(106, 12);
            this.OpacityTrackBar.Maximum = 255;
            this.OpacityTrackBar.Name = "OpacityTrackBar";
            this.OpacityTrackBar.Size = new System.Drawing.Size(428, 45);
            this.OpacityTrackBar.TabIndex = 0;
            this.OpacityTrackBar.TickFrequency = 15;
            // 
            // XtrackBar
            // 
            this.XtrackBar.Location = new System.Drawing.Point(106, 63);
            this.XtrackBar.Maximum = 15;
            this.XtrackBar.Minimum = -15;
            this.XtrackBar.Name = "XtrackBar";
            this.XtrackBar.Size = new System.Drawing.Size(428, 45);
            this.XtrackBar.TabIndex = 1;
            // 
            // YtrackBar
            // 
            this.YtrackBar.Location = new System.Drawing.Point(106, 114);
            this.YtrackBar.Maximum = 15;
            this.YtrackBar.Minimum = -10;
            this.YtrackBar.Name = "YtrackBar";
            this.YtrackBar.Size = new System.Drawing.Size(428, 45);
            this.YtrackBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Opacity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "000";
            // 
            // AllBalls
            // 
            this.AllBalls.AutoSize = true;
            this.AllBalls.Location = new System.Drawing.Point(258, 170);
            this.AllBalls.Name = "AllBalls";
            this.AllBalls.Size = new System.Drawing.Size(37, 17);
            this.AllBalls.TabIndex = 9;
            this.AllBalls.Text = "All";
            this.AllBalls.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 199);
            this.Controls.Add(this.AllBalls);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YtrackBar);
            this.Controls.Add(this.XtrackBar);
            this.Controls.Add(this.OpacityTrackBar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OpacityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XtrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YtrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar OpacityTrackBar;
        private System.Windows.Forms.TrackBar XtrackBar;
        private System.Windows.Forms.TrackBar YtrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox AllBalls;
    }
}

