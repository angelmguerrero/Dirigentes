<template>
    <b-container>
        <br /><br /> <br /><br />
        <b-card title="Convocatorias" class="mb-2">
            <div class=" col-6 justify-content-center p-2" style="width:160px; height: 20px;background-color: #C8FE2E;"></div>
            <b-card-body>
                <CalendarioConvocatoria></CalendarioConvocatoria>
            </b-card-body>
        </b-card>
    </b-container>
</template>

<script>

import CalendarioConvocatoria from "@/components/Convocatorias/compCalendarioConvocatorias.vue"
export default {
    name: 'ConvocatoriasView',
    components: {
        CalendarioConvocatoria

    },
    data() {
        return { 

        }
    },
    mounted() {

    },
    methods: {

    }
}
</script>



