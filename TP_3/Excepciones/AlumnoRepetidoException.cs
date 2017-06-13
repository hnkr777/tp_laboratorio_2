using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        static string defaultMsg = "Alumno repetido.";

        /// <summary>
        /// Excepción de alumno repetido...
        /// </summary>
        public AlumnoRepetidoException() : base(defaultMsg)
        {

        }
    }
}
