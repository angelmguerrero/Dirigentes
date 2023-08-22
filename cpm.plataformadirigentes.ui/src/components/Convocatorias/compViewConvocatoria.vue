<template>
    <div>

        <b-row>
            <b-col></b-col>
            <b-col class="text-center ">
                <b-button-group size="sm">
                    <b-button variant="outline-success" disabled>
                        <i class="fa-solid fa-square-check"></i> Votación
                    </b-button>
                    <b-button variant="outline-success" disabled>
                        <i class="fa-solid fa-download"></i> Material
                    </b-button>
                    <b-button variant="outline-success" disabled>
                        <i class="fa-solid fa-file-text"></i> Acta
                    </b-button>
                    <b-button variant="outline-success" disabled>
                        <i class="fa-solid fa-handshake"></i> Acuerdos
                    </b-button>
                    <b-button variant="outline-success">
                        <i class="fa-solid fa-video-camera"></i> Videoconferencia
                    </b-button>
                    <b-button variant="outline-success" disabled>
                        <i class="fa-solid fa-question-circle"></i> Preguntas
                    </b-button>
                </b-button-group>

            </b-col>
            <b-col>
                <b-button-group size="sm" v-if="mostrarBotonesConvocatoria">
                    <b-button variant="outline-success" @click="AprobarConvocatoria">
                        <i class="fa-solid fa-thumbs-up"></i> Autorizar
                    </b-button>
                    <b-button variant="outline-success" @click="AutorizarConvocatoria">
                        <i class="fa-regular fa-paper-plane"></i> Enviar
                    </b-button>
                    <b-button variant="outline-success" @click="CancelarConvocatoria">
                        <i class="fa-solid fa-ban"></i> Rechazar
                    </b-button>
                </b-button-group>
            </b-col>
            <b-col></b-col>

        </b-row>
        <b-row>
            <b-col></b-col>
            <b-col class="text-center "><br>
            </b-col>
            <b-col></b-col>
        </b-row>

        <b-row align-v="center">
            <b-col></b-col>
            <b-col cols="8" class="head text-center">
                Convocatoria
            </b-col>
            <b-col>
            </b-col>
        </b-row>
        <b-row align-v="center">
            <b-col></b-col>
            <b-col b-col cols="8" class="head text-center">
                Estatus: {{ estatusConvocatoria }}
            </b-col>
            <b-col></b-col>
        </b-row>

        <b-row>
            <div ref="divConvocatoria">
                <CreateConvocatoria @showAlertUpdate="showAlertUpdate" :idConvocatoria="this.id" disabled>
                </CreateConvocatoria>
            </div>
        </b-row>
    </div>
</template>

<script>
import CreateConvocatoria from "@/components/Convocatorias/compCreateConvocatorias.vue"
import { HTTP } from '@/plugins/axios'


export default {
    name: "EditModal",
    props: {
        id: Number,
        title: String,
    },
    data() {
        return {
            niveles: [],
            mostrarBotonesConvocatoria: true,
            estatusConvocatoria: ''
        };
    },
    mounted() {
        //this.lectura();
        this.GetEstatusConvocatoria();
    },
    components: {
        CreateConvocatoria
    },
    methods: {
        triggerClose() {
            this.$emit("closeViewModal");
        },
        getConvocatoria() {
            console.log("Convocatoria")
        },
        showAlertUpdate() {
            this.showSuccessAlert = true;
            this.MensajeSuccess(this.$messageConstants('actualizarRegistro'))
        },
        AutorizarConvocatoria() {
            debugger;
            const parametros = JSON.stringify(this.id);
            HTTP.post('api/Convocatorias/AutorizarConvocatoria', parametros).then(responseApi => {
                if (responseApi.data.resultado == true) {
                    this.MensajeSuccess(responseApi.data.mensaje)

                }
                else {
                    this.MensajeError(responseApi.data.mensaje)
                }

            }).catch(error => {
                this.MensajeError(error);
            });
        },
        CancelarConvocatoria() {
            debugger;
            const parametros = JSON.stringify(this.id);
            HTTP.post('api/Convocatorias/CancelarConvocatoria', parametros).then(responseApi => {
                if (responseApi.data.resultado == true) {
                    this.MensajeSuccess(responseApi.data.mensaje)
                }
                else {
                    this.MensajeError(responseApi.data.mensaje)
                }

            }).catch(error => {
                this.MensajeError(error);
            });
        },
        AprobarConvocatoria() {
            const parametros = JSON.stringify(this.id);
            HTTP.post('api/Convocatorias/AprobarConvocatoria', parametros).then(responseApi => {
                if (responseApi.data.resultado == true) {
                    this.MensajeSuccess(responseApi.data.mensaje)
                }
                else {
                    this.MensajeError(responseApi.data.mensaje)
                }

            }).catch(error => {
                this.MensajeError(error);
            });
        },
        GetEstatusConvocatoria() {
            debugger
            const parametros = JSON.stringify(this.id);
            HTTP.post('api/Convocatorias/GetEstatusConvocatoria', parametros).then(responseApi => {
                debugger
                if (responseApi.data == 5) {
                    this.mostrarBotonesConvocatoria = false
                    this.estatusConvocatoria = "Cancelada"
                    this.habilitarOuDeshabilitarDiv(false)
                }
                if (responseApi.data == 1)
                    this.estatusConvocatoria = "En validación"

                if (responseApi.data == 2)
                    this.estatusConvocatoria = "Publicada"


                console.log(responseApi.data);
                debugger
            }).catch(error => {
                this.MensajeError(error);
            });

        },
        habilitarOuDeshabilitarDiv(habilitar) {
            debugger
            const dElement = this.$refs.myButton;
            const divElement = dElement.id;
            console.log('ID del botón:', divElement);

            if (habilitar) {
                divElement.style.pointerEvents = 'auto';
                divElement.style.opacity = '1';
            } else {
                divElement.style.pointerEvents = 'none';
                divElement.style.opacity = '0.6';
            }
        },

    },
};
</script>
<style>
.head {
    background-color: #229954;
    color: #fff;
    height: 35px;
    font-weight: bold;
}

#divConvocatoria {
    pointer-events: none;
    opacity: 0.6;
    /* Opcional: para reducir la opacidad del div y dar una apariencia deshabilitada */
}
</style>
