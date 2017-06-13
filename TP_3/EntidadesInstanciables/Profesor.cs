using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    
    public sealed class Profesor : Universitario
    {
        private static Random _random;
        private Queue<Universidad.EClases> _clasesDelDia;

        #region Constructors
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor() :base()
        {
            if(this._clasesDelDia==null)
                this._clasesDelDia = new Queue<Universidad.EClases>();
        }

        /// <summary>
        /// Constructor estático, inicializa el objeto random de tipo estático
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Ctor con parámetros, llama al ctor de la base y genera aleatoriamente 2 clases para cada profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad) 
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Operators

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i._clasesDelDia.Contains(clase);
        }

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }

        #endregion

        /// <summary>
        /// Generador de clases aleatorio, no se pensó hacerlo escalable dado el problema puntual...
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
                this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 5)); // hardwired in this case :p
        }

        /// <summary>
        /// Indica las clases del día...
        /// </summary>
        /// <returns>devuelve una cadena</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine(); // usado así en vez de "\n" ya que guardar a disco no toma los retornos, y si los AppendLine()

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve una cadena con los datos
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\n" + this.ParticiparEnClase();
        }

        /// <summary>
        /// Para evitar warnings
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this == ((Profesor)obj);
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
        /// Hace públicos los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
    }
}
