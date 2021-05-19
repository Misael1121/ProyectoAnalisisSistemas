using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidad.Ventas;

namespace Sistema.Datos.Maping.Ventas
{
    public class VentasMap : IEntityTypeConfiguration<Venta>
    {
        public void configure(IEntityTypeConfiguration<Venta> builder)
        {
            builder.ToTable("Ventas")
                .Haskey(v => v.idventa);
            builder.Property(v => v.tipo_comprobante)
                    .HasMaxLength(50);
            builder.Property(v => v.serie_comprobante)
                    .HasMaxLength(50);
        }
    }
}
