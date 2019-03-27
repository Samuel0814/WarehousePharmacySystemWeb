using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int FacturaID { get; set; }
        public int IDArt { get; set; }
        public int Cantidad { get; set; }
        public string NombreArticulo { get; set; }
        public Double Precio { get; set; }
        public Double Importe { get; set; }


        public FacturasDetalle(int id, int idFactura, int idArt, int cantidad, string nombreArticulo, double precio, double importe)
        {
            ID = id;
            FacturaID = idFactura;
            IDArt = idArt;
            Cantidad = cantidad;
            NombreArticulo = nombreArticulo;
            Precio = precio;
            Importe = importe;
        }

        public FacturasDetalle()
        {
            ID = 0;
            FacturaID = 0;
            IDArt = 0;
            Cantidad = 0;
            NombreArticulo = string.Empty;
            Precio = 0;
            Importe = 0;
        }
    }
}
