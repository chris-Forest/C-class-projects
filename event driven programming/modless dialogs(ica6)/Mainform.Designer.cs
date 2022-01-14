namespace ica6
{
    partial class Mainform
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
            this.colorDialogBox = new System.Windows.Forms.CheckBox();
            this.SizeDialogBox = new System.Windows.Forms.CheckBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.shapeSize = new System.Windows.Forms.Label();
            this.DrawColorBox = new System.Windows.Forms.PictureBox();
            this.SizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DrawColorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // colorDialogBox
            // 
            this.colorDialogBox.AutoSize = true;
            this.colorDialogBox.Location = new System.Drawing.Point(13, 13);
            this.colorDialogBox.Name = "colorDialogBox";
            this.colorDialogBox.Size = new System.Drawing.Size(113, 17);
            this.colorDialogBox.TabIndex = 0;
            this.colorDialogBox.Text = "Show Color Dialog";
            this.colorDialogBox.UseVisualStyleBackColor = true;
            this.colorDialogBox.CheckedChanged += new System.EventHandler(this.colorDialogBox_CheckedChanged);
            // 
            // SizeDialogBox
            // 
            this.SizeDialogBox.AutoSize = true;
            this.SizeDialogBox.Location = new System.Drawing.Point(12, 36);
            this.SizeDialogBox.Name = "SizeDialogBox";
            this.SizeDialogBox.Size = new System.Drawing.Size(109, 17);
            this.SizeDialogBox.TabIndex = 1;
            this.SizeDialogBox.Text = "Show Size Dialog";
            this.SizeDialogBox.UseVisualStyleBackColor = true;
            this.SizeDialogBox.CheckedChanged += new System.EventHandler(this.SizeDialogBox_CheckedChanged);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(155, 13);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(76, 13);
            this.colorLabel.TabIndex = 2;
            this.colorLabel.Text = "Drawing Color:";
            // 
            // shapeSize
            // 
            this.shapeSize.AutoSize = true;
            this.shapeSize.Location = new System.Drawing.Point(155, 40);
            this.shapeSize.Name = "shapeSize";
            this.shapeSize.Size = new System.Drawing.Size(59, 13);
            this.shapeSize.TabIndex = 3;
            this.shapeSize.Text = "Circle Size:";
            // 
            // DrawColorBox
            // 
            this.DrawColorBox.Location = new System.Drawing.Point(238, 13);
            this.DrawColorBox.Name = "DrawColorBox";
            this.DrawColorBox.Size = new System.Drawing.Size(38, 17);
            this.DrawColorBox.TabIndex = 4;
            this.DrawColorBox.TabStop = false;
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(235, 40);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(13, 13);
            this.SizeLabel.TabIndex = 5;
            this.SizeLabel.Text = "_";
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 79);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.DrawColorBox);
            this.Controls.Add(this.shapeSize);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.SizeDialogBox);
            this.Controls.Add(this.colorDialogBox);
            this.Name = "Mainform";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DrawColorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox colorDialogBox;
        private System.Windows.Forms.CheckBox SizeDialogBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label shapeSize;
        private System.Windows.Forms.PictureBox DrawColorBox;
        private System.Windows.Forms.Label SizeLabel;
    }
}

