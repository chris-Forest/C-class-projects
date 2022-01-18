namespace Chris_lab2
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
            this.start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rstButton = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.intervalUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boomTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.missilesUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.labelmissIN = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.labelDestroyed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFriend = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelKD = new System.Windows.Forms.Label();
            this.labelBommVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.intervalUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boomTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missilesUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(12, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(135, 23);
            this.start.TabIndex = 0;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            // 
            // rstButton
            // 
            this.rstButton.Location = new System.Drawing.Point(12, 42);
            this.rstButton.Name = "rstButton";
            this.rstButton.Size = new System.Drawing.Size(135, 23);
            this.rstButton.TabIndex = 1;
            this.rstButton.Text = "reset";
            this.rstButton.UseVisualStyleBackColor = true;
            this.rstButton.Click += new System.EventHandler(this.reset_click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(12, 72);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(135, 23);
            this.pauseBtn.TabIndex = 2;
            this.pauseBtn.Text = "pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pause_click);
            // 
            // intervalUpDown
            // 
            this.intervalUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.intervalUpDown.Location = new System.Drawing.Point(287, 97);
            this.intervalUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.intervalUpDown.Name = "intervalUpDown";
            this.intervalUpDown.Size = new System.Drawing.Size(44, 20);
            this.intervalUpDown.TabIndex = 3;
            this.intervalUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "interval";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "boom radius";
            // 
            // boomTrackBar
            // 
            this.boomTrackBar.Location = new System.Drawing.Point(153, 20);
            this.boomTrackBar.Maximum = 100;
            this.boomTrackBar.Name = "boomTrackBar";
            this.boomTrackBar.Size = new System.Drawing.Size(178, 45);
            this.boomTrackBar.TabIndex = 6;
            this.boomTrackBar.TickFrequency = 10;
            this.boomTrackBar.Value = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "# of incoming missiles ";
            // 
            // missilesUpDown
            // 
            this.missilesUpDown.Location = new System.Drawing.Point(287, 71);
            this.missilesUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.missilesUpDown.Name = "missilesUpDown";
            this.missilesUpDown.Size = new System.Drawing.Size(44, 20);
            this.missilesUpDown.TabIndex = 8;
            this.missilesUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "enemy missiles launched";
            // 
            // labelmissIN
            // 
            this.labelmissIN.AutoSize = true;
            this.labelmissIN.Location = new System.Drawing.Point(134, 104);
            this.labelmissIN.Name = "labelmissIN";
            this.labelmissIN.Size = new System.Drawing.Size(13, 13);
            this.labelmissIN.TabIndex = 10;
            this.labelmissIN.Text = "0";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(9, 129);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(91, 13);
            this.label.TabIndex = 11;
            this.label.Text = "missiles destroyed";
            // 
            // labelDestroyed
            // 
            this.labelDestroyed.AutoSize = true;
            this.labelDestroyed.Location = new System.Drawing.Point(134, 129);
            this.labelDestroyed.Name = "labelDestroyed";
            this.labelDestroyed.Size = new System.Drawing.Size(13, 13);
            this.labelDestroyed.TabIndex = 12;
            this.labelDestroyed.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "friendly missiles launched";
            // 
            // labelFriend
            // 
            this.labelFriend.AutoSize = true;
            this.labelFriend.Location = new System.Drawing.Point(134, 155);
            this.labelFriend.Name = "labelFriend";
            this.labelFriend.Size = new System.Drawing.Size(13, 13);
            this.labelFriend.TabIndex = 14;
            this.labelFriend.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "K/D";
            // 
            // labelKD
            // 
            this.labelKD.AutoSize = true;
            this.labelKD.Location = new System.Drawing.Point(134, 180);
            this.labelKD.Name = "labelKD";
            this.labelKD.Size = new System.Drawing.Size(13, 13);
            this.labelKD.TabIndex = 16;
            this.labelKD.Text = "0";
            // 
            // labelBommVal
            // 
            this.labelBommVal.AutoSize = true;
            this.labelBommVal.Location = new System.Drawing.Point(254, 4);
            this.labelBommVal.Name = "labelBommVal";
            this.labelBommVal.Size = new System.Drawing.Size(13, 13);
            this.labelBommVal.TabIndex = 17;
            this.labelBommVal.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 247);
            this.Controls.Add(this.labelBommVal);
            this.Controls.Add(this.labelKD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelFriend);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelDestroyed);
            this.Controls.Add(this.label);
            this.Controls.Add(this.labelmissIN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.missilesUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boomTrackBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intervalUpDown);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.rstButton);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.intervalUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boomTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missilesUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button rstButton;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.NumericUpDown intervalUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar boomTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown missilesUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelmissIN;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelDestroyed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelFriend;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelKD;
        private System.Windows.Forms.Label labelBommVal;
    }
}

