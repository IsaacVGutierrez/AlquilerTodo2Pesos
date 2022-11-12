using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerBD.Data.Entidades
{
    public class Direccion
    {

        public int Id { get; set; }

        [Required]

        public string Localidad { get; set; }

        [Required]

        public string Departamento { get; set; }

        [Required]

        public string Provincia { get; set; }

        public List<Persona> Personas { get; set; }
    }
}
