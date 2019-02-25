using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AICrackersFinalApp
{
    public partial class Form6 : Form
    {
        static int no_questions;
        string[] questions;
        float[] inputs_loaded;
        static int index = 0;
        static int idx = 0;
        Form2 f2;
        private float[] answers1 = new float[] { 1, 4, 1, 1, 1, 2, 1, 1, 2, 2, 1, 4, 1, 3, 2 };
        private float[] answers3 = new float[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2, 3, 4, 2 };
        private float[] answers2 = new float[] { 4, 2, 3, 2, 2, 2, 1, 3, 4, 2, 2, 1, 1, 2, 2 };

        public Form6()
        {
            string filename = "Science.txt";
            string text = "";
            System.IO.StreamReader objReader;

            if (System.IO.File.Exists(filename) == true)
            {
                //System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(filename);
                no_questions = int.Parse(objReader.ReadLine());
                questions = new string[no_questions];
                inputs_loaded = new float[no_questions + 8];

                int i = 0;

                do
                {
                    text = objReader.ReadLine();
                    questions[i++] = text;
                } while (objReader.Peek() != -1);

                objReader.Close();
            }

            else
            {
                MessageBox.Show("No such file " + filename);
            }
            InitializeComponent();
        }

        public Form6(Form2 f)
        {
            f2 = f;
            string filename = "Science.txt";
            string text = "";
            System.IO.StreamReader objReader;

            if (System.IO.File.Exists(filename) == true)
            {
                //System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(filename);
                no_questions = int.Parse(objReader.ReadLine());
                questions = new string[no_questions * 5 + 10];
                inputs_loaded = new float[no_questions + 8];
                
                int i = 0;
                no_questions = no_questions * 5;

                do
                {
                    text = objReader.ReadLine();
                    questions[i++] = text;
                } while (objReader.Peek() != -1);
                
                objReader.Close();
            }

            else
            {
                MessageBox.Show("No such file " + filename);
            }
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            try
            {
                button3.Visible = false;
            }
            catch
            {

            }
            label1.Text = questions[index];
            radioButton1.Text = questions[++index];
            radioButton2.Text = questions[++index];
            radioButton3.Text = questions[++index];
            radioButton4.Text = questions[++index];
            idx++;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          
            inputs_loaded[idx] = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            inputs_loaded[idx] = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            inputs_loaded[idx] = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            inputs_loaded[idx] = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index > 4)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                index = index - 10;
                label1.Text = questions[++index];
                radioButton1.Text = questions[++index];
                radioButton2.Text = questions[++index];
                radioButton3.Text = questions[++index];
                radioButton4.Text = questions[++index];
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                idx--;

            }

            else
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index < no_questions - 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                label1.Text = questions[++index];
                radioButton1.Text = questions[++index];
                radioButton2.Text = questions[++index];
                radioButton3.Text = questions[++index];
                radioButton4.Text = questions[++index];
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                idx++;
            }

            else
            {
                button3.Visible = true;
                button2.Enabled = false;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            float score1 = 0;
            float score2 = 0;
            float score3 = 0;
            float score = 0;
            for (int i = 0; i < 15; i++)
            {
                if (inputs_loaded[i] == answers1[i])
                {
                    score1++;
                }
            }

            score1 = (float)((100.0 * score1) / 15.0);

            for (int i = 0; i < 15; i++)
            {
                if (inputs_loaded[i + 15] == answers2[i])
                {
                    score2++;
                }
            }

            score2 = (float)((100.0 * score2) / 15.0);

            for (int i = 0; i < 15; i++)
            {
                if (inputs_loaded[i + 30] == answers3[i])
                {
                    score3++;
                }
            }

            score3 = (float)((100.0 * score3) / 15.0);
            score = score1 + score2 + score3;
            score = (float)(score / 3.0);

            f2.science_score = score;

            f2.chemistry_score = score1;
            f2.biology_score = score2;
            f2.physics_score = score3;

            int ss = (int)score;

            f2.setL1(ss.ToString() + "%");
            f2.setB5();
            f2.Visible = true;
            Dispose();
        }
    }
}
