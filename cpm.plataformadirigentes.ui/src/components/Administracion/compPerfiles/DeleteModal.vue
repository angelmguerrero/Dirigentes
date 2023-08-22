<template>
    <div>
        <b-row class="mt-2 mb-3">
            <h6 class="text-secondary">
                &iquest; Est&aacute; seguro que quiere deshabilitar este registro ?
            </h6>
        </b-row>
        <b-row class="mt-4">
            <b-col>
                <b-button variant="danger" @click="removeFromData">Deshabilitar</b-button>
            </b-col>
            <b-col>
                <b-button variant="warning" @click="triggerClose">Cerrar</b-button>
            </b-col>
        </b-row>
    </div>
</template>

<script>
    import { config } from "@/config/auth";
    import store from '@/store'; 

    export default {
        name: "DeleteModal",
        data() {
            return {

                usuarioLog: {},

            };
        },
        props: {
            id: Number,
        },
        methods: {
            triggerClose() {
                this.$emit("closeDeleteModal");
            },
            removeFromData() {
             //   debugger

                const requestOptions = {
                    method: 'POST',
                    //headers: { 'Content-Type': 'application/json' },
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },//CAMBIO SEGURIDAD
                    body: JSON.stringify(this.id)
                };

                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioDelete', requestOptions)
                    .then(async response => {
                       // debugger
                        if (response.status == 200) {
                            this.addNewLog();
                            this.$emit("closeDeleteModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showDeleteAlert");
                        }
                        else {
                            this.$swal.fire({
                                text: 'Se genero un error al deshabilitar el usuario valide con su administrador',
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                            });
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            addNewLog() {

                this.usuarioLog.idModulo = 1;
                this.usuarioLog.idSubModulo = 1;
                this.usuarioLog.tipoMovimiento = 'Baja';
                this.usuarioLog.descripcion = 'Id: ' + this.id;
                console.log("Comienza agregar usuarioLog");
                console.log("usuario" + this.usuarioLog);
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] }, // CAMBIO SEGURIDAD
                    body: JSON.stringify(this.usuarioLog)
                };
                //  debugger
                fetch(config.auth.server_url_api + 'api/LogGeneral/CrearLogGeneral', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            this.$emit("closeCreateModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showSuccessAlert");
                        }
                        else {
                            this.$swal.fire({
                                text: 'Se genero un error al crear el log general, consulte con su administrador',

                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                            });
                        }
                    })
                    .catch(error => {
                        this.errorMessage = error;
                        console.error('There was an error!', error);
                    });

            },
        },
    };
</script>