<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(addNew)">
            <b-row>
                <b-col cols="12">
                    <validation-provider name="Responsable" :rules="{ required: true }" v-slot="validationContext">
                        <b-form-group id="id_usuario" label="Responsable" label-for="idUsuario">


                            <b-form-select v-model="selectedUsuario" :state="getValidationState(validationContext)"
                                aria-describedby="input-1-live-feedback">
                                <option v-for="optUsuario in optUsuarios" :key="optUsuario.id"
                                    :value="optUsuario.idPersona">
                                    {{ optUsuario.nombrePersonaCompleto }}
                                </option>
                            </b-form-select>

                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0]
                            }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>
                </b-col>


            </b-row>

            <b-row>
                <b-col cols="12">
                    <validation-provider name="Plaza" :rules="{ required: true }" v-slot="validationContext">
                        <b-form-group id="id_plaza" label="Plaza" label-for="idPlaza">
                            <b-form-select v-model="selectedPlaza" :state="getValidationState(validationContext)"
                                aria-describedby="input-1-live-feedback">
                                <option v-for="optPlaza in optPlazas" :key="optPlaza.id" :value="optPlaza.idPlaza">
                                    {{ optPlaza.nombre }}
                                </option>
                            </b-form-select>
                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0]
                            }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>
                </b-col>
            </b-row>
            <b-row class="mt-4">
                <b-col cols="3">
                    <!--<b-button variant="success" @click="addNew">Guardar</b-button>-->
                    <b-button type="submit" variant="success">Guardar</b-button>
                </b-col>
                <b-col>
                    <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
                </b-col>
            </b-row>
        </b-form>
    </validation-observer>
</template>

<script>
import { HTTP } from '@/plugins/axios'

export default {
    name: "CreateModal",
    data() {
        return {
            registro: {},
            //modal
            condicion: false,
            disabled: 1,
            selected: null,
            selectedPlaza: null,
            selectedUsuario: null,
            optPlazas: [],
            optUsuarios: [],
            idPlaza: '',
            idUsuario: '',
            idPErsona: ''


        };
    },
    methods: {
        triggerClose() {
            this.$emit("closeCreateModal");
        },
        getValidationState({ dirty, validated, valid = null }) {
            return dirty || validated ? valid : null;
        },
        addNew() {

            //if (this.selectedUsuario != null && this.selectedUsuario != '' && this.selectedPlaza != null && this.selectedPlaza != '') {

            this.registro.idPersona = this.selectedUsuario;
            this.registro.idPlaza = this.selectedPlaza;
            this.registro.nombre = "";
            this.registro.nombrePersona = "";

            const parametros = JSON.stringify(this.registro);

            HTTP.post('api/ResponsablePlazas/CrearResponsablePlazaPersonaNew', parametros).then(responseApi => {
                if (responseApi.data.resultado == true) {
                    this.$emit("closeCreateModal");
                    this.$emit("reloadDataTable");
                    this.$emit("showSuccessAlert");
                }
                else {
                    this.MensajeError(responseApi.data.mensaje)
                }

            }).catch(error => {
                this.MensajeError(error);
            });
        },
        ObtenerPlaza() {
            HTTP
                .get('api/PlazaWrk/ConsultarPlazas')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {
                        this.optPlazas = response.data;
                    }
                })
                .catch(function (error) {
                    this.MensajeError(error);
                });
        },
        ObtenerUsuariosConPermisoSolicitudDirigencial() {
            HTTP
                .get('api/ResponsablePlazas/UsuarioPersonaPerfilPermisoSolicitudDirigencial')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {
                        this.optUsuarios = response.data;
                    }
                })
                .catch(function (error) {
                    this.MensajeError(error);
                });


        },
        onChangePlaza: function () {
            console.log('hola', this.selectedEsta)
            this.ObtenerSucursalbyIdPlazaParametro(this.selectedEsta)
        },
    },
    mounted() {
        this.ObtenerUsuariosConPermisoSolicitudDirigencial();
        this.ObtenerPlaza();
    },

};
</script>