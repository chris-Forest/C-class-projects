namespace chris_ica11
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
            this.LoadButton = new System.Windows.Forms.Button();
            this.Avgbutton = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadButton.Location = new System.Drawing.Point(13, 13);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(237, 23);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load File";
            this.LoadButton.UseVisualStyleBackColor = true;
            // 
            // Avgbutton
            // 
            this.Avgbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Avgbutton.Location = new System.Drawing.Point(13, 43);
            this.Avgbutton.Name = "Avgbutton";
            this.Avgbutton.Size = new System.Drawing.Size(237, 23);
            this.Avgbutton.TabIndex = 1;
            this.Avgbutton.Text = "Average";
            this.Avgbutton.UseVisualStyleBackColor = true;
            // 
            // DGV
            // 
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(13, 73);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(237, 362);
            this.DGV.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 447);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.Avgbutton);
            this.Controls.Add(this.LoadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button Avgbutton;
        private System.Windows.Forms.DataGridView DGV;
    }
}

