using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        ETipo _tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigoDeBarras">Código de barras del producto</param>
        /// <param name="color">Color del empaque del producto</param>
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor color)
            : base(marca, codigoDeBarras, color)
        {
            _tipo = ETipo.Entera;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigoDeBarras">Código de barras del producto</param>
        /// <param name="colorPrimarioEmpaque">Color del empaque del producto</param>
        /// <param name="tipo">Tipo específico del producto</param>
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque, ETipo tipo): this(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
            this._tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Devuelve las características del objeto
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this._tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
