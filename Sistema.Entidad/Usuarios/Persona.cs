using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidad.Usuarios
{
   public class Persona
    {
        public int idpersona { get; set; }

        public int tipo_persona { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener nomas de 50 caracterres y no menos de 3")]
        public string nombre { get; set; }

        [StringLength(50)]
        public string tipo_documento { get; set; }

        [StringLength(50)]
        public string num_documento { get; set; }

        [StringLength(256, MinimumLength = 3, ErrorMessage = "La direccion debe tener nomas de 256 caracterres")]
        public string direccion { get; set; }

        [StringLength(13)]
        public string telefono { get; set; }// El atributo va cambiar

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string emil { get; set; }

        [StringLength(50)]
        public string password_hash { get; set; }

        [StringLength(50)]
        public string password_sat { get; set; }

        [StringLength(50)]
        public bool condicion { get; set; }

        public ICollection<Rol> Idrol { get; set; }
    }
}
