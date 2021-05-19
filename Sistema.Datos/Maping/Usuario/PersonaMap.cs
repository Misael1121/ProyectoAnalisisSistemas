using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidad.Usuarios;

namespace Sistema.Datos.Maping.Usuario
{
    public class PersonaMap : IEntityTypeConfiguration<Persona>
    {
        public void configure(IEntityTypeConfiguration<Persona> builder)
        {
            builder.ToTable("Persona")
             .Haskey(p => p.idpersona);
             builder.Property(p => p.Nombre)
             .HasMaxLength(50);
            builder.Property(p => p.tipo_documento)
            .HasMaxLength(50);
            builder.Property(p => p.num_documento)
           .HasMaxLength(50);
            builder.Property(p => p.direccion)
           .HasMaxLength(256);
            builder.Property(p => p.telefono)
           .HasMaxLength(13);
            builder.Property(p => p.email)
           .HasMaxLength(50);
            builder.Property(p => p.password_hash)
           .HasMaxLength(50);
            builder.Property(p => p.password_sat)
           .HasMaxLength(50);

        } 
    }
}

    
