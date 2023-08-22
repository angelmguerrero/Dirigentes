<template>
    <b-form class="mt-auto">

        <b-row>
            <b-col cols="2"><h5>Filtro:</h5></b-col>
            <b-col cols="4">
                <b-form-select v-model="selected" size="sm" :options="optionsfitro"></b-form-select>
            </b-col>
            <b-col cols="4">

                <input type="text" v-model="inputbusqueda" class="form-control">
                

            </b-col>

            <b-col cols="2">

                
                <b-button size="sm" @click="ValidarTipoBusqudad">
                    <i class="fa-solid fa-magnifying-glass"> </i>
                    Buscar
                </b-button>

            </b-col>


        </b-row>
        <hr />

        <h2>Datos Generales: </h2>
        <hr />
        <b-row>
            <b-col cols="4">
                <b-form-group id="apellido_paterno"
                              label="Apellido Paterno"
                              label-for="apellidoPaterno">

                    <b-form-input id="apellidoPaterno"
                                  type="text"
                                  v-model="apaterno" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{apaterno}}</span>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="apellido_materno"
                              label="Apellido Materno"
                              label-for="apellidoMaterno">

                    <b-form-input id="apellidoMaterno"
                                  type="text"
                                  v-model="amaterno" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{amaterno}}</span>-->

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="nombres_"
                              label="Nombres"
                              label-for="nombres">

                    <b-form-input id="nombres"
                                  type="text"
                                  v-model="nombres" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{nombres}}</span>-->
                </b-form-group>
            </b-col>

        </b-row>

        <b-row>
            <b-col cols="4">
                <b-form-group id="fecha_nacimiento"
                              label="Fecha Nacimiento"
                              label-for="fechaNacimiento">
                   
                    <b-form-input id="fechaNacimiento"
                                  type="text"
                                  v-model="fecNaciomientoFormato" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{fecNaciomientoFormato}}</span>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="edad_"
                              label="Edad"
                              label-for="edad">

                    <b-form-input id="edad"
                                  type="text"
                                  v-model="edad" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{edad}}</span>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="rfc_"
                              label="Rfc"
                              label-for="rfc">

                    <b-form-input id="rfc"
                                  type="text"
                                  v-model="rfc" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{rfc}}</span>-->
                </b-form-group>
            </b-col>

        </b-row>

        <b-row>
            <b-col cols="4">
                <b-form-group id="curp_"
                              label="CURP"
                              label-for="curp">

                    <b-form-input id="curp"
                                  type="text"
                                  v-model="curp" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{curp}}</span>-->


                </b-form-group>
            </b-col>

            <!--<b-col cols="4">
                <b-form-group id="iddirigente_"
                              label="ID Dirigente"
                              label-for="iddirigente">

                    <b-form-input id="iddirigente"
                                  type="text"
                                  v-model="idDirigente"  ></b-form-input>
                  

                </b-form-group>
            </b-col>-->

        </b-row>

        <b-row>
            <b-col cols="4">
                <b-form-group id="plaza_"
                              label="Plaza"
                              label-for="plaza">

                    <b-form-input id="plaza"
                                  type="text"
                                  v-model="plaza" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{plaza}}</span>-->
                    <!--<b-form-select v-model="selectedEsta"  v-on:change="onChangePlaza"   >
        <option v-for="optPlaza in optPlazas" :key="optPlaza.id" :value="optPlaza.idPlaza">
            {{ optPlaza.descripcion }}
        </option>
    </b-form-select>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="sucursal_"
                              label="Sucursal"
                              label-for="sucursal">

                    <b-form-input id="sucursal"
                                  type="text"
                                  v-model="sucursal" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{sucursal}}</span>-->
                    <!--<b-form-select v-model="selectedEsta">
        <option v-for="optSucursal in optSucursales" :key="optSucursal.id" :value="optSucursal.idSucursal">
            {{ optSucursal.descripcion }}
        </option>
    </b-form-select>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="fecha_Ingreso"
                              label="Fecha Ingreso"
                              label-for="fechaIngreso">

                    <b-form-input id="fechaIngreso"
                                  type="text"
                                  v-model="fecIngreso" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{fecIngreso}}</span>-->
                </b-form-group>
            </b-col>

        </b-row>

        <b-row>
            <b-col cols="4">
                <b-form-group id="genero_"
                              label="Genero"
                              label-for="genero">

                    <b-form-input id="genero"
                                  type="text"
                                  v-model="genero" disabled></b-form-input>
                    <!--<span style="color:dimgray"> {{genero}}</span>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="estado_civil"
                              label="Estado Civil"
                              label-for="estadoCivil">

                    <b-form-input id="estadoCivil"
                                  type="text"
                                  v-model="edoCivil" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{edoCivil}}</span>-->
                </b-form-group>
            </b-col>


        </b-row>

        <b-row>
            <b-col cols="4">
                <b-form-group id="correo_acceso"
                              label="Correo"
                              label-for="correoAcceso">

                    <b-form-input id="correoAcceso"
                                  type="text"
                                  v-model="email" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{email}}</span>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="celular_"
                              label="Celular"
                              label-for="celular">

                    <b-form-input id="celular"
                                  type="text"
                                  v-model="celular" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{celular}}</span>-->
                </b-form-group>
            </b-col>



        </b-row>


        <h2>Informacion Direccion: </h2>
        <hr />

        <b-row>
            <b-col cols="4">
                <b-form-group id="calle_"
                              label="Calle"
                              label-for="calle">

                    <b-form-input id="calle"
                                  type="text"
                                  v-model="calle" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{calle}}</span>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="numerointerior_"
                              label="Numero interior"
                              label-for="numeroInterior">

                    <b-form-input id="noInterior"
                                  type="text"
                                  v-model="nointerior" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{nointerior}}</span>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="codigopostal_"
                              label="Codigo postal"
                              label-for="codigoPostal">

                    <b-form-input id="codigoPostal"
                                  type="text"
                                  v-model="cp" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{cp}}</span>-->
                </b-form-group>
            </b-col>


        </b-row>

        <b-row>
            <b-col cols="4">
                <b-form-group id="colonia_"
                              label="Colonia"
                              label-for="colonia">

                    <b-form-input id="colonia"
                                  type="text"
                                  v-model="colonia" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{colonia}}</span>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="estado_"
                              label="Estado"
                              label-for="estado">

                    <b-form-input id="estado"
                                  type="text"
                                  v-model="estado" disabled></b-form-input>
                    <!--<span style="color:dimgray"> {{estado}}</span>-->
                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="municipio_"
                              label="Municipio"
                              label-for="municipio">

                    <b-form-input id="municipio"
                                  type="text"
                                  v-model="municipio" disabled></b-form-input>

                    <!--<span style="color:dimgray"> {{municipio}}</span>-->
                </b-form-group>
            </b-col>


        </b-row>

        <!--<h2>Informacion Usuario: </h2>
    <hr />

    <b-row>
        <b-col cols="4">
            <b-form-group id="id_perfil"
                          label="Id Perfil"
                          label-for="idPerfil">


                <span style="color:dimgray"> {{idPerfil}}</span>


            </b-form-group>
        </b-col>

        <b-col cols="4">
            <b-form-group id="correo_acceso"
                          label="Correo acceso"
                          label-for="correoAcceso">

                <span style="color:dimgray"> {{email}}</span>


            </b-form-group>
        </b-col>

        <b-col cols="4">
            <b-form-group id="estatus"
                          label="Estatus"
                          label-for="estatus">

                <span style="color:dimgray"> {{estatusPerfil}}</span>


            </b-form-group>
        </b-col>
    </b-row>-->





        <b-row class="mt-4">
            <b-col cols="3">
                <b-button variant="success" @click="addNew">Guardar</b-button>
            </b-col>
            <b-col>
                <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
            </b-col>
        </b-row>
    </b-form>

