<template>

  
    <div>

        <b-row>

            <b-col cols="2">
                <b-form-group id="Tipo"
                              label="Tipo"
                              label-for="Tipo">

                    <b-form-select v-model="selectedPerfil" size="sm" :options="optionsfitroPerfil" v-on:change="onChangePerfil"    ></b-form-select>

                </b-form-group>
            </b-col>



            <b-col cols="6">
                <b-form-group id="descripcion_perfil"
                              label="Nombre"
                              label-for="descripcionPerfil">

                    <input type="text" v-model="inputDescripcion" class="form-control">
                    <!--<b-form-input id="descripcionPerfil"
                  type="text"
                  v-model="descripcionPerfil">

    </b-form-input>-->

                </b-form-group>
            </b-col>

           
                <b-col cols="2">
                    <b-form-group id="order_cargo"
                                  label="Orden cargo"
                                  label-for="ordenCargo">

                        <b-form-select id="ordenCargoCaptura" v-model="selectedOrdenCargo" size="sm" :options="optionsfitroOrdenCargo" :disabled="disabled == 1"  ></b-form-select>



                    </b-form-group>
                </b-col>
            
        </b-row>

        <!-- C�digo HTML -->
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

                    <!--<template #cell(estatusPermiso)="data">
        <b-icon-bookmark-check-fill variant="success"
                                    v-if="data.item.estatusPermiso === true"></b-icon-bookmark-check-fill>
        <b-icon-bookmark-x-fill variant="danger"
                                v-else></b-icon-bookmark-x-fill>
    </template>-->

                     
                    <template #cell(todos)="data">
                        <b-form-checkbox  
                                         v-model="data.item.todos"
                                         name="todos">

                        </b-form-checkbox>
                    </template>


                    <!--<template #cell(todos)="data">
        <b-icon-bookmark-check-fill variant="success"
                                    v-if="data.item.todos === true"></b-icon-bookmark-check-fill>
        <b-icon-bookmark-x-fill variant="danger"
                                v-else></b-icon-bookmark-x-fill>
    </template>-->

                    <template #cell(crear)="data">
                        <b-form-checkbox  
                                         v-model="data.item.crear"
                                         name="crear">

                        </b-form-checkbox>
                    </template>

                    <!--<template #cell(crear)="data">
        <b-icon-bookmark-check-fill variant="success"
                                    v-if="data.item.crear === true"></b-icon-bookmark-check-fill>
        <b-icon-bookmark-x-fill variant="danger"
                                v-else></b-icon-bookmark-x-fill>
    </template>-->

                    <template #cell(editar)="data">
                        <b-form-checkbox  
                                         v-model="data.item.editar"
                                         name="editar">

                        </b-form-checkbox>
                    </template>

                    <!--<template #cell(editar)="data">
        <b-icon-bookmark-check-fill variant="success"
                                    v-if="data.item.editar === true"></b-icon-bookmark-check-fill>
        <b-icon-bookmark-x-fill variant="danger"
                                v-else></b-icon-bookmark-x-fill>
    </template>-->

                    <template #cell(consultar)="data">
                        <b-form-checkbox  
                                         v-model="data.item.consultar"
                                         name="consultar">

                        </b-form-checkbox>
                    </template>

                    <!--<template #cell(consultar)="data">
        <b-icon-bookmark-check-fill variant="success"
                                    v-if="data.item.consultar === true"></b-icon-bookmark-check-fill>
        <b-icon-bookmark-x-fill variant="danger"
                                v-else></b-icon-bookmark-x-fill>
    </template>-->

                    <template #cell(eliminar)="data">
                        <b-form-checkbox  
                                         v-model="data.item.eliminar"
                                         name="eliminar">

                        </b-form-checkbox>
                    </template>

                    <!--<template #cell(eliminar)="data">
        <b-icon-bookmark-check-fill variant="success"
                                    v-if="data.item.eliminar === true"></b-icon-bookmark-check-fill>
        <b-icon-bookmark-x-fill variant="danger"
                                v-else></b-icon-bookmark-x-fill>
    </template>-->

                    <template #cell(descargar)="data">
                        <b-form-checkbox  
                                         v-model="data.item.descargar"
                                         name="descargar">

                        </b-form-checkbox>
                    </template>

                    <!--<template #cell(descargar)="data">
        <b-icon-bookmark-check-fill variant="success"
                                    v-if="data.item.descargar === true"></b-icon-bookmark-check-fill>
        <b-icon-bookmark-x-fill variant="danger"
                                v-else></b-icon-bookmark-x-fill>
    </template>-->

                    <template #cell(cargar)="data">
                        <b-form-checkbox  
                                         v-model="data.item.cargar"
                                         name="cargar">

                        </b-form-checkbox>
                    </template>

                    <!--<template #cell(cargar)="data">
        <b-icon-bookmark-check-fill variant="success"
                                    v-if="data.item.cargar === true"></b-icon-bookmark-check-fill>
        <b-icon-bookmark-x-fill variant="danger"
                                v-else></b-icon-bookmark-x-fill>
    </template>-->

                    <template #cell(autorizar)="data">
                        <b-form-checkbox  
                                         v-model="data.item.autorizar"
                                         name="autorizar">

                        </b-form-checkbox>
                    </template>

                    <!--<template #cell(autorizar)="data">
        <b-icon-bookmark-check-fill variant="success"
                                    v-if="data.item.autorizar === true"></b-icon-bookmark-check-fill>
        <b-icon-bookmark-x-fill variant="danger"
                                v-else></b-icon-bookmark-x-fill>
    </template>-->

                    <template #cell(historico)="data">
                        <b-form-checkbox  
                                         v-model="data.item.historico"
                                         name="historico">

                        </b-form-checkbox>
                    </template>

                    <!--<template #cell(historico)="data">
        <b-icon-bookmark-check-fill variant="success"
                                    v-if="data.item.historico === true"></b-icon-bookmark-check-fill>
        <b-icon-bookmark-x-fill variant="danger"
                                v-else></b-icon-bookmark-x-fill>
    </template>-->

                    <template #cell(estatusPermiso)="data">
                        <b-form-checkbox id="estatusPermiso"
                                         v-model="data.item.estatusPermiso"
                                         name="estatusPermiso">

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
            <b-col>
                <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
            </b-col>
        </b-row>

    </div>

