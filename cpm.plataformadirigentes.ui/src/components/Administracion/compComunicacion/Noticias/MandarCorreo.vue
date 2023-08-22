<template>
    <b-form class="mt-auto">
        <b-row>
            <b-col cols="12">
                <b-form-group id="lblcorreo"
                              label="Para:"
                              label-for="correo">

                    <b-form-input id="correo"
                                  type="text"
                                  v-model="email.addListTo"
                                  trim></b-form-input>

                </b-form-group>
            </b-col>
        </b-row>
        <b-row>
            <b-col cols="12">
                <b-form-group id="lblsubject"
                              label="Asunto:"
                              label-for="subject">

                    <b-form-input id="subject"
                                  type="text"
                                  v-model="email.Subject"
                                  trim></b-form-input>

                </b-form-group>
            </b-col>
        </b-row>
        <b-row>
            <b-col cols="12">
                <b-form-checkbox id="lblhtml"
                                 v-model="email.isBodyHTML"
                                 name="cbxstatus">
                    El body es html
                </b-form-checkbox>
            </b-col>

        </b-row>
        <b-row>
            <b-col cols="12">
                <b-form-group id="lblbody"
                              label="Cuerpo:"
                              label-for="body">

                    <b-form-input id="body"
                                  type="text"
                                  v-model="email.Body"
                                  trim></b-form-input>

                </b-form-group>
            </b-col>
        </b-row>



        <b-row class="mt-4">
            <b-col cols="3">
                <b-button variant="success" @click="addNew" :disabled="disabled == 0">Guardar</b-button>
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

    export default {
        name: "MandarCorreo",
        data() {
            return {
                email: {},
                disabled: 1
            };
        },
        methods: {
            triggerClose() {
                this.$emit("closeCreateModal");
            },
            addNew() {            


                this.disabled = 0;
                console.log("this.disabled", this.disabled); 
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(this.email)
                };
                fetch(config.auth.server_url_api + 'api/Herramientas/MandarCorreo', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            this.$emit("closeCreateModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showSuccessAlert");
                            this.disabled = 1;
                            console.log("this.disabled", this.disabled); 
                        }
                        else {
                            this.MensajeError("Error en envio");
                            this.disabled = 1;
                            console.log("this.disabled", this.disabled); 
                        }
                    })
                    .catch(error => {
                        this.MensajeError(error);
                    });
            },
        },
    };
</script>

