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
                        <b-button
                            v-if="$store.getters['permisos/getPermisosByModulo']('Cargopororganodirigencial', 'Descargar')
                                || $store.getters['permisos/getPermisosByModulo']('Cargopororganodirigencial', 'Todos')"
                            variant="outline-success" id="export-btn">
                            <download-excel :data="items" name="CargosPorOrgano.xls" type="xls" :fields="json_fields">
                                <i class="fa-solid fa-file-excel"></i> Exportar
                            </download-excel>
                        </b-button>
                        <b-button
                            v-if="$store.getters['permisos/getPermisosByModulo']('Cargopororganodirigencial', 'Crear')
                                || $store.getters['permisos/getPermisosByModulo']('Cargopororganodirigencial', 'Todos')"
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
                    :sort-desc.sync="sortDesc" responsive="xl" :filter="filter" :filter-function="filterTable"
                    class="text-center" @filtered="onFiltered">

                    <template #cel(idCargoOrgano)="data">
                        {{
                            ` ${data.item.persona} ${data.item.rfc}${data.item.organo}${data.item.cargo}${data.item.suplente}
                                                ${data.item.firmante}${data.item.necesario}
                                                ${data.item.fechaNombramiento}${data.item.fechaActaDesignacion}${data.item.fechaInicial}${data.item.fechaFinal}
                                                ${data.item.fechaIngresoSocio}${data.item.plaza}${data.item.nivelGestion}`
                        }}
                    </template>

                    <template #cell(estatusCargoOrgano)="data">
                        <b-icon-bookmark-check-fill variant="success"
                            v-if="data.item.estatusCargoOrgano"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger" v-else></b-icon-bookmark-x-fill>
                    </template>
                    <template v-slot:cell(acciones)="data">
                        <b-row>
                            <b-icon-pencil-square
                                v-if="$store.getters['permisos/getPermisosByModulo']('Cargopororganodirigencial', 'Editar')
                                    || $store.getters['permisos/getPermisosByModulo']('Cargopororganodirigencial', 'Todos')"
                                class="action-item mx-1" size="sm" variant="primary"
                                @click="getRowData(data.item.idCargoOrgano)">
                            </b-icon-pencil-square>

                            <b-icon-trash-fill
                                v-if="($store.getters['permisos/getPermisosByModulo']('Cargopororganodirigencial', 'Eliminar')
                                    || $store.getters['permisos/getPermisosByModulo']('Cargopororganodirigencial', 'Todos')) && data.item.estatusCargoOrgano"
                                class="action-item mx-1" size="sm" variant="danger"
                                @click="showDeleteModal(data.item.idCargoOrgano)">
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
        <b-modal ref="create-modal" hide-footer title="Nuevo Cargo por Órgano" size="xl" header-bg-variant="success"
            header-text-variant="light" body-bg-variant="light">
            <create-form @closeCreateModal="closeCreateModal" @reloadDataTable="getData"
                @showSuccessAlert="showAlertCreate"></create-form>
        </b-modal>
        <!--Modal for updating-->
        <b-modal ref="edit-modal" hide-footer title="Editar Cargo por Órgano" size="xl" header-bg-variant="success"
            header-text-variant="light" body-bg-variant="light" no-stacking>
            <edit-form @closeEditModal="closeEditModal" @reloadDataTable="getData" @showSuccessAlert="showAlertUpdate"
                :id="id">
            </edit-form>
        </b-modal>
        <!--Delete Modal-->
        <b-modal ref="delete-modal" size="md" hide-footer title="Confirmar Baja">
            <delete-modal @closeDeleteModal="closeDeleteModal" @reloadDataTable="getData"
                @showDeleteAlert="showDeleteSuccessModal" :id="id"></delete-modal>
        </b-modal>
    </div>
</template>

<script>

