<template>
    <div>
        <br /><br /> <br />
        <logoEncabezado />
        <br />
        <b-card title="Administración Cargos por Órgano Dirigencial">
            <div class=" col-6 justify-content-center p-2" style="width:100px; height: 20px;background-color: #C8FE2E;"></div>
            <b-card-body>
                <data-table></data-table>
            </b-card-body>
        </b-card>
    </div>
</template>

<script>
    import logoEncabezado from '@/components/Administracion/Home/compLogoEncabezado.vue'
    import DataTable from '@/components/Administracion/compDirigentes/CargoOrgano/DataTable.vue'

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