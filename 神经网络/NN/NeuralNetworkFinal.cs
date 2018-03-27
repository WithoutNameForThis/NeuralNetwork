using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 神经网络
{
    [Serializable]
    class NeuralNetworkFinal
    {
        [Serializable]
        private class Neural
        {
            private double[] mWeight;
            private double mThreshold;

            /// <summary>
            /// 对输入进行处理的权重
            /// </summary>
            public double[] Weight
            {
                get { return mWeight; }
                set { mWeight = value; }
            }

            /// <summary>
            /// 对输入进行处理的阈值
            /// </summary>
            public double Threshold
            {
                get { return mThreshold; }
                set { mThreshold = value; }
            }



            /// <summary>
            /// 矩阵乘法 用于两个矩阵相乘 二者的维数应相同。
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns>结果</returns>
            public double MatrixMultiplication(double[] x, double[] y)
            {
                double sum = 0;
                for(int i= 0; i < y.Length; i++)
                {
                    sum += y[i] * x[i];
                }
                return sum;
            }

            /// <summary>
            /// 返回原始加权和
            /// </summary>
            /// <param name="input">输入</param>
            /// <returns>原始加权和</returns>
            public double output(double[] input)
            {
                double sum = 0;
                sum += MatrixMultiplication(input, mWeight);
                sum -= mThreshold;
                return sum;
            }

            public double outputSigmoid(double[] input)
            {
                return sigmoid(output(input));
            }

            public Neural(int ConnectCount)
            {
                mWeight = new Double[ConnectCount];

                Random R = new Random();

                mThreshold = (((double)R.Next()) / 1000.0) % 1.0 - 0.5;
                //mThreshold = 0;

                for (int i = 0; i < ConnectCount; i++)
                {
                    mWeight[i] = (((double)R.Next()) / 1000.0) % 1.0 - 0.5;
                }
            }


            public double sigmoid(double x)
            {
                return 1.0 / (1.0 + Math.Exp(-1.0*x));
               
            }


        }
        private int inputCount = 784;
        private int hideCount = 50;  //lr 10 0.3
        private int resultCount = 10;


        public double learningRate=0.03;


        private Neural[] hide;
        private Neural[] result;
        public NeuralNetworkFinal(int inputCount ,int hideCount,int resultCount)
        {
            hide = new Neural[hideCount];
            result = new Neural[resultCount];
            for (int i = 0; i < hideCount; i++)
            {
                hide[i] = new Neural(inputCount);
            }
            for (int i = 0; i <resultCount; i++)
            {
                result[i] = new Neural(hideCount);
            }
            this.hideCount = hideCount;
            this.inputCount = inputCount;
            this.resultCount = resultCount;
        }



        public double[] output(double[] input)
        {
            double[] ho = new double[hideCount];
            for(int i = 0; i < hideCount; i++)
            {
                ho[i] = hide[i].outputSigmoid(input);
            }

            double[] ro = new double[resultCount];
            for(int i = 0; i < resultCount; i++)
            {
                ro[i] = result[i].outputSigmoid(ho);
            }
            // 改为递归
            return ro;
        }

        public double train(double[] input,double[] exp)
        {
            double[] ho = new double[hideCount];
            for (int i = 0; i < hideCount; i++)
            {
                ho[i] = hide[i].outputSigmoid(input);
                
            }

            double[] ro = new double[resultCount];
            for (int i = 0; i < resultCount; i++)
            {
                ro[i] = result[i].outputSigmoid(ho);
            }

            double[] g = new double[resultCount];
            for(int i = 0; i < resultCount; i++)
            {
                g[i] = (1 - ro[i]) * ro[i] * (exp[i] - ro[i]);  //改变导数

            }

            for(int i = 0; i < resultCount; i++)
            {
                for(int j = 0; j < hideCount; j++)
                {
                    result[i].Weight[j] += learningRate * g[i] * ho[j];
                }
                result[i].Threshold += (-1.0)*learningRate * g[i];
            }

            double[] e = new double[hideCount];
            for(int i = 0; i < hideCount; i++)
            {
                double sum = 0;
                for(int j = 0; j < resultCount; j++)
                {
                    sum += result[j].Weight[i]*g[j];
                }
                e[i] = ho[i] * (1.0 - ho[i]) * sum; //导数改变
            }

            for(int i = 0; i < hideCount; i++)
            {
                for(int j = 0; j < inputCount; j++)
                {
                    hide[i].Weight[j] += learningRate * e[i] * input[j];
                }
                hide[i].Threshold += (-1.0) * learningRate * e[i];


            }


            double sumE = 0;
            for (int i = 0; i < resultCount; i++)
            {
                sumE+=Math.Pow ((exp[i] - ro[i]),2);  //改变
            }

            return sumE;





        }




        public double th(double x)
        {
            return Math.Tanh(x);
        }


        //public double sigmoid(double x)
        //{
        //    return 1.0 / (1.0 + Math.Exp(-1.0*x));

        //}
        public double tanh(double x)
        {
            return 2.0 / (1.0 + Math.Exp(x)) - 0.5;

        }







    }





}
