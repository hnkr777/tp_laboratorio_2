using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;

namespace TestsUnitarios
{
    [TestClass]
    public class AlumnoTest
    {
        [TestMethod]
        public void AlumnoArgentinoValido()
        {
            try
            {
                Alumno a = new Alumno(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                Assert.AreEqual<string>(a.Nombre, "Juan");
                Assert.AreEqual<string>(a.Apellido, "Lopez");
                Assert.AreEqual<int>(a.DNI, 12234456);
                Assert.AreEqual<Persona.ENacionalidad>(a.Nacionalidad, Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void AlumnoExtranjeroValido()
        {
            try
            {
                Alumno a = new Alumno(1, "Juan", "Lopez", "92234456", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                Assert.AreEqual<string>(a.Nombre, "Juan");
                Assert.AreEqual<string>(a.Apellido, "Lopez");
                Assert.AreEqual<int>(a.DNI, 92234456);
                Assert.AreEqual<Persona.ENacionalidad>(a.Nacionalidad, Persona.ENacionalidad.Extranjero);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void AlumnoArgentinoDNIInvalido()
        {
            try
            {
                Alumno a = new Alumno(1, "Juan", "Lopez", "92234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                Assert.Fail("Alumno argentino con DNI extranjero");
            }
            catch (DniInvalidoException e)
            {
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void AlumnoExtranjeroNacionalidadInvalida()
        {
            try
            {
                Alumno a = new Alumno(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                Assert.Fail("Alumno extranjero con DNI argetino");
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void AlumnoArgentinoApellidoRaroValido()
        {
            try
            {
                Alumno a = new Alumno(1, "JuanáéíóúÁÉÍÓÚñÑ", "LopezáéíóúÁÉÍÓÚñÑ", "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                Assert.AreEqual<string>(a.Nombre, "JuanáéíóúÁÉÍÓÚñÑ");
                Assert.AreEqual<string>(a.Apellido, "LopezáéíóúÁÉÍÓÚñÑ");
                Assert.AreEqual<int>(a.DNI, 12234456);
                Assert.AreEqual<Persona.ENacionalidad>(a.Nacionalidad, Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /*[TestMethod]
        public void AlumnoArgentinoSinDNI()
        {
            try
            {
                Alumno a = new Alumno(1, "Juan", "Lopez", null, Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            }
            catch (DniInvalidoException e)
            {
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void AlumnoArgentinoSinNombre()
        {
            try
            {
                Alumno a = new Alumno(1, null, "Lopez", "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                Assert.Fail("El alumno no tiene nombre, la consigna no lo considera...");
            }
            catch (Exception e)
            {
                Assert.IsTrue(true);
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void AlumnoArgentinoSinApellido()
        {
            try
            {
                Alumno a = new Alumno(1, "Juan", null, "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                Assert.Fail("El alumno no tiene apellido, la consigna no lo considera...");
            }
            catch (Exception e)
            {
                Assert.IsTrue(true);
                Assert.Fail(e.Message);
            }
        }*/
    }
}
