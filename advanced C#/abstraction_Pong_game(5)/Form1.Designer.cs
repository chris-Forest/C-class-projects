
namespace ChrisF_Pong
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
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._rbMouse1 = new System.Windows.Forms.RadioButton();
            this._rbWASD = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._rbMouse2 = new System.Windows.Forms.RadioButton();
            this.ArrowKeys = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(326, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(200, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "player 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(426, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Player 2";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(334, 212);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(90, 40);
            this.startBtn.TabIndex = 5;
            this.startBtn.Text = "start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._rbMouse1);
            this.groupBox1.Controls.Add(this._rbWASD);
            this.groupBox1.Location = new System.Drawing.Point(205, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 86);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "controls";
            // 
            // _rbMouse1
            // 
            this._rbMouse1.AutoSize = true;
            this._rbMouse1.Location = new System.Drawing.Point(7, 44);
            this._rbMouse1.Name = "_rbMouse1";
            this._rbMouse1.Size = new System.Drawing.Size(57, 17);
            this._rbMouse1.TabIndex = 1;
            this._rbMouse1.TabStop = true;
            this._rbMouse1.Text = "Mouse";
            this._rbMouse1.UseVisualStyleBackColor = true;
            this._rbMouse1.CheckedChanged += new System.EventHandler(this._rbMouse1_CheckedChanged);
            // 
            // _rbWASD
            // 
            this._rbWASD.AutoSize = true;
            this._rbWASD.Location = new System.Drawing.Point(7, 20);
            this._rbWASD.Name = "_rbWASD";
            this._rbWASD.Size = new System.Drawing.Size(58, 17);
            this._rbWASD.TabIndex = 0;
            this._rbWASD.TabStop = true;
            this._rbWASD.Text = "WASD";
            this._rbWASD.UseVisualStyleBackColor = true;
            this._rbWASD.CheckedChanged += new System.EventHandler(this._rbWASD_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._rbMouse2);
            this.groupBox2.Controls.Add(this.ArrowKeys);
            this.groupBox2.Location = new System.Drawing.Point(431, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 86);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "controls";
            // 
            // _rbMouse2
            // 
            this._rbMouse2.AutoSize = true;
            this._rbMouse2.Location = new System.Drawing.Point(7, 44);
            this._rbMouse2.Name = "_rbMouse2";
            this._rbMouse2.Size = new System.Drawing.Size(57, 17);
            this._rbMouse2.TabIndex = 1;
            this._rbMouse2.TabStop = true;
            this._rbMouse2.Text = "Mouse";
            this._rbMouse2.UseVisualStyleBackColor = true;
            this._rbMouse2.CheckedChanged += new System.EventHandler(this._rbMouse2_CheckedChanged);
            // 
            // ArrowKeys
            // 
            this.ArrowKeys.AutoSize = true;
            this.ArrowKeys.Location = new System.Drawing.Point(7, 20);
            this.ArrowKeys.Name = "ArrowKeys";
            this.ArrowKeys.Size = new System.Drawing.Size(57, 17);
            this.ArrowKeys.TabIndex = 0;
            this.ArrowKeys.TabStop = true;
            this.ArrowKeys.Text = "Arrows";
            this.ArrowKeys.UseVisualStyleBackColor = true;
            this.ArrowKeys.CheckedChanged += new System.EventHandler(this.ArrowKeys_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton _rbMouse1;
        private System.Windows.Forms.RadioButton _rbWASD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton _rbMouse2;
        private System.Windows.Forms.RadioButton ArrowKeys;
    }
}

