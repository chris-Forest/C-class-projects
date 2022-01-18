namespace ica13_HashsetProfile
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
      this._btnPopSeq = new System.Windows.Forms.Button();
      this._btnPop1 = new System.Windows.Forms.Button();
      this._btnPop2 = new System.Windows.Forms.Button();
      this._btnPop3 = new System.Windows.Forms.Button();
      this._btnPop0 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // _btnPopSeq
      // 
      this._btnPopSeq.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._btnPopSeq.Location = new System.Drawing.Point(12, 12);
      this._btnPopSeq.Name = "_btnPopSeq";
      this._btnPopSeq.Size = new System.Drawing.Size(266, 36);
      this._btnPopSeq.TabIndex = 0;
      this._btnPopSeq.Text = "Populate Sequential";
      this._btnPopSeq.UseVisualStyleBackColor = true;
      // 
      // _btnPop1
      // 
      this._btnPop1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._btnPop1.Location = new System.Drawing.Point(12, 96);
      this._btnPop1.Name = "_btnPop1";
      this._btnPop1.Size = new System.Drawing.Size(266, 36);
      this._btnPop1.TabIndex = 1;
      this._btnPop1.Text = "Populate MultHash";
      this._btnPop1.UseVisualStyleBackColor = true;
      // 
      // _btnPop2
      // 
      this._btnPop2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._btnPop2.Location = new System.Drawing.Point(12, 138);
      this._btnPop2.Name = "_btnPop2";
      this._btnPop2.Size = new System.Drawing.Size(266, 36);
      this._btnPop2.TabIndex = 2;
      this._btnPop2.Text = "Populate AddHash";
      this._btnPop2.UseVisualStyleBackColor = true;
      // 
      // _btnPop3
      // 
      this._btnPop3.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._btnPop3.Location = new System.Drawing.Point(12, 180);
      this._btnPop3.Name = "_btnPop3";
      this._btnPop3.Size = new System.Drawing.Size(266, 36);
      this._btnPop3.TabIndex = 3;
      this._btnPop3.Text = "Populate FixedHash";
      this._btnPop3.UseVisualStyleBackColor = true;
      // 
      // _btnPop0
      // 
      this._btnPop0.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._btnPop0.Location = new System.Drawing.Point(12, 54);
      this._btnPop0.Name = "_btnPop0";
      this._btnPop0.Size = new System.Drawing.Size(266, 36);
      this._btnPop0.TabIndex = 4;
      this._btnPop0.Text = "Populate OffsetHash ";
      this._btnPop0.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(290, 243);
      this.Controls.Add(this._btnPop0);
      this.Controls.Add(this._btnPop3);
      this.Controls.Add(this._btnPop2);
      this.Controls.Add(this._btnPop1);
      this.Controls.Add(this._btnPopSeq);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button _btnPopSeq;
    private System.Windows.Forms.Button _btnPop1;
    private System.Windows.Forms.Button _btnPop2;
    private System.Windows.Forms.Button _btnPop3;
    private System.Windows.Forms.Button _btnPop0;
  }
}

