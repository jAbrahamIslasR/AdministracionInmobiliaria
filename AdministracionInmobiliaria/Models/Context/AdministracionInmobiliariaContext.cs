using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdministracionInmobiliaria.Models.Entities
{
    public partial class AdministracionInmobiliariaContext : DbContext
    {
        public AdministracionInmobiliariaContext()
        {
        }

        public AdministracionInmobiliariaContext(DbContextOptions<AdministracionInmobiliariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desarrollos> Desarrollos { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Propiedades> Propiedades { get; set; }
        public virtual DbSet<Rentas> Rentas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosPermisos> UsuariosPermisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-C1NNK92K;Database=AdministracionInmobiliaria;User Id=AdminInmobiliaria;Password=master.413;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desarrollos>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.Property(e => e.CantidadPagada).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Cuenta)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FechaReal).HasColumnType("datetime");

                entity.Property(e => e.MesPago)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPropiedadNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdPropiedad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_Propiedades");
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Propiedades>(entity =>
            {
                entity.Property(e => e.Adicional).IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CostoMensual).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Disponible)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Notas).IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDesarrolloNavigation)
                    .WithMany(p => p.Propiedades)
                    .HasForeignKey(d => d.IdDesarrollo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Propiedades_Desarrollos");
            });

            modelBuilder.Entity<Rentas>(entity =>
            {
                entity.Property(e => e.Arrendatario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CostoTotal).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicial).HasColumnType("datetime");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDesarrolloNavigation)
                    .WithMany(p => p.Rentas)
                    .HasForeignKey(d => d.IdDesarrollo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentas_Desarrollos");

                entity.HasOne(d => d.IdPropiedadNavigation)
                    .WithMany(p => p.Rentas)
                    .HasForeignKey(d => d.IdPropiedad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentas_Propiedades");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordEncrypted).IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuariosPermisos>(entity =>
            {
                entity.HasOne(d => d.IdPermisoNavigation)
                    .WithMany(p => p.UsuariosPermisos)
                    .HasForeignKey(d => d.IdPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosPermisos_Permisos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosPermisos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosPermisos_Usuarios");
            });
        }
    }
}
