namespace chris_lab3
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_play = new System.Windows.Forms.Button();
            this.numUpDownCol = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCol)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            // 
            // button_play
            // 
            this.button_play.Location = new System.Drawing.Point(13, 13);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(436, 205);
            this.button_play.TabIndex = 0;
            this.button_play.Text = "play";
            this.button_play.UseVisualStyleBackColor = true;
            // 
            // numUpDownCol
            // 
            this.numUpDownCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDownCol.Location = new System.Drawing.Point(13, 225);
            this.numUpDownCol.Name = "numUpDownCol";
            this.numUpDownCol.Size = new System.Drawing.Size(436, 31);
            this.numUpDownCol.TabIndex = 1;
            this.numUpDownCol.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 420);
            this.Controls.Add(this.numUpDownCol);
            this.Controls.Add(this.button_play);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.NumericUpDown numUpDownCol;
    }
}

