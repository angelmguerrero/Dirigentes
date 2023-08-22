<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(update)">

            <b-row>
                <b-col cols="12">
                    <validation-provider name="Estado Civil" :rules="{ required: true, max: 50 }" v-slot="validationContext">
                        <b-form-group id="lbldescripcion" label="Estado Civil" label-for="txtDescripcion">
                            <b-form-input id="txtDescripcion" type="text" v-model="registro.descripcion"
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
                    <b-form-checkbox id="lblestatus" v-model="registro.estatusEstadoCivil" name="cbxstatus">
                        Registro es Activo
                    </b-form-checkbox>
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
    name: "EditModal",
    props: {
        id: Number,
    },
    data() {
        return {
            registro: {},
        };
    },
    mounted() {
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

            HTTP.post('api/CatalogoEstadoCivil/RegistrobyId', parametros).then(responseApi => {
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

            HTTP.post('api/CatalogoEstadoCivil/Update', parametros).then(responseApi => {
                if (responseApi.data.resultado == true) {
                    this.$emit("closeEditModal");
                    this.$emit("reloadDataTable");
                    this.$emit("showSuccessAlert");
                }
                else {
                    this.MensajeError('Se genero un error al deshabilitar el cargo valide con su administrador')
                }

            }).catch(error => {
                this.MensajeError(error);
            });



        },
    },
};
</script>
