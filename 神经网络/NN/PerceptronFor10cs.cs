using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 神经网络
{
    [Serializable]
    class PerceptronFor10 
    {



        [Serializable]
        public class Neural
        {
            int mCount;

            double[] mInput;

            public double[] mWeight;

            public double mThreshold;

            double mExport;

            public double[] getWeight()
            {
                return mWeight;
            }



            public double getExport()
            {

                double sum = 0;
                for (int i = 0; i < mCount; i++)
                {
                    sum += mInput[i] * mWeight[i];
                }
                sum -= mThreshold;

                return sigmoid(sum);
            }

            public void updateNeural()
            {

            }

            public Neural(int Length)
            {
                mCount = Length;

                mWeight = new double[mCount];

                initWeight();

                initThreshold();

            }

            public double trainingRate = 0.03;



            public double getOutput(double[] input, Boolean value)
            {



                mInput = input;

                double REAL_Y; //表示应该的输出值
                if (value == true)
                {
                    REAL_Y = 1.0;
                }
                else
                {
                    REAL_Y = 0.0;
                }


                double this_y = 0;

                for (int i = 0; i < mCount; i++)
                {

                    this_y += mWeight[i] * input[i];
                    this_y -= mThreshold;


                }

                this_y = sigmoid(this_y);

                for (int i = 0; i < mCount; i++)
                {

                    mWeight[i] += trainingRate * (REAL_Y - this_y) * input[i];


                }

                mThreshold = trainingRate * (REAL_Y - this_y) * mThreshold;








                if (mInput == null) { mInput = input; }




                return getExport();
            }

            private double sigmoid(double x)
            {
                return 1 / (1 + Math.Exp(-x));
            }

            public double getOutputWithoutTrain(double[] input)
            {
                mInput = input;
                return getExport();
            }






            public void initWeight()
            {
                for (int i = 0; i < mCount; i++)
                {
                    //mWeight[i] = 0; 
                    mWeight[i] = (new Random().Next()) % 1 - 0.5;
                    //MessageBox.Show(mWeight[i].ToString());
                }
            }

            public void initThreshold()
            {
                //mThreshold = 0; //( new Random().Next())%2-1;
                mThreshold = (new Random().Next()) % 1 - 0.5;
            }

        }
        

        public Neural[] innerNeural=new Neural[10];

        public PerceptronFor10()
        {
            for(int i = 0; i < 10; i++)
            {
                innerNeural[i] = new Neural(784);
            }
        }

        public void setLearningRate(double d)
        {
            for (int i = 0; i < 10; i++)
            {
                innerNeural[i].trainingRate = d;
            }
        }



        public void Train(LabeledPicture[] lp)
        {
            int k = 0;
            int count = lp.Length;

            for (int j = 0; j < count; j++)
            {


                LabeledPicture slp = lp[j];
                for (int inner = 0; inner < 10; inner++)
                {
                    Boolean tempb = (lp[j].label == inner);

                    double a = innerNeural[inner].getOutput(Surface.getDouble(slp.bit), tempb);
                    k++;
                }
            }
        }

        public int GetPreict(double[] picture)
        {
            double max=0;
            int index=0;
            for(int i = 0; i < 10; i++)
            {
                double k = innerNeural[i].getOutputWithoutTrain(picture);
                if(max<k)
                {
                    max = k;
                    index = i;
                }

            }
            return index;
        }
        
    }
}
