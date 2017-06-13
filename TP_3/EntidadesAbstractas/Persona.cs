using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;


namespace EntidadesAbstractas // En el pdf se llama "Clases Abstractas", y difiere en las llamadas en el main: "EntidadesAbstractas", se priorizó el main
{
    public abstract class Persona
    {
        #region enum & atribs
        
        /// <summary>
        /// Enumerado de nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #endregion

        #region Properties

        public string Apellido 
        { 
            get 
            { 
                return this._apellido; 
            }
 
            set 
            { 
                this._apellido = this.ValidarNombreApellido(value);
            } 
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }

            set
            {
                this._nacionalidad = value;
            }
        }

        public int DNI 
        { 
            get 
            { 
                return this._dni; 
            } 
            
            set 
            {
                if(((int)this.Nacionalidad)!=(-1))   // Nota: se hizo así porque en la deserialización xml primero devuelve el DNI antes que la nacionalidad, para evitar una excepción
                    this._dni = this.ValidarDNI(this.Nacionalidad, value); 
            } 
        }

        public string Nombre 
        { 
            get 
            { 
                return this._nombre; 
            } 
            
            set 
            {
                this._nombre = this.ValidarNombreApellido(value); 
            } 
        }

        public string StringToDNI 
        { 
            set 
            { 
                this._dni = this.ValidarDNI(this.Nacionalidad, value); 
            } 
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor por defecto...
        /// </summary>
        public Persona()
        {
            this._nacionalidad = (ENacionalidad)(-1); // Nota: se hizo así porque en la deserialización xml primero devuelve el DNI antes que la nacionalidad, para evitar una excepción
            this._dni = -1;
        }

        /// <summary>
        /// Constructor v2
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor v3, reutiliza al v2
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor v4, reutiliza al v2 y valida utilizando la propiedad StringToDNI
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        /// <summary>
        /// Método por defecto, devuelte la info de la persona en una cadena
        /// </summary>
        /// <returns>info de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Valida que el número de DNI coincida con la nacionalidad de acuerdo a un criterio
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve el número de DNI ya validado, caso contrario tira excepción</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if (_nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999))
            {
                throw new DniInvalidoException();
            } 
            else if (_nacionalidad == ENacionalidad.Extranjero && (dato < 90000000))
            {
                throw new NacionalidadInvalidaException(); // debería ser DniInvalidoException() ?
            }
            
            return dato;
        }

        /// <summary>
        /// Valida que el número de DNI dado como cadena no contenga caracteres inválidos
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve el número de DNI ya validado, caso contrario tira excepción</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            dato = dato.Replace(" ", "");
            dato = dato.Replace(".", "");
            dato = dato.Replace("-", "");
            dato = dato.Replace(",", "");
            dato = dato.Replace("\t", "");

            if (dato.Length > 9 || !int.TryParse(dato, out dni))
            {
                throw new DniInvalidoException();
            }

            return ValidarDNI(nacionalidad, dni);
        }

        /// <summary>
        /// Valida que el nombre o apellido dados contenga caracteres válidos, caso contrario devuelve null
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Devuelve el nombre o apellido dados validado, caso contrario cadena nula</returns>
        private string ValidarNombreApellido(string dato)
        {
            string result = default(string);
            if (dato != null)
            {
                Match match = Regex.Match(dato, @"^[\u00e1\u00e9\u00ed\u00f3\u00fa\u0301\u00c1\u00c9\u00cd\u00d3\u00dañÑA-Za-z]+$", RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    result = dato;
                }
            }
            return result;
        }
    }
}
