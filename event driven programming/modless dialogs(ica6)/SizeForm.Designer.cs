namespace ica6
{
    partial class SizeForm
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
            this.SizeTrackBar = new System.Windows.Forms.TrackBar();
            this.minLabel = new System.Windows.Forms.Label();
            this.MaxLlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SizeTrackBar
            // 
            this.SizeTrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.SizeTrackBar.Location = new System.Drawing.Point(13, 12);
            this.SizeTrackBar.Maximum = 100;
            this.SizeTrackBar.Minimum = 10;
            this.SizeTrackBar.Name = "SizeTrackBar";
            this.SizeTrackBar.Size = new System.Drawing.Size(383, 45);
            this.SizeTrackBar.TabIndex = 0;
            this.SizeTrackBar.TickFrequency = 10;
            this.SizeTrackBar.Value = 10;
            this.SizeTrackBar.ValueChanged += new System.EventHandler(this.SizeTrackBar_ValueChanged);
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(13, 64);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(19, 13);
            this.minLabel.TabIndex = 1;
            this.minLabel.Text = "10";
            // 
            // MaxLlabel
            // 
            this.MaxLlabel.AutoSize = true;
            this.MaxLlabel.Location = new System.Drawing.Point(371, 64);
            this.MaxLlabel.Name = "MaxLlabel";
            this.MaxLlabel.Size = new System.Drawing.Size(25, 13);
            this.MaxLlabel.TabIndex = 2;
            this.MaxLlabel.Text = "100";
            // 
            // SizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 102);
            this.Controls.Add(this.MaxLlabel);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.SizeTrackBar);
            this.Name = "SizeForm";
            this.Text = "Size";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SizeForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar SizeTrackBar;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label MaxLlabel;
    }
}