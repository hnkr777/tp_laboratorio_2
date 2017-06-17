using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";
        public List<string> lista;

        /// <summary>
        /// Default constructor
        /// </summary>
        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event method called when history form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            lstHistorial.DoubleClick += lstHistorial_DoubleClick;
            
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            if (archivos.leer(out lista))
            {
                foreach (string datos in lista)
                {
                    this.lstHistorial.Items.Add(datos);
                }
            }
        }

        /// <summary>
        /// Event List Box double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstHistorial_DoubleClick(object sender, EventArgs e)
        {
            Program.BrowserForm.GoAddress(this.lstHistorial.SelectedItem.ToString());
        }
    }
}
