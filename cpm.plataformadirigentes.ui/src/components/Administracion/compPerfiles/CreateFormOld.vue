<template>
    <div>
        <!-- Código HTML -->
        <b-card-text>
            <b-row>
                <b-col class="col-8">
                    <h3>{{ tableHeader}}</h3>
                </b-col>
                <b-col class="col-4">

                    <b-button-group size="sm">
                        <b-button variant="outline-success"
                                  id="export-btn"
                                  @click="showCreateModal">
                            <i class="fa-solid fa-file-excel"></i> Exportar
                        </b-button>
                        <b-button variant="outline-success"
                                  id="show-btn"
                                  @click="showCreateModal">
                            <i class="fa-solid fa-plus"></i> Nuevo
                        </b-button>
                    </b-button-group>

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

                    <template #cell(estatusPermiso)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.estatusPermiso === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>


                    <template #cell(esCargo)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.esCargo === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>

                    <template #cell(todos)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.todos === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>
                    <template #cell(crear)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.crear === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>
                    <template #cell(editar)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.editar === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>
                    <template #cell(consultar)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.consultar === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>
                    <template #cell(eliminar)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.eliminar === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>
                    <template #cell(descargar)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.descargar === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>
                    <template #cell(cargar)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.cargar === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>
                    <template #cell(autorizar)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.autorizar === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>
                    <template #cell(historico)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.historico === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>


                    <template v-slot:cell(acciones)="data">
                        <b-row>
                            <b-icon-pencil-square class="action-item mx-1"
                                                  size="sm" variant="primary"
                                                  @click="getRowData(data.item.idPermiso)">
                            </b-icon-pencil-square>

                            <b-icon-trash-fill class="action-item mx-1"
                                               size="sm" variant="danger"
                                               @click="showDeleteModal(data.item.idPermiso)">
                            </b-icon-trash-fill>
                        </b-row>
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

        <!--Modal for add-->
        <b-modal ref="create-modal"
                 hide-footer
                 title="Nuevo Perfil"
                 size="lg"
                 header-bg-variant="success"
                 header-text-variant="light"
                 body-bg-variant="light"
                 no-stacking>
            <create-form @closeCreateModal="closeCreateModal"
                         @reloadDataTable="getData"
                         @showSuccessAlert="showAlertCreate"></create-form>
        </b-modal>
        <!--Modal for updating-->
        <b-modal ref="edit-modal"
                 hide-footer
                 title="Editar Perfil"
                 size="lg"
                 header-bg-variant="success"
                 header-text-variant="light"
                 body-bg-variant="light"
                 no-stacking>
            <edit-form @closeEditModal="closeEditModal"
                       @reloadDataTable="getData"
                       @showSuccessAlert="showAlertUpdate"
                       :id="id">
            </edit-form>
        </b-modal>
        <!--Delete Modal-->
        <b-modal ref="delete-modal"
                 size="md"
                 hide-footer
                 title="Confirmar Baja">
            <delete-modal @closeDeleteModal="closeDeleteModal"
                          @reloadDataTable="getData"
                          @showDeleteAlert="showDeleteSuccessModal"
                          :id="id"></delete-modal>
        </b-modal>
    </div>

</template>

