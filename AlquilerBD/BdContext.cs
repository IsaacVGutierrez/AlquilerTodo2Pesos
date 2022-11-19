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
        public DbSet<Persona> Personas { get; set; }

        public DbSet<ProductoAlquilado> ProductosAlquilados { get; set; }

        public DbSet<ProductoPublicado> ProductsoPublicados { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }

        public DbSet<TipoDocumento> TipoDocumentos { get; set; }


        public DbSet<Estado> Estados { get; set; }

    }
}
