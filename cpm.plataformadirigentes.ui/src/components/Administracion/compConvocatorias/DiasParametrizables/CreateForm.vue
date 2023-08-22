<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(addNew)">
            <b-row>
                <b-col cols="12">
                    <validation-provider name="Descripcion"
                                         :rules="{ required: true, max:250 }"
                                         v-slot="validationContext">
                        <b-form-group id="lbldescripcion"
                                      label="Descripcion"
                                      label-for="txtDescripcion">

                            <b-form-input id="txtDescripcion"
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

            <b-row>
                <b-col cols="12">
                    <validation-provider name="Dias"
                                         :rules="{ required: true , numeric, min_value: 1}"
                                         v-slot="validationContext">
                        <b-form-group id="lbldias"
                                      label="Dias"
                                      label-for="txtDias">

                            <b-form-input id="txtDias"
                                          type="number"
                                          v-model="registro.dias"
                                          :state="getValidationState(validationContext)"
                                          aria-describedby="input-1-live-feedback"
                                          min="0"
                                          trim></b-form-input>


                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>
                </b-col>
            </b-row>

            <b-row>
                <b-col cols="12">
                    <validation-provider name="Dias Naturales"
                                         :rules="{ required: true}"
                                         v-slot="validationContext">
                        <b-form-group id="lblNaturales"
                                      label="Son dias naturales">
                            <b-select v-model="registro.diasNaturales" :options="options"
                                      :state="getValidationState(validationContext)"
                                      aria-describedby="input-1-live-feedback"
                                      trim>

                            </b-select>

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
                options: [
                    { value: 'SI', text: 'SI' },
                    { value: 'NO', text: 'NO' }
                ],

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
                
                const parametros = JSON.stringify(this.registro);
                HTTP.post('api/CatalogoDiasParametrizables/Crear', parametros).then(responseApi => {
                    if (responseApi.data.resultado == true) {
                        this.$emit("closeCreateModal");
                        this.$emit("reloadDataTable");
                        this.$emit("showSuccessAlert");
                    }
                    else {
                        this.MensajeError(responseApi.data.mensaje)

                    }

                }).catch(error => {
                    this.MensajeError(error)
                });


            },
        },
    };
</script>