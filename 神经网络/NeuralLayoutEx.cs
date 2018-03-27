using System;

namespace 神经网络
{
    class NeuralLayoutEx
    {
        public NeuralNodeEx[] innerNeural;

        public NeuralLayoutEx(NeuralNodeEx[] nn)
        {
            innerNeural = nn;
        }


        public NeuralLayoutEx(int count,int ConnectCount)
        {
            innerNeural = new NeuralNodeEx[count];
            for(int i = 0; i < count; i++)
            {
                innerNeural[i] = new NeuralNodeEx(ConnectCount);
            }
        }

        public double[] output(double[] input)
        {
            double[] output = new double[innerNeural.Length];
            for(int i = 0; i < innerNeural.Length; i++)
            {
                output[i]= innerNeural[i].output(input);
            }
            return output;
        }






    }
}