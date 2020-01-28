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
    public partial class upr : Form
    {
        public upr()
        {
            InitializeComponent();
        }
        Random R;

        private void upr_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ""; richTextBox2.Text = ""; richTextBox3.Text = "";
            int[] mass = new int[50];   
            R = new Random();
            for (int i = 0; i < 50; i++)
            {
                mass[i] = R.Next(-100, 100);
                richTextBox1.Text += mass[i] + " ";
                if (mass[i] > 0)
                {
                    richTextBox2.Text += mass[i]+ " ";
                }
                if (mass[i] % 3 == 0)
                {
                    richTextBox3.Text += mass[i] + " ";
                }
            } 
            int MaxVal = mass.Max();
            richTextBox1.Text += "Максимальное = " + MaxVal;
            int MinVal = mass.Min();
            richTextBox1.Text += "Минимальное = " + MinVal;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            int first = Convert.ToInt32(textBox1.Text);
            int second = Convert.ToInt32(textBox2.Text);
            for (int i =first; i <= second;i++)
            {                
                richTextBox1.Text += i + " ";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] arr = new int[10];

        }

        private void upr_Load(object sender, EventArgs e)
        {

        }
    }
}
