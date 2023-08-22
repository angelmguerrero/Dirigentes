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
                        <b-button variant="outline-success" id="export-btn">
                            <download-excel :data="items" name="Plazas.xls" type="xls" :fields="json_fields">
                                <i class="fa-solid fa-file-excel"></i> Exportar
                            </download-excel>
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

                    <template #cel(descCargo)="data">
                        {{
                            ` ${data.item.descripcion}${data.item.region}${data.item.centroCosto}`
                        }}
                    </template>

                    <template #cell(estatusPlaza)="data">
                        <b-icon-bookmark-check-fill variant="success"
                            v-if="data.item.estatusPlaza"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger" v-else></b-icon-bookmark-x-fill>
                    </template>

                </b-table>
                <b-pagination v-model="currentPage" :total-rows="rows" :per-page="perPage" aria-controls="my-table"
                    size="sm" align="center" first-text="Primero" prev-text="Anterior" next-text="Siguiente"
                    last-text="Ultimo">
                </b-pagination>
            </div>
        </b-card-text>

    </div>
</template>

<script>
import { HTTP } from '@/plugins/axios'


export default {
    name: "dtPlaza",
    data() {
        return {
            fields: [
                { key: 'descripcion', label: 'Descripción', sortable: true },
                { key: 'region', label: 'Región', sortable: true },
                { key: 'centroCosto', label: 'Centro de Costos', sortable: true },
                { key: 'estatusPlaza', label: 'Estatus', sortable: true },
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
                "Descripción": "descripcion",
                "Región": "region",
                "Centro de Costos": "centroCosto",
                "Estatus": {
                    field: "estatusPlaza",
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

    },
    mounted() {
        this.getData();
    },
    methods: {
        filterTable(row, filter) {
            if (
                (row.descripcion.concat(row.region, row.centroCosto).toLowerCase().includes(filter.toLowerCase()))
                ||
                ('activo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusPlaza == true)
                ||
                ('inactivo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusPlaza == false && filter.toLowerCase().substring(0, 2) == 'in')
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
                .get('api/Plaza/ConsultarPlazasDom')
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
            this.MensajeSuccess('Se creó el registro')

        },
        showAlertUpdate() {
            this.showSuccessAlert = true;
            this.MensajeSuccess('Se actualizó el registro')
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
            this.MensajeSuccess('Se deshabilitó el registro')

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
