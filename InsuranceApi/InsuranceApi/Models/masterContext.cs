using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InsuranceApi.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Poliza> Polizas { get; set; }
        public virtual DbSet<PolizaCliente> PolizasCliente { get; set; }
        public virtual DbSet<TipoCubrimiento> TiposCubrimiento { get; set; }
        public virtual DbSet<TipoRiesgo> TiposRiesgo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Clientes_PK");

                entity.ToTable("CLIENTES");

                entity.Property(e => e.Id).HasColumnName("CLIE_ID");

                entity.Property(e => e.Nombre)
                    .HasColumnName("CLIE_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Polizas_PK");

                entity.ToTable("POLIZAS");

                entity.Property(e => e.Id).HasColumnName("POLI_ID");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("POLI_DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InicioVigencia)
                    .HasColumnName("POLI_INICIO_VIGENCIA")
                    .HasColumnType("date");

                entity.Property(e => e.MesesCobertura).HasColumnName("POLI_MESES_COBERTURA");

                entity.Property(e => e.Nombre)
                    .HasColumnName("POLI_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnName("POLI_PRECIO");

                entity.Property(e => e.TipoCubrimiento).HasColumnName("POLI_TIPO_CUBRIMIENTO");

                entity.Property(e => e.TipoRiesgo).HasColumnName("POLI_TIPO_RIESGO");

                entity.HasOne(d => d.TipoCubrimientoNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.TipoCubrimiento)
                    .HasConstraintName("POLIZAS_TIPOS_CUBRIMIENTO_FK");

                entity.HasOne(d => d.TipoRiesgoNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.TipoRiesgo)
                    .HasConstraintName("POLIZAS_TIPOS_RIESGO_FK");
            });

            modelBuilder.Entity<PolizaCliente>(entity =>
            {
                entity.HasKey(e => new { e.IdCliente, e.IdPoliza })
                    .HasName("POLIZAS_CLIENTE_PK");

                entity.ToTable("POLIZAS_CLIENTE");

                entity.Property(e => e.IdCliente).HasColumnName("POCL_ID_CLIENTE");

                entity.Property(e => e.IdPoliza).HasColumnName("POCL_ID_POLIZA");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.PolizasCliente)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POLIZAS_CLIENTE_CLIENTES_FK");

                entity.HasOne(d => d.IdPolizaNavigation)
                    .WithMany(p => p.PolizasCliente)
                    .HasForeignKey(d => d.IdPoliza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POLIZAS_CLIENTE_POLIZAS_FK");
            });

            modelBuilder.Entity<TipoCubrimiento>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("TIPOS_CUBRIMIENTO_PK");

                entity.ToTable("TIPOS_CUBRIMIENTO");

                entity.Property(e => e.Id).HasColumnName("TICO_ID");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("TICO_DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("TICO_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Porcentaje).HasColumnName("TICO_PORCENTAJE");
            });

            modelBuilder.Entity<TipoRiesgo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("TIPOS_RIESGO_PK");

                entity.ToTable("TIPOS_RIESGO");

                entity.Property(e => e.Id).HasColumnName("TIRI_ID");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("TIRI_DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
