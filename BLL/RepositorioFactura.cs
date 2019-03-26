using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioFactura : RepositorioBase<Facturas>
    {
        public override Facturas Buscar(int id)
        {
            Facturas facturas = _contexto.Facturas.
                                 Include(x => x.Lista)
                                 .Where(z => z.IdFactura == id)
                                 .FirstOrDefault();
            return facturas;
        }

        public override bool Eliminar(int id)
        {
            Facturas facturas = Buscar(id);
            Articulos articulos = _contexto.Articulos.Find(facturas.IdArticulo);
            articulos.Existencia += facturas.Cantidad;
            _contexto.Entry(articulos).State = EntityState.Modified;
            return base.Eliminar(id);
        }

        public override bool Guardar(Facturas facturas)
        {
            Articulos articulos = _contexto.Articulos.Find(facturas.IdArticulo);
            articulos.Existencia -= facturas.Cantidad;
            _contexto.Entry(articulos).State = EntityState.Modified;

            return base.Guardar(facturas);
        }

        public override bool Modificar(Facturas entity)
        {
            Facturas facturas1 = _contexto.Facturas.
                                 Include(x => x.Lista)
                                 .Where(z => z.IdFactura == entity.IdFactura)
                                 .AsNoTracking()
                                 .FirstOrDefault();

            var facturaAnt = facturas1;
            var articulo = _contexto.Articulos.Find(entity.IdArticulo);
            articulo.Existencia -= facturaAnt.Cantidad;
            _contexto.Entry(articulo).State = EntityState.Modified;

            foreach (var item in facturaAnt.Lista)
                _contexto.Entry(item).State = EntityState.Deleted;


            foreach (var item in entity.Lista)
                _contexto.Entry(item).State = (item.ID == 0) ? EntityState.Added : EntityState.Modified;

            articulo.Existencia += entity.Cantidad;
            _contexto.Entry(articulo).State = EntityState.Modified;

            return base.Modificar(entity);
        }

        public override List<Facturas> GetList(Expression<Func<Facturas, bool>> expression)
        {
            var lista = _contexto.Facturas.Include(x => x.Lista).Where(expression).ToList();
            return lista;
        }
    }
}
