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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        bool IsVisible = true;

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tb_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "Login" || tb.Text == "Password" || tb.Text == "E-mail")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }

        }
        private void SignUp_Shown(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Login";
                textBox1.ForeColor = Color.DarkGray;
                
            }
            else if ( textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.DarkGray;
                textBox2.PasswordChar = '\0';
            }
            else if (textBox3.Text == "")
            {
                textBox3.Text = "E-mail";
                textBox3.ForeColor = Color.DarkGray;
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (IsVisible == true && textBox2.Text != "Password")
            {
                IsVisible = false;
                textBox2.PasswordChar = '*';
            }
            else
            {
                IsVisible = true;
                textBox2.PasswordChar = '\0'; // \0 - пустота в одинраных кавычках
            }
        }
    }
}
