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
    
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        bool IsVisible = false;

        private void button2_Click(object sender, EventArgs e)
        {
            Form SU = new SignUp();
            SU.Show();
            this.Hide(); // спрятали 1 форму
        }

        private void tb_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "Login" || tb.Text == "Password" )
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Login";
                textBox1.ForeColor = Color.DarkGray;

            }
            else if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.DarkGray;
                textBox2.PasswordChar = '\0';
                pictureBox1.Image = Image.FromFile("Images/opened.jpg");
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (IsVisible == true && textBox2.Text != "Password")
            {
                IsVisible = false;
                textBox2.PasswordChar = '*';
                pictureBox1.Image = Image.FromFile("Images/closed.jpg");
            }
            else
            {
                IsVisible = true;
                textBox2.PasswordChar = '\0'; // \0 - пустота в одинраных кавычках
                pictureBox1.Image = Image.FromFile("Images/opened.jpg");
            }
        }

        private void SignIn_Shown(object sender, EventArgs e)
        {
            button1.Focus();
        }
    }
}
