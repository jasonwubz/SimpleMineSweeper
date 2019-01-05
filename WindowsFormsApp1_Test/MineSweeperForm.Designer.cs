namespace SimpleMineSweeper
{
    partial class MineSweeperForm
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
            this.MineFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.newGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameInfoLabel = new System.Windows.Forms.Label();
            this.newGameMiniButton = new System.Windows.Forms.Button();
            this.timeElapsedTextBox = new System.Windows.Forms.TextBox();
            this.flagCountLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MineFlowPanel
            // 
            this.MineFlowPanel.Location = new System.Drawing.Point(8, 61);
            this.MineFlowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MineFlowPanel.Name = "MineFlowPanel";
            this.MineFlowPanel.Size = new System.Drawing.Size(8, 8);
            this.MineFlowPanel.TabIndex = 6;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(388, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip";
            // 
            // newGameMenuItem
            // 
            this.newGameMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.newGameMenuItem.Name = "newGameMenuItem";
            this.newGameMenuItem.Size = new System.Drawing.Size(37, 20);
            this.newGameMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.NewGameToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // gameInfoLabel
            // 
            this.gameInfoLabel.AutoSize = true;
            this.gameInfoLabel.Location = new System.Drawing.Point(110, 24);
            this.gameInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gameInfoLabel.Name = "gameInfoLabel";
            this.gameInfoLabel.Size = new System.Drawing.Size(170, 13);
            this.gameInfoLabel.TabIndex = 8;
            this.gameInfoLabel.Text = "Select \'File -> New Game\' to Begin";
            // 
            // newGameMiniButton
            // 
            this.newGameMiniButton.BackColor = System.Drawing.Color.White;
            this.newGameMiniButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newGameMiniButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameMiniButton.ForeColor = System.Drawing.Color.Teal;
            this.newGameMiniButton.Location = new System.Drawing.Point(9, 24);
            this.newGameMiniButton.Margin = new System.Windows.Forms.Padding(2);
            this.newGameMiniButton.Name = "newGameMiniButton";
            this.newGameMiniButton.Size = new System.Drawing.Size(22, 24);
            this.newGameMiniButton.TabIndex = 0;
            this.newGameMiniButton.TabStop = false;
            this.newGameMiniButton.Text = "r";
            this.newGameMiniButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newGameMiniButton.UseVisualStyleBackColor = false;
            this.newGameMiniButton.Click += new System.EventHandler(this.NewGameMiniButton_Click);
            // 
            // timeElapsedTextBox
            // 
            this.timeElapsedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeElapsedTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.timeElapsedTextBox.Location = new System.Drawing.Point(302, 24);
            this.timeElapsedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.timeElapsedTextBox.Name = "timeElapsedTextBox";
            this.timeElapsedTextBox.ReadOnly = true;
            this.timeElapsedTextBox.Size = new System.Drawing.Size(70, 13);
            this.timeElapsedTextBox.TabIndex = 0;
            this.timeElapsedTextBox.TabStop = false;
            this.timeElapsedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flagCountLabel
            // 
            this.flagCountLabel.AutoSize = true;
            this.flagCountLabel.Location = new System.Drawing.Point(36, 24);
            this.flagCountLabel.Name = "flagCountLabel";
            this.flagCountLabel.Size = new System.Drawing.Size(0, 13);
            this.flagCountLabel.TabIndex = 9;
            this.flagCountLabel.UseMnemonic = false;
            // 
            // MineSweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 80);
            this.Controls.Add(this.flagCountLabel);
            this.Controls.Add(this.timeElapsedTextBox);
            this.Controls.Add(this.newGameMiniButton);
            this.Controls.Add(this.gameInfoLabel);
            this.Controls.Add(this.MineFlowPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MineSweeperForm";
            this.Text = "Mine Sweeper";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel MineFlowPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.Label gameInfoLabel;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button newGameMiniButton;
        private System.Windows.Forms.TextBox timeElapsedTextBox;
        private System.Windows.Forms.Label flagCountLabel;
    }
}

