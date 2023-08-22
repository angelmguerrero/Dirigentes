<template>
    <div>
        <validation-observer ref="observer" v-slot="{ handleSubmit }">
            <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(addNew)">
                <b-row>
                    <b-col cols="12">
                        <validation-provider name="Genero"
                                             :rules="{ required: true, max:20}"
                                             v-slot="validationContext">
                            <b-form-group id="lblgenero"
                                          label=""
                                          label-for="txtGenero"><label>G&eacute;nero</label>
                                <b-form-input id="txtGenero"
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
                        <!--<b-button variant="success" @click="validarCampos">Guardar</b-button>-->
                        <b-button type="submit" variant="success">Guardar</b-button>

                    </b-col>
                    <b-col>
                        <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
                    </b-col>
                </b-row>
            </b-form>
        </validation-observer>
    </div>
</template>

<script>
    import { HTTP } from '@/plugins/axios'

    export default {
        name: "CreateModal",
        computed: {
        },
        data() {
            return {
                registro: {},
            };
        },
        methods: {
            getValidationState({ dirty, validated, valid = null }) {
                return dirty || validated ? valid : null;
            },
            triggerClose() {
                this.$emit("closeCreateModal");
            },
            addNew() {
                const parametros = JSON.stringify(this.registro);
                HTTP.post('api/CatalogoGenero/Crear', parametros).then(responseApi => {
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