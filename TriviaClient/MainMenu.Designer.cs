namespace TriviaClient
{
    partial class MainMenu
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
            this.MagshiTriviaTitleLabel = new System.Windows.Forms.Label();
            this.LoggedNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MyStatsButton = new System.Windows.Forms.Button();
            this.BrowseLobbiesButton = new System.Windows.Forms.Button();
            this.CreateLobbyButton = new System.Windows.Forms.Button();
            this.ViewHighscoresButton = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.CreditLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MagshiTriviaTitleLabel
            // 
            this.MagshiTriviaTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MagshiTriviaTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MagshiTriviaTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.MagshiTriviaTitleLabel.Name = "MagshiTriviaTitleLabel";
            this.MagshiTriviaTitleLabel.Size = new System.Drawing.Size(800, 55);
            this.MagshiTriviaTitleLabel.TabIndex = 0;
            this.MagshiTriviaTitleLabel.Text = "MagshiTrivia";
            this.MagshiTriviaTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoggedNameLabel
            // 
            this.LoggedNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoggedNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoggedNameLabel.Location = new System.Drawing.Point(0, 55);
            this.LoggedNameLabel.Name = "LoggedNameLabel";
            this.LoggedNameLabel.Size = new System.Drawing.Size(800, 55);
            this.LoggedNameLabel.TabIndex = 1;
            this.LoggedNameLabel.Text = "Logged In As: {0}";
            this.LoggedNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.MyStatsButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.BrowseLobbiesButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CreateLobbyButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ViewHighscoresButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.VersionLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.CreditLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.QuitButton, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 110);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 340);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // MyStatsButton
            // 
            this.MyStatsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyStatsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyStatsButton.Location = new System.Drawing.Point(457, 83);
            this.MyStatsButton.Name = "MyStatsButton";
            this.MyStatsButton.Size = new System.Drawing.Size(340, 74);
            this.MyStatsButton.TabIndex = 8;
            this.MyStatsButton.Text = "My Stats";
            this.MyStatsButton.UseVisualStyleBackColor = true;
            this.MyStatsButton.Click += new System.EventHandler(this.MyStatsButton_Click);
            // 
            // BrowseLobbiesButton
            // 
            this.BrowseLobbiesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseLobbiesButton.Location = new System.Drawing.Point(3, 3);
            this.BrowseLobbiesButton.Name = "BrowseLobbiesButton";
            this.BrowseLobbiesButton.Size = new System.Drawing.Size(340, 74);
            this.BrowseLobbiesButton.TabIndex = 0;
            this.BrowseLobbiesButton.Text = "Browse Lobbies";
            this.BrowseLobbiesButton.UseVisualStyleBackColor = true;
            this.BrowseLobbiesButton.Click += new System.EventHandler(this.BrowseLobbiesButton_Click);
            // 
            // CreateLobbyButton
            // 
            this.CreateLobbyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateLobbyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateLobbyButton.Location = new System.Drawing.Point(457, 3);
            this.CreateLobbyButton.Name = "CreateLobbyButton";
            this.CreateLobbyButton.Size = new System.Drawing.Size(340, 74);
            this.CreateLobbyButton.TabIndex = 1;
            this.CreateLobbyButton.Text = "Create New Lobby";
            this.CreateLobbyButton.UseVisualStyleBackColor = true;
            this.CreateLobbyButton.Click += new System.EventHandler(this.CreateLobbyButton_Click);
            // 
            // ViewHighscoresButton
            // 
            this.ViewHighscoresButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewHighscoresButton.Location = new System.Drawing.Point(3, 83);
            this.ViewHighscoresButton.Name = "ViewHighscoresButton";
            this.ViewHighscoresButton.Size = new System.Drawing.Size(340, 74);
            this.ViewHighscoresButton.TabIndex = 5;
            this.ViewHighscoresButton.Text = "View Highscores";
            this.ViewHighscoresButton.UseVisualStyleBackColor = true;
            this.ViewHighscoresButton.Click += new System.EventHandler(this.ViewHighscoresButton_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.Location = new System.Drawing.Point(3, 320);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(146, 20);
            this.VersionLabel.TabIndex = 6;
            this.VersionLabel.Text = "MagshiTrivia V4.0.0";
            // 
            // CreditLabel
            // 
            this.CreditLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreditLabel.AutoSize = true;
            this.CreditLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditLabel.Location = new System.Drawing.Point(502, 320);
            this.CreditLabel.Name = "CreditLabel";
            this.CreditLabel.Size = new System.Drawing.Size(295, 20);
            this.CreditLabel.TabIndex = 7;
            this.CreditLabel.Text = "By Ron Gorodetski And Eran Yeruhamie";
            this.CreditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuitButton
            // 
            this.QuitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.QuitButton, 2);
            this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.Location = new System.Drawing.Point(230, 243);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(340, 74);
            this.QuitButton.TabIndex = 2;
            this.QuitButton.Text = "Logout";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.LoggedNameLabel);
            this.Controls.Add(this.MagshiTriviaTitleLabel);
            this.Name = "MainMenu";
            this.Text = "Trivia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_Closing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MagshiTriviaTitleLabel;
        private System.Windows.Forms.Label LoggedNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BrowseLobbiesButton;
        private System.Windows.Forms.Button ViewHighscoresButton;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Button MyStatsButton;
        private System.Windows.Forms.Button CreateLobbyButton;
        private System.Windows.Forms.Label CreditLabel;
        private System.Windows.Forms.Button QuitButton;
    }
}

