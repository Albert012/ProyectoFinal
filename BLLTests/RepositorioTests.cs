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
    public class RepositorioTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>(); 
            bool paso = false;
            Productos productos = new Productos();
            productos.ProductoId = 2;
            productos.FechaRegistro = DateTime.Now;
            productos.FechaVencimiento = productos.FechaRegistro.AddYears(1);
            productos.Descripcion = "Huevo";
            productos.Costo = 120;
            productos.Precio = 150;
            productos.Inventario = 0;
            paso = repositorio.Guardar(productos);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            bool paso = false;
            Productos productos = new Productos();
            productos.ProductoId = 1;
            productos.FechaRegistro = DateTime.Now;
            productos.FechaVencimiento = productos.FechaRegistro.AddYears(1);
            productos.Descripcion = "Salami";
            productos.Costo = 150;
            productos.Precio = 170;
            productos.Inventario = 0;
            paso = repositorio.Modificar(productos);

        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            paso = repositorio.Eliminar(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            Productos productos = new Productos();
            productos = repositorio.Buscar(1);
            Assert.IsNotNull(productos);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            var lista = repositorio.GetList(p => true);
            Assert.IsNotNull(lista);
        }
    }
}