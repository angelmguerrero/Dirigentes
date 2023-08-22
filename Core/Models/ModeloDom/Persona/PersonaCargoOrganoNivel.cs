namespace CPM.PlataformaDirigentes.Models.ModeloDom.Persona
{
    public class PersonaCargoOrganoNivel
    {
        //persona
        public int IdPersona { get; set; }
        public string? NombrePersona { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public bool? EstatusPersona { get; set; }
        public int IdTipoPersona { get; set; }

        public string? DescripciontipoPersona { get; set; }
        public int? IdCargo { get; set; }
        public string? DescripcionCargo { get; set; }
        public int? IdSubUnidadOperativa { get; set; }
        public string? DescripcionUnidadOperativa { get; set; }
        public int? IdGenero { get; set; }
        public string? DescripcionGenero { get; set; }
        public int? IdEstadoCivil { get; set; }
        public string DescripcionEstadoCivil { get; set; }
        public string CorreoPersonal { get; set; }
        public int? IdOficio { get; set; }
        public string? DescripcionIdOficio { get; set; }
        public int? IdEscolaridad { get; set; }
        public string? DescripcionEscolaridad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Rfc { get; set; }
        public string? Curp { get; set; }
        public int? Edad { get; set; }
        public int? CodigoPostal { get; set; }
        public string Celular { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? Cif { get; set; }
        public bool Dirigente { get; set; }
        public int? IdDirigente { get; set; }
        public int IdRepresententanteCargoCat { get; set; }
        public string? DescripcionRepresententanteCargoCat { get; set; }

        public int IdProfesion { get; set; }
        public string? DescripcionProfesion { get; set; }
        public string? DescripcionClasificacion { get; set; }

        public string? NombrePersonaCompleto { get; set; }
        public int? IdPlaza { get; set; }
        public string? Plaza { get; set; }
        public string? Sucursal { get; set; }
        public string? Genero { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Calle { get; set; }
        public string? NumeroInterior { get; set; }
        public string? Colonia { get; set; }
        public string? Estado { get; set; }
        public string? Municipio { get; set; }
        public string? CuentaMexicana { get; set; }
        public string? Participacion { get; set; }


        //cargo x organo
        public int IdCargoOrgano { get; set; }

        public int IdOrgano { get; set; }

        public string? DescripcionOrgano { get; set; }

        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int Suplente { get; set; }

        public bool? EstatusCargoOrgano { get; set; }
        //NivelDirigencial
        public int? IdNivelDirigencialCat { get; set; }
        public string? NivelDirigencialCatDescrip { get; set; }
        public bool? EstatusNivelDirigencial { get; set; }
        public DateTime? FechaIngresoNivel { get; set; }
        public int? FinPeriodo { get; set; }
        public string? Periodo { get; set; }
        public int? Aperiodo { get; set; }
        public int? IdCondicionIngreso { get; set; }
        public string? CondicionIngresoDescrip { get; set; }
        public int? Antiguedad { get; set; }


        //perfil

        public int IdPerfilCargo { get; set; }
        public string DescripcionPerfil { get; set; }
        public bool? EstatusPerfil { get; set; }
        public int? OrdenCargo { get; set; }
        public bool? EsCargo { get; set; }
    }
}
