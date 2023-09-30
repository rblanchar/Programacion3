using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (button1.Text!=string.Empty)
            {
                button2.Text = button1.Text;
                button1.Text = string.Empty;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text!= string.Empty)
            {
                button1.Text = button2.Text;
                button2.Text = string.Empty;
            }
            
        }
    }
}
