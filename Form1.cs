using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Approximation_dots
{
    public partial class MainForm : Form
    {
        private int width;
        private int height;
        private float a;
        private float b;
        private int sumP, sumX, sumY, sumX2;
        private int max = int.MinValue;
        private int min = int.MaxValue;
        private int x_max;
        private int x_min;
        private Graphics g;

        private List<int> x;
        private List<int> y;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            width = ClientSize.Width;
            height = ClientSize.Height;

            x = new List<int>();
            y = new List<int>();

            sumP = 0;
            sumX = 0;
            sumY = 0;
            sumX2 = 0;
            a = 0;
            b = 0;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            for (int i = 0; i < x.Count; i++)
            {
                g.FillEllipse(new SolidBrush(Color.Black), x[i] - 4, y[i] - 4, 8, 8);
            }

            if (min != int.MaxValue && max != int.MinValue)
            {
                g.DrawLine(new Pen(Color.Red, 2), x_min, min, x_max, max);
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            x.Add(e.X);
            y.Add(e.Y);
            if (x.Count > 1)
            {
                Approximating();
                for (int i = 0; i < width; i++)
                {
                    if (i * a + b < height)
                    {
                        if (i * a + b > max)
                        {
                            max = (int)(i * a + b);
                            x_max = i;
                        }
                        if (i * a + b < min)
                        {
                            min = (int)(i * a + b);
                            x_min = i;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            label1.Text = "a: " + a;
            label2.Text = "b: " + b;
            Invalidate();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            x_label.Text = "X: " + e.X;
            y_label.Text = "Y: " + e.Y;
        }

        private void Approximating()
        {
            sumP = 0;
            sumX = 0;
            sumY = 0;
            sumX2 = 0;
            a = 0;
            b = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sumP += x[i] * y[i];
                sumX += x[i];
                sumY += y[i];
                sumX2 += x[i] * x[i];
            }
            a = (float)(x.Count * sumP - sumX * sumY) / (float)(x.Count * sumX2 - sumX * sumX);
            b = (float)(sumY - a * sumX) / (float)x.Count;
        }
    }
}
