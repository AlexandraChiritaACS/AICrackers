using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AICrackersFinalApp
{
    public partial class Form5 : Form
    {
        Form2 f2;
        float[] outputs;
        float[] inputs;
        public Form5(float[] outputs, float[] inputs)
        {
            this.outputs = outputs;
            this.inputs = inputs;
            InitializeComponent();
        }

        public Form5(float[] outputs, float[] inputs, Form2 f)
        {
            this.outputs = outputs;
            this.inputs = inputs;
            InitializeComponent();
            f2 = f;
        }

        public float Maximum(float[] outputs)
        {
            float maxim = -1;
            for (int i = 0; i < outputs.Length; i++)
            {
                if (maxim < outputs[i])
                    maxim = outputs[i];
            }

            return maxim;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            this.chart1.Series[0].LegendText = "%";
            this.chart1.Series["Series1"].Points.AddXY("Building", outputs[0]);
            this.chart1.Series["Series1"].Points.AddXY("Theoretical", outputs[1]);
            this.chart1.Series["Series1"].Points.AddXY("Artistic", outputs[2]);
            this.chart1.Series["Series1"].Points.AddXY("Helping & Caring", outputs[3]);
            this.chart1.Series["Series1"].Points.AddXY("Persuading", outputs[4]);
            this.chart1.Series["Series1"].Points.AddXY("Organiser", outputs[5]);



            int code = 0;
            if (Maximum(outputs) == outputs[0])
            {
                code = 0;

            }

            if (Maximum(outputs) == outputs[1])
            {
                code = 1;
            }

            if (Maximum(outputs) == outputs[2])
            {
                code = 2;
            }

            if (Maximum(outputs) == outputs[3])
            {
                code = 3;
            }

            if (Maximum(outputs) == outputs[4])
            {
                code = 4;
            }

            if (Maximum(outputs) == outputs[5])
            {
                code = 5;
            }

            if (code == 0)
            {
                MessageBox.Show("The most suitable Univesity for you is Architecture or Engineering School (for instance ACS). You are creative, but also pragmatic, dynamic.");

            }

            else if (code == 1)
            {
                MessageBox.Show("The most suitable Univesity for you is Mathematics or Phisics. You are analitical and you like abstract notions.");

            }
            else if (code == 2)
            {
                MessageBox.Show("The most suitable Univesity for you is Music/ Drama College. You are inventive, extrovert and dynamic.");
            }

            else if (code == 3)
            {
                MessageBox.Show("The most suitable Univesity for you is Medicine/Nurcery School. You are extremely carring, but also theoretical and dynamic.");
            }

            else if (code == 4)
            {
                MessageBox.Show("The most suitable Univesity for you is Law School. You are creative and dynamic. You know how to make things work");
            }

            else if (code == 5)
            {
                MessageBox.Show("The most suitable Univesity for you is Economics. You are well-calculated and care about details.");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();

            f2.holland_test_results[0] = outputs[0];
            f2.holland_test_results[1] = outputs[1];
            f2.holland_test_results[2] = outputs[2];
            f2.holland_test_results[3] = outputs[3];
            f2.holland_test_results[4] = outputs[4];
            f2.holland_test_results[5] = outputs[5];

            f2.setB1();
            f2.Visible = true;
            //f2.ShowDialog();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "careernet.database.windows.net";
                builder.UserID = "alex_admin";
                builder.Password = "Mamasita-123";
                builder.InitialCatalog = "Career_Test_Data";
                string s1 = textBox1.Text;
                string s2 = textBox2.Text;
                string s3 = textBox3.Text;

                string values = "VALUES (" + "'" + Guid.NewGuid().ToString() + "'" + "," + "'" + s1 + "'" + "," + "'" + s2 + "'" + "," + "'" + inputs.ToString() + "'" + "," + "'" + outputs.ToString() + "'" + "," + "'" + s3 + "'" + ");";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO DATA_NET (PERSONID, FIRSTNAME, LASTNAME, FEATURESTEST, OUTPUT_RESULTS, UNIVERSITY, GENDER) ");
                    sb.Append(values);


                }
            }
            catch
            {

            }

            finally
            {
                MessageBox.Show("End of registration");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }*/
    }
}
