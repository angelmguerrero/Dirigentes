<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(addNew)">
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


            <b-row class="mt-4">
                <b-col cols="3">
                    <!--<b-button variant="success" @click="validarCampos">Guardar</b-button>-->
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
            profesion: {},
            clasificaciones: {},
            selectedOption: null,
            options: {}
        }
    },
    mounted() {
        this.getClasificacion();
    },
    methods: {
        triggerClose() {
            this.$emit("closeCreateModal");
        },
        getValidationState({ dirty, validated, valid = null }) {
            return dirty || validated ? valid : null;
        },
        addNew() {
            if (this.profesion.estatusProfesion == undefined) {

                this.profesion.estatusProfesion = true
            }

            const parametros = JSON.stringify(this.profesion);
            HTTP.post('api/CatalogoProfesion/Crear', parametros).then(responseApi => {
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
