using CPMPlataformaDirigentes.Models.ModelsConsulta;
using Microsoft.EntityFrameworkCore;

namespace CPM.PlataformaDirigentes.Data.Contexto
{
    public partial class ConsultaCPMContext : DbContext
    {
        private string connectionString = "";

        public ConsultaCPMContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ConsultaCPMContext(DbContextOptions<ConsultaCPMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CifInfgen> CifInfgens { get; set; } = null!;
        public virtual DbSet<VwInfoSocio> VwInfoSocios { get; set; } = null!;
        public virtual DbSet<VwUsuarioDirigente> VwUsuarioDirigentes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VwInfoSocio>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_InfoSocios");

                entity.Property(e => e.ApeMatSocio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApePatSocio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CALLE");

                entity.Property(e => e.Cif)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CIF");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Colonia)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Cp)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CP");

                entity.Property(e => e.CveCol)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("CVE_COL");

                entity.Property(e => e.CveEstado)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.EntreCalles)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTRE_CALLES");

                entity.Property(e => e.EstadoDomicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSucursal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FecNacD)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_NAC_D");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.NumExterior)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Num_Exterior");

                entity.Property(e => e.NumInterior)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NUM_INTERIOR");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelCasa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipSocio)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TIP_SOCIO");

                entity.Property(e => e.TipoPersona)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Persona");

                entity.Property(e => e.TipoSocio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Socio");
            });

            modelBuilder.Entity<CifInfgen>(entity =>
            {
                entity.HasKey(e => new { e.CveSucursal, e.NoSocio });

                entity.ToTable("CIF_INFGEN", "InfoCPM");

                entity.HasIndex(e => e.NoSocio, "IDX_CIF_INFGEN_EstatusMenores_SOC");

                entity.HasIndex(e => e.NoSocio, "NDX_CIF_INFGEN");

                entity.HasIndex(e => e.ApPaterno, "NDX_CIF_INFGEN_AP_PATERNO");

                entity.HasIndex(e => new { e.CveSucursal, e.ClaveMotivoIngreso }, "NDX_CIF_INFGEN_CLAVE_MOTIVO_INGRESO");

                entity.HasIndex(e => new { e.ClaveEsSocio, e.FecUltMtD, e.FechaUltimoMovParteSocial }, "NDX_CIF_INFGEN_Clave_Es_Socio_Fec_Ult_Mt_D_Fecha_UltMovPS");

                entity.HasIndex(e => new { e.FecAltaD, e.CveSucursal, e.NoSocio }, "NDX_CIF_INFGEN_FEC_ALTA");

                entity.HasIndex(e => e.ClaveMedioPorEnterado, "NDX_CIF_INFGEN_MEDIO_POR_ENTERADO");

                entity.HasIndex(e => new { e.NoSocio, e.CveSucursal }, "NDX_CIF_INFGEN_NO_SOCIO");

                entity.HasIndex(e => e.NoSocio, "NDX_NO_SOCIO");

                entity.Property(e => e.CveSucursal).HasColumnName("CVE_SUCURSAL");

                entity.Property(e => e.NoSocio)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("NO_SOCIO");

                entity.Property(e => e.ApMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AP_MATERNO");

                entity.Property(e => e.ApPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AP_PATERNO");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CALLE");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CIUDAD");

                entity.Property(e => e.ClaveEsSocio).HasColumnName("CLAVE_ES_SOCIO");

                entity.Property(e => e.ClaveEstatusPropietarioVivienda)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CLAVE_ESTATUS_PROPIETARIO_VIVIENDA");

                entity.Property(e => e.ClaveMedioPorEnterado)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CLAVE_MEDIO_POR_ENTERADO");

                entity.Property(e => e.ClaveMotivoIngreso)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CLAVE_MOTIVO_INGRESO");

                entity.Property(e => e.ClaveTipoVivienda)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CLAVE_TIPO_VIVIENDA");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO_POSTAL");

                entity.Property(e => e.Curp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CURP");

                entity.Property(e => e.CveCiudad)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("CVE_CIUDAD");

                entity.Property(e => e.CveCol)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("CVE_COL");

                entity.Property(e => e.CveEmpleo).HasColumnName("CVE_EMPLEO");

                entity.Property(e => e.CveEstado)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CVE_ESTADO");

                entity.Property(e => e.CveProfesion).HasColumnName("CVE_PROFESION");

                entity.Property(e => e.CveSector)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CVE_SECTOR");

                entity.Property(e => e.CveSucursalAperturaCuenta).HasColumnName("Cve_Sucursal_AperturaCuenta");

                entity.Property(e => e.EdoCivil)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EDO_CIVIL");

                entity.Property(e => e.EntreCalles)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTRE_CALLES");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESTATUS");

                entity.Property(e => e.FecAct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FEC_ACT");

                entity.Property(e => e.FecActD)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ACT_D");

                entity.Property(e => e.FecAlta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FEC_ALTA");

                entity.Property(e => e.FecAltaD)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ALTA_D");

                entity.Property(e => e.FecNac)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("FEC_NAC");

                entity.Property(e => e.FecNacD)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_NAC_D");

                entity.Property(e => e.FecUltMt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FEC_ULT_MT");

                entity.Property(e => e.FecUltMtD)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_ULT_MT_D");

                entity.Property(e => e.FechaAperturaParteSocial)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_AperturaParteSocial");

                entity.Property(e => e.FechaUltimoMovParteSocial)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_UltimoMovParteSocial");

                entity.Property(e => e.FechaVivienda)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_VIVIENDA");

                entity.Property(e => e.IdPreferenciaContacto).HasColumnName("Id_Preferencia_Contacto");

                entity.Property(e => e.IdTipoNivelAcademico).HasColumnName("Id_Tipo_NivelAcademico");

                entity.Property(e => e.IngresoMensual)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("INGRESO_MENSUAL");

                entity.Property(e => e.NoCreditos).HasColumnName("NO_CREDITOS");

                entity.Property(e => e.NoDependientes).HasColumnName("NO_DEPENDIENTES");

                entity.Property(e => e.NoImss)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NO_IMSS");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.NumInterior)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NUM_INTERIOR");

                entity.Property(e => e.NumeroCasa)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO_CASA");

                entity.Property(e => e.PermitirContactoEmail).HasColumnName("Permitir_ContactoEmail");

                entity.Property(e => e.PermitirContactoSms).HasColumnName("Permitir_ContactoSMS");

                entity.Property(e => e.PermitirContactoTelefono).HasColumnName("Permitir_ContactoTelefono");

                entity.Property(e => e.Poblacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POBLACION");

                entity.Property(e => e.Rfc)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("RFC");

                entity.Property(e => e.SdoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SDO_NOMBRE");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.Telefono)
                    .HasColumnType("decimal(13, 0)")
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.TipPersona)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TIP_PERSONA");

                entity.Property(e => e.TipSocio)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TIP_SOCIO");

                entity.Property(e => e.UnidadHab)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UNIDAD_HAB");
            });

            modelBuilder.Entity<VwUsuarioDirigente>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Usuario_Dirigente");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_Materno");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_Paterno");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Cif)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Postal");

                entity.Property(e => e.Colonia)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaMexicana)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Cuenta_Mexicana");

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Estado_Civil");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Ingreso");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(203)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Completo");

                entity.Property(e => e.NumeroInterior)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Interior");

                entity.Property(e => e.Plaza)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PlazaId).HasColumnName("Plaza_Id");

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SucursalId).HasColumnName("Sucursal_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
