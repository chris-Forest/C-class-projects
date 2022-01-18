namespace ica_18EqualsStarter
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
      this._btnPopulate = new System.Windows.Forms.Button();
      this._btnDistinct = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // _btnPopulate
      // 
      this._btnPopulate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._btnPopulate.Location = new System.Drawing.Point(12, 12);
      this._btnPopulate.Name = "_btnPopulate";
      this._btnPopulate.Size = new System.Drawing.Size(267, 45);
      this._btnPopulate.TabIndex = 0;
      this._btnPopulate.Text = "button1";
      this._btnPopulate.UseVisualStyleBackColor = true;
      // 
      // _btnDistinct
      // 
      this._btnDistinct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._btnDistinct.Location = new System.Drawing.Point(12, 75);
      this._btnDistinct.Name = "_btnDistinct";
      this._btnDistinct.Size = new System.Drawing.Size(267, 45);
      this._btnDistinct.TabIndex = 1;
      this._btnDistinct.Text = "button1";
      this._btnDistinct.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(291, 141);
      this.Controls.Add(this._btnDistinct);
      this.Controls.Add(this._btnPopulate);
      this.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button _btnPopulate;
    private System.Windows.Forms.Button _btnDistinct;
  }
}

