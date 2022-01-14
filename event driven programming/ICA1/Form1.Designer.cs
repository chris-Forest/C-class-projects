
namespace ICA1
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
            this.Value_enter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ValtextBox = new System.Windows.Forms.TextBox();
            this.AVGCount = new System.Windows.Forms.Label();
            this.ValCount = new System.Windows.Forms.Label();
            this.button_AVG = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Value_enter
            // 
            this.Value_enter.AutoSize = true;
            this.Value_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value_enter.Location = new System.Drawing.Point(12, 16);
            this.Value_enter.Name = "Value_enter";
            this.Value_enter.Size = new System.Drawing.Size(124, 42);
            this.Value_enter.TabIndex = 0;
            this.Value_enter.Text = "Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Crnt Avg:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 42);
            this.label3.TabIndex = 2;
            this.label3.Text = "num of vals:";
            // 
            // ValtextBox
            // 
            this.ValtextBox.Location = new System.Drawing.Point(243, 26);
            this.ValtextBox.Name = "ValtextBox";
            this.ValtextBox.Size = new System.Drawing.Size(69, 20);
            this.ValtextBox.TabIndex = 3;
            // 
            // AVGCount
            // 
            this.AVGCount.AutoSize = true;
            this.AVGCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AVGCount.Location = new System.Drawing.Point(236, 71);
            this.AVGCount.Name = "AVGCount";
            this.AVGCount.Size = new System.Drawing.Size(39, 42);
            this.AVGCount.TabIndex = 4;
            this.AVGCount.Text = "0";
            // 
            // ValCount
            // 
            this.ValCount.AutoSize = true;
            this.ValCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValCount.Location = new System.Drawing.Point(236, 133);
            this.ValCount.Name = "ValCount";
            this.ValCount.Size = new System.Drawing.Size(39, 42);
            this.ValCount.TabIndex = 5;
            this.ValCount.Text = "0";
            // 
            // button_AVG
            // 
            this.button_AVG.Location = new System.Drawing.Point(15, 213);
            this.button_AVG.Name = "button_AVG";
            this.button_AVG.Size = new System.Drawing.Size(207, 23);
            this.button_AVG.TabIndex = 6;
            this.button_AVG.Text = "AVG";
            this.button_AVG.UseVisualStyleBackColor = true;
            this.button_AVG.Click += new System.EventHandler(this.button_AVG_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(228, 213);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(189, 23);
            this.button_reset.TabIndex = 7;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 248);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_AVG);
            this.Controls.Add(this.ValCount);
            this.Controls.Add(this.AVGCount);
            this.Controls.Add(this.ValtextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Value_enter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Value_enter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ValtextBox;
        private System.Windows.Forms.Label AVGCount;
        private System.Windows.Forms.Label ValCount;
        private System.Windows.Forms.Button button_AVG;
        private System.Windows.Forms.Button button_reset;
    }
}

