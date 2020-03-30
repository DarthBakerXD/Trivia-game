using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaClient
{
    public partial class LobbyScreenRegular : Form
    {
        private Thread loopThread;
        private bool stopThread = false;
        private JSON_Classes.Room room;
        public LobbyScreenRegular(JSON_Classes.Room room)
        {
            InitializeComponent();
            RoomNameLabel.Text = room.Metadata.name;
            MaxPlayersLabel.Text = String.Format(MaxPlayersLabel.Text, room.Metadata.MaxPlayers);
            QuestionCountLabel.Text = String.Format(QuestionCountLabel.Text, room.Metadata.QuestionCount);
            TimePerQuestionLabel.Text = String.Format(TimePerQuestionLabel.Text, room.Metadata.AnswerTimeout);
            PlayerListBox.DataSource = room.Players;
            this.room = room;
            loopThread = new Thread(updateLoop);
            loopThread.Start();
        }
        private void updateLoop()
        {
            while (!stopThread)
            {
                Thread.Sleep(5000);
                byte[] message = new ASCIIEncoding().GetBytes("123");
                ClientSocket.client.Send(message);
                byte[] response = new byte[1024];
                int bytesRead = ClientSocket.client.Receive(response);
                Array.Resize<byte>(ref response, bytesRead);
                if (GlobalHelpers.GetCode(response) == "223")
                {
                    var roomState = MessagePack.MessagePackSerializer.Deserialize<JSON_Classes.GetRoomStateResponse>(GlobalHelpers.GetMsgpack(response));
                    switch (roomState.Status)
                    {
                        case 0:
                            if (!stopThread)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    this.PlayerListBox.DataSource = roomState.Room.Players;
                                });
                            }
                            break;
                        default:
                            if (!stopThread)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show("There Was An Error Getting The Room Info!");
                                    this.Close();
                                    DialogResult = DialogResult.Abort;
                                });
                            }
                            break;
                    }
                    switch (roomState.Room.Metadata.IsActive) // Game Status Check
                    {
                        case 0: // Still In Lobby, Do Nothing
                            break;
                        case -1: // Admin Closed Lobby, Leave
                            if (!stopThread)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show("Room Has Been Closed!");
                                    this.Close();
                                    DialogResult = DialogResult.Abort;
                                });
                                stopThread = true;
                            }
                            break;
                        default: // Game Started
                            if (!stopThread)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    this.Hide();
                                    var game = new GameQuestion(this.room.Metadata);
                                    game.ShowDialog();
                                    this.Close();
                                });
                                stopThread = true;
                            }
                            break;
                    }
                }
            }
        }

        private void LeaveLobbyButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void LobbyScreenRegular_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] message = new ASCIIEncoding().GetBytes("124");
            ClientSocket.client.Send(message);
            byte[] response = new byte[1024];
            int bytesRead = ClientSocket.client.Receive(response);
            Array.Resize<byte>(ref response, bytesRead);
            stopThread = true;
        }
    }
}