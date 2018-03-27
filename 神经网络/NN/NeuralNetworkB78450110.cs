using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 神经网络
{
    [Serializable]
    class NeuralNetworkB78450110
    {
        NeuralNetworkFinal[] nnb = new NeuralNetworkFinal[10];

        public NeuralNetworkB78450110()
        {
            for (int i=0; i < 10; i++)
            {
                nnb[i] = new NeuralNetworkFinal(784, 10, 1);
            }

        }
        public void train(LabeledPicture[] lp)
        {
            for(int j = 0; j < lp.Length; j++)
            {
                for(int i = 0; i < 10; i++)
                {
                    if (lp[j].label == i)
                    {
                        double[] a = { 1.0 };
                        nnb[i].train(Surface.getDouble(lp[j].bit), a);
                    }
                    else
                    {
                        double[] a = { 0.0 };
                        nnb[i].train(Surface.getDouble(lp[j].bit), a);
                    }



                }



            }
        }

        public void setLearningRate(double d)
        {
            for(int i = 0; i < 10; i++)
            {
                nnb[i].learningRate = d;
            }
        }
        public int getOutput(double[] input)
        {
            double max = 0;
            int index = 0;
            for(int i = 0; i < 10; i++)
            {
                double t= nnb[i].output(input)[0];
                if (t > max)
                {
                    max = t;
                    index = i;
                }
            }
            return index;
        }


        public double[] getEx(int a)
        {
            double[] k = new double[10];
            for (int i = 0; i < 10; i++)
            {
                if (i == a)
                {
                    k[i] = 1.0;
                }
                else
                {
                    k[i] = 0.000000;
                }

            }

            return k;
        }


    }
}
