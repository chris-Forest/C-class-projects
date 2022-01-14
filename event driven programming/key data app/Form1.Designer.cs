namespace ica4
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.KeyCodeLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.RunLabel = new System.Windows.Forms.Label();
            this.KeyResult = new System.Windows.Forms.Label();
            this.onesTotalLabel = new System.Windows.Forms.Label();
            this.runResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(186, 13);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(227, 303);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // KeyCodeLabel
            // 
            this.KeyCodeLabel.AutoSize = true;
            this.KeyCodeLabel.Location = new System.Drawing.Point(13, 13);
            this.KeyCodeLabel.Name = "KeyCodeLabel";
            this.KeyCodeLabel.Size = new System.Drawing.Size(59, 13);
            this.KeyCodeLabel.TabIndex = 1;
            this.KeyCodeLabel.Text = "Key Code: ";
            // 
            // CountLabel
            // 
            this.CountLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(13, 192);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(69, 13);
            this.CountLabel.TabIndex = 2;
            this.CountLabel.Text = "Ones Count: ";
            // 
            // RunLabel
            // 
            this.RunLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RunLabel.AutoSize = true;
            this.RunLabel.Location = new System.Drawing.Point(13, 225);
            this.RunLabel.Name = "RunLabel";
            this.RunLabel.Size = new System.Drawing.Size(71, 13);
            this.RunLabel.TabIndex = 3;
            this.RunLabel.Text = "Longest Run:";
            // 
            // KeyResult
            // 
            this.KeyResult.AutoSize = true;
            this.KeyResult.Location = new System.Drawing.Point(80, 13);
            this.KeyResult.Name = "KeyResult";
            this.KeyResult.Size = new System.Drawing.Size(13, 13);
            this.KeyResult.TabIndex = 4;
            this.KeyResult.Text = "0";
            // 
            // onesTotalLabel
            // 
            this.onesTotalLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.onesTotalLabel.AutoSize = true;
            this.onesTotalLabel.Location = new System.Drawing.Point(98, 192);
            this.onesTotalLabel.Name = "onesTotalLabel";
            this.onesTotalLabel.Size = new System.Drawing.Size(13, 13);
            this.onesTotalLabel.TabIndex = 5;
            this.onesTotalLabel.Text = "0";
            // 
            // runResultLabel
            // 
            this.runResultLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.runResultLabel.AutoSize = true;
            this.runResultLabel.Location = new System.Drawing.Point(98, 225);
            this.runResultLabel.Name = "runResultLabel";
            this.runResultLabel.Size = new System.Drawing.Size(13, 13);
            this.runResultLabel.TabIndex = 6;
            this.runResultLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 338);
            this.Controls.Add(this.runResultLabel);
            this.Controls.Add(this.onesTotalLabel);
            this.Controls.Add(this.KeyResult);
            this.Controls.Add(this.RunLabel);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.KeyCodeLabel);
            this.Controls.Add(this.listBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label KeyCodeLabel;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label RunLabel;
        private System.Windows.Forms.Label KeyResult;
        private System.Windows.Forms.Label onesTotalLabel;
        private System.Windows.Forms.Label runResultLabel;
    }
}

