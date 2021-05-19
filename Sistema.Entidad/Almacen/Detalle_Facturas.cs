using System;
using System.Collections.Generic;
using System.Text;
using Sistema.Entidad.Ventas;

namespace Sistema.Entidad.Almacen
{
   public class Detalle_Facturas
    {
        public int Iddetalle { get; set; }

        public int cantidad { get; set; }

        public double precio { get; set; }

        public double Descuento { get; set; }

        public ICollection<Ingreso> Idingreso { get; set; }

        public ICollection<Venta> FACTURA_DE_LA_VENTA{ get; set; }


    }
}
