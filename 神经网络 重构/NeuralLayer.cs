using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            get { return mNeural; }
            set { mNeural = value; }
        }

        public Neural getNeural(int index)
        {
            return mNeural[index];
        }

        public NeuralLayerRaw(int inputCount, int Count)
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


        public double[] partDerivative(double[] output, double[] exp)
        {
            double[] g = new double[mCount];
            for (int i = 0; i < mCount; i++)
            {
                double cache_1 = output[i];
                g[i] = fd(cache_1) * (exp[i] - cache_1);  //测试

            }
            return g;
        }
        public double[] partDerivative(double[] output, double[] g, NeuralLayerRaw next)
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

        public double[] updateEx(double[] ro, double[] ho, double[] exp, double learningRate)
        {
            double[] g = new double[mCount];

            g = this.partDerivative(ro, exp);

            this.updateWeight(g, ho, learningRate);

            return g;
        }

    }

    class NeuralLayerFactory
    {

        static NeuralLayerFactory _Self;
        private NeuralLayerFactory() { }

        public static NeuralLayerFactory getInstance()
        {
            if (_Self == null) _Self = new NeuralLayerFactory();
            return _Self;
        }
        public NeuralLayerRaw GetNeuralLayerRelu(int count, int inputCount)
        {
            return new NeuralLayerRelu(count, inputCount);
        }
        public NeuralLayerRaw GetNeuralLayerTanh(int count, int inputCount)
        {
            return new NeuralLayerTanh(count, inputCount);
        }
        public NeuralLayerRaw GetNeuralLayerSigmoid(int count, int inputCount)
        {
            return new NeuralLayerSigmoid(count, inputCount);
        }





    }


    [Serializable]
    class NeuralLayerRelu : NeuralLayerRaw
    {
        public NeuralLayerRelu(int Count, int InputCount) : base(Count, InputCount)
        {

        }
        protected override double fd(double x)
        {
            return x < 0 ? 0.0 : 1.0;
        }
        protected override double f(double x)
        {
            return Math.Max(x, 0); //2.0
        }
    }

    [Serializable]
    class NeuralLayerTanh : NeuralLayerRaw
    {
        public NeuralLayerTanh(int Count, int InputCount) : base(Count, InputCount)
        {

        }
        protected override double fd(double x)
        {
            return (1 - Math.Pow(x, 2)); //2.0
        }
        protected override double f(double x)
        {
            return Math.Tanh(x);

        }
    }

    [Serializable]
    class NeuralLayerSigmoid : NeuralLayerRaw
    {
        public NeuralLayerSigmoid(int Count, int InputCount) : base(Count, InputCount)
        {

        }
        protected override double fd(double x)
        {
            //return x * (1 - x);
            return x - x * x;
        }
        protected override double f(double x)
        {
            return sigmoid(x);
        }
        public double sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
            //return Math.Pow((1.0 + Math.Exp(-x)), -1);
        }

    }



}
