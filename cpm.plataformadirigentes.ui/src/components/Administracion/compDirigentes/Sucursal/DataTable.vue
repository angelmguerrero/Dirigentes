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
                            <download-excel :data="items" name="Sucursales.xls" type="xls" :fields="json_fields">
                                <i class="fa-solid fa-file-excel"></i> Exportar
                            </download-excel>
                        </b-button>
                        <!--<b-button-group size="sm">
                            <b-button variant="outline-success"
                                      id="show-btn"
                                      @click="showMandarCorreo">
                                <i class="fa-solid fa-plus"></i> Correo
                            </b-button>

                            <b-button variant="outline-success"
                                      id="show-btn"
                                      @click="showMandarCorreoIp">
                                <i class="fa-solid fa-plus"></i> Correo IP
                            </b-button>
                            <b-button variant="outline-success"
                                      id="show-btn"
                                      @click="showCargarArchivo">
                                <i class="fa-solid fa-plus"></i> Cargar Archivo
                            </b-button>
                            <b-button variant="outline-success"
                                      id="show-btn"
                                      @click="showDescargarArchivo">
                                <i class="fa-solid fa-plus"></i> Descargar Archivo
                            </b-button>
                        </b-button-group>-->
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
                            `${data.item.descripcion}${data.item.plaza}${data.item.centroCosto}`
                        }}
                    </template>

                    <template #cell(estatusSucursal)="data">
                        <b-icon-bookmark-check-fill variant="success"
                            v-if="data.item.estatusSucursal"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger" v-else></b-icon-bookmark-x-fill>
                    </template>

                </b-table>
                <b-pagination v-model="currentPage" :total-rows="rows" :per-page="perPage" aria-controls="my-table"
                    size="sm" align="center" first-text="Primero" prev-text="Anterior" next-text="Siguiente"
                    last-text="Ultimo">
                </b-pagination>
            </div>
        </b-card-text>

        <!--<b-modal ref="mandar-correo"
                 hide-footer
                 title="Nueva correo"
                 size="md"
                 header-bg-variant="success"
                 header-text-variant="light"
                 body-bg-variant="light"
                 no-stacking>
            <mandar-correo @closeCreateModal="closeMandarCorreo"
                           @reloadDataTable="getData"
                           @showSuccessAlert="showAlertCreate"></mandar-correo>
        </b-modal>-->

        <!--<b-modal ref="mandar-correo-ip"
                 hide-footer
                 title="Nueva correo Ip"
                 size="md"
                 header-bg-variant="success"
                 header-text-variant="light"
                 body-bg-variant="light"
                 no-stacking>
            <mandar-correo-ip @closeCreateModal="closeMandarCorreoIp"
                              @reloadDataTable="getData"
                              @showSuccessAlert="showAlertCreate"></mandar-correo-ip>
        </b-modal>

        <b-modal ref="cargar-archivo"
                 hide-footer
                 title="Nuevo archivo"
                 size="md"
                 header-bg-variant="success"
                 header-text-variant="light"
                 body-bg-variant="light"
                 no-stacking>
            <cargar-archivo @closeCreateModal="closeCargarArchivo"
                            @reloadDataTable="getData"
                            @showSuccessAlert="showAlertCreate"></cargar-archivo>
        </b-modal>

        <b-modal ref="descargar-archivo"
                 hide-footer
                 title="Descargar archivo"
                 size="md"
                 header-bg-variant="success"
                 header-text-variant="light"
                 body-bg-variant="light"
                 no-stacking>
            <descargar-archivo @closeCreateModal="closeDescargarArchivo"
                               @reloadDataTable="getData"
                               @showSuccessAlert="showAlertCreate"></descargar-archivo>
        </b-modal>-->

    </div>
</template>

<script>
import { config } from "@/config/auth";
//import MandarCorreo from "@/components/Administracion/compComunicacion/Noticias/MandarCorreo.vue";
//import MandarCorreoIp from "@/components/Administracion/compComunicacion/Noticias/MandarCorreoIp.vue";
//import CargarArchivo from "@/components/Administracion/compComunicacion/Noticias/CargarArchivoModal.vue";
//import DescargarArchivo from "@/components/Administracion/compComunicacion/Noticias/DescargarArchivoModal.vue";
import { HTTP } from '@/plugins/axios'




export default {
    name: "dtPlaza",
    data() {
        return {
            fields: [
                { key: 'descripcion', label: 'Descripción', sortable: true },
                { key: 'plaza', label: 'Plaza', sortable: true },
                { key: 'centroCosto', label: 'Centro de Costos', sortable: true },
                { key: 'estatusSucursal', label: 'Estatus', sortable: true },
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
                "Plaza": "plaza",
                "Centro de Costos": "centroCosto",
                "Estatus": {
                    field: "estatusSucursal",
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
        //MandarCorreo,
        //MandarCorreoIp,
        //CargarArchivo,
        //DescargarArchivo
    },
    mounted() {
        this.getData();
    },
    methods: {
        filterTable(row, filter) {
            if (
                (row.descripcion.concat(row.plaza, row.centroCosto).toLowerCase().includes(filter.toLowerCase()))
                ||
                ('activo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusSucursal == true)
                ||
                ('inactivo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusSucursal == false && filter.toLowerCase().substring(0, 2) == 'in')
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
                .get(config.auth.server_url_api + 'api/Sucursal/ConsultarSucursalesDom')
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
        //showMandarCorreo() {
        //    this.$refs["mandar-correo"].show();
        //},
        //closeMandarCorreo() {
        //    this.$refs["mandar-correo"].hide();
        //},
        //showMandarCorreoIp() {
        //    this.$refs["mandar-correo-ip"].show();
        //},
        //closeMandarCorreoIp() {
        //    this.$refs["mandar-correo-ip"].hide();
        //},
        //showCargarArchivo() {
        //    this.$refs["cargar-archivo"].show();
        //},
        //closeCargarArchivo() {
        //    this.$refs["cargar-archivo"].hide();
        //},
        //showDescargarArchivo() {
        //    this.$refs["descargar-archivo"].show();
        //},
        //closeDescargarArchivo() {
        //    this.$refs["descargar-archivo"].hide();
        //},
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
