<template>
    <div>
        <validation-observer ref="observer" v-slot="{ handleSubmit }">
            <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(BuscarUsuario)">
                <b-row>
                    <b-col cols="2">
                        <h5>Filtro:</h5>
                    </b-col>
                    <b-col cols="4">
                        <validation-provider name="Filtro" :rules="{ required: true }" v-slot="validationContext">
                            <b-form-select v-model="selectedFilter" :options="optionsfitro"
                                :state="getValidationState(validationContext)" aria-describedby="input-1-live-feedback"
                                size="sm" v-on:change="onChangeFilter">
                            </b-form-select>
                            <b-form-invalid-feedback id="input-1-live-feedback">
                                {{ validationContext.errors[0] }}
                            </b-form-invalid-feedback>
                        </validation-provider>
                    </b-col>
                    <b-col cols="2">
                        <div class="text-center" id="divSpinner" v-if="spinnerOnOff">
                            <b-spinner variant="success" label="Spinning"></b-spinner>
                        </div>
                    </b-col>
                    <b-col cols="2">
                        <b-button type="submit" variant="success" size="sm">
                            <i class="fa-solid fa-magnifying-glass"> </i>
                            Buscar
                        </b-button>
                    </b-col>
                </b-row>
                <hr>
                <b-row>
                    <b-col cols="4">
                        <!-- <validation-provider name="Nombres / CIF / Cuenta Mexicana" :rules="{ required: true }"
                                             v-slot="validationContext">
                            <b-form-input id="txtsearch" type="text" v-model="inputbusqueda"
                                          :state="getValidationState(validationContext)" aria-describedby="input-1-live-feedback" trim
                                          placeholder="Nombres / CIF / Cuenta Mexicana" size="sm"></b-form-input>
                            <b-form-invalid-feedback id="input-1-live-feedback">
                                {{  validationContext.errors[0]  }}
                            </b-form-invalid-feedback>
                        </validation-provider> -->
                        <b-form-input id="txtsearch" type="text" v-model="inputbusqueda" trim
                            placeholder="Nombres / CIF / Cuenta Mexicana" size="sm"></b-form-input>

                    </b-col>
                    <b-col cols="4" v-if="selectNombre">
                        <!-- <validation-provider name="Apellido Paterno" :rules="{ required: true }" v-slot="validationContext">
                            <b-form-input id="txtApeliidoPaterno" type="text" v-model="apellidoPaterno"
                                :state="getValidationState(validationContext)" aria-describedby="input-2-live-feedback" trim
                                placeholder="Apellido Paterno" size="sm"></b-form-input>
                            <b-form-invalid-feedback id="input-2-live-feedback">
                                {{ validationContext.errors[0] }}
                            </b-form-invalid-feedback>
                        </validation-provider> -->
                        <b-form-input id="txtApeliidoPaterno" type="text" v-model="apellidoPaterno" trim
                            placeholder="Apellido Paterno" size="sm"></b-form-input>
                    </b-col>
                    <b-col cols="4" v-if="selectNombre">
                        <!-- <validation-provider name="Apellido Materno" :rules="{ required: true }" v-slot="validationContext">
                            <b-form-input id="txtApellidoMaterno" type="text" v-model="apellidoMaterno"
                                :state="getValidationState(validationContext)" aria-describedby="input-3-live-feedback" trim
                                placeholder="Apellido Materno" size="sm"></b-form-input>
                            <b-form-invalid-feedback id="input-1-live-feedback">
                                {{ validationContext.errors[0] }}
                            </b-form-invalid-feedback>
                        </validation-provider> -->
                        <b-form-input id="txtApellidoMaterno" type="text" v-model="apellidoMaterno" trim
                            placeholder="Apellido Materno" size="sm"></b-form-input>
                    </b-col>
                </b-row>
                <hr>
                <b-row>
                    <b-col cols="8" v-if="usuariosMultiples">
                        <span class="label label-default">{{ totalRegistros }} registros encontrados</span>
                        <b-form-group id="id_perfil" label="Personas encontradas por Nombre">
                            <b-form-select v-model="selectedUsuarioDirigente" v-on:change="onChangeUsuariosDirigentes">
                                <option v-for="(item, index) in optUsuariosDirigentes" :key="index" :value="index">
                                    Nombre: {{ item.nombrePersona }} {{ item.apellidoPaterno }} {{ item.apellidoMaterno }}
                                    Plaza: {{ item.plaza }}
                                </option>
                            </b-form-select>
                        </b-form-group>
                    </b-col>
                </b-row>
            </b-form>
        </validation-observer>
        <hr />

        <div v-if="resultadoBusqueda">
            <validation-observer ref="observer2" v-slot="{ handleSubmit }">
                <div id="infoPersona">
                    <b-row>
                        <b-col class="col-8">
                            <h3>Informaci&oacute;n</h3>
                        </b-col>
                    </b-row>

                    <div>
                        <b-row class="justify-content-md-center sm-3">
                            <b-col col-3>
                                <b-form-group id="lblPaterno" label="Ap. Paterno" label-for="txtPaterno">

                                    <b-form-input id="txtPaterno" type="text" disabled=true
                                        v-model="registro.apellidoPaterno"></b-form-input>
                                </b-form-group>
                            </b-col>

                            <b-col col-3>
                                <b-form-group id="lblMaterno" label="Ap. Materno" label-for="txtMaterno">
                                    <b-form-input id="txtMaterno" type="text" disabled=true
                                        v-model="registro.apellidoMaterno"></b-form-input>
                                </b-form-group>
                            </b-col>
                            <b-col col-3>
                                <b-form-group id="lblNombre" label="Nombre" label-for="txtNombnre">
                                    <b-form-input id="txtNombre" type="text" disabled=true v-model="registro.nombrePersona"
                                        disable></b-form-input>
                                </b-form-group>
                            </b-col>
                            <b-col col-3>
                                <b-form-group id="lblFechaIngresoSocio" label="F. Ingreso Socio">
                                    <b-form-datepicker locale="es-MX" v-model="registro.fechaIngreso" disabled=true
                                        :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"></b-form-datepicker>
                                </b-form-group>
                            </b-col>



                        </b-row>
                    </div>
                </div>

                <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(addNew)">
                    <div>
                        <b-button variant="outline-success" id="show-btn" @click="addCargo">
                            <i class="fa-solid fa-plus"> Agregar</i>
                        </b-button>
                        <br>
                        <div class="previous" v-for="(organo, counter) in organos" v-bind:key="counter">
                            <b-row>
                                <b-col cols="3">
                                    <ValidationProvider name="Nivel" :rules="{ required: true, excluded: 0 }"
                                        v-slot="valTJ">
                                        <b-form-group id="lblNivel" label="Nivel">
                                            <b-form-select v-model="organo.idNivelGestion" :options="optionsNivel"
                                                :state="getValidationState(valTJ)" aria-describedby="input-10-live-feedback"
                                                v-on:change="onChangeNivel">
                                            </b-form-select>
                                            <b-form-invalid-feedback id="input-10-live-feedback">
                                                {{ valTJ.errors[0] }}
                                            </b-form-invalid-feedback>
                                        </b-form-group>
                                    </ValidationProvider>
                                </b-col>

                                <b-col cols="3" v-if="selectNivel">
                                    <ValidationProvider name="Organo" :rules="{ required: true, excluded: 0 }"
                                        v-slot="valOrgano">
                                        <b-form-group id="lblOrgano">
                                            <label>&Oacute;rgano</label>
                                            <b-select v-model="organo.idOrgano" :options="optionsOrgano"
                                                :state="getValidationState(valOrgano)"
                                                aria-describedby="input-11-live-feedback">
                                            </b-select>
                                            <b-form-invalid-feedback id="input-11-live-feedback">
                                                {{ valOrgano.errors[0] }}
                                            </b-form-invalid-feedback>
                                        </b-form-group>
                                    </ValidationProvider>

                                </b-col>
                                <b-col cols="3" v-if="organo.idNivelGestion == '2'">
                                    <ValidationProvider name="Plaza" :rules="{ required: true, excluded: 0 }"
                                        v-slot="valPlaza">
                                        <b-form-group id="lblPlaza" label="Plaza">
                                            <b-select v-model="organo.idPlaza" :options="optionsPlaza"
                                                :state="getValidationState(valPlaza)"
                                                aria-describedby="input-12-live-feedback">

                                            </b-select>
                                            <b-form-invalid-feedback id="input-12-live-feedback">
                                                {{ valPlaza.errors[0] }}
                                            </b-form-invalid-feedback>
                                        </b-form-group>
                                    </ValidationProvider>
                                </b-col>
                                <b-col cols="3">
                                    <ValidationProvider name="Cargo" :rules="{ required: true, excluded: 0 }"
                                        v-slot="valCargo">
                                        <b-form-group id="lblPerfil" label="Cargo">
                                            <b-select v-model="organo.idPerfilCargo" :options="optionsCargo"
                                                :state="getValidationState(valCargo)"
                                                aria-describedby="input-13-live-feedback">
                                            </b-select>
                                            <b-form-invalid-feedback id="input-13-live-feedback">
                                                {{ valCargo.errors[0] }}
                                            </b-form-invalid-feedback>
                                        </b-form-group>
                                    </ValidationProvider>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col cols="4">
                                    <ValidationProvider name="Suplente" :rules="{ required: true }" v-slot="valSuplente">
                                        <b-form-group id="lblSuplente" label="Suplente">
                                            <b-select v-model="organo.suplente" :options="optionsSN"
                                                :state="getValidationState(valSuplente)"
                                                aria-describedby="input-14-live-feedback">
                                            </b-select>
                                            <b-form-invalid-feedback id="input-14-live-feedback">
                                                {{ valSuplente.errors[0] }}
                                            </b-form-invalid-feedback>
                                        </b-form-group>
                                    </ValidationProvider>
                                </b-col>
                                <b-col cols="4">
                                    <ValidationProvider name="Firmante" :rules="{ required: true }" v-slot="valFirmante">
                                        <b-form-group id="lblfirmante" label="Firmante">
                                            <b-select v-model="organo.firmante" :options="optionsSN"
                                                :state="getValidationState(valFirmante)"
                                                aria-describedby="input-15-live-feedback">
                                            </b-select>
                                            <b-form-invalid-feedback id="input-15-live-feedback">
                                                {{ valFirmante.errors[0] }}
                                            </b-form-invalid-feedback>
                                        </b-form-group>
                                    </ValidationProvider>

                                </b-col>
                                <b-col cols="4">
                                    <ValidationProvider name="Necesario" :rules="{ required: true }" v-slot="valNecesario">
                                        <b-form-group id="lblnecesarop" label="Necesario">
                                            <b-select v-model="organo.necesario" :options="optionsSN"
                                                :state="getValidationState(valNecesario)"
                                                aria-describedby="input-16-live-feedback">
                                            </b-select>
                                            <b-form-invalid-feedback id="input-16-live-feedback">
                                                {{ valNecesario.errors[0] }}
                                            </b-form-invalid-feedback>
                                        </b-form-group>
                                    </ValidationProvider>
                                </b-col>
                            </b-row>

                            <b-row>
                                <b-col cols="1"></b-col>
                                <b-col cols="2">
                                    <b-form-group id="lblFechaNombramiento" label="F. Nombramiento">
                                        <b-form-datepicker v-model="organo.fechaNombramiento" locale="es-MX"
                                            placeholder="Selecciona una fecha"
                                            :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"></b-form-datepicker>
                                    </b-form-group>
                                </b-col>
                                <b-col cols="2">
                                    <b-form-group id="lblActaDesignacion" label="F. Acta Designacion">

                                        <b-form-datepicker v-model="organo.fechaActaDesignacion" locale="es-MX"
                                            placeholder="Selecciona una fecha"
                                            :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"></b-form-datepicker>
                                    </b-form-group>
                                </b-col>

                                <b-col cols="2">
                                    <b-form-group id="lblFechaInicial" label="F. Inicial">
                                        <b-form-datepicker v-model="organo.fechaInicial" locale="es-MX"
                                            placeholder="Selecciona una fecha"
                                            :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"></b-form-datepicker>
                                    </b-form-group>
                                </b-col>


                                <b-col cols="2">
                                    <b-form-group id="lblFechaFinal" label="F. Final">
                                        <b-form-datepicker v-model="organo.fechaFinal" locale="es-MX"
                                            placeholder="Selecciona una fecha"
                                            :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"></b-form-datepicker>
                                    </b-form-group>
                                </b-col>



                                <b-col cols="1"></b-col>

                            </b-row>

                            <b-button variant="outline-danger" id="show-btn" @click="deleteCargo(counter)">
                                <i class="fa-solid fa-minus"></i>
                            </b-button>
                            <div class=" col-12 justify-content-center p-2"
                                style="width:100%; height: 20px;background-color: #C8FE2E;"></div>
                        </div>
                    </div>

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

        </div>

    </div>
