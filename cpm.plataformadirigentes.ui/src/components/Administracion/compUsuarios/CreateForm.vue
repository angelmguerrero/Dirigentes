<template>
    

        <b-form class="mt-auto">

            <b-row>
                <b-col cols="2"><h5>Filtro:</h5></b-col>
                <b-col cols="4">
                    <b-form-select v-model="selected" size="sm" :options="optionsfitro" v-on:change="onChangeFiltro"></b-form-select>
                </b-col>


                <b-col cols="2">


                    <b-button size="sm" @click="ValidarTipoBusqudad" :disabled="disabled==0"  >
                        <i class="fa-solid fa-magnifying-glass"> </i>
                        Buscar
                    </b-button>

                   

                </b-col>


                <b-col cols="1">
                    <div class="text-center" id="divSpinner" v-if="disabled==0">
                        <b-spinner variant="success" label="Spinning"></b-spinner>
                    </div>
                </b-col>


            </b-row>



            <hr />
            <b-row>

                <b-col cols="4">

                    <!--<label>Nombres/CIF/Cuenta Mexicana</label>-->
                    <input placeholder="Nombres/CIF/Cuenta Mexicana"  type="text" v-model="inputbusqueda" class="form-control">

                </b-col>

                <b-col cols="2" v-if="MostrarApellidos">

                    <!--<label>Apellido Paterno</label>-->
                    <input placeholder="Apellido Paterno"  type="text" v-model="inputbusquedaApellidoPaterno" class="form-control" :disabled="disabledApellidos == 1">

                </b-col>

                <b-col cols="2" v-if="MostrarApellidos">

                    <!--<label>Apellido Materno</label>-->
                    <input placeholder="Apellido Materno"  type="text" v-model="inputbusquedaApellidoMaterno" class="form-control" :disabled="disabledApellidos == 1">

                </b-col>




            </b-row>
            <hr />
            <b-row>
                <b-col cols="8" v-if="MostrarApellidos">
                    <b-form-group id="id_perfil"
                                  label="Personas encontradas por Nombre"  
                                  label-for="cif">  
                        <span class="label">({{totalRegistros}} registros encontrados)</span>

                        <b-form-select v-model="selectedUsuarioDirigente" v-on:change="onChangeUsuariosDirigentes" :disabled="disabledApellidos == 1">
                            <!--<option value="0"   >Seleccione un registro.</option>-->
                            <option v-for="optUsuarioDirigente in optUsuariosDirigentes" :key="optUsuarioDirigente.id" :value="optUsuarioDirigente.cif">
                                Nombre: {{ optUsuarioDirigente.nombre }}   {{ optUsuarioDirigente.apellidoPaterno }}   {{ optUsuarioDirigente.apellidoMaterno }}  Cif: {{ optUsuarioDirigente.cif }}  Plaza: {{ optUsuarioDirigente.plaza }}
                            </option>
                        </b-form-select>


                    </b-form-group>
                </b-col>
            </b-row>

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

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="apellido_materno"
                                  label="Apellido Materno"
                                  label-for="apellidoMaterno">

                        <b-form-input id="apellidoMaterno"
                                      type="text"
                                      v-model="amaterno" disabled></b-form-input>

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="nombres_"
                                  label="Nombres"
                                  label-for="nombres">

                        <b-form-input id="nombres"
                                      type="text"
                                      v-model="nombres" disabled></b-form-input>

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

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="edad_"
                                  label="Edad"
                                  label-for="edad">

                        <b-form-input id="edad"
                                      type="text"
                                      v-model="edad" disabled></b-form-input>

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="rfc_"
                                  label="Rfc"
                                  label-for="rfc">

                        <b-form-input id="rfc"
                                      type="text"
                                      v-model="rfc" disabled></b-form-input>

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

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="cif_"
                                  label="CIF"
                                  label-for="cif">

                        <b-form-input id="cif"
                                      type="text"
                                      v-model="cif" disabled></b-form-input>


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

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="sucursal_"
                                  label="Sucursal"
                                  label-for="sucursal">

                        <b-form-input id="sucursal"
                                      type="text"
                                      v-model="sucursal" disabled></b-form-input>

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="fecha_Ingreso"
                                  label="Fecha Ingreso"
                                  label-for="fechaIngreso">

                        <b-form-input id="fechaIngreso"
                                      type="text"
                                      v-model="fecIngresoFormato" disabled></b-form-input>

                    </b-form-group>
                </b-col>

            </b-row>

            <b-row>
                <b-col cols="4">
                    <b-form-group id="genero_"
                                  label-for="genero">
                        <label>G&eacute;nero </label>
                        <b-form-input id="genero"
                                      type="text"
                                      v-model="genero" disabled></b-form-input>

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="estado_civil"
                                  label="Estado Civil"
                                  label-for="estadoCivil">

                        <b-form-input id="estadoCivil"
                                      type="text"
                                      v-model="estadoCivil" disabled></b-form-input>

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

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="celular_"
                                  label-for="celular">
                        <label>N&uacute;mero de tel&eacute;fono </label>
                        <b-form-input id="celular"
                                      type="text"
                                      v-model="celular" disabled></b-form-input>

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="cuentaMexicana_"
                                  label="Cuenta Mexicana"
                                  label-for="cuentamexicana">

                        <b-form-input id="cuentaMexicana"
                                      type="text"
                                      v-model="cuentaMexicana" disabled></b-form-input>

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

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="numerointerior_"
                                  label-for="numeroInterior">
                        <label>N&uacute;mero </label>
                        <b-form-input id="noInterior"
                                      type="text"
                                      v-model="nointerior" disabled></b-form-input>

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="codigopostal_"
                                  label-for="codigoPostal">
                        <label>C&oacute;digo Postal </label>
                        <b-form-input id="codigoPostal"
                                      type="text"
                                      v-model="codigoPostal" disabled></b-form-input>

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

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="estado_"
                                  label="Estado"
                                  label-for="estado">

                        <b-form-input id="estado"
                                      type="text"
                                      v-model="estado" disabled></b-form-input>

                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="municipio_"
                                  label="Municipio"
                                  label-for="municipio">

                        <b-form-input id="municipio"
                                      type="text"
                                      v-model="municipio" disabled></b-form-input>

                    </b-form-group>
                </b-col>


            </b-row>

            <h2>Informacion Usuario: </h2>
            <hr />

            <b-row>
                <b-col cols="4">
                    <b-form-group id="id_perfil"
                                  label="Perfil"
                                  label-for="idPerfil">


                        <b-form-select v-model="selectedPerfil">
                            <option v-for="optPerfil in optPerfiles" :key="optPerfil.id" :value="optPerfil.idPerfilCargo">
                                {{ optPerfil.descripcion }}
                            </option>
                        </b-form-select>


                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="correo_acceso"
                                  label="Correo acceso"
                                  label-for="correoAcceso">

                        <b-form-input id="correoAcceso"
                                      type="text"
                                      v-model="correoAcceso" contenteditable="false" @input="validateEmail"></b-form-input>
                        <p v-if="error" class="error">{{ error }}</p>

                    </b-form-group>
                </b-col>

                <!--<b-col cols="4">
                <b-form-group id="estatus"
                              label="Estatus"
                              label-for="estatus">

                    <b-form-input id="estatus"
                                  type="text"
                                  v-model="usuario.estatusPerfil" disabled></b-form-input>


                </b-form-group>
            </b-col>-->
            </b-row>

            <!--<b-row>
            <b-col cols="12">
                <b-form-checkbox id="estatus_usuario"
                                 v-model="usuario.estatusUsuario"
                                 name="usuario-status">
                    Usuario es Activo
                </b-form-checkbox>
            </b-col>

        </b-row>-->


            <b-row class="mt-4">
             

                <b-col cols="3">
                    <b-button variant="success" @click="validaExistenciaByCif" >Guardar</b-button>
                </b-col>

                <b-col cols="1">
                    <div class="text-center" id="divSpinner" v-if="disabledG==0">
                        <b-spinner variant="success" label="Spinning"></b-spinner>
                    </div>
                </b-col>

                <b-col>
                    <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
                </b-col>
                <b-col cols="1">
                  <!--   <b-button variant="light" @click="enviarMail" ></b-button>-->
                </b-col>
            </b-row>
        </b-form>
 
