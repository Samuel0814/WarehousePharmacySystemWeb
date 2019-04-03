using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ClientesTest
    {
        [TestMethod]
        public void GuardarTest()
        {
            bool paso;
            Categorias categorias = new Categorias();
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            categorias.CategoriaId = 1;
            categorias.NombreCategoria = "Liquidos";
            paso = repositorio.Guardar(categorias);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Categorias categorias = new Categorias();
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            categorias.CategoriaId = 1;
            categorias.NombreCategoria ="Agua ";
            paso = repositorio.Modificar(categorias);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Categorias categorias = new Categorias();
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            categorias = repositorio.Buscar(id);
            Assert.IsNotNull(categorias);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            var Listar = repositorio.GetList(x => true);
            Assert.IsNotNull(Listar);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 1;
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

    }
}
