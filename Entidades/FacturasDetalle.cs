using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class FacturasDetalle
    {
        
        [Key]
        public int ID { get; set; }

        public int IdFacturas { get; set; }
        public int IdArticulos { get; set; }
        public int Cantidad { get; set; }
        public string NombreArticulo { get; set; }
        public Double Precio { get; set; }
        public Double Importe { get; set; }


        public FacturasDetalle(int id, int idFactura, int idArticulo, int cantidad, string nombreArticulo, double precio, double importe)
        {
            ID = id;
            IdFacturas = idFactura;
            IdArticulos = idArticulo;
            Cantidad = cantidad;
            NombreArticulo = nombreArticulo;
            Precio = precio;
            Importe = importe;
        }

        public FacturasDetalle()
        {
            ID = 0;
            IdFacturas = 0;
            IdArticulos = 0;
            Cantidad = 0;
            NombreArticulo = "";
            Precio = 0;
            Importe = 0;
        }

        
    }

}
