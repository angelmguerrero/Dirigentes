namespace CPMPlataformaDirigentes.Models.ModelsConsulta
{
    public partial class CifInfgen

    {

        public int CveSucursal { get; set; }

        public string NoSocio { get; set; }
        public string Estatus { get; set; }
        public string TipPersona { get; set; }
        public string TipSocio { get; set; }
        public string NoImss { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombre { get; set; }
        public string SdoNombre { get; set; }
        public string Calle { get; set; }
        public string NumeroCasa { get; set; }
        public string NumInterior { get; set; }
        public string UnidadHab { get; set; }
        public string EntreCalles { get; set; }
        public decimal? CveCol { get; set; }
        public decimal? CveCiudad { get; set; }
        public string CveEstado { get; set; }
        public string CveSector { get; set; }
        public string Poblacion { get; set; }
        public string Ciudad { get; set; }
        public int? CveEmpleo { get; set; }
        public string Sexo { get; set; }
        public int? NoDependientes { get; set; }
        public decimal? FecNac { get; set; }
        public int? CveProfesion { get; set; }
        public string FecAct { get; set; }
        public string EdoCivil { get; set; }
        public string FecUltMt { get; set; }
        public string FecAlta { get; set; }
        public DateTime? FecNacD { get; set; }
        public DateTime? FecActD { get; set; }
        public DateTime? FecUltMtD { get; set; }
        public DateTime? FecAltaD { get; set; }
        public int? NoCreditos { get; set; }
        public string CodigoPostal { get; set; }
        public decimal? Telefono { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        public string ClaveMedioPorEnterado { get; set; }
        public string ClaveMotivoIngreso { get; set; }
        public int? ClaveEsSocio { get; set; }
        public string ClaveTipoVivienda { get; set; }
        public string ClaveEstatusPropietarioVivienda { get; set; }
        public DateTime? FechaVivienda { get; set; }
        public decimal? IngresoMensual { get; set; }
        public DateTime? FechaAperturaParteSocial { get; set; }
        public DateTime? FechaUltimoMovParteSocial { get; set; }
        public byte? IdTipoNivelAcademico { get; set; }
        public int? CveSucursalAperturaCuenta { get; set; }
        public short? IdPreferenciaContacto { get; set; }
        public bool? PermitirContactoTelefono { get; set; }
        public bool? PermitirContactoEmail { get; set; }
        public bool? PermitirContactoSms { get; set; }
    }
}
