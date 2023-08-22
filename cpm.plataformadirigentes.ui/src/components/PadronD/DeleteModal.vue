<template>
    <div>
        <b-row class="mt-2 mb-3">
            <h6 class="text-secondary">
                &iquest; Est&aacute; seguro que quiere deshabilitar al Dirigente ? Si es as&iacute;, favor de capturar Motivo y Tipo de baja
            </h6>
        </b-row>

        <b-row>

            <b-col cols="6">
                <b-form-group id="id_MotivoBaja"
                              label="Motivo de Baja"
                              label-for="idMotivoBaja">


                    <b-form-select v-model="selectedMotivoBaja">
                        <option v-for="optMotivoBaja in optMotivosBaja" :key="optMotivoBaja.id" :value="optMotivoBaja.idMotivoBaja">
                            {{ optMotivoBaja.descripcion }}
                        </option>
                    </b-form-select>

                </b-form-group>
            </b-col>

            <b-col cols="6">
                <b-form-group id="id_TipoBaja"
                              label="Tipo de Baja"
                              label-for="idTipoBaja">


                    <b-form-select v-model="selectedTipoBaja">
                        <option v-for="optTipoBaja in optTiposBaja" :key="optTipoBaja.id" :value="optTipoBaja.idTipoBaja">
                            {{ optTipoBaja.descripcion }}
                        </option>
                    </b-form-select>

                </b-form-group>
            </b-col>
            
        </b-row>
        <loading-overlay :active='isLoading' color='#008000' />
           <b-row align-h="end" class="mt-4">
            <b-col cols="mb-3 p-2">
                <b-button variant="danger" @click="validaExistenciaResponsablePlaza">Deshabilitar</b-button>
            </b-col>
            <b-col cols="mb-3 p-2">
                <b-button variant="warning" @click="triggerClose">Cerrar</b-button>
            </b-col>
        </b-row>
    </div>
</template>

