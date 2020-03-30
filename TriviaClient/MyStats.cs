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
    public partial class MyStats : Form
    {
        public MyStats(JSON_Classes.PlayerResults stats)
        {
            InitializeComponent();
            UsernameLabel.Text = stats.Username;
            CorrectStatLabel.Text = stats.CorrectAnswers.ToString();
            WrongStatLabel.Text = stats.WrongAnswers.ToString();
            AverageStatLabel.Text = stats.AverageTime.ToString();
        }
    }
}
