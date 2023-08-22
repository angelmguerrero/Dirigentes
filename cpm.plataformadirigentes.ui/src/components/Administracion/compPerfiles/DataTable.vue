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
                        <b-button v-if="$store.getters['permisos/getPermisosByModulo']('PerfilesyPermisos','Descargar')
                                     || $store.getters['permisos/getPermisosByModulo']('PerfilesyPermisos','Todos')"
                                  variant="outline-success"
                                  id="export-btn">
                            <download-excel :data="items"
                                            name="Perfiles.xls"
                                            type="xls"
                                            :fields="json_fields">
                                <i class="fa-solid fa-file-excel"></i> Exportar
                            </download-excel>
                        </b-button>
                        <b-button v-if="$store.getters['permisos/getPermisosByModulo']('PerfilesyPermisos','Crear')
                                     || $store.getters['permisos/getPermisosByModulo']('PerfilesyPermisos','Todos')"
                                  variant="outline-success"
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

                    <!--<template #cell(estatusPermiso)="data">
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
                </template>-->


                    <template v-slot:cell(acciones)="data">
                        <b-row>
                            <b-icon-pencil-square v-if="$store.getters['permisos/getPermisosByModulo']('PerfilesyPermisos','Editar')
                                                         || $store.getters['permisos/getPermisosByModulo']('PerfilesyPermisos','Todos')"
                                                  class="action-item mx-1"
                                                  size="sm" variant="primary"
                                                  @click="getRowData(data.item.idPerfilCargo)">
                            </b-icon-pencil-square>

                            <b-icon-exclamation-circle  
                                                       class="action-item mx-1"
                                                       size="sm" variant="info"
                                                       @click="getRowDataPermiso(data.item.idPerfilCargo)">
                            </b-icon-exclamation-circle>
                            <!--<b-icon-trash-fill class="action-item mx-1"
                       size="sm" variant="danger"
                       @click="showDeleteModal(data.item.idPermiso)">
    </b-icon-trash-fill>-->
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
                 size="xl"
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
                 size="xl"
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

        <!--Modal for permisos-->
        <b-modal ref="permiso-modal"
                 hide-footer
                 title="Permisos"
                 size="xl"
                 header-bg-variant="success"
                 header-text-variant="light"
                 body-bg-variant="light"
                 no-stacking>
            <permiso-modal @closePermisoModal="closePermisoModal"
                           @reloadDataTable="getData"
                           @showSuccessAlert="showAlertUpdate"
                           :id="id">
            </permiso-modal>
        </b-modal>
    </div>

</template>

