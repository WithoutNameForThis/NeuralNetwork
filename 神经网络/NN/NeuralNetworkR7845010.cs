using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 神经网络
{
    class NeuralNetworkR7845010
    {
        NeuralNetworkReLu nnr;
        public NeuralNetworkR7845010()
        {
            nnr = new NeuralNetworkReLu(784, 10, 10);
            nnr.learningRate = 0.315;                                                  //hide 150 lr 0.03 t 24k
        }

        public void setLearningRate(double d)
        {
            nnr.learningRate = d;
        }

        public void train(LabeledPicture[] lp)
        {
            for (int i = 0; i < lp.Length; i++)
            {



                double[] a = getEx(lp[i].label);



                nnr.train(Surface.getDouble(lp[i].bit), a);

                //MessageBox.Show("s");
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
                double k = nnr.output(input)[i];
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
