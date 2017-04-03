using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    /// <summary>
    /// Trabajo práctico número 1, clase Calculadora
    /// </summary>
    class Calculadora
    {
        /// <summary>
        /// Opera matemáticamente los operandos numero1 y numero2 según el operador
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>"double Devuelve el resultado de la operación."</returns>
        public static double operar(Numero numero1, Numero numero2, String operador) 
        {
            double retorno = 0, num1, num2;
            num1 = numero1.getNumero();
            num2 = numero2.getNumero();

            switch(operador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;

                case "-":
                    retorno = num1 - num2;
                    break;

                case "*":
                    retorno = num1 * num2;
                    break;

                case "/":
                    if(num2!=0)
                        retorno = num1 / num2;
                    break;
            }

            return retorno;
        }

        /// <summary>
        /// Valida el operador String (parámetro) y sino devuelve por defecto el operador de suma "+".
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>"Devuelve un String con el parámetro validado de acuerdo a la consigna."</returns>
        public static string validarOperador(String operador)
        {
            String retorno = "+";
            if (operador.Equals("-") || operador.Equals("*") || operador.Equals("/"))
            {
                retorno = operador;
            }
            return retorno;
        }
    }
}
