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
                            <i class="fa-solid fa-plus"></i> Archivo
                        </b-button>
                        <b-button variant="outline-success"
                                  id="show-btn"
                                  @click="showDescargarArchivo">
                            <i class="fa-solid fa-plus"></i> Archivo
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

                    <template #cel(descCargo)="data">
                        {{
                        `${data.item.idTipoBaja} ${data.item.descripcion}`
                        }}
                    </template>

                    <template #cell(estatusTipoBaja)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.estatusTipoBaja"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>



                    <template v-slot:cell(acciones)="data">
                        <b-row>
                            <b-icon-pencil-square class="action-item mx-1"
                                                  size="sm" variant="primary"
                                                  @click="getRowData(data.item.idTipoBaja)">
                            </b-icon-pencil-square>

                            <b-icon-trash-fill class="action-item mx-1"
                                               size="sm" variant="danger"
                                               @click="showDeleteModal(data.item.idTipoBaja)">
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

        <b-modal ref="mandar-correo"
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
        </b-modal>

        <b-modal ref="mandar-correo-ip"
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
        </b-modal>
    </div>

</template>

<script>

    import MandarCorreo from "@/components/Administracion/compComunicacion/Noticias/MandarCorreo.vue";
    import MandarCorreoIp from "@/components/Administracion/compComunicacion/Noticias/MandarCorreoIp.vue";
    import CargarArchivo from "@/components/Administracion/compComunicacion/Noticias/CargarArchivoModal.vue";
    import DescargarArchivo from "@/components/Administracion/compComunicacion/Noticias/DescargarArchivoModal.vue";
    import { config } from "@/config/auth";

    export default {
        name: "dTable",
        data() {
            return {
                fields: [
                    { key: 'idNoticia', label: 'Id' },
                    { key: 'descripcion', label: 'Noticia', sortable: true },
                    { key: 'estatusNoticia', label: 'Estatus' },
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
            MandarCorreo,
            MandarCorreoIp,
            CargarArchivo,
            DescargarArchivo
        },
        mounted() {
            //this.getData();
        },
        methods: {
            getData() {
                fetch(config.auth.server_url_api + 'api/CatalogoTipoBaja/Consultar')
                    .then((response) => response.json())
                    .then((data) => {
                        this.items = data;

                    })
                    .catch(error => {
                        this.MensajeError(error)
                    });
            },
            showMandarCorreo() {
                this.$refs["mandar-correo"].show();
            },
            closeMandarCorreo() {
                this.$refs["mandar-correo"].hide();
            },
            showMandarCorreoIp() {
                this.$refs["mandar-correo-ip"].show();
            },
            closeMandarCorreoIp() {
                this.$refs["mandar-correo-ip"].hide();
            },
            showCargarArchivo() {
                this.$refs["cargar-archivo"].show();
            },
            closeCargarArchivo() {
                this.$refs["cargar-archivo"].hide();
            },
            showDescargarArchivo() {
                this.$refs["descargar-archivo"].show();
            },
            closeDescargarArchivo() {
                this.$refs["descargar-archivo"].hide();
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

