
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 神经网络
{
    class NeuralNetworkEx
    {
        private const int surfaceNumber = 2;
        private const int firstNumber = 2;
        private const int showNumber = 1;



        public NeuralNodeEx[] firstHideNeural = new NeuralNodeEx[firstNumber];


        public NeuralNodeEx[] showNeural = new NeuralNodeEx[showNumber];





        private double learningRate =0.005;

        public NeuralNetworkEx()
        {

            for (int i = 0; i < firstNumber; i++)
            {
                firstHideNeural[i] = new NeuralNodeEx(surfaceNumber);
            }
            for (int i = 0; i < showNumber; i++)
            {
                showNeural[i] = new NeuralNodeEx(firstNumber);
            }







        }

        public double[] inputCache;//= new double[surfaceNumber];

        public double[] hideCache; //= new double[firstNumber];
        public double[] resultCache; //= new double[showNumber];




        public double[] output(double[] input)
        {
            //double sum = 0;


            //for (int c = 0; c < firstNumber; c++)
            //{
            //    for (int i = 0; i < surfaceNumber; i++)
            //    {
            //        sum += firstHideNeural[c].Weight[i] * input[i];

            //    }

            //    b[c] = sigmoid(sum);
            //}
            //for (int k = 0; k < showNumber; k++)
            //{
            //    y[k] = 0;
            //    for (int c = 0; c < firstNumber; c++)
            //    {
            //        y[k] += b[c] * showNeural[k].Weight[c];
            //    }
            //    y[k] = sigmoid(y[k]);

            //}
            // double[] b = new double[firstNumber];
            // double[] y = new double[showNumber];
            //double[] g = new double[showNumber];

            //double sum = 0;


            //for (int c = 0; c < firstNumber; c++)
            //{
            //    for (int i = 0; i < surfaceNumber; i++)
            //    {
            //        sum += firstHideNeural[c].Weight[i] * input[i];
            //    }
            //    sum -= firstHideNeural[c].Threshold;
            //    b[c] = sum;//sigmoid(sum); 
            //}

            //for (int k = 0; k < showNumber; k++)
            //{
            //    y[k] = 0;
            //    for (int c = 0; c < firstNumber; c++)
            //    {
            //        y[k] += b[c] * showNeural[k].Weight[c];
            //    }
            //    y[k] = sigmoid(y[k] - showNeural[k].Threshold);




            //}
            double[] a =  { 0 };
            train(input,a);


            return y;

        }

        public double[] b = new double[firstNumber];
        public double[] y = new double[showNumber];
        public double[] g = new double[showNumber];


        //double[] b = new double[firstNumber];
        //    double[] y = new double[showNumber];
        //    double[] g = new double[showNumber];
        public void train(double[] input, double[] exp)
        {
            double sum = 0;



            for (int c = 0; c < firstNumber; c++)
            {
                for (int i = 0; i < surfaceNumber; i++)
                {
                    sum += firstHideNeural[c].Weight[i] * input[i];
                }
                sum -= firstHideNeural[c].Threshold;
                b[c] = sum;//sigmoid(sum); 
            }

            for (int k = 0; k < showNumber; k++)
            {
                y[k] = 0;
                for (int c = 0; c < firstNumber; c++)
                {
                    y[k] +=b[c] * showNeural[k].Weight[c];
                }
                y[k] = sigmoid(y[k]-showNeural[k].Threshold);
                //MessageBox.Show(y[k].ToString());

                g[k] = y[k] * (1 - y[k]) * (exp[k] - y[k]);


            }

            for (int k = 0; k < showNumber; k++)
            {
                for (int c = 0; c < firstNumber; c++)
                {
                    showNeural[k].Weight[c] += learningRate * g[k] * b[c];

                }
                showNeural[k].Threshold -= learningRate * g[k];
            }


            for (int c = 0; c < firstNumber; c++)
            {
                double e = 0;
                double su = 0;
                for (int k = 0; k < showNumber; k++)
                {
                    su += showNeural[k].Weight[c] * g[k];
                }
                e = b[c] * (1 - b[c]) * su;

                for (int i = 0; i < surfaceNumber; i++)
                {
                    firstHideNeural[c].Weight[i] += learningRate * e * input[i];
                }
                firstHideNeural[c].Threshold -= learningRate * e;


            }





            




        }









        private double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }





        /// <summary>
        /// 利用0-9的数字，生成 应输出 结果序列。
        /// </summary>
        /// <param name="a">应输出值</param>
        /// <returns>应输出结果序列</returns>
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