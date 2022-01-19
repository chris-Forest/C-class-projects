
namespace server
{
    partial class ServerForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSoft = new System.Windows.Forms.RadioButton();
            this.rdoHard = new System.Windows.Forms.RadioButton();
            this.DiscoBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clients: 0";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(17, 76);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(583, 511);
            this.listBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSoft);
            this.groupBox1.Controls.Add(this.rdoHard);
            this.groupBox1.Location = new System.Drawing.Point(129, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 44);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type disco";
            // 
            // rdoSoft
            // 
            this.rdoSoft.AutoSize = true;
            this.rdoSoft.Location = new System.Drawing.Point(97, 21);
            this.rdoSoft.Name = "rdoSoft";
            this.rdoSoft.Size = new System.Drawing.Size(42, 17);
            this.rdoSoft.TabIndex = 1;
            this.rdoSoft.TabStop = true;
            this.rdoSoft.Text = "soft";
            this.rdoSoft.UseVisualStyleBackColor = true;
            // 
            // rdoHard
            // 
            this.rdoHard.AutoSize = true;
            this.rdoHard.Location = new System.Drawing.Point(6, 21);
            this.rdoHard.Name = "rdoHard";
            this.rdoHard.Size = new System.Drawing.Size(48, 17);
            this.rdoHard.TabIndex = 0;
            this.rdoHard.TabStop = true;
            this.rdoHard.Text = "Hard";
            this.rdoHard.UseVisualStyleBackColor = true;
            // 
            // DiscoBtn
            // 
            this.DiscoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscoBtn.Location = new System.Drawing.Point(412, 13);
            this.DiscoBtn.Name = "DiscoBtn";
            this.DiscoBtn.Size = new System.Drawing.Size(188, 44);
            this.DiscoBtn.TabIndex = 3;
            this.DiscoBtn.Text = "Disconect";
            this.DiscoBtn.UseVisualStyleBackColor = true;
            this.DiscoBtn.Click += new System.EventHandler(this.DiscoBtn_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 599);
            this.Controls.Add(this.DiscoBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoSoft;
        private System.Windows.Forms.RadioButton rdoHard;
        private System.Windows.Forms.Button DiscoBtn;
    }
}

