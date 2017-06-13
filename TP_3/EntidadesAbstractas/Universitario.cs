using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas // En el pdf se llama "Clases Abstractas", y difiere en las llamadas en el main: "EntidadesAbstractas", se priorizó el main
{
    public abstract class Universitario :Persona
    {
        private int _legajo;

        #region Constructors

        /// <summary>
        /// Constructor por defecto, llama al ctor padre x las dudas...
        /// </summary>
        public Universitario() : base()
        {

        }

        /// <summary>
        /// Constructor con parámetros, llama al de la base para setear los respectivos atributos heredados
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            :base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion

        /// <summary>
        /// Método abstracto, deben implementarlo las clases hijas de esta clase
        /// </summary>
        /// <returns>Devuelve una cadena</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Retorna los datos del universitario en una cadena
        /// </summary>
        /// <returns>Devuelve los datos de la clase</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this._legajo);
            return sb.ToString();
        }

        /// <summary>
        /// Para evitar warnings... mismo criterio de igualdad que el operados ==
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this == ((Universitario)obj);
        }

        /// <summary>
        /// devuelve el hash de la propia clase (objeto)
        /// </summary>
        /// <returns>Devuelve un hash</returns>
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        /// <summary>
        /// Operador de igualdad, si ambos objetos son del mismo tipo, y además el 
        /// número de legajo ó el número de DNI son iguales, la igualdad es verdadera
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Devuelve true o false de acuerdo al criterio arriba mencionado</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.GetType() == pg2.GetType()) && (pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI);
        }

        /// <summary>
        /// Operador de desigualdad, inverso lógico de la igualdad
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Devuelve true o false de acuerdo al criterio arriba mencionado</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
