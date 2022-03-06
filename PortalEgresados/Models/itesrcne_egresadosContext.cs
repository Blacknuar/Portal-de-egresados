using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PortalEgresados.Models
{
    public partial class itesrcne_egresadosContext : DbContext
    {
        public itesrcne_egresadosContext()
        {
        }

        public itesrcne_egresadosContext(DbContextOptions<itesrcne_egresadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Datosegresado> Datosegresados { get; set; }
        public virtual DbSet<Docente> Docentes { get; set; }
        public virtual DbSet<Egresado> Egresados { get; set; }
        public virtual DbSet<Gradosacademico> Gradosacademicos { get; set; }
        public virtual DbSet<Habilidadesegresado> Habilidadesegresados { get; set; }
        public virtual DbSet<Nivelesegresado> Nivelesegresados { get; set; }
        public virtual DbSet<Redessociale> Redessociales { get; set; }
        public virtual DbSet<Redsocial> Redsocials { get; set; }
        public virtual DbSet<Trayectorialaboral> Trayectorialaborals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=204.93.216.11;user=itesrcne_proy22;password=4veSZ42@Eii4SMt;database=itesrcne_egresados", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.29-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.ToTable("administrador");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Contraseña).HasMaxLength(128);

                entity.Property(e => e.Nombre).HasMaxLength(45);
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.ToTable("carrera");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ContraseñaJefe).HasMaxLength(128);

                entity.Property(e => e.CorreoJefe).HasMaxLength(45);

                entity.Property(e => e.Eliminado).HasColumnType("bit(1)");

                entity.Property(e => e.Nombre).HasMaxLength(70);
            });

            modelBuilder.Entity<Datosegresado>(entity =>
            {
                entity.HasKey(e => e.IdEgresado)
                    .HasName("PRIMARY");

                entity.ToTable("datosegresado");

                entity.Property(e => e.IdEgresado)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Celular).HasMaxLength(10);

                entity.Property(e => e.Ciudad).HasMaxLength(100);

                entity.Property(e => e.Curp)
                    .HasMaxLength(18)
                    .HasColumnName("CURP");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Fotografia).HasColumnType("text");

                entity.Property(e => e.Perfil).HasColumnType("text");

                entity.HasOne(d => d.IdEgresadoNavigation)
                    .WithOne(p => p.Datosegresado)
                    .HasForeignKey<Datosegresado>(d => d.IdEgresado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkDatosEgresado_Egresado");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.ToTable("docente");

                entity.HasIndex(e => e.IdCarrera, "fkIdDocenteIdCarrera");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Contraseña).HasMaxLength(128);

                entity.Property(e => e.Correo).HasMaxLength(45);

                entity.Property(e => e.Eliminado).HasColumnType("bit(1)");

                entity.Property(e => e.IdCarrera).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasMaxLength(45);
            });

            modelBuilder.Entity<Egresado>(entity =>
            {
                entity.ToTable("egresado");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AñoEgreso).HasMaxLength(4);

                entity.Property(e => e.Contraseña).HasMaxLength(128);

                entity.Property(e => e.IdCarrera).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.NunControl)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Gradosacademico>(entity =>
            {
                entity.ToTable("gradosacademicos");

                entity.HasIndex(e => e.IdEgresado, "fkIdEgresado");

                entity.HasIndex(e => e.IdNivelGrado, "fkIdNivel");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AñoEgreso).HasMaxLength(4);

                entity.Property(e => e.IdEgresado).HasColumnType("int(11)");

                entity.Property(e => e.IdNivelGrado).HasColumnType("int(11)");

                entity.Property(e => e.NombreInstituto).HasMaxLength(45);

                entity.Property(e => e.Titulo).HasMaxLength(45);

                entity.HasOne(d => d.IdEgresadoNavigation)
                    .WithMany(p => p.Gradosacademicos)
                    .HasForeignKey(d => d.IdEgresado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkIdEgresado");

                entity.HasOne(d => d.IdNivelGradoNavigation)
                    .WithMany(p => p.Gradosacademicos)
                    .HasForeignKey(d => d.IdNivelGrado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkIdNivel");
            });

            modelBuilder.Entity<Habilidadesegresado>(entity =>
            {
                entity.ToTable("habilidadesegresado");

                entity.HasIndex(e => e.IdEgresado, "fkHabilidadEgresado");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Habilidades).HasColumnType("text");

                entity.Property(e => e.IdEgresado).HasColumnType("int(11)");

                entity.HasOne(d => d.IdEgresadoNavigation)
                    .WithMany(p => p.Habilidadesegresados)
                    .HasForeignKey(d => d.IdEgresado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkHabilidadEgresado");
            });

            modelBuilder.Entity<Nivelesegresado>(entity =>
            {
                entity.ToTable("nivelesegresado");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Redessociale>(entity =>
            {
                entity.ToTable("redessociales");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Redsocial>(entity =>
            {
                entity.ToTable("redsocial");

                entity.HasIndex(e => e.IdEgresado, "fkRedSocial_Egresado");

                entity.HasIndex(e => e.IdRed, "fkRedSocial_Red");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Enlace)
                    .HasColumnType("text")
                    .HasColumnName("enlace");

                entity.Property(e => e.IdEgresado)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEgresado");

                entity.Property(e => e.IdRed)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRed");

                entity.HasOne(d => d.IdEgresadoNavigation)
                    .WithMany(p => p.Redsocials)
                    .HasForeignKey(d => d.IdEgresado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRedSocial_Egresado");

                entity.HasOne(d => d.IdRedNavigation)
                    .WithMany(p => p.Redsocials)
                    .HasForeignKey(d => d.IdRed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRedSocial_Red");
            });

            modelBuilder.Entity<Trayectorialaboral>(entity =>
            {
                entity.ToTable("trayectorialaboral");

                entity.HasIndex(e => e.IdEgresado, "fkTrayectoriaEgresado");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AñoFin).HasMaxLength(4);

                entity.Property(e => e.AñoInicio).HasMaxLength(4);

                entity.Property(e => e.IdEgresado).HasColumnType("int(11)");

                entity.Property(e => e.NombreEmpresa).HasMaxLength(45);

                entity.Property(e => e.Puesto).HasMaxLength(45);

                entity.HasOne(d => d.IdEgresadoNavigation)
                    .WithMany(p => p.Trayectorialaborals)
                    .HasForeignKey(d => d.IdEgresado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkTrayectoriaEgresado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
