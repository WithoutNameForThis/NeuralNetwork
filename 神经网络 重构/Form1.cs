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

namespace 神经网络
{
    public partial class frm_main : Form
    {
        class MainInput
        {

            private PictureBox _ImgForShow;
            public MainInput(PictureBox picBox)
            {
                _ImgForShow = picBox;
                _Width = _ImgForShow.Width;

                _Scale = _Width / 28;

                inti();
                _ImgForShow.MouseMove += _ImgForShow_MouseMove; ;
            }
            private double _PenWidth = 0.75;
            private void _ImgForShow_MouseMove(object sender, MouseEventArgs e)
            {
                if (MouseButtons == MouseButtons.Left)
                {
                    Point p = _ImgForShow.PointToClient(Control.MousePosition);
                    int sk = 3;
                    sk = (int)(1 / _PenWidth);

                    //MessageBox.Show(sk.ToString());
                    drawPixer(new Point(p.X / _Scale, p.Y / _Scale));
                    drawPixer(new Point((p.X + _Scale / sk) / _Scale, p.Y / _Scale));
                    drawPixer(new Point(p.X / _Scale, (p.Y + _Scale / sk) / _Scale));
                    drawPixer(new Point((p.X - _Scale / sk) / _Scale, p.Y / _Scale));
                    drawPixer(new Point(p.X / _Scale, (p.Y - _Scale / sk) / _Scale));

                    _ImgForShow.Image = _Bitmap;

                }
                
            }

            private int _Width;

            private int _Scale;

            private Bitmap _Bitmap;

            private double[] _Input;
            public void inti()
            {
                _Bitmap = new Bitmap(_Width, _Width);
                //drawIntiLine();

                _ImgForShow.Image = _Bitmap;
                _Input = new double[784];
            }
            
            private void drawIntiLine()
            {
                Graphics pixel = Graphics.FromImage(_Bitmap);
                for (int j = 0; j < 28; j++)
                {
                    pixel.DrawLine(Pens.DarkCyan, new Point(_Width, _Scale * j), new Point(0, _Scale * j));


                    if (j == 4 || j == 24)
                    {
                        pixel.DrawLine(Pens.Red, new Point(_Width, _Scale * j), new Point(0, _Scale * j));

                    }
                    if (j == 6 || j == 22)
                    {
                        pixel.DrawLine(Pens.OrangeRed, new Point(_Width, _Scale * j), new Point(0, _Scale * j));

                    }
                }

                for (int j = 0; j < 28; j++)
                {
                    pixel.DrawLine(Pens.DarkCyan, new Point(_Scale * j, _Width), new Point(_Scale * j, 0));

                    if (j == 4 || j == 24)
                    {
                        pixel.DrawLine(Pens.Red, new Point(_Scale * j, _Width), new Point(_Scale * j, 0));

                    }
                    if (j == 6 || j == 22)
                    {
                        pixel.DrawLine(Pens.OrangeRed, new Point(_Scale * j, _Width), new Point(_Scale * j, 0));

                    }

                }
            }

            public void drawPixer(Point location)
            {
                if (location.X >= 28 || location.Y >= 28) return;

                Graphics pixel = Graphics.FromImage(_Bitmap);

                Rectangle R = new Rectangle(new Point(location.X * _Scale, location.Y * _Scale), new Size(_Scale, _Scale));



                //pixel.DrawRectangle(Pens.DarkCyan, R);
                //pixel.FillRectangle(Brushes.DarkCyan, R);
                Color c = Color.FromArgb(0,0,0);
                Pen p = new Pen(c);
                //pixel.DrawRectangle(p, R);
                pixel.FillRectangle(new SolidBrush(c), R);

                _Input[location.X + location.Y * 28] = 1.0;

            }



            public void drawPixer(Point location,double deep)
            {
                if (location.X >= 28 || location.Y >= 28) return;

                Graphics pixel = Graphics.FromImage(_Bitmap);

                Rectangle R = new Rectangle(new Point(location.X * _Scale, location.Y * _Scale), new Size(_Scale, _Scale));


                Color c = Color.FromArgb((int)(255-255 * deep), (int)(255 - 255 * deep), (int)(255 - 255 * deep));
                Pen p = new Pen(c);
                
                //pixel.DrawRectangle(p, R);
                pixel.FillRectangle(new SolidBrush(c), R);
                



                _Input[location.X + location.Y * 28] = 1.0;

            }

