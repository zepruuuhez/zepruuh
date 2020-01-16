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
    public partial class Maze : Form
    {
        public Maze()
        {
            InitializeComponent();
        }

        private void Maze_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }

        private void Maze_Load(object sender, EventArgs e)
        {
            Cursor.Position = new Point(this.Location.X+110,this.Location.Y+80);
        }

        private void lb_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Position = new Point(this.Location.X + 110, this.Location.Y + 80);
        }

        private void label27_MouseEnter(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Поздравляеем, вы прошли лабиринт\n"
                                               +"Хотите начать новую игру?","Победа",
                                               MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Cursor.Position = new Point(this.Location.X + 110, this.Location.Y + 80);
            }
            else this.Close();
        }
    }
}
