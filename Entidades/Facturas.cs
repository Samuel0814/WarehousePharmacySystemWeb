using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Facturas
    {
        [Key]
        public int IdFactura { get; set; }

        public int IdCliente { get; set; }
        public int IdArticulo { get; set; }
        public DateTime Fecha { get; set; }
        public Double Monto { get; set; }
        public String Observacion { get; set; }
        public virtual List<FacturasDetalle> Lista { get; set; }

        public Facturas(int idFactura, int idCliente, DateTime fecha, double monto, string observacion)
        {
            IdFactura = idFactura;
            IdCliente = idCliente;
            Fecha = fecha;
            Monto = monto;
            Observacion = observacion;
        }

        public Facturas()
        {
            IdFactura = 0;
            IdCliente = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            Observacion = String.Empty;
            Lista = new List<FacturasDetalle>();
        }
    }
}
