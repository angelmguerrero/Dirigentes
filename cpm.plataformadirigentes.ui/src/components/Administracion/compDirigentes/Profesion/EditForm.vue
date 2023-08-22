<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(update)">
            <b-row>
                <b-col cols="12">
                    <validation-provider name="Profesión" :rules="{ required: true, max: 250 }" v-slot="validationContext">
                        <b-form-group id="descripcion" label="Profesión" label-for="descripcion">


                            <b-form-input id="descripcion" type="text" v-model="profesion.descripcion"
                                :state="getValidationState(validationContext)" aria-describedby="input-1-live-feedback"
                                trim></b-form-input>

                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0]
                            }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>
                </b-col>
            </b-row>

            <b-row>
                <b-col cols="12">
                    <validation-provider name="Clasificación por Profesión" :rules="{ required: true }"
                        v-slot="validationContext">
                        <b-form-group id="clasificacion" label="Clasificación por Profesión" label-for="clasificacion">

                            <b-select v-model="profesion.idClasificacionProfesion" :options="options"
                                :state="getValidationState(validationContext)" aria-describedby="input-1-live-feedback">

                            </b-select>
                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0]
                            }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>
                </b-col>
            </b-row>

            <b-row>
                <b-col cols="12">
                    <b-form-checkbox id="estatus_profesion" v-model="profesion.estatusProfesion" name="profesion-status">
                        Activo
                    </b-form-checkbox>
                </b-col>

            </b-row>
            <b-row class="mt-4">
                <b-col cols="3">
                    <!--<b-button variant="success" @click="update">Guardar</b-button>-->
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
    name: "EditModal",
    props: {
        id: Number,
    },
    data() {
        return {
            profesion: {},
            clasificaciones: {},
            options: {}
        };
    },
    mounted() {
        this.getClasificacion();
        this.getByID();
    },
    methods: {
        triggerClose() {
            this.$emit("closeEditModal");
        },
        getValidationState({ dirty, validated, valid = null }) {
            return dirty || validated ? valid : null;
        },
        getByID() {
            const parametros = JSON.stringify(this.id);
            HTTP.post('api/CatalogoProfesion/RegistrobyId', parametros).then(responseApi => {
                if (responseApi.status == 401)
                    throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                if (responseApi.status == 200)
                    this.profesion = responseApi.data;


            }).catch(error => {
                this.MensajeError(error);
            });

        },
        update() {
            const parametros = JSON.stringify(this.profesion);

            HTTP.post('api/CatalogoProfesion/Update', parametros).then(responseApi => {
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
        getClasificacion() {
            HTTP
                .get('api/CatalogoProfesion/ConsultarClasificaciones')
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
