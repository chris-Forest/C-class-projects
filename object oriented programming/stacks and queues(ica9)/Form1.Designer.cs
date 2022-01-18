namespace chris_ica9
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
            this.simulateBtn = new System.Windows.Forms.Button();
            this.howManyUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelStack = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.howManyUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // simulateBtn
            // 
            this.simulateBtn.Location = new System.Drawing.Point(13, 13);
            this.simulateBtn.Name = "simulateBtn";
            this.simulateBtn.Size = new System.Drawing.Size(157, 40);
            this.simulateBtn.TabIndex = 0;
            this.simulateBtn.Text = "simulate";
            this.simulateBtn.UseVisualStyleBackColor = true;
            this.simulateBtn.Click += new System.EventHandler(this.simulateBtn_Click);
            // 
            // howManyUpDown1
            // 
            this.howManyUpDown1.Location = new System.Drawing.Point(177, 13);
            this.howManyUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.howManyUpDown1.Name = "howManyUpDown1";
            this.howManyUpDown1.Size = new System.Drawing.Size(47, 20);
            this.howManyUpDown1.TabIndex = 1;
            this.howManyUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelStack
            // 
            this.labelStack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStack.Location = new System.Drawing.Point(13, 56);
            this.labelStack.Name = "labelStack";
            this.labelStack.Size = new System.Drawing.Size(205, 30);
            this.labelStack.TabIndex = 2;
            this.labelStack.Text = "label";
            this.labelStack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 95);
            this.Controls.Add(this.labelStack);
            this.Controls.Add(this.howManyUpDown1);
            this.Controls.Add(this.simulateBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.howManyUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button simulateBtn;
        private System.Windows.Forms.NumericUpDown howManyUpDown1;
        private System.Windows.Forms.Label labelStack;
        private System.Windows.Forms.Timer timer1;
    }
}

