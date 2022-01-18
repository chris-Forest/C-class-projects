namespace chris_ica05
{
    partial class ica6
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
            this.sortBox = new System.Windows.Forms.GroupBox();
            this.ClrRadioButton = new System.Windows.Forms.RadioButton();
            this.DisRadioButton = new System.Windows.Forms.RadioButton();
            this.RadiusRadioButton = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.sortBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ADDbutton
            // 
            this.ADDbutton.Location = new System.Drawing.Point(13, 13);
            this.ADDbutton.Name = "ADDbutton";
            this.ADDbutton.Size = new System.Drawing.Size(441, 44);
            this.ADDbutton.TabIndex = 0;
            this.ADDbutton.Text = "Replace this text";
            this.ADDbutton.UseVisualStyleBackColor = true;
            // 
            // sortBox
            // 
            this.sortBox.Controls.Add(this.ClrRadioButton);
            this.sortBox.Controls.Add(this.DisRadioButton);
            this.sortBox.Controls.Add(this.RadiusRadioButton);
            this.sortBox.Location = new System.Drawing.Point(13, 79);
            this.sortBox.Name = "sortBox";
            this.sortBox.Size = new System.Drawing.Size(441, 70);
            this.sortBox.TabIndex = 1;
            this.sortBox.TabStop = false;
            this.sortBox.Text = "Sort type";
            // 
            // ClrRadioButton
            // 
            this.ClrRadioButton.AutoSize = true;
            this.ClrRadioButton.Location = new System.Drawing.Point(305, 30);
            this.ClrRadioButton.Name = "ClrRadioButton";
            this.ClrRadioButton.Size = new System.Drawing.Size(49, 17);
            this.ClrRadioButton.TabIndex = 2;
            this.ClrRadioButton.TabStop = true;
            this.ClrRadioButton.Text = "Color";
            this.ClrRadioButton.UseVisualStyleBackColor = true;
            // 
            // DisRadioButton
            // 
            this.DisRadioButton.AutoSize = true;
            this.DisRadioButton.Location = new System.Drawing.Point(150, 30);
            this.DisRadioButton.Name = "DisRadioButton";
            this.DisRadioButton.Size = new System.Drawing.Size(67, 17);
            this.DisRadioButton.TabIndex = 1;
            this.DisRadioButton.TabStop = true;
            this.DisRadioButton.Text = "Distance";
            this.DisRadioButton.UseVisualStyleBackColor = true;
            // 
            // RadiusRadioButton
            // 
            this.RadiusRadioButton.AutoSize = true;
            this.RadiusRadioButton.Location = new System.Drawing.Point(19, 30);
            this.RadiusRadioButton.Name = "RadiusRadioButton";
            this.RadiusRadioButton.Size = new System.Drawing.Size(58, 17);
            this.RadiusRadioButton.TabIndex = 0;
            this.RadiusRadioButton.TabStop = true;
            this.RadiusRadioButton.Text = "Radius";
            this.RadiusRadioButton.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-2, 171);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(471, 62);
            this.progressBar1.TabIndex = 2;
            // 
            // ica6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 235);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.sortBox);
            this.Controls.Add(this.ADDbutton);
            this.Name = "ica6";
            this.Text = "ica 6";
            this.sortBox.ResumeLayout(false);
            this.sortBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ADDbutton;
        private System.Windows.Forms.GroupBox sortBox;
        private System.Windows.Forms.RadioButton ClrRadioButton;
        private System.Windows.Forms.RadioButton DisRadioButton;
        private System.Windows.Forms.RadioButton RadiusRadioButton;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

