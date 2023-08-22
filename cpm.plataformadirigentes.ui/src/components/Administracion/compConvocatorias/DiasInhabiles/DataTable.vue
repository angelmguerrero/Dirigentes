<template>
    <div>
        <!-- Código HTML -->
        <b-card-text>
            <validation-observer ref="observer" v-slot="{ handleSubmit }">
                <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(buscarporFechas)">
                    <b-row>
                        <b-col cols="3">
                            <validation-provider name="Fecha Inicio" :rules="{ required: true }" v-slot="validationContext">
                                <b-form-group id="lblFecha" label="Fecha Inicio: " label-for="txtfechaInicio">

                                    <b-form-datepicker id="txtfechaInicio" v-model="filtro.fechaInicio" locale="es-MX"
                                        class="mb-2" placeholder="Selecciona una fecha"
                                        :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"
                                        :state="getValidationState(validationContext)"
                                        aria-describedby="input-1-live-feedback" trim
                                        @context="validarFechas"></b-form-datepicker>


                                    <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0]
                                    }}</b-form-invalid-feedback>
                                </b-form-group>
                            </validation-provider>

                        </b-col>
                        <b-col cols="3">
                            <validation-provider name="Fecha Fin" :rules="{ required: true }" v-slot="validationContext">
                                <b-form-group id="lblFecha" label="Fecha Fin: " label-for="txtfechaFin">

                                    <b-form-datepicker id="txtfechaFin" v-model="filtro.fechaFin" locale="es-MX"
                                        class="mb-2" placeholder="Selecciona una fecha"
                                        :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"
                                        :state="getValidationState(validationContext)"
                                        aria-describedby="input-1-live-feedback" trim
                                        @context="validarFechas"></b-form-datepicker>


                                    <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0]
                                    }}</b-form-invalid-feedback>
                                </b-form-group>
                            </validation-provider>

                        </b-col>
                        <b-col cols="2" style="padding-top: 30px;">
                            <!--<b-button variant="info" @click="buscarporFechas">
                                <i class="fa-solid fa-magnifying-glass"> </i>
                                Buscar
                            </b-button>-->
                            <b-button variant="info" type="submit">
                                <i class="fa-solid fa-magnifying-glass"> </i>
                                Buscar
                            </b-button>
                        </b-col>
                    </b-row>
                </b-form>
            </validation-observer>
            <b-row>
                <b-col class="col-8">
                    <h3>{{ tableHeader }}</h3>
                </b-col>
                <b-col class="col-4">

                    <b-button-group size="sm">
                        <b-button
                            v-if="$store.getters['permisos/getPermisosByModulo']('Diasinhabiles', 'Descargar') || $store.getters['permisos/getPermisosByModulo']('Diasinhabiles', 'Todos')"
                            variant="outline-success" id="export-btn">

                            <download-excel :data="items" name="DiasInhabiles.xls" type="xls" :fields="json_fields">
                                <i class="fa-solid fa-file-excel"></i> Exportar
                            </download-excel>
                        </b-button>
                        <b-button v-if="$store.getters['permisos/getPermisosByModulo']('Diasinhabiles', 'Crear')
                            || $store.getters['permisos/getPermisosByModulo']('Diasinhabiles', 'Todos')"
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
                            <b-form-input v-model="filter" type="search"
                                placeholder="Ingresa el dato para filtrar"></b-form-input>
                        </div>
                    </b-col>
                    <b-col col-5>
                    </b-col>
                    <b-col col-3>
                        <b-row>
                            <b-col cols="12">
                                <b-form-checkbox id="lblestatusSabado" name="cbxstatusSabado" @change="updateSabado"
                                    v-model="sabado">
                                    Sábado
                                </b-form-checkbox>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col cols="12">
                                <b-form-checkbox id="lblestatusDomingo" name="cbxstatusDomindo" @change="updateDomingo"
                                    v-model="domingo">
                                    Domingo
                                </b-form-checkbox>
                            </b-col>
                        </b-row>
                    </b-col>
                </b-row>
                <br />
                <b-table outlined small hover fixed id="my-table" no-border-collapse :per-page="perPage"
                    :current-page="currentPage" :items="items" :fields="fields" head-variant="light"
                    :sort-desc.sync="sortDesc" responsive="sm" :filter="filter" :filter-function="filterTable"
                    class="text-center" @filtered="onFiltered">
                    <template #cel(idDiaInhabil)="data">
                        {{
                            `${data.item.fecha} ${data.item.descripcion}`
                        }}
                    </template>

                    <template #cell(estatusDiaInhabil)="data">
                        <b-icon-bookmark-check-fill variant="success"
                            v-if="data.item.estatusDiaInhabil"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger" v-else></b-icon-bookmark-x-fill>
                    </template>



                    <template v-slot:cell(acciones)="data">
                        <b-row>
                            <b-icon-pencil-square
                                v-if="$store.getters['permisos/getPermisosByModulo']('Diasinhabiles', 'Editar') || $store.getters['permisos/getPermisosByModulo']('Diasinhabiles', 'Todos')"
                                class="action-item mx-1" size="sm" variant="primary"
                                @click="getRowData(data.item.idDiaInhabil)">
                            </b-icon-pencil-square>

                            <b-icon-trash-fill
                                v-if="($store.getters['permisos/getPermisosByModulo']('Diasinhabiles', 'Eliminar') || $store.getters['permisos/getPermisosByModulo']('Diasinhabiles', 'Todos')) && data.item.estatusDiaInhabil"
                                class="action-item mx-1" size="sm" variant="danger"
                                @click="showDeleteModal(data.item.idDiaInhabil)">
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
        <b-modal ref="create-modal" hide-footer title="Nuevo Día Inhabil" size="md" header-bg-variant="success"
            header-text-variant="light" body-bg-variant="light" no-stacking>
            <create-form @closeCreateModal="closeCreateModal" @reloadDataTable="getData"
                @showSuccessAlert="showAlertCreate"></create-form>
        </b-modal>
        <!--Modal for updating-->
        <b-modal ref="edit-modal" hide-footer title="Editar Día Inhabil" size="md" header-bg-variant="success"
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

