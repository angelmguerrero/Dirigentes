<template>
    <b-form class="mt-auto">

        <b-container>
            <b-row>
                <b-form-group id="idsolicitud"
                              label="Id solicitud"
                              label-for="idsolicitud"
                              class="col-md-4">

                    <b-form-input id="idsolicitud"
                                  type="text"
                                  disabled
                                  v-model="solicitud.idSolicitud">

                    </b-form-input>
                </b-form-group>
                <b-form-group id="nombreCompleto"
                              label="Nombre solicitud"
                              label-for="nombreCompleto"
                              class="col-md-4">

                    <b-form-input id="nombreCompleto"
                                  type="text"
                                  v-model="solicitud.nombreCompleto"
                                  disabled>
                    </b-form-input>
                </b-form-group>
                <b-form-group id="plaza"
                              label="Plaza"
                              label-for="Plaza"
                              class="col-md-4">

                    <b-form-input id="plaza"
                                  type="text"
                                  v-model="solicitud.plaza"
                                  disabled>

                    </b-form-input>
                </b-form-group>

            </b-row>

            <b-row>



                <b-form-group id="nombresolicitud"
                              label="Tipo solicitud"
                              label-for="nombresolicitud"
                              class="col-md-4">
                    <b-form-input id="nombresolicitud"
                                  type="text"
                                  v-model="solicitud.descripcionTipoMovimiento"
                                  disabled>

                    </b-form-input>
                </b-form-group>

                <b-form-group id="fecha_solicitud"
                              label="Fecha de solicitud"
                              label-for="FechaSolicitud"
                              class="col-md-4">

                    <b-form-input id="fechaSolicitud"
                                  type="text"
                                  v-model="solicitud.fechaSolicitud"
                                  disabled>

                    </b-form-input>
                </b-form-group>


                <b-form-group id="nombreCompletoResponsable"
                              label="Nombre Responsable"
                              label-for="nombreCompletoResponsable"
                              class="col-md-4">

                    <b-form-input id="nombreCompletoResponsable"
                                  type="text"
                                  v-model="solicitud.nombreCompletoResponsable" disabled>
                    </b-form-input>
                </b-form-group>
            </b-row>

            <b-row>
                <b-form-group id="nombreCompleto"
               label="Nombre solicitud"
               label-for="nombreCompleto"
               class="col-md-4">
                <b-form-input id="nombreCompleto"
                   type="text"
                   v-model="solicitud.nombreCompletoSolicitante"
                   disabled>
                </b-form-input>
             </b-form-group>
                <div class=" col-4 ">
                    <b> Estatus de la solicitud: </b>
                    <!-- <b-form-select v-model="solicitud.estatus" size="sm" :options="optionsestatus" -->
                                   <!-- @change="estatusSolicitud" :value="solicitud.estatus"> -->
                        <!-- <option :value="solicitud.estatus"> {{solicitud.estatus}} </option> -->
                    <!-- </b-form-select> -->
                    <b-form-select v-model="selectedEstatusSol"
                                   aria-describedby="input-1-live-feedback">
                        <option v-for="optionsEstatusSol in optionsEstatusSols" :key="optionsEstatusSol.value" :value="optionsEstatusSol.text">
                            {{ optionsEstatusSol.text }}
                        </option>
                    </b-form-select>


                </div>
                <b-col class="m-2 p-2">

                    <b-button variant="success" @click="detalles">Detalles</b-button>
                </b-col>
             
            </b-row>
            <loading-overlay :active='isLoading' color='#008000' />              
            <b-form-group label="Observaciones"
                          label-for="Observaciones"
                          class="mb-0">
                <b-form-textarea id="textarea-lazy"
                                 v-model="solicitud.observaciones"
                                 placeholder="Observaciones"
                                 lazy-formatter
                                 :formatter="formatter"></b-form-textarea>
            </b-form-group>
           
            <div v-if="detalleSolicitudshow">
                <br/>
                <DetalleSolicitud :idsolicitud="solicitud.idSolicitud" :idpersonanivel="solicitud.idPersona" @showSuccessAlert="showAlertCreate" @detalles="detalles"/>
            </div>
        </b-container>
        <hr />
        <b-row align-h="end" class="mt-4">
            <b-col cols="mb-3 p-2">
                <b-button variant="success" @click="update">Guardar</b-button>
                
            </b-col>
            
            <b-col cols="mb-3 p-2">
                <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
            </b-col>
        </b-row>
     
</b-form>
</template>