<script>

    import CreateForm from "@/components/Administracion/compPerfiles/CreateForm.vue";
    import EditForm from "@/components/Administracion/compPerfiles/EditForm.vue";
    import DeleteModal from "@/components/Administracion/compPerfiles/DeleteModal.vue";
    import PermisoModal from "@/components/Administracion/compPerfiles/PermisoForm.vue";
    import { config } from "@/config/auth";
    import store from '@/store'; 

    export default {
        name: "dtUsuarios",
        data() {
            return {
                fields: [
                    //{ key: 'idPerfilCargo', label: 'Id', sortable: true },
                    { key: 'descripcionPerfil', label: 'Perfil', sortable: true },
                    { key: 'tipo', label: 'Tipo', sortable: true },
                    { key: 'perfilesPermisos', label: 'Perfiles y Permisos' },
                    { key: 'usuarios', label: 'Usuarios' },
                    { key: 'catalogo', label: 'Cat\u00E1logos' },
                    { key: 'padronDirigentes', label: 'Padr\u00F3n Dirigentes' },
                    { key: 'convocatorias', label: 'Convocatorias' },
                    { key: 'logisticaJocaps', label: 'Log\u00EDstica Jocaps' },
                    { key: 'requerimientosAdicionales', label: 'Requerimientos Adicionales' },
                    { key: 'indicadoresReporteria', label: 'Indicadores y Reporter\u00EDea' },
                    { key: 'blog', label: 'Blog' },

                  //  { key: 'descripcionModulo', label: 'Modulo', sortable: true },
                  //  { key: 'descripcionSubmodulo', label: 'Submodulo', sortable: true },
                  //  { key: 'todos', label: 'Todos', sortable: true },
                  //  { key: 'crear', label: 'Crear', sortable: true },
                  //  { key: 'editar', label: 'Editar', sortable: true },
                  //  { key: 'consultar', label: 'Consultar', sortable: true },
                  //  { key: 'eliminar', label: 'Eliminar', sortable: true },
                  //  { key: 'descargar', label: 'Descargar', sortable: true },
                  //  { key: 'cargar', label: 'Cargar', sortable: true },
                  //  { key: 'autorizar', label: 'Autorizar', sortable: true },
                  //  { key: 'historico', label: 'Historico', sortable: true },                   
                  //  { key: 'esCargo', label: 'Es Cargo' },
                  //  { key: 'ordenCargo', label: 'Orden Cargo' },
                  //  { key: 'estatusPermiso', label: 'Estatus' },
               //     { key: 'idPerfil', label: 'IdPerfil' },
                    'acciones'
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
 
                json_fields: {
                    "Id Perfil": "idPerfilCargo",
                    "Perfil": "descripcionPerfil",
                    "Tipo": "tipo",
                    "Perfiles y Permisos": "perfilesPermisos",
                    "Usuarios": "usuarios",
                    "Catálogo": "catalogo",
                    "Padrón Dirigentes": "padronDirigentes",
                    "Convocatorias": "convocatorias",
                    "Logística Jocaps": "logisticaJocaps",
                    "Requerimientos Adicionales": "requerimientosAdicionales",
                    "Indicadores y Reportería": "indicadoresReporteria",
                    "Blog": "blog",                  
                    "Estatus": {
                        field: "estatusPerfil",
                        callback: (value) => {
                            if (value == true) {
                                value = "Activo"
                            } else {
                                value = "Inactivo"
                            }
                            return value;
                        }
                    },

                },

            }
        },
        components: {
            CreateForm,
            EditForm,
            DeleteModal,
            PermisoModal,
        },
        mounted() {
            this.getData();
        },
        methods: {
            showCreateModal() {
                this.$refs["create-modal"].show();
            },
            closeCreateModal() {
                this.$refs["create-modal"].hide();
            },
            getData() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };// auth header with bearer token

                fetch(config.auth.server_url_api + 'api/PerfilCargos/ConsultarPerfilPermisoIndex',{headers})
               // fetch('/api/Usuarios/ConsultarUsuariosPersonaPerfil')
                    .then((response) => response.json())
                    .then((data) => {
                        this.items = data;

                        console.log('items' ,this.items)
                        if (this.todos == false) {
                            this.todos = 0
                        }

                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            getRowData(iditem) {
                this.id = iditem;
                this.$refs["edit-modal"].show();
            },
            getRowDataPermiso(iditem) {
                this.id = iditem;
                this.$refs["permiso-modal"].show();
            },
            closeEditModal() {
                this.$refs["edit-modal"].hide();
            },
            closePermisoModal() {
                this.$refs["permiso-modal"].hide();
            },
            showAlertCreate() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se creó el perfil',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });

            },
            showAlertUpdate() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se actualizó el perfil',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });
            },
            showAlertPermiso() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se mostró el perfil',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });
            },
            showDeleteModal(iditem) {
                debugger
                this.$refs["delete-modal"].show();
                this.id = iditem;
            },
            closeDeleteModal() {
                this.$refs["delete-modal"].hide();
            },
            showDeleteSuccessModal() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se deshabilitó el perfil',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });

            },
            onFiltered(filteredItems) {
                this.rows = filteredItems.length
                this.currentPage = 1
            },
        },
        computed: {
            rows() {
                return this.items.length
            }
        }
    };
</script>

<style>
    /* Estilos CSS */
    .action-item:hover {
        cursor: pointer;
    }
</style>
