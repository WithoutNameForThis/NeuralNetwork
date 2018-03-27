using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 神经网络
{
    [Serializable]
    abstract class NeuralLayerRaw
    {

        private Neural[] mNeural;

        private int mInputCount; //每个神经节点的上层连接数
        private int mCount;
        public Neural[] Neural
        {
            protected get { return mNeural; }
            set { mNeural = value; }
        }

        public Neural getNeural(int index)
        {
            return mNeural[index];
        }




        public NeuralLayerRaw( int inputCount,int Count)
        {
            mInputCount = inputCount;
            mCount = Count;

            mNeural = new Neural[Count];
            for (int i = 0; i < Count; i++)
            {
                mNeural[i] = new Neural(inputCount);
            }
        }

        protected abstract double f(double x);  //改为抽象方法

        protected abstract double fd(double x);


        public double[] partDerivative(double[] output,double[] exp)
        {
            double[] g = new double[mCount];
            for (int i = 0; i < mCount; i++)
            {
                double cache_1 = output[i];
                g[i] = fd(cache_1) * (exp[i] - cache_1);  //测试

            }
            return g;
        }
        public double[] partDerivative(double[] output,double[] g,NeuralLayerRaw next)
        {
            double[] e = new double[mCount];
            for (int i = 0; i < mCount; i++)
            {
                double sum = 0;
                for (int j = 0; j < next.mCount; j++)
                {
                    sum += next.getNeural(j).Weight[i] * g[j];
                }

                e[i] = fd(output[i]) * sum; //导数改变
            }
            return e;
        }


        public double[] output(double[] input)
        {
            double[] ho = new double[mCount];
            for (int i = 0; i < mCount; i++)
            {
                ho[i] = f(mNeural[i].output(input));
            }
            return ho;
        }

        public void updateWeight(double[] g, double[] input, double learningRate)  //for result
        {
            for (int i = 0; i < mCount; i++)
            {
                for (int j = 0; j < mInputCount; j++)
                {
                    mNeural[i].Weight[j] += learningRate * g[i] * input[j];
                }
                //mNeural[i].Threshold += (-1.0) * learningRate * g[i];
                mNeural[i].Threshold += -learningRate * g[i];
            }
        }

        public double[] updateEx(double[] ro,double[] ho,double[] exp,double learningRate)
        {
            double[] g = new double[mCount];

            g = this.partDerivative(ro, exp);

            this.updateWeight(g, ho, learningRate);

            return g;
        }

    }




    [Serializable]
    class NeuralNetworkOO
    {


        public double learningRate = 0.1;


        public void setNeuralLayer(List<NeuralLayerRaw> NeuralLayers)
        {
            this.NeuralLayers = NeuralLayers;
        }


        public List<NeuralLayerRaw> NeuralLayers = new List<NeuralLayerRaw>();


        public double[] output(double[] input)
        {

            return outputRaw(input)[NeuralLayers.Count];  //change
        }


        public double[][] outputRaw(double[] input)
        {
            int NeuralLayers_Count = NeuralLayers.Count;

            double[][] temp = new double[NeuralLayers_Count+1][]; //change

            temp[0] = input;
            for (int i = 1; i <= NeuralLayers_Count; i++)
            {
                temp[i] = NeuralLayers.ElementAt(i-1).output(temp[i - 1]);
            }


            return temp;                                 //change
        }

        public double train(double[] input, double[] exp)
        {


            double[][] temp = outputRaw(input);


            int NeuralLayers_Count = NeuralLayers.Count;


            double[] g;

            NeuralLayerRaw result = NeuralLayers.ElementAt(NeuralLayers_Count-1);

            g = result.partDerivative(temp[NeuralLayers_Count], exp);

            result.updateWeight(g, temp[NeuralLayers_Count - 1], learningRate);


            double[] eA=g;

            for(int i = NeuralLayers_Count - 2; i >= 0; i--)
            {
                NeuralLayerRaw T = NeuralLayers.ElementAt(i);
                NeuralLayerRaw T_Next = NeuralLayers.ElementAt(i+1);

                eA = T.partDerivative(temp[i + 1], eA, T_Next); //3层

                T.updateWeight(eA, temp[i], learningRate);
            }


            return 0;

        }

    }
}