<script>
    import DetalleSolicitud from "@/components/PadronD/Solicitud/DetalleSolicitud.vue"
    import moment from 'moment';
    import { config } from "@/config/auth";
    import store from '@/store' 


    export default {
        name: "EditFormSol",
        props: {
            id: Number,
        },
        components: {


            DetalleSolicitud,
        },
        data() {
            return {
                solicitud: {},
                solicitudestatus: '',
                selectedEstatusSol: null,
                optionsEstatusSols:[
                { value: 1, text: 'Aprobado' },
                { value: 2, text: 'Pendiente' },
                { value: 3, text: 'En revisión' },
                { value: 4, text: 'Rechazada' }, 
                ],
                // optionsestatus: [
                    // { value: 1, text: 'Aprobado' },
                    // { value: 2, text: 'Pendiente' },
                    // { value: 3, text: 'En revisión' },
                // ],
                detalleSolicitudshow: false,
                isLoading: false,

            };
        },
        mounted() {
            this.getByID();
            this.ObtenerPlazaSolicitante();
        
        },
        methods: {
            triggerClose() {
                this.$emit("closeEditModal");
            },
              showAlertCreate() {
                this.showSuccessAlert = true;
                this.MensajeSuccess(this.$messageConstants('actualizarRegistro'))

            },
            getByID() {
                console.log('idsol', this.id)
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.id)
                    
                };


                fetch(config.auth.server_url_api + 'api/Solicitud/SolicitudpersonaresponsablebyId', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {
                        //debugger
                        this.solicitud = data;
                        this.selectedEstatusSol=this.solicitud.estatus
                        
                        //this.solicitud.fechaSolicitud = this.fechaFormato(this.solicitud.fechaSolicitud);
                        console.log("solicitud:", this.solicitud)
                   

                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },

            update() {

                this.isLoading = true;

                if (this.solicitudestatus == 'Aprobado')
                {
                    //actualizar campo de dirigente true
                    console.log('actualizapersonadirigente')
                    this.activaDirigente();

                }
             
                var body = {
                    idSolicitud: this.solicitud.idSolicitud,
                    IdPersona: this.solicitud.idPersona,
                    IdResponsablePlaza: this.solicitud.idResponsablePlaza,
                    estatus: this.selectedEstatusSol,//this.solicitud.estatus,
                    IdTipoMovimiento: this.solicitud.idTipoMovimiento,
                    FechaSolicitud: this.solicitud.fechaSolicitud,
                    observaciones: this.solicitud.observaciones,
                    IdMotivoBaja: this.solicitud.idMotivoBaja,
                    EstatusSolicitud: this.solicitud.estatusSolicitud == 1 ? true : false,
                    IdPersonaSolicitante: this.idPersonaSolicitante
                   
                }
                console.log('bodyupdate',body)
                    const requestOptions = {
                     method: 'POST',
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                        body: JSON.stringify(body)
                };
                fetch(config.auth.server_url_api + 'api/Solicitud/ModificarSolicitud', requestOptions)
                    .then(async response => {
                       
                        if (response.status == 200) {
                            this.$emit("closeEditModal");
                            this.$emit("reloadDataTable");
                            // this.$emit("showSuccessAlert");
                            this.MensajeSuccess(this.$messageConstants('actualizarRegistro'))
                            this.isLoading = false
                        }
                        else {
                            this.isLoading = false
                             this.$swal.fire({
                                text: 'Se genero un error al editar  valide con su administrador',
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                            });
                        }
                    })
                    .catch(error => {
                        this.errorMessage = error;
                        console.error('There was an error!', error);
                    });
            },

            fechaFormato(fecha) {

                let ano = new Date(fecha).getFullYear();
                let mes = new Date(fecha).getMonth() + 1;
                let dia = new Date(fecha).getDate();

                mes = mes < 10 ? "0" + mes : mes;
                dia = dia < 10 ? "0" + dia : dia;


                let salida = dia + '-' + mes + '-' + ano;
                //console.log('Sal', salida)
                return salida;

            },
            formatDate(value) {
                return moment(value).format('DD/MM/YYYY');
            },
   
            estatusSolicitud(value) {
                //this.solicitud.estatus = value
                if (value == 1) { this.solicitudestatus = 'Aprobado' }
                if (value == 2) { this.solicitudestatus = 'Pendiente' }
                if (value == 3) { this.solicitudestatus = 'En revisión' }

                console.log('estatusSolicitud', value, this.solicitudestatus)
                this.solicitud.estatus = this.solicitudestatus
            },
          
            formatter(value) {
                return value.toLowerCase()
            },
            activaDirigente() {

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.solicitud.idPersona)
                };

                fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/ActivaDirigente', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            console.log('aprobado')
                           // this.$emit("closeEditModal");
                            //this.$emit("reloadDataTable");
                        }
                        else {
                            this.MensajeError('Se genero un error al deshabilitar el cargo valide con su administrador')
                        }
                    })
                    .catch(error => {
                        this.MensajeError(error)
                    });
            },
            ObtenerPlazaSolicitante() {
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
                        console.log('personasolicitante', this.personasolicitante)
                        this.idPersonaSolicitante = this.personasolicitante.idPersona
                        this.plazaPersonaSolicitante = this.personasolicitante.plaza
                        this.idPlazaSolicitante = this.personasolicitante.plazaId

                        console.log('IDPERSONASOLICITANTE plaza', this.idPersonaSolicitante, this.plazaPersonaSolicitante, this.idPlazaSolicitante)



                    })
                    .catch(error => {
                        this.MensajeError(error) //fechaActual(
                        console.log(error)
                        this.permisoSolicitud = false
                        console.log('No es odg', this.permisoSolicitud)

                    });



            },
            detalles() {
                this.detalleSolicitudshow = !this.detalleSolicitudshow
            },

           
        },
    };
</script>
