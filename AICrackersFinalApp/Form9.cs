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
    public partial class Form9 : Form
    {
        static int no_questions;
        string[] questions;
        float[] inputs_loaded;
        static int index = 0;
        Form2 f2;

        public Form9()
        {
            string filename = "Philology.txt";
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

        public Form9(Form2 f)
        {
            f2 = f;
            string filename = "Philology.txt";
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

        private void Form9_Load(object sender, EventArgs e)
        {
            try
            {
                button4.Visible = false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            // ... interpret answers

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
