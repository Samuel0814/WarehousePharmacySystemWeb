using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Articulos
    {
        [Key]
        public int IdArticulos { get; set; }

        public int IdDepartamento { get; set; }
        public String Nombre { get; set; }
        public int Existencia { get; set; }
        public DateTime FechaDeVencimiento { get; set; }
        public Double Costo { get; set; }
        public Double Precio { get; set; }

        public Articulos(int idArticulos, int idDepartamento, string nombre, double precio, int existencia, DateTime fechaDeVencimiento, double costo)
        {
            IdArticulos = idArticulos;
            IdDepartamento = idDepartamento;
            Nombre = nombre;
            Precio = precio;
            Existencia = existencia;
            FechaDeVencimiento = fechaDeVencimiento;
            Costo = costo;
        }

        public Articulos()
        {
            IdArticulos = 0;
            IdDepartamento = 0;
            Nombre = String.Empty;
            Precio = 0;
            Existencia = 0;
            FechaDeVencimiento = DateTime.Now;
            Costo = 0;
        }
    }
}
