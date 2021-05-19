using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Sistema.Entidad.Usuarios;

namespace Sistema.Entidad.Almacen
{
   public class Articulo
    {
        public int idarticulo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El codigo debe tener nomas de 50 caracterres y no menos de 3")]
        public string codigo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El codigo debe tener nomas de 50 caracterres y no menos de 3")]
        public string nombre { get; set; }

        [StringLength(256, ErrorMessage = "El tamaño maximo de la direccion es de 256 caracteres")]
        public double precio { get; set; }

        public int stock { get; set; }

        public ICollection <Categoria> Idcategorias { get; set; }
        public ICollection<Usuario> COMPRA_USUARIO { get; set; }

        public ICollection<Persona> COMPRA_PERSONA { get; set; }


    }
}
