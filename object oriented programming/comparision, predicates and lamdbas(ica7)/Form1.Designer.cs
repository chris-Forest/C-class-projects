namespace Chris_ica7
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
            this.PopulateButton = new System.Windows.Forms.Button();
            this.Clrbutton = new System.Windows.Forms.Button();
            this.WidthButton = new System.Windows.Forms.Button();
            this.DecButton = new System.Windows.Forms.Button();
            this.WidClrButton = new System.Windows.Forms.Button();
            this.BrightButton = new System.Windows.Forms.Button();
            this.LessButton = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // PopulateButton
            // 
            this.PopulateButton.Location = new System.Drawing.Point(12, 12);
            this.PopulateButton.Name = "PopulateButton";
            this.PopulateButton.Size = new System.Drawing.Size(267, 56);
            this.PopulateButton.TabIndex = 0;
            this.PopulateButton.Text = "Populate";
            this.PopulateButton.UseVisualStyleBackColor = true;
            // 
            // Clrbutton
            // 
            this.Clrbutton.Location = new System.Drawing.Point(12, 74);
            this.Clrbutton.Name = "Clrbutton";
            this.Clrbutton.Size = new System.Drawing.Size(267, 56);
            this.Clrbutton.TabIndex = 1;
            this.Clrbutton.Text = "Color";
            this.Clrbutton.UseVisualStyleBackColor = true;
            // 
            // WidthButton
            // 
            this.WidthButton.Location = new System.Drawing.Point(12, 136);
            this.WidthButton.Name = "WidthButton";
            this.WidthButton.Size = new System.Drawing.Size(267, 56);
            this.WidthButton.TabIndex = 2;
            this.WidthButton.Text = "Width";
            this.WidthButton.UseVisualStyleBackColor = true;
            // 
            // DecButton
            // 
            this.DecButton.Location = new System.Drawing.Point(12, 198);
            this.DecButton.Name = "DecButton";
            this.DecButton.Size = new System.Drawing.Size(267, 56);
            this.DecButton.TabIndex = 3;
            this.DecButton.Text = "Width Desc";
            this.DecButton.UseVisualStyleBackColor = true;
            // 
            // WidClrButton
            // 
            this.WidClrButton.Location = new System.Drawing.Point(12, 260);
            this.WidClrButton.Name = "WidClrButton";
            this.WidClrButton.Size = new System.Drawing.Size(267, 56);
            this.WidClrButton.TabIndex = 4;
            this.WidClrButton.Text = "Width Color";
            this.WidClrButton.UseVisualStyleBackColor = true;
            // 
            // BrightButton
            // 
            this.BrightButton.BackColor = System.Drawing.SystemColors.Control;
            this.BrightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrightButton.Location = new System.Drawing.Point(12, 322);
            this.BrightButton.Name = "BrightButton";
            this.BrightButton.Size = new System.Drawing.Size(267, 56);
            this.BrightButton.TabIndex = 5;
            this.BrightButton.Text = "Bright";
            this.BrightButton.UseVisualStyleBackColor = true;
            // 
            // LessButton
            // 
            this.LessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LessButton.Location = new System.Drawing.Point(12, 385);
            this.LessButton.Name = "LessButton";
            this.LessButton.Size = new System.Drawing.Size(267, 56);
            this.LessButton.TabIndex = 6;
            this.LessButton.Text = "longer then 100";
            this.LessButton.UseVisualStyleBackColor = true;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(12, 447);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(264, 45);
            this.trackBar.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 515);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.LessButton);
            this.Controls.Add(this.BrightButton);
            this.Controls.Add(this.WidClrButton);
            this.Controls.Add(this.DecButton);
            this.Controls.Add(this.WidthButton);
            this.Controls.Add(this.Clrbutton);
            this.Controls.Add(this.PopulateButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PopulateButton;
        private System.Windows.Forms.Button Clrbutton;
        private System.Windows.Forms.Button WidthButton;
        private System.Windows.Forms.Button DecButton;
        private System.Windows.Forms.Button WidClrButton;
        private System.Windows.Forms.Button BrightButton;
        private System.Windows.Forms.Button LessButton;
        private System.Windows.Forms.TrackBar trackBar;
    }
}

