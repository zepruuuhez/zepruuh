﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Data.SQLite;

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
            Form frm = Application.OpenForms[0]; // призакрытии этой формы вернулись к первой
            frm.Show();
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
                pictureBox1.Image = Image.FromFile("Images/opened.jpg");
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
                pictureBox1.Image = Image.FromFile("Images/closed.jpg");
            }
            else
            {
                IsVisible = true;
                textBox2.PasswordChar = '\0'; // \0 - пустота в одинраных кавычках
                pictureBox1.Image = Image.FromFile("Images/opened.jpg");
            }
        }
                SQLiteConnection connection = new SQLiteConnection(@"DataSource=Users/Users.db;Version=3;");
                SQLiteCommand command = new SQLiteCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Login" && textBox2.Text != "Password" && textBox3.Text != "E-mail")
            {
                command.Connection = connection;
                connection.Open();
                command.CommandText = "SELECT count(*)" +
                    " FROM Users WHERE login = '" + textBox1.Text + "'" 
                    + " OR email = '" + textBox3.Text + "'"; 
                string chislo = command.ExecuteScalar().ToString();
                command.Reset();
                if (chislo == "0")
                {
                    command.CommandText = "Insert into Users (login,email,password) Values('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')";
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Данное Логин/email уже зарегистрировано другим пользователем",
                        "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                command.Reset();
                connection.Close();

                /*
                    bool IsExists = false;
                
                StreamReader sr = new StreamReader("Users/UsersInfo.txt", Encoding.Default);
                while (!sr.EndOfStream)
                {
                    string[] tmp = sr.ReadLine().Split(',');
                    try
                    {
                        MailAddress addr = new MailAddress(textBox3.Text);
                        if (tmp[0] == textBox1.Text)
                        {
                            MessageBox.Show("Данное имя пользователя уже занято", "Ошибка при регистрации",
                                             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            IsExists = true;
                            break;
                        }
                        else if (tmp[2] == textBox3.Text)
                        {
                            MessageBox.Show("Данный электронный адрес уже используется", "Ошибка при регистрации",
                                             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            IsExists = true;
                            break;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Электронный адрес введен не верно", "Ошибка при регистрации",
                                             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        IsExists = true; break;
                    }
                    
                }
                sr.Close();
                if (!IsExists)
                {
                    StreamWriter sw = new StreamWriter("Users/UsersInfo.txt", true);
                    sw.WriteLine(textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + ",u");
                    MessageBox.Show("Вы успешно зарегестрировались", "Регистрация успешна",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sw.Close();
                    this.Close();
                }*/
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка ввода",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
