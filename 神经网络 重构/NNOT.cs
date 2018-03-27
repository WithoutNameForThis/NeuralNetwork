using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 神经网络
{







    [Serializable]
    public class NNOT
    {
        

        NeuralNetworkOO _NeuralNetwork=new NeuralNetworkOO();
        public NNOT()
        {

            _NeuralNetwork.learningRate = 0.1;//hide 50 lr 0.3 t 24k

            NeuralLayerFactory nlf = NeuralLayerFactory.getInstance();

            _NeuralNetwork.NeuralLayers.Add(nlf.GetNeuralLayerTanh(784, 200));
            _NeuralNetwork.NeuralLayers.Add(nlf.GetNeuralLayerTanh(200, 150));
            _NeuralNetwork.NeuralLayers.Add(nlf.GetNeuralLayerTanh(150, 10));
            //_NeuralNetwork.NeuralLayers.Add(nlf.GetNeuralLayerSigmoid(784, 10));



        }

        public void Save()
        {
            


            ObjectSaver<List<NeuralLayerRaw>>.saveToLocal(_NeuralNetwork.NeuralLayers, "NNOT_CORE_LAYERS");
        }

        public void Load()
        {

            _NeuralNetwork.NeuralLayers = ObjectSaver<List<NeuralLayerRaw>>.loadByFile("NNOT_CORE_LAYERS");
        }

        public void setLearningRate(double d)
        {
            _NeuralNetwork.learningRate = d;
        }

        public int max;
        public int pro;

        private LabeledPicture MovePicture(LabeledPicture src, int offsetX, int offsetY)
        {


            LabeledPicture lp = new LabeledPicture(MoveInput(src.getDouble(),offsetX,offsetY) , src.getLabel(),src.getNumLabel());
            return lp;
        }
        private double[] MoveInput(double[] src, int offsetX, int offsetY)
        {

            double[] temp = new double[28 * 28];

            for (int i = 0; i < 28 * 28; i++)
            {
                temp[i] = 0.0;
            }
            for (int i = 0; i < 28; i++)//Y
            {
                for (int j = 0; j < 28; j++)//X
                {
                    if ((i + offsetY) < 28 && (i + offsetY) >= 0 && (j + offsetX) < 28 && (j + offsetX) >= 0)
                    {
                        temp[(i + offsetY) * 28 + j + offsetX] = src[(i) * 28 + j];
                    }
                }
            }

            
            return temp;
        }
        public void train(LabeledPicture[] lp)
        {
            max = lp.Length;

            const int LOOP = 1; 
            for (int i = 0; i < lp.Length; i++)
            {
                pro = i ;
                //MessageBox.Show(i.ToString());


                //偏移图片
                for(int offsetX = -LOOP; offsetX <= LOOP; offsetX+=1)
                {
                    for (int offsetY = -LOOP; offsetY <= LOOP; offsetY+=1)
                    {
                        LabeledPicture lpt = MovePicture(lp[i], offsetX, offsetY);                        
                        _NeuralNetwork.train(lpt.getDouble(), lpt.getLabel());
                    }
                }


                //double[] a = getEx(lp[i].label);
                //nno.train(Surface.getDouble(lp[i].bit), a);


            }
        }

        public void addLayer()
        {
            this._NeuralNetwork.NeuralLayers.Add(NeuralLayerFactory.getInstance().GetNeuralLayerSigmoid(10, 10));
        }


        public double test(LabeledPicture[] lps)
        {
            double sum = 0;
            foreach(LabeledPicture lp in lps)
            {
                if(getOutput(lp.getDouble())==Label2Int(lp.getLabel()))
                {
                    sum+=1;
                }

            }
            return sum / lps.Length;

        }
        private int Label2Int(double[] label)
        {
            for(int i = 0; i < label.Length; i++)
            {
                if (label[i] == 1.0)
                {
                    return i;
                }
            }
            throw new Exception("Impossible");
        }


        public double[] getEx(int a)
        {
            double[] k = new double[10];
            for (int i = 0; i < 10; i++)
            {
                if (i == a)
                {
                    k[i] = 1.0;
                }
                else
                {
                    k[i] = 0.0;
                }

            }

            return k;
        }

        public double[] getOutputRaw(double[] inputRaw)
        {
            return _NeuralNetwork.output(inputRaw);
        }

        public int getOutput(double[] inputRaw)
        {
            double max = 0;
            int index = 0;
            const int loop = 3;

            double[] sum = new double[10];
            for(int i = 0; i < 10; i++)
            {
                sum[i] = 0.0;
            }

            for(int offsetX = -loop; offsetX <= loop; offsetX++)
            {
                for(int offsetY = -loop; offsetY <= loop; offsetY++)
                {
                    //MessageBox.Show(string.Format("{0},{1}", offsetX, offsetY));
                    

                    double[] input = MoveInput(inputRaw,offsetX,offsetY);
                    double[] output = _NeuralNetwork.output(input);
                    for (int i = 0; i < 10; i++)
                    {
                        if (offsetX == 0 && offsetY == 0)
                        {
                            sum[i] += output[i]*3;
                        }
                        sum[i] += output[i];

                       //// MessageBox.Show(input.ToString());
                       // double k = output[i];
                       // if (max < k)
                       // {
                       //     max = k;
                       //     index = i;
                       // }
                    }
                }
            }
            for(int i = 0; i < 10; i++)
            {
                double k = sum[i];
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
