namespace lab3
{
    partial class Ballz
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
            this.label1 = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.ANIMEcheckBox = new System.Windows.Forms.CheckBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.LeaderBoard = new System.Windows.Forms.ListView();
            this.Player = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Score = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Difficulty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Score";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(101, 20);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(35, 38);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "0";
            // 
            // ANIMEcheckBox
            // 
            this.ANIMEcheckBox.AutoSize = true;
            this.ANIMEcheckBox.Location = new System.Drawing.Point(12, 288);
            this.ANIMEcheckBox.Name = "ANIMEcheckBox";
            this.ANIMEcheckBox.Size = new System.Drawing.Size(136, 17);
            this.ANIMEcheckBox.TabIndex = 2;
            this.ANIMEcheckBox.Text = "Show Animation Speed";
            this.ANIMEcheckBox.UseVisualStyleBackColor = true;
            this.ANIMEcheckBox.CheckedChanged += new System.EventHandler(this.ANIMEcheckBox_CheckedChanged);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(12, 157);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 3;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // LeaderBoard
            // 
            this.LeaderBoard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Player,
            this.Score,
            this.Difficulty});
            this.LeaderBoard.HideSelection = false;
            this.LeaderBoard.Location = new System.Drawing.Point(218, 29);
            this.LeaderBoard.Name = "LeaderBoard";
            this.LeaderBoard.Size = new System.Drawing.Size(285, 276);
            this.LeaderBoard.TabIndex = 4;
            this.LeaderBoard.UseCompatibleStateImageBehavior = false;
            this.LeaderBoard.View = System.Windows.Forms.View.Details;
            // 
            // Player
            // 
            this.Player.Text = "Player";
            this.Player.Width = 89;
            // 
            // Score
            // 
            this.Score.Text = "Score";
            this.Score.Width = 80;
            // 
            // Difficulty
            // 
            this.Difficulty.Text = "Difficulty";
            this.Difficulty.Width = 62;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(154, 288);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(19, 13);
            this.SpeedLabel.TabIndex = 5;
            this.SpeedLabel.Text = "10";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.delete);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 67);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(14, 32);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 0;
            this.delete.Text = "delete Score";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // Ballz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 321);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.LeaderBoard);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.ANIMEcheckBox);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.label1);
            this.Name = "Ballz";
            this.Text = "Ballz";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.CheckBox ANIMEcheckBox;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.ListView LeaderBoard;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader Player;
        private System.Windows.Forms.ColumnHeader Score;
        private System.Windows.Forms.ColumnHeader Difficulty;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button delete;
    }
}

