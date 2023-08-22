using CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales;
using Microsoft.EntityFrameworkCore;

namespace CPMPlataformaDirigentes.Data.Contexto
{
    public partial class CPMDirectorioSucursalesContext : DbContext
    {
        private string connectionString = "";

        public CPMDirectorioSucursalesContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public CPMDirectorioSucursalesContext(DbContextOptions<CPMDirectorioSucursalesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PlazaWrk> PlazaWrks { get; set; } = null!;
        public virtual DbSet<SucursalWrk> SucursalWrks { get; set; } = null!;
        public virtual DbSet<RegionWrk> RegionWrks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SucursalWrk>(entity =>
            {
                entity.HasKey(e => e.IdSucursal);

                entity.ToTable("Sucursal_Wrk");

                entity.Property(e => e.IdSucursal)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Sucursal");

                entity.Property(e => e.Cajero)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CajeroReceptor).HasColumnName("Cajero_Receptor");

                entity.Property(e => e.CentroCostos).HasColumnName("Centro_Costos");

                entity.Property(e => e.CodigoPostal).HasColumnName("Codigo_Postal");

                entity.Property(e => e.Consecutivo).ValueGeneratedOnAdd();

                entity.Property(e => e.ContraCalles)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("Contra_Calles");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EntreCalles)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("Entre_Calles");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Actualizacion");

                entity.Property(e => e.FechaApertura)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Apertura");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.IdColonia).HasColumnName("Id_Colonia");

                entity.Property(e => e.IdHorario).HasColumnName("Id_Horario");

                entity.Property(e => e.IdPlaza).HasColumnName("Id_Plaza");

                entity.Property(e => e.IdTipoLocal).HasColumnName("Id_Tipo_Local");

                entity.Property(e => e.IdVialidad).HasColumnName("Id_Vialidad");

                entity.Property(e => e.LatitudUtm)
                    .HasColumnType("decimal(15, 12)")
                    .HasColumnName("Latitud_UTM");

                entity.Property(e => e.LongitudUtm)
                    .HasColumnType("decimal(15, 12)")
                    .HasColumnName("Longitud_UTM");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.NumExterior)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Exterior");

                entity.Property(e => e.NumIcbs).HasColumnName("Num_ICBS");

                entity.Property(e => e.NumInterior)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Interior");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioActualizacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Actualizacion");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion");

                entity.Property(e => e.Vpnet)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("VPNET");
            });
            modelBuilder.Entity<PlazaWrk>(entity =>
            {
                entity.HasKey(e => e.IdPlaza);

                entity.ToTable("Plaza_Wrk");

                entity.Property(e => e.IdPlaza)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Plaza");

                entity.Property(e => e.CentroCostos).HasColumnName("Centro_Costos");

                entity.Property(e => e.CodigoPostal).HasColumnName("Codigo_Postal");

                entity.Property(e => e.Consecutivo).ValueGeneratedOnAdd();

                entity.Property(e => e.ContraCalles)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("Contra_Calles");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EntreCalles)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("Entre_Calles");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Actualizacion");

                entity.Property(e => e.FechaApertura)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Apertura");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.IdColonia).HasColumnName("Id_Colonia");

                entity.Property(e => e.IdHorario).HasColumnName("Id_Horario");

                entity.Property(e => e.IdRegion).HasColumnName("Id_Region");

                entity.Property(e => e.IdTipoLocal).HasColumnName("Id_Tipo_Local");

                entity.Property(e => e.IdVialidad).HasColumnName("Id_Vialidad");

                entity.Property(e => e.LatitudUtm)
                    .HasColumnType("decimal(15, 12)")
                    .HasColumnName("Latitud_UTM");

                entity.Property(e => e.LongitudUtm)
                    .HasColumnType("decimal(15, 12)")
                    .HasColumnName("Longitud_UTM");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.NumExterior)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Exterior");

                entity.Property(e => e.NumIcbs).HasColumnName("Num_ICBS");

                entity.Property(e => e.NumInterior)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Interior");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioActualizacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Actualizacion");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion");

                entity.Property(e => e.Vpnet)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("VPNET");
            });
            modelBuilder.Entity<RegionWrk>(entity =>
            {
                entity.HasKey(e => e.IdRegion);

                entity.ToTable("Region_Wrk");

                entity.Property(e => e.IdRegion)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Region");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CentroCostos)
                    .HasColumnName("Centro_Costos")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CodigoPostal).HasColumnName("Codigo_Postal");

                entity.Property(e => e.ContraCalles)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("Contra_Calles")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EntreCalles)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("Entre_Calles")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Actualizacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdColonia)
                    .HasColumnName("Id_Colonia")
                    .HasDefaultValueSql("((33000007))");

                entity.Property(e => e.IdHorario)
                    .HasColumnName("Id_Horario")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdTipoLocal)
                    .HasColumnName("Id_Tipo_Local")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdVialidad)
                    .HasColumnName("Id_Vialidad")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LatitudUtm)
                    .HasColumnType("decimal(15, 12)")
                    .HasColumnName("Latitud_UTM")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LongitudUtm)
                    .HasColumnType("decimal(15, 12)")
                    .HasColumnName("Longitud_UTM")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumExterior)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Exterior")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumIcbs)
                    .HasColumnName("Num_ICBS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NumInterior)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Interior")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuarioActualizacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Actualizacion")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion")
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
