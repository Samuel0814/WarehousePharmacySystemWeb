using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class FacturaTest
    {
        [TestMethod]
        public void GuardarTest()
        {
            bool paso;
            Facturas ventas = new Facturas();
            RepositorioFactura repositorio = new RepositorioFactura();
            ventas.IdFactura = 1;
            ventas.IdCliente = 1;
            ventas.Fecha = DateTime.Now;
            ventas.Monto = 200;
            ventas.Observacion = "Venta al contado";
            ventas.Cantidad = 1;

            ventas.Lista.Add(new FacturasDetalle(1, 1, 1,1,"Maria", 200, 200 ));
            paso = repositorio.Guardar(ventas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Facturas ventas = new Facturas();
            RepositorioFactura repositorio = new RepositorioFactura();
            ventas.IdFactura = 1;
            ventas.IdCliente = 1;
            ventas.Fecha = DateTime.Now;
            ventas.Monto = 400;
            ventas.Observacion = "Venta a credito";
            ventas.Cantidad = 1;

            ventas.Lista.Add(new FacturasDetalle(1, 1, 1, 2, "Maria", 200, 400));
            paso = repositorio.Modificar(ventas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioFactura repositorio = new RepositorioFactura();
            int idVenta = repositorio.GetList(x => true)[0].IdFactura;
            Facturas ventas = repositorio.Buscar(idVenta);
            bool paso = ventas.Lista.Count > 0;
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioFactura repositorio = new RepositorioFactura();
            var Listar = repositorio.GetList(x => true);
            Assert.IsNotNull(Listar);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioFactura repositorio = new RepositorioFactura();
            bool paso;
            int id = 1;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }
    }
}
