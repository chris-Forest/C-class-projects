namespace lab2
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NoiseRadioButton = new System.Windows.Forms.RadioButton();
            this.TintRadioButton = new System.Windows.Forms.RadioButton();
            this.BlkToWhiteRadioButton = new System.Windows.Forms.RadioButton();
            this.ContrastRadioButton = new System.Windows.Forms.RadioButton();
            this.Transformbutton = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.leftLabel = new System.Windows.Forms.Label();
            this.RightLabel = new System.Windows.Forms.Label();
            this.midLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(871, 424);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoad.Location = new System.Drawing.Point(12, 458);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(100, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load Picture";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 442);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(869, 10);
            this.progressBar.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.NoiseRadioButton);
            this.groupBox1.Controls.Add(this.TintRadioButton);
            this.groupBox1.Controls.Add(this.BlkToWhiteRadioButton);
            this.groupBox1.Controls.Add(this.ContrastRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(118, 458);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 77);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modification Type";
            // 
            // NoiseRadioButton
            // 
            this.NoiseRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoiseRadioButton.AutoSize = true;
            this.NoiseRadioButton.Location = new System.Drawing.Point(132, 42);
            this.NoiseRadioButton.Name = "NoiseRadioButton";
            this.NoiseRadioButton.Size = new System.Drawing.Size(52, 17);
            this.NoiseRadioButton.TabIndex = 3;
            this.NoiseRadioButton.Text = "Noise";
            this.NoiseRadioButton.UseVisualStyleBackColor = true;
            // 
            // TintRadioButton
            // 
            this.TintRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TintRadioButton.AutoSize = true;
            this.TintRadioButton.Location = new System.Drawing.Point(132, 19);
            this.TintRadioButton.Name = "TintRadioButton";
            this.TintRadioButton.Size = new System.Drawing.Size(43, 17);
            this.TintRadioButton.TabIndex = 2;
            this.TintRadioButton.Text = "Tint";
            this.TintRadioButton.UseVisualStyleBackColor = true;
            // 
            // BlkToWhiteRadioButton
            // 
            this.BlkToWhiteRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlkToWhiteRadioButton.AutoSize = true;
            this.BlkToWhiteRadioButton.Location = new System.Drawing.Point(6, 43);
            this.BlkToWhiteRadioButton.Name = "BlkToWhiteRadioButton";
            this.BlkToWhiteRadioButton.Size = new System.Drawing.Size(104, 17);
            this.BlkToWhiteRadioButton.TabIndex = 1;
            this.BlkToWhiteRadioButton.Text = "Black and White";
            this.BlkToWhiteRadioButton.UseVisualStyleBackColor = true;
            // 
            // ContrastRadioButton
            // 
            this.ContrastRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContrastRadioButton.AutoSize = true;
            this.ContrastRadioButton.Checked = true;
            this.ContrastRadioButton.Location = new System.Drawing.Point(7, 20);
            this.ContrastRadioButton.Name = "ContrastRadioButton";
            this.ContrastRadioButton.Size = new System.Drawing.Size(64, 17);
            this.ContrastRadioButton.TabIndex = 0;
            this.ContrastRadioButton.TabStop = true;
            this.ContrastRadioButton.Text = "Contrast\r\n";
            this.ContrastRadioButton.UseVisualStyleBackColor = true;
            // 
            // Transformbutton
            // 
            this.Transformbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Transformbutton.Location = new System.Drawing.Point(784, 458);
            this.Transformbutton.Name = "Transformbutton";
            this.Transformbutton.Size = new System.Drawing.Size(99, 23);
            this.Transformbutton.TabIndex = 5;
            this.Transformbutton.Text = "Transform!";
            this.Transformbutton.UseVisualStyleBackColor = true;
            this.Transformbutton.Click += new System.EventHandler(this.Transformbutton_Click);
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar.Location = new System.Drawing.Point(369, 458);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(409, 45);
            this.trackBar.TabIndex = 6;
            this.trackBar.TickFrequency = 10;
            this.trackBar.Value = 50;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // leftLabel
            // 
            this.leftLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.leftLabel.AutoSize = true;
            this.leftLabel.Location = new System.Drawing.Point(369, 506);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.Size = new System.Drawing.Size(21, 13);
            this.leftLabel.TabIndex = 7;
            this.leftLabel.Text = "left";
            // 
            // RightLabel
            // 
            this.RightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RightLabel.AutoSize = true;
            this.RightLabel.Location = new System.Drawing.Point(751, 506);
            this.RightLabel.Name = "RightLabel";
            this.RightLabel.Size = new System.Drawing.Size(27, 13);
            this.RightLabel.TabIndex = 8;
            this.RightLabel.Text = "right";
            // 
            // midLabel
            // 
            this.midLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.midLabel.AutoSize = true;
            this.midLabel.Location = new System.Drawing.Point(560, 506);
            this.midLabel.Name = "midLabel";
            this.midLabel.Size = new System.Drawing.Size(23, 13);
            this.midLabel.TabIndex = 9;
            this.midLabel.Text = "mid";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 547);
            this.Controls.Add(this.midLabel);
            this.Controls.Add(this.RightLabel);
            this.Controls.Add(this.leftLabel);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.Transformbutton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pic Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton NoiseRadioButton;
        private System.Windows.Forms.RadioButton TintRadioButton;
        private System.Windows.Forms.RadioButton BlkToWhiteRadioButton;
        private System.Windows.Forms.RadioButton ContrastRadioButton;
        private System.Windows.Forms.Button Transformbutton;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label leftLabel;
        private System.Windows.Forms.Label RightLabel;
        private System.Windows.Forms.Label midLabel;
    }
}

