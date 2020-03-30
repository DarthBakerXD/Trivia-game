namespace TriviaClient
{
    partial class LobbyDetailsForm
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
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.TimePerQuestionLabel = new System.Windows.Forms.Label();
            this.TimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.QuestionCountLabel = new System.Windows.Forms.Label();
            this.QuestionUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.MaxUsersLabel = new System.Windows.Forms.Label();
            this.MaxUsersUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.RoomNameLabel = new System.Windows.Forms.Label();
            this.RoomNameBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeUpDown)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionUpDown)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUsersUpDown)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(297, 301);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.TimePerQuestionLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.TimeUpDown, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 228);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.67F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(291, 69);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // TimePerQuestionLabel
            // 
            this.TimePerQuestionLabel.AutoSize = true;
            this.TimePerQuestionLabel.Location = new System.Drawing.Point(3, 0);
            this.TimePerQuestionLabel.Name = "TimePerQuestionLabel";
            this.TimePerQuestionLabel.Size = new System.Drawing.Size(97, 13);
            this.TimePerQuestionLabel.TabIndex = 6;
            this.TimePerQuestionLabel.Text = "Time Per Question:";
            // 
            // TimeUpDown
            // 
            this.TimeUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TimeUpDown.Location = new System.Drawing.Point(3, 46);
            this.TimeUpDown.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.TimeUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TimeUpDown.Name = "TimeUpDown";
            this.TimeUpDown.Size = new System.Drawing.Size(120, 20);
            this.TimeUpDown.TabIndex = 7;
            this.TimeUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.QuestionCountLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.QuestionUpDown, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 153);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.67F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(291, 69);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // QuestionCountLabel
            // 
            this.QuestionCountLabel.AutoSize = true;
            this.QuestionCountLabel.Location = new System.Drawing.Point(3, 0);
            this.QuestionCountLabel.Name = "QuestionCountLabel";
            this.QuestionCountLabel.Size = new System.Drawing.Size(83, 13);
            this.QuestionCountLabel.TabIndex = 4;
            this.QuestionCountLabel.Text = "Question Count:";
            // 
            // QuestionUpDown
            // 
            this.QuestionUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.QuestionUpDown.Location = new System.Drawing.Point(3, 46);
            this.QuestionUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.QuestionUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuestionUpDown.Name = "QuestionUpDown";
            this.QuestionUpDown.Size = new System.Drawing.Size(120, 20);
            this.QuestionUpDown.TabIndex = 5;
            this.QuestionUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.MaxUsersLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.MaxUsersUpDown, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 78);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.67F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(291, 69);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // MaxUsersLabel
            // 
            this.MaxUsersLabel.AutoSize = true;
            this.MaxUsersLabel.Location = new System.Drawing.Point(3, 0);
            this.MaxUsersLabel.Name = "MaxUsersLabel";
            this.MaxUsersLabel.Size = new System.Drawing.Size(60, 13);
            this.MaxUsersLabel.TabIndex = 2;
            this.MaxUsersLabel.Text = "Max Users:";
            // 
            // MaxUsersUpDown
            // 
            this.MaxUsersUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MaxUsersUpDown.Location = new System.Drawing.Point(3, 46);
            this.MaxUsersUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.MaxUsersUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxUsersUpDown.Name = "MaxUsersUpDown";
            this.MaxUsersUpDown.Size = new System.Drawing.Size(120, 20);
            this.MaxUsersUpDown.TabIndex = 3;
            this.MaxUsersUpDown.ThousandsSeparator = true;
            this.MaxUsersUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.RoomNameLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.RoomNameBox, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.67F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(291, 69);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // RoomNameLabel
            // 
            this.RoomNameLabel.AutoSize = true;
            this.RoomNameLabel.Location = new System.Drawing.Point(3, 0);
            this.RoomNameLabel.Name = "RoomNameLabel";
            this.RoomNameLabel.Size = new System.Drawing.Size(69, 13);
            this.RoomNameLabel.TabIndex = 0;
            this.RoomNameLabel.Text = "Room Name:";
            // 
            // RoomNameBox
            // 
            this.RoomNameBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RoomNameBox.Location = new System.Drawing.Point(3, 46);
            this.RoomNameBox.Name = "RoomNameBox";
            this.RoomNameBox.Size = new System.Drawing.Size(285, 20);
            this.RoomNameBox.TabIndex = 1;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ConfirmButton.Location = new System.Drawing.Point(0, 339);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(321, 23);
            this.ConfirmButton.TabIndex = 1;
            this.ConfirmButton.Text = "Create";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // LobbyDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 362);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LobbyDetailsForm";
            this.Text = "LobbyDetailsForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeUpDown)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionUpDown)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUsersUpDown)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label TimePerQuestionLabel;
        private System.Windows.Forms.NumericUpDown TimeUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label QuestionCountLabel;
        private System.Windows.Forms.NumericUpDown QuestionUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label MaxUsersLabel;
        private System.Windows.Forms.NumericUpDown MaxUsersUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label RoomNameLabel;
        private System.Windows.Forms.TextBox RoomNameBox;
        private System.Windows.Forms.Button ConfirmButton;
    }
}