namespace chris_async_lab02
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
            this.label1 = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FindStocksButton = new System.Windows.Forms.Button();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DGV_Filter = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddStockButton = new System.Windows.Forms.Button();
            this.HottestTipButton = new System.Windows.Forms.Button();
            this.NewTipButton = new System.Windows.Forms.Button();
            this.SelectedTipButton = new System.Windows.Forms.Button();
            this.addTipTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DGV_Tips = new System.Windows.Forms.DataGridView();
            this.statusLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Filter)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Tips)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(13, 33);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(174, 20);
            this.UsernameTextBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FindStocksButton);
            this.groupBox1.Controls.Add(this.FilterTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 166);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stocks";
            // 
            // FindStocksButton
            // 
            this.FindStocksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindStocksButton.Location = new System.Drawing.Point(7, 81);
            this.FindStocksButton.Name = "FindStocksButton";
            this.FindStocksButton.Size = new System.Drawing.Size(161, 65);
            this.FindStocksButton.TabIndex = 4;
            this.FindStocksButton.Text = "Find Stocks";
            this.FindStocksButton.UseVisualStyleBackColor = true;
            this.FindStocksButton.Click += new System.EventHandler(this.FindStocks_Click);
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Location = new System.Drawing.Point(6, 35);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(162, 20);
            this.FilterTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filter:";
            // 
            // DGV_Filter
            // 
            this.DGV_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Filter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Filter.Location = new System.Drawing.Point(194, 13);
            this.DGV_Filter.Name = "DGV_Filter";
            this.DGV_Filter.RowHeadersVisible = false;
            this.DGV_Filter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Filter.Size = new System.Drawing.Size(723, 272);
            this.DGV_Filter.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.AddStockButton);
            this.groupBox2.Controls.Add(this.HottestTipButton);
            this.groupBox2.Controls.Add(this.NewTipButton);
            this.groupBox2.Controls.Add(this.SelectedTipButton);
            this.groupBox2.Controls.Add(this.addTipTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(18, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 82);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tips";
            // 
            // AddStockButton
            // 
            this.AddStockButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddStockButton.Location = new System.Drawing.Point(550, 38);
            this.AddStockButton.Name = "AddStockButton";
            this.AddStockButton.Size = new System.Drawing.Size(340, 23);
            this.AddStockButton.TabIndex = 9;
            this.AddStockButton.Text = "Add Stock Tip";
            this.AddStockButton.UseVisualStyleBackColor = true;
            // 
            // HottestTipButton
            // 
            this.HottestTipButton.Location = new System.Drawing.Point(349, 38);
            this.HottestTipButton.Name = "HottestTipButton";
            this.HottestTipButton.Size = new System.Drawing.Size(195, 23);
            this.HottestTipButton.TabIndex = 8;
            this.HottestTipButton.Text = "Hottest Tips";
            this.HottestTipButton.UseVisualStyleBackColor = true;
            // 
            // NewTipButton
            // 
            this.NewTipButton.Location = new System.Drawing.Point(173, 38);
            this.NewTipButton.Name = "NewTipButton";
            this.NewTipButton.Size = new System.Drawing.Size(170, 23);
            this.NewTipButton.TabIndex = 7;
            this.NewTipButton.Text = "Newest Tips";
            this.NewTipButton.UseVisualStyleBackColor = true;
            // 
            // SelectedTipButton
            // 
            this.SelectedTipButton.Location = new System.Drawing.Point(7, 38);
            this.SelectedTipButton.Name = "SelectedTipButton";
            this.SelectedTipButton.Size = new System.Drawing.Size(159, 23);
            this.SelectedTipButton.TabIndex = 6;
            this.SelectedTipButton.Text = "Selected Tip";
            this.SelectedTipButton.UseVisualStyleBackColor = true;
            // 
            // addTipTextBox
            // 
            this.addTipTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addTipTextBox.Location = new System.Drawing.Point(136, 11);
            this.addTipTextBox.Name = "addTipTextBox";
            this.addTipTextBox.Size = new System.Drawing.Size(754, 20);
            this.addTipTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hot Stock Tip:";
            // 
            // DGV_Tips
            // 
            this.DGV_Tips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Tips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Tips.Location = new System.Drawing.Point(18, 385);
            this.DGV_Tips.Name = "DGV_Tips";
            this.DGV_Tips.RowHeadersVisible = false;
            this.DGV_Tips.Size = new System.Drawing.Size(896, 141);
            this.DGV_Tips.TabIndex = 5;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(21, 533);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(48, 18);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 561);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.DGV_Tips);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DGV_Filter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Stonks";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Filter)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Tips)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button FindStocksButton;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV_Filter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AddStockButton;
        private System.Windows.Forms.Button HottestTipButton;
        private System.Windows.Forms.Button NewTipButton;
        private System.Windows.Forms.Button SelectedTipButton;
        private System.Windows.Forms.TextBox addTipTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGV_Tips;
        private System.Windows.Forms.Label statusLabel;
    }
}

