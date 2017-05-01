using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        /// <summary>
        /// Enumeración de marcas de productos
        /// </summary>
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        
        EMarca _marca;
        string _codigoDeBarras;
        ConsoleColor _colorPrimarioEmpaque;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias { get; /*set;*/ }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (String)this;
        }

        /// <summary>
        /// Constructor de tres parámetros
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigoDeBarras"></param>
        /// <param name="colorPrimarioEmpaque"></param>
        protected Producto(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque)
        {
            this._marca = marca;
            this._codigoDeBarras = codigoDeBarras;
            this._colorPrimarioEmpaque = colorPrimarioEmpaque;
        }

        /// <summary>
        /// Sobrecarga del operador explicito a string
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Devuelve la descripción del producto</returns>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: " + p._codigoDeBarras);
            sb.AppendLine("MARCA          : " + p._marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : " + p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
    }
}
