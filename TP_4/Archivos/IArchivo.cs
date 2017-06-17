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
        /// Interface - save to disk method
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool guardar(T datos);

        /// <summary>
        /// Interface - read from disk method
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool leer(out List<T> datos);
    }
}
