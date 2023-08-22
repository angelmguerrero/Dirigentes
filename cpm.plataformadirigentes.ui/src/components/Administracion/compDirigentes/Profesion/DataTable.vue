<template>
    <div>
        <!-- Código HTML -->
        <b-card-text>
            <b-row>
                <b-col class="col-8">
                    <h3>{{ tableHeader }}</h3>
                </b-col>
                <b-col class="col-4">


                    <b-button-group size="sm">
                        <b-button v-if="$store.getters['permisos/getPermisosByModulo']('Profesion', 'Descargar')
                            || $store.getters['permisos/getPermisosByModulo']('Profesion', 'Todos')"
                            variant="outline-success" id="export-btn">
                            <download-excel :data="items" name="Profesiones.xls" type="xls" :fields="json_fields">
                                <i class="fa-solid fa-file-excel"></i> Exportar
                            </download-excel>
                        </b-button>
                        <b-button v-if="$store.getters['permisos/getPermisosByModulo']('Profesion', 'Crear')
                            || $store.getters['permisos/getPermisosByModulo']('Profesion', 'Todos')"
                            variant="outline-success" id="show-btn" @click="showCreateModal">
                            <i class="fa-solid fa-plus"></i> Nuevo
                        </b-button>
                    </b-button-group>

                </b-col>
            </b-row>

            <div class="overflow-auto">
                <b-row class="justify-content-md-center sm-3">
                    <b-col col-4>
                        <div class="input-group input-group-sm ">
                            <b-form-input v-model="filter" type="search" placeholder="Ingresa el dato"></b-form-input>
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

                <b-table outlined small hover fixed id="my-table" no-border-collapse :per-page="perPage"
                    :current-page="currentPage" :items="items" :fields="fields" head-variant="light"
                    :sort-desc.sync="sortDesc" responsive="sm" :filter="filter" :filter-function="filterTable"
                    class="text-center" @filtered="onFiltered">

                    <template #cel(Descripcion)="data">
                        {{
                            `${data.item.Descripcion}`
                        }}
                    </template>

                    <template #cell(estatusProfesion)="data">
                        <b-icon-bookmark-check-fill variant="success"
                            v-if="data.item.estatusProfesion"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger" v-else></b-icon-bookmark-x-fill>
                    </template>



                    <template v-slot:cell(acciones)="data">
                        <b-row>
                            <b-icon-pencil-square
                                v-if="$store.getters['permisos/getPermisosByModulo']('Profesion', 'Editar')
                                    || $store.getters['permisos/getPermisosByModulo']('Profesion', 'Todos')"
                                class="action-item mx-1" size="sm" variant="primary"
                                @click="getRowData(data.item.idProfesion)">
                            </b-icon-pencil-square>

                            <b-icon-trash-fill
                                v-if="($store.getters['permisos/getPermisosByModulo']('Profesion', 'Eliminar')
                                    || $store.getters['permisos/getPermisosByModulo']('Profesion', 'Todos')) && data.item.estatusProfesion"
                                class="action-item mx-1" size="sm" variant="danger"
                                @click="showDeleteModal(data.item.idProfesion)">
                            </b-icon-trash-fill>
                        </b-row>
                    </template>
                </b-table>
                <b-pagination v-model="currentPage" :total-rows="rows" :per-page="perPage" aria-controls="my-table"
                    size="sm" align="center" first-text="Primero" prev-text="Anterior" next-text="Siguiente"
                    last-text="Ultimo">
                </b-pagination>
            </div>
        </b-card-text>

        <!--Modal for add-->
        <b-modal ref="create-modal" hide-footer title="Nueva Profesión" size="md" header-bg-variant="success"
            header-text-variant="light" body-bg-variant="light" no-stacking>
            <create-form @closeCreateModal="closeCreateModal" @reloadDataTable="getData"
                @showSuccessAlert="showAlertCreate"></create-form>
        </b-modal>
        <!--Modal for updating-->
        <b-modal ref="edit-modal" hide-footer title="Editar Profesión" size="md" header-bg-variant="success"
            header-text-variant="light" body-bg-variant="light" no-stacking>
            <edit-form @closeEditModal="closeEditModal" @reloadDataTable="getData" @showSuccessAlert="showAlertUpdate"
                :id="id">
            </edit-form>
        </b-modal>
        <!--Delete Modal-->
        <b-modal ref="delete-modal" size="md" hide-footer title="Confirma la eliminación">
            <delete-modal @closeDeleteModal="closeDeleteModal" @reloadDataTable="getData"
                @showDeleteAlert="showDeleteSuccessModal" :id="id"></delete-modal>
        </b-modal>
    </div>
</template>

<script>

import CreateForm from "@/components/Administracion/compDirigentes/Profesion/CreateForm.vue";
import EditForm from "@/components/Administracion/compDirigentes/Profesion/EditForm.vue";
import DeleteModal from "@/components/Administracion/compDirigentes/Profesion/DeleteModal.vue";
import { HTTP } from '@/plugins/axios'



export default {
    name: "dtProfesiones",
    data() {
        return {
            fields: [
                { key: 'descripcion', label: 'Profesión', sortable: true },
                { key: 'descripcionClasificacion', label: 'Clasificación Profesión', sortable: true },
                { key: 'estatusProfesion', label: 'Estatus' },
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
                "Profesión": "descripcion",
                "Clasificación Profesión": "descripcionClasificacion",
                "Estatus": {
                    field: "estatusProfesion",
                    callback: (value) => {
                        if (value == true) {
                            value = "activo"
                        } else {
                            value = "inactivo"
                        }
                        return value;
                    }
                },
            },
            json_meta: [
                [
                    {
                        key: "charset",
                        value: "utf-8",
                    },
                ],
            ],

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
        filterTable(row, filter) {
            if (
                (row.descripcion.toLowerCase().includes(filter.toLowerCase()))
                ||
                ('activo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusProfesion == true)
                ||
                ('inactivo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusProfesion == false && filter.toLowerCase().substring(0, 2) == 'in')
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
            HTTP
                .get('api/CatalogoProfesion/Consultar')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {

                        this.items = response.data;
                    }
                })
                .catch(function (error) {
                    this.MensajeError(error);
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
            this.showsuccessalert = true;
            this.MensajeSuccess(this.$messageConstants('crearRegistro'))
        },
        showAlertUpdate() {
            this.showsuccessalert = true;
            this.MensajeSuccess(this.$messageConstants('actualizarRegistro'))
        },
        showDeleteModal(iditem) {

            this.$refs["delete-modal"].show();
            this.id = iditem;
        },
        closeDeleteModal() {
            this.$refs["delete-modal"].hide();
        },
        showDeleteSuccessModal() {
            this.showsuccessalert = true;
            this.MensajeSuccess(this.$messageConstants('bajaRegistro'))

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
