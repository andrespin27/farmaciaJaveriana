using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace farmaciaJaveriana.Models
{
    public partial class FarmaciaContext : IdentityDbContext
    {
        public FarmaciaContext()
        {
        }

        public FarmaciaContext(DbContextOptions<FarmaciaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aplicacione> Aplicaciones { get; set; }
        public virtual DbSet<Catalogo> Catalogos { get; set; }
        public virtual DbSet<Ciudade> Ciudades { get; set; }
        public virtual DbSet<DespachoDet> DespachoDets { get; set; }
        public virtual DbSet<DespachoEnc> DespachoEncs { get; set; }
        public virtual DbSet<Distancia> Distancias { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<SolicitudDespachoTercero> SolicitudDespachoTerceros { get; set; }
        public virtual DbSet<Tercero> Terceros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.\\APINEDA;Database=Farmacia;User Id=sa;Password=Perseo5581;");
            }
        }

        //Scaffold-DbContext "Server=.\APINEDA;Database=Farmacia;User Id=sa;Password=Perseo5581;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Aplicacione>(entity =>
            {
                entity.HasKey(e => e.IdAplicacion);

                entity.Property(e => e.IdAplicacion)
                    .ValueGeneratedNever()
                    .HasColumnName("idAplicacion");

                entity.Property(e => e.FechaAplicacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaAplicacion");

                entity.Property(e => e.IdDespacho).HasColumnName("idDespacho");

                entity.Property(e => e.IdRow).HasColumnName("idRow");

                entity.HasOne(d => d.IdDespachoNavigation)
                    .WithMany(p => p.Aplicaciones)
                    .HasForeignKey(d => d.IdDespacho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aplicaciones_DespachoEnc");

                entity.HasOne(d => d.IdRowNavigation)
                    .WithMany(p => p.Aplicaciones)
                    .HasForeignKey(d => d.IdRow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aplicaciones_DespachoTercero");
            });

            modelBuilder.Entity<Catalogo>(entity =>
            {
                entity.HasKey(e => e.IdCatalogo);

                entity.Property(e => e.IdCatalogo)
                    .ValueGeneratedNever()
                    .HasColumnName("idCatalogo");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiasEntrega).HasColumnName("diasEntrega");

                entity.Property(e => e.DistaciaFin)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("distaciaFin");

                entity.Property(e => e.DistanciaIni)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("distanciaIni");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCargue)
                    .HasColumnType("date")
                    .HasColumnName("fechaCargue");

                entity.Property(e => e.IdCiudad)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idCiudad");

                entity.Property(e => e.IdTercero).HasColumnName("idTercero");

                entity.Property(e => e.PesoFin)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("pesoFin");

                entity.Property(e => e.PesoIni)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("pesoIni");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Catalogos)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalogos_Ciudades");

                entity.HasOne(d => d.IdTerceroNavigation)
                    .WithMany(p => p.Catalogos)
                    .HasForeignKey(d => d.IdTercero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalogos_Tercero");
            });

            modelBuilder.Entity<Ciudade>(entity =>
            {
                entity.HasKey(e => e.IdCiudad);

                entity.Property(e => e.IdCiudad)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idCiudad");

                entity.Property(e => e.IdDepto)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idDepto");

                entity.Property(e => e.NombreCiudad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreCiudad");

                entity.Property(e => e.NombreDepto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreDepto");
            });

            modelBuilder.Entity<DespachoDet>(entity =>
            {
                entity.HasKey(e => e.IdDespachoDet);

                entity.ToTable("DespachoDet");

                entity.Property(e => e.IdDespachoDet)
                    .ValueGeneratedNever()
                    .HasColumnName("idDespachoDet");

                entity.Property(e => e.IdDespachoEnc).HasColumnName("idDespachoEnc");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreProducto");

                entity.Property(e => e.PesoProducto)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("pesoProducto");

                entity.HasOne(d => d.IdDespachoEncNavigation)
                    .WithMany(p => p.DespachoDets)
                    .HasForeignKey(d => d.IdDespachoEnc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DespachoDet_DespachoEnc");
            });

            modelBuilder.Entity<DespachoEnc>(entity =>
            {
                entity.HasKey(e => e.IdDespacho);

                entity.ToTable("DespachoEnc");

                entity.Property(e => e.IdDespacho)
                    .ValueGeneratedNever()
                    .HasColumnName("idDespacho");

                entity.Property(e => e.DirDestino)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dirDestino");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaDescarga)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDescarga");

                entity.Property(e => e.FechaOrden)
                    .HasColumnType("date")
                    .HasColumnName("fechaOrden");

                entity.Property(e => e.IdCiudadDestino).HasColumnName("idCiudadDestino");

                entity.Property(e => e.IdTercero).HasColumnName("idTercero");

                entity.Property(e => e.PesoTotal)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("pesoTotal");

                entity.Property(e => e.ValorAsegurable)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorAsegurable");

                entity.HasOne(d => d.IdTerceroNavigation)
                    .WithMany(p => p.DespachoEncs)
                    .HasForeignKey(d => d.IdTercero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DespachoEnc_Tercero");
            });

            modelBuilder.Entity<Distancia>(entity =>
            {
                entity.HasKey(e => e.IdDistancia);

                entity.Property(e => e.IdDistancia)
                    .ValueGeneratedNever()
                    .HasColumnName("idDistancia");

                entity.Property(e => e.CantidadKm)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("cantidadKm");

                entity.Property(e => e.IdCiudad)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("idCiudad");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Distancia)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distancias_Ciudades");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.IdLog);

                entity.ToTable("Log");

                entity.Property(e => e.IdLog)
                    .ValueGeneratedNever()
                    .HasColumnName("idLog");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaEvento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaEvento");

                entity.Property(e => e.IdTercero).HasColumnName("idTercero");

                entity.Property(e => e.NombreEvento).HasColumnName("nombreEvento");

                entity.HasOne(d => d.IdTerceroNavigation)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.IdTercero)
                    .HasConstraintName("FK_Log_Tercero");
            });

            modelBuilder.Entity<SolicitudDespachoTercero>(entity =>
            {
                entity.HasKey(e => e.IdRow)
                    .HasName("PK_DespachoTercero");

                entity.ToTable("SolicitudDespachoTercero");

                entity.Property(e => e.IdRow)
                    .ValueGeneratedNever()
                    .HasColumnName("idRow");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaSolicitud)
                    .HasColumnType("date")
                    .HasColumnName("fechaSolicitud");

                entity.Property(e => e.IdDespacho).HasColumnName("idDespacho");

                entity.Property(e => e.IdTercero).HasColumnName("idTercero");

                entity.HasOne(d => d.IdDespachoNavigation)
                    .WithMany(p => p.SolicitudDespachoTerceros)
                    .HasForeignKey(d => d.IdDespacho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DespachoTercero_DespachoEnc");

                entity.HasOne(d => d.IdTerceroNavigation)
                    .WithMany(p => p.SolicitudDespachoTerceros)
                    .HasForeignKey(d => d.IdTercero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DespachoTercero_Tercero");
            });

            modelBuilder.Entity<Tercero>(entity =>
            {
                entity.HasKey(e => e.IdTercero);

                entity.ToTable("Tercero");

                entity.Property(e => e.IdTercero).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NitTercero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nitTercero");

                entity.Property(e => e.NombreTercero)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreTercero");

                entity.Property(e => e.NumCelular).HasColumnName("numCelular");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.TipoTercero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipoTercero");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
