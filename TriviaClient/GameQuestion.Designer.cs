namespace TriviaClient
{
    partial class GameQuestion
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
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.AnswerOneButton = new System.Windows.Forms.Button();
            this.AnswerTwoButton = new System.Windows.Forms.Button();
            this.AnswerThreeButton = new System.Windows.Forms.Button();
            this.AnswerFourButton = new System.Windows.Forms.Button();
            this.LeaveGameButton = new System.Windows.Forms.Button();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.AnswerFourButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.AnswerThreeButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.AnswerTwoButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.QuestionLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AnswerOneButton, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(549, 341);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.QuestionLabel, 2);
            this.QuestionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionLabel.Location = new System.Drawing.Point(3, 0);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(543, 136);
            this.QuestionLabel.TabIndex = 0;
            this.QuestionLabel.Text = "Question";
            this.QuestionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AnswerOneButton
            // 
            this.AnswerOneButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnswerOneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerOneButton.Location = new System.Drawing.Point(3, 139);
            this.AnswerOneButton.Name = "AnswerOneButton";
            this.AnswerOneButton.Size = new System.Drawing.Size(268, 96);
            this.AnswerOneButton.TabIndex = 1;
            this.AnswerOneButton.Text = "Answer";
            this.AnswerOneButton.UseVisualStyleBackColor = true;
            // 
            // AnswerTwoButton
            // 
            this.AnswerTwoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnswerTwoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerTwoButton.Location = new System.Drawing.Point(277, 139);
            this.AnswerTwoButton.Name = "AnswerTwoButton";
            this.AnswerTwoButton.Size = new System.Drawing.Size(269, 96);
            this.AnswerTwoButton.TabIndex = 2;
            this.AnswerTwoButton.Text = "Answer";
            this.AnswerTwoButton.UseVisualStyleBackColor = true;
            // 
            // AnswerThreeButton
            // 
            this.AnswerThreeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnswerThreeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerThreeButton.Location = new System.Drawing.Point(3, 241);
            this.AnswerThreeButton.Name = "AnswerThreeButton";
            this.AnswerThreeButton.Size = new System.Drawing.Size(268, 97);
            this.AnswerThreeButton.TabIndex = 3;
            this.AnswerThreeButton.Text = "Answer";
            this.AnswerThreeButton.UseVisualStyleBackColor = true;
            // 
            // AnswerFourButton
            // 
            this.AnswerFourButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnswerFourButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerFourButton.Location = new System.Drawing.Point(277, 241);
            this.AnswerFourButton.Name = "AnswerFourButton";
            this.AnswerFourButton.Size = new System.Drawing.Size(269, 97);
            this.AnswerFourButton.TabIndex = 4;
            this.AnswerFourButton.Text = "Answer";
            this.AnswerFourButton.UseVisualStyleBackColor = true;
            // 
            // LeaveGameButton
            // 
            this.LeaveGameButton.Location = new System.Drawing.Point(568, 327);
            this.LeaveGameButton.Name = "LeaveGameButton";
            this.LeaveGameButton.Size = new System.Drawing.Size(141, 23);
            this.LeaveGameButton.TabIndex = 1;
            this.LeaveGameButton.Text = "Leave Game";
            this.LeaveGameButton.UseVisualStyleBackColor = true;
            this.LeaveGameButton.Click += new System.EventHandler(this.LeaveGameButton_Click);
            // 
            // TimerLabel
            // 
            this.TimerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(568, 13);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(140, 100);
            this.TimerLabel.TabIndex = 2;
            this.TimerLabel.Text = "Time Left: {0} Seconds";
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(568, 298);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(141, 23);
            this.NextButton.TabIndex = 3;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Visible = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // GameQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 366);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.LeaveGameButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GameQuestion";
            this.Text = "GameQuestion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameQuestion_FormClosing);
            this.Load += new System.EventHandler(this.GameQuestion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button AnswerFourButton;
        private System.Windows.Forms.Button AnswerThreeButton;
        private System.Windows.Forms.Button AnswerTwoButton;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Button AnswerOneButton;
        private System.Windows.Forms.Button LeaveGameButton;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Button NextButton;
    }
}