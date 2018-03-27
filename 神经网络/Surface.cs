using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 神经网络
{
    class Surface
    {
        Boolean[] outerData = new Boolean[28*28];




        /// <summary>
        /// 设置数据 请保证 数组长度为28*28
        /// </summary>
        /// <param name="b">数据</param>
        public void setData(Boolean[] b)
        {
            outerData = b;
        }

        /// <summary>
        /// 返回表层数据 数组长度为28*28
        /// </summary>
        /// <returns>长度为28*28的数组</returns>
        public Boolean[] getData()
        {
            return outerData;
        }

        public void reSet()
        {
            outerData = new Boolean[28*28];
        }

        public void setSingleData(int x)
        {
            outerData[x] = true;
        }

        public Boolean getSingleData(int x)
        {
            return outerData[x];
        }

        
        public static double[] getDouble( Boolean[] outerData)
        {

            double[] d = new double[784];
            for(int i = 0; i < 784; i++)
            {
                if (outerData[i] == true)
                {
                    d[i] = 1.0;
                }
                else
                {
                    d[i] = 0.0;
                }
            }
            return d;
        }
    }
}
