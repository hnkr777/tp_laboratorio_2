using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;

namespace EntidadesInstanciables // este namespace debería ser Clases Instanciables como indica el PDF?
{
    public class Universidad
    {
        /// <summary>
        /// Los valores del enumerado no estaban en el pdf de la consigna, se sacaron del main
        /// </summary>
        public enum EClases
        {
            Programacion=1, Laboratorio=2, SPD=3, Legislacion=4
        }

        private List<Alumno> _alumnos;      // en el diagrama estaba como alumnos
        private List<Jornada> _jornada;     // en el diagrama estaba como jornada
        private List<Profesor> _profesores; // en el diagrama estaba como profesores

        #region Constructor

        /// <summary>
        /// Ctor por default... inicializa las listas genéricas
        /// </summary>
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
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

        public List<Profesor> Instructores
        {
            get
            {
                return this._profesores;
            }

            set
            {
                this._profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this._jornada;
            }

            set
            {
                this._jornada = value;
            }
        }

        /// <summary>
        /// Indexador de las jornadas contenidas dentro de una clase Universidad, capaz valía la pena mencionarlo...
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this._jornada[i];
            }

            set
            {
                this._jornada[i] = value;
            }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g._alumnos.Contains(a);
        }

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g._profesores.Contains(i);
        }

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {
            Profesor profesor = (u == clase);
            Jornada jornada = new Jornada(clase, profesor);
            foreach (Alumno item in u.Alumnos)
            {
                if (item == clase)
                {
                    jornada = jornada + item;
                }
            }

            u.Jornadas.Add(jornada);

            return u;
        }

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a) // se considera que un alumno también puede ser profesor al mismo tiempo
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            g.Alumnos.Add(a);
            return g;
        }

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)  // se considera que un profesor también puede ser alumno al mismo tiempo
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            else
            {
                //throw new SinProfesorException(); // Debería ir esta excepción?? No lo dice el enunciado
            }

            return g;
        }

        /// <summary>
        /// Operador igualdad entre Universidad y EClases
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item != clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException(); // debería tirar esta excepción? en la consigna no lo dice explicitamente...
        }

        #endregion

        /// <summary>
        /// Muestra los datos de la universidad, sus jornadas
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            foreach (Jornada jor in gim._jornada)
            {
                sb.Append(jor.ToString());
                sb.AppendLine("<------------------------------------------------>\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve en una cadena los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Para evitar warnings
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this == ((Universidad)obj);
        }

        /// <summary>
        /// Para evitar quilombos
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Metodo estático que llama a la implementación de la interfaz de escritura xml
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", gim);
        }

        /// <summary>
        /// Metodo estático que llama a la implementación de la interfaz de lectura xml
        /// IMPORTANTE: SE MODIFICÓ EL PROTOTIPO CON EL FORMATO OUT AL PARÁMETRO UNIVERSIDAD, PARA ASÍ PODER HACER LA DESERIALIZACIÓN...
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Leer(out Universidad gim) // este método no está en el diagrama de clases!!! aunque la consigna lo especifica, se lo modificó con "out"
        {
            bool ret = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            ret = xml.leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out gim);

            return ret;
        }
    }
}
