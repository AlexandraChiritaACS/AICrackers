using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AICrackersFinalApp
{


    public partial class Form4 : Form
    {
        static int no_questions;
        string[] questions;
        float[] inputs_loaded;
        static int index = 0;
        private DateTime start = DateTime.Now;
        NeuralNetwork net;
        Form2 f2;
        public Form4()
        {
            //string w_file = "TextFile1.txt";
            string filename = "Questions.txt";
            string text = "";


            net = new NeuralNetwork(new int[] { 45, 45, 45, 6 });

            System.IO.StreamReader objReader;
            //objReader = new System.IO.StreamReader(w_file);
            //net.set(int.Parse(objReader.ReadLine()));
            //objReader.Close();

            //System.IO.File.WriteAllBytes(w_file, new byte[0]);

            //File.WriteAllText(w_file, "0");


            if (net.get() == 1)
            {

                net.set(0);

                float[] t1 = new float[] { 5, 5, 3, 3, 3, 4, 2, 1, 5, 2, 4, 3, 2, 1, 5, 3, 2, 1, 1, 1, 1, 1, 4, 3, 4, 3, 1, 2, 1, 3, 5, 3, 3, 2, 4, 5, 5, 0.00300731952f, 5.14648448E-08f, 9.180124E-06f, 0.0001912825f, 0.9875571f, 0.0009861537f, 1.889955E-05f, 0.008229999f };
                float[] t2 = new float[] { 1, 3, 4, 5, 3, 3, 2, 3, 5, 4, 1, 4, 3, 2, 3, 3, 4, 3, 4, 2, 2, 1, 2, 5, 5, 1, 1, 2, 1, 4, 3, 5, 5, 5, 2, 5, 1, 0.0300731952f, 5.14648448E-09f, 0.0002323f, 0.0012825f, 0.98750001f, 0.00000001537f, 1.880005E-05f, 0.00822000f };
                float[] t3 = new float[] { 1, 1, 1, 4, 2, 5, 3, 4, 3, 5, 3, 4, 2, 4, 5, 2, 4, 5, 2, 3, 2, 3, 4, 5, 2, 3, 4, 5, 3, 2, 3, 4, 5, 2, 1, 2, 1, 0.00331952f, 5.1932448448E-04f, 9.183240124E-09f, 0.0001912f, 0.98755f, 0.0009867f, 1.889955f, 0.00899f };
                float[] t4 = new float[] { 5, 5, 4, 3, 4, 5, 3, 4, 3, 4, 5, 5, 5, 4, 5, 3, 4, 5, 4, 4, 5, 4, 5, 4, 3, 4, 3, 4, 3, 4, 5, 5, 5, 4, 4, 5, 4, 0.00300731952f, 5.14648448E-08f, 9.180124E-06f, 0.0001912825f, 0.9875571f, 0.0009861537f, 1.889955E-05f, 0.008229999f };
                float[] t5 = new float[] { 3, 3, 4, 2, 3, 3, 3, 3, 1, 1, 2, 2, 3, 3, 3, 3, 4, 4, 3, 3, 4, 3, 4, 3, 5, 5, 3, 4, 3, 4, 3, 5, 3, 4, 3, 5, 4, 0.03243231952f, 5.12344648448E-08f, 9.180123424E-06f, 0.0034201912825f, 0.98755271f, 0.061537f, 1.855E-05f, 0.0089f };
                float[] t6 = new float[] { 1, 1, 2, 5, 3, 5, 2, 3, 4, 1, 2, 5, 3, 2, 4, 3, 1, 2, 1, 1, 1, 3, 2, 4, 2, 4, 5, 3, 2, 3, 1, 2, 4, 1, 3, 2, 4, 0.0731952f, 5.1464E-08f, 9.184E-06f, 0.01912825f, 0.987571f, 0.0009537f, 1.89955E-05f, 0.0082294999f };
                float[] t7 = new float[] { 5, 5, 5, 5, 5, 3, 4, 4, 4, 4, 5, 5, 2, 3, 5, 5, 5, 5, 4, 3, 4, 5, 3, 4, 5, 5, 4, 5, 4, 5, 3, 4, 5, 3, 4, 5, 3, 0.00230731952f, 5.23448448E-08f, 9.123424E-06f, 0.0002342825f, 0.9234875571f, 0.00234409861537f, 1.889923432455E-05f, 0.008229992349f };
                float[] t8 = new float[] { 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 4, 3, 2, 3, 2, 1, 1, 1, 2, 3, 1, 2, 3, 1, 2, 3, 4, 5, 5, 5, 1, 1, 1, 1, 2, 3, 2, 0.0030078831952f, 5.14648499948E-08f, 9.140080124E-06f, 0.0001912990825f, 0.98099075571f, 0.000090809861537f, 1.88995098805E-05f, 0.008298729999f };
                float[] r1 = new float[] { 3, 4, 3, 2, 3, 3 };
                float[] r2 = new float[] { 5, 3, 2, 3, 4, 5 };
                float[] r3 = new float[] { 3, 1, 2, 1, 2, 3 };
                float[] r4 = new float[] { 3, 3, 2, 4, 3, 4 };
                float[] r5 = new float[] { 4, 4, 3, 3, 2, 3 };
                float[] r6 = new float[] { 2, 3, 2, 3, 4, 2 };
                float[] r7 = new float[] { 3, 4, 5, 5, 5, 4 };
                float[] r8 = new float[] { 1, 2, 1, 1, 2, 2 };

                for (int i = 0; i < 100; i++)
                {
                    net.FeedForward(t1);
                    net.BP(r1);

                    net.FeedForward(t2);
                    net.BP(r2);

                    net.FeedForward(t3);
                    net.BP(r3);

                    net.FeedForward(t4);
                    net.BP(r4);

                    net.FeedForward(t5);
                    net.BP(r5);

                    net.FeedForward(t6);
                    net.BP(r6);

                    net.FeedForward(t7);
                    net.BP(r7);

                    net.FeedForward(t8);
                    net.BP(r8);


                }


            }

            net.set(0);

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

        public Form4(Form2 f)
        {
            f2 = f;
            //string w_file = "TextFile1.txt";
            string filename = "Questions.txt";
            string text = "";


            net = new NeuralNetwork(new int[] { 45, 45, 45, 6 });

            System.IO.StreamReader objReader;
            //objReader = new System.IO.StreamReader(w_file);
            //net.set(int.Parse(objReader.ReadLine()));
            //objReader.Close();

            //System.IO.File.WriteAllBytes(w_file, new byte[0]);

            //File.WriteAllText(w_file, "0");


            if (net.get() == 1)
            {

                net.set(0);

                float[] t1 = new float[] { 5, 5, 3, 3, 3, 4, 2, 1, 5, 2, 4, 3, 2, 1, 5, 3, 2, 1, 1, 1, 1, 1, 4, 3, 4, 3, 1, 2, 1, 3, 5, 3, 3, 2, 4, 5, 5, 0.00300731952f, 5.14648448E-08f, 9.180124E-06f, 0.0001912825f, 0.9875571f, 0.0009861537f, 1.889955E-05f, 0.008229999f };
                float[] t2 = new float[] { 1, 3, 4, 5, 3, 3, 2, 3, 5, 4, 1, 4, 3, 2, 3, 3, 4, 3, 4, 2, 2, 1, 2, 5, 5, 1, 1, 2, 1, 4, 3, 5, 5, 5, 2, 5, 1, 0.0300731952f, 5.14648448E-09f, 0.0002323f, 0.0012825f, 0.98750001f, 0.00000001537f, 1.880005E-05f, 0.00822000f };
                float[] t3 = new float[] { 1, 1, 1, 4, 2, 5, 3, 4, 3, 5, 3, 4, 2, 4, 5, 2, 4, 5, 2, 3, 2, 3, 4, 5, 2, 3, 4, 5, 3, 2, 3, 4, 5, 2, 1, 2, 1, 0.00331952f, 5.1932448448E-04f, 9.183240124E-09f, 0.0001912f, 0.98755f, 0.0009867f, 1.889955f, 0.00899f };
                float[] t4 = new float[] { 5, 5, 4, 3, 4, 5, 3, 4, 3, 4, 5, 5, 5, 4, 5, 3, 4, 5, 4, 4, 5, 4, 5, 4, 3, 4, 3, 4, 3, 4, 5, 5, 5, 4, 4, 5, 4, 0.00300731952f, 5.14648448E-08f, 9.180124E-06f, 0.0001912825f, 0.9875571f, 0.0009861537f, 1.889955E-05f, 0.008229999f };
                float[] t5 = new float[] { 3, 3, 4, 2, 3, 3, 3, 3, 1, 1, 2, 2, 3, 3, 3, 3, 4, 4, 3, 3, 4, 3, 4, 3, 5, 5, 3, 4, 3, 4, 3, 5, 3, 4, 3, 5, 4, 0.03243231952f, 5.12344648448E-08f, 9.180123424E-06f, 0.0034201912825f, 0.98755271f, 0.061537f, 1.855E-05f, 0.0089f };
                float[] t6 = new float[] { 1, 1, 2, 5, 3, 5, 2, 3, 4, 1, 2, 5, 3, 2, 4, 3, 1, 2, 1, 1, 1, 3, 2, 4, 2, 4, 5, 3, 2, 3, 1, 2, 4, 1, 3, 2, 4, 0.0731952f, 5.1464E-08f, 9.184E-06f, 0.01912825f, 0.987571f, 0.0009537f, 1.89955E-05f, 0.0082294999f };
                float[] t7 = new float[] { 5, 5, 5, 5, 5, 3, 4, 4, 4, 4, 5, 5, 2, 3, 5, 5, 5, 5, 4, 3, 4, 5, 3, 4, 5, 5, 4, 5, 4, 5, 3, 4, 5, 3, 4, 5, 3, 0.00230731952f, 5.23448448E-08f, 9.123424E-06f, 0.0002342825f, 0.9234875571f, 0.00234409861537f, 1.889923432455E-05f, 0.008229992349f };
                float[] t8 = new float[] { 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 4, 3, 2, 3, 2, 1, 1, 1, 2, 3, 1, 2, 3, 1, 2, 3, 4, 5, 5, 5, 1, 1, 1, 1, 2, 3, 2, 0.0030078831952f, 5.14648499948E-08f, 9.140080124E-06f, 0.0001912990825f, 0.98099075571f, 0.000090809861537f, 1.88995098805E-05f, 0.008298729999f };
                float[] r1 = new float[] { 3, 4, 3, 2, 3, 3 };
                float[] r2 = new float[] { 5, 3, 2, 3, 4, 5 };
                float[] r3 = new float[] { 3, 1, 2, 1, 2, 3 };
                float[] r4 = new float[] { 3, 3, 2, 4, 3, 4 };
                float[] r5 = new float[] { 4, 4, 3, 3, 2, 3 };
                float[] r6 = new float[] { 2, 3, 2, 3, 4, 2 };
                float[] r7 = new float[] { 3, 4, 5, 5, 5, 4 };
                float[] r8 = new float[] { 1, 2, 1, 1, 2, 2 };

                for (int i = 0; i < 100; i++)
                {
                    net.FeedForward(t1);
                    net.BP(r1);

                    net.FeedForward(t2);
                    net.BP(r2);

                    net.FeedForward(t3);
                    net.BP(r3);

                    net.FeedForward(t4);
                    net.BP(r4);

                    net.FeedForward(t5);
                    net.BP(r5);

                    net.FeedForward(t6);
                    net.BP(r6);

                    net.FeedForward(t7);
                    net.BP(r7);

                    net.FeedForward(t8);
                    net.BP(r8);


                }


            }

            net.set(0);

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

        private void Form4_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome! We are pleased that you have choosen out test. Let's start the journey together!");
            try
            {
                button3.Visible = false;
            }
            catch
            {

            }
            label1.Text = questions[index];
        }

        


        
        private void button2_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (index > 0)
            {
                button1.Enabled = true;
                label1.Text = questions[--index];
            }

            else
            {
                button1.Enabled = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           


            for (int j = 0; j < no_questions; j++)
            {
                inputs_loaded[j] = inputs_loaded[j];

            }

            float[] outputs = net.LoadSolution(inputs_loaded);
            Hide();
            Form5 results = new Form5(outputs, inputs_loaded, f2);
            results.Visible = true;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            inputs_loaded[index] = 1;
            start = DateTime.Now;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            inputs_loaded[index] = 2;
            start = DateTime.Now;
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            inputs_loaded[index] = 3;
            start = DateTime.Now;
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            inputs_loaded[index] = 4;
            start = DateTime.Now;
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            inputs_loaded[index] = 5;
            start = DateTime.Now;
        }
    }
}
