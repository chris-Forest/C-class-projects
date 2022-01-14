namespace nica9
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
            this.label1 = new System.Windows.Forms.Label();
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            this.GENbutton = new System.Windows.Forms.Button();
            this.SortButton = new System.Windows.Forms.Button();
            this.STPButton = new System.Windows.Forms.Button();
            this.DataBox = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Values";
            // 
            // numUpDown
            // 
            this.numUpDown.Location = new System.Drawing.Point(16, 30);
            this.numUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(88, 20);
            this.numUpDown.TabIndex = 1;
            this.numUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // GENbutton
            // 
            this.GENbutton.Location = new System.Drawing.Point(16, 75);
            this.GENbutton.Name = "GENbutton";
            this.GENbutton.Size = new System.Drawing.Size(88, 23);
            this.GENbutton.TabIndex = 2;
            this.GENbutton.Text = "Generate";
            this.GENbutton.UseVisualStyleBackColor = true;
            this.GENbutton.Click += new System.EventHandler(this.GENbutton_Click);
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(16, 173);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(88, 23);
            this.SortButton.TabIndex = 3;
            this.SortButton.Text = "Sort";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // STPButton
            // 
            this.STPButton.Location = new System.Drawing.Point(16, 127);
            this.STPButton.Name = "STPButton";
            this.STPButton.Size = new System.Drawing.Size(88, 23);
            this.STPButton.TabIndex = 4;
            this.STPButton.Text = "Stop";
            this.STPButton.UseVisualStyleBackColor = true;
            this.STPButton.Click += new System.EventHandler(this.STPButton_Click);
            // 
            // DataBox
            // 
            this.DataBox.FormattingEnabled = true;
            this.DataBox.Location = new System.Drawing.Point(134, 13);
            this.DataBox.Name = "DataBox";
            this.DataBox.Size = new System.Drawing.Size(138, 251);
            this.DataBox.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 270);
            this.progressBar1.Maximum = 10000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(259, 23);
            this.progressBar1.Step = 500;
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Value = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 304);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.DataBox);
            this.Controls.Add(this.STPButton);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.GENbutton);
            this.Controls.Add(this.numUpDown);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDown;
        private System.Windows.Forms.Button GENbutton;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Button STPButton;
        private System.Windows.Forms.ListBox DataBox;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

