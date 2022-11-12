using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerBD.Data.Entidades
{
    public class Categoria
    {

        public int id { get; set; }

        public string categoria { get; set; }

        public List<ProductoPublicado> ProductosPublicados { get; set; }
    }
}
