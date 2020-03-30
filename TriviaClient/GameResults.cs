using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TriviaClient
{
    public partial class GameResults : Form
    {
        private bool stopThread = false;
        private Thread updateThread;
        public GameResults()
        {
            InitializeComponent();
        }

        private void AddItem(string Username, uint answeredQuestions, uint correctAns, uint wrongAns, uint avgTime)
        {
            //Keep the previous style saved
            RowStyle temp = ResultsPanel.RowStyles[ResultsPanel.RowCount - 1];
            //increase panel rows count by one
            ResultsPanel.RowCount++;
            //add a new RowStyle as a copy of the previous one
            ResultsPanel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            //add labels
            ResultsPanel.Controls.Add(new Label() { Text = Username }, 0, ResultsPanel.RowCount - 1);
            ResultsPanel.Controls.Add(new Label() { Text = answeredQuestions.ToString() }, 1, ResultsPanel.RowCount - 1);
            ResultsPanel.Controls.Add(new Label() { Text = correctAns.ToString() }, 2, ResultsPanel.RowCount - 1);
            ResultsPanel.Controls.Add(new Label() { Text = wrongAns.ToString() }, 3, ResultsPanel.RowCount - 1);
            ResultsPanel.Controls.Add(new Label() { Text = avgTime.ToString() }, 4, ResultsPanel.RowCount - 1);
        }

        private void GameResults_Load(object sender, EventArgs e)
        {
            fetchResults();
            updateThread = new Thread(updateLoop);
            updateThread.Start();
        }

        private void updateLoop()
        {
            while (!stopThread)
            {
                Thread.Sleep(5000);
                fetchResults();
            }
        }

        private void fetchResults()
        {
            byte[] message = new ASCIIEncoding().GetBytes("133");
            ClientSocket.client.Send(message);
            byte[] response = new byte[1024];
            int bytesRead = ClientSocket.client.Receive(response);
            Array.Resize<byte>(ref response, bytesRead);
            if (GlobalHelpers.GetCode(response) == "233")
            {
                var gameResults = MessagePack.MessagePackSerializer.Deserialize<JSON_Classes.GetGameResultsResponse>(GlobalHelpers.GetMsgpack(response));
                switch (gameResults.Status)
                {
                    case 0:
                        if (!stopThread)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                for (int i = 1; i < ResultsPanel.RowCount && i < gameResults.Results.Length; i++)
                                {
                                    ResultsPanel.GetControlFromPosition(0, i).Text = gameResults.Results[i - 1].Username;
                                    ResultsPanel.GetControlFromPosition(1, i).Text = (gameResults.Results[i - 1].CorrectAnswers + gameResults.Results[i - 1].WrongAnswers).ToString();
                                    ResultsPanel.GetControlFromPosition(2, i).Text = gameResults.Results[i - 1].CorrectAnswers.ToString();
                                    ResultsPanel.GetControlFromPosition(3, i).Text = gameResults.Results[i - 1].WrongAnswers.ToString();
                                    ResultsPanel.GetControlFromPosition(4, i).Text = gameResults.Results[i - 1].AverageTime.ToString();
                                }
                                for (int i = ResultsPanel.RowCount; i <= gameResults.Results.Length; i++)
                                {
                                    AddItem(gameResults.Results[i - 1].Username, gameResults.Results[i - 1].CorrectAnswers + gameResults.Results[i - 1].WrongAnswers, gameResults.Results[i - 1].CorrectAnswers, gameResults.Results[i - 1].WrongAnswers, gameResults.Results[i - 1].AverageTime);
                                }
                            });
                        }
                        break;
                    default:
                        if (!stopThread)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("There Was An Error Getting The Game Results!");
                                this.Close();
                                DialogResult = DialogResult.Abort;
                            });
                        }
                        break;
                }
            }
        }

        private void GameResults_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopThread = true;
        }
    }
}
