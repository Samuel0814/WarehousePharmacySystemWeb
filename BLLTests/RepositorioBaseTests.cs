using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    [TestClass()]
    public class Categorias
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Categorias categorias = new Categorias();
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            cat
            paso = repositorio.Guardar(categorias);
            Assert.AreEqual(paso, true);
        }
    }
}