import CreateForm from "@/components/Administracion/compConvocatorias/DiasInhabiles/CreateForm.vue";
import EditForm from "@/components/Administracion/compConvocatorias/DiasInhabiles/EditForm.vue";
import DeleteModal from "@/components/Administracion/compConvocatorias/DiasInhabiles/DeleteModal.vue";
import { HTTP } from '@/plugins/axios'

export default {
    name: "dtCargos",
    data() {
        return {
            fields: [
                { key: 'fecha', label: 'Dia', sortable: true, formatter: "formatDate" },
                { key: 'descripcion', label: 'Descripción', sortable: true },
                { key: 'estatusDiaInhabil', label: 'Estatus', sortable: true },
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
            sabado: false,
            domingo: false,
            json_fields: {
                "Dia": {
                    field: "fecha",
                    callback: (value) => {
                        return this.formatDate(`${value}`);
                    }
                },
                "Descripción": "descripcion",
                "Estatus": {
                    field: "estatusDiaInhabil",
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
            filtro: {}
        }
    },
    components: {
        CreateForm,
        EditForm,
        DeleteModal,
    },
    mounted() {
        this.getData();
        this.getSabado();
        this.getDomingo();
    },
    methods: {
        filterTable(row, filter) {
            if (
                (row.descripcion.concat(row.fecha).toLowerCase().includes(filter.toLowerCase()))
                ||
                ('activo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusDiaInhabil == true)
                ||
                ('inactivo'.toLowerCase().includes(filter.toLowerCase()) && row.estatusDiaInhabil == false && filter.toLowerCase().substring(0, 2) == 'in')
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
        getValidationState({ dirty, validated, valid = null }) {
            return dirty || validated ? valid : null;
        },
        getData() {
            this.filtro.fechaInicio = null;
            this.filtro.fechaFin = null;
            const parametros = JSON.stringify(this.filtro);
            HTTP
                .post('api/CatalogoDiasInhabiles/BuscarFechas', parametros)
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeInfo(this.$messageConstants('apiError')));

                    if (response.status == 200) {

                        this.items = response.data;
                    }
                })
                .catch(function (error) {
                    this.MensajeError(error);
                });
        },
        validarFechas() {
            if (this.filtro.fechaInicio > this.filtro.fechaFin) {
                this.filtro.fechaFin = this.filtro.fechaInicio;
            }
        },
        buscarporFechas() {
            const parametros = JSON.stringify(this.filtro);
            HTTP
                .post('api/CatalogoDiasInhabiles/BuscarFechas', parametros)
                .then(response => {
                    debugger
                    if (response.status == 200) {
                        this.items = response.data;
                        if (this.items.length <= 0) {
                            this.MensajeWarning("La busqueda no devolvio resultados.");
                        }
                    }
                    else {
                        this.MensajeError("Ocurrio un error");
                    }
                })
                .catch(error => {
                    this.MensajeError(error)
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
        getSabado() {
            HTTP
                .get('api/CatalogoDiasInhabiles/GetSabado')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {
                        this.sabado = (response.data == "1") ? true : false;
                    }
                })
                .catch(function (error) {
                    this.MensajeError(error);
                });


        },
        getDomingo() {
            HTTP
                .get('api/CatalogoDiasInhabiles/GetDomingo')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {
                        this.domingo = (response.data == "1") ? true : false;
                    }
                })
                .catch(function (error) {
                    this.MensajeError(error);
                });

        },
        updateSabado() {
            const parametros = JSON.stringify(this.sabado);
            HTTP.post('api/CatalogoDiasInhabiles/UpdateSabado', parametros).then(responseApi => {
                if (responseApi.status == 200) {
                    let mensaje = this.sabado ? 'Los sábados quedan habilitados como días inhabiles' : 'Los sábados quedan inhabilidatdos como días inhabiles';
                    this.MensajeSuccess(mensaje);
                }
                else {
                    this.MensajeError("Se genero un error al deshabilitar el cargo valide con su administrador")
                }

            }).catch(error => {
                this.MensajeError(error)
            });


        },
        updateDomingo() {
            const parametros = JSON.stringify(this.domingo);
            HTTP.post('api/CatalogoDiasInhabiles/UpdateDomingo', parametros).then(responseApi => {
                if (responseApi.status == 200) {
                    let mensaje = this.domingo ? 'Los domingos quedan habilitados como días inhabiles' : 'Los domingos quedan inhabilidatdos como días inhabiles';
                    this.MensajeSuccess(mensaje);
                }
                else {
                    this.MensajeError("Se genero un error al deshabilitar el cargo valide con su administrador")
                }

            }).catch(error => {
                this.MensajeError(error)
            });


        },
    },
    computed: {
        rows() {
            return this.items.length
        },
    }
};
</script>

<style>
/* Estilos CSS */
.action-item:hover {
    cursor: pointer;
}
</style>
