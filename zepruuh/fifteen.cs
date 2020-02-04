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

        private void label_click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            MessageBox.Show(lb.Name);
        }
    }
}