<template>

   

    <b-form class="mt-auto">

  

        <b-row>

            <b-col cols="4">
                <b-form-group id="Tipo"
                              label="Tipo"
                              label-for="Tipo">

                    <b-form-select v-model="selected" size="sm" :options="optionsfitro"></b-form-select>

                </b-form-group>
            </b-col>

            <!--<b-col cols="2"><h5>Tipo:</h5></b-col>
        <b-col cols="4">
            <b-form-select v-model="selected" size="sm" :options="optionsfitro"></b-form-select>
        </b-col>-->

            <b-col cols="6">
                <b-form-group id="descripcion_perfil"
                              label="Nombre"
                              label-for="descripcionPerfil">

                    <b-form-input id="descripcionPerfil"
                                  type="text"
                                  v-model="descripcionPerfil"></b-form-input>

                </b-form-group>
            </b-col>

        </b-row>
        <hr />

        <!--<h2>Nombre: </h2>
    <hr />
    <b-row>
        <b-col cols="4">
            <b-form-group id="descripcion_perfil"
                          label="Nombre"
                          label-for="descripcionPerfil">

                <b-form-input id="descripcionPerfil"
                              type="text"
                              v-model="descripcionPerfil"  ></b-form-input>

            </b-form-group>
        </b-col>

    </b-row>-->


        <h2>Configuracion: </h2>
        <hr />

        <b-row>
            <b-col cols="4">
                <b-form-group id="idpermiso_"
                              label="Id"
                              label-for="idpermiso">

                    <b-form-input id="idPermiso"
                                  type="text"
                                  v-model="idPermiso" disabled></b-form-input>

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="descripcionmodulo_"
                              label="Modulo"
                              label-for="descripcionModulo">

                    <b-form-input id="descripcionModulo"
                                  type="text"
                                  v-model="descripcionModulo" disabled></b-form-input>

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="descripcionsubmodulo_"
                              label="Submodulo"
                              label-for="descripcionSubmodulo">

                    <b-form-input id="descripcionSubmodulo"
                                  type="text"
                                  v-model="descripcionSubmodulo" disabled></b-form-input>

                </b-form-group>
            </b-col>


        </b-row>

        <b-row>
            <b-col cols="4">
                <b-form-group id="todos_"
                              label="Todos"
                              label-for="todos">

                    <b-form-input id="todos"
                                  type="text"
                                  v-model="todos" disabled></b-form-input>

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="crear_"
                              label="Crear"
                              label-for="crear">

                    <b-form-input id="crear"
                                  type="text"
                                  v-model="crear" disabled></b-form-input>

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="editar_"
                              label="Editar"
                              label-for="editar">

                    <b-form-input id="editar"
                                  type="text"
                                  v-model="editar" disabled></b-form-input>

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="consultar_"
                              label="Consultar"
                              label-for="consultar">

                    <b-form-input id="consultar"
                                  type="text"
                                  v-model="consultar" disabled></b-form-input>

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="eliminar_"
                              label="Eliminar"
                              label-for="eliminar">

                    <b-form-input id="eliminar"
                                  type="text"
                                  v-model="eliminar" disabled></b-form-input>

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="descargar_"
                              label="Descargar"
                              label-for="descargar">

                    <b-form-input id="descargar"
                                  type="text"
                                  v-model="descargar" disabled></b-form-input>

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="cargar_"
                              label="Cargar"
                              label-for="cargar">

                    <b-form-input id="cargar"
                                  type="text"
                                  v-model="cargar" disabled></b-form-input>

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="autorizar_"
                              label="Autorizar"
                              label-for="autorizar">

                    <b-form-input id="autorizar"
                                  type="text"
                                  v-model="autorizar" disabled></b-form-input>

                </b-form-group>
            </b-col>

            <b-col cols="4">
                <b-form-group id="historico_"
                              label="Historico"
                              label-for="historico">

                    <b-form-input id="historico"
                                  type="text"
                                  v-model="historico" disabled></b-form-input>

                </b-form-group>
            </b-col>

        </b-row>

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
    import { config } from "@/config/auth";


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
                    { value: 1, text: 'Perfil' },
                    { value: 2, text: 'Cargo' }, 

                ],
                selectedEsta: [
                    { value: 1, text: 'Selecciona una Opción' },
                    { value: 2, text: 'Activo' },
                    { value: 3, text: 'Inactivo' },
                ],

                idModulo :'',
                descripcionModulo: '',
                estatusModulo : '',

                //Submodulo //

                idSubModulo:'',
                descripcionSubmodulo : '',
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

                selectedescolar: null,
                escolaroptions: [],
                selectedProfesion: null,
                optProfesiones: [],
                selecteClasificacion: null,
                optClasificaciones: [],

                
            };
        },
        methods: {
            triggerClose() {
                this.$emit("closeCreateModal");
            },
            addNew() {
                
                this.registro.idModulo = this.idModulo;
                this.registro.descripcionModulo = this.descripcionModulo;
                this.registro.estatusModulo = this.estatusModulo;
                this.registro.idSubModulo = this.idSubModulo;
                this.registro.descripcionSubmodulo = this.descripcionSubmodulo;
                this.registro.estatusSubModulo = this.estatusSubModulo;
                this.registro.idPerfilCargo = this.idPerfilCargo;
                this.registro.descripcionPerfil = this.descripcionPerfil;
                this.registro.estatusPerfil = this.estatusPerfil;
                this.registro.ordenCargo = this.ordenCargo;
                this.registro.esCargo = this.esCargo;
                this.registro.idPermiso = this.idPermiso;
                this.registro.todos = this.todos;
                this.registro.crear = this.crear;
                this.registro.editar = this.editar;
                this.registro.consultar = this.consultar;
                this.registro.eliminar = this.eliminar;
                this.registro.descargar = this.descargar;
                this.registro.cargar = this.cargar;
                this.registro.autorizar = this.autorizar;
                this.registro.historico = this.historico;
                this.registro.estatusPermiso = this.estatusPermiso;


                console.log("Comienza agregar permiso");
                console.log("permiso" + this.registro);
                console.log("estatus " + this.registro.estatusPermiso);

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(this.registro)
                };
                fetch(config.auth.server_url_api + 'api/PerfilCargos/CrearPerfilPermisoNew', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            this.$emit("closeCreateModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showSuccessAlert");
                        }
                        else {
                            this.$swal.fire({
                                text: 'Se genero un error al crear el permiso valide con su administrador',
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
                fetch(config.auth.server_url_api + 'api/Plaza/ConsultarPlazas')
                    .then((response) => response.json())
                    .then((data) => {
                        debugger

                        this.optPlazas = data;
                        console.log('plazas', this.optPlazas)
                        // console.log('plaza', this.optPlaza)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            ObtenerSucursal() {
                fetch(config.auth.server_url_api + 'api/Sucursal/ConsultarSucursales')
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
                fetch(config.auth.server_url_api + 'api/Sucursal/ConsultarSucursalesbyIdPlaza?idPlaza=' + idPlaza)
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


                    fetch(config.auth.server_url_api + 'api/VwInfoSocios/VwInfoSociosbyId', requestOptions)
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
            ObtenerPerfilPermisoSinPerfil() {
                fetch(config.auth.server_url_api + 'api/PerfilCargos/ConsultarPerfilPermisoSinPerfil')
                    .then((response) => response.json())
                    .then((data) => {
                        
                        this.registro = data;

                        console.log("registro", this.registro)

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

                        this.idModulo = 100;

                    })
                    .catch(error => {
                        console.error('Error:', error)
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
            getData() {
                fetch(config.auth.server_url_api + 'api/PerfilCargos/ConsultarPerfilPermiso')
                    // fetch(config.auth.server_url_api + 'api/Usuarios/ConsultarUsuariosPersonaPerfil')
                    .then((response) => response.json())
                    .then((data) => {
                        this.items = data;

                        console.log('items', this.items)
                        if (this.todos == false) {
                            this.todos = 0
                        }

                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },


        },
        mounted() {
            this.ObtenerPerfilPermisoSinPerfil();
            //  this.ObtenerSucursal();
        }
    };
</script>