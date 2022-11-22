using AlquilerBD.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerBD
{
    public class BdContext: DbContext
    {

        public BdContext(DbContextOptions <BdContext> options) : base(options)
        {
        }


        public DbSet<ProductoAlquilado> ProductosAlquilados { get; set; }

        public DbSet<ProductoPublicado> ProductosPublicados { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estado> Estados { get; set; }

    }
}