import CreateForm from "@/components/Administracion/compDirigentes/CargoOrgano/CreateForm.vue";
import EditForm from "@/components/Administracion/compDirigentes/CargoOrgano/EditForm.vue";
import DeleteModal from "@/components/Administracion/compDirigentes/CargoOrgano/DeleteModal.vue";
import { HTTP } from '@/plugins/axios'

export default {
    name: "dtCargoOrgano",
    data() {
        return {
            fields: [
                { key: 'nivelGestion', label: 'Nivel', sortable: true },
                { key: 'persona', label: 'Nombre', sortable: true },
                { key: 'rfc', label: 'RFC', sortable: true },
                { key: 'organo', label: 'Órgano', sortable: true },
                { key: 'cargo', label: 'Cargo', sortable: true },
                { key: 'plaza', label: 'Plaza', sortable: true },
                { key: 'suplente', label: 'Suplente', sortable: true },
                { key: 'firmante', label: 'Firmante', sortable: true },
                { key: 'necesario', label: 'Necesario', sortable: true },
                { key: 'fechaNombramiento', label: 'Fecha Nombramiento', sortable: true, formatter: "formatDate" },
                { key: 'fechaActaDesignacion', label: 'Fecha Acta Designación', sortable: true, formatter: "formatDate" },
                { key: 'fechaInicial', label: 'Fecha Inicia', sortable: true, formatter: "formatDate" },
                { key: 'fechaFinal', label: 'Fecha Final', sortable: true, formatter: "formatDate" },
                { key: 'fechaIngresoSocio', label: 'Fecha Ingreso Socio', sortable: true, formatter: "formatDate" },
                { key: 'estatusCargoOrgano', label: 'Estatus', sortable: true },
                'acciones'
            ],
            items: [],
            id: 0,
            tableHeader: "",
            perPage: 10,  //Numero de registros por pagina
            sortDesc: false,
            filter: "activo",
            showSuccessAlert: false,
            currentPage: 1,
            json_fields: {
                "Nivel": "nivelGestion",
                "Nombre": "persona",
                "RFC": "rfc",
                "Órgano": "organo",
                "Cargo": "cargo",
                "Plaza": "plaza",
                "Suplente": "suplente",
                "Firmante": "firmante",
                "Necesario": "necesario",
                "Fecha Nombramiento": {
                    field: "fechaNombramiento",
                    callback: (value) => {
                        return this.formatDate(`${value}`);
                    }
                },
                "Fecha Acta Designación": {
                    field: "fechaActaDesignacion",
                    callback: (value) => {
                        return this.formatDate(`${value}`);
                    }
                },
                "Fecha Inicia": {
                    field: "fechaInicial",
                    callback: (value) => {
                        return this.formatDate(`${value}`);
                    }
                },
                "Fecha Final": {
                    field: "fechaFinal",
                    callback: (value) => {
                        return this.formatDate(`${value}`);
                    }
                },
                "Fecha Ingreso Socio": {
                    field: "fechaIngresoSocio",
                    callback: (value) => {
                        return this.formatDate(`${value}`);
                    }
                },
                "Estatus": {
                    field: "estatusCargoOrgano",
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
                (row.nivelGestion.concat(row.persona, row.rfc, row.organo, row.cargo, row.plaza, row.suplente, row.firmante, row.necesario, row.fechaNombramiento, row.fechaActaDesignacion, row.fechaInicial, row.fechaFinal, row.fechaIngresoSocio).toLowerCase().includes(filter.toLowerCase()))
                ||
                ('activo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusCargoOrgano == true)
                ||
                ('inactivo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusCargoOrgano == false && filter.toLowerCase().substring(0, 2) == 'in')
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
                .get('api/CatalogoCargoXOrgano/Consultar')
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
            this.showSuccessAlert = true;
            this.MensajeSuccess(this.$messageConstants('crearRegistro'))

        },
        showAlertUpdate() {
            this.showSuccessAlert = true;
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
            this.showSuccessAlert = true;
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
