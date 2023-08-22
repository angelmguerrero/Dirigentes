<template>
    <div>
        <b-row class="mt-2 mb-3">
            <h6 class="text-secondary">
                &iquest; Est&aacute; seguro que quiere deshabilitar la solicitud ?
            </h6>
        </b-row>
        <loading-overlay :active='isLoading' color='#008000' />
        <b-row align-h="end" class="mt-4">
            <b-col cols="mb-3 p-2">
                <b-button variant="danger" @click="removeFromData">Deshabilitar</b-button>
            </b-col>
            <b-col cols="mb-3 p-2">
                <b-button variant="warning" @click="triggerClose">Cerrar</b-button>
            </b-col>
        </b-row>
    </div>
</template>

<script>
   import store from '@/store'  
    import { config } from "@/config/auth";
   

    export default {
        name: "DeleteModal",
        props: {
            id: Number,
           
        },
        data() {
        return {
                          
            isLoading: false,
        };
    },

        methods: {
            triggerClose() {
                this.$emit("closeDeleteModal");
            },
            removeFromData() {
                this.isLoading = true

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.id)
                };

                fetch(config.auth.server_url_api + 'api/Solicitud/Deletesolitud', requestOptions)
                    .then(async response => {
                        
                        if (response.status == 200) {
                            this.$emit("closeDeleteModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showDeleteAlert");
                            this.isLoading = false;
                        }
                        else {
                            this.isLoading = false
                            this.$swal.fire({
                                text: 'Se genero un error al deshabilitar el cargo valide con su administrador',
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
            removeFromDataxcargo() {


                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken']},
                    body: JSON.stringify(this.id, )
                };

                fetch('/api/PersonaPerfilCargoOrgano/DeletePersonaxCargo', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            this.$emit("closeDeleteModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showDeleteAlert");
                        }
                        else {
                            this.$swal.fire({
                                text: 'Se genero un error al deshabilitar el cargo valide con su administrador',
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
        },
    };
</script>