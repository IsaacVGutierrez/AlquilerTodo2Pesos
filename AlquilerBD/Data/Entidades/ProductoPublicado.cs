using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerBD.Data.Entidades
{
    public class ProductoPublicado
    {
        public int Id { get; set; }

        [Required]

        public string NombreProducto { get; set; }

        [Required]

        public int PrecioProducto { get; set; }

        [Required]

        public string DetallesProducto { get; set; }

        [Required]

        public string foto { get; set; }

      

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Required]


        public int EstadoId { get; set; }
        public Estado Estado { get; set; }


    }
}
