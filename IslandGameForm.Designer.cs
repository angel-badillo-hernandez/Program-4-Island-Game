namespace program4
{
    partial class IslandGameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.InfoButton = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.EnterRowsLabel = new System.Windows.Forms.Label();
            this.EnterColumnsLabel = new System.Windows.Forms.Label();
            this.EnterRowsTextBox = new System.Windows.Forms.TextBox();
            this.EnterColumnsTextBox = new System.Windows.Forms.TextBox();
            this.MapSizeLabel = new System.Windows.Forms.Label();
            this.MapLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.MapCreateGroupBox = new System.Windows.Forms.GroupBox();
            this.MapGroupBox = new System.Windows.Forms.GroupBox();
            this.GuessCountLabel = new System.Windows.Forms.Label();
            this.GuessGroupBox = new System.Windows.Forms.GroupBox();
            this.EnterILabel = new System.Windows.Forms.Label();
            this.EnterJLabel = new System.Windows.Forms.Label();
            this.EnterITextBox = new System.Windows.Forms.TextBox();
            this.EnterJTextBox = new System.Windows.Forms.TextBox();
            this.GuessButton = new System.Windows.Forms.Button();
            this.MapCreateGroupBox.SuspendLayout();
            this.MapGroupBox.SuspendLayout();
            this.GuessGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.Location = new System.Drawing.Point(201, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(348, 27);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Find the Tropical Island";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoButton
            // 
            this.InfoButton.Location = new System.Drawing.Point(555, 9);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(52, 30);
            this.InfoButton.TabIndex = 1;
            this.InfoButton.Text = "HELP";
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // EnterRowsLabel
            // 
            this.EnterRowsLabel.AutoSize = true;
            this.EnterRowsLabel.Location = new System.Drawing.Point(6, 34);
            this.EnterRowsLabel.Name = "EnterRowsLabel";
            this.EnterRowsLabel.Size = new System.Drawing.Size(133, 15);
            this.EnterRowsLabel.TabIndex = 2;
            this.EnterRowsLabel.Text = "Enter no. of rows:";
            // 
            // EnterColumnsLabel
            // 
            this.EnterColumnsLabel.AutoSize = true;
            this.EnterColumnsLabel.Location = new System.Drawing.Point(6, 65);
            this.EnterColumnsLabel.Name = "EnterColumnsLabel";
            this.EnterColumnsLabel.Size = new System.Drawing.Size(154, 15);
            this.EnterColumnsLabel.TabIndex = 3;
            this.EnterColumnsLabel.Text = "Enter no. of columns:";
            // 
            // EnterRowsTextBox
            // 
            this.EnterRowsTextBox.Location = new System.Drawing.Point(160, 28);
            this.EnterRowsTextBox.Name = "EnterRowsTextBox";
            this.EnterRowsTextBox.Size = new System.Drawing.Size(94, 21);
            this.EnterRowsTextBox.TabIndex = 4;
            // 
            // EnterColumnsTextBox
            // 
            this.EnterColumnsTextBox.Location = new System.Drawing.Point(160, 59);
            this.EnterColumnsTextBox.Name = "EnterColumnsTextBox";
            this.EnterColumnsTextBox.Size = new System.Drawing.Size(94, 21);
            this.EnterColumnsTextBox.TabIndex = 5;
            // 
            // MapSizeLabel
            // 
            this.MapSizeLabel.AutoSize = true;
            this.MapSizeLabel.Location = new System.Drawing.Point(6, 28);
            this.MapSizeLabel.Name = "MapSizeLabel";
            this.MapSizeLabel.Size = new System.Drawing.Size(49, 15);
            this.MapSizeLabel.TabIndex = 6;
            this.MapSizeLabel.Text = "Size: ";
            // 
            // MapLabel
            // 
            this.MapLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MapLabel.AutoSize = true;
            this.MapLabel.Location = new System.Drawing.Point(107, 65);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(28, 15);
            this.MapLabel.TabIndex = 7;
            this.MapLabel.Text = "Map";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(96, 97);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(70, 25);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MapCreateGroupBox
            // 
            this.MapCreateGroupBox.Controls.Add(this.EnterRowsLabel);
            this.MapCreateGroupBox.Controls.Add(this.StartButton);
            this.MapCreateGroupBox.Controls.Add(this.EnterColumnsLabel);
            this.MapCreateGroupBox.Controls.Add(this.EnterRowsTextBox);
            this.MapCreateGroupBox.Controls.Add(this.EnterColumnsTextBox);
            this.MapCreateGroupBox.Location = new System.Drawing.Point(12, 73);
            this.MapCreateGroupBox.Name = "MapCreateGroupBox";
            this.MapCreateGroupBox.Size = new System.Drawing.Size(271, 139);
            this.MapCreateGroupBox.TabIndex = 9;
            this.MapCreateGroupBox.TabStop = false;
            this.MapCreateGroupBox.Text = "Map Creation";
            // 
            // MapGroupBox
            // 
            this.MapGroupBox.Controls.Add(this.GuessCountLabel);
            this.MapGroupBox.Controls.Add(this.MapSizeLabel);
            this.MapGroupBox.Controls.Add(this.MapLabel);
            this.MapGroupBox.Location = new System.Drawing.Point(437, 73);
            this.MapGroupBox.Name = "MapGroupBox";
            this.MapGroupBox.Size = new System.Drawing.Size(316, 257);
            this.MapGroupBox.TabIndex = 10;
            this.MapGroupBox.TabStop = false;
            this.MapGroupBox.Text = "Map";
            // 
            // GuessCountLabel
            // 
            this.GuessCountLabel.AutoSize = true;
            this.GuessCountLabel.Location = new System.Drawing.Point(6, 59);
            this.GuessCountLabel.Name = "GuessCountLabel";
            this.GuessCountLabel.Size = new System.Drawing.Size(63, 15);
            this.GuessCountLabel.TabIndex = 8;
            this.GuessCountLabel.Text = "Guesses:";
            // 
            // GuessGroupBox
            // 
            this.GuessGroupBox.Controls.Add(this.GuessButton);
            this.GuessGroupBox.Controls.Add(this.EnterJTextBox);
            this.GuessGroupBox.Controls.Add(this.EnterITextBox);
            this.GuessGroupBox.Controls.Add(this.EnterJLabel);
            this.GuessGroupBox.Controls.Add(this.EnterILabel);
            this.GuessGroupBox.Location = new System.Drawing.Point(12, 230);
            this.GuessGroupBox.Name = "GuessGroupBox";
            this.GuessGroupBox.Size = new System.Drawing.Size(271, 144);
            this.GuessGroupBox.TabIndex = 11;
            this.GuessGroupBox.TabStop = false;
            this.GuessGroupBox.Text = "Guess";
            // 
            // EnterILabel
            // 
            this.EnterILabel.AutoSize = true;
            this.EnterILabel.Location = new System.Drawing.Point(9, 37);
            this.EnterILabel.Name = "EnterILabel";
            this.EnterILabel.Size = new System.Drawing.Size(105, 15);
            this.EnterILabel.TabIndex = 0;
            this.EnterILabel.Text = "Enter i index:";
            // 
            // EnterJLabel
            // 
            this.EnterJLabel.AutoSize = true;
            this.EnterJLabel.Location = new System.Drawing.Point(9, 67);
            this.EnterJLabel.Name = "EnterJLabel";
            this.EnterJLabel.Size = new System.Drawing.Size(105, 15);
            this.EnterJLabel.TabIndex = 1;
            this.EnterJLabel.Text = "Enter j index:";
            // 
            // EnterITextBox
            // 
            this.EnterITextBox.Enabled = false;
            this.EnterITextBox.Location = new System.Drawing.Point(160, 31);
            this.EnterITextBox.Name = "EnterITextBox";
            this.EnterITextBox.Size = new System.Drawing.Size(94, 21);
            this.EnterITextBox.TabIndex = 9;
            // 
            // EnterJTextBox
            // 
            this.EnterJTextBox.Enabled = false;
            this.EnterJTextBox.Location = new System.Drawing.Point(160, 61);
            this.EnterJTextBox.Name = "EnterJTextBox";
            this.EnterJTextBox.Size = new System.Drawing.Size(94, 21);
            this.EnterJTextBox.TabIndex = 10;
            // 
            // GuessButton
            // 
            this.GuessButton.Enabled = false;
            this.GuessButton.Location = new System.Drawing.Point(91, 103);
            this.GuessButton.Name = "GuessButton";
            this.GuessButton.Size = new System.Drawing.Size(75, 23);
            this.GuessButton.TabIndex = 11;
            this.GuessButton.Text = "GUESS";
            this.GuessButton.UseVisualStyleBackColor = true;
            this.GuessButton.Click += new System.EventHandler(this.GuessButton_Click);
            // 
            // IslandGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GuessGroupBox);
            this.Controls.Add(this.MapGroupBox);
            this.Controls.Add(this.MapCreateGroupBox);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.TitleLabel);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "IslandGameForm";
            this.Text = "Find the Tropical Island";
            this.MapCreateGroupBox.ResumeLayout(false);
            this.MapCreateGroupBox.PerformLayout();
            this.MapGroupBox.ResumeLayout(false);
            this.MapGroupBox.PerformLayout();
            this.GuessGroupBox.ResumeLayout(false);
            this.GuessGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label TitleLabel;
        private Button InfoButton;
        private HelpProvider helpProvider1;
        private Label EnterRowsLabel;
        private Label EnterColumnsLabel;
        private TextBox EnterRowsTextBox;
        private TextBox EnterColumnsTextBox;
        private Label MapSizeLabel;
        private Label MapLabel;
        private Button StartButton;
        private GroupBox MapCreateGroupBox;
        private GroupBox MapGroupBox;
        private Label GuessCountLabel;
        private GroupBox GuessGroupBox;
        private Label EnterJLabel;
        private Label EnterILabel;
        private Button GuessButton;
        private TextBox EnterJTextBox;
        private TextBox EnterITextBox;
    }
}