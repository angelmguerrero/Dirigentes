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
                <b-col cols="4">

                </b-col>

                <!--<b-col cols="4">
                <b-form-group id="lblAgregarNivel"
                              label="Agregar Nivel"
                              label-for="btnAgregarNivel">

                    <b-button id="btnAgregarNivel" variant="success" @click="addNivel">
                        <i class="fa-solid fa-plus"></i> Nivel
                    </b-button>
                </b-form-group>
            </b-col>-->
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
                            <NivelOrden @niveles="getNiveles"></NivelOrden>
                        </b-card>
                    </b-card-group>
                </b-col>
            </b-row>

            <b-row class="mt-4">
                <b-col cols="3">
                    <!--<b-button variant="success" @click="addNew">Guardar</b-button>-->
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

    //import NivelOrden from "@/components/Administracion/compConvocatorias/OrdenesDia/NivelOrden.vue";
    import NivelOrden from "@/components/Administracion/compConvocatorias/OrdenesDia/NivelOrdenPruebaCreate.vue";
    import { HTTP } from '@/plugins/axios'

    export default {
        name: "CreateModal",
        data() {
            return {
                registro: {},
                ordenDia: {},
                tiposJunta: {},
                options: {},
                selected: null,
                count: 1,
                niveles: [],
                ordenDiaDetalles: {}
            };


        },
        components: {
            NivelOrden
        },
        mounted() {
            this.getTiposJunta();

        },
        methods: {
            triggerClose() {
                this.$emit("closeCreateModal");
            },
            getValidationState({ dirty, validated, valid = null }) {
                return dirty || validated ? valid : null;
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
                            this.addNew();
                        }
                        else {
                            this.MensajeError(responseApi.data.mensaje);
                        }
                    })
                    .catch(error => {
                        this.MensajeError(error);
                    });
            },
            addNew() {
                this.ordenDiaDetalles.encabezado = this.ordenDia;
                this.ordenDiaDetalles.detalles = this.niveles;
                const param = JSON.stringify(this.ordenDiaDetalles);
                HTTP.post('api/CatalogoPlantillaOrdenDia/Crear', param)
                    .then(responseApi => {
                        if (responseApi.data.resultado == true) {

                                this.$emit("closeCreateModal");
                                this.$emit("reloadDataTable");
                                this.$emit("showSuccessAlert");
                        }
                        else {
                            this.MensajeError(responseApi.data.mensaje);
                        }
                    })
                    .catch(error => {
                        this.MensajeError(error);
                    });           
            },
            getTiposJunta() {
                HTTP.get('api/CatalogoOrdenesDia/ConsultarTiposJunta')
                    .then(response => {
                        if (response.status == 401)
                            throw new Error('No tiene acceso al recurso');

                        if (response.status == 200) {
                            this.options = response.data;
                        }
                    })
                    .catch(function (error) {
                        this.MensajeError(error);
                    });
            },
            onChange: function () {               
                this.ordenDia.descripcion = "Plantilla para junta " + document.getElementById("tipoJunta").options[document.getElementById('tipoJunta').selectedIndex].text;
            },
        },
    };
</script>

