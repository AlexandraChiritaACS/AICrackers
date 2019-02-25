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
    public partial class Form7 : Form
    {
        static int no_questions;
        string[] questions;
        float[] inputs_loaded;
        static int index = 0;
        Form2 f2;

        public Form7(Form2 f)
        {
            f2 = f;
            string filename = "Psihology.txt";
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

        public Form7()
        {
            string filename = "Psihology.txt";
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

        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                button3.Visible = false;
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

                button2.Enabled = true;
            
                label1.Text = questions[++index];
            }

            else
            {
                button3.Visible = true;
                button2.Enabled = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (index == 4)
            {
                string s = textBox1.Text.ToUpper();
                if (s.Contains("PLATO") || s.Contains("PLATON"))
                {
                    inputs_loaded[index] = 1;
                }

                else
                {
                    inputs_loaded[index] = 0;
                }
            }

            else if (index == 5)
            {
                // check in database - wait Adrian
                string s = textBox1.Text.ToUpper();
                inputs_loaded[index] = 1;
            }

            else if (index == 6)
            {

                string s = textBox1.Text.ToLower();

                if (s.Contains("empiric"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                }

                if (s.Contains("skeptic"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                }

                if (s.Contains("naturalism"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                }

                if (inputs_loaded[index] >= 0.4)
                {
                    // Emotional analysis
                    // +0.2 or 0.4

                    double sentiment = f2.initTextAnalysis(textBox1.Text);
                    if (sentiment > 0.6 && sentiment < 0.8)
                    {
                        inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                    }

                    else if (sentiment > 0.8)
                    {
                        inputs_loaded[index] = inputs_loaded[index] + (float)0.4;
                    }
                }
            }

            else if (index == 8)
            {
                string s = textBox1.Text.ToLower();

                if (s.Contains("physic"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                }

                if (s.Contains("logic"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                }

                if (s.Contains("moral"))
                {
                    inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                }

                if (inputs_loaded[index] >= 0.4)
                {
                    // Emotional analysis
                    // +0.2 or 0.4

                    double sentiment = f2.initTextAnalysis(textBox1.Text);
                    if (sentiment > 0.6 && sentiment < 0.8)
                    {
                        inputs_loaded[index] = inputs_loaded[index] + (float)0.2;
                    }

                    else if (sentiment > 0.8)
                    {
                        inputs_loaded[index] = inputs_loaded[index] + (float)0.4;
                    }
                }

            }

            else if (index == 9)
            {
                string s = textBox1.Text.ToLower();
                if (s.Contains("socrate"))
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

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                f2.philosophy_score = f2.philosophy_score + inputs_loaded[i];
            }

            for (int i = 10; i < 20; i++)
            {
                f2.psihology_score = f2.psihology_score + inputs_loaded[i];
            }

            f2.psihology_total_score = (float)((f2.psihology_score + f2.philosophy_score) / 2.0 * 10);
            int ss = (int)f2.psihology_total_score;
            f2.setL3(ss.ToString() + "%");
            f2.setB2();
            
            f2.Visible = true;
            Dispose();
        }
    }
}
