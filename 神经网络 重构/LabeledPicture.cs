using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 神经网络
{

    public class LabeledPicture
    {
        private double[] _Pic = new double[784];
        private double[] _label;

        private int _tip;

        //public static int getNumLabel(double[] label)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (label[i] == 1.0)
        //        {
        //            return i;
        //        }
        //    }
        //    throw new Exception();
        //}

        public LabeledPicture(double[] bitmap,double[] label,int tip)
        {
            this._label = label;
            this._Pic = bitmap;
            this._tip = tip;
        }

        public int getNumLabel()
        {
            return _tip;
        }

        public double[] getLabel()
        {
            return _label;
        }
        public double[] getDouble()
        {
            return _Pic;
        }
    }
}
