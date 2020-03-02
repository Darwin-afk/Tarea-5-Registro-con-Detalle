using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroConDetalle.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using RegistroConDetalle.Entidades;
using System.Linq;

namespace RegistroConDetalle.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        /*[TestMethod()]
        public void GuardarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }*/

        [TestMethod()]
        public void BuscarTest()
        {
            Personas persona = PersonasBLL.Buscar(1);

            Assert.IsTrue(persona.Telefonos.Count() > 0);
        }

        /*[TestMethod()]
        public void GetListaTest()
        {
            Assert.Fail();
        }*/
    }
}