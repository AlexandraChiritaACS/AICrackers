using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICrackersFinalApp
{
    class NeuralNetwork
    {
        public int[] layer;
        Layer[] layers;
        private int net_neural;
        public NeuralNetwork(int[] layer)
        {
            net_neural = 1;

            this.layer = new int[layer.Length];
            for (int i = 0; i < layer.Length; i++)
            {
                this.layer[i] = layer[i];
            }

            layers = new Layer[layer.Length - 1];
            for (int i = 0; i < layers.Length; i++)
            {
                layers[i] = new Layer(layer[i], layer[i + 1]);
            }

            if (net_neural == 0)
            {
                string w_file = "W1.txt";
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(w_file);

                for (int i = 0; i < layers[0].weigths.GetLength(0); i++)
                {
                    string s = objReader.ReadLine();
                    string[] integerStrings = s.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < layers[0].weigths.GetLength(1); j++)
                    {
                        layers[0].weigths[i, j] = int.Parse(integerStrings[j]);
                    }
                }

                objReader.Close();

                w_file = "W2.txt";

                objReader = new System.IO.StreamReader(w_file);

                for (int i = 0; i < layers[1].weigths.GetLength(0); i++)
                {
                    string s = objReader.ReadLine();
                    string[] integerStrings = s.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < layers[1].weigths.GetLength(1); j++)
                    {
                        layers[1].weigths[i, j] = int.Parse(integerStrings[j]);
                    }
                }

                objReader.Close();

                w_file = "W3.txt";

                objReader = new System.IO.StreamReader(w_file);

                for (int i = 0; i < layers[2].weigths.GetLength(0); i++)
                {
                    string s = objReader.ReadLine();
                    string[] integerStrings = s.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < layers[2].weigths.GetLength(1); j++)
                    {
                        layers[2].weigths[i, j] = int.Parse(integerStrings[j]);
                    }
                }

                objReader.Close();
            }
        }

        public float[] FeedForward(float[] inputs)
        {
            layers[0].FeedForward(inputs);
            for (int i = 1; i < layers.Length; i++)
            {
                layers[i].FeedForward(layers[i - 1].outputs);
            }

            return layers[layers.Length - 1].outputs;
        }

        public void BP(float[] expected)
        {
            for (int i = layers.Length - 1; i >= 0; i--)
            {
                if (i == layers.Length - 1)
                {
                    layers[i].BackPropOutput(expected);
                }

                else
                {
                    layers[i].Hidden(layers[i + 1].gamma, layers[i + 1].weigths);
                }
            }

            for (int i = 1; i < layers.Length; i++)
            {
                layers[i].UpdateWeigths();

            }

            // Write weigths

            string w_file = "W1.txt";
            System.IO.StreamWriter objReader;
            objReader = new System.IO.StreamWriter(w_file);

            for (int i = 0; i < layers[0].weigths.GetLength(0); i++)
            {
                for (int j = 0; j < layers[0].weigths.GetLength(1); j++)
                {
                    objReader.Write(layers[0].weigths[i, j] + " ");
                }

                objReader.Write("\n");
            }

            objReader.Close();

            w_file = "W2.txt";

            objReader = new System.IO.StreamWriter(w_file);

            for (int i = 0; i < layers[1].weigths.GetLength(0); i++)
            {
                for (int j = 0; j < layers[1].weigths.GetLength(1); j++)
                {
                    objReader.Write(layers[1].weigths[i, j] + " ");
                }

                objReader.Write("\n");
            }

            objReader.Close();

            w_file = "W3.txt";

            objReader = new System.IO.StreamWriter(w_file);

            for (int i = 0; i < layers[2].weigths.GetLength(0); i++)
            {
                for (int j = 0; j < layers[2].weigths.GetLength(1); j++)
                {
                    objReader.Write(layers[2].weigths[i, j] + " ");
                }

                objReader.Write("\n");
            }

            objReader.Close();
        }

        public int get()
        {
            return net_neural;
        }

        public void set(int i)
        {
            net_neural = i;
        }

        class Layer
        {
            public int no_input;
            public int no_output;

            public float[] outputs;
            public float[] inputs;
            public float[,] weigths;
            public float[,] weigthsdelta;
            public float[] gamma;
            public float[] error;
            public static Random random = new Random();



            public Layer(int a, int b)
            {
                no_input = a;
                no_output = b;
                outputs = new float[no_output];
                inputs = new float[no_input];
                weigths = new float[no_output, no_input];
                weigthsdelta = new float[no_output, no_input];
                gamma = new float[no_output];
                error = new float[no_output];

                InitializeWeigths();




            }

            public void InitializeWeigths()
            {
                for (int i = 0; i < no_output; i++)
                {
                    for (int j = 0; j < no_input; j++)
                    {
                        weigths[i, j] = (float)random.NextDouble() - 0.23f;
                    }
                }
            }

            public float[] FeedForward(float[] inputs)
            {
                this.inputs = inputs;
                for (int i = 0; i < no_output; i++)
                {
                    outputs[i] = 0;

                    for (int j = 0; j < no_input; j++)
                    {
                        outputs[i] += inputs[i] + weigths[i, j];

                    }
                    Random r = new Random();
                    float d = (float)r.NextDouble();
                    if (d < 0)
                    {

                    }
                    outputs[i] = (float)Math.Tanh(outputs[i]) * d / 10;
                    if (outputs[i] < 0)
                    {
                        outputs[i] = -outputs[i];
                    }
                }
                return outputs;
            }

            public float TanHDer(float value)
            {
                return 1 - (value * value);
            }

            public void BackPropOutput(float[] expected)
            {
                for (int i = 0; i < no_output; i++)
                {
                    error[i] = outputs[i] - expected[i];
                }

                for (int i = 0; i < no_output; i++)
                {
                    gamma[i] = error[i] * TanHDer(outputs[i]);
                }

                for (int i = 0; i < no_output; i++)
                {
                    for (int j = 0; j < no_input; j++)
                    {
                        weigthsdelta[i, j] = gamma[i] * inputs[i];
                    }
                }
            }

            public void Hidden(float[] g, float[,] wf)
            {
                for (int i = 0; i < no_output; i++)
                {
                    gamma[i] = 0;

                    for (int j = 0; j < g.Length; j++)
                    {
                        gamma[i] = g[j] * wf[j, i];
                    }

                    gamma[i] *= TanHDer(outputs[i]);
                }

                for (int i = 0; i < no_output; i++)
                {
                    for (int j = 0; j < no_input; j++)
                    {
                        weigthsdelta[i, j] = gamma[i] * inputs[i];
                    }
                }

            }

            public void UpdateWeigths()
            {
                for (int i = 0; i < no_output; i++)
                {
                    for (int j = 0; j < no_input; j++)
                    {
                        weigths[i, j] = weigthsdelta[i, j] * 0.46f; // Learning Rate

                    }
                }
            }

        }

        public float[] LoadSolution(float[] inputs)
        {
            float[] f = FeedForward(inputs);
            return f;

            //Console.WriteLine(bpm);
        }
    }

}
