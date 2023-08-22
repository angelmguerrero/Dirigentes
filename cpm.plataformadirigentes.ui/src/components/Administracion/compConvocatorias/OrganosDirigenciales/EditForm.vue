<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(update)">
            <b-row>
                <b-col cols="12">
                    <validation-provider name="Organo Dirigencial" :rules="{ required: true, max: 200 }"
                        v-slot="validationContext">
                        <b-form-group id="lbldescOrgano" label-for="txtdescOrgano">
                            <label>Nombre &Oacute;rgano Dirigencial </label>
                            <b-form-input id="txtdescOrgano" type="text" v-model="registro.descripcion"
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
                    <validation-provider name="Nivel" :rules="{ required: true }" v-slot="validationContext">
                        <b-form-group id="lblNivel" label="Nivel">
                            <b-select v-model="registro.idNivelGestion" :options="optionsnivel"
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
                    <validation-provider name="Abreviatura" :rules="{ required: true, max: 50 }" v-slot="validationContext">
                        <b-form-group id="lblabreviaturaOrgano" label="Abreviatura" label-for="txtabreviaturaOrgano">
                            <b-form-input id="txtabreviaturaOrgano" type="text" v-model="registro.abreviaturaOrgano"
                                :state="getValidationState(validationContext)" aria-describedby="input-1-live-feedback"
                                trim>></b-form-input>

                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0]
                            }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>
                </b-col>
            </b-row>
            <b-row>
                <b-col cols="12">
                    <validation-provider name="No. de Firmas"
                        :rules="{ required: true, numeric, min_value: 1, max_value: 2 }" v-slot="validationContext">
                        <b-form-group id="lblnoFirmas" label="No. de Firmas" label-for="txtnoFirmas">
                            <b-form-input id="txtnoFirmas" type="number" v-model="registro.noFirmas"
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
                    <validation-provider name="Material" :rules="{ required: true }" v-slot="validationContext">
                        <b-form-group id="lblMaterial" label="Material">
                            <b-select v-model="registro.idMaterial" :options="options"
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
                    <b-form-checkbox id="lblestatus" v-model="registro.estatusOrgano" name="cbxstatus">
                        Registro es Activo
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
            registro: {},
            options: {},
            optionsnivel: {}
        };
    },
    mounted() {
        this.getMateriales();
        this.getNivel();
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
            HTTP.post('api/CatalogoOrganoDirigencial/RegistrobyId', parametros).then(responseApi => {

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
            HTTP.post('api/CatalogoOrganoDirigencial/Update', parametros).then(responseApi => {
                if (responseApi.status == 200) {
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
        getMateriales() {
            HTTP
                .get('api/CatalogoOrganoDirigencial/ConsultarMateriales')
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
        getNivel() {
            HTTP
                .get('api/CatalogoOrganoDirigencial/ConsultarNivelGestion')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {
                        this.optionsnivel = response.data;
                    }
                })
                .catch(function (error) {
                    this.MensajeError(error);
                });


        },
    },
};
</script>
