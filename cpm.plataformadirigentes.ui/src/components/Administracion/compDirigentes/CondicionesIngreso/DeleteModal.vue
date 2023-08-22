<template>
    <b-container fluid>
        <b-row class="justify-content-md-center">
            <h6 class="text-secondary">
                {{ $messageConstants("confirmarBorrado") }}
            </h6>
        </b-row>
        <b-row class="text-center"> 
            <b-col>
                <b-button variant="danger" @click="removeFromData"> {{ $messageConstants("mensajeBotonAceptar") }}</b-button>
            </b-col>
            <b-col>
                <b-button variant="warning" @click="triggerClose"> {{ $messageConstants("mensajeBotonCerrar") }}</b-button>
            </b-col>
        </b-row>
    </b-container>
</template>


<script>
    import { HTTP } from '@/plugins/axios'

    export default {
        name: "DeleteModal",
        props: {
            id: Number,
        },
        methods: {
            triggerClose() {
                this.$emit("closeDeleteModal");
            },
            removeFromData() {
                const parametros = JSON.stringify(this.id);
                HTTP.post('api/CatalogoCondicionIngreso/Delete', parametros).then(responseApi => {
                    if (responseApi.status == 200) {
                        this.$emit("closeDeleteModal");
                        this.$emit("reloadDataTable");
                        this.$emit("showDeleteAlert");
                    }
                    else {
                        this.MensajeError(this.$messageConstants('errorConfirmarBorrado'))
                    }

                }).catch(error => {
                    this.MensajeError(error);
                });


            },
        },
    };
</script>