using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 神经网络
{
    class LabeledPictureEx : LabeledPicture
    {
        public double[] Pic = new double[784];


        public LabeledPictureEx(double[] bitmap, int label) : base(null, label)
        {
            Pic = bitmap;
        }

        public override double[] getDouble()
        {
            return Pic;
        }
    }

    class LabeledPicture
    {
        public Boolean[] bit = new Boolean[784];
        public int label;

        public LabeledPicture(Boolean[] bitmap,int label)
        {
            this.label = label;
            this.bit = bitmap;
        }

        public virtual double[] getDouble()
        {
            double[] d = new double[784];
            for (int i = 0; i < 784; i++)
            {
                if (bit[i] == true)
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
