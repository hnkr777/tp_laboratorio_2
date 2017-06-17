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
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        private const string httpConst = "http://";
        Archivos.Texto archivos;

        /// <summary>
        /// Default constructor
        /// </summary>
        public frmWebBrowser()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Event related method, when form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);

        /// <summary>
        /// Untouched method...
        /// </summary>
        /// <param name="progreso"></param>
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }

        delegate void FinDescargaCallback(string html);

        /// <summary>
        /// Untouched method
        /// </summary>
        /// <param name="html"></param>
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        /// <summary>
        /// Event related method, various checks, include site not repeated & existence of protocol string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIr_Click(object sender, EventArgs e)
        {
            List<string> lista;
            string buf = this.txtUrl.Text.ToString();

            if (!buf.ToLower().StartsWith(httpConst))
            {
                buf = httpConst + buf;
            }

            try
            {
                Uri uri = new Uri(buf);
                Descargador descargador = new Descargador(uri);

                descargador.progreso += new Descargador.Progreso(this.ProgresoDescarga);
                descargador.descargaCompletada += new Descargador.DescargaCompletada(this.FinDescarga);
                Thread thread = new Thread(descargador.IniciarDescarga);
                this.rtxtHtmlCode.ForeColor = Color.Black;

                thread.Start();
                this.archivos.leer(out lista);

                if (!lista.Contains(this.txtUrl.Text))
                {
                    this.archivos.guardar(this.txtUrl.Text);
                }
            }
            catch (Exception exc)
            {
                this.rtxtHtmlCode.ForeColor = Color.Red;
                this.rtxtHtmlCode.Text = exc.Message;
            }
        }

        /// <summary>
        /// Not used...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Method for external load of a web page
        /// </summary>
        /// <param name="address">Desire address to load</param>
        public void GoAddress(string address)
        {
            this.txtUrl.Text = address;
            btnIr_Click(new object(), new EventArgs());
        }

        /// <summary>
        /// We show up the history window...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmHistorial().ShowDialog(); 
            // new frmHistorial().Show();
        }
    }
}
