<template>
    <div>
        <loading-overlay :active='isLoading' color='#008000' />
        <b-row>
            <b-col></b-col>
            <b-col></b-col>
            <b-col></b-col>
            <b-col></b-col>
            <b-col></b-col>
            <b-col></b-col>
            <b-col></b-col>
            <b-col></b-col>
            <b-col></b-col>
            <b-col>
                <b-button-group size="sm">
                    <b-button v-if="$store.getters['permisos/getPermisosByModulo']('Convocatoria', 'Consultar')
                        || $store.getters['permisos/getPermisosByModulo']('Convocatoria', 'Todos')"
                        variant="outline-success" id="show-btn" @click="showCreateModal">
                        <i class="fa-solid fa-plus"></i> Nuevo
                    </b-button>
                </b-button-group>
            </b-col>
        </b-row>
        <b-form class="mt-auto" @submit.stop.prevent="handleSubmit(buscarporFechas)">
            <b-row class="justify-content-md-center sm-3">
                <b-col col-4>
                    <div class="input-group input-group-sm ">
                        <div class="labelbusqueda">Buscar</div>
                    </div>
                </b-col>
                <b-col>
                    <div class="labelbusqueda">Organo Dirigencial</div>
                </b-col>
                <b-col>
                    <div class="labelbusqueda">Fecha</div>
                </b-col>
                <b-col></b-col>
            </b-row>
            <b-row class="justify-content-md-center sm-3">
                <b-col col-4>
                    <div class="input-group input-group-sm ">
                        <b-form-input v-model="filter" type="search" placeholder="Ingresa el dato"
                            @input="Filtra(tipo, filter)"></b-form-input>
                    </div>
                </b-col>
                <b-col>
                    <div class="input-group input-group-sm ">
                        <b-form-select v-model="tipo" :options="optionsComite" @input="Filtra(tipo, filter)"
                            size="sm"></b-form-select>
                    </div>
                </b-col>
                <b-col>
                    <div class="input-group input-group-sm ">
                        <b-form-datepicker id="txtfechaInicio" v-model="filtro.fechaInicio" locale="es-MX" class="mb-2"
                            placeholder="Selecciona una fecha" label-help=""
                            label-no-date-selected="No se ha seleccionado una fecha"
                            :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }" @input="IrAFecha()"
                            aria-describedby="input-1-live-feedback" trim></b-form-datepicker>
                    </div>
                </b-col>
                <b-col>
                    <b-button size="sm">
                        <i class="fa-solid fa-magnifying-glass"> </i>
                        Buscar
                    </b-button>
                </b-col>
            </b-row>
        </b-form>
        <br />
        <b-row style="display: flex;flex-direction: column;flex-grow: 1;">
            <div class="calendar-parent">
                <calendar-view :show-date="showDate" :items="filtrados" :locale="locale"
                    :weekdayNameFormat="weekdayNameFormat" :display-period-count="displayPeriodCount"
                    @click-item="onClickItem" class="theme-default">
                    <template #header="{ headerProps }">
                        <calendar-view-header :header-props="headerProps" @input="setShowDate" />
                    </template>
                </calendar-view>
            </div>
        </b-row>
        <!--Modal for add-->
        <b-modal ref="create-modal" title="Nueva Convocatoria" size="xl" header-bg-variante="sucess"
            header-text-valiant="light" body-bg-variant="light" scrollable hide-footer>
            <CreateConvocatoria @closeCreateModal="closeCreateModal" @showSuccessAlert="showAlertCreate"
                @reloadCalendar="getData" :idConvocatoria="idConvocatoriaNueva">
            </CreateConvocatoria>
        </b-modal>
        <!--Modal for view-->
        <b-modal ref="view-modal" title="Revisión de convocatoria" size="xl" header-bg-variante="sucess"
            header-text-valiant="light" body-bg-variant="light" scrollable hide-footer>
            <VerConvocatoria @closeViewModal="closeViewModal" @showSuccessAlert="showAlertCreate" @reloadCalendar="getData"
                :id="id" :title="title">
            </VerConvocatoria>
        </b-modal>
    </div>
</template>

