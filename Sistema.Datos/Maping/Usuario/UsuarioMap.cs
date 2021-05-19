using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidad.Usuarios;

namespace Sistema.Datos.Maping.Usuario
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuarios>
    {
        public void configure(IEntityTypeConfiguration<Usuarios> builder)
        {
            builder.ToTable("Usuario")
             .Haskey(u => u.Idusuario);
            builder.Property(u => u.Nombre)
            .HasMaxLength(50);
            builder.Property(u => u.tipo_documento)
            .HasMaxLength(50);
            builder.Property(u => u.num_documento)
           .HasMaxLength(50);
            builder.Property(u => u.direccion)
           .HasMaxLength(256);
            builder.Property(u => u.telefono)
           .HasMaxLength(13);
            builder.Property(u => u.email)
           .HasMaxLength(50);
            builder.Property(u => u.password_hash)
           .HasMaxLength(50);
            builder.Property(u => u.password_sat)
           .HasMaxLength(50);

        }
    }
}
