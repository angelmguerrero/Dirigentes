<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(addNew)">

            <b-row>
                <b-col cols="12">
                    <validation-provider name="Fecha"
                                         :rules="{ required: true, max:250}"
                                         v-slot="validationContext">
                        <b-form-group id="lblFecha"
                                      label="Fecha"
                                      label-for="txtFecha">

                            <b-form-datepicker id="txtfecha"
                                               v-model="registro.fecha"
                                               locale="es-MX"
                                               class="mb-2"
                                               placeholder="Selecciona una fecha"
                                               :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"
                                               :state="getValidationState(validationContext)"
                                               aria-describedby="input-1-live-feedback"
                                               trim></b-form-datepicker>


                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>

                </b-col>
            </b-row>

            <b-row>
                <b-col cols="12">
                    <validation-provider name="Descripcion"
                                         :rules="{ required: true, max:250}"
                                         v-slot="validationContext">
                        <b-form-group id="lblDescripcion"
                                      label="Descripcion"
                                      label-for="txtDias">

                            <b-form-input id="txtDias"
                                          type="text"
                                          v-model="registro.descripcion"
                                          :state="getValidationState(validationContext)"
                                          aria-describedby="input-1-live-feedback"
                                          trim></b-form-input>

                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>
                </b-col>
            </b-row>

            <b-row class="mt-4">
                <b-col cols="3">
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
                const params = JSON.stringify(this.registro);
                HTTP.post('api/CatalogoDiasInhabiles/Crear', params)
                    .then(response => {
                        if (response.data.resultado == true) {
                            this.$emit("closeCreateModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showSuccessAlert");
                        }
                        else {
                            this.$emit("closeCreateModal");
                            this.MensajeError(response.data.mensaje);
                        }
                    })
                    .catch(error => {
                        this.MensajeError(error)
                    });
            },
        },
    };
</script>