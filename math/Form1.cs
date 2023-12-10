using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace math
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Def
        private readonly Random random = new Random();
        private DateTime startTime;
        private Timer TimerNumberGenerator;

        //Asg
        public int iterations = 8;
        int CountCorrectAnswer = 0;
        int CountIncorrectAnswer = 0;
        int QuestionsCount = 0;
        int Answer = 0;
        public int AsgQCount = 5;
        public int RandStartNumber = 1;
        public int RandEndNumber = 500;
        public int _Itr = 8;
        public int _NumberShowSpeed = 400;

        private void Form1_Load(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            TimerCountDown.Start();
            GenerateNumbers();
        }      
       
        private void GenerateNumbers()
        {
            lblAnswer.Text = string.Empty;
            lblNumber.Text = string.Empty;  
            txtAnswer.Text = string.Empty;
            TimerNumberGenerator = new Timer();
            TimerNumberGenerator.Interval = _NumberShowSpeed;
            TimerNumberGenerator.Tick += TimerNumberGenerator_Tick;
            TimerNumberGenerator.Start();
        }

      
       
        private void TimerNumberGenerator_Tick(object sender, EventArgs e)
        {
            int randomNumber = random.Next(RandStartNumber, RandEndNumber);
            lblNumber.Text = randomNumber.ToString();
            Answer += randomNumber;           
            iterations--;           
            if (iterations <= 0)
            {
                ((Timer)sender).Stop(); 
                lblAnswer.Text = Answer.ToString();
                
            }
        }

       
        private void TimerCountDown_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            //lblTime.Text = $"Elapsed Time: {elapsedTime.Hours:D2}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
            lblTime.Text = $"Time:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
        }
        private void btnAnswer_Click(object sender, EventArgs e)
        {
            //Get a count of questions
            QuestionsCount++;
            lblQCount.Text = QuestionsCount.ToString();
            //match answer correct
            int inputAnswer = Convert.ToInt32(txtAnswer.Text);
            if (Answer == inputAnswer)
            {
                CountCorrectAnswer++;
            }
            else
            {
                CountIncorrectAnswer++;
            }

           // iterations = iterations;

            if (QuestionsCount < AsgQCount)
            {
                GenerateNumbers();
            }

            if (QuestionsCount == AsgQCount)
            {
                TimerCountDown.Stop();
                MessageBox.Show("Correct Answers: " + CountCorrectAnswer.ToString() + "\n" + "Incorrect Answers: " + CountIncorrectAnswer.ToString() + "\n" + "Your Time : " + lblTime.Text);
            }
        }
    }
}
