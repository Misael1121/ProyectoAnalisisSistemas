using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidad.Almacen;

namespace Sistema.Datos.Maping.Almacen
{
    public class IngresoMap : IEntityTypeConfiguration<Ingreso>
    {
        public void configure(IEntityTypeConfiguration<Ingreso> builder)
        {
            builder.ToTable("Ingreso")
                .Haskey(i => i.Idingreso);
            builder.Property(i => i.tipo_comprobante)
                    .HasMaxLength(50);
            builder.Property(i => i.serie_comprobante)
                    .HasMaxLength(50);
        }
    }
}
