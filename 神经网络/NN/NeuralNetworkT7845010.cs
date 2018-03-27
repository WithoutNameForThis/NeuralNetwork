using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 神经网络
{
    [Serializable]
    class NeuralNetworkT7845010
    {
        NeuralNetworkWithTanh nnt;
        public NeuralNetworkT7845010()
        {
            nnt = new NeuralNetworkWithTanh(784, 150, 10);
            nnt.learningRate = 0.315;                                                  //hide 150 lr 0.03 t 24k
        }

        public void setLearningRate(double d)
        {
            nnt.learningRate = d;
        }

        public void train(LabeledPicture[] lp)
        {
            for (int i = 0; i < lp.Length; i++)
            {



                double[] a = getEx(lp[i].label);



                nnt.train(Surface.getDouble(lp[i].bit), a);


            }
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
                    k[i] = -0.000000;
                }

            }

            return k;
        }


        public int getOutput(double[] input)
        {
            double max = 0;
            int index = 0;
            for (int i = 0; i < 10; i++)
            {
                double k = nnt.output(input)[i];
                if (max < k)
                {
                    max = k;
                    index = i;
                }



            }
            return index;
        }
    }
}
