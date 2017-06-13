﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        static string defaultMsg = "La nacionalidad no se condice con el número de DNI";

        /// <summary>
        /// Excepción de nacionalidad inválida...
        /// </summary>
        public NacionalidadInvalidaException() :base(defaultMsg)
        {

        }

        /// <summary>
        /// Otra versión
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) :base(message)
        {

        }
    }
}
