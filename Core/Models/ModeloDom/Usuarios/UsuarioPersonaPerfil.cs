namespace CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios
{
    public class UsuarioPersonaPerfil
    {

        //usuario
        public int IdUsuario { get; set; }
        public string? UsuarioDa { get; set; }
        public string? Password { get; set; }
        public string? CorreoAcceso { get; set; }
        public bool? EstatusUsuario { get; set; }
        public int? IdPersona { get; set; }
        public int? IdPerfil { get; set; }
        //persona
        public string? NombrePersona { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public bool? EstatusPersona { get; set; }
        public int IdTipoPersona { get; set; }
        public int? IdCargo { get; set; }
        public int? IdSubUnidadOperativa { get; set; }
        public int? IdGenero { get; set; }
        public int? IdEstadoCivil { get; set; }
        public int? IdOficio { get; set; }
        public int? IdEscolaridad { get; set; }
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
        public int IdRepresententanteCargoCat { get; set; }
        public int IdOrgano { get; set; }
        public int IdProfesion { get; set; }

        public string? NombrePersonaCompleto { get; set; }
        public string? Plaza { get; set; }
        public string? Sucursal { get; set; }
        public string? Genero { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Calle { get; set; }
        public string? NumeroInterior { get; set; }
        public string? Colonia { get; set; }
        public string? Estado { get; set; }
        public string? Municipio { get; set; }
        public int? IdDirigente { get; set; }

        public int? PlazaId { get; set; }
        public int SucursalId { get; set; }

        //perfil
        public string? Perfil { get; set; } // perfil
        public bool? EstatusPerfil { get; set; } // perfil

        public string? Email { get; set; } // perfil
        public string? CuentaMexicana { get; set; } // perfil
    }
}
