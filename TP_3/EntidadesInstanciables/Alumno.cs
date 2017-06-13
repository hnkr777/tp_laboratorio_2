using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        /// <summary>
        /// Valores del enumerado sacados del main, no decía nada el PDF
        /// </summary>
        public enum EEstadoCuenta // no estaban en el enunciado del pdf, valores sacados del main, los demás valores no se conocen...
        {
            Becado, Deudor, AlDia
        }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region Constructors

        /// <summary>
        /// Constructor por defecto, llama al de la base por las dudas...
        /// </summary>
        public Alumno() :base()
        {

        }

        /// <summary>
        /// Constructor v2, invoca al de la clase padre para setear los respectivos atributos heredados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor v3, invoca al v2 para setear los respectivos atributos heredados a través del mismo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) 
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Operador de igualdad alumno/clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Devuelve si el alumno puede cursar o no (digamos)</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a._estadoCuenta != EEstadoCuenta.Deudor && a._claseQueToma == clase);
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase. (consigna)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a._claseQueToma != clase;
        }

        #endregion

        /// <summary>
        /// Devuelve la info de la clase que toma el alumno
        /// </summary>
        /// <returns>String con info de clases</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + _claseQueToma.ToString();
        }

        /// <summary>
        /// Devuelve los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine();  // usado así en vez de "\n" ya que guardar a disco no toma los retornos, y si los AppendLine()
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Para evitar warnings
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this == ((Alumno)obj);
        }

        /// <summary>
        /// Para evitar warnings
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Hace públicos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
    }
}
