    <template>
        <div>
            <b-row>
                <b-col cols="6">
                    <b-form-group id="descripcion_perfil"
                                  label="Nombre"
                                  label-for="descripcionPerfil">


                        <input type="text" v-model="inputDescripcion" class="form-control"  >

                    </b-form-group>
                </b-col>
            </b-row>

            <b-card-text>
                <b-row>
                    <b-col class="col-8">
                        <h3>{{ tableHeader}}</h3>
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

                        <template #cel(idPermiso)="data">
                            {{
                        `${data.item.idPermiso} ${data.item.idPerfilCargo}`
                            }}


                        </template>

                        <template #cell(todos)="data">
                            <b-form-checkbox v-model="data.item.todos"
                                             name="todos">

                            </b-form-checkbox>
                        </template>



                        <template #cell(crear)="data">
                            <b-form-checkbox v-model="data.item.crear"
                                             name="crear">

                            </b-form-checkbox>
                        </template>


                        <template #cell(editar)="data">
                            <b-form-checkbox v-model="data.item.editar"
                                             name="editar">

                            </b-form-checkbox>
                        </template>


                        <template #cell(consultar)="data">
                            <b-form-checkbox v-model="data.item.consultar"
                                             name="consultar">

                            </b-form-checkbox>
                        </template>



                        <template #cell(eliminar)="data">
                            <b-form-checkbox v-model="data.item.eliminar"
                                             name="eliminar">

                            </b-form-checkbox>
                        </template>


                        <template #cell(descargar)="data">
                            <b-form-checkbox v-model="data.item.descargar"
                                             name="descargar">

                            </b-form-checkbox>
                        </template>



                        <template #cell(cargar)="data">
                            <b-form-checkbox v-model="data.item.cargar"
                                             name="cargar">

                            </b-form-checkbox>
                        </template>


                        <template #cell(autorizar)="data">
                            <b-form-checkbox v-model="data.item.autorizar"
                                             name="autorizar">

                            </b-form-checkbox>
                        </template>



                        <template #cell(historico)="data">
                            <b-form-checkbox v-model="data.item.historico"
                                             name="historico">

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

            </b-card-text>


            <b-row class="mt-4">
                <b-col cols="3">
                    <b-button variant="success" @click="validaExistenciaByNombre">Guardar</b-button>
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
        </div>
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
                    usuarioLog: {},
                    disabledG: 1,
                    registro: {},
                    perfilBusqueda: {},
                    nombrePerfilBusqueda: '',
                    idModulo: '',
                    descripcionModulo: '',
                    estatusModulo: '',

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
                    inputDescripcion: '',
                    asignaPermisos: 'No',
                    idPerfilBusqueda:'',
                     

                    // nuevo

                    fields: [
                      //  { key: 'idPermiso', label: 'Id' },
                        //  { key: 'descripcionPerfil', label: 'Perfil' },
                        { key: 'descripcionModulo', label: 'M\u00F3dulo', sortable: true },
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
            },
            methods: {
                triggerClose() {
                    this.$emit("closeEditModal");
                },
                validaExistenciaByNombre() {

                    //this.validaExistenciaByCorreoAcceso();

                    console.log("registro update", this.registro)

                    const requestOptions = {
                        method: 'POST',
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },//CAMBIO SEGURIDAD
                        body: JSON.stringify(this.inputDescripcion)
                    };


                    fetch(config.auth.server_url_api + 'api/PerfilCargos/PerfilCargobyNombre', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {

                            this.perfilBusqueda = data;

                            this.nombrePerfilBusqueda = this.perfilBusqueda.descripcion;
                            this.idPerfilBusqueda = this.perfilBusqueda.idPerfilCargo;

                            console.log("this.nombrePerfilBusqueda", this.nombrePerfilBusqueda)
                            console.log("this.inputDescripcion", this.inputDescripcion)
                            if (this.nombrePerfilBusqueda == '' || this.nombrePerfilBusqueda == null || (this.nombrePerfilBusqueda == this.inputDescripcion && this.idPerfilBusqueda == this.registro[0].idPerfilCargo)) {

                                this.update();
                                // this.validaExistenciaByCorreoAcceso();

                            }
                            else {
                                this.$swal.fire({
                                    text: 'Ya existe un registro con el Nombre ingresado, favor de validar',
                                    icon: 'warning',
                                    confirmButtonText: 'Ok',

                                });
                            }

                        })

                },
                getByID() {
                    const requestOptions = {
                        method: 'POST',
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },//CAMBIO SEGURIDAD
                        body: JSON.stringify(this.id)
                    };


                    fetch(config.auth.server_url_api + 'api/PerfilCargos/PerfilPermisobyId', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {
                           // debugger
                            this.items = data;

                            this.registro = data;

                            console.log("registroPerfilPermisobyId", this.registro)

                            this.idModulo = this.registro.idModulo;
                            this.descripcionModulo = this.registro.descripcionModulo;
                            this.estatusModulo = this.registro.estatusModulo;
                            this.idSubModulo = this.registro.idSubModulo;
                            this.descripcionSubmodulo = this.registro.descripcionSubmodulo;
                            this.estatusSubModulo = this.registro.estatusSubModulo;
                            this.idPerfilCargo = this.registro.idPerfilCargo;
                            this.descripcionPerfil = this.registro.descripcionPerfil;
                            this.estatusPerfil = this.registro.estatusPerfil;
                            this.ordenCargo = this.registro.ordenCargo;
                            this.esCargo = this.registro.esCargo;
                            this.idPermiso = this.registro.idPermiso;
                            this.todos = this.registro.todos;
                            this.crear = this.registro.crear;
                            this.editar = this.registro.editar;
                            this.consultar = this.registro.consultar;
                            this.eliminar = this.registro.eliminar;
                            this.descargar = this.registro.descargar;
                            this.cargar = this.registro.cargar;
                            this.autorizar = this.registro.autorizar;
                            this.historico = this.registro.historico;
                            this.estatusPermiso = this.registro.estatusPermiso;

                            this.inputDescripcion = this.registro[0].descripcionPerfil;
                            console.log("inputDescripcion", this.inputDescripcion)

                        })
                        .catch(error => {
                            console.error('Error:', error)
                        });
                },
                update() {
                    this.disabledG = 0;
                    this.asignaPermisos = 'No'

                    //valida total de permisos asignados
                    for (let i = 0; i < this.registro.length; i++) {
                        //console.log(this.registro[i].descripcionPerfil);
                        if (this.registro[i].todos == true || this.registro[i].crear == true || this.registro[i].editar == true || this.registro[i].consultar == true || this.registro[i].eliminar == true || this.registro[i].descargar == true || this.registro[i].cargar == true || this.registro[i].autorizar == true || this.registro[i].historico == true) {
                            this.asignaPermisos = 'Si';

                        }
                        // else{}
                    }

                    //Actualiza nombre perfil
                    for (let i = 0; i < this.registro.length; i++) {
                        this.registro[i].descripcionPerfil = this.inputDescripcion;
                    }

                    if (this.inputDescripcion != null && this.inputDescripcion.trim() != '') {

                    if (this.asignaPermisos == 'Si') {

                    const requestOptions = {
                    method: 'POST',
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },//CAMBIO SEGURIDAD
                    body: JSON.stringify(this.registro)
                };
                    fetch(config.auth.server_url_api + 'api/PerfilCargos/PerfilPermisoUpdate', requestOptions)
                    .then(async response => {
                       
                        if (response.status == 200) {
                           // this.addNewLog();
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
                        this.disabledG = 1;
                        this.$swal.fire({
                            text: 'Favor de capturar al menos un permiso',
                            icon: 'warning',
                            confirmButtonText: 'Ok',

                        });
                        }

                    }
                    else {
                        this.disabledG = 1;
                        this.$swal.fire({
                            text: 'Favor de capturar Nombre',
                            icon: 'warning',
                            confirmButtonText: 'Ok',

                        });
                    }
                },
                addNewLog() {

                    this.usuarioLog.idModulo = 1;
                    this.usuarioLog.idSubModulo = 1;
                    this.usuarioLog.tipoMovimiento = 'Actualizacion';
                    this.usuarioLog.descripcion = 'Id: ' + this.id + ' Nombre: ' + this.registro[0].descripcionPerfil + ' EsCargo: ' + this.registro[0].esCargo + ' OrdenCargo: ' + this.registro[0].ordenCargo;
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
            computed: {
                rows() {
                    return this.items.length
                }
            }
        };
    </script>