</template>

<!--<template>

   

    <b-form class="mt-auto">

  

        <b-row>

            <b-col cols="4">
                <b-form-group id="Tipo"
                              label="Tipo"
                              label-for="Tipo">

                    <b-form-select v-model="selected" size="sm" :options="optionsfitro"></b-form-select>

                </b-form-group>
            </b-col>

      

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

</template>-->

<script>
    import { config } from "@/config/auth";
    import store from '@/store'; 

    export default {
        name: "CreateModal",
        data() {
            return {
                registro: {},
                perfilBusqueda: {},
                //modal
                selected: null,
                inputbusqueda: null,
                usuario: {},
                usuarioLog: {},
                optPlazas: [],
                optSucursales: [],
                optionsfitroPerfil: [
                    { value: 1, text: 'Perfil' },
                    { value: 2, text: 'Cargo' }, 

                ],
                optionsfitroOrdenCargo: [
                    { value: 1, text: '1' },
                    { value: 2, text: '2' },
                    { value: 3, text: '3' },
                    { value: 4, text: '4' },
                    { value: 5, text: '5' },
                    { value: 6, text: '6' },
                    { value: 7, text: '7' },
                    { value: 8, text: '8' },
                    { value: 9, text: '9' },
                    { value: 10, text: '10' },

                ],
                selectedEsta: [
                    { value: 1, text: 'Selecciona una Opci�n' },
                    { value: 2, text: 'Activo' },
                    { value: 3, text: 'Inactivo' },
                ],
                disabled: 1,
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
                nombrePerfilBusqueda: '',
                asignaPermisos: 'No',

                selectedescolar: null,
                escolaroptions: [],
                selectedProfesion: null,
                optProfesiones: [],
                selecteClasificacion: null,
                optClasificaciones: [],

                // nuevo

                fields: [
                   // { key: 'idPermiso', label: 'Id' },
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
                id: 0,
                tableHeader: "",
                perPage: 10,  //Numero de registros por pagina
                sortDesc: false,
                filter: null,
                showSuccessAlert: false,
                alertMessage: "",
                currentPage: 1,

                
            };
        },
        methods: {
            triggerClose() {
                this.$emit("closeCreateModal");
            },
            validaExistenciaByNombre() {

                //this.validaExistenciaByCorreoAcceso();

                console.log("registro addnew", this.registro)

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
                       
                        if (this.nombrePerfilBusqueda == '' || this.nombrePerfilBusqueda == null  ) {
                           
                             this.addNew();
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
            addNew() {
               // debugger

                console.log("registro addnew in", this.registro)

                //this.registro.idModulo = this.idModulo;
                //this.registro.descripcionModulo = this.descripcionModulo;
                //this.registro.estatusModulo = this.estatusModulo;
                //this.registro.idSubModulo = this.idSubModulo;
                //this.registro.descripcionSubmodulo = this.descripcionSubmodulo;
                //this.registro.estatusSubModulo = this.estatusSubModulo;
                //this.registro.idPerfilCargo = this.idPerfilCargo;
                //this.registro.descripcionPerfil = this.descripcionPerfil;
                //this.registro.estatusPerfil = this.estatusPerfil;
                //this.registro.ordenCargo = this.ordenCargo;
                //this.registro.esCargo = this.esCargo;
                //this.registro.idPermiso = this.idPermiso;
                //this.registro.todos = this.todos;
                //this.registro.crear = this.crear;
                //this.registro.editar = this.editar;
                //this.registro.consultar = this.consultar;
                //this.registro.eliminar = this.eliminar;
                //this.registro.descargar = this.descargar;
                //this.registro.cargar = this.cargar;
                //this.registro.autorizar = this.autorizar;
                //this.registro.historico = this.historico;
                //this.registro.estatusPermiso = this.estatusPermiso;
   
                console.log("Comienza agregar permiso"); 

                this.asignaPermisos = 'No'
                //debugger
                //Asigna valores de ordencargo, escargo, descripcionperfil
                for (let i = 0; i < this.registro.length; i++) {
                    //console.log(this.registro[i].descripcionPerfil);
                    this.registro[i].descripcionPerfil = this.inputDescripcion;
                    this.registro[i].esCargo = (this.selectedPerfil == 1 ? false : true);
                    this.registro[i].ordenCargo = this.selectedOrdenCargo;
                }

                //valida total de permisos asignados
                for (let i = 0; i < this.registro.length; i++) {
                    //console.log(this.registro[i].descripcionPerfil);
                    if (this.registro[i].todos == true || this.registro[i].crear == true || this.registro[i].editar == true || this.registro[i].consultar == true || this.registro[i].eliminar == true || this.registro[i].descargar == true || this.registro[i].cargar == true || this.registro[i].autorizar == true || this.registro[i].historico == true)
                    {
                        this.asignaPermisos = 'Si';
                    
                }
               // else{}
                }
                 

                console.log("Termina agregar permiso"); 
                console.log("this.asignaPermisos", this.asignaPermisos); 
                console.log("this.inputDescripcion", this.inputDescripcion, "this.selectedPerfil", this.selectedPerfil)
                if (this.asignaPermisos =='Si') {

                    if ((this.inputDescripcion != null && this.inputDescripcion.trim() != '' && this.selectedPerfil != null && this.selectedPerfil != '' && this.selectedPerfil == 1)
                        ||
                        (this.inputDescripcion != null && this.inputDescripcion.trim() != '' && this.selectedPerfil != null && this.selectedPerfil != '' && this.selectedOrdenCargo != null && this.selectedOrdenCargo != '' && this.selectedPerfil == 2)) {

                        const requestOptions = {
                            method: 'POST',
                            //headers: { 'Content-Type': 'application/json' },
                            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },//CAMBIO SEGURIDAD
                            body: JSON.stringify(this.registro)

                        };
                        fetch(config.auth.server_url_api + 'api/PerfilCargos/CrearPerfilPermisoNew', requestOptions)
                            .then(async response => {

                                if (response.status == 200) {
                                    //this.addNewLog();
                                    this.$emit("closeCreateModal");
                                    this.$emit("reloadDataTable");
                                    this.$emit("showSuccessAlert");
                                }
                                else {
                                    this.$swal.fire({
                                        text: 'Se genero un error al crear el Perfil valide con su administrador',
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
                            text: 'Favor de capturar Tipo/Nombre y Orden cuando aplique',
                            icon: 'warning',
                            confirmButtonText: 'Ok',

                        });
                    }

                }
                else {
                    this.$swal.fire({
                        text: 'Favor de capturar al menos un permiso',
                        icon: 'warning',
                        confirmButtonText: 'Ok',

                    });
                }


            },
            addNewLog() {

                this.usuarioLog.idModulo = 1;
                this.usuarioLog.idSubModulo = 1;
                this.usuarioLog.tipoMovimiento = 'Alta';
                this.usuarioLog.descripcion = 'Nombre: ' + this.registro[0].descripcionPerfil + ' EsCargo: ' + this.registro[0].esCargo + ' OrdenCargo: ' + this.registro[0].ordenCargo  ;
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
            onChangePerfil: function () {
                

                console.log('selectedPerfil: ', this.selectedPerfil)
                if (this.selectedPerfil == 2) {
                    this.disabled = 0;
                }
                else {
                    this.disabled = 1;
                }
              
            },
            ObtenerPlaza() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };// auth header with bearer token

                fetch(config.auth.server_url_api + 'api/Plaza/ConsultarPlazas',{headers})
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
                        //headers: { 'Content-Type': 'application/json' },
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },//CAMBIO SEGURIDAD
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
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };// auth header with bearer token

                fetch(config.auth.server_url_api + 'api/PerfilCargos/ConsultarPerfilPermisoSinPerfil',{headers})
                    .then((response) => response.json())
                    .then((data) => {

                        this.items = data;

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
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };// auth header with bearer token

                fetch(config.auth.server_url_api + 'api/PerfilCargos/ConsultarPerfilPermisoSinPerfil',{headers})
                    // fetch('/api/Usuarios/ConsultarUsuariosPersonaPerfil')
                    .then((response) => response.json())
                    .then((data) => {
                        this.items = data;

                        console.log('items', this.items)


                        this.registro = data;

                        console.log("registro", this.registro)

                        this.idModulo = this.registro.idModulo;
                        this.descripcionModulo = this.registro.descripcionModulo;
                        this.estatusModulo = this.registro.estatusModulo;
                        this.idSubModulo = this.registro.idSubModulo;
                        this.descripcionSubmodulo = this.registro.descripcionSubmodulo;
                        this.estatusSubModulo = this.registro.estatusSubModulo;
                        this.idPerfilCargo = this.registro.idPerfilCargo;
                       // this.descripcionPerfil = this.registro.descripcionPerfil;
                        this.estatusPerfil = this.registro.estatusPerfil;
                        this.ordenCargo = this.registro.ordenCargo;
                       // this.esCargo = this.registro.esCargo;
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

                      

                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },


        },
        mounted() {
            this.ObtenerPerfilPermisoSinPerfil();
           // this.getData();
            //  this.ObtenerSucursal();
        },
        computed: {
            rows() {
                return this.items.length
            }
        }
    };
</script>