</template>

<script>
    import { config } from "@/config/auth";
    import store from '@/store'; 

    export default {
        name: "CreateModal",
        data() {
            return {

               
                registro: {},
                registroNombreApellidos: {},
                //modal
                condicion: false,
                disabled: 1,
                disabledG: 1,
                selected: null,
                selectedPerfil: null,
                selectedUsuarioDirigente: null,
                inputbusqueda: null,
                usuario: {},
                usuarioLog: {},
                usuarioBusqueda: {},
                optPlazas: [],
                optPerfiles: [],
                optUsuariosDirigentes: [],
                optSucursales: [],
                optionsfitro: [
                    { value: 1, text: 'CIF' },
                    { value: 2, text: 'Nombre' },
                    { value: 3, text: 'Cuenta mexicana' },

                ],
                selectedEsta: [
                    { value: 1, text: 'Selecciona una Opci�n' },
                    { value: 2, text: 'Activo' },
                    { value: 3, text: 'Inactivo' },
                ],

                //datosGenerales
                estatusgeneral: '',

                apaterno: "",
                amaterno: "",
                nombres: "",
                fecNaciomiento: '',
                fecNaciomientoFormato: '',
                fecIngresoFormato:'',
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
                calle: '',
                nointerior: '',
                cp: '',
                colonia: '',
                estado: '',
                municipio: '',
                correoAcceso: '',
                perfil: '',
                codigoPostal: '',
                estadoCivil: '',
                idPerfil: '',
                cuentaMexicana: '',
                cifBusqueda: '',
                correoAccesoBusqueda: '',
                plazaId: '',
                sucursalId:'',
                error: '',
                valorBusqueda: '',
                disabledApellidos: '',
                MostrarApellidos: false,
                totalRegistros: '0',
                algo: '',

            };
        },
        
        methods: {
            

            onChangeUsuariosDirigentes: function () {
                console.log('changeusuariodirigente')
                if (this.selectedUsuarioDirigente != '0') { this.ObtenerSocioCifNombreApellidos(); }
               // this.ObtenerSucursalbyIdPlazaParametro(this.selectedEsta)
            },
            onChangeFiltro: function () {


                console.log('selected: ', this.selected)
                if (this.selected == 1 || this.selected == 3) {
                    this.disabledApellidos = 1;
                    this.MostrarApellidos = false;
                }
                else {
                    this.disabledApellidos = 0;
                    this.MostrarApellidos = true;
                }

            },
            validateEmail() {
                let emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                if (!emailRegex.test(this.correoAcceso)) {
                    this.error = 'Favor de ingresar un Email v\u00E1lido, p.ej. usuario@dominio.com';
                } else {
                    this.error = '';
                }
            },

            triggerClose() {
                this.$emit("closeCreateModal");
            },
            validaExistenciaByCorreoAcceso() {
                 

                const requestOptions = {
                    method: 'POST',
                 //   headers: { 'Content-Type': 'application/json' },
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },//CAMBIO SEGURIDAD
                    body: JSON.stringify(this.correoAcceso)
                };

                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilbyCorreoAcceso', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.usuarioBusqueda = data;


                        //this.correoAccesoBusqueda = this.usuarioBusqueda.cif;// == null ? 0 : this.usuarioBusqueda.cif;
                        this.correoAccesoBusqueda = this.usuarioBusqueda.correoAcceso;// == null ? 0 : this.usuarioBusqueda.cif;
                        console.log("usuario:", this.usuarioBusqueda)

                        let emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                        console.log('this.correoAceso', this.correoAcceso)

                        if (this.correoAcceso == '') { this.correoAccesoBusqueda == '' }
                        console.log('correoAccesoBusqueda', this.correoAccesoBusqueda)
                        console.log('correoAcceso', this.correoAccesoBusqueda)
                        console.log('emailRegex.test(this.correoAcceso)', emailRegex.test(this.correoAcceso))


                        if ((this.correoAccesoBusqueda == '' || this.correoAccesoBusqueda == null || this.correoAccesoBusqueda == 0) && emailRegex.test(this.correoAcceso)) {
                       // if ((this.correoAccesoBusqueda == '' || this.correoAccesoBusqueda == null || this.correoAccesoBusqueda == 0)) {
                             this.addNew();
                            //this.validaExistenciaByCorreoAcceso

                        }
                        else {
                            this.$swal.fire({
                                text: 'Ya existe un registro con el Correo de Acceso ingresado o el Correo de Acceso es incorrecto, favor de validar',
                                //text: 'Ya existe un registro con el Correo de Acceso ingresado o el Correo de Acceso est\u00E1 vac\u00EDo, favor de validar',
                                icon: 'warning',
                                confirmButtonText: 'Ok',

                            });
                        }
                        
                    })
                //.catch(error => {
                //    this.errorMessage = error;
                //    console.error('Error:', error)
                //});
            },
            validaExistenciaByCif() {

            
                //this.validaExistenciaByCorreoAcceso();

                const requestOptions = {
                    method: 'POST',
                    //headers: { 'Content-Type': 'application/json' },
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                    body: JSON.stringify(this.cif)
                };


                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilbyCif', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {
                           
                        this.usuarioBusqueda = data;

                        this.cifBusqueda = this.usuarioBusqueda.cif;// == null ? 0 : this.usuarioBusqueda.cif;
                        console.log("usuario:", this.usuarioBusqueda)                       
                        console.log('usuarioBusqueda', this.usuarioBusqueda)
                        console.log('cifBusqueda', this.cifBusqueda)
                        console.log('correoAccesoBusqueda', this.correoAccesoBusqueda)
                         
                  
                        
                        if ((this.cifBusqueda == '' || this.cifBusqueda == null || this.cifBusqueda == 0)   ) {
                           // this.addNew();
                            this.validaExistenciaByCorreoAcceso();
                           
                            }
                        else {
                            this.$swal.fire({
                                text: 'Ya existe un registro con el CIF ingresado, favor de validar',
                                icon: 'warning',
                                confirmButtonText: 'Ok',

                            });
                        }

                    })
                    //.catch(error => {
                    //    this.errorMessage = error;
                    //    console.error('Error:', error)
                    //});
            },
            addNew() {

                 // if de busqueda por nombre y sin persona capturada
                if (this.selected == 2 && (this.selectedUsuarioDirigente == '' || this.selectedUsuarioDirigente == null || this.selectedUsuarioDirigente == '0')) {
                    this.$swal.fire({
                        text: 'Favor de seleccionar una persona en caso de buscar por Nombre.',
                        icon: 'warning',
                        confirmButtonText: 'Ok',

                    });
                }
                else {
                    //  debugger
                    // if de PErfil, Correo Acceso, 
                    if (this.selectedPerfil != null && this.selectedPerfil != '' && this.correoAcceso != null && this.correoAcceso != '') {

                        if (this.usuario.estatusUsuario == undefined) {
                            this.usuario.estatusUsuario = true
                        }

                        this.disabledG = 0;
                        this.usuario.email = this.email;
                        this.usuario.estadoCivil = this.estadoCivil;
                        this.usuario.email = this.email;
                        this.usuario.codigoPostal = this.codigoPostal;
                        this.usuario.apellidoPaterno = this.apaterno;
                        this.usuario.apellidoMaterno = this.amaterno;
                        this.usuario.nombrePersona = this.nombres;
                        this.usuario.fechaNacimiento = this.fecNaciomiento;
                        this.usuario.rfc = this.rfc;
                        this.usuario.curp = this.curp;
                        this.usuario.edad = this.edad;
                        this.usuario.plaza = this.plaza;
                        this.usuario.sucursal = this.sucursal;
                        //  this.usuario.codigoPostal = this.cp;
                        this.usuario.celular = (this.celular == null || this.celular == '' ? 0 : this.celular);// this.celular;
                        this.usuario.fechaIngreso = this.fecIngreso;
                        this.usuario.cif = this.cif;
                        this.usuario.colonia = this.colonia;
                        this.usuario.estado = this.estado;
                        this.usuario.municipio = this.municipio;
                        this.usuario.correoAcceso = this.correoAcceso;
                        this.usuario.sucursal = this.sucursal;
                        this.usuario.genero = this.genero;
                        this.usuario.calle = this.calle;

                        this.usuario.numeroInterior = this.nointerior;

                        this.usuario.idPerfil = this.selectedPerfil;
                        this.usuario.cuentaMexicana = this.cuentaMexicana;

                        this.usuario.plazaId = this.plazaId;
                        this.usuario.sucursalId = this.sucursalId;
                        // this.usuario.idDirigente = this.idDirigente;


                        console.log("Comienza agregar usuario");
                        console.log("usuario" + this.usuario);
                        console.log("estatus " + this.usuario.estatusUsuario);

                        const requestOptions = {
                            method: 'POST',
                            //headers: { 'Content-Type': 'application/json' },
                            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                            body: JSON.stringify(this.usuario)
                        };
                      //  debugger
                        fetch(config.auth.server_url_api + 'api/Usuarios/CrearUsuarioPersonaPerfilNew', requestOptions)
                            .then(async response => {

                                if (response.status == 200) {
                                    //this.addNewLog();
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

                    }
                    else {
                        this.$swal.fire({
                            text: 'Favor de capturar Perfil y Correo de Acceso.',
                            icon: 'warning',
                            confirmButtonText: 'Ok',

                        });
                    }
                } // else de busqueda por nombre y sin persona capturada
            },
            enviarMail() {
  this.usuarioLog.idModulo = 2;
                this.usuarioLog.idSubModulo = 2;
                this.usuarioLog.tipoMovimiento = 'Alta';
              //  this.usuarioLog.descripcion = 'Cif: ' + this.usuario.cif + ' Nombre: ' + this.usuario.nombrePersona + ' ' + this.usuario.apellidoPaterno + ' ' + this.usuario.apellidoMaterno + ' Correo: ' + this.usuario.correoAcceso + ' Perfil: ' + this.usuario.idPerfil;
                console.log("Comienza agregar usuarioLog");
                console.log("usuario" + this.usuarioLog);
                          const requestOptions = {
                            method: 'POST', 
                            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                              body: JSON.stringify(this.usuarioLog)
                        };
                        //  debugger
                        fetch(config.auth.server_url_api + 'api/Email/EnviarEmailPlantilla', requestOptions)
                            .then(async response => {

                                if (response.status == 200) {
                                    this.$emit("closeCreateModal");
                                    this.$emit("reloadDataTable");
                                    this.$emit("showSuccessAlert");
                                }
                                else {
                                    this.$swal.fire({
                                        text: 'Se genero un error al crear el mail, consulte con su administrador',

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
            addNewLog() {
  
                this.usuarioLog.idModulo = 2;
                this.usuarioLog.idSubModulo = 2;
                this.usuarioLog.tipoMovimiento = 'Alta';
                this.usuarioLog.descripcion = 'Cif: ' + this.usuario.cif + ' Nombre: ' + this.usuario.nombrePersona + ' ' + this.usuario.apellidoPaterno + ' ' + this.usuario.apellidoMaterno + ' Correo: ' + this.usuario.correoAcceso + ' Perfil: ' + this.usuario.idPerfil;
                console.log("Comienza agregar usuarioLog");
                console.log("usuario" + this.usuarioLog);
                          const requestOptions = {
                            method: 'POST', 
                            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                              body: JSON.stringify(this.usuarioLog)
                        };
                        //  debugger
                        fetch(config.auth.server_url_api + 'api/LogGeneral/CrearLogGeneral', requestOptions)
                            .then(async response => {

                                if (response.status == 200) {
                                    this.$emit("closeCreateModal");
                                    this.$emit("reloadDataTable");
                                    this.$emit("showSuccessAlert");
                                }
                                else {
                                    this.$swal.fire({
                                        text: 'Se genero un error al crear el log general, consulte con su administrador',

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
            ObtenerPerfilCargo() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/PerfilCargos/ConsultarPerfilCargosActivos',{headers})
                    .then((response) => response.json())
                    .then((data) => {
                        // debugger

                        this.optPerfiles = data;
                        console.log('perfiles', this.optPerfiles)
                        // console.log('plaza', this.optPlaza)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            ObtenerPlaza() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };// auth header with bearer token

                fetch(config.auth.server_url_api + 'api/Plaza/ConsultarPlazas',{headers})
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
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };// auth header with bearer token

                fetch(config.auth.server_url_api + 'api/Sucursal/ConsultarSucursales',{headers})
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
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };// auth header with bearer token

                fetch(config.auth.server_url_api + 'api/Sucursal/ConsultarSucursalesbyIdPlaza?idPlaza=' + idPlaza,{headers})
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

                //1, text: 'CIF'
                //2, text: 'Nombre'
                //3, text: 'Cuenta mexicana'

                if (this.inputbusqueda != null && this.inputbusqueda != '' && this.selected != null && this.selected != '') {

                    if (this.selected == 1) {
                        this.ObtenerSocioCif();

                    }  

                    if (this.selected == 2) {
                        //this.ObtenerSocioNombre();
                        this.ObtenerSocioNombreApellidos();

                    }  

                    if (this.selected == 3) {
                        this.ObtenerSocioCuentaMexicana();

                    }  

                }
                else {
                    this.$swal.fire({
                        text: 'Favor de capturar filtro y texto de busqueda.',
                        icon: 'warning',
                        confirmButtonText: 'Ok',

                    });
                }


            },            
            ObtenerSocioCif() {
                if (this.inputbusqueda != null && this.inputbusqueda != '' && this.selected != null && this.selected != '') {
                    console.log('cif', this.cif)
                    console.log('this.inputbusqueda: ', this.inputbusqueda)
                    const requestOptions = {
                        method: 'POST',
                      //  headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                        body: JSON.stringify(this.inputbusqueda)
                    };
                    this.disabled = 0;
                    fetch(config.auth.server_url_api + 'api/VwUsuarioDirigentes/VwUsuarioDirigentebyCif', requestOptions)
                        //fetch(config.auth.server_url_api + 'api/VwInfoSocios/VwInfoSociosbyId', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {

                            this.registro = data;
                           
                            this.apaterno = this.registro.apellidoPaterno;
                            this.amaterno = this.registro.apellidoMaterno;
                            this.nombres = this.registro.nombre;
                            this.fecNaciomientoFormato = this.fechaFormato(this.registro.fechaNacimiento);
                            this.fecNaciomiento = this.registro.fechaNacimiento;
                            this.edad= this.registro.edad;
                            this.rfc = this.registro.rfc;
                            this.curp = this.registro.curp;
                            this.plaza = this.registro.plaza;
                            this.sucursal = this.registro.sucursal;
                            this.fecIngresoFormato = this.fechaFormato(this.registro.fechaIngreso);
                            this.fecIngreso = this.registro.fechaIngreso;
                            this.genero = this.registro.genero;                        
                            this.edoCivil = this.registro.estadoCivil;
                            this.estadoCivil = this.registro.estadoCivil;
                            this.email= this.registro.email;
                            this.celular = this.registro.celular;                            
                            this.calle = this.registro.calle;
                            this.nointerior = this.registro.numeroInterior
                            this.codigoPostal = this.registro.codigoPostal;
                            this.colonia = this.registro.colonia;
                            this.estado = this.registro.estado;
                            this.municipio = this.registro.municipio;
                            this.cif = this.registro.cif; 
                            this.cuentaMexicana = this.registro.cuentaMexicana; 


                            this.plazaId = this.registro.plazaId;
                            this.sucursalId = this.registro.sucursalId;

                            this.disabled = 1;

                            if (this.registro.length<1)  
                            {
                                this.$swal.fire({
                                    text: this.$messageConstants('usuarioNoEncontrado'),
                                    icon: 'warning',
                                    confirmButtonText: 'Ok',

                                });
                            }

                        })
                        .catch(error => {
                            this.$swal.fire({
                               // text: 'Se genero un error valide con su administrador',
                                text: this.$messageConstants('usuarioNoEncontrado'),
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                                
                            });
                            console.error('Error:', error)
                            this.disabled = 1;
                        });

                    
                }
               
                //else {
                //    this.$swal.fire({
                //        text: 'Favor de capturar filtro y texto de b�squeda.',
                //        icon: 'warning',
                //        confirmButtonText: 'Ok',

                //    });
                //}
            },
            ObtenerSocioCifNombreApellidos() {
                if (this.inputbusqueda != null && this.inputbusqueda != '' && this.selected != null && this.selected != '') {
                    console.log('cif', this.cif)
                    console.log('this.inputbusqueda: ', this.inputbusqueda)
                    const requestOptions = {
                        method: 'POST',
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, //CAMBIO SEGURIDAD
                        body: JSON.stringify(this.selectedUsuarioDirigente)
                    };
                    this.disabled = 0;
                    fetch(config.auth.server_url_api + 'api/VwUsuarioDirigentes/VwUsuarioDirigentebyCif', requestOptions)
                        //fetch(config.auth.server_url_api + 'api/VwInfoSocios/VwInfoSociosbyId', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {

                            this.registro = data;

                            this.apaterno = this.registro.apellidoPaterno;
                            this.amaterno = this.registro.apellidoMaterno;
                            this.nombres = this.registro.nombre;
                            this.fecNaciomientoFormato = this.fechaFormato(this.registro.fechaNacimiento);
                            this.fecNaciomiento = this.registro.fechaNacimiento;
                            this.edad = this.registro.edad;
                            this.rfc = this.registro.rfc;
                            this.curp = this.registro.curp;
                            this.plaza = this.registro.plaza;
                            this.sucursal = this.registro.sucursal;
                            this.fecIngresoFormato = this.fechaFormato(this.registro.fechaIngreso);
                            this.fecIngreso = this.registro.fechaIngreso;
                            this.genero = this.registro.genero;
                            this.edoCivil = this.registro.estadoCivil;
                            this.estadoCivil = this.registro.estadoCivil;
                            this.email = this.registro.email;
                            this.celular = this.registro.celular;
                            this.calle = this.registro.calle;
                            this.nointerior = this.registro.numeroInterior
                            this.codigoPostal = this.registro.codigoPostal;
                            this.colonia = this.registro.colonia;
                            this.estado = this.registro.estado;
                            this.municipio = this.registro.municipio;
                            this.cif = this.registro.cif;
                            this.cuentaMexicana = this.registro.cuentaMexicana;


                            this.plazaId = this.registro.plazaId;
                            this.sucursalId = this.registro.sucursalId;

                            this.disabled = 1;

                        })
                        .catch(error => {
                            this.$swal.fire({
                                // text: 'Se genero un error valide con su administrador',
                                text: 'No se encontro informacion.',
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,

                            });
                            console.error('Error:', error)
                            this.disabled = 1;
                        });


                }

                //else {
                //    this.$swal.fire({
                //        text: 'Favor de capturar filtro y texto de b�squeda.',
                //        icon: 'warning',
                //        confirmButtonText: 'Ok',

                //    });
                //}
            },
            ObtenerSocioNombre() {
                if (this.inputbusqueda != null && this.inputbusqueda != '' && this.selected != null && this.selected != '') {

                   
                    if (this.selected == 2) { this.valorBusqueda = (this.inputbusquedaApellidoPaterno == null || this.inputbusquedaApellidoPaterno == '' ? '' : this.inputbusquedaApellidoPaterno) + ' ' + (this.inputbusquedaApellidoMaterno == null || this.inputbusquedaApellidoMaterno == '' ? '' : this.inputbusquedaApellidoMaterno) + ' ' + this.inputbusqueda }
                    console.log('cif', this.cif)
                    console.log('this.inputbusqueda: ', this.inputbusqueda)
                    const requestOptions = {
                        method: 'POST',
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                        body: JSON.stringify(this.valorBusqueda)
                          //body: JSON.stringify(this.inputbusqueda)
                    };
                    this.disabled = 0;
                    fetch(config.auth.server_url_api + 'api/VwUsuarioDirigentes/VwUsuarioDirigentebyNombre', requestOptions)
                        //fetch(config.auth.server_url_api + 'api/VwInfoSocios/VwInfoSociosbyId', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {

                            this.registro = data;

                            this.apaterno = this.registro.apellidoPaterno;
                            this.amaterno = this.registro.apellidoMaterno;
                            this.nombres = this.registro.nombre;
                            this.fecNaciomientoFormato = this.fechaFormato(this.registro.fechaNacimiento);
                            this.fecNaciomiento = this.registro.fechaNacimiento;
                            this.edad = this.registro.edad;
                            this.rfc = this.registro.rfc;
                            this.curp = this.registro.curp;
                            this.plaza = this.registro.plaza;
                            this.sucursal = this.registro.sucursal;
                            this.fecIngresoFormato = this.fechaFormato(this.registro.fechaIngreso);
                            this.fecIngreso = this.registro.fechaIngreso;
                            this.genero = this.registro.genero;
                            this.edoCivil = this.registro.estadoCivil;
                            this.estadoCivil = this.registro.estadoCivil;
                            this.email = this.registro.email;
                            this.celular = this.registro.celular;
                            this.calle = this.registro.calle;
                            this.nointerior = this.registro.numeroInterior
                            this.codigoPostal = this.registro.codigoPostal;
                            this.colonia = this.registro.colonia;
                            this.estado = this.registro.estado;
                            this.municipio = this.registro.municipio;
                            this.cif = this.registro.cif; 
                            this.cuentaMexicana = this.registro.cuentaMexicana; 
                            this.plazaId = this.registro.plazaId;
                            this.sucursalId = this.registro.sucursalId;

                            this.disabled = 1;

                        })
                        .catch(error => {
                            this.$swal.fire({
                              //  text: 'Se genero un error valide con su administrador',
                                text: 'No se encontro informacion.',
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                            });
                            console.error('Error:', error)
                            this.disabled = 1;
                        });
                }
                //else {
                //    this.$swal.fire({
                //        text: 'Favor de capturar filtro y texto de b�squeda.',
                //        icon: 'warning',
                //        confirmButtonText: 'Ok',

                //    });
                //}
            },
            ObtenerSocioNombreApellidos() {
                if (this.inputbusqueda != null && this.inputbusqueda != '' && this.selected != null && this.selected != '') {


                    if (this.selected == 2) {
                        this.valorBusqueda = (this.inputbusquedaApellidoPaterno == null || this.inputbusquedaApellidoPaterno == '' ? '' : this.inputbusquedaApellidoPaterno) + ' ' + (this.inputbusquedaApellidoMaterno == null || this.inputbusquedaApellidoMaterno == '' ? '' : this.inputbusquedaApellidoMaterno) + ' ' + this.inputbusqueda
                        this.registroNombreApellidos.nombre = this.inputbusqueda;
                        this.registroNombreApellidos.apellidoPaterno = (this.inputbusquedaApellidoPaterno == null || this.inputbusquedaApellidoPaterno == '' ? '' : this.inputbusquedaApellidoPaterno);
                        this.registroNombreApellidos.apellidoMaterno = (this.inputbusquedaApellidoMaterno == null || this.inputbusquedaApellidoMaterno == '' ? '' : this.inputbusquedaApellidoMaterno);
                        this.registroNombreApellidos.calle = 'x';
                        this.registroNombreApellidos.celular = 'x';
                        this.registroNombreApellidos.cif = '1';
                        this.registroNombreApellidos.codigoPostal = '1';
                        this.registroNombreApellidos.colonia = 'x';
                        this.registroNombreApellidos.cuentaMexicana = 'x';
                        this.registroNombreApellidos.curp = 'x';
                        this.registroNombreApellidos.email = 'x';
                        this.registroNombreApellidos.estado = 'x';
                        this.registroNombreApellidos.estadoCivil = 'x';
                        this.registroNombreApellidos.genero = 'x';
                        this.registroNombreApellidos.municipio = 'x';
                        this.registroNombreApellidos.nombreCompleto = 'x';
                        this.registroNombreApellidos.numeroInterior = 'x';
                        this.registroNombreApellidos.plaza = 'x';
                        this.registroNombreApellidos.rfc = 'x';
                        this.registroNombreApellidos.sucursal = 'x';
                     

                    }
                   // console.log('cif', this.cif)
                   // console.log('this.inputbusqueda: ', this.inputbusqueda)
                    console.log('this.registroNombreApellidos: ', this.registroNombreApellidos)
                    const requestOptions = {
                        method: 'POST',
                       // headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                        body: JSON.stringify(this.registroNombreApellidos)
                        //body: JSON.stringify(this.valorBusqueda)
                        //body: JSON.stringify(this.inputbusqueda)
                    };
                    this.disabled = 0;
                    fetch(config.auth.server_url_api + 'api/VwUsuarioDirigentes/VwUsuarioDirigentebyNombreApellidos', requestOptions)
                        //fetch(config.auth.server_url_api + 'api/VwInfoSocios/VwInfoSociosbyId', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {

                            this.optUsuariosDirigentes = data;
                            
                            console.log(' this.optUsuariosDirigentes: ', this.optUsuariosDirigentes)
                            this.registro = data;

                            //this.apaterno = this.registro.apellidoPaterno;
                            //this.amaterno = this.registro.apellidoMaterno;
                            //this.nombres = this.registro.nombre;
                            //this.fecNaciomientoFormato = this.fechaFormato(this.registro.fechaNacimiento);
                            //this.fecNaciomiento = this.registro.fechaNacimiento;
                            //this.edad = this.registro.edad;
                            //this.rfc = this.registro.rfc;
                            //this.curp = this.registro.curp;
                            //this.plaza = this.registro.plaza;
                            //this.sucursal = this.registro.sucursal;
                            //this.fecIngresoFormato = this.fechaFormato(this.registro.fechaIngreso);
                            //this.fecIngreso = this.registro.fechaIngreso;
                            //this.genero = this.registro.genero;
                            //this.edoCivil = this.registro.estadoCivil;
                            //this.estadoCivil = this.registro.estadoCivil;
                            //this.email = this.registro.email;
                            //this.celular = this.registro.celular;
                            //this.calle = this.registro.calle;
                            //this.nointerior = this.registro.numeroInterior
                            //this.codigoPostal = this.registro.codigoPostal;
                            //this.colonia = this.registro.colonia;
                            //this.estado = this.registro.estado;
                            //this.municipio = this.registro.municipio;
                            //this.cif = this.registro.cif;
                            //this.cuentaMexicana = this.registro.cuentaMexicana;
                            //this.plazaId = this.registro.plazaId;
                            //this.sucursalId = this.registro.sucursalId;

                            this.disabled = 1;
                            

                            if (this.registro.length < 1) {
                                this.$swal.fire({
                                    text: this.$messageConstants('usuarioNoEncontrado'),
                                    icon: 'warning',
                                    confirmButtonText: 'Ok',

                                });
                            }
                            else {
                                this.totalRegistros = this.registro.length.toString();
                                this.$swal.fire({
                                    text: 'Se encontraron ' + this.registro.length + ' registros',
                                    icon: 'info',
                                    confirmButtonText: 'Ok',

                                });
}

                        })
                        .catch(error => {
                            this.$swal.fire({
                                //  text: 'Se genero un error valide con su administrador',
                                text: this.$messageConstants('usuarioNoEncontrado'),
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                            });
                            console.error('Error:', error)
                            this.disabled = 1;
                        });
                }
                //else {
                //    this.$swal.fire({
                //        text: 'Favor de capturar filtro y texto de b�squeda.',
                //        icon: 'warning',
                //        confirmButtonText: 'Ok',

                //    });
                //}
            },
            ObtenerSocioCuentaMexicana() {
                if (this.inputbusqueda != null && this.inputbusqueda != '' && this.selected != null && this.selected != '') {
                    console.log('cif', this.cif)
                    console.log('this.inputbusqueda: ', this.inputbusqueda)
                    const requestOptions = {
                        method: 'POST',
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                        body: JSON.stringify(this.inputbusqueda)
                    };
                    this.disabled = 0;
                    fetch(config.auth.server_url_api + 'api/VwUsuarioDirigentes/VwUsuarioDirigentebyCuentaMexicana', requestOptions)
                        //fetch(config.auth.server_url_api + 'api/VwInfoSocios/VwInfoSociosbyId', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {

                            this.registro = data;

                            this.apaterno = this.registro.apellidoPaterno;
                            this.amaterno = this.registro.apellidoMaterno;
                            this.nombres = this.registro.nombre;
                            this.fecNaciomientoFormato = this.fechaFormato(this.registro.fechaNacimiento);
                            this.fecNaciomiento = this.registro.fechaNacimiento;
                            this.edad = this.registro.edad;
                            this.rfc = this.registro.rfc;
                            this.curp = this.registro.curp;
                            this.plaza = this.registro.plaza;
                            this.sucursal = this.registro.sucursal;
                            this.fecIngresoFormato = this.fechaFormato(this.registro.fechaIngreso);
                            this.fecIngreso = this.registro.fechaIngreso;
                            this.genero = this.registro.genero;
                            this.edoCivil = this.registro.estadoCivil;
                            this.estadoCivil = this.registro.estadoCivil;
                            this.email = this.registro.email;
                            this.celular = this.registro.celular;
                            this.calle = this.registro.calle;
                            this.nointerior = this.registro.numeroInterior
                            this.codigoPostal = this.registro.codigoPostal;
                            this.colonia = this.registro.colonia;
                            this.estado = this.registro.estado;
                            this.municipio = this.registro.municipio;
                            this.cif = this.registro.cif;  
                            this.cuentaMexicana = this.registro.cuentaMexicana;
                            this.plazaId = this.registro.plazaId;
                            this.sucursalId = this.registro.sucursalId;

                            this.disabled = 1;

                            if (this.registro.length < 1) {
                                this.$swal.fire({
                                    text: this.$messageConstants('usuarioNoEncontrado'),
                                    icon: 'warning',
                                    confirmButtonText: 'Ok',

                                });
                            }

                        })
                        .catch(error => {
                            this.$swal.fire({
                               // text: 'Se genero un error valide con su administrador',
                                text: this.$messageConstants('usuarioNoEncontrado'),
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                            });
                            console.error('Error:', error)
                            this.disabled = 1;
                        });
                }
                //else {
                //    this.$swal.fire({
                //        text: 'Favor de capturar filtro y texto de b�squeda.',
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
            showHide: function () {
                this.show = !this.show;
            }
        },
        mounted() {
            // this.ObtenerPlaza();
            //  this.ObtenerSucursal();
            this.ObtenerPerfilCargo();

            

        }
    };
</script>