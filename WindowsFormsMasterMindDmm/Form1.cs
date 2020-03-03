using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsMasterMindDmm
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        int attempts = 0;
        int[] answer = new int[4];
        int[] guess = new int[4];
        char[] answerKey = new char[4];
        char[] guessKey = new char[4];

        const int MAX_ATTEMPTS = 10;
        const char A_SPACE = ' ';
        const char PLUS = '+';
        const char MINUS = '-';


        public Form1()
        {
            InitializeComponent();

            answer[0] = rnd.Next(1, 6);
            answer[1] = rnd.Next(1, 6);
            answer[2] = rnd.Next(1, 6);
            answer[3] = rnd.Next(1, 6);
            progressBar1.Value = MAX_ATTEMPTS;
            labelAttemptsLeft.Text = String.Format("{0} Attempts left", MAX_ATTEMPTS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                guess[0] = (int)numericUpDown1.Value;
                guess[1] = (int)numericUpDown2.Value;
                guess[2] = (int)numericUpDown3.Value;
                guess[3] = (int)numericUpDown4.Value;

                answerKey[0] = answerKey[1] = answerKey[2] = answerKey[3] = guessKey[0] = guessKey[1] = guessKey[2] = guessKey[3] = A_SPACE;

                if (compareAnswerAndGuess())
                {

                    MessageBox.Show("Combination found, you are a BIG WINNER!!!", "", MessageBoxButtons.OK);
                    Application.Exit();
                }
                else
                {
                    ++attempts;
                    labelAttemptsLeft.Text = String.Format("{0} Attempts left", MAX_ATTEMPTS - attempts);
                    progressBar1.Value = MAX_ATTEMPTS - attempts;

                    switch (guessKey[0])
                    {
                        case A_SPACE:
                            label1.Visible = false;
                            break;
                        case PLUS:
                            label1.Visible = true;
                            label1.Text = "+";
                            break;
                        case MINUS:
                            label1.Visible = true;
                            label1.Text = "-";
                            break;
                    }
                    switch (guessKey[1])
                    {
                        case A_SPACE:
                            label2.Visible = false;
                            break;
                        case PLUS:
                            label2.Visible = true;
                            label2.Text = "+";
                            break;
                        case MINUS:
                            label2.Visible = true;
                            label2.Text = "-";
                            break;
                    }
                    switch (guessKey[2])
                    {
                        case A_SPACE:
                            label3.Visible = false;
                            break;
                        case PLUS:
                            label3.Visible = true;
                            label3.Text = "+";
                            break;
                        case MINUS:
                            label3.Visible = true;
                            label3.Text = "-";
                            break;
                    } //end switch (guessKey[2]
                    switch (guessKey[3])
                    {
                        case A_SPACE:
                            label4.Visible = false;
                            break;
                        case PLUS:
                            label4.Visible = true;
                            label4.Text = "+";
                            break;
                        case MINUS:
                            label4.Visible = true;
                            label4.Text = "-";
                            break;
                    }// end switch (guessKey[3])
                } //end else

                if (attempts > 9)
                {
                    String msg = String.Format("You've lost, your guesses have expired.  The combination was {0} {1} {2} {3}", answer[0], answer[1], answer[2], answer[3]);
                    MessageBox.Show(msg, "", MessageBoxButtons.OK);
                    Application.Exit();
                }
            } //end try
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Exception Occurred", MessageBoxButtons.OK);
                Application.Exit();
            } //end catch (Exception e)

        } //end private void button1_Click(object sender, EventArgs e)

        private bool compareAnswerAndGuess()
        {
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (guess[i] == answer[i])
                        answerKey[i] = guessKey[i] = PLUS;
                } //end for (int i = 0; i < 4; i++)

                for (int i = 0; i < 4; i++)
                {
                    if (guessKey[i] == PLUS)
                        continue;

                    for (int j = 0; j < 4; j++)
                    {
                        if ((answerKey[j] != PLUS) && (answerKey[j] != MINUS))
                        {
                            if (guess[i] == answer[j])
                            {
                                guessKey[i] = MINUS;
                                answerKey[j] = MINUS;
                                break;
                            } //end if (guess[i] == answer[j])
                        } //end if ((answerKey[j] != PLUS) && (answerKey[j] != MINUS))
                    } //end for (int j = 0; j < 4; j++)
                } //end for (int i = 0; i < 4; i++)

                return answer.SequenceEqual(guess);
            } //end try
            catch (Exception e)
            {
                throw e;
            } //end catch (Exception e)
        }
    }
}
