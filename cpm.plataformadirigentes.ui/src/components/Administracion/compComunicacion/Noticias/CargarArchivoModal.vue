<template>
        <b-form class="mt-auto" enctype="multipart/form-data">
            <b-row>
                <b-col cols="12">
                        <b-form-group label="Default:" label-cols-sm="2">

                            <b-form-file ref="file" id="file" name="file" v-on:change="getFile($event)" accept=".pdf"></b-form-file>

                        </b-form-group>
                </b-col>
            </b-row>

            <b-row class="mt-4">
                <b-col cols="3">
                     <b-button variant="success" @click="addNew">Guardar</b-button>
                    <!--<b-button type="submit" variant="success">Guardar</b-button>-->
                </b-col>
                <b-col>
                    <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
                </b-col>
            </b-row>
        </b-form>
</template>

<script>

    import axios from 'axios';

    export default {
        name: "CargarArchivo",
        data() {
            return {
                email: {},
                file: ""
            };
        },
        methods: {
            triggerClose() {
                this.$emit("closeCreateModal");
            },
            getFile(event) {
                debugger
                const nombre = event.target.files[0].name;
                let extension = nombre.split('.');
                let size = extension.length;
                if (extension[size-1].toString() != "pdf") {
                    this.MensajeError("Tipo de archivo invalido");
                } else {
                    this.file = event.target.files[0];
                    console.log(this.file);
                }
            },
            addNew() {
                debugger
                //var files = this.$refs["file"].files;
                let fileData = new FormData();

                // Looping over all files and add it to FormData object
                //for (var i = 0; i < files.length; i++) {
                    fileData.append('file', this.file, this.file.name);

                //} 
               
                    axios.post(`./api/Herramientas/AgregarDocumento`,
                        fileData,
                        {
                            headers: {
                                'Content-Type': 'multipart/form-data'
                            }
                        }).then(response => {
                            this.MensajeSuccess("Archivo cargado: " + response.data);
                            //alert(`Total Mock File Uploaded: ${response.data}`);
                        }).catch(error => {
                            this.MensajeError("Ocurrio un problema al cargar el archivo: " + error);
                            //alert(`something went wrong: ${error}`);
                        });
                //const requestOptions = {
                //    method: 'POST',
                //    headers: { 'Content-Type': 'multipart/form-data'},
                //    //enctype: 'multipart/form-data',
                //    //body: JSON.stringify(this.email),
                //    data: fileData
                //};
                //fetch('./api/Herramientas/AgregarDocumento', requestOptions)
                //    .then(async response => {

                //        if (response.status == 200) {
                //            this.$emit("closeCreateModal");
                //            this.$emit("reloadDataTable");
                //             this.$emit("showSuccessAlert");
                //        }
                //        else {
                //            this.MensajeError("correo mandado");
                //        }
                //    })
                //    .catch(error => {
                //        this.MensajeError(error);
                //    });
            },
        },
    };
</script>

