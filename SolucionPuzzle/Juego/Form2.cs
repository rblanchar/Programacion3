using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego
{
    public partial class Form2 : Form
    {
        int minuto = 0;
        int segundo = 0;
        int hora = 0;

        int contadorClicks = 0;

        public Form2()
        {
            InitializeComponent();

            foreach (Control control in groupBox1.Controls)
            {
                if (control is Button)
                {
                    ((Button)control).Click += Boton_Click;
                }
            }
        }


        private void Boton_Click(object sender, EventArgs e)
        {
            contadorClicks++;
            lbContador.Text = contadorClicks.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (btn1.Text == string.Empty)
            {
                btn1.Text = btn2.Text;
                btn2.Text = string.Empty;
            }
            else if (btn3.Text == string.Empty)
            {
                btn3.Text = btn2.Text;
                btn2.Text = string.Empty;
            }
            else if (btn6.Text == string.Empty)
            {
                btn6.Text = btn2.Text;
                btn2.Text = string.Empty;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (btn15.Text == string.Empty)
            {
                btn15.Text = btn16.Text;
                btn16.Text = string.Empty;
            }
            else if (btn12.Text == string.Empty)
            {
                btn12.Text = btn16.Text;
                btn16.Text = string.Empty;
            }

            if (btn16.Text == string.Empty)
            {
                comprobar();
                
            }
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            if (btn16.Text == string.Empty)
            {
                btn16.Text = btn15.Text;
                btn15.Text = string.Empty;
            }
            else if (btn11.Text == string.Empty)
            {
                btn11.Text = btn15.Text;
                btn15.Text = string.Empty;
            }
            else if (btn14.Text == string.Empty)
            {
                btn14.Text = btn15.Text;
                btn15.Text = string.Empty;
            }
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            if (btn13.Text == string.Empty)
            {
                btn13.Text = btn14.Text;
                btn14.Text = string.Empty;
            }
            else if (btn15.Text == string.Empty)
            {
                btn15.Text = btn14.Text;
                btn14.Text = string.Empty;
            }
            else if (btn10.Text == string.Empty)
            {
                btn10.Text = btn14.Text;
                btn14.Text = string.Empty;
            }
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            if (btn9.Text == string.Empty)
            {
                btn9.Text = btn13.Text;
                btn13.Text = string.Empty;
            }
            else if (btn14.Text == string.Empty)
            {
                btn14.Text = btn13.Text;
                btn13.Text = string.Empty;
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (btn5.Text == string.Empty)
            {
                btn5.Text = btn9.Text;
                btn9.Text = string.Empty;
            }
            else if (btn10.Text == string.Empty)
            {
                btn10.Text = btn9.Text;
                btn9.Text = string.Empty;
            }
            else if (btn13.Text == string.Empty)
            {
                btn13.Text = btn9.Text;
                btn9.Text = string.Empty;
            }
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            if (btn6.Text == string.Empty)
            {
                btn6.Text = btn10.Text;
                btn10.Text = string.Empty;
            }
            else if (btn11.Text == string.Empty)
            {
                btn11.Text = btn10.Text;
                btn10.Text = string.Empty;
            }
            else if (btn9.Text == string.Empty)
            {
                btn9.Text = btn10.Text;
                btn10.Text = string.Empty;
            }
            else if (btn14.Text == string.Empty)
            {
                btn14.Text = btn10.Text;
                btn10.Text = string.Empty;
            }
        }

        private void btn11_Click(object sender, EventArgs e)
        {

            if (btn7.Text == string.Empty)
            {
                btn7.Text = btn11.Text;
                btn11.Text = string.Empty;
            }
            else if (btn10.Text == string.Empty)
            {
                btn10.Text = btn11.Text;
                btn11.Text = string.Empty;
            }
            else if (btn12.Text == string.Empty)
            {
                btn12.Text = btn11.Text;
                btn11.Text = string.Empty;
            }
            else if (btn15.Text == string.Empty)
            {
                btn15.Text = btn11.Text;
                btn11.Text = string.Empty;
            }
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            if (btn8.Text == string.Empty)
            {
                btn8.Text = btn12.Text;
                btn12.Text = string.Empty;
            }
            else if (btn11.Text == string.Empty)
            {
                btn11.Text = btn12.Text;
                btn12.Text = string.Empty;
            }
            else if (btn16.Text == string.Empty)
            {
                btn16.Text = btn12.Text;
                btn12.Text = string.Empty;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (btn1.Text == string.Empty)
            {
                btn1.Text = btn5.Text;
                btn5.Text = string.Empty;
            }
            else if (btn6.Text == string.Empty)
            {
                btn6.Text = btn5.Text;
                btn5.Text = string.Empty;
            }
            else if (btn9.Text == string.Empty)
            {
                btn9.Text = btn5.Text;
                btn5.Text = string.Empty;
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (btn2.Text == string.Empty)
            {
                btn2.Text = btn6.Text;
                btn6.Text = string.Empty;
            }
            else if (btn5.Text == string.Empty)
            {
                btn5.Text = btn6.Text;
                btn6.Text = string.Empty;
            }
            else if (btn7.Text == string.Empty)
            {
                btn7.Text = btn6.Text;
                btn6.Text = string.Empty;
            }
            else if (btn10.Text == string.Empty)
            {
                btn10.Text = btn6.Text;
                btn6.Text = string.Empty;
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (btn3.Text == string.Empty)
            {
                btn3.Text = btn7.Text;
                btn7.Text = string.Empty;
            }
            else if (btn6.Text == string.Empty)
            {
                btn6.Text = btn7.Text;
                btn7.Text = string.Empty;
            }
            else if (btn8.Text == string.Empty)
            {
                btn8.Text = btn7.Text;
                btn7.Text = string.Empty;
            }
            else if (btn11.Text == string.Empty)
            {
                btn11.Text = btn7.Text;
                btn7.Text = string.Empty;
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (btn4.Text == string.Empty)
            {
                btn4.Text = btn8.Text;
                btn8.Text = string.Empty;
            }
            else if (btn7.Text == string.Empty)
            {
                btn7.Text = btn8.Text;
                btn8.Text = string.Empty;
            }
            else if (btn12.Text == string.Empty)
            {
                btn12.Text = btn8.Text;
                btn8.Text = string.Empty;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn2.Text == string.Empty)
            {
                btn2.Text = btn1.Text;
                btn1.Text = string.Empty;
            }
            else if (btn5.Text == string.Empty)
            {
                btn5.Text = btn1.Text;
                btn1.Text = string.Empty;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn2.Text == string.Empty)
            {
                btn2.Text = btn3.Text;
                btn3.Text = string.Empty;
            }
            else if (btn4.Text == string.Empty)
            {
                btn4.Text = btn3.Text;
                btn3.Text = string.Empty;
            }
            else if (btn7.Text == string.Empty)
            {
                btn7.Text = btn3.Text;
                btn3.Text = string.Empty;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn3.Text == string.Empty)
            {
                btn3.Text = btn4.Text;
                btn4.Text = string.Empty;
            }
            else if (btn8.Text == string.Empty)
            {
                btn8.Text = btn4.Text;
                btn4.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hora = 0;
            minuto = 0;
            segundo = 0;

            contadorClicks = 0;
            lbContador.Text = "0";

            groupBox1.Enabled = true;
            string[] aleatorio = new string[15];
            aleatorio = generarRandom();

            Button[] btn = crearBoton();

            for (int i = 0; i < 15; i++)
            {
                btn[i].Text = aleatorio[i];
            }
            btn16.Text = "";
            btn_Detener.Enabled= true;
            
            lbTiempo.Text = "00:00:00";
            timer1.Enabled = true;
        }

        public string[] generarRandom()
        {
            bool sw;
            string numero;
            int Posicion = 0;
            Random random = new Random();
            string[] Vector = new string[15];

            while (Posicion < Vector.Length)
            {
                sw = false;
                numero = Convert.ToString(random.Next(1, 16));
                for (int i = 0; i < Vector.Length; i++)
                {
                    if (Vector[i] == numero)
                    {
                        sw = true;
                        break;
                    }
                }
                if (sw == false)
                {
                    Vector[Posicion] = numero;
                    Posicion++;
                }
            }
            return Vector;
        }


        public void comprobar()
        {
            Button[] btn = crearBoton();
            int sw = 0;
            for (int i = 0; i <= 14; i++)
            {
                if ((Convert.ToString(btn[i].Text)) != Convert.ToString(i + 1))
                {
                    sw = 1; break;
                }
            }
            if (sw == 0)
            {
                timer1.Stop();
                MessageBox.Show("Ganaste");                
                btn_Detener.Enabled = false;
                groupBox1.Enabled=false ;
            }
        }

        public Button[] crearBoton()
        {
            Button[] btn = new Button[]
            {
                btn1, btn2, btn3, btn4, btn5,
                btn6, btn7, btn8, btn9, btn10,
                btn11, btn12, btn13, btn14,
                btn15, btn16,
            };
            return btn;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            segundo++;
            lbTiempo.Text = $"{hora.ToString().PadLeft(2, '0')}:{minuto.ToString().PadLeft(2, '0')}:{segundo.ToString().PadLeft(2, '0')}";

            if (segundo == 59)
            {
                minuto++;
                segundo = 0;
            }
            if (minuto == 59)
            {
            }
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            groupBox1.Enabled = false;
            btn_Detener.Enabled = false;
            btn_Continuar.Enabled = true;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            groupBox1.Enabled=true;
            timer1.Start();
            btn_Continuar.Enabled = false;
            btn_Detener.Enabled = true;
            
        }
    }
}