<script>
import CreateConvocatoria from "@/components/Convocatorias/compCreateConvocatorias.vue"
import VerConvocatoria from "@/components/Convocatorias/compViewConvocatoria.vue"
import { HTTP } from '@/plugins/axios'
export default {
    name: 'CalendarioConvocatoria',
    components: {
        CreateConvocatoria,
        VerConvocatoria

    },
    data() {
        return {
            isLoading: false,
            id: 0,
            title: "",
            showSuccessAlert: false,
            showDate: new Date(),
            displayPeriodCount: 1,
            locale: "es-MX",
            weekdayNameFormat: "long",
            items: [],
            filter: "",
            filtrados: [],
            filtro: {},
            optionsComite: {},
            tipo: "",
            idConvocatoriaNueva: 0
        }
    },
    mounted() {
        this.getComite()
        this.getData()
    },
    methods: {
        onClickItem(e) {
            this.id = parseInt(e.id);
            this.title = e.title;
            this.$refs["view-modal"].show();
        },
        closeViewModal() {
            this.$refs["view-modal"].hide();
        },
        showCreateModal() {
            this.$refs["create-modal"].show();
        },
        closeCreateModal() {
            this.$refs["create-modal"].hide();
        },
        showAlertCreate() {
            this.showSuccessAlert = true;
            this.MensajeSuccess(this.$messageConstants('crearRegistro'))
        },
        getComite() {
            HTTP
                .get('api/Convocatorias/GetComite')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.$messageConstants('apiError'));

                    if (response.status == 200)
                        this.optionsComite = response.data;
                    this.optionsComite.unshift({ text: 'Todos', value: "" });
                })
                .catch(function (error) {
                    console.log(error);
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });

        },
        getConvocatorias() {
            this.isLoading = true;
            HTTP
                .get('api/Convocatorias/GetConvocatorias')
                .then(response => {
                    if (response.status == 401)
                        throw new Error(this.$messageConstants('apiError'));

                    if (response.status == 200)
                        this.items = response.data;
                        this.filtrados=this.items;
                        this.filtrados.forEach(function (element) {
                            console.log(element.classes);
                            
                        if (element.status==1){
                            element.classes=["validacion"];
                        }
                        if (element.status==2){
                            element.classes=["publicada"];
                        }
                        if (element.status==5){
                            element.classes=["cancelada"];
                        }
                        console.log(element.classes);
                });
                        
                })
                .catch(function (error) {
                    console.log(error);
                    this.MensajeError(this.$messageConstants('errorGenerico'));
                });
                this.isLoading = false;
        },
        Filtra(type, filtro) {
            var newArray = this.items.filter(x =>
                (!filtro || x.title.toLowerCase().includes(filtro.toLowerCase())) &&
                (!type || x.idOrgano == type)
            );
            this.filtrados = newArray;
        },
        IrAFecha() {
            if (typeof this.filtro.fechaInicio !== 'undefined') {

                var date = this.filtro.fechaInicio;
                var arr1 = date.split('-');
                this.showDate = new Date(arr1[0], arr1[1] - 1, arr1[2], 0, 0, 0);
                this.filtrados.forEach(function (element) {
                    if (element.startDate==date){
                        element.style = "border:solid 2px #FF6600";
                    }else{
                        element.style = "";
                    }
                });

            }
        },
        setShowDate(d) {
            this.showDate = d;
        },
        getData() {
            this.filtro.fechaInicio = null;
            this.getConvocatorias()
        },
    }
}
</script>
<style>

.validacion{
    background-color: #9ACD32 !important;
}
.publicada{
    background-color: #FFFF64 !important;
}
.cancelada{
    background-color: #DC3545 !important;
    color: white;
}

.calendar-parent {
	display: flex;
	flex-direction: column;
	flex-grow: 1;
	overflow: hidden;
	max-height: 80vh;
	background-color: white;
    height: 700px;
}

.calendar-parent {
    display: flex;
    flex-direction: column;
    flex-grow: 1;
    overflow: hidden;
    max-height: 80vh;
    background-color: white;
    height: 700px;
}

.labelbusqueda {
    font-weight: bold;
}

.theme-default .cv-header {
    background-color: #f0f0f0;
}

.theme-default .cv-header-day {
    background-color: #229954;
    color: #fff;
    text-transform: capitalize;
}

.theme-default .cv-day.today {
    background-color: #FFFF64;
}

.theme-default .cv-item {
	border-color: silver;
	border-radius: 0.5em;
	background-color: #C1E9FE;
	text-overflow: ellipsis;
    cursor: pointer;
}

.theme-default .cv-header button {
    color: #7f7f7f;
}
</style>