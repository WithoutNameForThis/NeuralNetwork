using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 神经网络
{
    class TestUnit
    {

        public static double[] getFilledPicture()
        {
            double[] t = new double[784];
            for(int i = 0; i < 784; i++)
            {
                t[i] = 1.0;
            }
            return t;
        }




        public static double getAcc(PerceptronFor10 per,LabeledPicture[] lp)
        {
            double count = (double)lp.Count();
            double correct = 0;

            foreach(LabeledPicture lps in lp)
            {
                ;

                if (lps.label == per.GetPreict(lps.getDouble()))
                {
                    correct++;
                }
            }






            return correct / count;
        }
        public static double getAcc(NeuralNetworkC7845010 nnc, LabeledPicture[] lp)
        {
            double count = (double)lp.Count();
            double correct = 0;

            foreach (LabeledPicture lps in lp)
            {
                ;

                if (lps.label == nnc.getOutput (lps.getDouble()))
                {
                    correct++;
                }
            }

            return correct / count;
        }
        public static double getAcc(NeuralNetworkC78415010 nnc, LabeledPicture[] lp)
        {
            double count = (double)lp.Count();
            double correct = 0;

            foreach (LabeledPicture lps in lp)
            {
                ;

                if (lps.label == nnc.getOutput(lps.getDouble()))
                {
                    correct++;
                }
            }

            return correct / count;
        }
        public static double getAcc(NeuralNetworkB78450110 nnb, LabeledPicture[] lp)
        {
            double count = (double)lp.Count();
            double correct = 0;

            foreach (LabeledPicture lps in lp)
            {
                ;

                if (lps.label == nnb.getOutput(lps.getDouble()))
                {
                    correct++;
                }
            }

            return correct / count;
        }
        public static double getAcc(NerualNetworkBC105CP nnbcp, LabeledPicture[] lp)
        {
            double count = (double)lp.Count();
            double correct = 0;

            foreach (LabeledPicture lps in lp)
            {
                ;

                if (lps.label == nnbcp.getOutput(lps.getDouble()))
                {
                    correct++;
                }
            }

            return correct / count;
        }




        public static double getAcc(NeuralNetworkT7845010 nnt, LabeledPicture[] lp)
        {
            double count = (double)lp.Count();
            double correct = 0;

            foreach (LabeledPicture lps in lp)
            {
                ;

                if (lps.label == nnt.getOutput(lps.getDouble()))
                {
                    correct++;
                }
            }

            return correct / count;
        }

        public static double getAcc(NNOT nnt, LabeledPicture[] lp)
        {
            double count = (double)lp.Count();
            double correct = 0;

            foreach (LabeledPicture lps in lp)
            {
                ;

                if (lps.label == nnt.getOutput(lps.getDouble()))
                {
                    correct++;
                }
            }

            return correct / count;
        }
        public static double getAcc(NNOTC nnt, LabeledPicture[] lp)
        {
            double count = (double)lp.Count();
            double correct = 0;

            foreach (LabeledPicture lps in lp)
            {
                ;

                if (lps.label == nnt.getOutput(lps.getDouble()))
                {
                    correct++;
                }
            }

            return correct / count;
        }
        public static double getAcc(NeuralNetworkR7845010 nnr, LabeledPicture[] lp)
        {
            double count = (double)lp.Count();
            double correct = 0;

            foreach (LabeledPicture lps in lp)
            {
                ;

                if (lps.label == nnr.getOutput(lps.getDouble()))
                {
                    correct++;
                }
            }

            return correct / count;
        }

    }
}
