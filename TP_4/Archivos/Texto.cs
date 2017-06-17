using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string file;

        /// <summary>
        /// Constructor, with the file of navigation history
        /// </summary>
        /// <param name="archivo"></param>
        public Texto(string archivo)
        {
            this.file = archivo;
        }

        /// <summary>
        /// Save to disk method
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + this.file, true);
                writer.WriteLine(datos.ToString());
                writer.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al guardar el archivo: " + this.file + "\x0D\x0A" + e.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Read from disk method
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();

            try
            {
                StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + this.file);
                
                while (!reader.EndOfStream)
                {
                    datos.Add(reader.ReadLine());
                }

                reader.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al leer el archivo: " + this.file + "\x0D\x0A" + e.Message, "Error al leer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
