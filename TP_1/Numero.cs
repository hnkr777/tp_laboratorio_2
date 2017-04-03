using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    /// <summary>
    /// Trabajo práctico número 1, clase Numero, almacena un operando.
    /// </summary>
    class Numero
    {
        /// <summary>
        /// Atributo privado que almacena el operando.
        /// </summary>
        private double numero;

        /// <summary>
        /// Getter que devuelve el valor del atributo numero.
        /// </summary>
        /// <returns>double</returns>
        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Constructor de la clase Numero, le asigna al 
        /// atributo numero un valor por defecto (cero).
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor (sobrecargado) que inicializa el atributo
        /// numero con el valor del parámetro del constructor (double numero).
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(String numero)
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// Constructor (sobrecargado) que inicializa el atributo
        /// numero con el valor del parámetro una vez validado a través
        /// de la función estática Numero.validarNumero(String).
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(String numero)
        {
            this.numero = Numero.validarNumero(numero);
        }

        /// <summary>
        /// Valida el valor del String del parámetro numeroString y devuelve
        /// el mismo como double, en caso de validación fallida devuelve cero (la consigna pide esto).
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns>double</returns>
        private static double validarNumero(String numeroString)
        {
            double retorno, salida = 0.0;
            if (double.TryParse(numeroString, out retorno))
            {
                salida = retorno;
            }
            return salida;
        }
    }
}
