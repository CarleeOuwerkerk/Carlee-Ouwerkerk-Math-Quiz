using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carlee_Ouwerkerk_Math_Quiz
{
    public partial class Form1 : Form
    {

        Random randomizer = new Random();

        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;

        public void StartTheQuiz()
        {
            // fills in addition problems
            // generates random numbers
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            
            // convert random numbers to strings
            // set label text to strings
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // sets sum label to 0
            sum.Value = 0;

            // subtraction
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // multiplication
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // division
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // starts the timer
            timeLeft = 30;
            timeLabel1.Text = "30 seconds";
            timer1.Start();
        }

        public Form1()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
            timeLabel1.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (CheckTheAnswer())
            {
                // if user got right answer, stop timer, show message
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // updates and displays time left
                timeLeft--;
                timeLabel1.Text = timeLeft + " seconds";

                if (timeLeft <= 5)
                {
                    timeLabel1.BackColor = Color.Red;
                }
            }
            else
            {
                // if user runs out of time
                timer1.Stop();
                timeLabel1.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                // will replace what's in box with new answer
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if (sum.Value == addend1 + addend2)
            {
                playSound();
            }
        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {
            if (difference.Value == minuend - subtrahend)
            {
                playSound();
            }
        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
            if (product.Value == multiplicand * multiplier)
            {
                playSound();
            }
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            if (quotient.Value == dividend / divisor)
            {
                playSound();
            }
        }

        private void playSound()
        {
            // I realize this mapping won't work if you clone my project, but it did work on mine.
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer();
            sound.SoundLocation = "C:\\Users\\Carlee\\source\\repos\\Carlee Ouwerkerk Math Quiz\\0944.wav";
            sound.Load();
            sound.Play();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}