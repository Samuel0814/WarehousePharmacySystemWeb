using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturasDetalle
    {
        [Serializable]
        public class FacturaDetalle
        {
            [Key]
            public int IdFacturaDetalle { get; set; }

            public int IdFacturas { get; set; }
            public int IdArticulos { get; set; }
            public int Cantidad { get; set; }
            public Double Precio { get; set; }
            public Double Importe { get; set; }

            public FacturaDetalle(int idFacturaDetalle, int idFactura, int idArticulos, int cantidad, double precio, double importe)
            {
                IdFacturaDetalle = idFacturaDetalle;
                IdFacturas = idFactura;
                IdArticulos = idArticulos;
                Cantidad = cantidad;
                Precio = precio;
                Importe = importe;
            }

            public FacturaDetalle()
            {
                IdFacturaDetalle = 0;
                IdFacturas = 0;
                IdArticulos = 0;
                Cantidad = 0;
                Precio = 0;
                Importe = 0;
            }
        }
    }

}
