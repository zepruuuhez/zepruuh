using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zepruuh
{
    public partial class graph : Form
    {
        public graph()
        {
            InitializeComponent();
        }

        private void graph_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width,pictureBox1.Height); //создали холст для пикбокса
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            gr.DrawLine(Pens.Black, 10, 10, 50, 50);
            gr.DrawLine(Pens.Black, 20,10, 50, 50);
            gr.DrawEllipse(Pens.Black, 50, 50, 100, 150);
            gr.FillEllipse(Brushes.Blue, 51, 51, 98, 148);
            gr.FillRectangle(Brushes.DarkCyan, 150, 50, 100, 100);
            Random R = new Random();
            Brush br = new SolidBrush(Color.FromArgb(R.Next(1,256), R.Next(1, 256), R.Next(1, 256), R.Next(1, 256)));
            Point[] points = new Point[3];
            points[0] = new Point(50, 200);
            points[1] = new Point(150, 200);
            points[2] = new Point(100, 300);
            gr.FillPolygon(br, points);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Должны появиться от 1 до 100 кругов в рандомных местах. Круг- эллипс размером 30 на 30.Рандомный цвет.
        }
    }
}
