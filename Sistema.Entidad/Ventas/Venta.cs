using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Sistema.Entidad.Almacen;
using Sistema.Entidad.Usuarios;

namespace Sistema.Entidad.Ventas
{
   public class Venta
    {
        public int idventa { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo_comprobante { get; set; }

        [StringLength(50)]
        public string serie_comprobante { get; set; }

        public int num_comprobante { get; set; }

        public DateTime fecha_hora { get; set; }

        public double impuesto { get; set; }// El atributo va cambiar

        public double total { get; set; }

        [StringLength(50)]
        public bool estado { get; set; }

      

        public ICollection<Articulo> VENTA_DEL_ARTICULO { get; set; }

       
    }
}
