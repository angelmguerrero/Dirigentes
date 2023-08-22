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
                        <!-- <b-button variant="outline-success" -->
                                  <!-- @click="getData" -->
                                  <!-- id="export-btn"> -->
                            <!-- <b-icon icon="arrow-counterclockwise" variant="success"></b-icon>Actualizar -->
                        <!-- </b-button> -->
                        <b-button variant="outline-success"
                                  id="export-btn">
                            <download-excel :data="itemsExport"
                                            name="PadronDirigentes.xls"
                                            type="xls"
                                            :fields="json_fields">
                                <i class="fa-solid fa-file-excel"></i> Exportar
                            </download-excel>
                        </b-button>
                        <b-button variant="outline-success"
                                  id="show-btn"
                                  @click="showCreateModal">
                            <i class="fa-solid fa-plus"></i> Nuevo
                        </b-button>
                        <b-button variant="outline-success"
                                  id="show-btn"
                                  @click="showRequestModal">
                            <i class="fa-solid fa-list"></i> Solicitud
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
                        `${data.item.idPersona} `
                        }}
                    </template>
                   
                    <template #cell(estatusPersona)="data">
                        <b-icon-bookmark-check-fill variant="success"
                                                    v-if="data.item.estatusPersona"></b-icon-bookmark-check-fill>
                        <b-icon-bookmark-x-fill variant="danger"
                                                v-else></b-icon-bookmark-x-fill>
                    </template>



                    <template v-slot:cell(acciones)="data">
                        <b-row>
                            <b-icon-pencil-square class="action-item mx-1"
                                                  size="sm" variant="primary"
                                                  @click="getRowData(data.item.idPersona, data.item.idCargoOrgano)">
                            </b-icon-pencil-square>

                            <b-icon-trash-fill class="action-item mx-1"
                                               size="sm" variant="danger"
                                               v-if="data.item.estatusPersona"
                                               @click="showDeleteModal(data.item.idPersona )">
                            </b-icon-trash-fill>
                            <b-icon-arrow-up-circle-fill class="action-item mx-1"
                                               size="sm" variant="success"
                                               v-if="!data.item.estatusPersona"
                                              
                                               @click="getRowDataReingreso(data.item.idPersona)">
                            </b-icon-arrow-up-circle-fill>
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
                 title="Nuevo Condición de Ingreso"
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
                 :title="modalDirigente"
                 size="xl"
                 header-bg-variant="success"
                 header-text-variant="light"
                 body-bg-variant="light"
                 no-stacking>
            <edit-form @closeEditModal="closeEditModal"
                       @reloadDataTable="getData"
                       @showSuccessAlert="showAlertUpdate"
                       :id="id"
                       :reingreso="reingreso">
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
                          :id="id"
                          :idcargoxorgano="idcargoxorgano"></delete-modal>
        </b-modal>
        <!--Request Modal-->
        <b-modal ref="request-modal"
                 size="xl"
                 header-bg-variant="success"
                 header-text-variant="light"
                 body-bg-variant="light"
                 
                 title="Solicitudes">
            <request-modal @CloseRequestModal="CloseRequestModal"
                           @reloadDataTable="getData"
                           @showDeleteAlert="showDeleteSuccessModal"
                           :id="id"></request-modal>
            <template #modal-footer="{ ok, cancel }">
                <b-button size="sm" variant="success" @click="ok()">
                    Guardar
                </b-button>
                <b-button size="sm" variant="danger" @click="cancel()">
                    Cancelar
                </b-button>
            </template>
        </b-modal>


    </div>

</template>

