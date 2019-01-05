namespace SimpleMineSweeper
{
    partial class NewGamePrompt
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
            this.beginGameButton = new System.Windows.Forms.Button();
            this.gameSizeBar = new System.Windows.Forms.TrackBar();
            this.gameSizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameSizeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // beginGameButton
            // 
            this.beginGameButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.beginGameButton.Location = new System.Drawing.Point(139, 114);
            this.beginGameButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.beginGameButton.Name = "beginGameButton";
            this.beginGameButton.Size = new System.Drawing.Size(64, 31);
            this.beginGameButton.TabIndex = 3;
            this.beginGameButton.Text = "OK";
            this.beginGameButton.UseVisualStyleBackColor = true;
            this.beginGameButton.Click += new System.EventHandler(this.BeginGameButton_Click);
            // 
            // gameSizeBar
            // 
            this.gameSizeBar.Location = new System.Drawing.Point(9, 34);
            this.gameSizeBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gameSizeBar.Name = "gameSizeBar";
            this.gameSizeBar.Size = new System.Drawing.Size(325, 45);
            this.gameSizeBar.TabIndex = 4;
            this.gameSizeBar.Value = 1;
            // 
            // gameSizeLabel
            // 
            this.gameSizeLabel.AutoSize = true;
            this.gameSizeLabel.Location = new System.Drawing.Point(10, 11);
            this.gameSizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gameSizeLabel.Name = "gameSizeLabel";
            this.gameSizeLabel.Size = new System.Drawing.Size(103, 13);
            this.gameSizeLabel.TabIndex = 5;
            this.gameSizeLabel.Text = "Select Size of Game";
            // 
            // NewGamePrompt
            // 
            this.AcceptButton = this.beginGameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 154);
            this.Controls.Add(this.gameSizeLabel);
            this.Controls.Add(this.gameSizeBar);
            this.Controls.Add(this.beginGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGamePrompt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Game Prompt";
            ((System.ComponentModel.ISupportInitialize)(this.gameSizeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button beginGameButton;
        private System.Windows.Forms.TrackBar gameSizeBar;
        private System.Windows.Forms.Label gameSizeLabel;
    }
}