using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 神经网络
{
    class NeuralNodeEx
    {
        private double[] mWeight;


        private double[] mInput;

        private double mThreshold;

        /// <summary>
        /// 下级神经节点连接数，用于确定权重的数量。
        /// </summary>
        private int mConnectCount;

        public double Threshold
        {
            get { return mThreshold; }
            set { mThreshold = value; }
        }



        public double[] Weight
        {
            get { return mWeight; }
            set
            {
                if (value.Count() != mConnectCount) throw new Exception("数据不符");
                mWeight = value;
            }
        }

        public int ConnectCout
        {
            get { return mConnectCount; }
        }














        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectCount">上级神经连接数量，定义输出数量</param>
        public NeuralNodeEx(int connectCount)
        {


            mConnectCount = connectCount;


            initThreshold();
            initWeight();


        }


        //public void input(double input)
        //{
        //    mInput = input;
        //}
        public double output(double[] input)
        {
            mInput = input;
            double output =0;
            for (int i = 0; i < mConnectCount; i++)
            {
                output += mWeight[i] * mInput[i];

            }
            output = sigmoid(output);


            return output;
        }


        private double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public void initWeight()
        {
            mWeight = new double[mConnectCount];
            Random r = new Random();
            for (int i = 0; i < mConnectCount; i++)
            {
                //mWeight[i] = 1/784; 
                mWeight[i] = (((double)r.Next())/1000.0) % 1.0 -0.5;
                //MessageBox.Show(mWeight[i].ToString());
                //MessageBox.Show(mWeight[i].ToString());
            }
        }
        public void initThreshold()
        {
            mThreshold = 0.1; //( new Random().Next())%2-1;
           // mThreshold = ((double)new Random().Next()/ 1000) % 1.0  - 0.5;
        }


    }

}
