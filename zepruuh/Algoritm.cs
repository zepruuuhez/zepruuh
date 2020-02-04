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
    public partial class Algoritm : Form
    {
        public Algoritm()
        {
            InitializeComponent();
        }
        Random R = new Random();
        private void Algoritm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            double Pa = Convert.ToDouble(textBox1.Text),
            N = Convert.ToDouble(textBox2.Text),
            S = Convert.ToDouble(textBox3.Text);
            double z;
            double V = 0;
            for (int i = 1; i <= N;i++)
            {
                z = R.NextDouble()*10;
                if (z < Pa)
                {
                    V += S;
                }
               
            }
            richTextBox1.Text += V + " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* 2 блоксхема : есть кол-во агентов(N), каждый агент может позвонить 
             * от 1 до 20 человеку. Каждый чел. с вероятностью Z может совершить покупку.
             * Получить кол-во покупок За день
             * 
             */
            richTextBox2.Text = "";
            double N = Convert.ToDouble(textBox4.Text),
                P = Convert.ToDouble(textBox5.Text),
                NumM ,
                z,
                NumP = 0;
            for (int i = 1; i <= N; i++)
            {
                NumM = R.Next(1, 20);
                NumP = 0;
                for (int j = 1; j <= NumM; j++)
                {
                    z = R.NextDouble();
                    if (z < P)
                    {
                        NumP++;
                    }
                }
                richTextBox2.Text += "На " + i + " горке было "+ NumM+ " детей. Смогли " +
                    "съехать "+NumP+" детей\n";
            }
        }

        private void Algoritm_Load(object sender, EventArgs e)
        {

        }
    }
}
