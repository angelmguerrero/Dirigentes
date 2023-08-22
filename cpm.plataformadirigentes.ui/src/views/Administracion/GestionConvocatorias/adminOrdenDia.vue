<template>
    <b-container>
        <br /><br /> <br />
        <logoEncabezado />
        <br />
        <b-card title="Administración Órdenes del día" class="mb-2">
            <div class=" col-6 justify-content-center p-2" style="width:100px; height: 20px;background-color: #C8FE2E;"></div>
            <b-card-body>
                <data-table></data-table>
            </b-card-body>
        </b-card>
    </b-container>
</template>

<script>
    import logoEncabezado from '@/components/Administracion/Home/compLogoEncabezado.vue'
    import DataTable from "@/components/Administracion/compConvocatorias/OrdenesDia/DataTable.vue";

    export default {
        components: {
            logoEncabezado,
            DataTable
        },
        data() {
            return {

            }
        },
        computed: {

        },
        methods: {
        }
    }

</script>


<style>
</style>
