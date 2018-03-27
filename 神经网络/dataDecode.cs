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
    class dataDecode
    {

        static string PATH_IMAGE_60K =Application.StartupPath+ @"\res\train-images.idx3-ubyte";//@"D:\nn\train-images.idx3-ubyte";
        static string PATH_IMAGE_10K = Application.StartupPath + @"\res\t10k-images.idx3-ubyte";
        static string PATH_LABEL_60K = Application.StartupPath + @"\res\train-labels.idx1-ubyte";
        static string PATH_LABEL_10K = Application.StartupPath + @"\res\t10k-labels.idx1-ubyte";


        // const string PAT
        public static LabeledPictureEx[] get60KPictureEx(int count)
        {
            return getPictureEx(PATH_LABEL_60K, PATH_IMAGE_60K, count);
        }

        public static LabeledPictureEx[] get10KPictureEx(int count)
        {
            return getPictureEx(PATH_LABEL_10K, PATH_IMAGE_10K, count);
        }


        public static LabeledPictureEx[] getPictureEx(string Label_Path, string Image_Path, int count)
        {
            FileStream fs_label = new FileStream(Label_Path, FileMode.Open);
            BinaryReader br_label = new BinaryReader(fs_label);

            FileStream fs_picture = new FileStream(Image_Path, FileMode.Open);
            BinaryReader br_picture = new BinaryReader(fs_picture);


            br_label.ReadBytes(8);
            br_picture.ReadBytes(16);  //跳过前面的标记


            //  int[] rb = new int[10000]; //标签

            //  Boolean[][] tempB = new Boolean[10000][]; //图片

            LabeledPictureEx[] labledPicture = new LabeledPictureEx[count];

            for (int i = 0; i < count; i++)
            {
                int rb = br_label.Read();

                double[] tempB = new double[784];
                Byte[] bt = br_picture.ReadBytes(784);
                for (int j = 0; j < 784; j++)
                {
                    if (bt[j] > 0)//115
                    {
                        tempB[j] = bt[j]/256;
                    }
                }

                labledPicture[i] = new LabeledPictureEx(tempB, rb);


            }
            fs_label.Close();
            fs_picture.Close();

            return labledPicture;
        }


        public static LabeledPicture[] getPicture(string Label_Path,string Image_Path,int count)
        {
            FileStream fs_label = new FileStream(Label_Path, FileMode.Open);
            BinaryReader br_label = new BinaryReader(fs_label);

            FileStream fs_picture = new FileStream(Image_Path, FileMode.Open);
            BinaryReader br_picture = new BinaryReader(fs_picture);


            br_label.ReadBytes(8);
            br_picture.ReadBytes(16);  //跳过前面的标记


            //  int[] rb = new int[10000]; //标签

            //  Boolean[][] tempB = new Boolean[10000][]; //图片

            LabeledPicture[] labledPicture = new LabeledPicture[count];

            for (int i = 0; i < count; i++)
            {
                int rb = br_label.Read();

                Boolean[] tempB = new Boolean[784];
                Byte[] bt = br_picture.ReadBytes(784);
                for (int j = 0; j < 784; j++)
                {
                    if (bt[j] > 105)//115
                    {
                        tempB[j] = true;

                    }
                }

                labledPicture[i] = new LabeledPicture(tempB, rb);


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


    }
}
