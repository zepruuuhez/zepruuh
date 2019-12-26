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

namespace zepruuh
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               // MailAddress addr = new MailAddress(textBox1.Text);
                MailAddress from = new MailAddress("SigmaIrkReports@mail.ru", "Zepruuuh");
                MailAddress to = new MailAddress("yalputailya2004@mail.ru");
                MailMessage m = new MailMessage(from,to);
                m.Subject = "Восстановление пароля";
                Random R = new Random();
                int kod = R.Next();
                m.Body = "Код для восстановления пароля<br>" +
                    "<p style=\"font-size:20px;\"><b>" + kod +
                    "</b></p>";
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("SigmaIrkReports@mail.ru","OstanovkaSuvorova");
                smtp.EnableSsl = true; // шифровка
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(m);
            }
            catch
            {
                MessageBox.Show("Электронный адрес введен неверно", "Ошибка ввода",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
