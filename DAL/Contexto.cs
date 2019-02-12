using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Articulos> articulos { get; set; }
        //public DbSet<DeudasClientes> deudas { get; set; }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Categorias> categoria { get; set; }
        public DbSet<Facturas> Facturas { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
