using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Maping.Almacen;
using Sistema.Datos.Maping.Usuario;
using Sistema.Datos.Maping.Ventas;
using Sistema.Entidad.Almacen;

namespace Sistema.Datos
{
    public class DBContextSistema : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DBContextSistema(DbContextOptions<DBContextSistema> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ArticuloMap());
            modelBuilder.ApplyConfiguration(new Detalle_FacturaMap());
            modelBuilder.ApplyConfiguration(new IngresoMap());
            modelBuilder.ApplyConfiguration(new PersonaMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new VentasMap());
        }


    }
    }

