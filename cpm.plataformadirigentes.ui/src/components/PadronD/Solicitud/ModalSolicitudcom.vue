<template>
    <div>
        <!-- C�digo HTML -->
        <b-card-text>
            <b-row>
                <b-col class="col-8">
                    <h3>{{ tableHeader}}</h3>
                </b-col>
                <b-col class="col-4">

                    <b-button-group size="sm">
                        <b-button variant="outline-success"
                                  id="export-btn">
                            <download-excel :data="items"
                                            name="Solicitudes.xls"
                                            type="xls"
                                            :fields="json_fields"
                                            >
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
                <div v-if="solicitudlist">
                    <b-card>
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

                            <template #cell(estatusSolicitud)="data">
                                <b-icon-bookmark-check-fill variant="success"
                                                            v-if="data.item.estatusSolicitud"></b-icon-bookmark-check-fill>
                                <b-icon-bookmark-x-fill variant="danger"
                                                        v-else></b-icon-bookmark-x-fill>
                            </template>



                            <template v-slot:cell(actions)="data">
                                <b-row>
                                    <b-icon-pencil-square class="action-item mx-1"
                                                          size="sm" variant="primary"
                                                          @click="getRowData(data.item.idSolicitud)">
                                    </b-icon-pencil-square>

                                    <b-icon-trash-fill class="action-item mx-1"
                                                       size="sm" variant="danger"
                                                       v-if="data.item.estatusSolicitud"
                                                       @click="showDeleteModal(data.item.idSolicitud)">
                                    </b-icon-trash-fill>

                                </b-row>
                            </template>

                        </b-table>
                        <b-pagination v-model="currentPage"
                                      :total-rows="rows"
                                      :per-page="perPage"
                                      aria-controls="my-table"
                                      first-text="Primero"
                                      prev-text="Anterior"
                                      next-text="Siguiente"
                                      last-text="Ultimo"></b-pagination>
                    </b-card>
                </div>
                <div v-else><h3>No tienes solicitudes</h3></div>
            </div>
        </b-card-text>

        <!--Modal for add-->
        <b-modal ref="create-modal"
                 hide-footer
                 title="Nuevo Condici�n de Ingreso"
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
        <b-modal ref="edit-modalSol"
                 title="Editar Solicitud"
                 size="xl"
                 hide-footer
                 >
            <EditFormSol @closeEditModal="closeEditModal"
                         @reloadDataTable="getData"
                         @showSuccessAlert="showAlertUpdate"
                         :id="id">
            </EditFormSol>

        </b-modal>
        <!--Delete Modal-->
        <b-modal ref="delete-modal"
                 size="md"
                 hide-footer
                 title="Confirmar Eliminar">
            <delete-modal @closeDeleteModal="closeDeleteModal"
                          @reloadDataTable="getData"
                          @showDeleteAlert="showDeleteSuccessModal"
                          :id="id"
                          ></delete-modal>
        </b-modal>
        <!--Request Modal-->
        <b-modal ref="request-modal"
                 size="lg"
                 header-bg-variant="success"
                 header-text-variant="light"
                 body-bg-variant="light"
                 title="Solicitudes">
            <request-modal @CloseRequestModal="CloseRequestModal"
                           @reloadDataTable="getData"
                           @showDeleteAlert="showDeleteSuccessModal"
                           :id="id"></request-modal>
            <template #modal-footer="{ ok }">
                <b-button size="sm" variant="success" @click="ok()">
                    ok
                </b-button>
                <!--<b-button size="sm" variant="danger" @click="cancel()">
                    Cancelar
                </b-button>-->
            </template>
        </b-modal>


    </div>

</template>

