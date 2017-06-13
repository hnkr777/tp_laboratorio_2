using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region Constructors

        /// <summary>
        /// Ctor por defecto
        /// </summary>
        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// ctor v2
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region Properties

        public List<Alumno> Alumnos 
        {
            get
            {
                return this._alumnos;
            }

            set
            {
               this._alumnos = value;
            }
        }

        public Universidad.EClases Clase 
        {
            get
            {
                return this._clase;
            }

            set
            {
               this._clase = value;
            }
        }

        public Profesor Instructor 
        {
            get
            {
                return this._instructor;
            }

            set
            {
               this._instructor = value;
            }
        }

        #endregion

        #region Overloads

        /// <summary>
        /// Operador de igualdad jornada==alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool ret = false;

            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Operador de desigualdad jornada!=alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }

            j._alumnos.Add(a);

            return j;
        }
        #endregion

        /// <summary>
        /// Devuelve la info de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASE DE ");
            sb.Append(this._clase);
            sb.Append(" POR ");
            sb.Append(this._instructor);
            
            sb.AppendLine("ALUMNOS:");
            
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Para evitar warnings
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this == ((Jornada)obj);
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
        /// Guardar
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Guardado exitoso</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Leer
        /// </summary>
        /// <returns>Lectura exitosa</returns>
        public static string Leer()
        {
            string buffer;
            Texto texto = new Texto();
            
            texto.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out buffer);
            return buffer;
        }
    }
}
