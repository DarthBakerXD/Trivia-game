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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private string username;
        private void MainMenu_Load(object sender, EventArgs e)
        {
            var prompt = new IPPromptForm();
            bool successful = false;
            while (!successful)
            {
                try
                {
                    this.Hide();
                    prompt.ShowDialog();
                    ClientSocket.serverEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(prompt.IP), 5656);
                    successful = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("IP Is Invalid, Please try again!");
                }
            }
            var loginMenu = new LoginMenu();
            DialogResult loginResult = loginMenu.ShowDialog();
            if (loginResult == DialogResult.OK)
            {
                LoggedNameLabel.Text = String.Format(LoggedNameLabel.Text, loginMenu.username);
                username = loginMenu.username;
            }
            else
            {
                this.Close();
                DialogResult = loginResult;
            }
        }

        private void BrowseLobbiesButton_Click(object sender, EventArgs e)
        {
            byte[] message = new ASCIIEncoding().GetBytes("112");
            ClientSocket.client.Send(message);
            byte[] response = new byte[1024];
            int bytesRead = ClientSocket.client.Receive(response);
            Array.Resize<byte>(ref response, bytesRead);
            if (GlobalHelpers.GetCode(response) == "212")
            {
                var lobbies = MessagePack.MessagePackSerializer.Deserialize<JSON_Classes.GetRoomsResponse>(GlobalHelpers.GetMsgpack(response));
                switch (lobbies.Status)
                {
                    case 0:
                        var browser = new LobbyBrowser(lobbies.Rooms, username);
                        this.Hide();
                        var result = browser.ShowDialog();
                        if (result != DialogResult.No)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Show();
                        }
                        break;
                    default:
                        MessageBox.Show("Error Getting Lobbies!");
                        break;
                }
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.No;
            }
        }

        private void CreateLobbyButton_Click(object sender, EventArgs e)
        {
            var form = new LobbyDetailsForm();
            this.Hide();
            form.ShowDialog();
            var request = new JSON_Classes.CreateRoomRequest { Name = form.Name, MaxUsers = form.MaxUsers, QuestionCount = form.QuestionCount, TimePerQuestion = form.TimePerQuestion };
            byte[] message = GlobalHelpers.CreateMessage("116", request);
            ClientSocket.client.Send(message);
            byte[] response = new byte[1024];
            int bytesRead = ClientSocket.client.Receive(response);
            Array.Resize<byte>(ref response, bytesRead);
            if (GlobalHelpers.GetCode(response) == "216")
            {
                var result = MessagePack.MessagePackSerializer.Deserialize<JSON_Classes.CreateRoomResponse>(GlobalHelpers.GetMsgpack(response));
                var room = new JSON_Classes.Room();
                var metadata = new JSON_Classes.RoomData();
                metadata.IsActive = 0;
                metadata.id = result.Id;
                metadata.name = request.Name;
                metadata.MaxPlayers = request.MaxUsers;
                metadata.QuestionCount = request.QuestionCount;
                metadata.AnswerTimeout = request.TimePerQuestion;
                room.Players = new[] { username };
                room.Metadata = metadata;
                var gameLobby = new LobbyScreenAdmin(room);
                this.Hide();
                gameLobby.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Error Creating Lobby!");
                this.Close();
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void MainMenu_Closing(object sender, FormClosingEventArgs e)
        {
            if (ClientSocket.client.Connected)
            {
                byte[] message = new ASCIIEncoding().GetBytes("111");
                ClientSocket.client.Send(message);
                byte[] response = new byte[1024];
                int bytesRead = ClientSocket.client.Receive(response);
                Array.Resize<byte>(ref response, bytesRead);
                DialogResult = DialogResult.OK;
            }
        }

        private void ViewHighscoresButton_Click(object sender, EventArgs e)
        {
            byte[] message = new ASCIIEncoding().GetBytes("114");
            ClientSocket.client.Send(message);
            byte[] response = new byte[1024];
            int bytesRead = ClientSocket.client.Receive(response);
            Array.Resize<byte>(ref response, bytesRead);
            if (GlobalHelpers.GetCode(response) == "214")
            {
                var result = MessagePack.MessagePackSerializer.Deserialize<JSON_Classes.GetHighscoreResponse>(GlobalHelpers.GetMsgpack(response));
                switch (result.Status)
                {
                    case 0:
                        Dictionary<string, uint> highscores = new Dictionary<string, uint>();
                        for (int i = 0; i < result.Highscores.Length; i++)
                        {
                            highscores[result.Highscores[i].Key] = result.Highscores[i].Value;
                        }
                        var browser = new HighscoreViewer(highscores);
                        this.Hide();
                        browser.ShowDialog();
                        this.Show();
                        break;
                    default:
                        MessageBox.Show("Could Not Get Highscores!");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Could Not Get Highscores!");
            }
        }

        private void MyStatsButton_Click(object sender, EventArgs e)
        {
            byte[] message = new ASCIIEncoding().GetBytes("117");
            ClientSocket.client.Send(message);
            byte[] response = new byte[1024];
            int bytesRead = ClientSocket.client.Receive(response);
            Array.Resize<byte>(ref response, bytesRead);
            if (GlobalHelpers.GetCode(response) == "217")
            {
                var result = MessagePack.MessagePackSerializer.Deserialize<JSON_Classes.GetStatsResponse>(GlobalHelpers.GetMsgpack(response));
                switch (result.Status)
                {
                    case 0:
                        this.Hide();
                        var statsPage = new MyStats(result.Stats);
                        statsPage.ShowDialog();
                        this.Show();
                        break;
                    default:
                        MessageBox.Show("Could Not Get Stats!");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Could Not Get Stats!");
            }
        }
    }
}
