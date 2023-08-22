<template>
    <b-form class="mt-auto">

        <b-row>
            <b-col cols="3">
                <b-form-group id="lblNivel" label="Nivel">
                    <b-select v-model="registro.idNivelGestion" :options="optionsNivel" v-on:change="onChangeNivel">

                    </b-select>
                </b-form-group>
            </b-col>

            <b-col cols="3">
                <b-form-group id="lblOrgano">
                    <label>&Oacute;rgano</label>
                    <b-select v-model="registro.idOrgano" :options="optionsOrgano">
                    </b-select>
                </b-form-group>
            </b-col>

            <b-col cols="3" v-if="registro.idNivelGestion == '2'">
                <b-form-group id="lblPlaza" label="Plaza">
                    <b-select v-model="registro.idPlaza" :options="optionsPlaza">

                    </b-select>
                </b-form-group>
            </b-col>


            <b-col cols="3">
                <b-form-group id="lblPerfil" label="Cargo">
                    <b-select v-model="registro.idPerfilCargo" :options="optionsCargo">

                    </b-select>
                </b-form-group>
            </b-col>

        </b-row>

        <b-row>
            <b-col cols="4">
                <b-form-group id="lblSuplente" label="Suplente">
                    <b-select v-model="registro.suplente" :options="optionsSN" required>

                    </b-select>
                </b-form-group>
            </b-col>
            <b-col cols="4">
                <b-form-group id="lblfirmante" label="Firmante">
                    <b-select v-model="registro.firmante" :options="optionsSN">

                    </b-select>
                </b-form-group>
            </b-col>
            <b-col cols="4">
                <b-form-group id="lblnecesarop" label="Necesario">
                    <b-select v-model="registro.necesario" :options="optionsSN">

                    </b-select>
                </b-form-group>
            </b-col>
        </b-row>

        <b-row>
            <b-col cols="1"></b-col>
            <b-col cols="2">
                <b-form-group id="lblFechaNombramiento" label="F. Nombramiento">
                    <b-form-datepicker v-model="registro.fechaNombramiento" locale="es-MX"
                        placeholder="Selecciona una fecha"
                        :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"></b-form-datepicker>
                </b-form-group>
            </b-col>
            <b-col cols="2">
                <b-form-group id="lblActaDesignacion" label="F. Acta Designacion">

                    <b-form-datepicker v-model="registro.fechaActaDesignacion" locale="es-MX"
                        placeholder="Selecciona una fecha"
                        :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"></b-form-datepicker>
                </b-form-group>
            </b-col>

            <b-col cols="2">
                <b-form-group id="lblFechaInicial" label="F. Inicial">
                    <b-form-datepicker v-model="registro.fechaInicial" locale="es-MX" placeholder="Selecciona una fecha"
                        :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"></b-form-datepicker>
                </b-form-group>
            </b-col>


            <b-col cols="2">
                <b-form-group id="lblFechaFinal" label="F. Final">
                    <b-form-datepicker v-model="registro.fechaFinal" locale="es-MX" placeholder="Selecciona una fecha"
                        :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"></b-form-datepicker>
                </b-form-group>
            </b-col>

            <b-col cols="2">
                <b-form-group id="lblFechaIngresoSocio" label="F. Ingreso Socio">

                    <b-form-datepicker v-model="registro.fechaIngresoSocio" locale="es-MX"
                        placeholder="Selecciona una fecha"
                        :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"></b-form-datepicker>
                </b-form-group>
            </b-col>

            <b-col cols="1"></b-col>

        </b-row>


        <b-row>
            <b-col cols="12">
                <b-form-checkbox id="lblestatus" v-model="registro.estatusCargoOrgano" name="cbxstatus">
                    Registro es Activo
                </b-form-checkbox>
            </b-col>
        </b-row>
        <b-row class="mt-4">
            <b-col cols="3">
                <b-button variant="success" @click="update">Guardar</b-button>
            </b-col>
            <b-col>
                <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
            </b-col>
        </b-row>
    </b-form>
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
            optionsfitro: [
                { value: 1, text: 'CIF' },
                { value: 2, text: 'Nombre' },
                { value: 3, text: 'Numero de socio' },
            ],
            optionsSN: [
                { value: 'SI', text: 'SI' },
                { value: 'NO', text: 'NO' },
            ],
            optionsNivel: {},
            optionsOrgano: {},
            optionsPlaza: {},
            optionsCargo: {},

        };
    },
    mounted() {
        this.getNivel();
        //this.getOrgano();
        this.getPlaza();
        this.getCargo();
        this.getByID();
    },
    methods: {
        triggerClose() {
            this.$emit("closeEditModal");
        },
        getByID() {
            const parametros = JSON.stringify(this.id);
            HTTP.post('api/CatalogoCargoXOrgano/RegistrobyId', parametros).then(responseApi => {
                if (responseApi.status == 401)
                    throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                if (responseApi.status == 200) {
                    this.registro = responseApi.data;
                    this.getOrgano(responseApi.data.idNivelGestion);
                }

            }).catch(error => {
                console.log(error);
                this.MensajeError(this.$messageConstants('errorGenerico'));
            });


        },
        update() {
            const parametros = JSON.stringify(this.registro);
            HTTP.post('api/CatalogoCargoXOrgano/Update', parametros).then(responseApi => {
                if (responseApi.data.resultado == true) {
                    this.$emit("closeEditModal");
                    this.$emit("reloadDataTable");
                    this.$emit("showSuccessAlert");
                }
                else {
                    this.MensajeError(responseApi.data.mensaje)
                }

            }).catch(error => {
                this.$emit("closeEditModal");

                this.MensajeError(error);
            });
        },
        getOrgano(id) {
            const parametros = JSON.stringify(id);

            HTTP
                .post('api/CatalogoCargoXOrgano/GetOrgano', parametros)
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {

                        this.optionsOrgano = response.data;
                    }
                })
                .catch(function (error) {
                    console.log(error)
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });
        },
        getCargo() {
            HTTP
                .get('api/CatalogoCargoXOrgano/GetCargo')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {

                        this.optionsCargo = response.data;
                    }
                })
                .catch(function (error) {
                    console.log(error);
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });
        },
        getPlaza() {
            HTTP
                .get('api/CatalogoCargoXOrgano/GetPlaza')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {

                        this.optionsPlaza = response.data;
                    }
                })
                .catch(function (error) {
                    console.log(error)
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });
        },
        getNivel() {
            HTTP
                .get('api/CatalogoCargoXOrgano/GetNivel')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200) {
                        this.optionsNivel = response.data;
                    }
                })
                .catch(function (error) {
                    console.log(error)
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });
        },
        onChangeNivel(id) {
            this.selectNivel = true;
            this.getOrgano(id);
        }
    },
};
</script>
