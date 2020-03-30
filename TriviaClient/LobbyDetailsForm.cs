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
    public partial class LobbyDetailsForm : Form
    {
        public new string Name { get; protected set; }
        public uint MaxUsers { get; protected set; }
        public uint QuestionCount { get; protected set; }
        public uint TimePerQuestion { get; protected set; }

        public LobbyDetailsForm()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
            Name = RoomNameBox.Text;
            MaxUsers = (uint)MaxUsersUpDown.Value;
            QuestionCount = (uint)QuestionUpDown.Value;
            TimePerQuestion = (uint)TimeUpDown.Value;
        }
    }
}
