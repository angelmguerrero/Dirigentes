using CPM.PlataformaDirigentes.Models.Models;
using CPMPlataformaDirigentes.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace CPM.PlataformaDirigentes.Data.Contexto
{
    public partial class CPMDirigentesPlataformaContext : DbContext
    {
        private string connectionString = "";

        public CPMDirigentesPlataformaContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public CPMDirigentesPlataformaContext(DbContextOptions<CPMDirigentesPlataformaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accion> Accions { get; set; } = null!;
        public virtual DbSet<Acuerdo> Acuerdos { get; set; } = null!;
        public virtual DbSet<Archivo> Archivos { get; set; } = null!;
        public virtual DbSet<CargoCat> CargoCats { get; set; } = null!;
        public virtual DbSet<CargosPlaza> CargosPlazas { get; set; } = null!;
        public virtual DbSet<CargoxOrgano> CargoxOrganos { get; set; } = null!;
        public virtual DbSet<ClasificacionProfesion> ClasificacionProfesions { get; set; } = null!;
        public virtual DbSet<CondicionIngresoCat> CondicionIngresoCats { get; set; } = null!;
        public virtual DbSet<CorreosOcultosCat> CorreosOcultosCats { get; set; } = null!;
        public virtual DbSet<CuentasDepositoCat> CuentasDepositoCats { get; set; } = null!;
        public virtual DbSet<DetalleOrdenDium> DetalleOrdenDia { get; set; } = null!;
        public virtual DbSet<DiasInhabilesCat> DiasInhabilesCats { get; set; } = null!;
        public virtual DbSet<EscolaridadCat> EscolaridadCats { get; set; } = null!;
        public virtual DbSet<EstadoCivilCat> EstadoCivilCats { get; set; } = null!;
        public virtual DbSet<EstatusAcuerdosCat> EstatusAcuerdosCats { get; set; } = null!;
        public virtual DbSet<FormacionPersona> FormacionPersonas { get; set; } = null!;
        public virtual DbSet<GeneroCat> GeneroCats { get; set; } = null!;
        public virtual DbSet<LogMovimiento> LogMovimientos { get; set; } = null!;
        public virtual DbSet<Materiale> Materiales { get; set; } = null!;
        public virtual DbSet<ModalidadCat> ModalidadCats { get; set; } = null!;
        public virtual DbSet<ModuloCat> ModuloCats { get; set; } = null!;
        public virtual DbSet<MotivosBajaCat> MotivosBajaCats { get; set; } = null!;
        public virtual DbSet<OficioCat> OficioCats { get; set; } = null!;
        public virtual DbSet<OperacionCat> OperacionCats { get; set; } = null!;
        public virtual DbSet<OrdenDelDium> OrdenDelDia { get; set; } = null!;
        public virtual DbSet<OrganoCat> OrganoCats { get; set; } = null!;
        public virtual DbSet<Permiso> Permisos { get; set; } = null!;
        public virtual DbSet<PersonaCat> PersonaCats { get; set; } = null!;
        public virtual DbSet<PersonaCuentaDeposito> PersonaCuentaDepositos { get; set; } = null!;
        public virtual DbSet<ProfesionCat> ProfesionCats { get; set; } = null!;
        public virtual DbSet<RepresententantesPlazaCat> RepresententantesPlazaCats { get; set; } = null!;
        public virtual DbSet<ReunionCargo> ReunionCargos { get; set; } = null!;
        public virtual DbSet<ReunionSubUnidadOpe> ReunionSubUnidadOpes { get; set; } = null!;
        public virtual DbSet<SubDetalleOrdenDium> SubDetalleOrdenDia { get; set; } = null!;
        public virtual DbSet<SubModuloCat> SubModuloCats { get; set; } = null!;
        public virtual DbSet<SubUnidadOperativaCat> SubUnidadOperativaCats { get; set; } = null!;
        public virtual DbSet<TipoArchivoCat> TipoArchivoCats { get; set; } = null!;
        public virtual DbSet<TipoJuntaCat> TipoJuntaCats { get; set; } = null!;
        public virtual DbSet<TipoPersonaCat> TipoPersonaCats { get; set; } = null!;
        public virtual DbSet<UnidadOperativaCat> UnidadOperativaCats { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Votacion> Votacions { get; set; } = null!;
        public virtual DbSet<PersonalAdministrativoCat> PersonalAdministrativoCats { get; set; } = null!;
        public virtual DbSet<DiasParametrizablesCat> DiasParametrizablesCats { get; set; } = null!;
        public virtual DbSet<FinSemanaInhabilCat> FinSemanaInhabilCats { get; set; } = null!;
        public virtual DbSet<NivelGestionCat> NivelGestionCats { get; set; } = null!;
        public virtual DbSet<PerfilCargo> PerfilCargos { get; set; } = null!;
        public virtual DbSet<NoticiaCat> NoticiaCats { get; set; } = null!;
        public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; } = null!;
        public virtual DbSet<Solicitud> Solicitudes { get; set; } = null!;
        public virtual DbSet<ResponsablePlaza> ResponsablePlazas { get; set; } = null!;
        public virtual DbSet<TipoBaja> TipoBajas { get; set; } = null!;
        public virtual DbSet<SolicitudResponsablePlaza> SolicitudResponsablePlazas { get; set; } = null!;
        public virtual DbSet<Dirigente> Dirigente { get; set; } = null!;
        public virtual DbSet<DetallePlantillaOrdenDia> DetallePlantillaOrdenDia { get; set; } = null!;
        public virtual DbSet<PlantillaOrdenDia> PlantillaOrdenDia { get; set; } = null!;
        public virtual DbSet<PersonaSolicitudHist> PersonaSolicitudHists { get; set; } = null!;
        public virtual DbSet<LogGeneral> LogGenerals { get; set; } = null!;
        public virtual DbSet<Convocatorium> Convocatoria { get; set; } = null!;
        public virtual DbSet<RelMeetingAsistente> RelMeetingAsistentes { get; set; } = null!;
        public virtual DbSet<RelMeetingConvocatorium> RelMeetingConvocatoria { get; set; } = null!;
        public virtual DbSet<RelMeetingOrdenDium> RelMeetingOrdenDia { get; set; } = null!;
        public virtual DbSet<NivelDirigencialCat> NivelDirigencialCats { get; set; } = null!;
        public virtual DbSet<NivelDirigencial> NivelDirigencials { get; set; } = null!;
        public virtual DbSet<EnvioCorreo> EnvioCorreos { get; set; } = null!;
        public virtual DbSet<RelMeetingAutorizacion> RelMeetingAutorizacions { get; set; } = null!;





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogGeneral>(entity =>
            {
                entity.ToTable("Log_General");

                entity.Property(e => e.LogGeneralId).HasColumnName("Log_General_Id");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdModulo)
                    .HasColumnName("Id_Modulo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdSubmodulo)
                    .HasColumnName("Id_Submodulo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoMovimiento)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Movimiento")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuarioCorreo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Correo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuarioNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Nombre")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Dirigente>(entity =>
            {
                entity.HasKey(e => e.IdDirigente);

                entity.ToTable("Dirigente");

                entity.Property(e => e.IdDirigente).HasColumnName("Id_Dirigente");

                entity.Property(e => e.Curriculum)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ExpedienteDigital)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Expediente_Digital");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            });

            modelBuilder.Entity<SolicitudResponsablePlaza>(entity =>
            {
                entity.HasKey(e => e.IdSolicitudResponsablePlaza);

                entity.ToTable("Solicitud_Responsable_Plaza");

                entity.Property(e => e.IdSolicitudResponsablePlaza).HasColumnName("Id_Solicitud_Responsable_Plaza");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Registro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdResponsablePlaza).HasColumnName("Id_Responsable_Plaza");

                entity.Property(e => e.IdSolicitud).HasColumnName("Id_Solicitud");
            });
            modelBuilder.Entity<ResponsablePlaza>(entity =>
            {
                entity.HasKey(e => e.IdResponsablePlaza);

                entity.ToTable("Responsable_Plaza");

                entity.Property(e => e.IdResponsablePlaza).HasColumnName("Id_Responsable_Plaza");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Registro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.IdPlaza).HasColumnName("Id_Plaza");
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud);

                entity.ToTable("Solicitud");

                entity.Property(e => e.IdSolicitud).HasColumnName("Id_Solicitud");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusSolicitud).HasColumnName("Estatus_Solicitud");

                entity.Property(e => e.FechaEfectivaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Efectiva_Baja")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaReingreso)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Reingreso");

                entity.Property(e => e.FechaSolicitud)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Solicitud")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMotivoBaja).HasColumnName("Id_MotivoBaja");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.IdPersonaSolicitante).HasColumnName("Id_Persona_Solicitante");

                entity.Property(e => e.IdTipoBaja).HasColumnName("Id_Tipo_Baja");

                entity.Property(e => e.IdTipoMovimiento).HasColumnName("Id_Tipo_Movimiento");

                entity.Property(e => e.Observaciones)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });


            modelBuilder.Entity<TipoMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdTipoMovimiento);

                entity.ToTable("Tipo_Movimiento");

                entity.Property(e => e.IdTipoMovimiento).HasColumnName("Id_Tipo_Movimiento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PerfilCargo>(entity =>
            {
                entity.HasKey(e => e.IdPerfilCargo)
                    .HasName("PK__Perfil__2CDD94197D0DCAAB");

                entity.ToTable("Perfil_Cargo");

                entity.Property(e => e.IdPerfilCargo).HasColumnName("Id_Perfil_Cargo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EsCargo).HasColumnName("Es_Cargo");

                entity.Property(e => e.EstatusPerfil).HasColumnName("Estatus_Perfil");

                entity.Property(e => e.OrdenCargo).HasColumnName("Orden_Cargo");
            });

            modelBuilder.Entity<Accion>(entity =>
            {
                entity.HasKey(e => e.IdAccion)
                    .HasName("_copy_10");

                entity.ToTable("Accion");

                entity.Property(e => e.IdAccion).HasColumnName("Id_Accion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusAccion).HasColumnName("Estatus_Accion");

                entity.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");


            });

            modelBuilder.Entity<Acuerdo>(entity =>
            {
                entity.HasKey(e => e.IdAcuerdo);

                entity.ToTable("Acuerdo");

                entity.Property(e => e.IdAcuerdo).HasColumnName("Id_Acuerdo");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.IdConvocatoria).HasColumnName("Id_Convocatoria");

                entity.Property(e => e.IdEstatusAcuerdo).HasColumnName("Id_Estatus_Acuerdo");


            });

            modelBuilder.Entity<Archivo>(entity =>
            {
                entity.HasKey(e => e.IdArchivo)
                    .HasName("_copy_9");

                entity.ToTable("Archivo");

                entity.Property(e => e.IdArchivo).HasColumnName("Id_Archivo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusArchivo).HasColumnName("Estatus_Archivo");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CargoCat>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("_copy_14");

                entity.ToTable("Cargo_Cat");

                entity.Property(e => e.IdCargo).HasColumnName("Id_Cargo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusCargo).HasColumnName("Estatus_Cargo");

                entity.Property(e => e.OrdenCargo).HasColumnName("Orden_Cargo");
            });

            modelBuilder.Entity<CargosPlaza>(entity =>
            {
                entity.HasKey(e => e.IdCargoPlaza);

                entity.ToTable("CargosPlaza");

                entity.Property(e => e.IdCargoPlaza).HasColumnName("Id_Cargo_Plaza");

                entity.Property(e => e.EstatusCargoPlaza).HasColumnName("Estatus_Cargo_Plaza");

                entity.Property(e => e.IdCargo).HasColumnName("Id_Cargo");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.IdPlaza).HasColumnName("Id_Plaza");
            });

            modelBuilder.Entity<CargoxOrgano>(entity =>
            {
                entity.HasKey(e => e.IdCargoOrgano);

                entity.ToTable("CargoxOrgano");

                entity.Property(e => e.IdCargoOrgano).HasColumnName("Id_Cargo_Organo");

                entity.Property(e => e.EstatusCargoOrgano).HasColumnName("Estatus_Cargo_Organo");

                entity.Property(e => e.FechaActaDesignacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Acta_Designacion");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Final");

                entity.Property(e => e.FechaIngresoSocio)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Ingreso_Socio");

                entity.Property(e => e.FechaInicial)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Inicial");

                entity.Property(e => e.FechaNombramiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nombramiento");

                entity.Property(e => e.Firmante)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdNivelGestion).HasColumnName("Id_NivelGestion");

                entity.Property(e => e.IdOrgano).HasColumnName("Id_Organo");

                entity.Property(e => e.IdPerfilCargo).HasColumnName("Id_Perfil_Cargo");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.IdPlaza).HasColumnName("Id_Plaza");

                entity.Property(e => e.Necesario)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Suplente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });



            modelBuilder.Entity<ClasificacionProfesion>(entity =>
            {
                entity.HasKey(e => e.IdClasificacionProfesion);

                entity.ToTable("Clasificacion_Profesion");

                entity.Property(e => e.IdClasificacionProfesion).HasColumnName("Id_Clasificacion_Profesion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusClasificacionProfesion).HasColumnName("Estatus_Clasificacion_Profesion");
            });

            modelBuilder.Entity<CondicionIngresoCat>(entity =>
            {
                entity.HasKey(e => e.IdCondicion);

                entity.ToTable("CondicionIngreso_Cat");

                entity.Property(e => e.IdCondicion).HasColumnName("Id_Condicion");

                entity.Property(e => e.CondicionIngreso)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Condicion_Ingreso");

                entity.Property(e => e.EstatusCondicion).HasColumnName("Estatus_Condicion");
            });





            modelBuilder.Entity<CorreosOcultosCat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CorreosOcultos_Cat");

                entity.Property(e => e.Correo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusCorreoOculto).HasColumnName("Estatus_Correo_Oculto");

                entity.Property(e => e.IdCorreoOculto)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Correo_Oculto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CuentasDepositoCat>(entity =>
            {
                entity.HasKey(e => e.IdCuentaDeposito)
                    .HasName("PK__Cuentas___A770F39C3FDBA12F");

                entity.ToTable("Cuentas_Deposito_Cat");

                entity.Property(e => e.IdCuentaDeposito)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Cuenta_Deposito");

                entity.Property(e => e.DescCuentaDeposito)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Desc_Cuenta_Deposito");
            });

            modelBuilder.Entity<DetalleOrdenDium>(entity =>
            {
                entity.HasKey(e => e.IdDetalleOrdenDia);

                entity.ToTable("Detalle_OrdenDia");

                entity.Property(e => e.IdDetalleOrdenDia).HasColumnName("Id_Detalle_Orden_Dia");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.EstatusDetalleOrdenDia).HasColumnName("Estatus_Detalle_Orden_Dia");

                entity.Property(e => e.IdSubDetalleOrdenDia).HasColumnName("Id_SubDetalle_Orden_Dia");


            });

            modelBuilder.Entity<DiasInhabilesCat>(entity =>
            {
                entity.HasKey(e => e.IdDiaInhabil);

                entity.ToTable("DiasInhabiles_Cat");

                entity.Property(e => e.IdDiaInhabil).HasColumnName("Id_Dia_Inhabil");

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.EstatusDiaInhabil).HasColumnName("Estatus_Dia_Inhabil");

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<EscolaridadCat>(entity =>
            {
                entity.HasKey(e => e.IdEscolaridad)
                    .HasName("PK__Escolari__A3E2EA0FEFD21DB6");

                entity.ToTable("Escolaridad_Cat");

                entity.Property(e => e.IdEscolaridad).HasColumnName("Id_Escolaridad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusEscolaridad).HasColumnName("Estatus_Escolaridad");
            });

            modelBuilder.Entity<EstadoCivilCat>(entity =>
            {
                entity.HasKey(e => e.IdEstadoCivil)
                    .HasName("PK__Estado_C__CAE6659A97629963");

                entity.ToTable("Estado_Civil_Cat");

                entity.Property(e => e.IdEstadoCivil).HasColumnName("Id_Estado_Civil");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusEstadoCivil).HasColumnName("Estatus_Estado_Civil");
            });

            modelBuilder.Entity<EstatusAcuerdosCat>(entity =>
            {
                entity.HasKey(e => e.IdEstatusAcuerdo);

                entity.ToTable("EstatusAcuerdos_Cat");

                entity.Property(e => e.IdEstatusAcuerdo).HasColumnName("Id_Estatus_Acuerdo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EstatusAcuerdo).HasColumnName("Estatus_Acuerdo");

            });

            modelBuilder.Entity<FormacionPersona>(entity =>
            {
                entity.HasKey(e => e.IdFormacionPersona);

                entity.ToTable("Formacion_Persona");

                entity.Property(e => e.IdFormacionPersona).HasColumnName("Id_Formacion_Persona");

                entity.Property(e => e.EstatusFormacionPersona).HasColumnName("Estatus_Formacion_Persona");

                entity.Property(e => e.FechaFinCargo)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Fin_Cargo");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Ingreso");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.IdSubUnidadOperativa).HasColumnName("Id_SubUnidad_Operativa");


            });

            modelBuilder.Entity<GeneroCat>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero_C__E76DD66EBE26222F");

                entity.ToTable("Genero_Cat");

                entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusGenero).HasColumnName("Estatus_Genero");
            });

            modelBuilder.Entity<LogMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdLogMovimiento)
                    .HasName("PK__Log_Movi__C856404545176C5C");

                entity.ToTable("Log_Movimientos");

                entity.Property(e => e.IdLogMovimiento).HasColumnName("Id_Log_Movimiento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");


            });

            modelBuilder.Entity<Materiale>(entity =>
            {
                entity.HasKey(e => e.IdMaterial);

                entity.Property(e => e.IdMaterial).HasColumnName("Id_Material");

                entity.Property(e => e.Descripción).IsUnicode(false);

                entity.Property(e => e.EstatusMaterial).HasColumnName("Estatus_Material");

                entity.Property(e => e.Junta)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModalidadCat>(entity =>
            {
                entity.HasKey(e => e.IdModalidad);

                entity.ToTable("Modalidad_Cat");

                entity.Property(e => e.IdModalidad).HasColumnName("Id_Modalidad");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.EstatusModalidad).HasColumnName("Estatus_Modalidad");
            });

            modelBuilder.Entity<ModuloCat>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("_copy_13");

                entity.ToTable("Modulo_Cat");

                entity.Property(e => e.IdModulo).HasColumnName("Id_Modulo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusModulo).HasColumnName("Estatus_Modulo");
            });

            modelBuilder.Entity<MotivosBajaCat>(entity =>
            {
                entity.HasKey(e => e.IdMotivoBaja)
                    .HasName("PK_Motivos deBaja");

                entity.ToTable("MotivosBaja_Cat");

                entity.Property(e => e.IdMotivoBaja).HasColumnName("Id_MotivoBaja");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Descripcion");

                entity.Property(e => e.EstatusMotivoBaja).HasColumnName("Estatus_MotivoBaja");
            });

            modelBuilder.Entity<OficioCat>(entity =>
            {
                entity.HasKey(e => e.IdOficio)
                    .HasName("PK__Oficio_C__3835DED9D36925F3");

                entity.ToTable("Oficio_Cat");

                entity.Property(e => e.IdOficio).HasColumnName("Id_Oficio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusOficio).HasColumnName("Estatus_Oficio");
            });

            modelBuilder.Entity<OperacionCat>(entity =>
            {
                entity.HasKey(e => e.IdOperacion)
                    .HasName("_copy_11");

                entity.ToTable("Operacion_Cat");

                entity.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusOperacion).HasColumnName("Estatus_Operacion");

                entity.Property(e => e.IdSubModulo).HasColumnName("Id_SubModulo");
            });

            modelBuilder.Entity<OrdenDelDium>(entity =>
            {
                entity.HasKey(e => e.IdOrdenDia);

                entity.ToTable("Orden_del_dia");

                entity.Property(e => e.IdOrdenDia).HasColumnName("Id_Orden_Dia");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.EstatusOrdenDia).HasColumnName("Estatus_Orden_Dia");

                entity.Property(e => e.IdDetalleOrdenDia).HasColumnName("Id_Detalle_Orden_dia");

                entity.Property(e => e.IdTipoJunta).HasColumnName("Id_Tipo_Junta");


            });

            modelBuilder.Entity<OrganoCat>(entity =>
            {
                entity.HasKey(e => e.IdOrgano);

                entity.ToTable("Organo_Cat");

                entity.Property(e => e.IdOrgano).HasColumnName("Id_Organo");

                entity.Property(e => e.AbreviaturaOrgano)
                    .IsRequired()
                     .HasMaxLength(50)
                     .IsUnicode(false)
                     .HasColumnName("Abreviatura_Organo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusOrgano).HasColumnName("Estatus_Organo");

                entity.Property(e => e.IdMaterial).HasColumnName("Id_Material");

                entity.Property(e => e.IdNivelGestion).HasColumnName("Id_NivelGestion");

                entity.Property(e => e.NoFirmas).HasColumnName("No_Firmas");
            });



            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso);

                entity.ToTable("Permiso");

                entity.Property(e => e.IdPermiso).HasColumnName("Id_Permiso");

                entity.Property(e => e.EstatusPermiso).HasColumnName("Estatus_Permiso");

                entity.Property(e => e.IdPerfilCargo).HasColumnName("Id_Perfil_Cargo");



                entity.Property(e => e.IdSubModulo).HasColumnName("Id_SubModulo");


            });

            modelBuilder.Entity<PersonaCat>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("_copy_2");

                entity.ToTable("Persona_Cat");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_Materno")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_Paterno")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Calle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cif).HasColumnName("CIF");

                entity.Property(e => e.CodigoPostal).HasColumnName("Codigo_Postal");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorreoPersonal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Correo_Personal")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaMexicana)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cuenta_Mexicana")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Curp)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("CURP")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EstatusPersona).HasColumnName("Estatus_Persona");

                entity.Property(e => e.EstatusSolicitud)
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .HasColumnName("Estatus_Solicitud");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Baja");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Ingreso");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.IdCargo).HasColumnName("Id_Cargo");

                entity.Property(e => e.IdDirigente).HasColumnName("Id_Dirigente");

                entity.Property(e => e.IdEscolaridad).HasColumnName("Id_Escolaridad");

                entity.Property(e => e.IdEstadoCivil).HasColumnName("Id_Estado_Civil");

                entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");

                entity.Property(e => e.IdOficio).HasColumnName("Id_Oficio");

                entity.Property(e => e.IdPlaza).HasColumnName("Id_Plaza");

                entity.Property(e => e.IdProfesion).HasColumnName("Id_Profesion");

                entity.Property(e => e.IdRepresententanteCargoCat).HasColumnName("Id_Represententante_Cargo_Cat");

                entity.Property(e => e.IdSubUnidadOperativa).HasColumnName("Id_SubUnidad_Operativa");

                entity.Property(e => e.IdSucursal).HasColumnName("Id_Sucursal");

                entity.Property(e => e.IdTipoPersona).HasColumnName("Id_Tipo_Persona");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombrePersona)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Persona")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumeroInterior)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Interior")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Participacion)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.Plaza)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rfc)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("RFC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<PersonaCuentaDeposito>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Pesona_C__C95634AFEC09B7E0");

                entity.ToTable("Persona_Cuenta_Deposito");

                entity.Property(e => e.IdPersona)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Persona");

                entity.Property(e => e.IdCuentaDeposito).HasColumnName("Id_Cuenta_Deposito");


            });

            modelBuilder.Entity<ProfesionCat>(entity =>
            {
                entity.HasKey(e => e.IdProfesion)
                    .HasName("PK_Profesion");

                entity.ToTable("Profesion_Cat");

                entity.Property(e => e.IdProfesion).HasColumnName("Id_Profesion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusProfesion).HasColumnName("Estatus_Profesion");

                entity.Property(e => e.IdClasificacionProfesion).HasColumnName("Id_Clasificacion_Profesion");


            });

            modelBuilder.Entity<RepresententantesPlazaCat>(entity =>
            {
                entity.HasKey(e => e.IdRepresentantePlazaCat);

                entity.ToTable("RepresententantesPlaza_Cat");

                entity.Property(e => e.IdRepresentantePlazaCat).HasColumnName("Id_Representante_Plaza_Cat");

                entity.Property(e => e.EstatusRepresentantePlazaCat).HasColumnName("Estatus_Representante_Plaza_Cat");

                entity.Property(e => e.IdCargo).HasColumnName("Id_Cargo");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.IdPlaza).HasColumnName("Id_Plaza");


            });

            modelBuilder.Entity<ReunionCargo>(entity =>
            {
                entity.HasKey(e => new { e.IdReunion, e.IdCargo })
                    .HasName("PK__Reunion___A43933AB11854A50");

                entity.ToTable("Reunion_Cargo");

                entity.Property(e => e.IdReunion).HasColumnName("Id_Reunion");

                entity.Property(e => e.IdCargo).HasColumnName("Id_Cargo");
            });



            modelBuilder.Entity<ReunionSubUnidadOpe>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Reunion_SubUnidadOpe");

                entity.Property(e => e.IdReunion).HasColumnName("Id_Reunion");

                entity.Property(e => e.IdSubUnidadOperativa).HasColumnName("Id_SubUnidadOperativa");
            });

            modelBuilder.Entity<SubDetalleOrdenDium>(entity =>
            {
                entity.HasKey(e => e.IdSubDetalleOrdenDia);

                entity.ToTable("Sub_Detalle_OrdenDia");

                entity.Property(e => e.IdSubDetalleOrdenDia)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_SubDetalle_OrdenDia");

                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<SubModuloCat>(entity =>
            {
                entity.HasKey(e => e.IdSubModulo)
                    .HasName("_copy_12");

                entity.ToTable("SubModulo_Cat");

                entity.Property(e => e.IdSubModulo).HasColumnName("Id_SubModulo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusSubModulo).HasColumnName("Estatus_SubModulo");

                entity.Property(e => e.IdModulo).HasColumnName("Id_Modulo");
            });

            modelBuilder.Entity<SubUnidadOperativaCat>(entity =>
            {
                entity.HasKey(e => e.IdSubUnidadOperativa)
                    .HasName("_copy_16");

                entity.ToTable("SubUnidadOperativa_Cat");

                entity.Property(e => e.IdSubUnidadOperativa)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_SubUnidadOperativa");

                entity.Property(e => e.DescUnidadOperativa)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Desc_UnidadOperativa");

                entity.Property(e => e.EstatusSubUnidadOpe).HasColumnName("Estatus_SubUnidadOpe");

                entity.Property(e => e.IdUnidadOperativa).HasColumnName("Id_UnidadOperativa");
            });

            modelBuilder.Entity<TipoArchivoCat>(entity =>
            {
                entity.HasKey(e => e.IdTipoArchivo)
                    .HasName("_copy_8");

                entity.ToTable("TipoArchivo_Cat");

                entity.Property(e => e.IdTipoArchivo)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_TipoArchivo");

                entity.Property(e => e.DescTipoArchivo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Desc_TipoArchivo");

                entity.Property(e => e.EstatusTipoArchivo).HasColumnName("Estatus_TipoArchivo");
            });

            modelBuilder.Entity<TipoJuntaCat>(entity =>
            {
                entity.HasKey(e => e.IdTipoJunta);

                entity.ToTable("TipoJunta_Cat");

                entity.Property(e => e.IdTipoJunta).HasColumnName("Id_Tipo_Junta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Desccripcion");

                entity.Property(e => e.EstatusTipoJunta).HasColumnName("Estatus_Tipo_Junta");
            });

            modelBuilder.Entity<TipoPersonaCat>(entity =>
            {
                entity.HasKey(e => e.IdTipoPersona)
                    .HasName("PK__TipoPers__64B4F253B66C3A55");

                entity.ToTable("TipoPersona_Cat");

                entity.Property(e => e.IdTipoPersona).HasColumnName("Id_Tipo_Persona");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusTipoPersona).HasColumnName("Estatus_Tipo_Persona");
            });

            modelBuilder.Entity<UnidadOperativaCat>(entity =>
            {
                entity.HasKey(e => e.IdUnidadOperativa)
                    .HasName("_copy_17");

                entity.ToTable("UnidadOperativa_Cat");

                entity.Property(e => e.IdUnidadOperativa)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_UnidadOperativa");

                entity.Property(e => e.Abreviatura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescUnidadOperativa)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Desc_UnidadOperativa");

                entity.Property(e => e.EstatusUnidadOpe).HasColumnName("Estatus_UnidadOpe");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.CorreoAcceso)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Correo_Acceso")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EstatusUsuario).HasColumnName("Estatus_Usuario");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdPerfilCargo).HasColumnName("Id_Perfil_Cargo");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.Password)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuarioDa)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_DA")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Votacion>(entity =>
            {
                entity.HasKey(e => e.IdVotacion)
                    .HasName("_copy_4");

                entity.ToTable("Votacion");

                entity.Property(e => e.IdVotacion).HasColumnName("Id_Votacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusVotacion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Estatus_Votacion");

                entity.Property(e => e.IdConvocatoria).HasColumnName("Id_Convocatoria");

                entity.Property(e => e.UrlVotacion)
                    .IsUnicode(false)
                    .HasColumnName("URL_Votacion");


            });

            modelBuilder.Entity<PersonalAdministrativoCat>(entity =>
            {
                entity.HasKey(e => e.IdPersonalAdministrativo)
                    .HasName("PK_PersonalAdministrativo");

                entity.ToTable("PersonalAdministrativo_Cat");

                entity.Property(e => e.IdPersonalAdministrativo).HasColumnName("Id_PersonalAdministrativo");

                entity.Property(e => e.CorreoParticipante)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("Correo_Participante");

                entity.Property(e => e.EstatusPersonalAdministrativo).HasColumnName("Estatus_PersonalAdministrativo");

                entity.Property(e => e.NombreParticipanteOculto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Participante_Oculto");
            });

            modelBuilder.Entity<DiasParametrizablesCat>(entity =>
            {
                entity.HasKey(e => e.IdDiaParametrizable)
                    .HasName("PK_Dias_Parametrizables");

                entity.ToTable("DiasParametrizables_Cat");

                entity.Property(e => e.IdDiaParametrizable).HasColumnName("Id_Dia_Parametrizable");

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.DiasNaturales)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusDiaParametrizable).HasColumnName("Estatus_Dia_Parametrizable");
            });


            modelBuilder.Entity<FinSemanaInhabilCat>(entity =>
            {
                entity.HasKey(e => e.IdFinSemanaInhabil);

                entity.ToTable("FinSemanaInhabil_Cat");

                entity.Property(e => e.IdFinSemanaInhabil).HasColumnName("Id_FinSemanaInhabil");

                entity.Property(e => e.Dia)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<NivelGestionCat>(entity =>
            {
                entity.HasKey(e => e.IdNivelGestion);

                entity.ToTable("NivelGestion_Cat");

                entity.Property(e => e.IdNivelGestion).HasColumnName("Id_NivelGestion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NoticiaCat>(entity =>
            {
                entity.HasKey(e => e.IdNoticia);

                entity.ToTable("Noticia_Cat");

                entity.Property(e => e.IdNoticia).HasColumnName("Id_Noticia");

                entity.Property(e => e.EstatusNoticia).HasColumnName("Estatus_Noticia");

                entity.Property(e => e.HipervinculoNoticia)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Hipervinculo_Noticia");

                entity.Property(e => e.NombreImagen)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Imagen");

                entity.Property(e => e.NombreImagenLimpio)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Imagen_Limpio");

                entity.Property(e => e.ResumenNoticia)
                    .IsRequired()
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("Resumen_Noticia");

                entity.Property(e => e.TituloNoticia)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Titulo_Noticia");
            });


            modelBuilder.Entity<PerfilCargo>(entity =>
            {
                entity.HasKey(e => e.IdPerfilCargo)
                    .HasName("PK__Perfil__2CDD94197D0DCAAB");

                entity.ToTable("Perfil_Cargo");

                entity.Property(e => e.IdPerfilCargo).HasColumnName("Id_Perfil_Cargo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EsCargo).HasColumnName("Es_Cargo");

                entity.Property(e => e.EstatusPerfil).HasColumnName("Estatus_Perfil");

                entity.Property(e => e.OrdenCargo).HasColumnName("Orden_Cargo");
            });

            modelBuilder.Entity<TipoBaja>(entity =>
            {
                entity.HasKey(e => e.IdTipoBaja);

                entity.ToTable("Tipo_Baja");

                entity.Property(e => e.IdTipoBaja).HasColumnName("Id_Tipo_Baja");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusTipoBaja).HasColumnName("Estatus_Tipo_Baja");
            });

            modelBuilder.Entity<PersonaSolicitudHist>(entity =>
            {
                entity.HasKey(e => e.IdPersonaSolicitud)
                    .HasName("PK_Persona_Solicitud");

                entity.ToTable("Persona_Solicitud_Hist");

                entity.Property(e => e.IdPersonaSolicitud).HasColumnName("Id_Persona_Solicitud");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_Materno");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_Paterno");

                entity.Property(e => e.Aperiodo).HasColumnName("APeriodo");

                entity.Property(e => e.Calle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cif).HasColumnName("CIF");

                entity.Property(e => e.CodigoPostal).HasColumnName("Codigo_Postal");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoPersonal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Correo_Personal");

                entity.Property(e => e.CuentaMexicana)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cuenta_Mexicana");

                entity.Property(e => e.Curp)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("CURP");

                entity.Property(e => e.Curriculum)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusNivelDirigencial).HasColumnName("Estatus_Nivel_Dirigencial");

                entity.Property(e => e.EstatusPersonSolicitud).HasColumnName("Estatus_Person_Solicitud");

                entity.Property(e => e.EstatusPersona).HasColumnName("Estatus_Persona");

                entity.Property(e => e.Expediente)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Baja");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Ingreso");

                entity.Property(e => e.FechaIngresoNivel)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Ingreso_Nivel");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.FinPeriodo).HasColumnName("Fin_Periodo");

                entity.Property(e => e.IdCargo).HasColumnName("Id_Cargo");

                entity.Property(e => e.IdCondicionIngreso).HasColumnName("Id_condicion_Ingreso");

                entity.Property(e => e.IdDirigente).HasColumnName("Id_Dirigente");

                entity.Property(e => e.IdEscolaridad).HasColumnName("Id_Escolaridad");

                entity.Property(e => e.IdEstadoCivil).HasColumnName("Id_Estado_Civil");

                entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");

                entity.Property(e => e.IdNivelDirigencialCat).HasColumnName("Id_Nivel_DirigencialCat");

                entity.Property(e => e.IdOficio).HasColumnName("Id_Oficio");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.IdPlaza).HasColumnName("Id_Plaza");

                entity.Property(e => e.IdProfesion).HasColumnName("Id_Profesion");

                entity.Property(e => e.IdRepresententanteCargoCat).HasColumnName("Id_Represententante_Cargo_Cat");

                entity.Property(e => e.IdSolicitud).HasColumnName("Id_Solicitud");

                entity.Property(e => e.IdSubUnidadOperativa).HasColumnName("Id_SubUnidad_Operativa");

                entity.Property(e => e.IdSucursal).HasColumnName("Id_Sucursal");

                entity.Property(e => e.IdTipoPersona).HasColumnName("Id_Tipo_Persona");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePersona)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Persona");

                entity.Property(e => e.NumeroInterior)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Interior");

                entity.Property(e => e.Participacion)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.Periodo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Plaza)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("RFC");

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallePlantillaOrdenDia>(entity =>
            {
                entity.HasKey(e => e.IdDetallePlantillaOrdenDia);

                entity.ToTable("Detalle_Plantilla_Orden_Dia");

                entity.Property(e => e.IdDetallePlantillaOrdenDia).HasColumnName("Id_Detalle_Plantilla_Orden_Dia");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IdConsecutivoPadre).HasColumnName("Id_Consecutivo_Padre");

                entity.Property(e => e.IdPadre).HasColumnName("Id_Padre");

                entity.Property(e => e.IdPlantillaOrdenDia).HasColumnName("Id_Plantilla_Orden_Dia");

                entity.Property(e => e.Indice)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlantillaOrdenDia>(entity =>
            {
                entity.HasKey(e => e.IdPlantillaOrdenDia);

                entity.ToTable("Plantilla_Orden_Dia");

                entity.Property(e => e.IdPlantillaOrdenDia).HasColumnName("Id_Plantilla_Orden_Dia");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusPlantillaOrdenDia).HasColumnName("Estatus_Plantilla_Orden_Dia");

                entity.Property(e => e.IdTipoJunta).HasColumnName("Id_Tipo_Junta");
            });

            modelBuilder.Entity<Convocatorium>(entity =>
            {
                entity.HasKey(e => e.IdConvocatoria);

                entity.Property(e => e.IdConvocatoria).HasColumnName("Id_Convocatoria");

                entity.Property(e => e.Convocatoria).IsUnicode(false);

                entity.Property(e => e.EstatusConvocatoria).HasColumnName("Estatus_Convocatoria");


                entity.Property(e => e.IdModalidad).HasColumnName("Id_Modalidad");

                entity.Property(e => e.IdOrdenDia).HasColumnName("Id_OrdenDia");

                entity.Property(e => e.IdOrgano).HasColumnName("Id_Organo");


                entity.Property(e => e.Ubicacion)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<RelMeetingAsistente>(entity =>
            {
                entity.ToTable("Rel_MeetingAsistentes");


            });

            modelBuilder.Entity<RelMeetingConvocatorium>(entity =>
            {
                entity.ToTable("Rel_MeetingConvocatoria");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.HoraFin).HasColumnName("Hora_Fin");

                entity.Property(e => e.HoraInicio).HasColumnName("Hora_Inicio");


                entity.Property(e => e.JoinWebUrl)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<RelMeetingOrdenDium>(entity =>
           {
               entity.HasKey(e => e.IdRelMeetingOrdenDia);

               entity.ToTable("Rel_Meeting_Orden_Dia");

               entity.Property(e => e.IdRelMeetingOrdenDia).HasColumnName("Id_Rel_Meeting_Orden_Dia");

               entity.Property(e => e.Descripcion)
                   .HasMaxLength(300)
                   .IsUnicode(false);

               entity.Property(e => e.IdConsecutivoPadre).HasColumnName("Id_Consecutivo_Padre");

               entity.Property(e => e.IdPadre).HasColumnName("Id_Padre");

               entity.Property(e => e.IdPlantillaOrdenDia).HasColumnName("Id_Plantilla_Orden_Dia");

               entity.Property(e => e.Indice)
                   .HasMaxLength(50)
                   .IsUnicode(false);
           });

            modelBuilder.Entity<NivelDirigencialCat>(entity =>
            {
                entity.HasKey(e => e.IdNivelDirigencialCat);

                entity.ToTable("Nivel_Dirigencial_Cat");

                entity.Property(e => e.IdNivelDirigencialCat).HasColumnName("Id_Nivel_Dirigencial_cat");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<NivelDirigencial>(entity =>
            {
                entity.HasKey(e => e.IdNivelDirigencial);

                entity.ToTable("Nivel_Dirigencial");

                entity.Property(e => e.IdNivelDirigencial).HasColumnName("Id_Nivel_Dirigencial");

                entity.Property(e => e.Aperiodo).HasColumnName("APeriodo");

                entity.Property(e => e.EstatusNivelDirigencial).HasColumnName("Estatus_Nivel_Dirigencial");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Ingreso");

                entity.Property(e => e.FinPeriodo).HasColumnName("Fin_Periodo");

                entity.Property(e => e.IdCondicionIngreso).HasColumnName("Id_condicion_Ingreso");

                entity.Property(e => e.IdNivelDirigencialCat).HasColumnName("Id_Nivel_DirigencialCat");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.Periodo)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnvioCorreo>(entity =>
            {
                entity.Property(e => e.Asunto)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Destinatario)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEnvio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mensaje).IsUnicode(false);
            });

            modelBuilder.Entity<RelMeetingAutorizacion>(entity =>
            {
                entity.ToTable("Rel_MeetingAutorizacion");

                entity.Property(e => e.CorreoAutoriza)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.FechaAutorizacion)
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("(getdate())");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
