using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroConDetalle.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using RegistroConDetalle.Entidades;

namespace RegistroConDetalle.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Personas persona = new Personas();

            persona.PersonaId = 0;
            persona.Nombre = "Jose";
            persona.Cedula = "123";
            persona.Direccion = "El rosal";
            persona.FechaNacimiento = DateTime.Now;
            persona.Telefonos.Add(new TelefonosDetalle("123", "t"));
            persona.Telefonos.Add(new TelefonosDetalle("11", "e"));

            bool paso = PersonasBLL.Guardar(persona);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Personas persona = PersonasBLL.Buscar(1);

            persona.Telefonos.RemoveAt(1);
            persona.Direccion = "El Rosal Azul";

            bool paso = PersonasBLL.Modificar(persona);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = PersonasBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Personas persona = new Personas();

            persona = PersonasBLL.Buscar(1);

            Assert.IsTrue(persona != null);
        }
    }
}