namespace TriviaClient
{
    partial class GameResults
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
            this.ResultsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.QuestionsAnsweredLabel = new System.Windows.Forms.Label();
            this.CorrectAnsLabel = new System.Windows.Forms.Label();
            this.WrongAnsLabel = new System.Windows.Forms.Label();
            this.AvgTimeLabel = new System.Windows.Forms.Label();
            this.ResultsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultsPanel
            // 
            this.ResultsPanel.AutoScroll = true;
            this.ResultsPanel.AutoSize = true;
            this.ResultsPanel.ColumnCount = 5;
            this.ResultsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ResultsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ResultsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ResultsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ResultsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ResultsPanel.Controls.Add(this.AvgTimeLabel, 4, 0);
            this.ResultsPanel.Controls.Add(this.WrongAnsLabel, 3, 0);
            this.ResultsPanel.Controls.Add(this.CorrectAnsLabel, 2, 0);
            this.ResultsPanel.Controls.Add(this.QuestionsAnsweredLabel, 1, 0);
            this.ResultsPanel.Controls.Add(this.UsernameLabel, 0, 0);
            this.ResultsPanel.Location = new System.Drawing.Point(13, 13);
            this.ResultsPanel.Name = "ResultsPanel";
            this.ResultsPanel.RowCount = 1;
            this.ResultsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResultsPanel.Size = new System.Drawing.Size(584, 425);
            this.ResultsPanel.TabIndex = 0;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsernameLabel.Location = new System.Drawing.Point(3, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(110, 425);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuestionsAnsweredLabel
            // 
            this.QuestionsAnsweredLabel.AutoSize = true;
            this.QuestionsAnsweredLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestionsAnsweredLabel.Location = new System.Drawing.Point(119, 0);
            this.QuestionsAnsweredLabel.Name = "QuestionsAnsweredLabel";
            this.QuestionsAnsweredLabel.Size = new System.Drawing.Size(110, 425);
            this.QuestionsAnsweredLabel.TabIndex = 1;
            this.QuestionsAnsweredLabel.Text = "Questions Answered";
            this.QuestionsAnsweredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CorrectAnsLabel
            // 
            this.CorrectAnsLabel.AutoSize = true;
            this.CorrectAnsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CorrectAnsLabel.Location = new System.Drawing.Point(235, 0);
            this.CorrectAnsLabel.Name = "CorrectAnsLabel";
            this.CorrectAnsLabel.Size = new System.Drawing.Size(110, 425);
            this.CorrectAnsLabel.TabIndex = 2;
            this.CorrectAnsLabel.Text = "Correct Answers";
            this.CorrectAnsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WrongAnsLabel
            // 
            this.WrongAnsLabel.AutoSize = true;
            this.WrongAnsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WrongAnsLabel.Location = new System.Drawing.Point(351, 0);
            this.WrongAnsLabel.Name = "WrongAnsLabel";
            this.WrongAnsLabel.Size = new System.Drawing.Size(110, 425);
            this.WrongAnsLabel.TabIndex = 3;
            this.WrongAnsLabel.Text = "Incorrect Answers";
            this.WrongAnsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AvgTimeLabel
            // 
            this.AvgTimeLabel.AutoSize = true;
            this.AvgTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AvgTimeLabel.Location = new System.Drawing.Point(467, 0);
            this.AvgTimeLabel.Name = "AvgTimeLabel";
            this.AvgTimeLabel.Size = new System.Drawing.Size(114, 425);
            this.AvgTimeLabel.TabIndex = 4;
            this.AvgTimeLabel.Text = "Average Time";
            this.AvgTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 450);
            this.Controls.Add(this.ResultsPanel);
            this.Name = "GameResults";
            this.Text = "GameResults";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameResults_FormClosing);
            this.Load += new System.EventHandler(this.GameResults_Load);
            this.ResultsPanel.ResumeLayout(false);
            this.ResultsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ResultsPanel;
        private System.Windows.Forms.Label AvgTimeLabel;
        private System.Windows.Forms.Label WrongAnsLabel;
        private System.Windows.Forms.Label CorrectAnsLabel;
        private System.Windows.Forms.Label QuestionsAnsweredLabel;
        private System.Windows.Forms.Label UsernameLabel;
    }
}