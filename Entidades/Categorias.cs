using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }


        public virtual List<Articulos> ArticuloList { get; set; }

        public Categorias()
        {
            this.ArticuloList = new List<Articulos>();
        }

        public Categorias(int catgoriaID, string nombre)
        {
            this.CategoriaId = catgoriaID;
            this.NombreCategoria = nombre;
        }
    }
}
