<template>
    <b-form class="mt-auto">
        <b-row>
            <b-col cols="12">
                <b-form-group id="lblnombreArchivo"
                              label="Archivo:"
                              label-for="archivo">

                    <b-form-input id="archivo"
                                  type="text"
                                  v-model="archivo.Nombre"
                                  trim></b-form-input>

                </b-form-group>
            </b-col>
        </b-row>
        <b-row>
            <b-col cols="12">
                <b-form-group id="lblextension"
                              label="Extensión:"
                              label-for="extension">

                    <b-form-input id="extension"
                                  type="text"
                                  v-model="archivo.Extension"
                                  trim></b-form-input>

                </b-form-group>
            </b-col>
        </b-row>
        <b-row class="mt-4">
            <b-col cols="3">
                <b-button variant="success" @click="addNew" :disabled="disabled == 0">Descargar</b-button>
                <!--<b-button type="submit" variant="success">Guardar</b-button>-->
            </b-col>
            <b-col>
                <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
            </b-col>
        </b-row>
    </b-form>
</template>

<script>
    import { config } from "@/config/auth";
    import axios from 'axios';

    export default {
        name: "DescargarArchivo",
        data() {
            return {
                archivo: {},
                disabled: 1
            };
        },
        methods: {
            triggerClose() {
                this.$emit("closeCreateModal");
            },
            addNew() {

                axios.post(config.auth.server_url_api + `./api/Herramientas/DescargarDocumento`,
                    this.archivo                        
                    ,
                    {
                        responseType: 'blob',
                        headers: {
                            //'Content-Type': 'application/octet-stream',
                            //'Content-Type': 'application/json',
                            //'Response-Type': 'blob' // important
                            //'Response-Type': 'arraybuffer'
                        }
                    }).then(response => {
                            const url = window.URL.createObjectURL(new Blob([response.data]));
                            const link = document.createElement('a');
                            link.href = url;
                            link.setAttribute('download', this.archivo.Nombre + this.archivo.Extension);
                            document.body.appendChild(link);
                            link.click();
                    }).catch(error => {
                        this.MensajeError("Ocurrio un problema al cargar el archivo: " + error);
                    });
            },
          
        },
    };
</script>

