namespace lab4
{
    partial class GameDifficulty
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
            this.HARDradioButton = new System.Windows.Forms.RadioButton();
            this.MEDradioButton = new System.Windows.Forms.RadioButton();
            this.EASYradioButton = new System.Windows.Forms.RadioButton();
            this.OKbutton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HARDradioButton);
            this.groupBox1.Controls.Add(this.MEDradioButton);
            this.groupBox1.Controls.Add(this.EASYradioButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Difficulty";
            // 
            // HARDradioButton
            // 
            this.HARDradioButton.AutoSize = true;
            this.HARDradioButton.Location = new System.Drawing.Point(7, 114);
            this.HARDradioButton.Name = "HARDradioButton";
            this.HARDradioButton.Size = new System.Drawing.Size(48, 17);
            this.HARDradioButton.TabIndex = 2;
            this.HARDradioButton.TabStop = true;
            this.HARDradioButton.Text = "Hard";
            this.HARDradioButton.UseVisualStyleBackColor = true;
            // 
            // MEDradioButton
            // 
            this.MEDradioButton.AutoSize = true;
            this.MEDradioButton.Location = new System.Drawing.Point(7, 71);
            this.MEDradioButton.Name = "MEDradioButton";
            this.MEDradioButton.Size = new System.Drawing.Size(62, 17);
            this.MEDradioButton.TabIndex = 1;
            this.MEDradioButton.TabStop = true;
            this.MEDradioButton.Text = "Medium";
            this.MEDradioButton.UseVisualStyleBackColor = true;
            // 
            // EASYradioButton
            // 
            this.EASYradioButton.AutoSize = true;
            this.EASYradioButton.Location = new System.Drawing.Point(7, 30);
            this.EASYradioButton.Name = "EASYradioButton";
            this.EASYradioButton.Size = new System.Drawing.Size(48, 17);
            this.EASYradioButton.TabIndex = 0;
            this.EASYradioButton.TabStop = true;
            this.EASYradioButton.Text = "Easy";
            this.EASYradioButton.UseVisualStyleBackColor = true;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(13, 180);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 1;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(143, 180);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // GameDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 214);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.groupBox1);
            this.Name = "GameDifficulty";
            this.Text = "Game Difficulty";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton HARDradioButton;
        private System.Windows.Forms.RadioButton MEDradioButton;
        private System.Windows.Forms.RadioButton EASYradioButton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button CancelButton;
    }
}