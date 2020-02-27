using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace zepruuh
{
    public partial class database : Form
    {
        public database()
        {
            InitializeComponent();
        }

        private void database_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }
        SQLiteConnection connection = new SQLiteConnection(@"DataSource=Аэропорт.db;Version=3;");
        SQLiteCommand command = new SQLiteCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            command.Connection = connection;
            connection.Open();
            command.CommandText = "SELECT *" +
                " FROM СОТРУДНИКИ";
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                richTextBox1.Text += reader.GetValue(0)+" "+reader.GetValue(1)+" "+ reader.GetValue(2)+" "+reader.GetValue(3)+"\n";
            }
            command.Reset();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            command.Connection = connection;
            connection.Open();
            command.CommandText = "SELECT count(*) FROM ПАССАЖИРЫ";
            richTextBox1.Text += command.ExecuteScalar();
            command.Reset();
            connection.Close();
        }

        private void database_Load(object sender, EventArgs e)
        {

        }
    }
}
