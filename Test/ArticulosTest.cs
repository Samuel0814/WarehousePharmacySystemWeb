using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ArticulosTest
    {
        [TestMethod]
        public void GuardarTest1()
        {
            bool paso;
            Articulos articulos = new Articulos();
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            articulos.IdArticulos = 1;
            articulos.IdCategorias = 1;
            articulos.Nombre = "Dasani";
            articulos.Existencia = 10;
            articulos.FechaDeVencimiento = DateTime.Now;
            articulos.Costo = 50;
            articulos.Precio = 100;
            paso = repositorio.Guardar(articulos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest1()
        {
            bool paso;
            Articulos articulos = new Articulos();
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            articulos.IdArticulos = 1;
            articulos.IdCategorias = 1;
            articulos.Nombre = "Maria";
            articulos.Existencia = 10;
            articulos.FechaDeVencimiento = DateTime.Now;
            articulos.Costo = 50;
            articulos.Precio = 200;
            paso = repositorio.Guardar(articulos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Articulos articulos = new Articulos();
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            articulos = repositorio.Buscar(id);
            Assert.IsNotNull(articulos);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            var Listar = repositorio.GetList(x => true);
            Assert.IsNotNull(Listar);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 1;
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }
    }
}
