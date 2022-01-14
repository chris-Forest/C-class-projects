namespace lab4
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
            this.StartButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.EndBtn = new System.Windows.Forms.Button();
            this.SpeedCheckBox = new System.Windows.Forms.CheckBox();
            this.score = new System.Windows.Forms.Label();
            this.listViewBoard = new System.Windows.Forms.ListView();
            this.Player = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HighScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.SPLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(13, 13);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start Game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(12, 51);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(75, 23);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // EndBtn
            // 
            this.EndBtn.Location = new System.Drawing.Point(12, 89);
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Size = new System.Drawing.Size(75, 23);
            this.EndBtn.TabIndex = 2;
            this.EndBtn.Text = "End Game";
            this.EndBtn.UseVisualStyleBackColor = true;
            this.EndBtn.Click += new System.EventHandler(this.EndBtn_Click);
            // 
            // SpeedCheckBox
            // 
            this.SpeedCheckBox.AutoSize = true;
            this.SpeedCheckBox.Location = new System.Drawing.Point(13, 139);
            this.SpeedCheckBox.Name = "SpeedCheckBox";
            this.SpeedCheckBox.Size = new System.Drawing.Size(120, 17);
            this.SpeedCheckBox.TabIndex = 3;
            this.SpeedCheckBox.Text = "Show Speed Dialog";
            this.SpeedCheckBox.UseVisualStyleBackColor = true;
            this.SpeedCheckBox.CheckedChanged += new System.EventHandler(this.SpeedCheckBox_CheckedChanged);
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.Location = new System.Drawing.Point(120, 23);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(68, 73);
            this.score.TabIndex = 4;
            this.score.Text = "0";
            // 
            // listViewBoard
            // 
            this.listViewBoard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Player,
            this.level,
            this.HighScore});
            this.listViewBoard.HideSelection = false;
            this.listViewBoard.Location = new System.Drawing.Point(229, 13);
            this.listViewBoard.Name = "listViewBoard";
            this.listViewBoard.Size = new System.Drawing.Size(265, 224);
            this.listViewBoard.TabIndex = 5;
            this.listViewBoard.UseCompatibleStateImageBehavior = false;
            this.listViewBoard.View = System.Windows.Forms.View.Details;
            // 
            // Player
            // 
            this.Player.Text = "Player";
            this.Player.Width = 96;
            // 
            // level
            // 
            this.level.Text = "Level";
            // 
            // HighScore
            // 
            this.HighScore.Text = "Score";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(13, 163);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(41, 13);
            this.SpeedLabel.TabIndex = 6;
            this.SpeedLabel.Text = "Speed:";
            // 
            // SPLabel
            // 
            this.SPLabel.AutoSize = true;
            this.SPLabel.Location = new System.Drawing.Point(61, 163);
            this.SPLabel.Name = "SPLabel";
            this.SPLabel.Size = new System.Drawing.Size(19, 13);
            this.SPLabel.TabIndex = 7;
            this.SPLabel.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 259);
            this.Controls.Add(this.SPLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.listViewBoard);
            this.Controls.Add(this.score);
            this.Controls.Add(this.SpeedCheckBox);
            this.Controls.Add(this.EndBtn);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.StartButton);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button EndBtn;
        private System.Windows.Forms.CheckBox SpeedCheckBox;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.ListView listViewBoard;
        private System.Windows.Forms.ColumnHeader Player;
        private System.Windows.Forms.ColumnHeader level;
        private System.Windows.Forms.ColumnHeader HighScore;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label SPLabel;
    }
}

