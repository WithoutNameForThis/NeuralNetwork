using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 神经网络
{
    class NerualNetworkBC105CP
    {
        NeuralNetworkB78450110 nnb;
        NeuralNetworkC78415010 nnc150;
        NeuralNetworkC7845010 nnc;
        PerceptronFor10 nnp;
        NeuralNetworkT7845010 nnt;
        NNOT nno;
        public NerualNetworkBC105CP(
            NeuralNetworkB78450110 nnb, 
            NeuralNetworkC78415010 nnc150,
            NeuralNetworkC7845010 nnc,
            PerceptronFor10 nnp,
            NeuralNetworkT7845010 nnt,
            NNOT nno
            )
        {
            this.nnb = nnb;
            this.nnc = nnc;
            this.nnc150 = nnc150;
            this.nnp = nnp;
            this.nnt = nnt;

            this.nno = nno;

        }
        double w1 = 0;
        double w2 = 0;



        public void train(LabeledPicture[] lp)
        {
            for (int i = 0; i < lp.Length; i++)
            {
                double[] input= Surface.getDouble(lp[i].bit);






            }
        }

        public int getOutput(double[] input)
        {
            double[] num_weight=new double[10];
            for(int i = 0; i < 10; i++)
            {
                num_weight[i] = 0;
            }

            num_weight[nnb.getOutput(input)] += 3;
            num_weight[nnc150.getOutput(input)] += 3.5;
            num_weight[nnc.getOutput(input)] += 2.5;
            num_weight[nnp.GetPreict(input)] += 0;
            num_weight[nnt.getOutput(input)] += 1.3;
            num_weight[nno.getOutput(input)] += 2.0;
            //standard
            //num_weight[nnb.getOutput(input)] += 3;
            //num_weight[nnc150.getOutput(input)] += 3;
            //num_weight[nnc.getOutput(input)] += 2.5;
            //num_weight[nnp.GetPreict(input)] += 1.5;
            //num_weight[nnt.getOutput(input)] += 1.5;

            int index = -1;
            double max = 0;
            for(int i = 0; i < 10; i++)
            {
                if (num_weight[i] > max)
                {
                    max = num_weight[i];
                    index = i;
                }

            }
            return index;
        }
        

    }
}
