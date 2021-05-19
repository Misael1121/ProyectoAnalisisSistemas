using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidad.Usuarios
{
    public class Rol
    { 
    public int idrol { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe tener nomas de 50 caracterres y no menos de 3")]
     public string nombre { get; set; }

     [StringLength(100, MinimumLength = 3, ErrorMessage = "La direccion debe tener nomas de 100 caracterres")]
        public string direccion { get; set; }
    public bool condicon { get; set; }
    }
}
