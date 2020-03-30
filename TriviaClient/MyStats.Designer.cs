namespace TriviaClient
{
    partial class MyStats
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
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.CorrectAnswersLabel = new System.Windows.Forms.Label();
            this.CorrectStatLabel = new System.Windows.Forms.Label();
            this.WrongAnswersLabel = new System.Windows.Forms.Label();
            this.WrongStatLabel = new System.Windows.Forms.Label();
            this.AverageTimeLabel = new System.Windows.Forms.Label();
            this.AverageStatLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.AverageStatLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.AverageTimeLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.WrongStatLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.WrongAnswersLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CorrectStatLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.CorrectAnswersLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.UsernameLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 391);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.UsernameLabel, 2);
            this.UsernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(3, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(258, 97);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CorrectAnswersLabel
            // 
            this.CorrectAnswersLabel.AutoSize = true;
            this.CorrectAnswersLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CorrectAnswersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CorrectAnswersLabel.Location = new System.Drawing.Point(3, 97);
            this.CorrectAnswersLabel.Name = "CorrectAnswersLabel";
            this.CorrectAnswersLabel.Size = new System.Drawing.Size(126, 97);
            this.CorrectAnswersLabel.TabIndex = 1;
            this.CorrectAnswersLabel.Text = "Correct Answers";
            this.CorrectAnswersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CorrectStatLabel
            // 
            this.CorrectStatLabel.AutoSize = true;
            this.CorrectStatLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CorrectStatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CorrectStatLabel.Location = new System.Drawing.Point(135, 97);
            this.CorrectStatLabel.Name = "CorrectStatLabel";
            this.CorrectStatLabel.Size = new System.Drawing.Size(126, 97);
            this.CorrectStatLabel.TabIndex = 2;
            this.CorrectStatLabel.Text = "0";
            this.CorrectStatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WrongAnswersLabel
            // 
            this.WrongAnswersLabel.AutoSize = true;
            this.WrongAnswersLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WrongAnswersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WrongAnswersLabel.Location = new System.Drawing.Point(3, 194);
            this.WrongAnswersLabel.Name = "WrongAnswersLabel";
            this.WrongAnswersLabel.Size = new System.Drawing.Size(126, 97);
            this.WrongAnswersLabel.TabIndex = 3;
            this.WrongAnswersLabel.Text = "Wrong Answers";
            this.WrongAnswersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WrongStatLabel
            // 
            this.WrongStatLabel.AutoSize = true;
            this.WrongStatLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WrongStatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WrongStatLabel.Location = new System.Drawing.Point(135, 194);
            this.WrongStatLabel.Name = "WrongStatLabel";
            this.WrongStatLabel.Size = new System.Drawing.Size(126, 97);
            this.WrongStatLabel.TabIndex = 4;
            this.WrongStatLabel.Text = "0";
            this.WrongStatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AverageTimeLabel
            // 
            this.AverageTimeLabel.AutoSize = true;
            this.AverageTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AverageTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AverageTimeLabel.Location = new System.Drawing.Point(3, 291);
            this.AverageTimeLabel.Name = "AverageTimeLabel";
            this.AverageTimeLabel.Size = new System.Drawing.Size(126, 100);
            this.AverageTimeLabel.TabIndex = 5;
            this.AverageTimeLabel.Text = "Average Time Per Answer";
            this.AverageTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AverageStatLabel
            // 
            this.AverageStatLabel.AutoSize = true;
            this.AverageStatLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AverageStatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AverageStatLabel.Location = new System.Drawing.Point(135, 291);
            this.AverageStatLabel.Name = "AverageStatLabel";
            this.AverageStatLabel.Size = new System.Drawing.Size(126, 100);
            this.AverageStatLabel.TabIndex = 6;
            this.AverageStatLabel.Text = "0";
            this.AverageStatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 416);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MyStats";
            this.Text = "MyStats";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label AverageStatLabel;
        private System.Windows.Forms.Label AverageTimeLabel;
        private System.Windows.Forms.Label WrongStatLabel;
        private System.Windows.Forms.Label WrongAnswersLabel;
        private System.Windows.Forms.Label CorrectStatLabel;
        private System.Windows.Forms.Label CorrectAnswersLabel;
        private System.Windows.Forms.Label UsernameLabel;
    }
}