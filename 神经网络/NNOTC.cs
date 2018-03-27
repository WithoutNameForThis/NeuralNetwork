using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 神经网络
{
    [Serializable]
    class NNOTC
    {
        [Serializable]
        class NNO : NeuralNetworkOO
        {
            public NNO() : base()
            {
                

                List<NeuralLayerRaw> NeuralLayers = new List<NeuralLayerRaw>();
                NeuralLayers.Add(new NeuralLayerSigmoid(784, 100));
                NeuralLayers.Add(new NeuralLayerSigmoid(100, 10));
                NeuralLayers.Add(new NeuralLayerSigmoid(10, 1));
                setNeuralLayer(NeuralLayers);
            }
        }
        NNO[] nnoes = new NNO[10];
        public NNOTC()
        {
            for(int i = 0; i < 10; i++)
            {
                nnoes[i] = new NNO();
                nnoes[i].learningRate = 0.1;
            }
            
        }
        public void setLearningRate(double d)
        {
            for (int i = 0; i < 10; i++)
            {
                nnoes[i].learningRate = d;
            }
        }
        public int max;//指示训练进度
        public int pro;

        private LabeledPicture MovePicture(LabeledPicture src, int offsetX, int offsetY)
        {

            bool[] temp = new bool[28 * 28];

            for (int i = 0; i < 28 * 28; i++)
            {
                temp[i] = false;
            }
            for (int i = 0; i < 28; i++)//Y
            {
                for (int j = 0; j < 28; j++)//X
                {
                    if ((i + offsetY) < 28 && (i + offsetY) >= 0 && (j + offsetX) < 28 && (j + offsetX) >= 0)
                    {
                        temp[(i + offsetY) * 28 + j + offsetX] = src.bit[(i) * 28 + j];
                    }
                }
            }

            LabeledPicture lp = new LabeledPicture(temp, src.label);
            return lp;
        }

        public void train(LabeledPicture[] lp)
        {
            max = lp.Length;
            for (int i = 0; i < lp.Length; i++)
            {
                pro = i;

                //偏移图片
                for (int offsetX = -6; offsetX < 7; offsetX += 2)
                {
                    for (int offsetY = -6; offsetY < 7; offsetY += 2)
                    {


                        LabeledPicture lpt = MovePicture(lp[i], offsetX, offsetY);

                        for(int jk = 0; jk < 10; jk++)
                        {
                            double[] zero = { 0 };
                            double[] one = { 1 };

                            nnoes[jk].train(Surface.getDouble(lpt.bit), jk==lpt.label?one:zero);
                        }
                        
                    }
                }
            }
        }


        public int getOutput(double[] input)
        {
            double max = 0;
            int index = 0;

            for (int i = 0; i < 10; i++)
            {
                double k = nnoes[i].output(input)[0];
                if (max < k)
                {
                    max = k;
                    index = i;
                }
            }
            return index;
        }
    }
}