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

<script>
    import { config } from "@/config/auth";


    import CreateForm from "@/components/Administracion/compPerfiles/CreateForm.vue";
    import EditForm from "@/components/Administracion/compPerfiles/EditForm.vue";
    import DeleteModal from "@/components/Administracion/compPerfiles/DeleteModal.vue";

    export default {
        name: "dtUsuarios",
        data() {
            return {
                fields: [
                    { key: 'idPermiso', label: 'Id' },
                    { key: 'descripcionPerfil', label: 'Perfil' },
                    { key: 'descripcionModulo', label: 'Modulo', sortable: true },
                    { key: 'descripcionSubmodulo', label: 'Submodulo', sortable: true },
                    { key: 'todos', label: 'Todos', sortable: true },
                    { key: 'crear', label: 'Crear', sortable: true },
                    { key: 'editar', label: 'Editar', sortable: true },
                    { key: 'consultar', label: 'Consultar', sortable: true },
                    { key: 'eliminar', label: 'Eliminar', sortable: true },
                    { key: 'descargar', label: 'Descargar', sortable: true },
                    { key: 'cargar', label: 'Cargar', sortable: true },
                    { key: 'autorizar', label: 'Autorizar', sortable: true },
                    { key: 'historico', label: 'Historico', sortable: true },                   
                    { key: 'esCargo', label: 'Es Cargo' },
                    { key: 'ordenCargo', label: 'Orden Cargo' },
                    { key: 'estatusPermiso', label: 'Estatus' },
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

            }
        },
        components: {
            CreateForm,
            EditForm,
            DeleteModal,
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
                fetch(config.auth.server_url_api + 'api/PerfilCargos/ConsultarPerfilPermiso')
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
            closeEditModal() {
                this.$refs["edit-modal"].hide();
            },
            showAlertCreate() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se creó el perfil permiso',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });

            },
            showAlertUpdate() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se actualizó el perfil permiso',
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
                    text: 'Se deshabilitó el perfil permiso',
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
