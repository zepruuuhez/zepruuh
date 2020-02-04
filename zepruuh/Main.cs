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
    public partial class Main : Form
    {
        public Main(string User, string Rights)
        {
            InitializeComponent();
            this.User = User;
            this.Rights = Rights;
        }
        string User, Rights;

        private void Main_Load(object sender, EventArgs e)
        {
            if (Rights == "a")
                button1.Visible = true;
            if (User.IndexOf('@')== -1)
            {
                label1.Text = "Добро пожаловать, " + User;
                
            }
            else
                label1.Text = "Добро пожаловать";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form maze = new Maze();
            maze.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form graph = new graph();
            graph.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form u = new upr();
            u.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form alg = new Algoritm();
            alg.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
