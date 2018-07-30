using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace BLL.Tests
{
    [TestClass()]
    public class InventariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Inventarios inventario = new Inventarios();
            inventario.InventarioId = 0;
            inventario.Fecha = DateTime.Now;
            inventario.ProductoId = 1;
            inventario.Descripcion = "Huevo";
            inventario.Cantidad = 2;
            paso = InventariosBLL.Guardar(inventario);

            Assert.AreEqual(true, paso);
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
        }
    }
}