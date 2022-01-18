namespace chris_ica10
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
            this.divisorUpDown = new System.Windows.Forms.NumericUpDown();
            this.ListButton = new System.Windows.Forms.Button();
            this.ShufflleButton = new System.Windows.Forms.Button();
            this.POPbutton = new System.Windows.Forms.Button();
            this.FilterANDorderBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.divisorUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // divisorUpDown
            // 
            this.divisorUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divisorUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.divisorUpDown.Location = new System.Drawing.Point(13, 13);
            this.divisorUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.divisorUpDown.Name = "divisorUpDown";
            this.divisorUpDown.Size = new System.Drawing.Size(244, 24);
            this.divisorUpDown.TabIndex = 0;
            // 
            // ListButton
            // 
            this.ListButton.Location = new System.Drawing.Point(13, 43);
            this.ListButton.Name = "ListButton";
            this.ListButton.Size = new System.Drawing.Size(244, 33);
            this.ListButton.TabIndex = 1;
            this.ListButton.Text = "Make list";
            this.ListButton.UseVisualStyleBackColor = true;
            // 
            // ShufflleButton
            // 
            this.ShufflleButton.Location = new System.Drawing.Point(12, 82);
            this.ShufflleButton.Name = "ShufflleButton";
            this.ShufflleButton.Size = new System.Drawing.Size(244, 33);
            this.ShufflleButton.TabIndex = 2;
            this.ShufflleButton.Text = "Shuffle";
            this.ShufflleButton.UseVisualStyleBackColor = true;
            // 
            // POPbutton
            // 
            this.POPbutton.Location = new System.Drawing.Point(12, 121);
            this.POPbutton.Name = "POPbutton";
            this.POPbutton.Size = new System.Drawing.Size(244, 33);
            this.POPbutton.TabIndex = 3;
            this.POPbutton.Text = "Populate List";
            this.POPbutton.UseVisualStyleBackColor = true;
            // 
            // FilterANDorderBtn
            // 
            this.FilterANDorderBtn.Location = new System.Drawing.Point(13, 160);
            this.FilterANDorderBtn.Name = "FilterANDorderBtn";
            this.FilterANDorderBtn.Size = new System.Drawing.Size(244, 33);
            this.FilterANDorderBtn.TabIndex = 4;
            this.FilterANDorderBtn.Text = "Filter and Order";
            this.FilterANDorderBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 208);
            this.Controls.Add(this.FilterANDorderBtn);
            this.Controls.Add(this.POPbutton);
            this.Controls.Add(this.ShufflleButton);
            this.Controls.Add(this.ListButton);
            this.Controls.Add(this.divisorUpDown);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.divisorUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown divisorUpDown;
        private System.Windows.Forms.Button ListButton;
        private System.Windows.Forms.Button ShufflleButton;
        private System.Windows.Forms.Button POPbutton;
        private System.Windows.Forms.Button FilterANDorderBtn;
    }
}

