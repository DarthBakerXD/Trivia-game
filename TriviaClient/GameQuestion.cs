using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace TriviaClient
{
    public partial class GameQuestion : Form
    {
        private JSON_Classes.RoomData roomRules;
        private bool stopTimer = false;
        private bool gameOver = false;
        private Stopwatch watch;
        private Button[] buttons;
        private int questionsPassed = 0;
        private Thread timerThread;
        private Color defaultColor;
        public GameQuestion(JSON_Classes.RoomData rules)
        {
            InitializeComponent();
            roomRules = rules;
            watch = new Stopwatch();
            buttons = new []{ AnswerOneButton, AnswerTwoButton, AnswerThreeButton, AnswerFourButton};
            defaultColor = AnswerOneButton.BackColor; // Save it for later.
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += AnswerButton_Click;
                buttons[i].BackColor = defaultColor;
            }
        }

        private void GameQuestion_Load(object sender, EventArgs e)
        {
            timerThread = new Thread(HandleTimer);
            FetchQuestion();
            timerThread.Start();
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Enabled = false;
            }
            Button button = sender as Button;
            stopTimer = true;
            string correctAnswer = SubmitAnswer(button.Text, Convert.ToUInt32(watch.Elapsed.Seconds));
            if (button.Text == correctAnswer)
            {
                button.BackColor = Color.Green;
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i] != button)
                    {
                        buttons[i].BackColor = Color.DarkRed;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i].Text == correctAnswer)
                    {
                        buttons[i].BackColor = Color.Green;
                    }
                    else
                    {
                        buttons[i].BackColor = Color.DarkRed;
                    }
                }
            }
            NextButton.Visible = true;
        }

        private void FetchQuestion()
        {
            byte[] message = new ASCIIEncoding().GetBytes("131");
            ClientSocket.client.Send(message);
            byte[] response = new byte[1024];
            int bytesRead = ClientSocket.client.Receive(response);
            Array.Resize<byte>(ref response, bytesRead);
            if (GlobalHelpers.GetCode(response) == "231")
            {
                var QuestionResponse = MessagePack.MessagePackSerializer.Deserialize<JSON_Classes.GetQuestionResponse>(GlobalHelpers.GetMsgpack(response));
                switch (QuestionResponse.Status)
                {
                    case 0:
                        QuestionLabel.Text = QuestionResponse.Question.QuestionString;
                        for (int i = 0; i < buttons.Length; i++)
                        {
                            buttons[i].Text = QuestionResponse.Question.PossibleAnswers[i];
                        }
                        break;
                    default:
                        MessageBox.Show("Couldn't Get Question!");
                        this.Close();
                        DialogResult = DialogResult.Abort;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Couldn't Get Question!");
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void GameQuestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopTimer = true;
            gameOver = true;
            byte[] message = new ASCIIEncoding().GetBytes("134");
            ClientSocket.client.Send(message);
            byte[] response = new byte[1024];
            int bytesRead = ClientSocket.client.Receive(response);
            Array.Resize<byte>(ref response, bytesRead);
        }
        private void HandleTimer()
        {
            while (!gameOver)
            {
                watch.Start();
                while (Convert.ToUInt32(watch.Elapsed.Seconds) < roomRules.AnswerTimeout && !stopTimer)
                {
                    if ((!stopTimer && !gameOver) && !this.IsDisposed) // Update timer, only if game is still going.
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.TimerLabel.Text = String.Format("Time Left: {0} Seconds", roomRules.AnswerTimeout - Convert.ToUInt32(watch.Elapsed.Seconds));
                        });
                        Thread.Sleep(500); // Sleep for 1/2 a second to not waste resources
                    }
                }
                watch.Stop();
                if ((watch.Elapsed.Seconds >= roomRules.AnswerTimeout && !stopTimer) && !this.IsDisposed)
                {
                    stopTimer = true;
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.TimerLabel.Text = "Time Left: 0 Seconds";
                        string correctAnswer = SubmitAnswer("", roomRules.AnswerTimeout); // Submit empty string, guranteed to be wrong, and full time elapsed.
                        for (int i = 0; i < buttons.Length; i++)
                        {
                            buttons[i].Enabled = false;
                            if (buttons[i].Text == correctAnswer)
                            {
                                buttons[i].BackColor = Color.Green;
                            }
                            else
                            {
                                buttons[i].BackColor = Color.DarkRed;
                            }
                        }
                        NextButton.Visible = true;
                    });
                }
                while (stopTimer && !this.IsDisposed)
                {
                    continue; // Loop here until we get a new question
                }
                watch.Reset();
            }
        }
        private string SubmitAnswer(string answer, uint timeElapsed)
        {
            JSON_Classes.SubmitAnswerRequest request = new JSON_Classes.SubmitAnswerRequest { Answer = answer, TimeUntilResponse = timeElapsed };
            byte[] message = GlobalHelpers.CreateMessage("132", request);
            ClientSocket.client.Send(message);
            byte[] response = new byte[1024];
            int bytesRead = ClientSocket.client.Receive(response);
            Array.Resize<byte>(ref response, bytesRead);
            if (GlobalHelpers.GetCode(response) == "232")
            {
                var submissionResult = MessagePack.MessagePackSerializer.Deserialize<JSON_Classes.SubmitAnswerResponse>(GlobalHelpers.GetMsgpack(response));
                switch (submissionResult.Status)
                {
                    case 0:
                        return submissionResult.CorrectAnswer;
                    default:
                        MessageBox.Show("Could Not Submit Answer!");
                        this.Close();
                        DialogResult = DialogResult.Abort;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Could Not Submit Answer!");
                this.Close();
                DialogResult = DialogResult.Abort;
            }
            return "";
        }

        private void LeaveGameButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            questionsPassed++;
            if (questionsPassed < roomRules.QuestionCount)
            {
                FetchQuestion();
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = true;
                    buttons[i].BackColor =  defaultColor;
                }
                stopTimer = false;
                NextButton.Visible = false;
            }
            else
            {
                gameOver = true;
                this.Hide();
                var gameResults = new GameResults();
                gameResults.ShowDialog();
                this.Close();
            }
        }
    }
}
