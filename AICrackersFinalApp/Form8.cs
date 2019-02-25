using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace AICrackersFinalApp
{
    public partial class Form8 : Form
    {
        static int no_questions;
        string[] questions;
        float[] inputs_loaded;
        static int index = 0;
        Form2 f2;

        public Form8(Form2 f)
        {
            f2 = f;
            string filename = "Arts.txt";
            string text = "";

            System.IO.StreamReader objReader;
            InitializeComponent();

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
        }

        public Form8()
        {
            string filename = "Arts.txt";
            string text = "";

            System.IO.StreamReader objReader;
            InitializeComponent();

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
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            try
            {
                button4.Visible = false;
                button5.Visible = false;
                pictureBox1.Visible = false;
            }
            catch
            {

            }
            label1.Text = questions[index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                label1.Text = questions[--index];
                if (index == 8)
                {
                    pictureBox1.Visible = true;
                    this.Width = this.Width * 3;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\Resources\Triads.png");
                    button5.Visible = false;
                }

                else if (index == 11)
                {
                    this.Width = this.Width * 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\carulboi.jpg");
                    button5.Visible = false;
                }

                else if (index == 13)
                {
                    this.Width = this.Width * 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\eggs.jpg");
                    button5.Visible = false;
                }

                else if (index == 14)
                {
                    this.Width = this.Width * 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\lilies.jpg");
                    button5.Visible = false;
                }

                else if (index == 15)
                {
                    this.Width = this.Width * 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\pieta.jpg");
                    button5.Visible = false;
                }

                else if (index == 4 || index == 9)
                {
                    button5.Visible = true;

                }

                else
                {
                    pictureBox1.Visible = false;
                    button5.Visible = false;
                }

            }

            else
            {
                pictureBox1.Visible = false;
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index < no_questions - 1)
            {

                button2.Enabled = true;

                label1.Text = questions[++index];
                if (index == 8)
                {
                    this.Width = this.Width * 3;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\Resources\Triads.png");
                    button5.Visible = false;
                }

                else if (index == 11)
                {
                    this.Width = this.Width * 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\carulboi.jpg");
                    button5.Visible = false;
                }

                else if (index == 13)
                {
                    this.Width = this.Width * 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\eggs.jpg");
                    button5.Visible = false;
                }

                else if (index == 14)
                {
                    this.Width = this.Width * 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\lilies.jpg");
                    button5.Visible = false;
                }

                else if (index == 15)
                {
                    this.Width = this.Width * 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\pieta.jpg");
                    button5.Visible = false;
                }


                else if (index == 4 || index == 9)
                {
                    pictureBox1.Visible = false;
                    button5.Visible = true;

                }

                else
                {
                    pictureBox1.Visible = false;
                    button5.Visible = false;
                }
            }

            else
            {
                button4.Visible = true;
                button2.Enabled = false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(index == 1)
            {
                string s = textBox1.Text.ToLower();
                if (s.Contains("no"))
                {
                    inputs_loaded[index] = 0;
                }

                else if (s.Contains("yes"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.3;

                    if (s.Contains("many"))
                    {
                        inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                    }

                    if (s.Contains("contest"))
                    {
                        inputs_loaded[index] = inputs_loaded[index] + (float)0.1;
                    }

                    double sentiment = f2.initTextAnalysis(s);
                    
                    if (sentiment > 0.6 && sentiment < 0.7)
                    {
                        inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                    }

                    else if (sentiment >= 0.7)
                    {
                        inputs_loaded[index] = inputs_loaded[index] + (float)0.4;
                    }

                }
            }

            else if (index == 4)
            {
                string s = textBox1.Text.ToLower();
                if (s.Contains("debussy"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.5;
                }
                else if (s.Contains ("debusy") || s.Contains("debusi"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.3;
                }

                if (s.Contains("clair") && s.Contains("lune"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.5;
                }
            }

            else if (index == 4)
            {
                button5.Visible = true;

            }

            else if (index == 5)
            {
                // Beethoven - wait for Adrian
            }

            else if (index == 6)
            {
                string s = textBox1.Text.ToLower();
                if (s.Contains("metallica"))
                {
                    inputs_loaded[index] = 1;
                }

                else if (s.Contains("metal"))
                {
                    inputs_loaded[index] = (float)0.2 ;
                }

                else
                {
                    inputs_loaded[index] = 0;
                }
            }

            else if (index == 7)
            {
                string s = textBox1.Text.ToLower();
                if (s.Contains("ton") || s.Contains("center"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.4;
                }

                if (s.Contains("scale") || s.Contains("degree"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.4;
                }

                if (s.Contains("resolution"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                }
            }

            else if (index == 8)
            {
                string s = textBox1.Text.ToLower();

                if (s.Contains("diatonic"))
                {
                    inputs_loaded[index] = 1;
                }

                else
                {
                    inputs_loaded[index] = 0;
                }

                this.Width = this.Width / 2;
                pictureBox1.Visible = false;

            }

            else if (index == 10)
            {
                // Singing Analysis;
            }

            else if (index == 11)
            {
                string s = textBox1.Text.ToLower();

                if (s.Contains("grigorescu"))
                {
                    inputs_loaded[index] = 1;
                }

                else
                {
                    inputs_loaded[index] = 0;
                }

                this.Width = this.Width / 2;
                pictureBox1.Visible = false;

            }

            else if (index == 12)
            {
                // Wait for Adrian
            }

            else if (index == 15)
            {
                string s = textBox1.Text.ToLower();

                inputs_loaded[index] = 0;

                if (s.Contains("pieta"))
                {
                    inputs_loaded[index] =  inputs_loaded[index] + (float)0.2;
                }

                if (s.Contains("michelangelo"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                }

                inputs_loaded[index] = inputs_loaded[index] + (float)(f2.initTextAnalysis(s)) - (float)0.4;

                this.Width = this.Width / 2;
                pictureBox1.Visible = false;
            }

            else if (index == 16)
            {
                string s = textBox1.Text.ToLower();
                if (s.Contains("inanimate") || s.Contains("man") || s.Contains("nature"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.5;

                    if (f2.initTextAnalysis(s) > 0.7)
                    {
                        inputs_loaded[index] = inputs_loaded[index] + (float)0.5;
                    }
                }

                else
                {
                    inputs_loaded[index] = 0;
                }
            }

            else if (index == 17)
            {
                string s = textBox1.Text.ToLower();
                if (s.Contains("pony") && s.Contains("tail"))
                {
                    inputs_loaded[index] = 1;

                }

                else
                {
                    inputs_loaded[index] = 0;
                }
            }

            else if (index == 20)
            {
                string s = textBox1.Text.ToLower();
                if (s.Contains("crown") && s.Contains("bible") && (s.Contains("angry") || s.Contains("mad")))
                {
                    inputs_loaded[index] = 1;

                }

                else
                {
                    inputs_loaded[index] = 0;
                }
            }

            else if (index == 19)
            {
                inputs_loaded[index] = 1;
            }

            else if (index == 18)
            {
                string s = textBox1.Text.ToLower();
                if (s.Contains("depth") && s.Contains("low"))
                {
                    inputs_loaded[index] = 1;

                }

                else
                {
                    inputs_loaded[index] = 0;
                }
            }

            else
            {
                inputs_loaded[index] = (float)f2.initTextAnalysis(textBox1.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 11; i++)
            {
                    f2.music_score = f2.music_score + inputs_loaded[i];
            }

            for (int i = 11; i < 22; i++)
            {
               f2.drawing_score = f2.drawing_score + inputs_loaded[i];
            }

            //f2.arts_score = (float)((f2.drawing_score + f2.music_score) / 2.0 * 100.0/11.0);
            int ss = (int)f2.arts_score;
            f2.setL4(ss.ToString() + "%");
            f2.setB3();

            f2.Visible = true;
            Dispose();
        }
    }
}
