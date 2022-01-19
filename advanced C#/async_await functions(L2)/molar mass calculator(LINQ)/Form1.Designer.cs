namespace Chris_Zeek_MMC
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.ColumnATMnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColmSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColmMass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameButton = new System.Windows.Forms.Button();
            this.SymButton = new System.Windows.Forms.Button();
            this.AtomicNumButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChemFormTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MassTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnATMnum,
            this.ColmName,
            this.ColmSymbol,
            this.ColmMass});
            this.DGV.Location = new System.Drawing.Point(13, 13);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(611, 385);
            this.DGV.TabIndex = 0;
            // 
            // ColumnATMnum
            // 
            this.ColumnATMnum.HeaderText = "Atomic Number";
            this.ColumnATMnum.Name = "ColumnATMnum";
            this.ColumnATMnum.ReadOnly = true;
            this.ColumnATMnum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ColmName
            // 
            this.ColmName.HeaderText = "Name";
            this.ColmName.Name = "ColmName";
            this.ColmName.ReadOnly = true;
            // 
            // ColmSymbol
            // 
            this.ColmSymbol.HeaderText = "Symbol";
            this.ColmSymbol.Name = "ColmSymbol";
            this.ColmSymbol.ReadOnly = true;
            // 
            // ColmMass
            // 
            this.ColmMass.HeaderText = "Mass";
            this.ColmMass.Name = "ColmMass";
            this.ColmMass.ReadOnly = true;
            // 
            // NameButton
            // 
            this.NameButton.Location = new System.Drawing.Point(630, 13);
            this.NameButton.Name = "NameButton";
            this.NameButton.Size = new System.Drawing.Size(158, 23);
            this.NameButton.TabIndex = 1;
            this.NameButton.Text = "Sort By Name";
            this.NameButton.UseVisualStyleBackColor = true;
            // 
            // SymButton
            // 
            this.SymButton.Location = new System.Drawing.Point(631, 43);
            this.SymButton.Name = "SymButton";
            this.SymButton.Size = new System.Drawing.Size(157, 23);
            this.SymButton.TabIndex = 2;
            this.SymButton.Text = "Single Character Symbols";
            this.SymButton.UseVisualStyleBackColor = true;
            // 
            // AtomicNumButton
            // 
            this.AtomicNumButton.Location = new System.Drawing.Point(631, 72);
            this.AtomicNumButton.Name = "AtomicNumButton";
            this.AtomicNumButton.Size = new System.Drawing.Size(158, 23);
            this.AtomicNumButton.TabIndex = 3;
            this.AtomicNumButton.Text = "Sort By Atomic #";
            this.AtomicNumButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chemical Formula:";
            // 
            // ChemFormTextBox
            // 
            this.ChemFormTextBox.Location = new System.Drawing.Point(111, 415);
            this.ChemFormTextBox.Name = "ChemFormTextBox";
            this.ChemFormTextBox.Size = new System.Drawing.Size(336, 20);
            this.ChemFormTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Aprorox. Molar Mass";
            // 
            // MassTextBox
            // 
            this.MassTextBox.Location = new System.Drawing.Point(628, 415);
            this.MassTextBox.Name = "MassTextBox";
            this.MassTextBox.ReadOnly = true;
            this.MassTextBox.Size = new System.Drawing.Size(152, 20);
            this.MassTextBox.TabIndex = 7;
            this.MassTextBox.Text = "0";
            this.MassTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MassTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChemFormTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AtomicNumButton);
            this.Controls.Add(this.SymButton);
            this.Controls.Add(this.NameButton);
            this.Controls.Add(this.DGV);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button NameButton;
        private System.Windows.Forms.Button SymButton;
        private System.Windows.Forms.Button AtomicNumButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ChemFormTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MassTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnATMnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColmSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColmMass;
    }
}

