using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Interfaz de salida
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool guardar(string archivo, T datos);

        /// <summary>
        /// Interfaz de lectura
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool leer(string archivo, out T datos);
    }
}
