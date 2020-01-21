using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height); //создали холст для пикбокса
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            Random R = new Random();
            int count = R.Next(1, 101);
            for (int i = 0; i < count; i++)
            {
               int a = R.Next(0, 255),
                r = R.Next(0, 255),
                g = R.Next(0, 255),
                b = R.Next(0, 255),
                x = R.Next(0, 400),
                y = R.Next(0, 400);
                // size pb1 - 470,470
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(x, y, 70, 70);
                PathGradientBrush brush = new PathGradientBrush(path);
                brush.CenterColor = Color.FromArgb(a,r,g,b);
                a = R.Next(0, 255);
                r = R.Next(0, 255);
                g = R.Next(0, 255);
                b = R.Next(0, 255);
                Color[] colors = { Color.FromArgb(a,r,g,b) };
                brush.SurroundColors = colors;
                gr.FillEllipse(brush, x, y, 70, 70);
            }

        
            
            
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height); 
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(50, 50, 300, 300);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = Color.Red;
            Color[] colors = { Color.Yellow };//массив цветов
            brush.SurroundColors = colors;
            gr.FillEllipse(brush,50,50,300,300);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height); 
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            LinearGradientBrush br = new LinearGradientBrush(new Point(10,10),new Point(210,210),Color.Blue,Color.Yellow);
            gr.FillRectangle(br,10, 10, 200, 200);
            br = new LinearGradientBrush(new Point(220, 10), new Point(220, 210), Color.Gold, Color.Olive);
            gr.FillRectangle(br, 220,10, 200, 200);
            br = new LinearGradientBrush(new Point(10, 220), new Point(210, 220), Color.DarkGreen, Color.Purple);
            gr.FillRectangle(br, 10, 220, 200, 200);


            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            gr.FillEllipse(Brushes.Black, 10, 10, 300, 300);
            gr.FillEllipse(Brushes.White, -60, 10, 300, 300);
        }
        int alpha = 255, BlackCordX = -255;

        private void timer1_Tick(object sender, EventArgs e)
        {
            BlackCordX++;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            if (BlackCordX >= -157 && BlackCordX < 98)
            {
                alpha--;
            }
            else if (BlackCordX > 98 && alpha < 255)
            {
                alpha++;
            }
            gr.FillRectangle(Brushes.Black, 0, 0, 470, 470);
            Brush br = new SolidBrush(Color.FromArgb(alpha, 0, 191, 255));
            gr.FillRectangle(br, 0, 0, 470, 470);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(98, 98, 255, 255);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = Color.Red;
            Color[] colors = { Color.Yellow };
            brush.SurroundColors = colors;
            gr.FillEllipse(brush, 98, 98, 255, 255);
            gr.FillEllipse(Brushes.Black, BlackCordX, 98, 255, 255);
            if (BlackCordX > 470)
            {
                BlackCordX = -255; alpha = 255;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
            }
            else if (!timer1.Enabled)
            {
                timer1.Enabled = true;
            }
        }
            float SunX = 135F, SunY = 50F, MoonY = 470F;
        private void button7_Click(object sender, EventArgs e)
        {
            SunX = 135F; SunY = 50F;
            alpha2 = 255; MoonY = 470F;
            timer2.Enabled = true;

        }
        int alpha2 = 255;
        private void timer2_Tick(object sender, EventArgs e)
        {
            SunY += 1.647F;
            if (alpha2 > 0)
            {
                alpha2--;
            }
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            gr.FillRectangle(Brushes.Black, 0, 0, 470, 470);
            Brush br = new SolidBrush(Color.FromArgb(alpha2, 0, 191, 255));
            gr.FillRectangle(br, 0, 0, 470, 470);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(SunX, SunY, 200, 200);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = Color.Red;
            Color[] colors = { Color.Yellow };
            brush.SurroundColors = colors;
            gr.FillEllipse(brush, SunX, SunY, 200, 200);
            gr.FillEllipse(Brushes.DarkGreen, -70, 400, 290, 290);//Холм сзади
            gr.FillEllipse(Brushes.DarkGreen, 185, 380, 295, 295);
            Brush brholm = new SolidBrush(Color.FromArgb(alpha2, 119, 221, 119));
            gr.FillEllipse(brholm, -70, 400, 290, 290); //Холм спереди
            gr.FillEllipse(brholm, 185, 380, 295, 295);
            if (SunY > 470)
            {
                if(MoonY > 50)
                {
                    MoonY-= 1.647F;
                    GraphicsPath pathMoon = new GraphicsPath();
                    pathMoon.AddEllipse(135, MoonY, 200, 200);
                    PathGradientBrush brushMoon = new PathGradientBrush(pathMoon);
                    brushMoon.CenterColor = Color.White;
                    Color[] colorsMoon = { Color.Gray };
                    brushMoon.SurroundColors = colorsMoon;
                    gr.FillEllipse(brushMoon, 135, MoonY, 200, 200); // ЛУНА
                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            alpha = 255;BlackCordX = -255;
            timer1.Enabled = true;


        }
    }
}
