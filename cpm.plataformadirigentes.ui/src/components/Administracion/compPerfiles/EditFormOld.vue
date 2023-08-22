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
                                      v-model="usuario.apellidoPaterno" disabled="false"></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="apellido_materno"
                                  label="Apellido Materno"
                                  label-for="apellidoMaterno">

                        <b-form-input id="apellidoMaterno"
                                      type="text"
                                      v-model="usuario.apellidoMaterno" disabled="false"></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="nombres_"
                                  label="Nombres"
                                  label-for="nombres">

                        <b-form-input id="nombres"
                                      type="text"
                                      v-model="usuario.nombrePersona" disabled="false"></b-form-input>
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
                                      v-model="usuario.fechaNacimiento" disabled="false"></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="edad_"
                                  label="Edad"
                                  label-for="edad">

                        <b-form-input id="edad"
                                      type="text"
                                      v-model="usuario.edad" disabled="false"></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="rfc_"
                                  label="Rfc"
                                  label-for="rfc">

                        <b-form-input id="rfc"
                                      type="text"
                                      v-model="usuario.rfc" disabled="false"></b-form-input>
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
                                      v-model="usuario.curp" disabled="false"></b-form-input>
                    </b-form-group>
                </b-col>

            </b-row>

            <b-row>
                <b-col cols="4">
                    <b-form-group id="plaza_"
                                  label="Plaza"
                                  label-for="plaza">

                        <b-form-input id="plaza"
                type="text"
                v-model="usuario.Plaza" disabled="false"></b-form-input>

                     
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="sucursal_"
                                  label="Sucursal"
                                  label-for="sucursal">

                        <b-form-input id="sucursal"
                type="text"
                v-model="usuario.Sucursal" disabled="false"></b-form-input>

                       
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="fecha_Ingreso"
                                  label="Fecha Ingreso"
                                  label-for="fechaIngreso">

                        <b-form-input id="fechaIngreso"
                                      type="text"
                                      v-model="usuario.fechaIngreso" disabled="false"></b-form-input>
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
                                      v-model="usuario.genero" disabled="false"></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="estado_civil"
                                  label="Estado Civil"
                                  label-for="estadoCivil">

                        <b-form-input id="estadoCivil"
                                      type="text"
                                      v-model="usuario.estadoCivil" disabled="false"></b-form-input>
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
                                      v-model="usuario.correoAcceso" disabled="false"></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="celular_"
                                  label="Celular"
                                  label-for="celular">

                        <b-form-input id="celular"
                                      type="text"
                                      v-model="usuario.celular" disabled="false"></b-form-input>
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
                                      v-model="usuario.calle" disabled="false">  </b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="numerointerior_"
                                  label="Numero interior"
                                  label-for="numeroInterior" disabled="false">

                        <b-form-input id="numerointerior"
                                      type="text"
                                      v-model="usuario.numeroInterior" disabled="false"></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="codigopostal_"
                                  label="Codigo postal"
                                  label-for="codigoPostal">

                        <b-form-input id="codigopostal"
                                      type="text"
                                      v-model="usuario.codigoPostal" disabled="false"></b-form-input>
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
                                      v-model="usuario.colonia" disabled="false">  </b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="estado_"
                                  label="Estado"
                                  label-for="estado">

                        <b-form-input id="estado"
                                      type="text"
                                      v-model="usuario.estado" disabled="false"></b-form-input>
                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="municipio_"
                                  label="Municipio"
                                  label-for="municipio">

                        <b-form-input id="municipio"
                                      type="text"
                                      v-model="usuario.municipio" disabled="false"></b-form-input>
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


                        <b-form-input id="idPerfil"
                                      type="text"
                                      v-model="usuario.perfil" contenteditable="false"></b-form-input>


                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="correo_acceso"
                                  label="Correo acceso"
                                  label-for="correoAcceso">

                        <b-form-input id="correoAcceso"
                                      type="text"
                                      v-model="usuario.correoAcceso" contenteditable="false"></b-form-input>


                    </b-form-group>
                </b-col>

                <b-col cols="4">
                    <b-form-group id="estatus"
                                  label="Estatus"
                                  label-for="estatus">

                        <b-form-input id="estatus"
                                      type="text"
                                      v-model="usuario.estatusPerfil" disabled="false"></b-form-input>


                    </b-form-group>
                </b-col>
            </b-row>

            <b-row>
                <b-col cols="12">
                    <b-form-checkbox id="estatus_usuario"
                                     v-model="usuario.estatusUsuario"
                                     name="usuario-status"
                                     
                                     >
                        Usuario es Activo
                    </b-form-checkbox>
                </b-col>

            </b-row>
            <b-row class="mt-4">
                <b-col cols="3">
                    <b-button variant="success" @click="update">Guardar</b-button>
                </b-col>
                <b-col>
                    <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
                </b-col>
            </b-row>
        </b-form>
    </template>

    <script>
        import { config } from "@/config/auth";


        export default {
            name: "EditModal",
            props: {
                id: Number,
            },
            data() {
                return {
                    usuario: {},
                };
            },
            mounted() {
                this.getByID();
            },
            methods: {
                triggerClose() {
                    this.$emit("closeEditModal");
                },
                getByID() {
                    const requestOptions = {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify(this.id)
                    };


                    fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilbyId', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {
                            debugger
                            this.usuario = data;

                            this.usuario.fechaNacimiento = this.fechaFormato(this.usuario.fechaNacimiento);
                            this.usuario.fechaIngreso = this.fechaFormato(this.usuario.fechaIngreso);
                           // this.fecNaciomiento = this.registro.fecNacD;
                            console.log("usuario:", this.usuario)

                        })
                        .catch(error => {
                            console.error('Error:', error)
                        });
                },
                update() {
                    const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(this.usuario)
                };
                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioUpdate', requestOptions)
                    .then(async response => {
                       
                        if (response.status == 200) {
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
