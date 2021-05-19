using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidad.Almacen;

namespace Sistema.Datos.Maping.Almacen
{
    public class ArticuloMap : IEntityTypeConfiguration <Articulo>
    {
        public void configure(IEntityTypeConfiguration<Categoria> builder)
        {
            builder.ToTable("Articulo")
                .Haskey(a => a.idarticulo);
            builder.Property(a => a.Nombre)
                .HasMaxLength(50);

        }
    }
}