<script>

    import store from '@/store'   
    import EditFormSol from "@/components/PadronD/Solicitud/EditFormSol.vue";
    import DeleteModal from "@/components/PadronD/Solicitud/DeleteModal.vue";
    import RequestModal from "@/components/PadronD/Solicitud/ModalSolicitudcom.vue";
    import moment from 'moment';
    import { config } from "@/config/auth";

    export default {
        name: "dtSolicitud",
        data() {
            return {
                fields: [
                    { key: 'idSolicitud', label: 'Solicitud', sortable: true },
                    { key: 'nombreCompleto', label: 'Nombre Solicitud', sortable: true },
                    { key: 'nombreCompletoSolicitante', label: 'Nombre Solicitante', sortable: true },
                    { key: 'plaza', label: 'Plaza', sortable: true },
                    { key: 'sucursal', label: 'Sucursal', sortable: true },
                    { key: 'descripcionTipoMovimiento', label: 'Movimiento ', sortable: true },
                    { key: 'fechaSolicitud', label: 'Fecha solicitud', sortable: true, formatter: "formatDate" },
                    { key: 'observaciones', label: 'Observaciones', sortable: true },
                    { key: 'estatus', label: 'Estatus', sortable: true },
                    { key: 'estatusSolicitud', label: 'Estatus Solicitud', sortable: true },
                    'actions'
                ],
                items: [],
                id: 0,
                tableHeader: "",
                perPage: 5,  //Numero de registros por pagina
                sortDesc: false,
                filter: null,
                showSuccessAlert: false,
                alertMessage: "",
                currentPage: 1,
                solicitudlist:true,
                json_fields: {
                 "ID Solicitud": "idSolicitud",
                 "Nombre":"nombreCompleto",
                 "Plaza":"plaza",
                 "Sucursal":"sucursal",
                 "Estatus de la solicitud":"estatus",
                 "Fecha de Solicitud":
                    {
                        field: "fechaSolicitud",
                        callback: (value) => {
                            return this.formatDate(`${value}`);
                        }
                    },
                    "Observaciones":"observaciones",
                    "Nombre Solicitante":"nombreCompletoSolicitante",
                    "Tipo de Movimiento":"descripcionTipoMovimiento",  
                }
                
               

            }
        },
        components: {
         
            EditFormSol,
            DeleteModal,
            RequestModal,
           
        },
        mounted() {
            this.ObtenerSolicitante();
           
          
           
        },
        methods: {
            showCreateModal() {
                this.$refs["create-modal"].show();
            },
            closeCreateModal() {
                this.$refs["create-modal"].hide();
            },
            showRequestModal() {
                this.$refs["request-modal"].show();
            },
            CloseRequestModal() {
                this.$refs["request-modal"].hide();
            },
            getData() {
                console.log('data', this.correoDirigente)
                
                const requestOptions = {
                    method: 'PUT',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.personasolicitante.idPersona)
                };
                fetch(config.auth.server_url_api + 'api/Solicitud/ConsultarSolicitudesbyIdresponsable', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {
                       
                        this.items = data;
                        console.log('solicitud', this.items)
                        //fechaSolicitud = formatDate(this.items.fechaSolicitud)
                        this.$emit("reloadDataTable");

                        if (this.items == '' || this.items == null || this.items == 0 ) {
                            //console.log('datossolicitud vacio', this.items)
                            this.solicitudlist==false
                        }
                        else {
                           // console.log('datossolicitud', this.items)
                            this.solicitudlist == true
                        }
                        
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
                console.log('datossolicitud')
            },
              getRowData(iditem) {
                this.id = iditem;
                this.$refs["edit-modalSol"].show();
            },
            closeEditModal() {
                console.log('cerrarmodal')
                this.$refs["edit-modalSol"].hide();
                this.$emit("reloadDataTable");
            },
            showAlertCreate() {
                this.showSuccessAlert = true;
                this.MensajeSuccess(this.$messageConstants('actualizarRegistro'))

            },
            showAlertUpdate() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se actualiz� el registro',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });
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
            formatDate(value) {
                return moment(value).format('DD/MM/YYYY');
            },
            ObtenerSolicitante() {
                //obtener correo usuario
                var correoDir = this.$store.getters['user/getCorreoDirigente'];
                this.correoDirigente = correoDir;
                console.log("solicitante--plaza:", this.correoDirigente)

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.correoDirigente)
                };
                console.log('correo', this.correoDirigente)

                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilPermisoPlaza', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.personasolicitante = data;
                        console.log('personasolicitante', this.personasolicitante, this.personasolicitante.idPersona)
                        this.getData();
                        console.log('personasolicitante')

                       
                    })
                    .catch(error => {
                        this.MensajeError(error) //fechaActual(
                        console.log(error)
                        this.permisoSolicitud = false
                        console.log('No es odg', this.permisoSolicitud)

                    });

              

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
