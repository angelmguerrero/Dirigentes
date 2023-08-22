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
                        <b-button v-if="$store.getters['permisos/getPermisosByModulo']('Usuarios','Descargar') 
                                     || $store.getters['permisos/getPermisosByModulo']('Usuarios','Todos')"
                                  variant="outline-success"
                                  id="export-btn">
                            <download-excel :data="items"
                                            name="Usuarios.xls"
                                            type="xls"
                                            :fields="json_fields">
                                <i class="fa-solid fa-file-excel"></i> Exportar
                            </download-excel>
                        </b-button>
                        <b-button v-if="$store.getters['permisos/getPermisosByModulo']('Usuarios','Crear') 
                                     || $store.getters['permisos/getPermisosByModulo']('Usuarios','Todos')"
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
                         :filter-function="filterTable"
                         class="text-center"
                         @filtered="onFiltered">

                    <template #cel(correoAcceso)="data">
                        {{
                        `${data.item.idUsuario} ${data.item.correoAcceso}${data.item.idPerfil}`
                        }}


                    </template>

                    <template #cell(estatusUsuario)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.estatusUsuario === true"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>



                    <template v-slot:cell(acciones)="data">
                        <b-row>
                            <b-icon-pencil-square v-if="$store.getters['permisos/getPermisosByModulo']('Usuarios','Editar') 
                                                     || $store.getters['permisos/getPermisosByModulo']('Usuarios','Todos')"
                                                  class="action-item mx-1"
                                                  size="sm" variant="primary"
                                                  @click="getRowData(data.item.idUsuario)">
                            </b-icon-pencil-square>

                            <b-icon-trash-fill v-if="($store.getters['permisos/getPermisosByModulo']('Usuarios','Eliminar') 
                                                  || $store.getters['permisos/getPermisosByModulo']('Usuarios','Todos') )
                                               && data.item.estatusUsuario === true"
                                               class="action-item mx-1"
                                               size="sm" variant="danger"
                                               @click="showDeleteModal(data.item.idUsuario)">
                            </b-icon-trash-fill>

                            <b-icon-exclamation-circle v-if="data.item.estatusUsuario === true"
                                                       class="action-item mx-1"
                                                  size="sm" variant="info"
                                                  @click="getRowDataPermiso(data.item.idUsuario)">
                            </b-icon-exclamation-circle>
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
                 title="Nuevo Usuario"
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
                 title="Editar Usuario"
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

    import CreateForm from "@/components/Administracion/compUsuarios/CreateForm.vue";
    import EditForm from "@/components/Administracion/compUsuarios/EditForm.vue";
    import DeleteModal from "@/components/Administracion/compUsuarios/DeleteModal.vue";
    import PermisoModal from "@/components/Administracion/compUsuarios/PermisoForm.vue";
    import { config } from "@/config/auth";
    import store from '@/store';

    export default {
        name: "dtUsuarios",
        data() {
            return {
                fields: [
                  //  { key: 'idUsuario', label: 'Id' },
                    { key: 'correoAcceso', label: 'Correo Acceso', sortable: true },
                    { key: 'perfil', label: 'Perfil', sortable: true },
                    { key: 'nombrePersonaCompleto', label: 'Nombres', sortable: true },
                    { key: 'estatusUsuario', label: 'Estatus' },
               //     { key: 'idPerfil', label: 'IdPerfil' },
                    'acciones'
                ],
                items: [],
                id: 0,
                tableHeader: "",
                perPage: 10,  //Numero de registros por pagina
                sortDesc: false,
                filter: "activo",
                showSuccessAlert: false,
                alertMessage: "",
                currentPage: 1,

                json_fields: {
                    "Id Usuario": "idUsuario",
                    "Correo Acceso": "correoAcceso",
                    "Perfil": "perfil",
                    "Nombres": "nombrePersonaCompleto",
                    "Estatus": {
                        field: "estatusUsuario",
                        callback: (value) => {
                            if (value == true) {
                                value = "Activo"
                            } else {
                                value = "Inactivo"
                            }
                            return value;
                        }
                    },

                    //"Fecha de ingreso":
                    //{
                    //    field: "fechaIngreso",
                    //    callback: (value) => {
                    //        return this.formatDate(`${value}`);
                    //    }
                    //},


                },
                correoDirigente: "",
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
            filterTable(row, filter) {
                if (
                    (row.correoAcceso.concat(row.perfil, row.nombrePersonaCompleto).toLowerCase().includes(filter.toLowerCase()))
                    ||
                    ('activo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusUsuario == true)
                    ||
                    ('inactivo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusUsuario == false && filter.toLowerCase().substring(0, 2) == 'in')
                ) {
                    return true;
                } else {
                    return false;
                }
            },
            showCreateModal() {
                this.$refs["create-modal"].show();
            },
            closeCreateModal() {
                this.$refs["create-modal"].hide();
            },
            getData() {

                var correoDir =this.$store.getters['user/getCorreoDirigente'] ;
                this.correoDirigente = correoDir;
                console.log("correoDirigente:", this.correoDirigente)

                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };// auth header with bearer token
               
                fetch(config.auth.server_url_api + 'api/Usuarios/ConsultarUsuariosPersonaPerfil',{headers})
                    .then((response) => response.json())
                    .then((data) => {
                        this.items = data;

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
                    text: 'Se creó el usuario',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });

            },
            showAlertUpdate() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se actualizó el usuario',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });
            },
            showAlertPermiso() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se mostró el usuario',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });
            },
            showDeleteModal(iditem) {
               // debugger
                this.$refs["delete-modal"].show();
                this.id = iditem;
            },
            closeDeleteModal() {
                this.$refs["delete-modal"].hide();
            },
            showDeleteSuccessModal() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se deshabilitó el usuario',
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
