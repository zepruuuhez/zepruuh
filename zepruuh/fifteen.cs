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
    public partial class fifteen : Form
    {
        public fifteen()
        {
            InitializeComponent();
        }

        private void fifteen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }
        public void win()
        {
            int lbx = 10, lby = 10, lbcount = 1;
            bool IsWon = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Label lb = Controls["label" + lbcount] as Label;
                    if (lb.Location.X != lbx || lb.Location.Y != lby)
                    {
                        IsWon = false;
                    }
                    lbx += 60;
                    lbcount++;
                }
                lby += 60;
                lbx = 10;
            }
            if (IsWon)
                MessageBox.Show("Вы победили");
        }

        private void label_click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            int lbX = lb.Location.X,
                lbY = lb.Location.Y;
            if (label16.Location.X == lbX + 60 && label16.Location.Y == lbY)
            {
                lb.Location = new Point(lbX + 60,lbY);
                label16.Location = new Point(lbX , lbY);
            }
            else if (label16.Location.X == lbX - 60 && label16.Location.Y == lbY)
            {
                lb.Location = new Point(lbX - 60, lbY);
                label16.Location = new Point(lbX, lbY);
            }
            else if (label16.Location.X == lbX && label16.Location.Y == lbY + 60)
            {
                lb.Location = new Point(lbX , lbY + 60);
                label16.Location = new Point(lbX, lbY);
            }
            else if (label16.Location.X == lbX && label16.Location.Y == lbY - 60)
            {
                lb.Location = new Point(lbX, lbY - 60);
                label16.Location = new Point(lbX, lbY);
            }
            win();
        }
        
        private void AssignIconsToSquares()
        {
            List<string> icons = new List<string>()
            {
                "1", "2", "3", "4", "5", "6", "7", "8",
                "9", "10", "11", "12", "13", "14", "15", "16"
            };
            Random random = new Random();
            // Контейнер имеет 16 ячеек,  лист имеет 16 иконок. 
            //Иконки рандомно выбираются из листа и добавляются в каждый Label
            foreach (Control control in this.Controls) //создаем переменную control, которая хранит в себе каждый элемент управления
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber]; //скрываем иконки (изменяем их цвет на цвет фона)
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AssignIconsToSquares();
        }
    }
}
