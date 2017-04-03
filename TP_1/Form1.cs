using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1
{
    public partial class Form1 : Form
    {
        Numero numero1, numero2;
        
        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            //numero1 = new Numero();
            //numero2 = new Numero();
            lblResultado.BackColor = Color.Gray;
            lblResultado.ForeColor = Color.Black;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double tmp;
            numero1 = new Numero(txtNumero1.Text);
            numero2 = new Numero(txtNumero2.Text);
            String operador = Calculadora.validarOperador(cmbOperacion.Text);
            lblResultado.Text = string.Format("{0}", Calculadora.operar(numero1, numero2, operador));
            if (operador.Equals("+"))
                cmbOperacion.Text = operador;
            if (operador.Equals("/") && numero2.getNumero() == 0)
            {
                lblResultado.Text = "Error: división por cero.";
                lblResultado.BackColor = Color.DarkRed;
                lblResultado.ForeColor = Color.White;
            }
            else 
            {
                lblResultado.BackColor = Color.Gray;
                lblResultado.ForeColor = Color.Black;
            }

            if (!double.TryParse(txtNumero1.Text, out tmp))
                txtNumero1.Text = "0";

            if (!double.TryParse(txtNumero2.Text, out tmp))
                txtNumero2.Text = "0";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbOperacion.Text = "+";
            cmbOperacion.Items.Add("+");
            cmbOperacion.Items.Add("-");
            cmbOperacion.Items.Add("*");
            cmbOperacion.Items.Add("/");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //if (txtNumero1.Text.Equals("0") && txtNumero1.Text.Equals("0") && lblResultado.Text.Equals("0"))
                //Application.Exit(); // se presiona dos veces escape y cerramos la calculadora...
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            lblResultado.Text = "0";
            lblResultado.BackColor = Color.Gray;
            lblResultado.ForeColor = Color.Black;
        }
    }
}
