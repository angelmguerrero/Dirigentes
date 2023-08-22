<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(validarVacios)">

            <b-row>
                <b-col cols="4">
                    <validation-provider name="Tipo de Junta"
                                         :rules="{ required: true}"
                                         v-slot="validationContext">
                        <b-form-group id="lblTipoJunta"
                                      label="Seleccione el tipo de junta"
                                      label-for="tipoJunta">

                            <b-select id="tipoJunta" v-model="ordenDia.idTipoJunta"
                                      :options="options"
                                      @change="onChange()"
                                      :state="getValidationState(validationContext)"
                                      aria-describedby="input-1-live-feedback">

                            </b-select>

                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </b-form-group>
                    </validation-provider>
                </b-col>  
                <b-col cols="4" style="padding-top: 40px;">
                    <validation-provider name="Estatus"
                                         :rules="{ required: true}"
                                         v-slot="validationContext">
                    <b-form-checkbox id="lblestatus" v-model="ordenDia.estatusPlantillaOrdenDia" name="cbxstatus">
                        Activo
                    </b-form-checkbox>

                    <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                    </validation-provider>
                </b-col>             
            </b-row>
            <b-row>
                <b-col cols="12">
                     <h3>{{ ordenDia.descripcion }}</h3>                           
                </b-col>
            </b-row>
            <b-row>
                <b-col cols="12">
                    <b-card-group>
                        <b-card footer-tag="footer">
                            <NivelOrden :idDetalle="id" @eliminados="getEliminados" @niveles="getNiveles"></NivelOrden>
                        </b-card>
                    </b-card-group>
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
    import NivelOrden from "@/components/Administracion/compConvocatorias/OrdenesDia/NivelOrdenPrueba.vue";
    import { HTTP } from '@/plugins/axios'


    export default {
        name: "CreateModal",
        props: {
            id: Number,
        },
        data() {
            return {
                registro: {},
                ordenDia: {},
                tiposJunta: {},
                options: {},
                selected: null,
                count: 1,
                nivelesEliminados: [],
                niveles: [],
                ordenDiaDetalles: {}
            };


        },
        components: {
            NivelOrden
        },
        mounted() {
            this.getTiposJunta();
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
                HTTP.post('api/CatalogoPlantillaOrdenDia/ConsultarEncabezado', parametros).then(responseApi => {

                    if (responseApi.status == 401)
                        throw new Error('No tiene acceso al recurso');

                    if (responseApi.status == 200)
                        this.ordenDia = responseApi.data;


                }).catch(error => {
                    this.MensajeError(error)
                });
            },
            getTiposJunta() {
                HTTP.get('api/CatalogoPlantillaOrdenDia/ConsultarTiposJunta')
                    .then(responseApi => {

                        if (responseApi.status == 401)
                            throw new Error('No tiene acceso al recurso');

                        if (responseApi.status == 200)
                            this.options = responseApi.data;


                    }).catch(error => {
                        this.MensajeError(error)
                    });
            },
            getEliminados(value) {
                this.nivelesEliminados = value;
            },
            getNiveles(value) {
                this.niveles = value;
            },
            validarVacios() {
                var lstNiveles = this.niveles;
                const parametros = JSON.stringify(lstNiveles);
                HTTP.post('api/CatalogoPlantillaOrdenDia/ValidarVacios', parametros)
                    .then(responseApi => {
                        if (responseApi.data.resultado == true) {
                            this.update();
                        }
                        else {
                            this.MensajeError(responseApi.data.mensaje);
                        }
                    })
                    .catch(error => {
                        this.MensajeError(error);
                    });
            },
            update() {
                this.ordenDiaDetalles.encabezado = this.ordenDia;
                this.ordenDiaDetalles.detallesEliminados = this.nivelesEliminados;
                this.ordenDiaDetalles.detalles = this.niveles;
                const parametros = JSON.stringify(this.ordenDiaDetalles);
                HTTP.post('api/CatalogoPlantillaOrdenDia/Update', parametros).then(responseApi => {
                    if (responseApi.data.resultado == true) {
                        this.$emit("closeEditModal");
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
            onChange: function () {
                this.ordenDia.descripcion = "Plantilla para junta " + document.getElementById("tipoJunta").options[document.getElementById('tipoJunta').selectedIndex].text;
            },
        },
    };
</script>

