//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace 神经网络
//{
//    class NeuralLayout
//    {
//        public neuralNode[] innerNeural;


//        public void setInnerNeural(neuralNode[] nn)
//        {
//            innerNeural = nn;
//        }
//        public NeuralLayout(neuralNode[] nn)
//        {
//            innerNeural = nn;
//        }



//        public double[] output(double[] input)
//        {
//            double[] temp = new double[innerNeural[0].ConnectCout];

//            if (input.Count() != innerNeural.Count()) throw new Exception("数量不符");

//            for (int i = 0; i < innerNeural.Count(); i++)
//            {
//                double[] k = innerNeural[i].output(input[i]);
//                for (int j = 0; j < temp.Count(); j++)
//                {
//                    temp[j] += k[j];
//                }
//            }
//            return temp;
//        }
//    }
//}
