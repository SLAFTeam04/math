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
        private readonly Random random = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowNumbers();
        }
        private Timer timer;
        private void ShowNumbers()
        {
            lblAnswer.Text = string.Empty;
            lblNumber.Text = string.Empty;  
            textBoxUserAnswer.Text = string.Empty;
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

      
        private int iterations = 8;

        int CountCorrectAnswer=0;
        int CountIncorrectAnswer=0;
        int QestionCount = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            QestionCount++;
            lblQCount.Text = QestionCount.ToString();

            if (QestionCount == 3)
            {
                MessageBox.Show("Correct Answers: " + CountCorrectAnswer.ToString() + "\n" + "Incorrect Answers: " + CountIncorrectAnswer.ToString());
            }
            else
            {
                int inputAnswer = Convert.ToInt32(textBoxUserAnswer.Text);
                if (Answer == inputAnswer)
                {
                    CountCorrectAnswer++;
                }
                else
                {
                    CountIncorrectAnswer++;
                }

                iterations = 8;

               
                if (QestionCount < 3)
                {
                    ShowNumbers();
                }
            }


        }
        int Answer = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            int randomNumber = random.Next(-10, 11);
            lblNumber.Text = randomNumber.ToString();
            Answer += randomNumber;           
            iterations--;           
            if (iterations <= 0)
            {
                ((Timer)sender).Stop(); 
                lblAnswer.Text = Answer.ToString();                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iterations = 8;
            ShowNumbers();
        }
    }
}
