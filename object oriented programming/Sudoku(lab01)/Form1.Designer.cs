namespace Sudoku_lab01_
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._loadPuzMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._solvePuzzleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._SudokuGridView = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SudokuGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._loadPuzMenuItem,
            this._solvePuzzleMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(545, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _loadPuzMenuItem
            // 
            this._loadPuzMenuItem.Name = "_loadPuzMenuItem";
            this._loadPuzMenuItem.Size = new System.Drawing.Size(81, 20);
            this._loadPuzMenuItem.Text = "Load Puzzle";
            // 
            // _solvePuzzleMenuItem
            // 
            this._solvePuzzleMenuItem.Name = "_solvePuzzleMenuItem";
            this._solvePuzzleMenuItem.Size = new System.Drawing.Size(83, 20);
            this._solvePuzzleMenuItem.Text = "Solve Puzzle";
            // 
            // _SudokuGridView
            // 
            this._SudokuGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._SudokuGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._SudokuGridView.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._SudokuGridView.Location = new System.Drawing.Point(9, 27);
            this._SudokuGridView.Name = "_SudokuGridView";
            this._SudokuGridView.Size = new System.Drawing.Size(524, 503);
            this._SudokuGridView.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(545, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _toolStripStatus
            // 
            this._toolStripStatus.Name = "_toolStripStatus";
            this._toolStripStatus.Size = new System.Drawing.Size(88, 17);
            this._toolStripStatus.Text = "Loaded Puzzle: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 558);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._SudokuGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SudokuGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _loadPuzMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _solvePuzzleMenuItem;
        private System.Windows.Forms.DataGridView _SudokuGridView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _toolStripStatus;
    }
}

