namespace chris_ica04
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
            this.ADDbutton = new System.Windows.Forms.Button();
            this.SizetrackBar = new System.Windows.Forms.TrackBar();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SizetrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ADDbutton
            // 
            this.ADDbutton.Location = new System.Drawing.Point(12, 97);
            this.ADDbutton.Name = "ADDbutton";
            this.ADDbutton.Size = new System.Drawing.Size(410, 42);
            this.ADDbutton.TabIndex = 0;
            this.ADDbutton.Text = "ADD";
            this.ADDbutton.UseVisualStyleBackColor = true;
            // 
            // SizetrackBar
            // 
            this.SizetrackBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SizetrackBar.Location = new System.Drawing.Point(12, 2);
            this.SizetrackBar.Maximum = 100;
            this.SizetrackBar.Minimum = -100;
            this.SizetrackBar.Name = "SizetrackBar";
            this.SizetrackBar.Size = new System.Drawing.Size(410, 45);
            this.SizetrackBar.TabIndex = 1;
            this.SizetrackBar.TickFrequency = 10;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 146);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(410, 50);
            this.progressBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Size = ";
            // 
            // labelVal
            // 
            this.labelVal.AutoSize = true;
            this.labelVal.Location = new System.Drawing.Point(227, 63);
            this.labelVal.Name = "labelVal";
            this.labelVal.Size = new System.Drawing.Size(13, 13);
            this.labelVal.TabIndex = 4;
            this.labelVal.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 208);
            this.Controls.Add(this.labelVal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.SizetrackBar);
            this.Controls.Add(this.ADDbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SizetrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ADDbutton;
        private System.Windows.Forms.TrackBar SizetrackBar;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelVal;
    }
}

