    <template>
        <b-form class="mt-auto">

            <h2>Res&uacute;men de s&uacute;bmodulos y permisos</h2>
            <hr />

            <b-row>
                <b-col cols="6" >
                    <b-form-group id="descripcion_perfil"
                                  label="Nombre"
                                  label-for="descripcionPerfil">


                        <input type="text" v-model="inputDescripcion" class="form-control" :disabled="disabledG==0">

                    </b-form-group>
                </b-col>
            </b-row>

            <div class="overflow-auto">

                <b-row class="justify-content-md-center sm-3">
                    <b-col col-4>
                        <div class="input-group input-group-sm ">
                            <b-form-input v-model="filter"
                                          type="search"
                                          placeholder="Ingresa el dato"></b-form-input>
                            <b-button size="sm">
                                <i class="fa-solid fa-magnifying-glass"> </i>
                                Buscar
                            </b-button>
                        </div>
                    </b-col>
                    <b-col>
                    </b-col>
                </b-row>
                <br />


                <b-table outlined
                         small
                         hover
                         fixed
                         id="my-table"
                         no-border-collapse
                         :per-page="perPage"
                         :current-page="currentPage"
                         :items="items"
                         :fields="fields"
                         head-variant="light"
                         :sort-desc.sync="sortDesc"
                         responsive="sm"
                         :filter="filter"
                         class="text-center"
                         @filtered="onFiltered">

                    <template #cell(todos)="data">
                        <b-form-checkbox v-model="data.item.todos"
                                         name="todos" :disabled="disabled == 1">

                        </b-form-checkbox>
                    </template>


                    <template #cell(crear)="data">
                        <b-form-checkbox v-model="data.item.crear"
                                         name="crear" :disabled="disabled == 1">

                        </b-form-checkbox>
                    </template>

                    <template #cell(editar)="data">
                        <b-form-checkbox v-model="data.item.editar"
                                         name="editar" :disabled="disabled == 1">

                        </b-form-checkbox>
                    </template>

                    <template #cell(consultar)="data">
                        <b-form-checkbox v-model="data.item.consultar"
                                         name="consultar" :disabled="disabled == 1">

                        </b-form-checkbox>
                    </template>


                    <template #cell(eliminar)="data">
                        <b-form-checkbox v-model="data.item.eliminar"
                                         name="eliminar" :disabled="disabled == 1">

                        </b-form-checkbox>
                    </template>


                    <template #cell(descargar)="data">
                        <b-form-checkbox v-model="data.item.descargar"
                                         name="descargar" :disabled="disabled == 1">

                        </b-form-checkbox>
                    </template>

                    <template #cell(cargar)="data">
                        <b-form-checkbox v-model="data.item.cargar"
                                         name="cargar" :disabled="disabled == 1">

                        </b-form-checkbox>
                    </template>

                    <template #cell(autorizar)="data">
                        <b-form-checkbox v-model="data.item.autorizar"
                                         name="autorizar" :disabled="disabled == 1">

                        </b-form-checkbox>
                    </template>


                    <template #cell(historico)="data">
                        <b-form-checkbox v-model="data.item.historico"
                                         name="historico" :disabled="disabled == 1">

                        </b-form-checkbox>
                    </template>

                </b-table>
                <b-pagination v-model="currentPage"
                              :total-rows="rows"
                              :per-page="perPage"
                              aria-controls="my-table"
                              size="sm"
                              align="center"
                              first-text="Primero"
                              prev-text="Anterior"
                              next-text="Siguiente"
                              last-text="Ultimo">
                </b-pagination>
            </div>

            <b-row class="mt-4">

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
            name: "PermisoModal",
            props: {
                id: Number,
            },
            data() {
                return {
                    usuario: {},
                    registro: {},
                    selectedPerfil: null,
                    optPerfiles: [],
                    fechaNacimientoOriginal: '',
                    fechaIngresoOriginal: '',

                    //Submodulo //

                    idSubModulo: '',
                    descripcionSubmodulo: '',
                    estatusSubModulo: '',

                    //Perfil

                    idPerfilCargo: '',
                    descripcionPerfil: '',
                    estatusPerfil: '',
                    ordenCargo: '',
                    esCargo: '',

                    //Permiso

                    idPermiso: '',
                    todos: '',
                    crear: '',
                    editar: '',
                    consultar: '',
                    eliminar: '',
                    descargar: '',
                    cargar: '',
                    autorizar: '',
                    historico: '',
                    estatusPermiso: '',
                    disabled: 1,
                    inputDescripcion: '',
                    disabledG: 0,

                    // nuevo

                    fields: [
                      //  { key: 'idPermiso', label: 'Id' },
                        //  { key: 'descripcionPerfil', label: 'Perfil' },
                      //  { key: 'descripcionModulo', label: 'Modulo', sortable: true },
                        { key: 'descripcionSubmodulo', label: 'Subm\u00F3dulo', sortable: true },
                        { key: 'todos', label: 'Todos', sortable: true },
                        { key: 'crear', label: 'Crear', sortable: true },
                        { key: 'editar', label: 'Editar', sortable: true },
                        { key: 'consultar', label: 'Consultar', sortable: true },
                        { key: 'eliminar', label: 'Deshabilitar', sortable: true },
                        { key: 'descargar', label: 'Descargar', sortable: true },
                        { key: 'cargar', label: 'Cargar', sortable: true },
                        { key: 'autorizar', label: 'Autorizar', sortable: true },
                        { key: 'historico', label: 'Hist\u00F3rico', sortable: true },
                        // { key: 'esCargo', label: 'Es Cargo' },
                        // { key: 'ordenCargo', label: 'Orden Cargo' },
                        // { key: 'estatusPermiso', label: 'Estatus' } 
                    ],
                    items: [],
                    //id: 0,
                    tableHeader: "",
                    perPage: 10,  //Numero de registros por pagina
                    sortDesc: false,
                    filter: null,
                    showSuccessAlert: false,
                    alertMessage: "",
                    currentPage: 1,

                };
            },
            mounted() {
                this.getByID();
             //   this.ObtenerPerfilCargo();
            },
            methods: {
                triggerClose() {
                    this.$emit("closePermisoModal");
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
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                        body: JSON.stringify(this.id)
                    };

                    console.log("this.id ", this.id)
                    //fetch(config.auth.server_url_api + 'api/PerfilCargos/ConsultarPermisobyCorreoAcceso', requestOptions)
                     
                    fetch(config.auth.server_url_api + 'api/PerfilCargos/ConsultarPermisobyIdPerfil', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {
                          //  debugger
                            this.items = data;

                            this.registro = data;

                          //  this.idModulo = this.registro.idModulo;
                           // this.descripcionModulo = this.registro.descripcionModulo;
                           // this.estatusModulo = this.registro.estatusModulo;
                          //  this.idSubModulo = this.registro.idSubModulo;
                            this.descripcionSubmodulo = this.registro.descripcionSubmodulo;
                           // this.estatusSubModulo = this.registro.estatusSubModulo;
                           // this.idPerfilCargo = this.registro.idPerfilCargo;
                           // this.descripcionPerfil = this.registro.descripcionPerfil;
                           // this.estatusPerfil = this.registro.estatusPerfil;
                           // this.ordenCargo = this.registro.ordenCargo;
                           // this.esCargo = this.registro.esCargo;
                           // this.idPermiso = this.registro.idPermiso;
                            this.todos = this.registro.todos;
                            this.crear = this.registro.crear;
                            this.editar = this.registro.editar;
                            this.consultar = this.registro.consultar;
                            this.eliminar = this.registro.eliminar;
                            this.descargar = this.registro.descargar;
                            this.cargar = this.registro.cargar;
                            this.autorizar = this.registro.autorizar;
                            this.historico = this.registro.historico;
                           // this.estatusPermiso = this.registro.estatusPermiso;

                            this.inputDescripcion = this.registro[0].descripcionPerfil;
                        })
                        .catch(error => {
                            console.error('Error:', error)
                        });
                },
                update() {

                    debugger
                    this.usuario.fechaNacimiento = this.fechaNacimientoOriginal;
                    this.usuario.fechaIngreso = this.fechaIngresoOriginal;
                    this.usuario.idPErfil = this.selectedPerfil;
                    const requestOptions = {
                    method: 'POST',
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },// CAMBIO SEGURIDAD
                    body: JSON.stringify(this.usuario)
                    };
                    console.log("usuario:", this.usuario)
                    fetch(config.auth.server_url_api + 'api/Usuarios/ActualizarUsuarioPersonaPerfilNew', requestOptions)
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
            computed: {
                rows() {
                    return this.items.length
                }
            }
        };
    </script>