</template>

<script>

    export default {
        name: "CreateModal",
        data() {
            return {
                registro: {},
                //modal
                selected: null,
                inputbusqueda: null,
                usuario: {},
                optPlazas: [],
                optSucursales: [],
                optionsfitro: [
                    { value: 1, text: 'CIF' },
                    { value: 2, text: 'Nombre' },
                    { value: 3, text: 'Cuenta mexicana' },

                ],
                selectedEsta: [
                    { value: 1, text: 'Selecciona una Opción' },
                    { value: 2, text: 'Activo' },
                    { value: 3, text: 'Inactivo' },
                ],

                //datosGenerales
                estatusgeneral: '',

                apaterno: "",
                amaterno: "",
                nombres: "",
                fecNaciomiento: '',
                edad: '',
                rfc: '',
                curp: '',
                plaza: '',
                sucursal: '',
                fecIngreso: '',
                genero: '',
                edoCivil: '',
                email: '',
                celular: '',
                //informacidireccion:'',
                calle: '',
                nointerior: '',
                cp: '',
                colonia: '',
                estado: '',
                municipio: '',
                iddirigente:'',
                //formaciónacademica

                selectedescolar: null,
                escolaroptions: [],
                selectedProfesion: null,
                optProfesiones: [],
                selecteClasificacion: null,
                optClasificaciones: [],

                file1: null,
                file2: null,
                //formacion Dirigente
                nivelorga: "Coprosu",
                fecintegracion: "17/04/2022",
                cargoorgano: "Vocal",
            };
        },
        methods: {
            triggerClose() {
                this.$emit("closeCreateModal");
            },
            addNew() {
                

                if (this.usuario.estatusUsuario == undefined) {
                    this.usuario.estatusUsuario = true
                }

                // this.usuario.EstatusPersona
                // this.usuario.IdCargo
                // this.usuario.IdSubUnidadOperativa
                //this.usuario.IdGenero
                //this.usuario.IdEstadoCivil
                //this.usuario.IdOficio
                //this.usuario.IdEscolaridad
                this.usuario.apellidoPaterno = this.apaterno;
                this.usuario.apellidoMaterno = this.amaterno;
                this.usuario.nombrePersona = this.nombres;
                this.usuario.fechaNacimiento = this.fecNaciomiento;
                //this.usuario.Rfc
                //this.usuario.Curp
                //this.usuario.Edad
                this.usuario.codigoPostal = this.cp;
                //this.usuario.Celular
                //this.usuario.FechaIngreso
                //this.usuario.FechaBaja
                this.usuario.cif = this.cif;
                //this.usuario.Dirigente
                //this.usuario.IdRepresententanteCargoCat
                //this.usuario.IdOrgano
                //this.usuario.IdProfesion
                this.usuario.colonia = this.colonia;
                this.usuario.estado = this.estado;
                this.usuario.municipio = this.municipio;
                //this.usuario.CorreoAcceso
                this.usuario.sucursal = this.sucursal;
                this.usuario.genero = this.genero;
                this.usuario.calle = this.calle;
                this.usuario.numeroInterior = this.nointerior;
                this.usuario.idDirigente = this.idDirigente;

                console.log("Comienza agregar usuario");
                console.log("usuario" + this.usuario);
                console.log("estatus " + this.usuario.estatusUsuario);

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(this.usuario)
                };
                fetch('./api/Usuarios/CrearUsuarioPersonaPerfilNew', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            this.$emit("closeCreateModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showSuccessAlert");
                        }
                        else {
                            this.$swal.fire({
                                text: 'Se genero un error al crear el usuario valide con su administrador',
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                            });
                        }
                    })
                    .catch(error => {
                        this.errorMessage = error;
                        console.error('There was an error!', error);
                    });
            },
            ObtenerPlaza() {
                fetch('./api/Plaza/ConsultarPlazas')
                    .then((response) => response.json())
                    .then((data) => {
                       // debugger

                        this.optPlazas = data;
                        console.log('plazas', this.optPlazas)
                        // console.log('plaza', this.optPlaza)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            ObtenerSucursal() {
                fetch('./api/Sucursal/ConsultarSucursales')
                    .then((response) => response.json())
                    .then((data) => {
                        debugger

                        this.optSucursales = data;
                        console.log('sucursales', this.optSucursales)
                        //  console.log('sucursal', this.optSucursal)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            ObtenerSucursalbyIdPlazaParametro(idPlaza) {
                fetch('./api/Sucursal/ConsultarSucursalesbyIdPlaza?idPlaza=' + idPlaza)
                    .then((response) => response.json())
                    .then((data) => {
                        debugger

                        this.optSucursales = data;
                        console.log('sucursales', this.optSucursales)
                        //  console.log('sucursal', this.optSucursal)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            onChangePlaza: function () {
                console.log('hola', this.selectedEsta)
                this.ObtenerSucursalbyIdPlazaParametro(this.selectedEsta)
            },
            ValidarTipoBusqudad() {

                if (this.selected == 1) {
                    this.ObtenerSocioCif();

                }
                else {
                    this.ObtenerSocioNombre();
                    console.log('ObtenerSocioNombre')
                }


            },
            ObtenerSocioNombre() {
                //todo


            },
            ObtenerSocioCif() {
                if (this.inputbusqueda != null && this.inputbusqueda != '') {
                    //console.log('cif', this.cif)
                    const requestOptions = {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify(this.inputbusqueda)
                    };


                    fetch('./api/VwInfoSocios/VwInfoSociosbyId', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {

                            this.registro = data;
                            //console.log('socioxcif', this.registro)

                            this.apaterno = this.registro.apePatSocio;
                            this.amaterno = this.registro.apeMatSocio;
                            this.nombres = this.registro.nombre;
                            this.fecNaciomientoFormato = this.fechaFormato(this.registro.fecNacD);
                            this.fecNaciomiento = this.registro.fecNacD;
                            //this.edad= this.registro.
                            //this.rfc= this.registro.
                            //this.curp= this.registro.
                            //this.plaza= this.registro.
                            this.sucursal = this.registro.sucursal;
                            //this.fecIngreso= this.registro.
                            this.genero = (this.registro.sexo == 'F' ? 'Femenino' : 'Masculino');
                            //this.edoCivil= this.registro.
                            //this.email= this.registro.
                            //this.celular= this.registro.
                            ////informacidireccion
                            this.calle = this.registro.calle;
                            this.nointerior = this.registro.numExterior
                            this.cp = this.registro.cp;
                            this.colonia = this.registro.colonia;
                            this.estado = this.registro.estadoDomicilio;
                            this.municipio = this.registro.ciudad;
                            this.cif = this.registro.cif;
                            this.idDirigente = this.registro.idDirigente;

                            

                        })
                        .catch(error => {
                            this.$swal.fire({
                                text: 'Se genero un error valide con su administrador',
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                            });
                            console.error('Error:', error)
                        });
                }
                //else {
                //    this.$swal.fire({
                //        text: 'El campo se encuentra vacio',
                //        icon: 'warning',
                //        confirmButtonText: 'Ok',

                //    });
                //}
            },

            fechaFormato(fecha) {

                let ano = new Date(fecha).getFullYear();
                let mes = new Date(fecha).getMonth() + 1;
                let dia = new Date(fecha).getDate();

                mes = mes < 10 ? "0" + mes : mes;
                dia = dia < 10 ? "0" + dia : dia;


                let salida = dia + '/' + mes + '/' + ano;
                //console.log('Sal', salida)
                return salida;

            },


        },
        mounted() {
           // this.ObtenerPlaza();
            //  this.ObtenerSucursal();
        }
    };
</script>