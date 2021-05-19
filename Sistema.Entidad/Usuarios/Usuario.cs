using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidad.Usuarios
{
    public class Usuarios
    {
        public int Idusuario { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener nomas de 50 caracterres y no menos de 3")]
        public string nombre { get; set; }

        [StringLength(50)]
        public string tipo_documento { get; set; }

        [StringLength(50)]
        public string num_documento { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "La direccion debe tener nomas de 100 caracterres")]
        public string direccion { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "Recuerde el número de teléfono debe contener al menos 11 digitos")]
        public string telefono { get; set; }// El atributo va cambiar

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string emil { get; set; }

        [StringLength(50)]
        public string password_hash { get; set; }

        [StringLength(50)]
        public string password_sat { get; set; }

        public bool condicion { get; set; }

        public ICollection<Rol> Idrol { get; set; }
    }
}
