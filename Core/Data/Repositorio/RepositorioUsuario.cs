using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using CPM.PlataformaDirigentes.Models.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private CPMDirigentesPlataformaContext context;
        public RepositorioUsuario()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        }

        public List<UsuarioDom> ObtenerUsuariosPersona()
        {

            var prueba = (from user1 in context.Usuarios
                          join user2 in context.PersonaCats
                          on user1.IdPersona equals user2.IdPersona
                          select new UsuarioDom

                          {
                              IdUsuario = user1.IdUsuario,


                              //      public int IdUsuario { get; set; }
                              //public string? UsuarioDa { get; set; }
                              //public string? Password { get; set; }
                              //public string? CorreoAcceso { get; set; }
                              //public int? EstatusUsuario { get; set; }
                              //public int? IdPersona { get; set; }
                              //public int? IdPerfil { get; set; }
                              //public string? NombrePersona { get; set; }

                          }).ToList();

            return prueba;
        }

        public List<UsuarioPersonaPerfil> ObtenerUsuariosPersonaPerfil()
        {

            var prueba = (from user1 in context.Usuarios
                          join pers1 in context.PersonaCats
                          on user1.IdPersona equals pers1.IdPersona
                          join perf1 in context.PerfilCargos
                          on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                          join gen1 in context.GeneroCats
                          on pers1.IdGenero equals gen1.IdGenero
                          join edo1 in context.EstadoCivilCats
                          on pers1.IdEstadoCivil equals edo1.IdEstadoCivil

                          select new UsuarioPersonaPerfil

                          {
                              IdUsuario = user1.IdUsuario,
                              CorreoAcceso = user1.CorreoAcceso,
                              Perfil = perf1.Descripcion,
                              NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                              EstatusUsuario = user1.EstatusUsuario,
                              UsuarioDa = user1.UsuarioDa,
                              Password = user1.Password,
                              IdPersona = user1.IdPersona,
                              IdPerfil = user1.IdPerfilCargo,
                              NombrePersona = pers1.NombrePersona,
                              ApellidoPaterno = pers1.ApellidoPaterno,
                              ApellidoMaterno = pers1.ApellidoMaterno,
                              EstatusPersona = pers1.EstatusPersona,
                              IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                              IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                              IdGenero = pers1.IdGenero,
                              Genero = gen1.Descripcion,
                              IdEstadoCivil = pers1.IdEstadoCivil,
                              EstadoCivil = edo1.Descripcion,
                              IdOficio = pers1.IdOficio,
                              IdEscolaridad = pers1.IdEscolaridad,
                              FechaNacimiento = pers1.FechaNacimiento,
                              Rfc = pers1.Rfc,
                              Curp = pers1.Curp,
                              Edad = pers1.Edad,
                              CodigoPostal = pers1.CodigoPostal,
                              Celular = pers1.Celular,
                              FechaIngreso = pers1.FechaIngreso,
                              FechaBaja = pers1.FechaBaja,
                              Cif = pers1.Cif,
                              Dirigente = pers1.Dirigente,
                              IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                              // IdOrgano = pers1.IdOrgano,
                              IdProfesion = pers1.IdProfesion,
                              Plaza = pers1.Plaza,
                              Sucursal = pers1.Sucursal,
                              EstatusPerfil = perf1.EstatusPerfil,
                              Calle = pers1.Calle,
                              NumeroInterior = pers1.NumeroInterior,
                              Colonia = pers1.Colonia,
                              Estado = pers1.Estado,
                              Municipio = pers1.Municipio,
                              //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                          }).ToList();

            return prueba;
            //return (List<UsuarioPersonaPerfil>)_usuarioPersonaPerfil;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return context.Usuarios.ToList();
        }

        public bool CrearUsuario(Usuario usuario)
        {
            try
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CrearUsuarioPersonaPerfil(UsuarioPersonaPerfil usuarioPersonaPerfil)
        {
            try
            {
                // checar insert en usuario, persona, perfil

                var result = context.EscolaridadCats.FromSqlRaw<EscolaridadCat>("pa_Obtener_Escolaridad").ToList();

                // var result2 = context.Database.ExecuteSqlRaw("insert into persona(1,2,3) values ()");
                // context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int CrearUsuarioPersonaPerfilNew(UsuarioPersonaPerfil usuarioPersonaPerfil)
        {
            try
            {
                var parameter = new List<SqlParameter>();
                //parameter.Add(new SqlParameter("@ProductName", product.ProductName));
                //parameter.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
                //parameter.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
                //parameter.Add(new SqlParameter("@ProductStock", product.ProductStock));

                // var result = await Task.Run(() => _dbContext.Database
                //.ExecuteSqlRawAsync(@"exec AddNewProduct @ProductName, @ProductDescription, @ProductPrice, @ProductStock", parameter.ToArray()));

                //var result = context.Database.ExecuteSqlRaw("UPDATE Persona_Cat SET Nombre_Persona = 'Another Name'  ");
                // var result = context.Database.ExecuteSqlRaw("UPDATE Persona_Cat SET Nombre_Persona = '" + usuarioPersonaPerfil.ApellidoPaterno + "'");
                //var result = context.Database.ExecuteSqlRaw
                //("insert into persona_cat( Nombre_Persona,Estatus_Persona,Id_Tipo_Persona,Id_Genero,Id_Estado_Civil," +
                //    "Id_Oficio,Id_Escolaridad,Apellido_Paterno,Apellido_Materno ,  Id_Profesion,Dirigente, " +
                //    "Id_Represententante_Cargo_Cat,Id_Organo) values('Maria ',1,1,1,1,1,1, 'PErez','Lopez',1,0,0,0)");
                //return result;
                var idGenero = (from gen in context.GeneroCats
                                where gen.Descripcion == usuarioPersonaPerfil.Genero
                                select new GeneroCat
                                {
                                    IdGenero = gen.IdGenero,

                                }).FirstOrDefault();

                var idEstadoCivil = (from edo in context.EstadoCivilCats
                                     where edo.Descripcion == usuarioPersonaPerfil.EstadoCivil
                                     select new EstadoCivilCat
                                     {
                                         IdEstadoCivil = edo.IdEstadoCivil,
                                     }).FirstOrDefault();

                //var nombre = "Gonzalez";
                //var result = context.Database.ExecuteSqlRaw("pa_i_Insertar_Persona_Cat @p0", nombre);
                var result = context.Database.ExecuteSqlRaw("pa_i_Insertar_Persona_Cat @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27,@p28,@p29,@p30,@p31,@p32,@p33,@p34,@p35,@p36", usuarioPersonaPerfil.NombrePersona,
                        usuarioPersonaPerfil.EstatusPersona == null ? 1 : usuarioPersonaPerfil.EstatusPersona,
                        usuarioPersonaPerfil.IdTipoPersona == 0 ? 1 : usuarioPersonaPerfil.IdTipoPersona,
                        usuarioPersonaPerfil.IdCargo == null ? 1 : usuarioPersonaPerfil.IdCargo,
                        usuarioPersonaPerfil.IdSubUnidadOperativa == null ? 1 : usuarioPersonaPerfil.IdSubUnidadOperativa,
                        //usuarioPersonaPerfil.Genero == "FEMENINO" ? 2 : 1,
                        idGenero.IdGenero == null ? 0 : idGenero.IdGenero,
                        //usuarioPersonaPerfil.IdEstadoCivil == null ? 1 : usuarioPersonaPerfil.EstadoCivil,
                        idEstadoCivil.IdEstadoCivil == null ? 0 : idEstadoCivil.IdEstadoCivil,
                        usuarioPersonaPerfil.IdOficio == null ? 1 : usuarioPersonaPerfil.IdOficio,
                        usuarioPersonaPerfil.IdEscolaridad == null ? 1 : usuarioPersonaPerfil.IdEscolaridad,
                        usuarioPersonaPerfil.ApellidoPaterno,
                        usuarioPersonaPerfil.ApellidoMaterno,
                        usuarioPersonaPerfil.FechaNacimiento,
                        usuarioPersonaPerfil.Rfc,
                        usuarioPersonaPerfil.Curp,
                        usuarioPersonaPerfil.Edad,
                        usuarioPersonaPerfil.CodigoPostal,
                        usuarioPersonaPerfil.Celular,
                        usuarioPersonaPerfil.FechaIngreso,
                        usuarioPersonaPerfil.FechaBaja,
                        usuarioPersonaPerfil.Cif == null ? 1 : usuarioPersonaPerfil.Cif,
                        usuarioPersonaPerfil.Dirigente,
                        usuarioPersonaPerfil.IdRepresententanteCargoCat,
                        // usuarioPersonaPerfil.IdOrgano,
                        usuarioPersonaPerfil.IdProfesion == 0 ? 1 : usuarioPersonaPerfil.IdProfesion,
                        usuarioPersonaPerfil.Calle,
                        usuarioPersonaPerfil.NumeroInterior,
                        usuarioPersonaPerfil.Colonia,
                        usuarioPersonaPerfil.Estado,
                        usuarioPersonaPerfil.Municipio,
                        usuarioPersonaPerfil.CorreoAcceso,
                        usuarioPersonaPerfil.IdDirigente,
                        usuarioPersonaPerfil.Email,
                        usuarioPersonaPerfil.IdPerfil,
                        usuarioPersonaPerfil.Plaza,
                        usuarioPersonaPerfil.Sucursal,
                        usuarioPersonaPerfil.CuentaMexicana,
                        usuarioPersonaPerfil.PlazaId,
                        usuarioPersonaPerfil.SucursalId
);
                return result;


            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int ActualizarUsuarioPersonaPerfilNew(UsuarioPersonaPerfil usuarioPersonaPerfil)
        {
            try
            {


                var result = context.Database.ExecuteSqlRaw("pa_u_Actualizar_Persona_Cat @p0,@p1,@p2,@p3", usuarioPersonaPerfil.IdUsuario,
                        usuarioPersonaPerfil.CorreoAcceso,
                        usuarioPersonaPerfil.IdPerfil,
                        usuarioPersonaPerfil.EstatusUsuario
);
                return result;


            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int EliminarUsuarioPersonaPerfilNew(int idUsuario)
        {
            try
            {


                var result = context.Database.ExecuteSqlRaw("pa_d_Eliminar_Persona_Cat @p0", idUsuario
);
                return result;


            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool ModificarUsuario(Usuario usuario)
        {
            var _usuario = context.Usuarios.Where(x => x.IdUsuario == usuario.IdUsuario).SingleOrDefault();
            if (_usuario == null)
                return false;

            _usuario.IdUsuario = usuario.IdUsuario;
            _usuario.CorreoAcceso = usuario.CorreoAcceso;
            _usuario.IdPerfilCargo = usuario.IdPerfilCargo;
            _usuario.EstatusUsuario = usuario.EstatusUsuario;
            //_usuario.OrdenUsuario = usuario.OrdenUsuario;
            context.SaveChanges();

            return true;
        }

        public bool DesactivarUsuario(int idUsuario)
        {
            var _usuario = context.Usuarios.Where(x => x.IdUsuario == idUsuario).SingleOrDefault();
            if (_usuario == null)
                return false;

            _usuario.EstatusUsuario = false;
            context.SaveChanges();
            return true;
        }

        public Usuario UsuariobyId(int idUsuario)
        {
            var usuario = context.Usuarios.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();

            if (usuario == null)
                return null;
            else
                return usuario;

        }

        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyId(int idUsuario)
        {
            var prueba = (from user1 in context.Usuarios
                          join pers1 in context.PersonaCats
                          on user1.IdPersona equals pers1.IdPersona
                          join perf1 in context.PerfilCargos
                          on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                          join gen1 in context.GeneroCats
                          on pers1.IdGenero equals gen1.IdGenero
                          join edo1 in context.EstadoCivilCats
                          on pers1.IdEstadoCivil equals edo1.IdEstadoCivil
                          where user1.IdUsuario == idUsuario

                          select new UsuarioPersonaPerfil

                          {
                              IdUsuario = user1.IdUsuario,
                              CorreoAcceso = user1.CorreoAcceso,
                              Perfil = perf1.Descripcion,
                              NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                              EstatusUsuario = user1.EstatusUsuario,
                              UsuarioDa = user1.UsuarioDa,
                              Password = user1.Password,
                              IdPersona = user1.IdPersona,
                              IdPerfil = user1.IdPerfilCargo,
                              NombrePersona = pers1.NombrePersona,
                              ApellidoPaterno = pers1.ApellidoPaterno,
                              ApellidoMaterno = pers1.ApellidoMaterno,
                              EstatusPersona = pers1.EstatusPersona,
                              IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                              IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                              IdGenero = pers1.IdGenero,
                              Genero = gen1.Descripcion,
                              IdEstadoCivil = pers1.IdEstadoCivil,
                              EstadoCivil = edo1.Descripcion,
                              IdOficio = pers1.IdOficio,
                              IdEscolaridad = pers1.IdEscolaridad,
                              FechaNacimiento = pers1.FechaNacimiento,
                              Rfc = pers1.Rfc,
                              Curp = pers1.Curp,
                              Edad = pers1.Edad,
                              CodigoPostal = pers1.CodigoPostal,
                              Celular = pers1.Celular,
                              FechaIngreso = pers1.FechaIngreso,
                              FechaBaja = pers1.FechaBaja,
                              Cif = pers1.Cif,
                              Dirigente = pers1.Dirigente,
                              IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                              // IdOrgano = pers1.IdOrgano,
                              IdProfesion = pers1.IdProfesion,
                              Plaza = pers1.Plaza,
                              Sucursal = pers1.Sucursal,
                              EstatusPerfil = perf1.EstatusPerfil,
                              Calle = pers1.Calle,
                              NumeroInterior = pers1.NumeroInterior,
                              Colonia = pers1.Colonia,
                              Estado = pers1.Estado,
                              Municipio = pers1.Municipio,
                              IdDirigente = pers1.IdDirigente,
                              Email = pers1.CorreoPersonal,
                              CuentaMexicana = pers1.CuentaMexicana
                              //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                          }).FirstOrDefault();

            return prueba;

        }

        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCif(int cif)
        {
            var prueba = (from user1 in context.Usuarios
                          join pers1 in context.PersonaCats
                          on user1.IdPersona equals pers1.IdPersona
                          join perf1 in context.PerfilCargos
                          on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                          join gen1 in context.GeneroCats
                          on pers1.IdGenero equals gen1.IdGenero
                          join edo1 in context.EstadoCivilCats
                          on pers1.IdEstadoCivil equals edo1.IdEstadoCivil
                          where pers1.Cif == cif

                          select new UsuarioPersonaPerfil

                          {
                              IdUsuario = user1.IdUsuario,
                              CorreoAcceso = user1.CorreoAcceso,
                              Perfil = perf1.Descripcion,
                              NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                              EstatusUsuario = user1.EstatusUsuario,
                              UsuarioDa = user1.UsuarioDa,
                              Password = user1.Password,
                              IdPersona = user1.IdPersona,
                              IdPerfil = user1.IdPerfilCargo,
                              NombrePersona = pers1.NombrePersona,
                              ApellidoPaterno = pers1.ApellidoPaterno,
                              ApellidoMaterno = pers1.ApellidoMaterno,
                              EstatusPersona = pers1.EstatusPersona,
                              IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                              IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                              IdGenero = pers1.IdGenero,
                              Genero = gen1.Descripcion,
                              IdEstadoCivil = pers1.IdEstadoCivil,
                              EstadoCivil = edo1.Descripcion,
                              IdOficio = pers1.IdOficio,
                              IdEscolaridad = pers1.IdEscolaridad,
                              FechaNacimiento = pers1.FechaNacimiento,
                              Rfc = pers1.Rfc,
                              Curp = pers1.Curp,
                              Edad = pers1.Edad,
                              CodigoPostal = pers1.CodigoPostal,
                              Celular = pers1.Celular,
                              FechaIngreso = pers1.FechaIngreso,
                              FechaBaja = pers1.FechaBaja,
                              Cif = pers1.Cif,
                              Dirigente = pers1.Dirigente,
                              IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                              // IdOrgano = pers1.IdOrgano,
                              IdProfesion = pers1.IdProfesion,
                              Plaza = pers1.Plaza,
                              Sucursal = pers1.Sucursal,
                              EstatusPerfil = perf1.EstatusPerfil,
                              Calle = pers1.Calle,
                              NumeroInterior = pers1.NumeroInterior,
                              Colonia = pers1.Colonia,
                              Estado = pers1.Estado,
                              Municipio = pers1.Municipio,
                              IdDirigente = pers1.IdDirigente,
                              Email = pers1.CorreoPersonal,
                              CuentaMexicana = pers1.CuentaMexicana
                              //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                          }).FirstOrDefault();

            if (prueba == null)
            {
                var pruebaVacia = new UsuarioPersonaPerfil();
                pruebaVacia.Cif = 0;

                return pruebaVacia;
            }
            else { return prueba; }
            //return prueba;

        }

        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCorreoAcceso(string correoAcceso)
        {
            var prueba = (from user1 in context.Usuarios
                          join pers1 in context.PersonaCats
                          on user1.IdPersona equals pers1.IdPersona
                          join perf1 in context.PerfilCargos
                          on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                          join gen1 in context.GeneroCats
                          on pers1.IdGenero equals gen1.IdGenero
                          join edo1 in context.EstadoCivilCats
                          on pers1.IdEstadoCivil equals edo1.IdEstadoCivil
                          where user1.CorreoAcceso == correoAcceso

                          select new UsuarioPersonaPerfil

                          {
                              IdUsuario = user1.IdUsuario,
                              CorreoAcceso = user1.CorreoAcceso,
                              Perfil = perf1.Descripcion,
                              NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                              EstatusUsuario = user1.EstatusUsuario,
                              UsuarioDa = user1.UsuarioDa,
                              Password = user1.Password,
                              IdPersona = user1.IdPersona,
                              IdPerfil = user1.IdPerfilCargo,
                              NombrePersona = pers1.NombrePersona,
                              ApellidoPaterno = pers1.ApellidoPaterno,
                              ApellidoMaterno = pers1.ApellidoMaterno,
                              EstatusPersona = pers1.EstatusPersona,
                              IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                              IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                              IdGenero = pers1.IdGenero,
                              Genero = gen1.Descripcion,
                              IdEstadoCivil = pers1.IdEstadoCivil,
                              EstadoCivil = edo1.Descripcion,
                              IdOficio = pers1.IdOficio,
                              IdEscolaridad = pers1.IdEscolaridad,
                              FechaNacimiento = pers1.FechaNacimiento,
                              Rfc = pers1.Rfc,
                              Curp = pers1.Curp,
                              Edad = pers1.Edad,
                              CodigoPostal = pers1.CodigoPostal,
                              Celular = pers1.Celular,
                              FechaIngreso = pers1.FechaIngreso,
                              FechaBaja = pers1.FechaBaja,
                              Cif = pers1.Cif,
                              Dirigente = pers1.Dirigente,
                              IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                              // IdOrgano = pers1.IdOrgano,
                              IdProfesion = pers1.IdProfesion,
                              Plaza = pers1.Plaza,
                              Sucursal = pers1.Sucursal,
                              EstatusPerfil = perf1.EstatusPerfil,
                              Calle = pers1.Calle,
                              NumeroInterior = pers1.NumeroInterior,
                              Colonia = pers1.Colonia,
                              Estado = pers1.Estado,
                              Municipio = pers1.Municipio,
                              IdDirigente = pers1.IdDirigente,
                              Email = pers1.CorreoPersonal,
                              CuentaMexicana = pers1.CuentaMexicana
                              //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                          }).FirstOrDefault();

            if (prueba == null)
            {
                var pruebaVacia = new UsuarioPersonaPerfil();
                pruebaVacia.Cif = 0;

                return pruebaVacia;
            }
            else { return prueba; }
            //return prueba;

        }


        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCifPadron(int cifUsuario)
        {
            var prueba = (from user1 in context.Usuarios
                          join pers1 in context.PersonaCats
                          on user1.IdPersona equals pers1.IdPersona
                          join perf1 in context.PerfilCargos
                          on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                          join gen1 in context.GeneroCats
                          on pers1.IdGenero equals gen1.IdGenero
                          join edo1 in context.EstadoCivilCats
                          on pers1.IdEstadoCivil equals edo1.IdEstadoCivil
                          where pers1.Cif == cifUsuario

                          select new UsuarioPersonaPerfil

                          {
                              IdUsuario = user1.IdUsuario,
                              CorreoAcceso = user1.CorreoAcceso,
                              Perfil = perf1.Descripcion,
                              NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                              EstatusUsuario = user1.EstatusUsuario,
                              UsuarioDa = user1.UsuarioDa,
                              Password = user1.Password,
                              IdPersona = user1.IdPersona,
                              IdPerfil = user1.IdPerfilCargo,
                              NombrePersona = pers1.NombrePersona,
                              ApellidoPaterno = pers1.ApellidoPaterno,
                              ApellidoMaterno = pers1.ApellidoMaterno,
                              EstatusPersona = pers1.EstatusPersona,
                              IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                              IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                              IdGenero = pers1.IdGenero,
                              Genero = gen1.Descripcion,
                              IdEstadoCivil = pers1.IdEstadoCivil,
                              EstadoCivil = edo1.Descripcion,
                              IdOficio = pers1.IdOficio,
                              IdEscolaridad = pers1.IdEscolaridad,
                              FechaNacimiento = pers1.FechaNacimiento,
                              Rfc = pers1.Rfc,
                              Curp = pers1.Curp,
                              Edad = pers1.Edad,
                              CodigoPostal = pers1.CodigoPostal,
                              Celular = pers1.Celular,
                              FechaIngreso = pers1.FechaIngreso,
                              FechaBaja = pers1.FechaBaja,
                              Cif = pers1.Cif,
                              Dirigente = pers1.Dirigente,
                              IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                              // IdOrgano = pers1.IdOrgano,
                              IdProfesion = pers1.IdProfesion,
                              Plaza = pers1.Plaza,
                              PlazaId = pers1.IdPlaza,
                              Sucursal = pers1.Sucursal,
                              SucursalId = (int)pers1.IdSucursal,
                              EstatusPerfil = perf1.EstatusPerfil,
                              Calle = pers1.Calle,
                              NumeroInterior = pers1.NumeroInterior,
                              Colonia = pers1.Colonia,
                              Estado = pers1.Estado,
                              Municipio = pers1.Municipio,
                              IdDirigente = pers1.IdDirigente,
                              CuentaMexicana = pers1.CuentaMexicana,
                              //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                          }).FirstOrDefault();

            return prueba;
        }

        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyNombrePadron(string NombreUsuario)
        {
            var usuarioPersona = (from user1 in context.Usuarios
                                  join pers1 in context.PersonaCats
                                  on user1.IdPersona equals pers1.IdPersona
                                  join perf1 in context.PerfilCargos
                                  on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                                  join gen1 in context.GeneroCats
                                  on pers1.IdGenero equals gen1.IdGenero
                                  join edo1 in context.EstadoCivilCats
                                  on pers1.IdEstadoCivil equals edo1.IdEstadoCivil
                                  where
                                  (pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno + " " + pers1.NombrePersona).Contains(NombreUsuario)

                                  select new UsuarioPersonaPerfil

                                  {
                                      IdUsuario = user1.IdUsuario,
                                      CorreoAcceso = user1.CorreoAcceso,
                                      Perfil = perf1.Descripcion,
                                      NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                                      EstatusUsuario = user1.EstatusUsuario,
                                      UsuarioDa = user1.UsuarioDa,
                                      Password = user1.Password,
                                      IdPersona = user1.IdPersona,
                                      IdPerfil = user1.IdPerfilCargo,
                                      NombrePersona = pers1.NombrePersona,
                                      ApellidoPaterno = pers1.ApellidoPaterno,
                                      ApellidoMaterno = pers1.ApellidoMaterno,
                                      EstatusPersona = pers1.EstatusPersona,
                                      IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                                      IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                                      IdGenero = pers1.IdGenero,
                                      Genero = gen1.Descripcion,
                                      IdEstadoCivil = pers1.IdEstadoCivil,
                                      EstadoCivil = edo1.Descripcion,
                                      IdOficio = pers1.IdOficio,
                                      IdEscolaridad = pers1.IdEscolaridad,
                                      FechaNacimiento = pers1.FechaNacimiento,
                                      Rfc = pers1.Rfc,
                                      Curp = pers1.Curp,
                                      Edad = pers1.Edad,
                                      CodigoPostal = pers1.CodigoPostal,
                                      Celular = pers1.Celular,
                                      FechaIngreso = pers1.FechaIngreso,
                                      FechaBaja = pers1.FechaBaja,
                                      Cif = pers1.Cif,
                                      Dirigente = pers1.Dirigente,
                                      IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                                      // IdOrgano = pers1.IdOrgano,
                                      IdProfesion = pers1.IdProfesion,
                                      Plaza = pers1.Plaza,
                                      PlazaId = pers1.IdPlaza,
                                      Sucursal = pers1.Sucursal,
                                      EstatusPerfil = perf1.EstatusPerfil,
                                      Calle = pers1.Calle,
                                      NumeroInterior = pers1.NumeroInterior,
                                      Colonia = pers1.Colonia,
                                      Estado = pers1.Estado,
                                      Municipio = pers1.Municipio,
                                      IdDirigente = pers1.IdDirigente,
                                      CuentaMexicana = pers1.CuentaMexicana,
                                      //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                                  }).First();
            if (usuarioPersona == null)
                return null;

            else
                return usuarioPersona;

        }



        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCuentaMex(string CuentaMexUsuario)
        {
            var prueba = (from user1 in context.Usuarios
                          join pers1 in context.PersonaCats
                          on user1.IdPersona equals pers1.IdPersona
                          join perf1 in context.PerfilCargos
                          on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                          join gen1 in context.GeneroCats
                          on pers1.IdGenero equals gen1.IdGenero
                          join edo1 in context.EstadoCivilCats
                          on pers1.IdEstadoCivil equals edo1.IdEstadoCivil
                          where pers1.CuentaMexicana == CuentaMexUsuario

                          select new UsuarioPersonaPerfil

                          {
                              IdUsuario = user1.IdUsuario,
                              CorreoAcceso = user1.CorreoAcceso,
                              Perfil = perf1.Descripcion,
                              NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                              EstatusUsuario = user1.EstatusUsuario,
                              UsuarioDa = user1.UsuarioDa,
                              Password = user1.Password,
                              IdPersona = user1.IdPersona,
                              IdPerfil = user1.IdPerfilCargo,
                              NombrePersona = pers1.NombrePersona,
                              ApellidoPaterno = pers1.ApellidoPaterno,
                              ApellidoMaterno = pers1.ApellidoMaterno,
                              EstatusPersona = pers1.EstatusPersona,
                              IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                              IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                              IdGenero = pers1.IdGenero,
                              Genero = gen1.Descripcion,
                              IdEstadoCivil = pers1.IdEstadoCivil,
                              EstadoCivil = edo1.Descripcion,
                              IdOficio = pers1.IdOficio,
                              IdEscolaridad = pers1.IdEscolaridad,
                              FechaNacimiento = pers1.FechaNacimiento,
                              Rfc = pers1.Rfc,
                              Curp = pers1.Curp,
                              Edad = pers1.Edad,
                              CodigoPostal = pers1.CodigoPostal,
                              Celular = pers1.Celular,
                              FechaIngreso = pers1.FechaIngreso,
                              FechaBaja = pers1.FechaBaja,
                              Cif = pers1.Cif,
                              Dirigente = pers1.Dirigente,
                              IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                              // IdOrgano = pers1.IdOrgano,
                              IdProfesion = pers1.IdProfesion,
                              Plaza = pers1.Plaza,
                              PlazaId = pers1.IdPlaza,
                              Sucursal = pers1.Sucursal,
                              EstatusPerfil = perf1.EstatusPerfil,
                              Calle = pers1.Calle,
                              NumeroInterior = pers1.NumeroInterior,
                              Colonia = pers1.Colonia,
                              Estado = pers1.Estado,
                              Municipio = pers1.Municipio,
                              IdDirigente = pers1.IdDirigente,
                              CuentaMexicana = pers1.CuentaMexicana,
                              //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                          }).FirstOrDefault();

            return prueba;
        }
        public List<string> UsuarioPerfiles(string correoUsuario)
        {
            List<string> lstPermisos = new List<string>();


            var lstPerfiles = (from user in context.Usuarios where user.CorreoAcceso.ToUpper() == correoUsuario.ToUpper() select user.IdPerfilCargo).SingleOrDefault();


            var lstCargos = (from cargos in context.CargoxOrganos
                             where
                              cargos.IdPersona == (from user in context.Usuarios where user.CorreoAcceso.ToUpper() == correoUsuario.ToUpper() select user.IdPersona).SingleOrDefault()
                             select cargos.IdPerfilCargo).ToList();


            var nomPerfil = (from perfil in context.PerfilCargos where perfil.EstatusPerfil == true && perfil.IdPerfilCargo == lstPerfiles select perfil.Descripcion).SingleOrDefault();
            if (nomPerfil != null || nomPerfil != "")
            {
                lstPermisos.Add(nomPerfil);
            }


            foreach (var item in lstCargos)
            {
                var nombrePerfil = (from perfil in context.PerfilCargos where perfil.EstatusPerfil == true && perfil.IdPerfilCargo == item select perfil.Descripcion).SingleOrDefault();
                if (nombrePerfil != null || nombrePerfil != "")
                {
                    lstPermisos.Add(nombrePerfil);
                }
            }

            return lstPermisos;

        }
        public UsuarioPersonaPerfil UsuarioPersonaPerfilPermisoSolicitudDirigencialbyCorreo(string correo)
        {
            // Se mostrarán en el combo de responsables plaza SOLO los que tengan permiso en el submodulo con id 28
            // Padrón de dirigentes(solicitudes) y que los permisos sean Todos o Autorizar
            var prueba = (from user1 in context.Usuarios
                          join pers1 in context.PersonaCats
                          on user1.IdPersona equals pers1.IdPersona
                          join perf1 in context.PerfilCargos
                          on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                          join perm1 in context.Permisos
                          on perf1.IdPerfilCargo equals perm1.IdPerfilCargo
                          join sub in context.SubModuloCats
                          on perm1.IdSubModulo equals sub.IdSubModulo

                          where sub.IdSubModulo == 28
                          && (perm1.Todos == true || perm1.Autorizar == true)
                          && user1.CorreoAcceso == correo
                          select new UsuarioPersonaPerfil

                          {
                              IdUsuario = user1.IdUsuario,
                              CorreoAcceso = user1.CorreoAcceso,
                              Perfil = perf1.Descripcion,
                              NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                              EstatusUsuario = user1.EstatusUsuario,
                              UsuarioDa = user1.UsuarioDa,
                              Password = user1.Password,
                              IdPersona = user1.IdPersona,
                              IdPerfil = user1.IdPerfilCargo,
                              NombrePersona = pers1.NombrePersona,
                              ApellidoPaterno = pers1.ApellidoPaterno,
                              ApellidoMaterno = pers1.ApellidoMaterno,
                              EstatusPersona = pers1.EstatusPersona,
                              IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                              IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                              IdGenero = pers1.IdGenero,
                              //     Genero = gen1.Descripcion,
                              IdEstadoCivil = pers1.IdEstadoCivil,
                              //  EstadoCivil = edo1.Descripcion,
                              IdOficio = pers1.IdOficio,
                              IdEscolaridad = pers1.IdEscolaridad,
                              FechaNacimiento = pers1.FechaNacimiento,
                              Rfc = pers1.Rfc,
                              Curp = pers1.Curp,
                              Edad = pers1.Edad,
                              CodigoPostal = pers1.CodigoPostal,
                              Celular = pers1.Celular,
                              FechaIngreso = pers1.FechaIngreso,
                              FechaBaja = pers1.FechaBaja,
                              Cif = pers1.Cif,
                              Dirigente = pers1.Dirigente,
                              IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                              // IdOrgano = pers1.IdOrgano,
                              IdProfesion = pers1.IdProfesion,
                              Plaza = pers1.Plaza,
                              PlazaId = pers1.IdPlaza,
                              Sucursal = pers1.Sucursal,
                              EstatusPerfil = perf1.EstatusPerfil,
                              Calle = pers1.Calle,
                              NumeroInterior = pers1.NumeroInterior,
                              Colonia = pers1.Colonia,
                              Estado = pers1.Estado,
                              Municipio = pers1.Municipio,
                              IdDirigente = pers1.IdDirigente,
                              Email = pers1.CorreoPersonal,
                              CuentaMexicana = pers1.CuentaMexicana
                              //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                          }).FirstOrDefault();

            if (prueba == null)
                return null;

            else
                return prueba;

        }
        public UsuarioPersonaPerfil UsuarioPersonaPerfilPermisoPlaza(string correo)
        {
            // Se mostrara la plaza del solicitante
            var prueba = (from user1 in context.Usuarios
                          join pers1 in context.PersonaCats
                          on user1.IdPersona equals pers1.IdPersona
                          join perf1 in context.PerfilCargos
                          on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                          join perm1 in context.Permisos
                          on perf1.IdPerfilCargo equals perm1.IdPerfilCargo
                          join sub in context.SubModuloCats
                          on perm1.IdSubModulo equals sub.IdSubModulo

                          where user1.CorreoAcceso == correo
                          select new UsuarioPersonaPerfil

                          {
                              IdUsuario = user1.IdUsuario,
                              CorreoAcceso = user1.CorreoAcceso,
                              Perfil = perf1.Descripcion,
                              NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                              EstatusUsuario = user1.EstatusUsuario,
                              UsuarioDa = user1.UsuarioDa,
                              Password = user1.Password,
                              IdPersona = user1.IdPersona,
                              IdPerfil = user1.IdPerfilCargo,
                              NombrePersona = pers1.NombrePersona,
                              ApellidoPaterno = pers1.ApellidoPaterno,
                              ApellidoMaterno = pers1.ApellidoMaterno,
                              EstatusPersona = pers1.EstatusPersona,
                              IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                              IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                              IdGenero = pers1.IdGenero,
                              //     Genero = gen1.Descripcion,
                              IdEstadoCivil = pers1.IdEstadoCivil,
                              //  EstadoCivil = edo1.Descripcion,
                              IdOficio = pers1.IdOficio,
                              IdEscolaridad = pers1.IdEscolaridad,
                              FechaNacimiento = pers1.FechaNacimiento,
                              Rfc = pers1.Rfc,
                              Curp = pers1.Curp,
                              Edad = pers1.Edad,
                              CodigoPostal = pers1.CodigoPostal,
                              Celular = pers1.Celular,
                              FechaIngreso = pers1.FechaIngreso,
                              FechaBaja = pers1.FechaBaja,
                              Cif = pers1.Cif,
                              Dirigente = pers1.Dirigente,
                              IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                              // IdOrgano = pers1.IdOrgano,
                              IdProfesion = pers1.IdProfesion,
                              Plaza = pers1.Plaza,
                              PlazaId = pers1.IdPlaza,
                              Sucursal = pers1.Sucursal,
                              EstatusPerfil = perf1.EstatusPerfil,
                              Calle = pers1.Calle,
                              NumeroInterior = pers1.NumeroInterior,
                              Colonia = pers1.Colonia,
                              Estado = pers1.Estado,
                              Municipio = pers1.Municipio,
                              IdDirigente = pers1.IdDirigente,
                              Email = pers1.CorreoPersonal,
                              CuentaMexicana = pers1.CuentaMexicana
                              //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                          }).FirstOrDefault();

            if (prueba == null)
                return null;

            else
                return prueba;

        }
        public List<UsuarioPersonaPerfil> UsuarioPersonaPerfilbyNombreApellidoPadron(PersonaNombre usuarioDirigente)
        {
            // Checar por ApPAterno + ApMaterno + Nombre
            var usuarioPersona = (from user1 in context.Usuarios
                                  join pers1 in context.PersonaCats
                                  on user1.IdPersona equals pers1.IdPersona
                                  join perf1 in context.PerfilCargos
                                  on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                                  join gen1 in context.GeneroCats
                                  on pers1.IdGenero equals gen1.IdGenero
                                  join edo1 in context.EstadoCivilCats
                                  on pers1.IdEstadoCivil equals edo1.IdEstadoCivil
                                  where
                                   pers1.NombrePersona == usuarioDirigente.NombrePersona
                                  && pers1.ApellidoPaterno == usuarioDirigente.ApellidoPaterno
                                  && pers1.ApellidoMaterno == usuarioDirigente.ApellidoMaterno
                                  //&& pers1.ApellidoMaterno.Contains( usuarioDirigente.ApellidoMaterno)


                                  select new UsuarioPersonaPerfil

                                  {
                                      IdUsuario = user1.IdUsuario,
                                      CorreoAcceso = user1.CorreoAcceso,
                                      Perfil = perf1.Descripcion,
                                      NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                                      EstatusUsuario = user1.EstatusUsuario,
                                      UsuarioDa = user1.UsuarioDa,
                                      Password = user1.Password,
                                      IdPersona = user1.IdPersona,
                                      IdPerfil = user1.IdPerfilCargo,
                                      NombrePersona = pers1.NombrePersona,
                                      ApellidoPaterno = pers1.ApellidoPaterno,
                                      ApellidoMaterno = pers1.ApellidoMaterno,
                                      EstatusPersona = pers1.EstatusPersona,
                                      IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                                      IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                                      IdGenero = pers1.IdGenero,
                                      Genero = gen1.Descripcion,
                                      IdEstadoCivil = pers1.IdEstadoCivil,
                                      EstadoCivil = edo1.Descripcion,
                                      IdOficio = pers1.IdOficio,
                                      IdEscolaridad = pers1.IdEscolaridad,
                                      FechaNacimiento = pers1.FechaNacimiento,
                                      Rfc = pers1.Rfc,
                                      Curp = pers1.Curp,
                                      Edad = pers1.Edad,
                                      CodigoPostal = pers1.CodigoPostal,
                                      Celular = pers1.Celular,
                                      FechaIngreso = pers1.FechaIngreso,
                                      FechaBaja = pers1.FechaBaja,
                                      Cif = pers1.Cif,
                                      Dirigente = pers1.Dirigente,
                                      IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                                      // IdOrgano = pers1.IdOrgano,
                                      IdProfesion = pers1.IdProfesion,
                                      Plaza = pers1.Plaza,
                                      PlazaId = pers1.IdPlaza,
                                      Sucursal = pers1.Sucursal,
                                      EstatusPerfil = perf1.EstatusPerfil,
                                      Calle = pers1.Calle,
                                      NumeroInterior = pers1.NumeroInterior,
                                      Colonia = pers1.Colonia,
                                      Estado = pers1.Estado,
                                      Municipio = pers1.Municipio,
                                      IdDirigente = pers1.IdDirigente,
                                      CuentaMexicana = pers1.CuentaMexicana,
                                      //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                                  }).ToList();
            if (usuarioPersona == null)
                return null;

            else
                return usuarioPersona;
        }
    }
}