            public void setInput(LabeledPicture lp)
            {
                _Input = lp.getDouble();
            }

            public void drawPic(LabeledPicture lp)
            {
                inti();
                for (int iy = 0; iy < 28; iy++) 
                {
                    for(int ix = 0; ix < 28; ix++)
                    {
                        //if (lp.getDouble()[ix + iy * 28]>0.1)
                        //{
                            drawPixer(new Point(ix, iy), lp.getDouble()[ix + iy * 28]);
                        //}
                    }
                }
                _Input = lp.getDouble();
            }


            public double[] getInput()
            {
                return _Input;
            }
        }




        public frm_main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        MainInput _MainInput;
        private void frm_main_Load(object sender, EventArgs e)
        {
            _MainInput = new MainInput(img_input);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            _MainInput.inti();
        }


        NNOT nnot = new NNOT();

        private void btn_train_Click(object sender, EventArgs e)
        {


            Thread thread_run = new Thread(trainNNOT);

            thread_run.Start();

            tim_keeper.Enabled = true;
            
        }
        private void trainNNOT()
        {
            double tr = double.Parse(text_rate.Text);
            int trainTime = int.Parse(text_time.Text);
            double preTrainDecRate = double.Parse(text_dec.Text);

            

            for (int j = 0; j < trainTime; j++)
            {


                nnot.setLearningRate(tr);
                nnot.train(DataDecode.get60KPictureB(60000));
                tr /= preTrainDecRate;

                text_rate.Text = tr.ToString();
                text_time.Text = (int.Parse(text_time.Text) - 1).ToString();

                list_acc.Items.Add(nnot.test(DataDecode.get10KPicture(10000)).ToString());
            }
                


        }


        private void btn_test_Click(object sender, EventArgs e)
        {
            MessageBox.Show( nnot.test(DataDecode.get10KPictureB(10000)).ToString());
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nnot.getOutput(_MainInput.getInput()).ToString());
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            nnot.Load();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            nnot.Save();
        }

        private void tim_keeper_Tick(object sender, EventArgs e)
        {
            pro_pro.Maximum = nnot.max;
            pro_pro.Value = nnot.pro;


        }

        private void pro_pro_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            nnot.addLayer();

        }

        private void btn_reg_plus_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int ix = 0; ix < 5; ix+=2)
            {
                for(int iy = 0; iy < 5; iy+=2)
                {

                    double[] args = nnot.getOutputRaw(_MainInput.getInput());

                    string str = string.Format("{0},{1}:{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}", ix, iy, args[0].ToString("F1"), args[1].ToString("F1"), args[2].ToString("F1"), args[3].ToString("F1"), args[4].ToString("F1"), args[5].ToString("F1"), args[6].ToString("F1"), args[7].ToString("F1"), args[8].ToString("F1"), args[9].ToString("F1"));

                    listBox1.Items.Add(str);


                }
            }
            
        }

        int re = 0;
        private void btn_error_Click(object sender, EventArgs e)
        {
            LabeledPicture[] lps = DataDecode.get10KPicture(10000);
            for(int i = re; i < 10000; i++)
            {
                re++;
                if (nnot.getOutput(lps[i].getDouble()) != lps[i].getNumLabel()){
                    MessageBox.Show(i.ToString()+" "+lps[i].getNumLabel().ToString());
                    _MainInput.drawPic(lps[i]);
                    break;
                }
                
            }
        }

        int re1 = 0;
        private void btn_error_train_Click(object sender, EventArgs e)
        {
            LabeledPicture[] lps = DataDecode.get60KPicture(60000);
            for (int i = re1; i < 60000; i++)
            {
                re1++;
                if (nnot.getOutput(lps[i].getDouble()) != lps[i].getNumLabel())
                {
                    MessageBox.Show(i.ToString() + " " + lps[i].getNumLabel().ToString());
                    _MainInput.drawPic(lps[i]);
                    break;
                }

            }
        }
    }
}
