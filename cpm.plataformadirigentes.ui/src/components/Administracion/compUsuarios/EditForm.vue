    <template>
        <b-form class="mt-auto">

            <h2>Datos Generales: </h2>
            <hr />
            <b-row>
                <b-col cols="4">
                    <b-form-group id="apellido_paterno"
                                  label="Apellido Paterno"
                                  label-for="apellidoPaterno">

                        <b-form-input id="apellidoPaterno"
                                      type="text"
                                      v-model="usuario.apellidoPaterno" disabled ></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="apellido_materno"
                                  label="Apellido Materno"
                                  label-for="apellidoMaterno">

                        <b-form-input id="apellidoMaterno"
                                      type="text"
                                      v-model="usuario.apellidoMaterno" disabled ></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="nombres_"
                                  label="Nombres"
                                  label-for="nombres">

                        <b-form-input id="nombres"
                                      type="text"
                                      v-model="usuario.nombrePersona" disabled ></b-form-input>
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
                                      v-model="usuario.fechaNacimiento" disabled ></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="edad_"
                                  label="Edad"
                                  label-for="edad">

                        <b-form-input id="edad"
                                      type="text"
                                      v-model="usuario.edad" disabled ></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="rfc_"
                                  label="Rfc"
                                  label-for="rfc">

                        <b-form-input id="rfc"
                                      type="text"
                                      v-model="usuario.rfc" disabled ></b-form-input>
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
                                      v-model="usuario.curp" disabled></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="cif_"
                                  label="CIF"
                                  label-for="cif">

                        <b-form-input id="cif"
                                      type="text"
                                      v-model="usuario.cif" disabled></b-form-input>


                    </b-form-group>
                </b-col>

                <!--<b-col cols="4">
        <b-form-group id="iddirigente_"
                      label="ID Dirigente"
                      label-for="iddirigente">

            <b-form-input id="iddirigente"
                          type="text"
                          v-model="usuario.idDirigente"  ></b-form-input>
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
                v-model="usuario.plaza" disabled ></b-form-input>

                     
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="sucursal_"
                                  label="Sucursal"
                                  label-for="sucursal">

                        <b-form-input id="sucursal"
                type="text"
                v-model="usuario.sucursal" disabled ></b-form-input>

                       
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="fecha_Ingreso"
                                  label="Fecha Ingreso"
                                  label-for="fechaIngreso">

                        <b-form-input id="fechaIngreso"
                                      type="text"
                                      v-model="usuario.fechaIngreso" disabled ></b-form-input>
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
                                      v-model="usuario.genero" disabled></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="estado_civil"
                                  label="Estado Civil"
                                  label-for="estadoCivil">

                        <b-form-input id="estadoCivil"
                                      type="text"
                                      v-model="usuario.estadoCivil" disabled ></b-form-input>
                    </b-form-group>
                </b-col>


            </b-row>

            <b-row>
                <b-col cols="4">
                    <b-form-group id="correo_acceso"
                                  label="Correo"
                                  label-for="correoAcceso">

                        <b-form-input id="email"
                                      type="text"
                                      v-model="usuario.email" disabled></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="celular_"
                                  label-for="celular">
                        <label>N&uacute;mero de tel&eacute;fono </label>
                        <b-form-input id="celular"
                                      type="text"
                                      v-model="usuario.celular" disabled></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="cuentaMexicana_"
                                  label="Cuenta Mexicana"
                                  label-for="cuentamexicana">

                        <b-form-input id="cuentaMexicana"
                                      type="text"
                                      v-model="usuario.cuentaMexicana" disabled></b-form-input>
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
                                      v-model="usuario.calle" disabled >  </b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="numerointerior_"
                                  label-for="numeroInterior" disabled>
                        <label>N&uacute;mero </label>
                        <b-form-input id="numerointerior"
                                      type="text"
                                      v-model="usuario.numeroInterior" disabled></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="codigopostal_"
                                  label-for="codigoPostal">
                        <label>C&oacute;digo Postal </label>
                        <b-form-input id="codigopostal"
                                      type="text"
                                      v-model="usuario.codigoPostal" disabled></b-form-input>
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
                                      v-model="usuario.colonia" disabled >  </b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="estado_"
                                  label="Estado"
                                  label-for="estado">

                        <b-form-input id="estado"
                                      type="text"
                                      v-model="usuario.estado" disabled ></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="municipio_"
                                  label="Municipio"
                                  label-for="municipio">

                        <b-form-input id="municipio"
                                      type="text"
                                      v-model="usuario.municipio" disabled ></b-form-input>
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


                        <!--<b-form-input id="idPerfil"
                  type="text"
                  v-model="usuario.perfil" contenteditable="false"></b-form-input>-->

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
                                      v-model="usuario.correoAcceso" contenteditable="false" @input="validateEmail"></b-form-input>
                        <p v-if="error" class="error">{{ error }}</p>


                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="estatus"
                                  label="Estatus"
                                  label-for="estatus">

                        <b-form-checkbox id="estatus_usuario"
                                         v-model="usuario.estatusUsuario"
                                         name="estatus_usuario">
                            Usuario es Activo
                        </b-form-checkbox>


                    </b-form-group>
                </b-col>
            </b-row>

            <!--<b-row>
                <b-col cols="12">
                    <b-form-checkbox id="estatus_usuario"
                                     v-model="usuario.estatusUsuario"
                                     name="usuario-status"
                                     
                                     >
                        Usuario es Activo
                    </b-form-checkbox>
                </b-col>

            </b-row>-->
            <b-row class="mt-4">
                <b-col cols="3">
                    <b-button variant="success" @click="validaExistenciaByCorreoAcceso">Guardar</b-button>
                </b-col>

                <b-col cols="1">
                    <div class="text-center" id="divSpinner" v-if="disabledG==0">
                        <b-spinner variant="success" label="Spinning"></b-spinner>
                    </div>
                </b-col>

                <b-col>
                    <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
                </b-col>
            </b-row>
        </b-form>
    </template>

    <script>
                import { config } from "@/config/auth";
        import store from '@/store'; 

        export default {
            name: "EditModal",
            props: {
                id: Number,
            },
            data() {
                return {
                    disabledG: 1,
                    usuario: {},
                    usuarioLog: {},
                    selectedPerfil: null,
                    optPerfiles: [],
                    fechaNacimientoOriginal: '',
                    fechaIngresoOriginal: '',
                    correoAcceso: '',
                    correoAccesoBusqueda: '',
                    cif: '',
                    cifBusqueda: '',
                };
            },
            mounted() {
                this.getByID();
                this.ObtenerPerfilCargo();
            },
            methods: {
                validateEmail() {
                    let emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                    if (!emailRegex.test(this.correoAcceso)) {
                        this.error = 'Favor de ingresar un Email v\u00E1lido, p.ej. usuario@dominio.com';
                    } else {
                        this.error = '';
                    }
                },

                triggerClose() {
                    this.$emit("closeEditModal");
                },
                validaExistenciaByCorreoAcceso() {
                    const requestOptions = {
                        method: 'POST',
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                        body: JSON.stringify(this.usuario.correoAcceso)
                    };


                    fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilbyCorreoAcceso', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {

                            this.usuarioBusqueda = data;

                            //this.correoAccesoBusqueda = this.usuarioBusqueda.cif;// == null ? 0 : this.usuarioBusqueda.cif;
                            this.correoAccesoBusqueda = this.usuarioBusqueda.correoAcceso;// == null ? 0 : this.usuarioBusqueda.cif;
                            this.cifBusqueda = this.usuarioBusqueda.cif;// == null ? 0 : this.usuarioBusqueda.cif;
                            console.log("usuario:", this.usuarioBusqueda)

                            console.log('this.correoAceso', this.correoAcceso)

                            if (this.correoAcceso == '') { this.correoAccesoBusqueda == '' }

                            let emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                            console.log('correoAccesoBusqueda', this.correoAccesoBusqueda)
                            console.log('usuario.correoAcceso', this.usuario.correoAcceso)
                            console.log('cifBusqueda', this.cifBusqueda)
                            console.log('usuario.cif', this.usuario.cif)
                            console.log('emailRegex.test(this.correoAcceso)', emailRegex.test(this.usuario.correoAcceso))

                            if ((this.correoAccesoBusqueda == '' || this.correoAccesoBusqueda == null || this.correoAccesoBusqueda == 0 || (this.correoAccesoBusqueda == this.usuario.correoAcceso && this.cifBusqueda == this.usuario.cif)) && emailRegex.test(this.usuario.correoAcceso)) {
                                //if ((this.correoAccesoBusqueda == '' || this.correoAccesoBusqueda == null || this.correoAccesoBusqueda == 0 || this.correoAccesoBusqueda == this.usuario.correoAcceso)) {
                                this.update();
                                //this.validaExistenciaByCorreoAcceso

                            }
                            else {
                                this.$swal.fire({
                                    text: 'Ya existe un registro con el Correo de Acceso ingresado o el Correo de Acceso es incorrecto, favor de validar',
                                    icon: 'warning',
                                    confirmButtonText: 'Ok',

                                });
                            }

                        })
                   
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
                getByID() {
                    const requestOptions = {
                        method: 'POST',
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, //CAMBIO SEGURIDAD
                        body: JSON.stringify(this.id)
                    };


                    fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilbyId', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {
                          //  debugger
                            this.usuario = data;

                            this.fechaNacimientoOriginal = this.usuario.fechaNacimiento;
                            this.fechaIngresoOriginal = this.usuario.fechaIngreso;

                            this.usuario.fechaNacimiento = this.fechaFormato(this.usuario.fechaNacimiento);
                            this.usuario.fechaIngreso = this.fechaFormato(this.usuario.fechaIngreso);
                           // this.fecNaciomiento = this.registro.fecNacD;

                           
                            console.log("usuario:", this.usuario)
                            this.selectedPerfil = this.usuario.idPerfil;
                        })
                        .catch(error => {
                            console.error('Error:', error)
                        });
                },
                update() {

                    console.log('this.correoAcceso', this.correoAcceso)
                    console.log('this.usuariocorreoAcceso', this.usuario.correoAcceso)
                    console.log('this.selectedPerfil', this.selectedPerfil)
                    if (this.selectedPerfil != null && this.selectedPerfil != '' && this.usuario.correoAcceso != null && this.usuario.correoAcceso != '') {

                        this.disabledG = 0;

                    this.usuario.fechaNacimiento = this.fechaNacimientoOriginal;
                    this.usuario.fechaIngreso = this.fechaIngresoOriginal;
                        this.usuario.idPerfil = this.selectedPerfil;
                    
                    const requestOptions = {
                    method: 'POST',
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                    body: JSON.stringify(this.usuario)
                    };
                    console.log("usuario:", this.usuario)
                    fetch(config.auth.server_url_api + 'api/Usuarios/ActualizarUsuarioPersonaPerfilNew', requestOptions)
                    .then(async response => {
                       
                        if (response.status == 200) {
                            //this.addNewLog();
                            this.$emit("closeEditModal");
                            this.$emit("reloadDataTable");
                             this.$emit("showSuccessAlert");
                        }
                        else {
                             this.$swal.fire({
                                text: 'Se genero un error al editar el usuario valide con su administrador',
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
                },
                addNewLog() {

                    this.usuarioLog.idModulo = 2;
                    this.usuarioLog.idSubModulo = 2;
                    this.usuarioLog.tipoMovimiento = 'Actualizacion';
                    this.usuarioLog.descripcion = 'Id: ' + this.usuario.idUsuario + ' Cif: ' + this.usuario.cif + ' Nombre: ' + this.usuario.nombrePersona + ' ' + this.usuario.apellidoPaterno + ' ' + this.usuario.apellidoMaterno + ' Correo: ' + this.usuario.correoAcceso + ' Perfil: ' + this.usuario.idPerfil + ' Estatus: ' + this.usuario.estatusUsuario;
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
        };
    </script>
