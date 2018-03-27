using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Media;

namespace 神经网络
{
    public partial class Ui : Form
    {

        public static int  scale;
        public static int sizeOfInput;



        class Painting
        {
            private Bitmap b; //= new Bitmap(sizeOfInput, sizeOfInput);

            


            public Painting( int size)
            {
                b= new Bitmap(sizeOfInput, sizeOfInput);
                clear();
            }

            public Bitmap getBitmap()
            {
                return b;
            }

            public void clear ()
            {
                b = new Bitmap(sizeOfInput, sizeOfInput);

                Graphics pixel = Graphics.FromImage(b);
                for (int j = 0; j < 28; j++)
                {
                    pixel.DrawLine(Pens.DarkCyan, new Point(sizeOfInput, scale * j), new Point(0, scale * j));


                    if (j == 4 || j == 24)
                    {
                        pixel.DrawLine(Pens.Red, new Point(sizeOfInput, scale * j), new Point(0, scale * j));

                    }
                    if (j == 6 || j == 22)
                    {
                        pixel.DrawLine(Pens.OrangeRed, new Point(sizeOfInput, scale * j), new Point(0, scale * j));

                    }
                }

                for (int j = 0; j < 28; j++)
                {
                    pixel.DrawLine(Pens.DarkCyan, new Point(scale * j, sizeOfInput), new Point(scale * j, 0));

                    if (j == 4 || j == 24)
                    {
                        pixel.DrawLine(Pens.Red, new Point(scale * j, sizeOfInput), new Point(scale * j, 0));

                    }
                    if (j == 6 || j == 22)
                    {
                        pixel.DrawLine(Pens.OrangeRed, new Point(scale * j, sizeOfInput), new Point(scale * j, 0));

                    }

                }




            }
            public void drawWeight(double[] weight)
            {
                Graphics pixel = Graphics.FromImage(b);

                // Rectangle R = new Rectangle(new Point(location.X * 20, location.Y * 20), new Size(20, 20));
                Pen a = new Pen(Color.AliceBlue);
                Font f = DefaultFont;
                Brush bc =new SolidBrush(Color.Red);
                
                



                for(int i = 0; i < 784; i++)
                {
                    string asas =string.Format("{0:0.00}", weight[i]);
                    pixel.DrawString(asas, f,bc,i%28*scale,i/28*scale);


                }

                //pixel.DrawRectangle(Pens.DarkCyan, R);
                //pixel.FillRectangle(Brushes.DarkCyan, R);
            }




            public void drawPixer(Point location)
            {
                Graphics pixel = Graphics.FromImage(b);

                Rectangle R = new Rectangle(new Point( location.X*scale,location.Y* scale), new Size(scale, scale));

                pixel.DrawRectangle(Pens.DarkCyan, R);
                pixel.FillRectangle(Brushes.DarkCyan, R);             
            }

            public void setPicture(Boolean[] b)
            {
                clear();
                for(int i = 0; i < 784; i++)
                {
                    if (b[i] == true)
                    {
                        drawPixer(new Point(((i % 28)),( i / 28)));
                    }
                }
            }


        }
        private Surface surface=new Surface();

        public Ui()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        

        private void input_Click(object sender, EventArgs e)
        {

        }


        double penWeight = 0.75;
        private void input_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                Point p = input.PointToClient(Control.MousePosition);
                int sk = 3;
                sk = (int)(1/penWeight);

                //MessageBox.Show(sk.ToString());
                painting.drawPixer(new Point(p.X / scale,p.Y / scale));
                painting.drawPixer(new Point((p.X+scale/sk) / scale, p.Y / scale));
                painting.drawPixer(new Point(p.X / scale, (p.Y + scale/ sk )/ scale));
                painting.drawPixer(new Point((p.X - scale / sk) / scale, p.Y / scale));
                painting.drawPixer(new Point(p.X / scale, (p.Y - scale / sk) / scale));

                input.Image = painting.getBitmap();

