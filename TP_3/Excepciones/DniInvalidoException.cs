using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        static string defaultMsg = "El DNI no es válido.";

        /// <summary>
        /// Excepción de DNI inválido y sus constructores...
        /// </summary>
        public DniInvalidoException() : this(defaultMsg)
        {

        }

        public DniInvalidoException(Exception e) : base(e.Message)
        {

        }

        public DniInvalidoException(string msg) : base(msg)
        {
            
        }

        public DniInvalidoException(string msg, Exception exc) : base(msg, exc)
        {

        }
    }
}