<script>
import store from '@/store'
    import { config } from "@/config/auth";
    import { HTTP } from '@/plugins/axios'


    export default {
        name: "DeleteModal",
        data() {
            return {
                registro: {},
                responsablePlazaBusqueda: {},
                //modal
                condicion: false,
                disabled: 1,
                optMotivosBaja: [],
                optTiposBaja: [],
                selectedMotivoBaja: null,
                selectedTipoBaja: null,
                idMotivoBaja: 0,
                idResponsablePlaza: '',
                ////
                correoDirigente: '',
                idPersonaSolicitante: '',
                plazaPersonaSolicitante: '',
                idPlazaSolicitante: '',
                personaAutorizada: '',
                esdirigenteSolAct: '',
                actualizapersonaestatus: '',
                isLoading: false,
            };
        },
        props: {
            id: Number,

            //idcargoxorgano: Number,
        },
        methods: {
            triggerClose() {
                this.$emit("closeDeleteModal");
            },
            validaExistenciaResponsablePlaza() {
                this.isLoading = true;
                //valida plaza
                if (this.idPlazaSolicitante == this.persona.idPlaza) {
                    console.log('Esde la plaza', this.persona.idPlaza)
                    this.validaResponsableplaza();
                 
                }
                //valida plaza
                else {
                    console.log('No es de la plaza', this.idPlazaSolicitante, this.persona.idPlaza)
                    this.$swal.fire({
                        text: 'No es posible la eliminacion debido a que no es de la misma plaza',
                        icon: 'warning',
                        confirmButtonText: 'Ok',
                    });

                }




            },
            validaResponsableplaza() {

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.id)
                };


                //debugger
                fetch(config.auth.server_url_api + 'api/ResponsablePlazas/ResponsablePlazaPersonabyIdPersona', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.responsablePlazaBusqueda = data;
                        console.log('this.responsablePlazaBusqueda', this.responsablePlazaBusqueda)
                        //debugger

                        this.idResponsablePlaza = this.responsablePlazaBusqueda.idResponsablePlaza;// == null ? 0 : this.usuarioBusqueda.cif;
                        // console.log("usuario:", this.usuarioBusqueda)
                        // console.log('usuarioBusqueda', this.usuarioBusqueda)
                        console.log('this.idResponsablePlaza', this.idResponsablePlaza)
                        //debugger
                        if (this.idResponsablePlaza != '' && this.idResponsablePlaza != null && this.idResponsablePlaza != 0) {
                            this.removeFromData();
                            


                        }
                        else {
                            this.$swal.fire({
                                text: 'No es posible la eliminacion debido a que no existen responsables de plaza para la plaza de la persona, favor de validar.',
                                icon: 'warning',
                                confirmButtonText: 'Ok',

                            });
                        }

                    })
            },
            removeFromData() {
                
                if (this.permisoSolicitud == true) {
                    //Es Odg
                    this.removeData()

                    console.log(' Es ODG  solicitud aprobada------')
                    if (this.selectedMotivoBaja != null && this.selectedMotivoBaja != '' && this.selectedTipoBaja != null && this.selectedTipoBaja != '') {

                        console.log('this.selectedMotivoBaja', this.selectedMotivoBaja)
                        var body = {

                            IdPersona: this.id,
                            estatus: 'Aprobado',
                            IdTipoMovimiento: 2,
                            observaciones: '',
                            idMotivoBaja : this.selectedMotivoBaja,
                            EstatusSolicitud: false,
                            idTipoBaja:  this.selectedTipoBaja,
                            IdPersonaSolicitante: this.idPersonaSolicitante,


                        }
                        console.log('body', body)
                        const requestOptions = {
                            method: 'POST',
                            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                            body: JSON.stringify(body)
                        };


                        fetch(config.auth.server_url_api + 'api/Solicitud/SolicitudCrear', requestOptions)
                            .then((response) => response.json())
                            .then((data) => {


                                this.solicituddata = data;
                                console.log('solicitud', this.solicituddata, this.solicituddata.idSolicitud)
                                this.$emit("closeDeleteModal");
                                this.$emit("reloadDataTable");
                                this.$emit("showDeleteAlert");
                                //this.crearPersonaSolicitudHist();
                               
                            })
                            .catch(error => {
                                console.error('Error:', error)
                            });

                        //fcosp
                        //this.registro.idPersona = this.id;
                        //this.registro.idMotivoBaja = this.selectedMotivoBaja;
                        //this.registro.idTipoBaja = this.selectedTipoBaja;
                        //this.registro.descripcionTipoBaja = "";
                        //this.registro.descripcionMotivoBaja = "";
                        //this.registro.idPersonaSolicitante = this.idPersonaSolicitante;
                        //this.registro.estatus = 'Aprobado';

                        //const requestOptions = {
                        //    method: 'POST',
                        //    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                        //    body: JSON.stringify(this.registro)

                        //};

                        ////   fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/Delete', requestOptions)
                        //fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/DeletePersonaInsertarSolicitudBaja', requestOptions)
                        //    .then(async response => {

                        //        if (response.status == 200) {
                        //            this.$emit("closeDeleteModal");
                        //            this.$emit("reloadDataTable");
                        //            this.$emit("showDeleteAlert");

                        //        }
                        //        else {
                        //            this.$swal.fire({
                        //                text: 'Se genero un error al deshabilitar el cargo valide con su administrador',
                        //                icon: 'error',
                        //                confirmButtonText: 'Ok',
                        //                timer: 3000,
                        //            });
                        //        }
                        //    })
                        //    .catch(error => {
                        //        console.error('Error:', error)
                        //    });

                    }
                    else {
                        this.isLoading = false
                        this.$swal.fire({
                            text: 'Favor de capturar el Motivo y Tipo de baja.',
                            icon: 'warning',
                            confirmButtonText: 'Ok',

                        });
                    }
                }
                else {
                    console.log(' No es ODG  solicitud Pendiente------')
                    
                    if (this.selectedMotivoBaja != null && this.selectedMotivoBaja != '' && this.selectedTipoBaja != null && this.selectedTipoBaja != '') {

                        console.log('this.selectedMotivoBaja', this.selectedMotivoBaja)
                        var body2 = {

                            IdPersona: this.id,
                            estatus: 'Pendiente',
                            IdTipoMovimiento: 2,
                            observaciones: '',
                            idMotivoBaja: this.selectedMotivoBaja,
                            EstatusSolicitud: true,
                            idTipoBaja: this.selectedTipoBaja,
                            IdPersonaSolicitante: this.idPersonaSolicitante,


                        }
                        console.log('body', body2)
                        const requestOptions = {
                            method: 'POST',
                            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                            body: JSON.stringify(body2)
                        };


                        fetch(config.auth.server_url_api + 'api/Solicitud/SolicitudCrear', requestOptions)
                            .then((response) => response.json())
                            .then((data) => {


                                this.solicituddata = data;
                                console.log('solicitud', this.solicituddata, this.solicituddata.idSolicitud)
                                this.crearPersonaSolicitudHist();

                            })
                            .catch(error => {
                                console.error('Error:', error)
                            });
                        //this.registro.idPersona = this.id;
                        //this.registro.idMotivoBaja = this.selectedMotivoBaja;
                        //this.registro.idTipoBaja = this.selectedTipoBaja;
                        //this.registro.descripcionTipoBaja = "";
                        //this.registro.descripcionMotivoBaja = "";
                        //this.registro.idPersonaSolicitante = this.idPersonaSolicitante;
                        //this.registro.estatus = 'Pendiente';

                        //const requestOptions = {
                        //    method: 'POST',
                        //    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                        //    body: JSON.stringify(this.registro)

                        //};

                        ////   fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/Delete', requestOptions)
                        //fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/DeletePersonaInsertarSolicitudBaja', requestOptions)
                        //    .then(async response => {

                        //        if (response.status == 200) {
                        //            this.$emit("closeDeleteModal");
                        //            this.$emit("reloadDataTable");
                        //            this.$emit("showDeleteAlert");

                        //        }
                        //        else {
                        //            this.$swal.fire({
                        //                text: 'Se genero un error al deshabilitar el cargo valide con su administrador',
                        //                icon: 'error',
                        //                confirmButtonText: 'Ok',
                        //                timer: 3000,
                        //            });
                        //        }
                        //    })
                        //    .catch(error => {
                        //        console.error('Error:', error)
                        //    });

                    }
                    else {
                        this.$swal.fire({
                            text: 'Favor de capturar el Motivo y Tipo de baja.',
                            icon: 'warning',
                            confirmButtonText: 'Ok',

                        });
                    }
                }


              
            },
            removeFromDataxcargo() {


                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.id,)
                };

                fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/DeletePersonaxCargo', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            this.$emit("closeDeleteModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showDeleteAlert");
                        }
                        else {
                            this.$swal.fire({
                                text: 'Se genero un error al deshabilitar el cargo valide con su administrador',
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                            });
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },

            ObtenerMotivoBaja() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoMotivoBaja/ConsultarSinMotivo', {headers})
                    .then((response) => response.json())
                    .then((data) => {
                        // debugger
                        this.optMotivosBaja = data;
                        console.log('motivos baja', this.optMotivosBaja)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            ObtenerTipoBaja() {
                 const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoTipoBaja/ConsultarActivas', {headers})
                    .then((response) => response.json())
                    .then((data) => {
                        // debugger
                        this.optTiposBaja = data;
                        console.log('tipos baja', this.optTiposBaja)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            getByID() {
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.id)
                };

               

                fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/PersonabyId', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {
                        //debugger
                        this.persona = data;
                       
                        console.log("persona:------", this.persona)
                    


                    })
                    .catch(error => {
                        console.error('Error:', error)
                        this.Organotable = false
                    });
            },

            ObtenerEsODG() {
                //obtener correo usuario odg
                var correoDir = this.$store.getters['user/getCorreoDirigente'];
                this.correoDirigente = correoDir;
                console.log("correoDirigente---es odg:", this.correoDirigente)

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.correoDirigente)
                };
                console.log('correo', this.correoDirigente)

                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilPermisoSolicitudDirigencialbyCorreo', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.personaAutorizada = data;
                        console.log('personaAutorizada', this.personaAutorizada)



                        if (this.personaAutorizada == '' || this.personaAutorizada == null || this.personaAutorizada == 0) {
                            this.permisoSolicitud = false
                            console.log('No es odg', this.permisoSolicitud)
                        }
                        else {
                            this.permisoSolicitud = true
                            console.log('Usuario con permisos ODG', this.permisoSolicitud)
                        }

                    })
                    .catch(error => {
                        //this.MensajeError(error) //fechaActual(
                        console.log(error)
                        this.permisoSolicitud = false
                        console.log('No es odg', this.permisoSolicitud)

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


                    });
            },
            crearPersonaSolicitudHist() {
                console.log('crearPersonaSolicitudHist', this.persona, this.persona.sucursalId)
                //debugger
                var body = {
                    idPersona: this.persona.idPersona,
                    nombrePersona: this.persona.nombrePersona,
                    estatusPersona: this.persona.estatusPersona == 1 ? true : false,
                    idTipoPersona: 1,//this.selectedTipoPersona,
                    idCargo: this.persona.idCargo,
                    idSubUnidadOperativa: 1,
                    idGenero: this.persona.idGenero,
                    idEstadoCivil: this.persona.idEstadoCivil,
                    idOficio: this.persona.idOficio,
                    //idEscolaridad: this.persona.idEscolaridad,
                    idEscolaridad: this.persona.idEscolaridad,
                    apellidoMaterno: this.persona.apellidoMaterno,
                    apellidoPaterno: this.persona.apellidoPaterno,
                    fechaNacimiento: this.persona.fechaNacimiento,
                    rfc: this.persona.rfc,
                    curp: this.persona.curp,
                    edad: this.persona.edad,
                    codigoPostal: this.persona.codigoPostal,
                    celular: this.persona.celular,
                    fechaIngreso: this.persona.fechaIngreso,
                    fechaBaja: this.persona.fechaBaja,
                    cif: this.persona.cif,
                    dirigente: this.persona.dirigente,
                    idDirigente: this.persona.idDirigente,
                    idRepresententanteCargoCat: 1,
                    //idProfesion: this.persona.idProfesion,
                    idProfesion: this.persona.idProfesion,
                    calle: this.persona.calle,
                    numeroInterior: this.persona.numeroInterior,
                    colonia: this.persona.colonia,
                    estado: this.persona.estado,
                    municipio: this.persona.municipio,
                    plaza: this.persona.plaza,
                    idPlaza: this.persona.idPlaza,
                    idSucursal: this.persona.idSucursal,
                    sucursal: this.persona.sucursal,
                    correoPersonal: this.persona.correoPersonal,
                    fechaCreacion: this.persona.fechaIngreso,
                    cuentaMexicana: this.persona.cuentaMexicana,
                    idSolicitud: this.solicituddata.idSolicitud,
                    estatusPersonSolicitud: true,



                }
                console.log('body', body)
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(body)
                };
                fetch(config.auth.server_url_api + 'api/PersonaSolicitudHist/Crear', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            console.log('PersonaSolicitudHis creada')

                            this.$emit("closeDeleteModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showDeleteAlert");
                            this.isLoading = false

                        }
                        else {
                            this.MensajeError('Error valide con su administrador')
                            this.isLoading = false
                        }
                    })
                    .catch(error => {
                        this.errorMessage = error;
                        console.error('Error valide con su administrador', error);
                        this.isLoading = false

                    });

            },
           
            removeData() {
                const parametros = JSON.stringify(this.id);
                HTTP.post('api/PersonaPerfilCargoOrgano/Delete', parametros).then(responseApi => {
                    if (responseApi.status == 200) {
                        //this.$emit("closeDeleteModal");
                        //this.$emit("reloadDataTable");
                        //this.$emit("showDeleteAlert");
                        console.log('desactivado')

                    }
                    else {
                        this.MensajeError(this.$messageConstants('errorConfirmarBorrado'))
                    }

                }).catch(error => {
                    this.MensajeError(error)
                });
            },
          },
            mounted() {
                // this.ObtenerPlaza();
                //  this.ObtenerSucursal();
                this.ObtenerMotivoBaja();
                this.ObtenerTipoBaja();
                this.getByID();
                this.ObtenerEsODG();
                this.ObtenerPlazaSolicitante();
            }
        };
</script>