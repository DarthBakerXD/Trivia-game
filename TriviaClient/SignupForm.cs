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
    public partial class SignupForm : Form
    {
        public string username;
        public SignupForm()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var signupRequest = new JSON_Classes.SignupRequest { Username = UsernameTextBox.Text, Password = PasswordTextBox.Text, Email = EmailTextBox.Text};
            byte[] message = GlobalHelpers.CreateMessage("102", signupRequest);
            if (!ClientSocket.client.Connected)
            {
                ClientSocket.client.Connect(ClientSocket.serverEndPoint);
            }
            ClientSocket.client.Send(message);
            byte[] response = new byte[1024];
            int bytesRead = ClientSocket.client.Receive(response);
            Array.Resize<byte>(ref response, bytesRead);
            if (GlobalHelpers.GetCode(response) == "202")
            {
                var signupResponse = MessagePack.MessagePackSerializer.Deserialize<JSON_Classes.SignupResponse>(GlobalHelpers.GetMsgpack(response));
                switch (signupResponse.Status)
                {
                    case 0:
                        this.username = UsernameTextBox.Text;
                        this.Close();
                        DialogResult = DialogResult.OK;
                        break;
                    case 1:
                        MessageBox.Show("An Issue Occured With The Database, Can't Sign up!");
                        this.Close();
                        DialogResult = DialogResult.No;
                        break;
                    default:
                        MessageBox.Show("Could Not Signup.. Please Check Your Credentials And Try Again!");
                        break;
                }
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.No;
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
        private void UsernameText_Enter(object sender, EventArgs e)
        {
            if (UsernameTextBox.ForeColor == Color.Silver)
            {
                UsernameTextBox.ForeColor = Color.Black;
                UsernameTextBox.Text = "";
            }
        }

        private void UsernameText_Leave(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "")
            {
                UsernameTextBox.ForeColor = Color.Silver;
                UsernameTextBox.Text = "Username...";
            }
        }

        private void PasswordText_Enter(object sender, EventArgs e)
        {
            if (PasswordTextBox.ForeColor == Color.Silver)
            {
                PasswordTextBox.ForeColor = Color.Black;
                PasswordTextBox.Text = "";
                PasswordTextBox.PasswordChar = '*';
            }
        }

        private void PasswordText_Leave(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "")
            {
                PasswordTextBox.ForeColor = Color.Silver;
                PasswordTextBox.Text = "Password...";
                PasswordTextBox.PasswordChar = '\0'; // No Password Char
            }
        }

        private void EmailText_Enter(object sender, EventArgs e)
        {
            if (EmailTextBox.ForeColor == Color.Silver)
            {
                EmailTextBox.ForeColor = Color.Black;
                EmailTextBox.Text = "";
            }
        }

        private void EmailText_Leave(object sender, EventArgs e)
        {
            if (EmailTextBox.Text == "")
            {
                EmailTextBox.ForeColor = Color.Silver;
                EmailTextBox.Text = "example@email.com";
            }
        }

        private void EmailText_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                var emailValid = new System.Net.Mail.MailAddress(EmailTextBox.Text);
                e.Cancel = false;
                emailErrorProvider.SetError(EmailLabel, null);
            }
            catch (FormatException)
            {
                e.Cancel = true;
                EmailTextBox.Focus();
                emailErrorProvider.SetError(EmailLabel, "Invalid Email Address, Please Format It Properly!");
            }
        }
    }
}
