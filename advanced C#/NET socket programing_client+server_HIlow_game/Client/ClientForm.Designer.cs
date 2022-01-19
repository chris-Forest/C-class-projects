
namespace Client
{
    partial class ClientForm
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
            this.AdressBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectionButton = new System.Windows.Forms.Button();
            this.TrackBarGuess = new System.Windows.Forms.TrackBar();
            this.L_min = new System.Windows.Forms.Label();
            this.GuessValLabel = new System.Windows.Forms.Label();
            this.L_High = new System.Windows.Forms.Label();
            this.GuessButton = new System.Windows.Forms.Button();
            this.ListBoxStatus = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarGuess)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adress:";
            // 
            // AdressBox
            // 
            this.AdressBox.Location = new System.Drawing.Point(103, 17);
            this.AdressBox.Name = "AdressBox";
            this.AdressBox.Size = new System.Drawing.Size(175, 20);
            this.AdressBox.TabIndex = 1;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(374, 20);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(143, 20);
            this.PortTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(311, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // ConnectionButton
            // 
            this.ConnectionButton.Location = new System.Drawing.Point(606, 20);
            this.ConnectionButton.Name = "ConnectionButton";
            this.ConnectionButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectionButton.TabIndex = 5;
            this.ConnectionButton.Text = "Connect";
            this.ConnectionButton.UseVisualStyleBackColor = true;
            // 
            // TrackBarGuess
            // 
            this.TrackBarGuess.Location = new System.Drawing.Point(18, 117);
            this.TrackBarGuess.Maximum = 1000;
            this.TrackBarGuess.Name = "TrackBarGuess";
            this.TrackBarGuess.Size = new System.Drawing.Size(786, 45);
            this.TrackBarGuess.TabIndex = 6;
            this.TrackBarGuess.Value = 500;
            // 
            // L_min
            // 
            this.L_min.AutoSize = true;
            this.L_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_min.Location = new System.Drawing.Point(13, 89);
            this.L_min.Name = "L_min";
            this.L_min.Size = new System.Drawing.Size(24, 25);
            this.L_min.TabIndex = 7;
            this.L_min.Text = "0";
            // 
            // GuessValLabel
            // 
            this.GuessValLabel.AutoSize = true;
            this.GuessValLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuessValLabel.Location = new System.Drawing.Point(384, 89);
            this.GuessValLabel.Name = "GuessValLabel";
            this.GuessValLabel.Size = new System.Drawing.Size(48, 25);
            this.GuessValLabel.TabIndex = 8;
            this.GuessValLabel.Text = "500";
            // 
            // L_High
            // 
            this.L_High.AutoSize = true;
            this.L_High.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_High.Location = new System.Drawing.Point(723, 89);
            this.L_High.Name = "L_High";
            this.L_High.Size = new System.Drawing.Size(60, 25);
            this.L_High.TabIndex = 9;
            this.L_High.Text = "1000";
            // 
            // GuessButton
            // 
            this.GuessButton.Location = new System.Drawing.Point(18, 168);
            this.GuessButton.Name = "GuessButton";
            this.GuessButton.Size = new System.Drawing.Size(786, 43);
            this.GuessButton.TabIndex = 10;
            this.GuessButton.Text = "Guess";
            this.GuessButton.UseVisualStyleBackColor = true;
            // 
            // ListBoxStatus
            // 
            this.ListBoxStatus.FormattingEnabled = true;
            this.ListBoxStatus.Location = new System.Drawing.Point(18, 218);
            this.ListBoxStatus.Name = "ListBoxStatus";
            this.ListBoxStatus.Size = new System.Drawing.Size(786, 199);
            this.ListBoxStatus.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(816, 433);
            this.Controls.Add(this.ListBoxStatus);
            this.Controls.Add(this.GuessButton);
            this.Controls.Add(this.L_High);
            this.Controls.Add(this.GuessValLabel);
            this.Controls.Add(this.L_min);
            this.Controls.Add(this.TrackBarGuess);
            this.Controls.Add(this.ConnectionButton);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AdressBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarGuess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AdressBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConnectionButton;
        private System.Windows.Forms.TrackBar TrackBarGuess;
        private System.Windows.Forms.Label L_min;
        private System.Windows.Forms.Label GuessValLabel;
        private System.Windows.Forms.Label L_High;
        private System.Windows.Forms.Button GuessButton;
        private System.Windows.Forms.ListBox ListBoxStatus;
    }
}

