namespace ica3_1600
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
            this.STARTbutton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.ShapeButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // STARTbutton
            // 
            this.STARTbutton.Location = new System.Drawing.Point(12, 12);
            this.STARTbutton.Name = "STARTbutton";
            this.STARTbutton.Size = new System.Drawing.Size(75, 28);
            this.STARTbutton.TabIndex = 0;
            this.STARTbutton.Text = "Start";
            this.STARTbutton.UseVisualStyleBackColor = true;
            this.STARTbutton.Click += new System.EventHandler(this.STARTbutton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(13, 47);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ColorButton
            // 
            this.ColorButton.Location = new System.Drawing.Point(12, 76);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(75, 23);
            this.ColorButton.TabIndex = 2;
            this.ColorButton.Text = "Color";
            this.ColorButton.UseVisualStyleBackColor = true;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // ShapeButton
            // 
            this.ShapeButton.Location = new System.Drawing.Point(12, 105);
            this.ShapeButton.Name = "ShapeButton";
            this.ShapeButton.Size = new System.Drawing.Size(75, 23);
            this.ShapeButton.TabIndex = 3;
            this.ShapeButton.Text = "Shape";
            this.ShapeButton.UseVisualStyleBackColor = true;
            this.ShapeButton.Click += new System.EventHandler(this.ShapeButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 146);
            this.Controls.Add(this.ShapeButton);
            this.Controls.Add(this.ColorButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.STARTbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ICA3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button STARTbutton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Button ShapeButton;
        private System.Windows.Forms.Timer timer1;
    }
}

