namespace Assignment_7
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.blockTrackbar = new System.Windows.Forms.TrackBar();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.generateBtn = new System.Windows.Forms.Button();
            this.fillColorBtn = new System.Windows.Forms.Button();
            this.fillBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.blockTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Blocks";
            // 
            // blockTrackbar
            // 
            this.blockTrackbar.Location = new System.Drawing.Point(12, 25);
            this.blockTrackbar.Maximum = 3000;
            this.blockTrackbar.Minimum = 100;
            this.blockTrackbar.Name = "blockTrackbar";
            this.blockTrackbar.Size = new System.Drawing.Size(280, 45);
            this.blockTrackbar.TabIndex = 1;
            this.blockTrackbar.TickFrequency = 100;
            this.blockTrackbar.Value = 100;
            // 
            // colorBox
            // 
            this.colorBox.Location = new System.Drawing.Point(123, 76);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(32, 23);
            this.colorBox.TabIndex = 2;
            this.colorBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fill Color";
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(12, 111);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(75, 23);
            this.generateBtn.TabIndex = 4;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // fillColorBtn
            // 
            this.fillColorBtn.Location = new System.Drawing.Point(114, 111);
            this.fillColorBtn.Name = "fillColorBtn";
            this.fillColorBtn.Size = new System.Drawing.Size(75, 23);
            this.fillColorBtn.TabIndex = 5;
            this.fillColorBtn.Text = "Fill Color";
            this.fillColorBtn.UseVisualStyleBackColor = true;
            this.fillColorBtn.Click += new System.EventHandler(this.fillColorBtn_Click);
            // 
            // fillBtn
            // 
            this.fillBtn.Location = new System.Drawing.Point(217, 111);
            this.fillBtn.Name = "fillBtn";
            this.fillBtn.Size = new System.Drawing.Size(75, 23);
            this.fillBtn.TabIndex = 6;
            this.fillBtn.Text = "Fill";
            this.fillBtn.UseVisualStyleBackColor = true;
            this.fillBtn.Click += new System.EventHandler(this.fillBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "3000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 146);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fillBtn);
            this.Controls.Add(this.fillColorBtn);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.blockTrackbar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.blockTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar blockTrackbar;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Button fillColorBtn;
        private System.Windows.Forms.Button fillBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

