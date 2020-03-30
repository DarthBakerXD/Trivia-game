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
    public partial class LoginMenu : Form
    {
        public string username;

        public LoginMenu()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var inputForm = new LoginForm();
            this.Hide();
            DialogResult result = inputForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                this.Show();
            }
            else
            {
                this.Close();
                if (result == DialogResult.OK)
                {
                    this.username = inputForm.username;
                }
                DialogResult = result;
            }
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            var inputForm = new SignupForm();
            this.Hide();
            DialogResult result = inputForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                this.Show();
            }
            else
            {
                this.Close();
                if (result == DialogResult.OK)
                {
                    this.username = inputForm.username;
                }
                DialogResult = result;
            }
        }
    }
}