                surface.setSingleData(p.X / scale % 28 + p.Y / scale * 28);
                surface.setSingleData((p.X + scale / sk) / scale % 28 + p.Y / scale * 28);
                surface.setSingleData(p.X / scale % 28 + (p.Y + scale / sk) / scale * 28);
                surface.setSingleData((p.X - scale / sk) / scale % 28 + p.Y / scale * 28);
                surface.setSingleData(p.X / scale % 28 + (p.Y - scale / sk) / scale * 28);

            }
        }




        public void clear()
        {
            surface.reSet();

            painting.clear();
            input.Image = painting.getBitmap();


        }


        private Painting painting;//= new Painting();





        private void Form1_Load(object sender, EventArgs e)
        {
            scale = input.Size.Height/28;

            sizeOfInput = input.Size.Height;

            painting = new Painting(sizeOfInput);

            input.Image = painting.getBitmap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            painting.clear();
            input.Image = painting.getBitmap();


            surface.reSet();
            //listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  Boolean[] inputX = surface.getData();
           // listBox1.Items.Clear();
            for(int i = 0; i < (28 * 28); i++)
            {
                if (surface.getSingleData(i) == true)
                {
                    //listBox1.Items.Add(string.Format("{0},{1}",i%28,i/28));
                }
            }

            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        PerceptronFor10 perceptron= new PerceptronFor10();
       // public
        private void button3_Click(object sender, EventArgs e)
        {

            int count = 60000;

            LabeledPicture[] lp = dataDecode.get60KPicture(count);

            perceptron.Train(lp);

            MessageBox.Show("finish");



            //for(int index = 0; index < 10; index++)
            //{
            //    n[index] = new Neural(784);
            //}




            ////double max=0;
            ////double min = 0;

            ////double sum = 0;
            ////double count = 0;

            //int k = 0;

            //    for (int j = 0; j < count; j++)
            //    {
            //       // do { i++; } while (lp[i].label != 1 );






            //        LabeledPicture slp = lp[j];

            //     //   painting.setPicture(slp.bit);

            //     //   input.Image = painting.getBitmap();

            //        label_N.Text = slp.label.ToString();

            //    for(int inner = 0; inner < 10; inner++)
            //    {
            //         Boolean tempb = (lp[j].label == inner);

            //        double a = n[inner].getOutput(Surface.getDouble(slp.bit),tempb);
            //        k++;
         //   //    }



         //}


      









            //painting.drawWeight(n[1].getWeight());

            //MessageBox
            //    .Show(max.ToString());
            //MessageBox.Show(min.ToString());

            //MessageBox.Show((sum / count).ToString());

            //MessageBox.Show("finish"+k.ToString());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            painting.setPicture(surface.getData());

            input.Image = painting.getBitmap();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  MessageBox.Show(n[listBox2.SelectedIndex].getOutputWithoutTrain(Surface.getDouble(surface.getData())).ToString());

          //  painting.drawWeight(n[listBox2.SelectedIndex].getWeight());

          //input.Image = painting.getBitmap();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //double max = -999 ;
            //double nc=0;
            //for (int i =0; i < 10; i++) {
            //    double temp = n[i].getOutputWithoutTrain(Surface.getDouble(surface.getData()));
            //    if(max< temp)
            //    {
            //        nc = i;
            //        max = n[i].getOutputWithoutTrain(Surface.getDouble(surface.getData()));
            //    }

            //}
            if (perceptron == null)
            {
                MessageBox.Show("请先训练");
                return;
            }
            MessageBox.Show(perceptron.GetPreict(Surface.getDouble(surface.getData())).ToString());





            painting.clear();
            input.Image = painting.getBitmap();


            surface.reSet();
            //listBox1.Items.Clear();



        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(perceptron, dataDecode.get10KPicture(10000)).ToString());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(perceptron, dataDecode.get60KPicture(60000)).ToString());
        }

        //BigNeural bigNeural = new BigNeural();
       

        private void button7_Click(object sender, EventArgs e)
        {

            MessageBox.Show(nnc.getOutput(Surface.getDouble(surface.getData())).ToString());

            //MessageBox.Show(nnf2.output(Surface.getDouble(surface.getData()))[0].ToString());

            ////MessageBox.Show(neuralNetwork.output(Surface.getDouble(surface.getData()))[3].ToString());
            ////MessageBox.Show(bigNeural.output(TestUnit.getFilledPicture())[0].ToString());

            //listBox1.Items.Clear();
            //listBox2.Items.Clear();
            //listBox3.Items.Clear();
            //double max = 0;
            //int index = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    double k = nnf.output(Surface.getDouble(surface.getData()))[i];
            //    if(max< k)
            //    {
            //        max = k;
            //        index = i;
            //    }

            //    listBox1.Items.Add(k.ToString());

            //}


           // MessageBox.Show();
            //for(int i = 0; i < 20; i++)
            //{
            //  //  listBox2.Items.Add(neuralNetwork.showNeural[0].Weight[i].ToString());
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    //listBox3.Items.Add(neuralNetwork..ToString());
            //}


            ////MessageBox.Show(neuralNetwork.result.innerNeural[0].Weight[3].ToString());
            painting.clear();
            input.Image = painting.getBitmap();


            surface.reSet();
        }



        //NeuralNetworkFinal nnf = new NeuralNetworkFinal(784,50,10);
        //NeuralNetworkFinal[] nnfc = new NeuralNetworkFinal[10];

        NeuralNetworkC7845010 nnc=new NeuralNetworkC7845010();
        NeuralNetworkB78450110 nnb = new NeuralNetworkB78450110();

        private void button6_Click(object sender, EventArgs e)
        {
            for(int j = 0; j < 4; j++)
            {


                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                nnc.setLearningRate(0.32 - j * 0.10);
                nnc.train(lp);


            }

            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnc, dataDecode.get10KPicture(10000)).ToString());

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void h1w1_Click(object sender, EventArgs e)
        {

        }

        private void h1w2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {




        }







        //}
        private string forN(double a)
        {
            return string.Format("{0:0.00}", a);
        }

        //private void button12_Click(object sender, EventArgs e)
        //{
        //    double[] input = {double.Parse( i1.Text),(double.Parse( i1.Text)) };
        //    double[] k = nnex.output(input);
        //    MessageBox.Show(k[0].ToString());


        //}

        private void button13_Click(object sender, EventArgs e)
        {
            
        }


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

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnc, dataDecode.get60KPicture(60000)).ToString());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nnb.getOutput(Surface.getDouble(surface.getData())).ToString());

            painting.clear();
            input.Image = painting.getBitmap();
            surface.reSet();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 4; j++)
            {


                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                nnc.setLearningRate(0.10 - j * 0.030);
                nnc.train(lp);


            }

            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 4; j++)
            {
                //MessageBox.Show(j.ToString());

                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                nnb.setLearningRate(0.32 - j * 0.10);
                nnb.train(lp);


            }

            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnb, dataDecode.get10KPicture(10000)).ToString());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 4; j++)
            {


                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                nnb.setLearningRate(0.10 - j * 0.030);
                nnb.train(lp);


            }

            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnb, dataDecode.get60KPicture(60000)).ToString());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ObjectSaver<PerceptronFor10>.saveToLocal(perceptron, "NNA78410");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            perceptron = ObjectSaver<PerceptronFor10>.loadByFile("NNA78410");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            ObjectSaver<NeuralNetworkC7845010>.saveToLocal(nnc, "NeuralNetworkC7845010");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            nnc = ObjectSaver<NeuralNetworkC7845010>.loadByFile("NeuralNetworkC7845010");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            ObjectSaver<NeuralNetworkB78450110>.saveToLocal(nnb, "NeuralNetworkB78450110");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            nnb  = ObjectSaver<NeuralNetworkB78450110>.loadByFile( "NeuralNetworkB78450110");
        }

        private void button26_Click(object sender, EventArgs e)
        {


                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                nnb.setLearningRate(double.Parse(textBox1.Text));
                nnb.train(lp);



            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nnc150.getOutput(Surface.getDouble(surface.getData())).ToString());

            painting.clear();
            input.Image = painting.getBitmap();
            surface.reSet();
        }
        NeuralNetworkC78415010 nnc150=new NeuralNetworkC78415010();
        private void button30_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 4; j++)
            {


                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                nnc150.setLearningRate(0.47 - j * 0.15);
                nnc150.train(lp);


            }

            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 4; j++)
            {


                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                nnc150.setLearningRate(0.10 - j * 0.030);
                nnc150.train(lp);


            }

            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private void button33_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnc150, dataDecode.get10KPicture(10000)).ToString());
        }

        private void button32_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnc150, dataDecode.get60KPicture(60000)).ToString());
        }

        private void button28_Click(object sender, EventArgs e)
        {
            ObjectSaver<NeuralNetworkC78415010>.saveToLocal(nnc150, "NeuralNetworkC78415010");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            nnc150 = ObjectSaver<NeuralNetworkC78415010>.loadByFile("NeuralNetworkC78415010");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int count = 60000;

            LabeledPicture[] lp = dataDecode.get60KPicture(count);
            perceptron.setLearningRate(double.Parse(textBox7.Text));
            perceptron.Train(lp);



            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        NerualNetworkBC105CP nnbcp;//= new NerualNetworkBC105CP(nnb, nnc150, nnc, nnp);
        private void button10_Click_1(object sender, EventArgs e)
        {
            nnbcp = new NerualNetworkBC105CP(nnb, nnc150, nnc, perceptron,nnt,nno);
            MessageBox.Show(nnbcp.getOutput(Surface.getDouble(surface.getData())).ToString());
            //listBox1.Items.Clear();

            //listBox1.Items.Add(perceptron.GetPreict(Surface.getDouble(surface.getData())).ToString());
            //listBox1.Items.Add(nnc.getOutput(Surface.getDouble(surface.getData())).ToString());
            //listBox1.Items.Add(nnc150.getOutput(Surface.getDouble(surface.getData())).ToString());
            //listBox1.Items.Add(nnb.getOutput(Surface.getDouble(surface.getData())).ToString());



            painting.clear();
            input.Image = painting.getBitmap();
            surface.reSet();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            nnbcp = new NerualNetworkBC105CP(nnb, nnc150, nnc, perceptron, nnt, nno);
            MessageBox.Show(TestUnit.getAcc(nnbcp, dataDecode.get10KPicture(10000)).ToString());
        }


        NeuralNetworkT7845010 nnt=new NeuralNetworkT7845010();
        private void button36_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 10; j++)
            {
                //MessageBox.Show(j.ToString());

                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                nnt.setLearningRate(0.01 );
                nnt.train(lp);


            }

            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private void button39_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnt, dataDecode.get10KPicture(10000)).ToString());
        }

        private void button37_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nnt.getOutput(Surface.getDouble(surface.getData())).ToString());

            painting.clear();
            input.Image = painting.getBitmap();
            surface.reSet();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            ObjectSaver<NeuralNetworkT7845010>.saveToLocal(nnt, "NeuralNetworkT7845010");
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            nnt = ObjectSaver<NeuralNetworkT7845010>.loadByFile("NeuralNetworkT7845010");
        }

        private void button12_Click(object sender, EventArgs e)
        {

            int count = 60000;

            LabeledPicture[] lp = dataDecode.get60KPicture(count);
            nnt.setLearningRate(double.Parse(textBox3.Text));
            nnt.train(lp);



            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private void button38_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnt, dataDecode.get60KPicture(60000)).ToString());
        }

        NeuralNetworkR7845010 nnr = new NeuralNetworkR7845010();
        private void button44_Click(object sender, EventArgs e)
        {
            //for (int j = 0; j < 1; j++)
            //{
                //MessageBox.Show(j.ToString());

                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                 nnr.setLearningRate(0.03);
                nnr.train(lp);


            //}

            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private void button47_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnr, dataDecode.get10KPicture(10000)).ToString());
        }

        private void button46_Click(object sender, EventArgs e)
        {

        }

        private void button55_Click(object sender, EventArgs e)
        {
            nnbcp = new NerualNetworkBC105CP(nnb, nnc150, nnc, perceptron, nnt, nno);
            MessageBox.Show(TestUnit.getAcc(nnbcp, dataDecode.get60KPicture(60000)).ToString());

        }
        NeuralNetworkReLu nnrn = new NeuralNetworkReLu(784, 25, 10);
        private void button40_Click(object sender, EventArgs e)
        {
            int count = 60000;

            LabeledPicture[] lp = dataDecode.get60KPicture(count);
            //nnr.setLearningRate(double.Parse(textBox4.Text));
            //nnr.train(lp);

            for(int i = 0; i < lp.Length; i++)
            {
                listBox1.Items.Add("  ");
                listBox1.Items.Add(lp[i].label);
                listBox1.Items.Add( nnrn.train(lp[i].getDouble(), getEx(lp[i].label)).ToString());
            }



            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            MessageBox.Show("finish");
        }

        private int indexer = 0;
            LabeledPicture[] lp = dataDecode.get10KPicture(10000);
        private void button48_Click(object sender, EventArgs e)
        {

            for(int j = 0; j < 10; j--)
            {
                button48.Text = lp[indexer].label.ToString();
                painting.setPicture(lp[indexer].bit);
                surface.setData(lp[indexer].bit);
                input.Image = painting.getBitmap();
                
                indexer++;

                nnbcp = new NerualNetworkBC105CP(nnb, nnc150, nnc, perceptron, nnt, nno);
                int a = nnbcp.getOutput(Surface.getDouble(surface.getData()));
                button52.Text = a.ToString();

                if (lp[indexer-1].label!= a) break;


                painting.clear();
                input.Image = painting.getBitmap();
                surface.reSet();
            }




        }
        LabeledPicture[] lp60k = dataDecode.get60KPicture(60000);
        private void button52_Click(object sender, EventArgs e)
        {
            button48.Text = lp60k[indexer].label.ToString();



            painting.setPicture(lp60k[indexer].bit);
            //painting.setPicture(MovePicture(lp60k[indexer], -4, -4).bit);


            surface.setData(lp60k[indexer].bit);
            input.Image = painting.getBitmap();
            indexer++;


            //nnbcp = new NerualNetworkBC105CP(nnb, nnc150, nnc, perceptron, nnt, nno);
            MessageBox.Show(perceptron.GetPreict(Surface.getDouble(surface.getData())).ToString());


            painting.clear();
            input.Image = painting.getBitmap();
            surface.reSet();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void maskedTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

                
                


        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                penWeight = double.Parse(maskedTextBox1.Text);
            }
        }

        NNOT nno = new NNOT();

        

        private void button62_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nno.getOutput(Surface.getDouble(surface.getData())).ToString());

            painting.clear();
            input.Image = painting.getBitmap();
            surface.reSet();
        }
        int jk = 0;








        private void t() {


            for (int j = 0; j < 1; j++)
            {

                jk = j;
                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);



                nno.setLearningRate(0.005 - j * 0.05);
                nno.train(lp);


            }

            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
           // MessageBox.Show("finish");
            MessageBox.Show(TestUnit.getAcc(nno, dataDecode.get10KPicture(10000)).ToString());
        }

        private void button61_Click(object sender, EventArgs e)
        {


            Thread t1 = new Thread(t);
            t1.Start();
            
        }

        private void button64_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nno, dataDecode.get10KPicture(10000)).ToString());
        }

        private void button59_Click(object sender, EventArgs e)
        {
            nno.Save();
            //ObjectSaver<NNOT>.saveToLocal(nno, "NNOT");
        }

        private void button58_Click(object sender, EventArgs e)
        {
            nno.Load();
            //nno = ObjectSaver<NNOT>.loadByFile("NNOT");
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button57_Click(object sender, EventArgs e)
        {
            int count = 60000;

            LabeledPicture[] lp = dataDecode.get60KPicture(count);
            nno.setLearningRate(double.Parse(textBox8.Text));
            //nno.train(lp);

            Thread t1 = new Thread(t);
            t1.Start();

            //neuralNetwork.train(lp);
            //SystemSounds.Beep.Play();
            //MessageBox.Show("finish");
        }

        private void button49_Click(object sender, EventArgs e)
        {

        }

        private void button65_Click(object sender, EventArgs e)
        {
            nnbcp = new NerualNetworkBC105CP(nnb, nnc150, nnc, perceptron, nnt, nno);
            listBox2.Items.Clear();
            listBox2.Items.Add(perceptron.GetPreict(Surface.getDouble(surface.getData())).ToString());
            listBox2.Items.Add(nnc.getOutput(Surface.getDouble(surface.getData())).ToString());
            listBox2.Items.Add(nnc150.getOutput(Surface.getDouble(surface.getData())).ToString());
            listBox2.Items.Add(nnb.getOutput(Surface.getDouble(surface.getData())).ToString());
            listBox2.Items.Add(nnt.getOutput(Surface.getDouble(surface.getData())).ToString());
            listBox2.Items.Add(nnbcp.getOutput(Surface.getDouble(surface.getData())).ToString());
            listBox2.Items.Add(nno.getOutput(Surface.getDouble(surface.getData())).ToString());

            painting.clear();
            input.Image = painting.getBitmap();
            surface.reSet();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nno, dataDecode.get60KPicture(60000)).ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Maximum = nno.max;
            progressBar1.Value = nno.pro;





            label1.Text=jk.ToString();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
            string str;
            string str_t="";
            LabeledPicture[] lp = dataDecode.get60KPicture(100);

            for(int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    str = string.Format("insert into dsv values({0},{1});"
                        ,j, lp[j].label);
                    str_t += str;
                    str_t += Environment.NewLine;
                }
            }
            textBox9.Text = str_t;

            textBox9.SelectAll();

        }

        private void textBox9_MouseEnter(object sender, EventArgs e)
        {
            textBox9.SelectAll();
        }

        private void button53_Click(object sender, EventArgs e)
        {

        }

        private void button60_Click(object sender, EventArgs e)
        {
            Thread t2 = new Thread(t1);
            t2.Start();
        }

        private void t1()
        {
            DateTime past = DateTime.Now;


            double tr = double.Parse(text_rate.Text);
            int trainTime = int.Parse(text_time.Text);
            double preTrainDecRate = double.Parse(text_dec.Text);


            for (int j = 0; j < trainTime; j++)
            {

                jk = j;
                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                nno.setLearningRate(tr);
                nno.train(lp);

                tr /= preTrainDecRate;

                text_rate.Text = tr.ToString();


                text_time.Text = (int.Parse(text_time.Text) - 1).ToString() ;


                label1.Text = j.ToString();




                listBox1.Items.Add(TestUnit.getAcc(nno, dataDecode.get10KPicture(10000)));

            }

            //neuralNetwork.train(lp);
            SystemSounds.Beep.Play();
            // MessageBox.Show("finish");
            //MessageBox.Show(TestUnit.getAcc(nno, dataDecode.get10KPicture(10000)).ToString());

            MessageBox.Show((((DateTime.Now - past).TotalMilliseconds)/1000).ToString());
        }

        private void button70_Click(object sender, EventArgs e)
        {
            Thread t2 = new Thread(th2);
            t2.Start();
        }
        NNOTC nnotc = new NNOTC();
        private void th2()
        {




            double tr = double.Parse(text_rate_2.Text);
            int trainTime = int.Parse(text_time_2.Text);
            double preTrainDecRate = double.Parse(text_dec_2.Text);


            for (int j = 0; j < trainTime; j++)
            {

                jk = j;
                int count = 60000;

                LabeledPicture[] lp = dataDecode.get60KPicture(count);
                nnotc.setLearningRate(tr);
                nnotc.train(lp);
                tr /= preTrainDecRate;
                text_rate_2.Text = tr.ToString();
                text_time_2.Text = (int.Parse(text_time_2.Text) - 1).ToString();
                label1.Text = j.ToString();
                listBox3.Items.Add(TestUnit.getAcc(nnotc, dataDecode.get10KPicture(10000)));

            }


            SystemSounds.Beep.Play();
            MessageBox.Show(TestUnit.getAcc(nnotc, dataDecode.get10KPicture(10000)).ToString());


        }

        private void button73_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnotc, dataDecode.get10KPicture(10000)).ToString());
        }

        private void button72_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestUnit.getAcc(nnotc, dataDecode.get60KPicture(60000)).ToString());
        }

        private void button69_Click(object sender, EventArgs e)
        {
            ObjectSaver<NNOTC>.saveToLocal(nnotc, "NNOTC");
        }

        private void button68_Click(object sender, EventArgs e)
        {
            nnotc = ObjectSaver<NNOTC>.loadByFile("NNOTC");
        }

        private void button71_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nnotc.getOutput(Surface.getDouble(surface.getData())).ToString());

            painting.clear();
            input.Image = painting.getBitmap();
            surface.reSet();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            nno.Test();
        }
    }
    
 
}
