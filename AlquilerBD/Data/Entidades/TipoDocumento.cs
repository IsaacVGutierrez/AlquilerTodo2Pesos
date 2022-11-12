using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerBD.Data.Entidades
{
    public class TipoDocumento
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre de Tipo de Documento es obligatorio")]
        [MaxLength(20, ErrorMessage = "El Nombre de Tipo de Documento no debe superar los 20 caracteres")]
        public string NombreTipoDocumento { get; set; }

        public List<Persona> Personas { get; set; }
    }
}