<script>

    import CreateForm from "@/components/PadronD/CreateForm.vue";
    import EditForm from "@/components/PadronD/EditForm.vue";
    import DeleteModal from "@/components/PadronD/DeleteModal.vue";
    import RequestModal from "@/components/PadronD/Solicitud/ModalSolicitudcom.vue";
    import moment from 'moment';
    import { config } from "@/config/auth";
    import store from '@/store' 


    export default {
        name: "dtPadronDirigente",
        data() {
            return {
                fields: [
                    { key: 'cif', label: 'CIF', sortable: true },
                    //{ key: 'idPersona',      label: 'Id', sortable: true },
                    { key: 'nombrePersonaCompleto', label: 'Nombre', sortable: true },
                    { key: 'fechaNacimiento', label: 'Fecha Nto', sortable: true, formatter: "formatDate" },
                    { key: 'edad', label: 'Edad', sortable: true },
                    { key: 'edad', label: 'Edad', sortable: true },
                    { key: 'plaza',   label: 'Plaza', sortable: true },
                    { key: 'sucursal', label: 'Sucursal', sortable: true },
                    { key: 'descripcionOrgano', label: 'Órgano', sortable: true },
                    { key: 'descripcionCargo', label: 'Cargo', sortable: true },
                    { key: 'estatusPersona', label: 'Estatus', sortable: true },
                    'acciones'
                ],
                items: [],
                itemsExport:[],
                modalDirigente:null,
                id: 0,
                tableHeader: "",
                perPage: 10,  //Numero de registros por pagina
                sortDesc: false,
                filter: null,
                showSuccessAlert: false,
                alertMessage: "",
                currentPage: 1,
                idcargoxorgano: 0,
                reingreso: false,
                correoDir:'',
                json_fields: {
                     ID: "idDirigente",
                    "Nombre": "nombrePersonaCompleto",
                    "Número Socio": "cif",
                    "No. Cuenta de Mexicana": "cuentaMexicana",
                     Plaza: "plaza",
                    //"Centro de Costos": "",
                    Sucursal: "sucursal",
                    "Órgano dirigencial": "descripcionOrgano",
                    //-----"Calidad en el comité": "",
                    //"Exdirigente o excolaborador": "",
                     RFC: "rfc",
                     CURP: "curp",
                    "Género": "descripcionGenero",
                    "Estado civil": "descripcionEstadoCivil",
                    "Fecha de nacimiento":
                    {
                        field: "fechaNacimiento",
                        callback: (value) => {
                            return this.formatDate(`${value}`);
                        }
                    },
                    //"Mes de nacimiento": "",
                     Edad: "edad",
                    //"Rango de edad": "",
                     Escolaridad: "descripcionEscolaridad",
                    "Clasificación por Profesión": "descripcionClasificacion",
                    "Cargo actual": "descripcionCargo",
                    //---falta--"Condición de ingreso": "",
                    "Nivel Dirigencial":"nivelDirigencialCatDescrip",
                    "Fecha de ingreso":
                    {
                        field: "fechaIngresoNivel",
                        callback: (value) => {
                            return this.formatDate(`${value}`);
                        }
                    },
                    "Condición de ingreso":"condicionIngresoDescrip",
                    "Periodo":"periodo",
                    "Años de periodo":"aperiodo",
                    "Antigüedad en el Comité (días)":"antiguedad"
   
                     
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
            RequestModal,
        },



        mounted() {
            this.getData();
            this.getDataExport();
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
            getDataExport(){
                var correoDir = this.$store.getters['user/getCorreoDirigente'];
                 this.correoDirigente = correoDir;
                // console.log("correoDirigente:", this.correoDirigente) 
                 const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                 fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/ObtenerPersonaCargoNivel', { headers })
                     .then((response) => response.json())
                     .then((data) => {
                         this.itemsExport = data;
                         console.log('datosNivel', this.itemsExport)
                     })
                     .catch(error => {
                         console.error('Error:', error)
                     });


            },
            getData() { 
                var correoDir = this.$store.getters['user/getCorreoDirigente'];
                this.correoDirigente = correoDir;
               // console.log("correoDirigente:", this.correoDirigente) 
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/ConsultarPersonaCargoOrgano', { headers })
                    .then((response) => response.json())
                    .then((data) => {
                        this.items = data;
                        console.log('datos', this.items)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            getRowData(iditem  ) {
                this.id = iditem
                this.reingreso=false
                this.modalDirigente='Editar Dirigente' 
                this.$refs["edit-modal"].show();
                console.log('id item', this.id, )
                
                
            },
            getRowDataReingreso(iditem) {
                this.id = iditem
                this.reingreso = true
                 this.modalDirigente='Reingreso Dirigente'
                this.$refs["edit-modal"].show();
                console.log('id item', this.id,)


            },
            closeEditModal() {
                this.$refs["edit-modal"].hide();
            },
            showAlertCreate() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se creó el registro',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });

            },
            showAlertUpdate() {
                this.showSuccessAlert = true;
                this.$swal.fire({
                    text: 'Se actualizó el registro',
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
                this.$swal.fire({
                    text: 'Se deshabilitó el registro',
                    icon: 'success',
                    confirmButtonText: 'Ok',
                    timer: 3000,
                });

            },
            onFiltered(filteredItems) {
                this.rows = filteredItems.length
                this.currentPage = 1
            },
            formatDate(value) {
                return moment(value).format('DD/MM/YYYY');
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