</template>

<script>
import { HTTP } from '@/plugins/axios'

export default {
    name: "CreateModal",
    data() {
        return {
            registro: {},
            optionsfitro: [
                { value: 1, text: 'CIF' },
                { value: 2, text: 'Nombre' },
                { value: 3, text: 'Cuenta Mexicana' },
            ],
            optionsSN: [
                { value: 'SI', text: 'SI' },
                { value: 'NO', text: 'NO' },
            ],
            selectedFilter: null,
            inputbusqueda: null,
            resultadoBusqueda: false,
            optionsNivel: {},
            optionsOrgano: {},
            optionsPlaza: {},
            optionsCargo: {},
            organos: [
                {
                    idPersona: 0,
                    idNivelGestion: 0,
                    idPlaza: 0,
                    idOrgano: 0,
                    idPerfilCargo: 0,
                    suplente: '',
                    firmante: '',
                    necesario: '',
                    fechaNombramiento: '',
                    fechaActaDesignacion: '',
                    fechaInicial: '',
                    fechaFinal: '',
                    fechaIngresoSocio: '',
                }
            ],
            spinnerOnOff: false,
            apellidoPaterno: null,
            apellidoMaterno: null,
            selectedUsuarioDirigente: null,
            optUsuariosDirigentes: {},
            usuariosMultiples: false,
            selectNombre: false,
            totalRegistros: 0,
            selectNivel: false
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
            var lstOrganos = this.organos;
            lstOrganos.forEach(element => {
                if (element.idPersona == 0)
                    element.idPersona = this.registro.idPersona
                if (element.fechaIngresoSocio == "")
                    element.fechaIngresoSocio = this.registro.fechaIngreso
            });

            const parametros = JSON.stringify(lstOrganos);
            HTTP.post('api/CatalogoCargoXOrgano/Crear', parametros).then(responseApi => {

                if (responseApi.data.resultado == true) {
                    this.$emit("closeCreateModal");
                    this.$emit("reloadDataTable");
                    this.$emit("showSuccessAlert");
                }
                else {

                    this.MensajeError(responseApi.data.mensaje)
                }

            }).catch(error => {

                this.$emit("closeCreateModal");
                console.log(error);
                this.MensajeError(this.$messageConstants('errorGenerico'));
            });
        },
        BuscarUsuario() {
            if (this.selectedFilter == null)
                return this.MensajeInfo(this.$messageConstants('errorbusqueda1'));

            if (this.inputbusqueda == null)
                return this.MensajeInfo(this.$messageConstants('errorbusqueda2'))

            if (this.inputbusqueda.trim() == '')
                return this.MensajeInfo(this.$messageConstants('errorbusqueda3'))

            this.spinnerOnOff = true;
            this.getUsuario()

        },
        getUsuario() {

            const parametros = JSON.stringify(
                {
                    tipoBusqueda: this.selectedFilter,
                    personaBusqueda: this.inputbusqueda,
                    apellidoPaterno: this.apellidoPaterno,
                    apellidoMaterno: this.apellidoMaterno
                });
            HTTP.post('api/CatalogoCargoXOrgano/GetUsuario', parametros).then(responseApi => {
                this.spinnerOnOff = false;

                if (responseApi.data.length == 0)
                    return this.MensajeInfo(this.$messageConstants('usuarioNoEncontrado'));


                if (responseApi.data.length > 1) {
                    this.totalRegistros = responseApi.data.length;
                    this.optUsuariosDirigentes = responseApi.data;
                    this.usuariosMultiples = true;
                }
                else {
                    this.registro = responseApi.data[0];
                    this.resultadoBusqueda = true;
                    this.getAll();
                }

            }).catch(error => {

                this.$emit("closeCreateModal");
                console.log(error);
                this.MensajeError(this.$messageConstants('errorGenerico'));
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

                    console.log(error);
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

                    console.log(error);
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

                    console.log(error);
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });
        },
        addCargo() {
            this.organos.push({
                idPersona: this.registro.idPersona,
                idNivelGestion: 0,
                idPlaza: 0,
                idOrgano: 0,
                idPerfilCargo: 0,
                suplente: '',
                firmante: '',
                necesario: '',
                fechaNombramiento: '',
                fechaActaDesignacion: '',
                fechaInicial: '',
                fechaFinal: '',
                fechaIngresoSocio: this.registro.fechaIngreso,
            })
        },
        deleteCargo(counter) {
            this.organos.splice(counter, 1);
        },
        getAll() {
            this.getNivel();
            this.getCargo();
            //this.getOrgano();
            this.getPlaza();

        },
        onChangeUsuariosDirigentes() {
            this.registro = this.optUsuariosDirigentes[this.selectedUsuarioDirigente];
            this.resultadoBusqueda = true;
            this.getAll();
        },
        onChangeFilter() {
            this.resultadoBusqueda = false;
            if (this.selectedFilter == 2)
                this.selectNombre = true
            else
                this.selectNombre = false;
        },
        onChangeNivel(id) {
            this.selectNivel = true;
            this.getOrgano(id);
        }
    },
};
</script>





