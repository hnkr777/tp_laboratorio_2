using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        static string defaultMsg = "No hay Profesor para la clase.";

        /// <summary>
        /// Excepción de profesor ausente para la clase
        /// </summary>
        public SinProfesorException() : base(defaultMsg)
        {

        }
    }
}
