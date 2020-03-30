namespace TriviaClient
{
    partial class LobbyScreenRegular
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TimePerQuestionLabel = new System.Windows.Forms.Label();
            this.QuestionCountLabel = new System.Windows.Forms.Label();
            this.RoomNameLabel = new System.Windows.Forms.Label();
            this.MaxPlayersLabel = new System.Windows.Forms.Label();
            this.PlayerListBox = new System.Windows.Forms.ListBox();
            this.PlayersListLabel = new System.Windows.Forms.Label();
            this.LeaveLobbyButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.TimePerQuestionLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.QuestionCountLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.RoomNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MaxPlayersLabel, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(297, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TimePerQuestionLabel
            // 
            this.TimePerQuestionLabel.AutoSize = true;
            this.TimePerQuestionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimePerQuestionLabel.Location = new System.Drawing.Point(200, 73);
            this.TimePerQuestionLabel.Name = "TimePerQuestionLabel";
            this.TimePerQuestionLabel.Size = new System.Drawing.Size(94, 74);
            this.TimePerQuestionLabel.TabIndex = 3;
            this.TimePerQuestionLabel.Text = "Time Per Question:\r\n{0}";
            this.TimePerQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuestionCountLabel
            // 
            this.QuestionCountLabel.AutoSize = true;
            this.QuestionCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestionCountLabel.Location = new System.Drawing.Point(101, 73);
            this.QuestionCountLabel.Name = "QuestionCountLabel";
            this.QuestionCountLabel.Size = new System.Drawing.Size(93, 74);
            this.QuestionCountLabel.TabIndex = 2;
            this.QuestionCountLabel.Text = "Number Of Questions:\r\n{0}";
            this.QuestionCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RoomNameLabel
            // 
            this.RoomNameLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.RoomNameLabel, 3);
            this.RoomNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoomNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomNameLabel.Location = new System.Drawing.Point(3, 0);
            this.RoomNameLabel.Name = "RoomNameLabel";
            this.RoomNameLabel.Size = new System.Drawing.Size(291, 73);
            this.RoomNameLabel.TabIndex = 0;
            this.RoomNameLabel.Text = "*room name*";
            this.RoomNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MaxPlayersLabel
            // 
            this.MaxPlayersLabel.AutoSize = true;
            this.MaxPlayersLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxPlayersLabel.Location = new System.Drawing.Point(3, 73);
            this.MaxPlayersLabel.Name = "MaxPlayersLabel";
            this.MaxPlayersLabel.Size = new System.Drawing.Size(92, 74);
            this.MaxPlayersLabel.TabIndex = 1;
            this.MaxPlayersLabel.Text = "Max Players:\r\n{0}";
            this.MaxPlayersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerListBox
            // 
            this.PlayerListBox.FormattingEnabled = true;
            this.PlayerListBox.Location = new System.Drawing.Point(12, 187);
            this.PlayerListBox.Name = "PlayerListBox";
            this.PlayerListBox.Size = new System.Drawing.Size(297, 95);
            this.PlayerListBox.TabIndex = 1;
            // 
            // PlayersListLabel
            // 
            this.PlayersListLabel.AutoSize = true;
            this.PlayersListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersListLabel.Location = new System.Drawing.Point(9, 171);
            this.PlayersListLabel.Name = "PlayersListLabel";
            this.PlayersListLabel.Size = new System.Drawing.Size(52, 13);
            this.PlayersListLabel.TabIndex = 2;
            this.PlayersListLabel.Text = "Players:";
            // 
            // LeaveLobbyButton
            // 
            this.LeaveLobbyButton.Location = new System.Drawing.Point(12, 291);
            this.LeaveLobbyButton.Name = "LeaveLobbyButton";
            this.LeaveLobbyButton.Size = new System.Drawing.Size(75, 23);
            this.LeaveLobbyButton.TabIndex = 3;
            this.LeaveLobbyButton.Text = "Leave";
            this.LeaveLobbyButton.UseVisualStyleBackColor = true;
            this.LeaveLobbyButton.Click += new System.EventHandler(this.LeaveLobbyButton_Click);
            // 
            // LobbyScreenRegular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 326);
            this.Controls.Add(this.LeaveLobbyButton);
            this.Controls.Add(this.PlayersListLabel);
            this.Controls.Add(this.PlayerListBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LobbyScreenRegular";
            this.Text = "Lobby";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LobbyScreenRegular_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label RoomNameLabel;
        private System.Windows.Forms.Label MaxPlayersLabel;
        private System.Windows.Forms.Label TimePerQuestionLabel;
        private System.Windows.Forms.Label QuestionCountLabel;
        private System.Windows.Forms.ListBox PlayerListBox;
        private System.Windows.Forms.Label PlayersListLabel;
        private System.Windows.Forms.Button LeaveLobbyButton;
    }
}