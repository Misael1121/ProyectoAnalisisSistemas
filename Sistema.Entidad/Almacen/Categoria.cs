using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidad.Almacen
{
    public class Categoria
    {
        public int idcategoria { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="El nombre debe tener nomas de 50 caracterres y no menos de 3")]

        public string nombre { get; set; }


        [StringLength(256, ErrorMessage = "El tamaño maximo de la direccion es de 256 caracteres")]
        public string descripcion { get; set; }

        public bool condicon { get; set; }

        public ICollection<Articulo> articulos { get; set; }
    }
}
