using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaClient
{
    public partial class HighscoreViewer : Form
    {
        public HighscoreViewer(Dictionary<string, uint> highscores)
        {
            InitializeComponent();
            foreach (KeyValuePair<string, uint> score in highscores)
            {
                MainFlowPanel.Controls.Add(CreatePanel(score.Key, score.Value));
            }
        }
        public Panel CreatePanel(string username, uint score)
        {
            Panel p = new Panel();
            p.Dock = DockStyle.Top;
            Label Username = new Label();
            Username.AutoSize = false;
            Username.Dock = DockStyle.Left;
            Username.Text = username;
            Username.TextAlign = ContentAlignment.MiddleCenter;
            Username.Font = new Font("Microsoft Sans Serif", 16);
            Label Score = new Label();
            Score.AutoSize = false;
            Score.Dock = DockStyle.Right;
            Score.Text = score.ToString();
            Score.TextAlign = ContentAlignment.MiddleCenter;
            Score.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            p.Controls.AddRange(new []{ Username, Score });
            return p;
        }
    }
}
