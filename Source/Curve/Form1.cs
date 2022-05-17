using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Curve.Lib;

namespace Curve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int length = 10;
            double[] par = GaussHelper.MultiLine(arrX, arrY, arrX.Length, 5);
            arrNewX = new double[13];
            arrNewY = new double[13];
            for (int x = 1; x <= 13; x++)
            {
                double y = 0;
                for (int i = 0; i < par.Length; i++)
                {
                    y += par[i] * Math.Pow(x, i);
                    //if (i == 0)
                    //{
                    //    y += par[i];
                    //}
                    //else
                    //{
                    //    y += par[i] * Math.Pow(x, i);
                    //}
                }

                arrNewX[x - 1] = x;
                arrNewY[x - 1] = y;

                this.Refresh();
            }

            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的.
            Pen p = new Pen(Color.Blue, 2);//定义了一个蓝色,宽度为的画笔
            Pen p2 = new Pen(Color.Green, 2);//定义了一个蓝色,宽度为的画笔
            float sx1 = 800f / 20f;
            float sy1 = 600f / 20f;


            for (int i = 0; i < arrX.Length-1; i++)
            {
                g.DrawLine(p, (float)arrX[i] * sx1, (float)arrY[i] * sy1, (float)arrX[i + 1] * sx1, (float)arrY[i + 1] * sy1);
            }

            for (int i = 0; i < arrNewX.Length-1; i++)
            {
                
                g.DrawLine(p2, (float)arrNewX[i] * sx1, (float)arrNewY[i] * sy1, (float)arrNewX[i + 1] * sx1, (float)arrNewY[i + 1] * sy1);
            }

           
            //    g.DrawRectangle(p, 10, 10, 100, 100);//在画板上画矩形,起始坐标为(10,10),宽为,高为
            //g.DrawEllipse(p, 10, 10, 100, 100);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
        }


        double[] arrX = new double[] { 1, 2, 3, 7, 8, 9, 10, 11, 12, 13 };
        double[] arrY = new double[] { 1, 0, 3, 0, 4, 0, 10, 0, 11, 0 };

        double[] arrNewX = null;
        double[] arrNewY = null;

        private void button1_Click(object sender, EventArgs e)
        {
            
            int length=10;
            double[] par = GaussHelper.MultiLine(arrX, arrY, 10, 10);
            arrNewX = new double[13];
            arrNewY = new double[13];
            for (int x = 1; x <= 13; x++)
            {
                double y = 0;
                for (int i = 0; i < par.Length; i++)
                {
                    y += par[i] * Math.Pow(x, i);
                    //if (i == 0)
                    //{
                    //    y += par[i];
                    //}
                    //else
                    //{
                    //    y += par[i] * Math.Pow(x, i);
                    //}
                }

                arrNewX[x - 1] = x;
                arrNewY[x - 1] = y;
                //textBox1.Text += string.Format("x:{0}-y:{1}\r\n", x, y);
                this.Refresh();
            }

                MessageBox.Show(par.Length.ToString());
        }
    }
}
