using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using System.IO;

namespace Archivos
{
    public class Xml<T> :IArchivo<T>
    {
        /// <summary>
        /// Función que implementa la interfaz de salida de IArchivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Devuelve si guardó exitosamente</returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T)); // datos.GetType()
                Stream stream = new FileStream(archivo, FileMode.Create);
                xml.Serialize(stream, datos);
                stream.Close();

                return true;
            }
            catch (Exception exc)
            {
                throw new ArchivosException(exc);
            }
        }

        /// <summary>
        /// Función que implementa la interfaz de lectura de IArchivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Devuelve si leyó exitosamente</returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                StreamReader reader = new StreamReader(archivo);
                datos = (T)xml.Deserialize(reader);
                
                //Console.Write(((T)datos).ToString());
                reader.Close();

                return true;
            }
            catch (Exception exc)
            {
                throw new ArchivosException(exc);
            }
        }
    }
}
