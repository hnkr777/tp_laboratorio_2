using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Snacks : Producto
    {
        /// <summary>
        /// Constructor que llama a la clase base (padre) pasandole los argumentos
        /// </summary>
        /// <param name="marca">Marca del Snack</param>
        /// <param name="codigo">Código de barras</param>
        /// <param name="color">Color del producto</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(marca, codigo, color)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        /// <summary>
        /// Devuelve las características del objeto
        /// </summary>
        /// <returns>Devuelve una cadena con la descripción</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
