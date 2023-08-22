<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(addNew)">
            <b-row>

                <b-col cols="12">
                    <validation-provider name="Responsable" :rules="{ required: true }" v-slot="validationContext">
                        <b-form-group id="responsable" label="Responsable" label-for="responsable">

                            <b-form-select v-model="registro.idPersona" :options="options"
                                :state="getValidationState(validationContext)" aria-describedby="input-1-live-feedback">
                            </b-form-select>

                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0]
                            }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>
                </b-col>

                <b-col cols="12">
                    <validation-provider name="Plaza" :rules="{ required: true }" v-slot="validationContext">
                        <b-form-group id="plaza" label="Plaza" label-for="plaza">

                            <b-form-select v-model="registro.idPlaza" :options="optionsPlaza"
                                :state="getValidationState(validationContext)" aria-describedby="input-1-live-feedback">
                            </b-form-select>

                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0]
                            }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>
                </b-col>

                <b-col cols="12">

                    <b-form-group id="estatus" label="Estatus" label-for="estatus">

                        <b-form-checkbox id="estatus_usuario" v-model="registro.estatus" name="estatus_usuario">
                            Responsable es Activo
                        </b-form-checkbox>


                    </b-form-group>



                </b-col>
            </b-row>


            <b-row class="mt-4">
                <b-col cols="3">
                    <b-button variant="success" @click="update">Guardar</b-button>
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
    name: "EditModal",
    props: {
        id: Number,
    },
    data() {
        return {
            registro: {},
            selectedPerfil: null,
            optPerfiles: [],
            fechaNacimientoOriginal: '',
            fechaIngresoOriginal: '',
            disabled: 1,
            estatus: '',
            options: {},
            optionsPlaza: {},
            usuario: {}
        };
    },
    mounted() {
        this.ObtenerUsuariosConPermisoSolicitudDirigencial();
        this.ObtenerPlaza();
        this.getByID();
    },
    methods: {
        triggerClose() {
            this.$emit("closeEditModal");
        },
        getValidationState({ dirty, validated, valid = null }) {
            return dirty || validated ? valid : null;
        },
        ObtenerPerfilCargo() {
            HTTP
                .get('api/PerfilCargos/ConsultarPerfilCargosActivos')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {
                        this.optPerfiles = response.data;
                    }
                })
                .catch(function (error) {
                    this.MensajeError(error);
                });
        },
        getByID() {
            const parametros = JSON.stringify(this.id);

            HTTP.post('api/ResponsablePlazas/ResponsablePlazaPersonabyId', parametros).then(responseApi => {
                if (responseApi.status == 401)
                    throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                if (responseApi.status == 200)
                    this.registro = responseApi.data;


            }).catch(error => {
                this.MensajeError(error);
            });
        },
        update() {
            const parametros = JSON.stringify(this.registro);

            HTTP.post('api/ResponsablePlazas/ActualizarResponsablePlazaPersonaNew', parametros).then(responseApi => {

                if (responseApi.data.resultado == true) {
                    this.$emit("closeEditModal");
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
                .get('api/PlazaWrk/ConsultarPlazasActivo')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {
                        this.optionsPlaza = response.data;
                    }
                })
                .catch(function (error) {
                    this.MensajeError(error);
                });
        },
        ObtenerUsuariosConPermisoSolicitudDirigencial() {
            HTTP
                .get('api/ResponsablePlazas/UsuarioPersonaPerfilPermisoSolicitudDirigencialActivo')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {
                        this.options = response.data;
                    }
                })
                .catch(function (error) {
                    this.MensajeError(error);
                });


        },
    },
};
</script>