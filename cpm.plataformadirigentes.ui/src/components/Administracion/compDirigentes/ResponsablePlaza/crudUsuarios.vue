<template>
    <b-container>

        <!-- Código HTML -->
        

        <b-modal id="modalNuevo" size="lg">
            <template #modal-title>
                <h1> hola {{selectedUser}}</h1>
                Aquí va el tipo de movimiento {{tipo}} Usuario




            </template>
            <b-container class="bv-example-row" fluid>

                <b-form-group id="fieldset-1"
                              label="Id"
                              label-for="usuario"
                              :invalid-feedback="invalidFeedback"
                              :state="state">
                    <b-form-input id="usuario" :state="state" trim v-model="idUsuario"></b-form-input>
                </b-form-group>
                 
            </b-container>
        </b-modal>



    </b-container>



</template>

<script>
export default {
  name: "modelCRUD",
  props: {
    //idCargo: Number,
    //DescCargo: String,
    //EstatusCargo: Number,
    //OrdenCargo: Number
  },
  data() {
    return {}
  },
  computed: {},
  methods: {}
}
</script>

<style>
    /* Estilos CSS */
</style>
