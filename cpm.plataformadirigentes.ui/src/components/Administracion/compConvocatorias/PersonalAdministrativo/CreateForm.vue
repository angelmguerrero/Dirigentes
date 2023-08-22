<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(addNew)">

            <b-row>
                <b-col cols="12">
                    <validation-provider name="Nombre Participante"
                                         :rules="{ required: true, max:255 }"
                                         v-slot="validationContext">
                        <b-form-group id="lblNombreParticipante"
                                      label="Nombre Participante"
                                      label-for="txtNombrePArticipanteOculto">

                            <b-form-input id="txtNombrePArticipanteOculto"
                                          type="text"
                                          v-model="registro.nombreParticipanteOculto"
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
                    <validation-provider name="Correo Participante"
                                         :rules="{ required: true , email, max:400 }"
                                         v-slot="validationContext">
                        <b-form-group id="lblCorreo"
                                      label="Correo Participante"
                                      label-for="txtCorreo">

                            <b-form-input id="txtCorreo"
                                          type="text"
                                          v-model="registro.correoParticipante"
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
                const parametros = JSON.stringify(this.registro);
                
                HTTP.post('api/CatalogoPersonalAdministrativo/Crear', parametros).then(responseApi => {
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
        },
    };
</script>