using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace zepruuh
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }
        int kod, Seconds = 120;
        string Info;
       

        private void button1_Click(object sender, EventArgs e)
        {
            bool IsSending = false;
            try
            {
                using (StreamReader sr = new StreamReader("Users/UsersInfo.txt"))
                {
                    while(!sr.EndOfStream)
                    {
                       string[] tmp = sr.ReadLine().Split(',');
                        // [0] - Логин [1] - пароль [2] - email [3] - права
                        if (tmp[2] == textBox1.Text)
                        {
                            Info = "Ваш E-mail: " + tmp[2] + "\nВаш пароль: " + tmp[1];
                            MailAddress from = new MailAddress("SigmaIrkReports@mail.ru", "Zepruuuh");
                            MailAddress to = new MailAddress(textBox1.Text);
                            MailMessage m = new MailMessage(from, to);
                            m.Subject = "Восстановление пароля";
                            Random R = new Random();
                            kod = R.Next();
                            m.Body = "Код для восстановления пароля<br>" +
                                "<p style=\"font-size:20px;\"><b>" + kod +
                                "</b></p>";
                            m.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                            smtp.Credentials = new NetworkCredential("SigmaIrkReports@mail.ru", "OstanovkaSuvorova");
                            smtp.EnableSsl = true; // шифровка
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Send(m);
                            textBox2.ReadOnly = false;
                            IsSending = true;
                            timer1.Enabled = true;
                            button1.Enabled = false;
                            Seconds = 120;
                            break;
                        }
                    }
                }
                if(!IsSending)
                {
                    MessageBox.Show("Код восстановления не был отправлен\n" +
                        "Проверьте актуальность введенныйх данных" , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: "+ex.Message, "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.ForeColor == Color.DimGray)
            {
                tb.Text = ""; tb.ForeColor = Color.Black;
            }
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Name == "textBox1" && tb.Text == "")
            {
                tb.Text = "Введите E-mail";
                tb.ForeColor = Color.DimGray;
            }
            else if (tb.Name == "textBox2" && tb.Text == "")
            {
                tb.Text = "Введите код";
                tb.ForeColor = Color.DimGray;
            }
        }

       

        private void ForgotPassword_Shown(object sender, EventArgs e)
        {
            button1.Focus();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (kod.ToString() == textBox2.Text)
            {
                MessageBox.Show(Info, "Успешное восстановление пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Seconds--;
            label1.Text = "Следующий код можно отправить через: " + Seconds + "сек.";
            if (Seconds == 0)
            {
                timer1.Enabled = false;
                button1.Enabled = true;
            }
        }
    }
}
