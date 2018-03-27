using System;

namespace 神经网络
{

    //神经网络初始权值 sqr（out/input）

        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class Neural
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
            public static double MatrixMultiplication(double[] x, double[] y)
            {
                double sum = 0;
                for (int i = 0; i < y.Length; i++)
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
                return (sum);
            }


            public Neural(int ConnectCount,double initWeight=0.1)
            {
                mWeight = new Double[ConnectCount];

                Random R = new Random();

                mThreshold = ((((double)R.Next()) / 1000.0) % 2.0 - 1.0)*initWeight;  


                for (int i = 0; i < ConnectCount; i++)
                {
                    mWeight[i] = ((((double)R.Next()) / 1000.0) % 2.0 - 1.0)* initWeight;
                }
            }

        }


}
