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

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Polizas> Polizas { get; set; }
        public virtual DbSet<PolizasCliente> PolizasCliente { get; set; }
        public virtual DbSet<TiposCubrimiento> TiposCubrimiento { get; set; }
        public virtual DbSet<TiposRiesgo> TiposRiesgo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.ClieId)
                    .HasName("Clientes_PK");

                entity.ToTable("CLIENTES");

                entity.Property(e => e.ClieId)
                    .HasColumnName("CLIE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClieNombre)
                    .HasColumnName("CLIE_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Polizas>(entity =>
            {
                entity.HasKey(e => e.PoliId)
                    .HasName("Polizas_PK");

                entity.ToTable("POLIZAS");

                entity.Property(e => e.PoliId)
                    .HasColumnName("POLI_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PoliDescripcion)
                    .HasColumnName("POLI_DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PoliInicioVigencia)
                    .HasColumnName("POLI_INICIO_VIGENCIA")
                    .HasColumnType("date");

                entity.Property(e => e.PoliMesesCobertura).HasColumnName("POLI_MESES_COBERTURA");

                entity.Property(e => e.PoliNombre)
                    .HasColumnName("POLI_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PoliPrecio).HasColumnName("POLI_PRECIO");

                entity.Property(e => e.PoliTipoCubrimiento).HasColumnName("POLI_TIPO_CUBRIMIENTO");

                entity.Property(e => e.PoliTipoRiesgo).HasColumnName("POLI_TIPO_RIESGO");

                entity.HasOne(d => d.PoliTipoCubrimientoNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.PoliTipoCubrimiento)
                    .HasConstraintName("POLIZAS_TIPOS_CUBRIMIENTO_FK");

                entity.HasOne(d => d.PoliTipoRiesgoNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.PoliTipoRiesgo)
                    .HasConstraintName("POLIZAS_TIPOS_RIESGO_FK");
            });

            modelBuilder.Entity<PolizasCliente>(entity =>
            {
                entity.HasKey(e => new { e.PoclIdCliente, e.PoclIdPoliza })
                    .HasName("POLIZAS_CLIENTE_PK");

                entity.ToTable("POLIZAS_CLIENTE");

                entity.Property(e => e.PoclIdCliente).HasColumnName("POCL_ID_CLIENTE");

                entity.Property(e => e.PoclIdPoliza).HasColumnName("POCL_ID_POLIZA");

                entity.HasOne(d => d.PoclIdClienteNavigation)
                    .WithMany(p => p.PolizasCliente)
                    .HasForeignKey(d => d.PoclIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POLIZAS_CLIENTE_CLIENTES_FK");

                entity.HasOne(d => d.PoclIdPolizaNavigation)
                    .WithMany(p => p.PolizasCliente)
                    .HasForeignKey(d => d.PoclIdPoliza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POLIZAS_CLIENTE_POLIZAS_FK");
            });

            modelBuilder.Entity<TiposCubrimiento>(entity =>
            {
                entity.HasKey(e => e.TicoId)
                    .HasName("TIPOS_CUBRIMIENTO_PK");

                entity.ToTable("TIPOS_CUBRIMIENTO");

                entity.Property(e => e.TicoId)
                    .HasColumnName("TICO_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TicoDescripcion)
                    .HasColumnName("TICO_DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TicoNombre)
                    .HasColumnName("TICO_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TicoPorcentaje).HasColumnName("TICO_PORCENTAJE");
            });

            modelBuilder.Entity<TiposRiesgo>(entity =>
            {
                entity.HasKey(e => e.TiriId)
                    .HasName("TIPOS_RIESGO_PK");

                entity.ToTable("TIPOS_RIESGO");

                entity.Property(e => e.TiriId)
                    .HasColumnName("TIRI_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TiriDescripcion)
                    .HasColumnName("TIRI_DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
