using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMindUI
{
    public partial class MasterMindForm : Form
    {
        int[] numbers = new int[4];
        List<string> guesses = new List<string>();
        bool gameStarted = false;
        
        public MasterMindForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            numbers[0] = rnd.Next(1, 10);

            numbers[1] = rnd.Next(0, 10);
            while (numbers[1] == numbers[0])
                numbers[1] = rnd.Next(0, 10);

            numbers[2] = rnd.Next(0, 10);
            while (numbers[2] == numbers[0] || numbers[2] == numbers[1])
                numbers[2] = rnd.Next(0, 10);
            
            numbers[3] = rnd.Next(0, 10);
            while (numbers[3] == numbers[0] || numbers[3] == numbers[1] || numbers[3] == numbers[2])
                numbers[3] = rnd.Next(0, 10);

            textBoxNo1.Text = "";
            textBoxNo2.Text = "";
            textBoxNo3.Text = "";
            textBoxNo4.Text = "";

            listBoxGuesses.Items.Clear();
            guesses.Clear();
            labelSentence.Text = "Guess this 4 digit number.";

            labelCongrats.Text = "";
            labelNumberGuesses.Text = "";
            labelPositive.Text = "";
            labelNegative.Text = "";

            resetColor();
            gameStarted = true;
            buttonPlay.Enabled = true;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                MessageBox.Show("Press Start first!");
            }

            else if (validateForm())
            {
                matchNumber();

                listBoxGuesses.Items.Clear();
                foreach (string guess in guesses)
                {
                    listBoxGuesses.Items.Add(guess);
                }
            }
            else
            {
                MessageBox.Show("Invalid Entry!");
            }

            textBoxNo1.Text = "";
            textBoxNo2.Text = "";
            textBoxNo3.Text = "";
            textBoxNo4.Text = "";
        }

        private bool validateForm()
        {
            bool valid = true;
            int number1, number2, number3, number4;

            bool validNo1 = int.TryParse(textBoxNo1.Text, out number1);
            bool validNo2 = int.TryParse(textBoxNo2.Text, out number2);
            bool validNo3 = int.TryParse(textBoxNo3.Text, out number3);
            bool validNo4 = int.TryParse(textBoxNo4.Text, out number4);

            if (number1 == number2 || number1 == number3 || number1 == number4 || number2 == number3 || number2 == number4 || number3 == number4)
            {
                valid = false;
            }

            if (!validNo1 || !validNo2 || !validNo3 || !validNo4)
            {
                valid = false;
            }

            if (number1 < 1 || number1 > 9)
            {
                valid = false;
            }

            if (number2 < 0 || number2 > 9)
            {
                valid = false;
            }

            if (number3 < 0 || number3 > 9)
            {
                valid = false;
            }

            if (number4 < 0 || number4 > 9)
            {
                valid = false;
            }

            return valid;
        }

        private void matchNumber()
        {
            int fullMatch = 0;
            int semiMatch = 0;

            if (numbers[0] == int.Parse(textBoxNo1.Text))
            {
                fullMatch++;
            }
            else if (numbers[0] == int.Parse(textBoxNo2.Text) || numbers[0] == int.Parse(textBoxNo3.Text) || numbers[0] == int.Parse(textBoxNo4.Text))
            {
                semiMatch++;
            }

            if (numbers[1] == int.Parse(textBoxNo2.Text))
            {
                fullMatch++;
            }
            else if (numbers[1] == int.Parse(textBoxNo1.Text) || numbers[1] == int.Parse(textBoxNo3.Text) || numbers[1] == int.Parse(textBoxNo4.Text))
            {
                semiMatch++;
            }

            if (numbers[2] == int.Parse(textBoxNo3.Text))
            {
                fullMatch++;
            }
            else if (numbers[2] == int.Parse(textBoxNo1.Text) || numbers[2] == int.Parse(textBoxNo2.Text) || numbers[2] == int.Parse(textBoxNo4.Text))
            {
                semiMatch++;
            }

            if (numbers[3] == int.Parse(textBoxNo4.Text))
            {
                fullMatch++;
            }
            else if (numbers[3] == int.Parse(textBoxNo1.Text) || numbers[3] == int.Parse(textBoxNo2.Text) || numbers[3] == int.Parse(textBoxNo3.Text))
            {
                semiMatch++;
            }

            string resultFull = fullMatch.ToString();
            string resultSemi = semiMatch.ToString();
            labelPositive.Text = "+" + resultFull;
            labelNegative.Text = "-" + resultSemi;

            string guess = $"{textBoxNo1.Text}{textBoxNo2.Text}{textBoxNo3.Text}{textBoxNo4.Text}   +{resultFull} -{resultSemi}";
            guesses.Add(guess);
            int numberGuesses = listBoxGuesses.Items.Count;

            if (fullMatch == 4)
            {
                labelCongrats.Text = "Congratulations!";
                labelNumberGuesses.Text = $"You got it in {numberGuesses + 1} guesses...";
                buttonPlay.Enabled = false;
            }            
        }

        private void button0_Click(object sender, EventArgs e)
        {
            switchColor(button0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switchColor(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switchColor(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switchColor(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switchColor(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switchColor(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            switchColor(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            switchColor(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            switchColor(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            switchColor(button9);
        }

        private void switchColor(Button button)
        {
            if (button.BackColor.Name == "ButtonHighlight")
            {
                button.BackColor = Color.Gray;
            }
            else if (button.BackColor.Name == "Gray")
            {
                button.BackColor = Color.Green;
            }
            else if (button.BackColor.Name == "Green")
            {
                button.BackColor = Color.Red;
            }
            else
            {
                button.BackColor = Color.FromName("ButtonHighlight");
            }
        }

        private void resetColor()
        {
            button0.BackColor = Color.FromName("ButtonHighlight");
            button1.BackColor = Color.FromName("ButtonHighlight");
            button2.BackColor = Color.FromName("ButtonHighlight");
            button3.BackColor = Color.FromName("ButtonHighlight");
            button4.BackColor = Color.FromName("ButtonHighlight");
            button5.BackColor = Color.FromName("ButtonHighlight");
            button6.BackColor = Color.FromName("ButtonHighlight");
            button7.BackColor = Color.FromName("ButtonHighlight");
            button8.BackColor = Color.FromName("ButtonHighlight");
            button9.BackColor = Color.FromName("ButtonHighlight");
        }
    }
}
