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
            inventario.InventarioId = 1;
            inventario.Fecha = DateTime.Now;
            inventario.ProductoId = 2;
            inventario.Cantidad = 2;
            paso = InventariosBLL.Guardar(inventario);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Inventarios inventario = new Inventarios();
            inventario.InventarioId = 1;
            inventario.Fecha = DateTime.Now;
            inventario.ProductoId = 2;
            inventario.Cantidad = 4;
            paso = InventariosBLL.Modificar(inventario);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;            
            paso = InventariosBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }
    }
}