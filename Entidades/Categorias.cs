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

        public Categorias(int idCategorias, string categorias)
        {
            CategoriaId = idCategorias;
            NombreCategoria = categorias;
        }

        public Categorias()
        {
            this.CategoriaId = 0;
            this.NombreCategoria = string.Empty;
        }
    }
}
