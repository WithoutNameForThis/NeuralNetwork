using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace 神经网络
{
    class DataDecode
    {

        static string PATH_IMAGE_60K =Application.StartupPath+ @"\res\train-images.idx3-ubyte";//@"D:\nn\train-images.idx3-ubyte";
        static string PATH_IMAGE_10K = Application.StartupPath + @"\res\t10k-images.idx3-ubyte";
        static string PATH_LABEL_60K = Application.StartupPath + @"\res\train-labels.idx1-ubyte";
        static string PATH_LABEL_10K = Application.StartupPath + @"\res\t10k-labels.idx1-ubyte";




        public static LabeledPicture[] getPicture(string Label_Path,string Image_Path,int count,int type=0)
        {
            FileStream fs_label = new FileStream(Label_Path, FileMode.Open);
            BinaryReader br_label = new BinaryReader(fs_label);

            FileStream fs_picture = new FileStream(Image_Path, FileMode.Open);
            BinaryReader br_picture = new BinaryReader(fs_picture);


            br_label.ReadBytes(8);
            br_picture.ReadBytes(16);  //跳过前面的标记

            LabeledPicture[] labledPicture = new LabeledPicture[count];

            for (int i = 0; i < count; i++)
            {
                int rb = br_label.Read();

                double[] tempB = new double[784];
                Byte[] bt = br_picture.ReadBytes(784);
                for (int j = 0; j < 784; j++)
                {
                    //if (bt[j] > 105)//115
                    //{
                    //    tempB[j] = 1.0;

                    //}


                    tempB[j] = ((double )bt[j]) / 256.0;

                    //if (tempB[j] > 0.3)
                    //{
                    //    MessageBox.Show(tempB[j].ToString());
                    //}


                }
                double[] tempLabel = new double[10];
                for(int j = 0; j < 10; j++)
                {
                    if (rb == j)
                    {
                        tempLabel[j] = 1.0;
                    }
                    else
                    {
                        if (type == 0)
                        {
                            tempLabel[j] = 0.0;
                        }
                        else
                        {
                            tempLabel[j] = -1.0;//for tanh
                        }

                    }

                }

                labledPicture[i] = new LabeledPicture(tempB, tempLabel,rb);


            }
            fs_label.Close();
            fs_picture.Close();

            return labledPicture;

        }
        public static LabeledPicture[] get60KPicture(int count)
        {
            return getPicture(PATH_LABEL_60K, PATH_IMAGE_60K,count);
        }

        public static LabeledPicture[] get10KPicture(int count)
        {
            return getPicture(PATH_LABEL_10K, PATH_IMAGE_10K,count);
        }

        public static LabeledPicture[] get60KPictureB(int count)
        {
            return getPicture(PATH_LABEL_60K, PATH_IMAGE_60K, count,1);
        }

        public static LabeledPicture[] get10KPictureB(int count)
        {
            return getPicture(PATH_LABEL_10K, PATH_IMAGE_10K, count,1);
        }
    }
}
