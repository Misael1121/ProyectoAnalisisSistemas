using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidad.Usuarios;

namespace Sistema.Datos.Maping.Usuario
{
    public class RolMap : IEntityTypeConfiguration<Rol>
    {
        public void configure(IEntityTypeConfiguration<Rol> builder)
        {
            builder.ToTable("Rol")
                .Haskey(r => r.idrol);
            builder.Property(r => c.Nombre)
                .HasMaxLength(50);
            builder.Property(r => c.Descripcion)
               .HasMaxLength(256);
        }
    }
}
