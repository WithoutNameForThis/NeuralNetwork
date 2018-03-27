using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 神经网络
{



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






    [Serializable]
    class NNOT
    {

        public void Test()
        {
            nno.NeuralLayers.Add(new NeuralLayerSigmoid(10, 10));
        }


        [Serializable]
        class NNO : NeuralNetworkOO
        {
            public NNO():base()
            {

                List<NeuralLayerRaw> NeuralLayers = new List<NeuralLayerRaw>();
                NeuralLayers.Add(new NeuralLayerSigmoid(784, 250));
                NeuralLayers.Add(new NeuralLayerSigmoid(250, 150));
                //NeuralLayers.Add(new NeuralLayerSigmoid(200, 100));
                NeuralLayers.Add(new NeuralLayerSigmoid(150, 10));
                //NeuralLayers.Add(new NeuralLayerSigmoid(10, 10));
                //NeuralLayers.Add(new NeuralLayerSigmoid(10, 10));
                //NeuralLayers.Add(new NeuralLayerSigmoid(10, 10));

                //NeuralLayers.Add(new NeuralLayerSigmoid(784, 100));
                //NeuralLayers.Add(new NeuralLayerSigmoid(200, 150));
                //NeuralLayers.Add(new NeuralLayerSigmoid(100, 50));
                //NeuralLayers.Add(new NeuralLayerSigmoid(150, 10));


                //NeuralLayers.Add(new NeuralLayerRelu(784, 10));



                setNeuralLayer(NeuralLayers);
            }
        }

        NNO nno=new NNO();
        public NNOT()
        {
            
            nno.learningRate = 0.315;                                                  //hide 50 lr 0.3 t 24k
        }


        public void Save()
        {

            //StreamWriter sw = new StreamWriter(@"C:\Users\phony\Desktop\新建文件夹 (2)\Data\sss.tesx");
            
            //NeuralLayerRaw nlr = nno.NeuralLayers.ElementAt(0);
            //sw.Write(784.ToString() + "|" + 250.ToString() + "|");

            //for (int i = 0; i < 250; i++)
            //{
            //    sw.Write(nlr.getNeural(i).Threshold.ToString() + "|");
            //    for (int j = 0; j < 784; j++)
            //    {
            //        sw.Write(nlr.getNeural(i).Weight[j] + "|");
            //    }

            //}
            // nlr = nno.NeuralLayers.ElementAt(1);
            //sw.Write(250.ToString() + "," + 150.ToString() + "|");

            //for (int i = 0; i < 150; i++)
            //{
            //    sw.Write(nlr.getNeural(i).Threshold.ToString() + "|");
            //    for (int j = 0; j < 250; j++)
            //    {
            //        sw.Write(nlr.getNeural(i).Weight[j] + "|");
            //    }

            //}
            // nlr = nno.NeuralLayers.ElementAt(2);
            //sw.Write(150.ToString() + "|" + 10.ToString() + "|");

            //for (int i = 0; i < 10; i++)
            //{
            //    sw.Write(nlr.getNeural(i).Threshold.ToString() + "|");
            //    for (int j = 0; j < 150; j++)
            //    {
            //        sw.Write(nlr.getNeural(i).Weight[j] + "|");
            //    }

            //}


            //double[] temp = new double[2000000];

            //for(int ik = 0; ik < 1; ik++)
            //{
            //    NeuralLayerRaw nlr = nno.NeuralLayers.ElementAt(ik);
            //    int jk = 0;
            //    temp[jk] = 784;

            //    jk++;
            //    temp[jk] = 250;
            //    jk++;
            //    for (int i = 0; i < 250; i++)
            //    {
            //        temp[jk] = nlr.getNeural(i).Threshold;
            //        jk++;
            //        for (int j = 0; j < 784; j++)
            //        {
            //            //sw.Write(nlr.getNeural(i).Weight[j] + ",");

            //            temp[jk] = nlr.getNeural(i).Weight[j];
            //            jk++;
            //        }

            //    }
            //}




 

            ObjectSaver<NNO>.saveToLocal(nno, "NNOT_CORE");
            
        }

        public void Load()
        {

            //StreamReader sr = new StreamReader(@"C:\Users\phony\Desktop\新建文件夹 (2)\Data\sss.tesx");

            //string str = sr.ReadToEnd();
            //string[] stres = str.Split('|');
            //MessageBox.Show(stres.Length.ToString())
            //    ;

            //MessageBox.Show(stres[196002]);
            //int jk = 0;
            //int InCount, LaCount;
            //InCount = int.Parse(stres[jk]);
            //jk++;
            //LaCount = int.Parse(stres[jk]);
            //jk++;
            //NeuralLayerSigmoid nls = new NeuralLayerSigmoid(LaCount, InCount);
            //for(int i = 0; i < LaCount;i++)
            //{
            //    //nls.neu;

            //}



            nno = ObjectSaver<NNO>.loadByFile("NNOT_CORE");

            
        }

        public void setLearningRate(double d)
        {
            nno.learningRate = d;
        }

        public int max;
        public int pro;
        //public List<double> AccList = new List<double>();

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

            const int LOOP = 6; 
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

                        
                        nno.train(Surface.getDouble(lpt.bit), getEx(lpt.label));
                    }
                }


                //double[] a = getEx(lp[i].label);
                //nno.train(Surface.getDouble(lp[i].bit), a);


            }
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

        public void ShowRawOutput(double[] inputRaw)
        {
            string str = "";
            for(int i = 0; i < 10; i++)
            {
                str += " " + inputRaw[i];
            }
            MessageBox.Show(str);
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
                    double[] output = nno.output(input);
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
