using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagePack;

namespace TriviaClient
{
    public partial class LobbyBrowser : Form
    {
        private JSON_Classes.Room[] rooms;
        private string username;
        public LobbyBrowser(JSON_Classes.Room[] rooms, string username)
        {
            InitializeComponent();
            this.rooms = rooms;
            this.username = username;
            RoomListBox.DataSource = rooms;
            RoomListBox.ClearSelected();
            PlayerListBox.Visible = false;
        }

        private void RoomListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoomListBox.SelectedIndex != -1)
            {
                if (!PlayerListBox.Visible)
                {
                    PlayerListBox.Visible = true;
                }
                PlayerListBox.DataSource = rooms[RoomListBox.SelectedIndex].Players;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.No;
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            if (RoomListBox.SelectedIndex != -1)
            {
                var request = new JSON_Classes.JoinRoomRequest { Id = rooms[RoomListBox.SelectedIndex].Metadata.id };
                byte[] message = GlobalHelpers.CreateMessage("115", request);
                ClientSocket.client.Send(message);
                byte[] response = new byte[1024];
                int bytesRead = ClientSocket.client.Receive(response);
                Array.Resize<byte>(ref response, bytesRead);
                if (GlobalHelpers.GetCode(response) == "215")
                {
                    var status = MessagePackSerializer.Deserialize<JSON_Classes.JoinRoomResponse>(GlobalHelpers.GetMsgpack(response));
                    switch (status.Status)
                    {
                        case 0:
                            string[] players = rooms[RoomListBox.SelectedIndex].Players;
                            Array.Resize(ref players, players.Length + 1);
                            players[players.Length - 1] = username; // Insert new players into list
                            rooms[RoomListBox.SelectedIndex].Players = players;
                            var gameLobby = new LobbyScreenRegular(rooms[RoomListBox.SelectedIndex]);
                            this.Hide();
                            gameLobby.ShowDialog();
                            this.Close();
                            DialogResult = DialogResult.No;
                            break;
                        default:
                            MessageBox.Show("Could Not Join Lobby!");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Could Not Join Lobby!");
                }
            }
        }
    }
}
