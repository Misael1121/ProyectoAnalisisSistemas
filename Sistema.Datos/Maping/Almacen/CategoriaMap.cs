using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidad.Almacen;

namespace Sistema.Datos.Maping.Almacen
{
    public class CategoriaMap : IEntityTypeConfiguration <Categoria>
    {
        public void configure(IEntityTypeConfiguration<Categoria> builder)
        {
            builder.ToTable("Categoria")
                .Haskey(c => c.idcategoria);
            builder.Property(c => c.Nombre)
                .HasMaxLength(50);
            builder.Property(c => c.Descripcion)
               .HasMaxLength(256);
        }

    }
}
