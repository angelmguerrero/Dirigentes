<template>
    <div id="divConvocatoria">
        <loading-overlay :active='isLoading' color='#008000' />
        <b-form class="mt-auto">
            <b-row>
                <b-col cols="12">
                    <ValidationProvider name="Comités y/o Comisiones" v-slot="v" :rules="{ required: true, is_not: 0 }">
                        <b-form-group id="lblComite" class="float-right">
                            <label>Comités y/o Comisiones</label>
                            <b-form-select v-model="convoca.idOrgano" :options="optionsComite" size="sm"
                                v-on:change="onChangecomite" required>
                            </b-form-select>
                            <span>{{ v.errors[0] }}</span>
                        </b-form-group>
                    </ValidationProvider>
                </b-col>
            </b-row>
        </b-form>
        <div v-if="selectComite">
            <hr>
            <validation-observer ref="observer" v-slot="{ handleSubmit }">
                <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(addNew)">
                    <b-row>
                        <b-col>
                            <ValidationProvider name="Asunto" :rules="{ required: true }" v-slot="valAsunto">
                                <b-form-group label="Asunto">
                                    <b-form-input v-model="convoca.convocatoria" trim :state="getValidationState(valAsunto)"
                                        aria-describedby="input-4-live-feedback" size="sm"></b-form-input>
                                    <b-form-invalid-feedback id="input-4-live-feedback">
                                        {{ valAsunto.errors[0] }}
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </ValidationProvider>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col>
                            <ValidationProvider name="Tipo de Junta" :rules="{ required: true, excluded: 0 }"
                                v-slot="valTJ">
                                <b-form-group id="lblTipoJunta">
                                    <label>Tipo de Junta</label>
                                    <b-form-select v-model="convoca.idTipoJunta" :options="optionsTipoJunta"
                                        :state="getValidationState(valTJ)" aria-describedby="input-1-live-feedback"
                                        size="sm" @change="getDetallePlantilla">
                                    </b-form-select>
                                    <b-form-invalid-feedback id="input-1-live-feedback">
                                        {{ valTJ.errors[0] }}
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </ValidationProvider>
                        </b-col>
                        <b-col>
                            <ValidationProvider name="Modalidad" :rules="{ required: true, excluded: 0 }"
                                v-slot="valModalidad">
                                <b-form-group id="lblModalidad">
                                    <label>Modalidad</label>
                                    <b-form-select v-model="convoca.idModalidad" :options="optionsModalidad"
                                        :state="getValidationState(valModalidad)" aria-describedby="input-2-live-feedback"
                                        size="sm" @change="onChangeModalidad">
                                    </b-form-select>
                                    <b-form-invalid-feedback id="input-2-live-feedback">
                                        {{ valModalidad.errors[0] }}
                                    </b-form-invalid-feedback>
                                </b-form-group>
                            </ValidationProvider>
                        </b-col>
                    </b-row>
                    <b-row v-if="selectModalidad">
                        <b-col>
                            <b-form-group label="Ubicación">
                                <b-form-input v-model="convoca.ubicacion" trim size="sm"></b-form-input>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <hr>
                    <b-row>
                        <b-col>Fecha Junta</b-col>
                        <b-col>Hora Inicio</b-col>
                        <b-col>Hora Fin</b-col>
                        <b-col>Acciones</b-col>
                        <div v-for="(line, index) in meetings" :key="index" class="row w-100">
                            <b-col>
                                <ValidationProvider name="Fecha" :rules="{ required: true, max: 250 }"
                                    v-slot="valFechaInicio">
                                    <b-form-datepicker v-model="line.fechaInicio" locale="es-MX" class="mb-2"
                                        placeholder="Selecciona una fecha"
                                        :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"
                                        :state="getValidationState(valFechaInicio)" aria-describedby="input-3-live-feedback"
                                        trim :min="minDate"></b-form-datepicker>
                                    <b-form-invalid-feedback id="input-3-live-feedback">{{
                                        valFechaInicio.errors[0] }}</b-form-invalid-feedback>
                                </ValidationProvider>
                            </b-col>
                            <b-col>
                                <b-form-timepicker v-model="line.horaInicio" locale="es-MX" now-button reset-button
                                    label-now-button="Ahora" label-reset-button="Reiniciar" label-close-button="Cerrar"
                                    label-no-time-selected="Hora no seleccionada"
                                    placeholder="Selecciona hora inicio"></b-form-timepicker>
                            </b-col>
                            <b-col>
                                <b-form-timepicker v-model="line.horaFin" locale="es-MX" now-button reset-button
                                    label-now-button="Ahora" label-reset-button="Reiniciar" label-close-button="Cerrar"
                                    label-no-time-selected="Hora no seleccionada"
                                    placeholder="Selecciona hora fin"></b-form-timepicker>
                            </b-col>
                            <b-col>
                                <b-button variant="outline-danger" @click="removeLine(index)" size="sm">
                                    <i class="fa-solid fa-minus"></i>
                                </b-button>
                                <b-button variant="outline-success" v-if="index + 1 === meetings.length" @click="addLine"
                                    size="sm">
                                    <i class="fa-solid fa-plus"> </i>
                                </b-button>
                            </b-col>
                        </div>
                    </b-row>
                    <hr>
                    <b-row>
                        <b-col>
                            <b-form-group label="Asistentes Necesarios">
                                <vue-tags-input v-model="correoNecesario" :tags="correosNecesarios"
                                    :autocomplete-items="filteredItems" placeholder="Agregar"
                                    :add-only-from-autocomplete="true"
                                    @tags-changed="newTags => correosNecesarios = newTags" />
                            </b-form-group>
                        </b-col>
                        <b-col cols="2" align-self="center">
                            <b-button variant="warning" size="sm" @click="validarAsistentes" class="float-center">{{
                                btnNecesarios }}</b-button>
                        </b-col>
                    </b-row>
                    <b-row>
                        <b-col>
                            <b-form-group label="Asistentes De Conocimiento" class="mb-0">
                                <vue-tags-input v-model="correoConocimiento" :tags="correosConocimiento"
                                    :autocomplete-items="filterConocimiento" placeholder="Agregar"
                                    :add-only-from-autocomplete="true"
                                    @tags-changed="newTags => correosConocimiento = newTags">
                                </vue-tags-input>
                            </b-form-group>
                        </b-col>
                        <!-- <b-col v-if="false">
                            <b-form-group label="Asistentes Ocultos" class="mb-0">
                                <vue-tags-input v-model="correoOculto" :tags="correosOcultos"
                                    :autocomplete-items="filterOcultos" placeholder="Agregar"
                                    :add-only-from-autocomplete="true" @tags-changed="newTags => correosOcultos = newTags">
                                </vue-tags-input>
                            </b-form-group>
                        </b-col> -->
                    </b-row>
                    <hr>
                    <b-row>
                        <b-col>
                            <b-form-group label="Solicitar Material" class="mb-0">
                                <b-form-input v-model="convoca.correoMaterial">
                                </b-form-input>
                            </b-form-group>
                        </b-col>
                        <b-col>
                            <b-form-group label="Fecha">
                                <b-row>
                                    <b-col>
                                        <b-form-datepicker v-model="convoca.fechaInicioMaterial" locale="es-MX"
                                            placeholder="Selecciona una fecha"
                                            :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"
                                            :min="minDate">
                                        </b-form-datepicker>
                                    </b-col>
                                    <b-col>
                                        <b-form-datepicker v-model="convoca.fechaFinMaterial" locale="es-MX"
                                            placeholder="Selecciona una fecha"
                                            :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"
                                            :min="minDate">
                                        </b-form-datepicker>
                                    </b-col>
                                </b-row>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <hr>
                    <b-row>
                        <b-col>
                            <b-form-group label="Órden del día" class="mb-0">

                                <b-card-group>
                                    <b-card footer-tag="footer" v-if="niveles.length > 0">
                                        <NivelOrden :detalles="niveles" :id-tipo-junta="convoca.idTipoJunta"
                                            :update="flagUpdate" @niveles="getNiveles" @eliminados="getEliminados">
                                        </NivelOrden>
                                    </b-card>
                                </b-card-group>
                            </b-form-group>
                        </b-col>
                    </b-row>
                    <hr>
                    <div class="w-100">
                        <b-row>
                            <b-col offset-md="9"> <b-button variant="danger" size="sm" class="float-right"
                                    @click="triggerClose">Cancelar</b-button>
                            </b-col>
                            <b-col> <b-button variant="success" size="sm" class="float-right" type="submit">
                                    Guardar
                                </b-button>
                            </b-col>
                            <!-- <b-col> <b-button variant="success" size="sm" class="float-right" @click="lectura()">
                                    Prueba lectura orden dia

                                </b-button>
                            </b-col> -->
                        </b-row>
                    </div>
                </b-form>
            </validation-observer>
        </div>
    </div>
