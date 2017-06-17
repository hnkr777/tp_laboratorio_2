using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;


namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public delegate void DescargaCompletada(string salida);
        public delegate void Progreso(int avance);

        public event DescargaCompletada descargaCompletada;
        public event Progreso progreso;

        /// <summary>
        /// Constructor, load the passed address direccion
        /// </summary>
        /// <param name="direccion">address to load</param>
        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        /// <summary>
        /// Event related method
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                
                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\x0D\x0A" + e.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// progress bar progresion related method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progreso( e.ProgressPercentage);
        }

        /// <summary>
        /// download html related method, if it fails, show up a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
                this.descargaCompletada(this.html);
            }
            catch (Exception exc)
            {
                this.descargaCompletada("Error: \x0D\x0A" + exc.InnerException.Message);
            }
        }
    }
}
