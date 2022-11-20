using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerBD.Data.Entidades
{
    public class Estado
    {
        public int Id { get; set; }

        [Required]
        public string Estados { get; set; }

        public List<ProductoPublicado> ProductosPublicados { get; set; }
    }
}
