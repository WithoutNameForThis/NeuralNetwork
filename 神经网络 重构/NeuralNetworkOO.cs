using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 神经网络
{





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
