using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 神经网络
{
    class NeuralNetwork
    {

        private const int surfaceNumber = 784;
        private const int firstNumber = 20;
        private const int showNumber = 10;

       

        public NeuralNodeEx[] firstHideNeural = new NeuralNodeEx[firstNumber];


        public NeuralNodeEx[] showNeural = new NeuralNodeEx[showNumber];





        private double learningRate = 0.006;

        public NeuralNetwork()
        {

            for (int i = 0; i < firstNumber; i++)
            {
                firstHideNeural[i] = new NeuralNodeEx(surfaceNumber);
            }
            for (int i = 0; i < showNumber; i++)
            {
                showNeural[i] = new NeuralNodeEx(firstNumber);
            }







        }

        public double[] inputCache;//= new double[surfaceNumber];

        public double[] hideCache; //= new double[firstNumber];
        public double[] resultCache; //= new double[showNumber];




        public double[] output(double[] input)
        {
            double sum = 0;
            double[] b = new double[firstNumber];
            double[] y = new double[showNumber];
            double[] g = new double[showNumber];

            for (int c = 0; c < firstNumber; c++)
            {
                for (int i = 0; i < surfaceNumber; i++)
                {
                    sum += firstHideNeural[c].Weight[i] * input[i];
                    
                }
                b[c] =sigmoid( sum);
            }
            for (int k = 0; k < showNumber; k++)
            {
                y[k] = 0;
                for (int c = 0; c < firstNumber; c++)
                {
                    y[k] += b[c] * showNeural[k].Weight[c];
                }
                y[k] = sigmoid(y[k]);

            }


            return y;

        }
        public void train(double[] input,double [] exp)
        {
            double sum = 0;
            double[] b = new double[firstNumber];
            double[] y = new double[showNumber];
            double[] g = new double[showNumber];

            for (int c = 0; c < firstNumber; c++)
            {
                for(int i=0; i < surfaceNumber; i++)
                {
                    sum += firstHideNeural[c].Weight[i] * input[i];                  
                }
                b[c] = sigmoid( sum); //
            }

            for(int k = 0; k < showNumber; k++)
            {
                y[k] = 0;
                for(int c = 0; c < firstNumber; c++)
                {
                    y[k] +=  b[c] * showNeural[k].Weight[c];
                }
                y[k] = sigmoid(y[k]-showNeural[k].Threshold);

                g[k] = y[k] * (1 - y[k]) * (exp[k] - y[k]);

                //if(exp[k]!=0) MessageBox.Show((exp[k]).ToString());
               // if(g[k]>0.05) MessageBox.Show((g[k]).ToString());
                //MessageBox.Show((y[k]).ToString());
            }

            for(int k = 0; k < showNumber; k++)
            {
                for(int c = 0; c < firstNumber; c++)
                {
                    showNeural[k].Weight[c] += learningRate * g[k] * b[c];
                  
                }
                showNeural[k].Threshold -= learningRate * g[k];
            }


            for(int c = 0; c < firstNumber; c++)
            {
                double e = 0;
                double su = 0;
                for(int k = 0; k < showNumber; k++)
                {
                    su += showNeural[k].Weight[c] * g[k];
                }
               // MessageBox.Show(su.ToString());
                e = b[c] * (1 - b[c]) * su;

                for(int i = 0; i < surfaceNumber; i++)
                {
                    firstHideNeural[c].Weight[i] += learningRate * e * input[i];
                 //   if(learningRate * e * input[i]!=0) MessageBox.Show((learningRate * e * input[i]).ToString());
                }
                firstHideNeural[c].Threshold -= learningRate * e;


            }









        }





        public void train(LabeledPicture[] lp)
        {
            for (int i = 0; i < lp.Length; i++)
            {

                LabeledPicture slp = lp[i];


                double[] bitmap = Surface.getDouble(slp.bit);

                double[] exp_result = getEx(slp.label);

                //if (slp.label == 1)
                //{
                //    exp_result[0] = 1;
                //}
                //else
                //{

                //    exp_result[0] = 0;
                //}

                for(int s = 0; s < 10; s++)
                {
                    //MessageBox.Show(exp_result.Length.ToString());
                   // if (exp_result[s] != 0) MessageBox.Show(exp_result[s].ToString());
                }

                

                train(bitmap, exp_result);
            }
        }





        private double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }













        //        public void train(LabeledPicture[] lp)
        //{
        //    for (int i = 0; i < lp.Length; i++)
        //    {

        //        LabeledPicture slp = lp[i];


        //        double[] bitmap = Surface.getDouble(slp.bit);

        //        double[] exp_result = getEx(slp.label);

        //        double[] g = new double[showNumber];

        //        inputCache = bitmap;
        //        hideCache = hide.output(inputCache);
        //            ;

        //        resultCache = result.output(hideCache);



        //        for (int res_index = 0; res_index < showNumber; res_index++)
        //        {

        //            double real_y = resultCache[res_index];
        //            g[res_index] = real_y * (1 - real_y) * (exp_result[res_index] - real_y);


        //            //对结果层神经元进行更新
        //            for (int res_weight_index = 0; res_weight_index < firstNumber; res_weight_index++)
        //            {
        //                result.innerNeural[res_index].Weight[res_weight_index] += g[res_index] * learningRate * hideCache[res_weight_index];
        //                // MessageBox.Show((g[res_index] * learningRate * hideCache[res_weight_index]).ToString());
        //                MessageBox.Show((g[res_index]).ToString());
        //            }
        //            result.innerNeural[res_index].Threshold -= learningRate * g[res_index];

        //        }

        //        for (int hid_index = 0; hid_index < firstNumber; hid_index++)
        //        {
        //            double e = 0;// 

        //            for (int res_index = 0; res_index < showNumber; res_index++)
        //            {
        //                e += result.innerNeural[res_index].Weight[hid_index] * g[res_index];
        //            }

        //            e *= hideCache[hid_index] * (1 - hideCache[hid_index]);
        //            //MessageBox.Show(( hideCache[hid_index]).ToString() );
        //            for (int hid_weight = 0; hid_weight < firstNumber; hid_weight++)
        //            {
        //                hide.innerNeural[hid_index].Weight[hid_weight] += learningRate * e * inputCache[hid_weight];
        //                //MessageBox.Show((learningRate * e * inputCache[hid_weight]).ToString());
        //            }

        //            hide.innerNeural[hid_index].Threshold -= learningRate * e;






        //        }
        //    }




        //}


        /// <summary>
        /// 利用0-9的数字，生成 应输出 结果序列。
        /// </summary>
        /// <param name="a">应输出值</param>
        /// <returns>应输出结果序列</returns>
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
                    k[i] = 0.000000;
                }

            }

            return k;
        }






    }
}
