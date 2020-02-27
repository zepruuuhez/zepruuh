using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Data.SQLite;

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
            
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Login or E-mail";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Login or E-mail" || textBox2.Text == "Password")
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                bool access = false;
                string UserLoginEmail = textBox1.Text, UserPassword = textBox2.Text;
                int LoginOrEmail = 0;
                try
                {
                    MailAddress addr = new MailAddress(textBox1.Text);
                    LoginOrEmail = 2;
                }
                catch 
                {
                    LoginOrEmail = 0;
                }
                finally
                {
                    SQLiteConnection conn = new SQLiteConnection(@"DataSource=Users/Users.db;Version=3");
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    conn.Open();
                    if (LoginOrEmail == 0)
                    {
                        cmd.CommandText = "SELECT * FROM Users WHERE login = '" + textBox1.Text + "'"+
                            " AND password = '"+ textBox2.Text  +"'";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM Users WHERE email = '" + textBox1.Text + "'" +
                            " AND password = '" + textBox2.Text + "'";
                    }
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string log = reader.GetValue(1).ToString(),
                                rights = reader.GetValue(4).ToString(),
                                banned = reader.GetValue(5).ToString();
                        if (banned == "False")
                        {

                            MessageBox.Show("Вы успешно авторизовались", "Авторизация успешна",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form main = new Main(log, rights);
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Извините, но ваша учётная запись была заблокиована","Авторизация невозможна",MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин/e-mail или пароль", "Ошибка авторизации",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    

                    conn.Close();
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form FP = new ForgotPassword();
            FP.Show(); 
        }
         
        private void label1_Click(object sender, EventArgs e) 
        {
            Form main = new Main("Хацкер","a");
            main.Show();
            this.Hide();
        }
    }
}
