using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Guardar()
        {
            bool paso;
            Clientes clientes = new Clientes();
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            clientes.IdCliente = 1;
            clientes.Nombre = "Samuel";
            clientes.Apellido = "Reyes";
            clientes.Telefono = "849-651-4182";
            clientes.Direccion = "Sanchez Ramirez, Villa la mata";
            clientes.Email = "Alexsander@gmail.com";
            paso = repositorio.Guardar(clientes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest1()
        {
            bool paso;
            Clientes clientes = new Clientes();
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            clientes.IdCliente = 1;
            clientes.Nombre = "ALexander";
            clientes.Apellido = "Diaz";
            clientes.Telefono = "849-651-4182";
            clientes.Direccion = "Sanchez Ramirez, Villa la mata";
            clientes.Email = "Alexsander@gmail.com";
            paso = repositorio.Modificar(clientes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Clientes clientes = new Clientes();
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            clientes = repositorio.Buscar(id);
            Assert.IsNotNull(clientes);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            var Listar = repositorio.GetList(x => true);
            Assert.IsNotNull(Listar);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 1;
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }
    }
}