</template>
<script>
import { HTTP } from '@/plugins/axios'
import { VueTagsInput } from '@johmun/vue-tags-input';
import NivelOrden from "@/components/Convocatorias/compOrdenDia.vue";


export default {
    name: "ConvocatoriasView",
    components: {
        VueTagsInput,
        NivelOrden,
    },
    props: {
        idConvocatoria: Number,
    },
    data() {
        return {
            convoca: {
                idConvocatoria: 0,
                convocatoria: "",
                idOrgano: 0,
                idTipoJunta: 0,
                idModalidad: 0,
                IdOrdenDia: 0,
                correoMaterial: '',
                fechaInicioMaterial: null,
                fechaFinMaterial: null,
                ubicacion: '',
                estatusConvocatoria: 0,
                listMeeting: [],
                lstOrdenDia: [],
                listNecesarios: [],
                listConocimiento: [],
                listOcultos: []
            },
            optionsTipoJunta: {},
            optionsModalidad: {},
            optionsComite: {},
            selectComite: false,
            blockRemoval: true,
            meetings: [],
            correoNecesario: '',
            correosNecesarios: [],
            autocompleteNecesarios: [],
            correoConocimiento: '',
            correosConocimiento: [],
            autocompleteConocimiento: [],
            correoOculto: '',
            correosOcultos: [],
            autocompleteOcultos: [],
            niveles: [],
            nivelesEliminados: [],
            selectModalidad: false,
            minDate: new Date(),
            horariosConvocatorias: [],
            validacionNecesarios: false,
            btnNecesarios: 'Validar Disponibilidad',
            isLoading: false,
            flagUpdate: false

        };
    },
    mounted() {
        this.getByID()
    },
    watch: {
        meetings() {
            this.blockRemoval = this.meetings.length <= 1
        }
    },
    methods: {
        triggerClose() {
            this.$emit("closeCreateModal");
        },
        getValidationState({ valid, errors }) {

            return errors[0] ? false : (valid ? true : null)
        },
        addNew() {
            debugger
            this.isLoading = true;
            this.convoca.idConvocatoria = this.idConvocatoria;
            this.convoca.listMeeting = this.meetings;
            this.convoca.lstOrdenDia = this.niveles;
            this.convoca.listNecesarios = this.correosNecesarios;
            this.convoca.listConocimiento = this.correosConocimiento;
            this.convoca.listOcultos = this.correosOcultos;

            //Validacion de horas misma fecha
            for (let i = 0; i < this.meetings.length; i++) {
                if (this.ValidarRangoHoras(this.meetings[i].horaInicio.toString(), this.meetings[i].horaFin.toString())) {
                    throw new Error(this.MensajeInfo(this.$messageConstants('errorConvocatoriasHoras')));
                }
            }

            //Validar Fechas cuando hay mas de una
            if (this.meetings.length > 1) {
                for (let i = 0; i < this.meetings.length; i++) {
                    for (let x = i + 1; x < this.meetings.length; x++) {
                        if (this.ValidarRangoFechas(this.meetings[i].fechaInicio.toString(), this.meetings[x].fechaInicio.toString())) {
                            throw new Error(this.MensajeInfo(this.$messageConstants('errorConvocatoriaFechas')));
                        }
                        //Validar Horas cuando es la misma fecha
                        if (this.ValidarFechasIgual(this.meetings[i].fechaInicio.toString(), this.meetings[x].fechaInicio.toString())) {
                            if (this.ValidarRangoHorasMismaFecha(this.meetings[i].horaInicio.toString(), this.meetings[i].horaFin.toString(), this.meetings[x].horaInicio.toString()))
                                throw new Error(this.MensajeInfo(this.$messageConstants('errorConvocatoriaFechasHoras')));
                        }
                    }
                }
            }

            const parametros = JSON.stringify(this.convoca)
            HTTP
                .post('api/Convocatorias/CrearConvocatoria', parametros).then(responseApi => {
                    if (responseApi.data.resultado == true) {
                        debugger
                        this.isLoading = false;
                        this.$emit("closeCreateModal");
                        this.$emit("reloadCalendar");
                        this.$emit("showSuccessAlert");
                        this.$emit("showAlertUpdate");
                    }
                }).catch(error => {
                    this.isLoading = false;
                    console.log(error);
                    this.MensajeError(this.$messageConstants('errorGenerico'))
                });
        },
        getTipoJunta() {
            HTTP
                .get('api/Convocatorias/GetTipoJunta')
                .then(response => {

                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200)
                        this.optionsTipoJunta = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });
        },
        getModalidad() {
            HTTP
                .get('api/Convocatorias/GetModalidad')
                .then(response => {

                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200)
                        this.optionsModalidad = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });
        },
        getComite() {
            this.isLoading = true;
            HTTP
                .get('api/Convocatorias/GetComite')
                .then(response => {
                    this.isLoading = false;
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (response.status == 200)
                        this.optionsComite = response.data;
                })
                .catch(function (error) {
                    this.isLoading = false;
                    console.log(error);
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });
        },
        onChangecomite(id) {
            debugger;
            this.selectComite = true;
            this.getCorreos(id);
        },
        addLine() {
            debugger;
            let checkEmptyLines = this.meetings.filter(line => (line.fechaInicio === '' || line.horaInicio === '' || line.horaFin === ''))
            if (checkEmptyLines.length >= 1 && this.meetings.length > 0) {
                return
            }
            this.meetings.push({
                fechaInicio: '',
                horaInicio: '',
                horaFin: '',
            })
        },
        removeLine(lineId) {

            if (!this.blockRemoval) {
                this.meetings.splice(lineId, 1)
            }
        },
        getDetallePlantilla() {
            this.isLoading = true;
            this.niveles = [];
            const parametros = JSON.stringify(this.convoca.idTipoJunta);
            HTTP.post('api/Convocatorias/ConsultarDetallePlantilla', parametros).then(responseApi => {
                this.isLoading = false;
                if (responseApi.status == 401)
                    throw new Error('No tiene acceso al recurso');

                if (responseApi.status == 200) {
                    if (responseApi.data.length == 0) {
                        this.MensajeError("No existe plantilla para este tipo de junta.")

                    } else {
                        this.flagUpdate = false;
                        //Agregar orden del dia a convoca.IdOrdenDia = 
                        this.convoca.IdOrdenDia = responseApi.data[0].idPlantillaOrdenDia;
                        this.niveles = responseApi.data;
                    }
                }
            }).catch(error => {
                this.isLoading = false;
                this.MensajeError(error)
            });
        },
        getEliminados(value) {
            this.nivelesEliminados = value;
        },
        getNiveles(value) {
            this.niveles = value;
        },
        getCorreos(idOrgano) {
            this.isLoading = true;
            const parametros = JSON.stringify(idOrgano);
            HTTP
                .post('api/Convocatorias/GetCorreos', parametros)
                .then(response => {
                    this.isLoading = false;
                    if (response.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));
                    if (response.status == 200) {
                        this.autocompleteNecesarios = response.data[0];
                        this.autocompleteConocimiento = response.data[0];
                        this.autocompleteOcultos = response.data[3]
                        this.correosNecesarios = response.data[1];
                        this.correosConocimiento = response.data[2];
                        this.correosOcultos = response.data[3];
                        this.correosConsejeros = response.data[4];
                    }
                })
                .catch(function (error) {
                    this.isLoading = false;
                    console.log(error);
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });
        },
        onChangeModalidad(id) {
            if (id == 1 || id == 2)
                this.selectModalidad = true;
            else
                this.selectModalidad = false;
        },
        async getFechasConvocatoria() {
            try {
                let res = await HTTP.get('api/Convocatorias/HorariosConvocatoria');
                if (res.status == 401)
                    throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                if (res.status == 200) {
                    return res.data;
                }
            }
            catch (error) {
                console.log(error);
                this.MensajeError(this.$messageConstants('errorGenerico'));
            }
        },
        async validarAsistentes() {
            var mensaje = '';
            let valido = false;

            this.isLoading = true;
            if (this.meetings[0].fechaInicio == "" && this.meetings[0].horaInicio == "" && this.meetings[0].horaFin == "") {
                this.isLoading = false;
                return this.MensajeWarning(this.$messageConstants('advertenciaValidacion'));
            }
            this.horariosConvocatorias = await this.getFechasConvocatoria();

            if (this.horariosConvocatorias.length == 0) {
                this.isLoading = false;
                return this.MensajeInfo(this.$messageConstants('infoValidacionDisponibilidad'));
            }

            for (let i = 0; i < this.meetings.length; i++) {
                mensaje += "En la Fecha: " + this.meetings[i].fechaInicio + " los usuarios ya tiene ocupado ese horario : ";

                for (let y = 0; y < this.correosNecesarios.length; y++) {
                    let fechaMeeting = this.meetings[i].fechaInicio + 'T00:00:00';

                    var horariosCorreo = this.horariosConvocatorias.filter(i =>
                        i.correoAsistente == this.correosNecesarios[y].text &&
                        i.fechaInicio == fechaMeeting
                    );

                    if (horariosCorreo.length > 0) {
                        for (let x = 0; x < horariosCorreo.length; x++) {
                            if (this.ValidarRangoHorasMismaFecha(horariosCorreo[x].horaInicio.toString(), horariosCorreo[x].horaFin.toString(), this.meetings[i].horaInicio.toString())) {
                                valido = true;
                                mensaje += "<li>" + this.correosNecesarios[y].text + "</li>";
                            }
                        }
                    }
                }
            }
            this.isLoading = false;
            if (valido) {
                this.MensajeInfo(mensaje);
            }
            else {
                this.MensajeInfo(this.$messageConstants('infoValidacionDisponibilidad'));
            }
        },
        getByID() {
            this.getComite()
            this.getTipoJunta()
            this.getModalidad()

            if (this.idConvocatoria == 0) {

                this.addLine()
            }
            else {
                const parametros = JSON.stringify(this.idConvocatoria);
                HTTP.post('api/Convocatorias/GetConvocatoriaEdit', parametros).then(responseApi => {
                    debugger

                    if (responseApi.status == 401)
                        throw new Error(this.MensajeError(this.$messageConstants('apiError')));

                    if (responseApi.status == 200) {
                        this.convoca = responseApi.data;
                        debugger;
                        this.meetings = this.convoca.listMeeting;
                        this.flagUpdate = true;
                        this.niveles = this.convoca.lstOrdenDia;
                        this.correosNecesarios = this.convoca.listNecesarios;
                        this.correosConocimiento = this.convoca.listConocimiento;
                        this.correosOcultos = this.convoca.listOcultos;
                        this.selectComite = true;
                    }


                }).catch(error => {
                    debugger
                    this.MensajeError(error);
                });
            }
        },

    },
    computed: {
        filteredItems() {
            return this.autocompleteNecesarios.filter(i => {
                return i.text.toLowerCase().indexOf(this.correoNecesario.toLowerCase()) !== -1;
            });
        },
        filterConocimiento() {
            return this.autocompleteConocimiento.filter(i => {
                return i.text.toLowerCase().indexOf(this.correoConocimiento.toLowerCase()) !== -1;
            })
        },
        filterOcultos() {
            return this.autocompleteOcultos.filter(i => {
                return i.text.toLowerCase().indexOf(this.correoOculto.toLowerCase()) !== -1;
            })
        }
    }
}
</script>

<style>
#my-custom-wrapper .vue-tags-input {
    max-width: 100%;
    width: 100%;
}
</style>