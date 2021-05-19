using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidad.Almacen;

namespace Sistema.Datos.Maping.Almacen
{
    class Detalle_FacturaMap : IEntityTypeConfiguration<Detalle_Facturas>
    {
        public void configure(IEntityTypeConfiguration<Detalle_Facturas> builder)
        {
            builder.ToTable("Detalle_Facturas")
                .Haskey(DF => DF.Iddetalle);
        }
    }
}
