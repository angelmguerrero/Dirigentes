<template>
    <b-container>
        <logoEncabezado />
        <br />
        <br />
        <br />
        <b-row>
            <b-col class="text-center">
                <h1>Módulo de Administración</h1>
            </b-col>
        </b-row>

        <b-card-group class="mb-3 p-2">
            <!-- Perfiles y Permisos -->
            <cardPerfiles />

            <!-- Usuarios -->
            <cardUsuarios />

            <!-- Gestión de dirigentes -->
            <cardGestionDirigentes />

            <!-- Gestión de Convocatorias -->
            <cardGestionConvocatorias />

            <!-- Gestión de comunicación -->
            <!--<cardGestionComunicacion />-->

        </b-card-group>
    </b-container>
</template>

<script>
    //import cardGestionComunicacion from '@/components/Administracion/Home/cardGestionComunicacion.vue'
    import cardGestionConvocatorias from '@/components/Administracion/Home/cardGestionConvocatorias.vue'
    import cardGestionDirigentes from '@/components/Administracion/Home/cardGestionDirigentes.vue'
    import cardPerfiles from '@/components/Administracion/Home/cardPerfiles.vue'
    import cardUsuarios from '@/components/Administracion/Home/cardUsuarios.vue'
    import logoEncabezado from '@/components/Administracion/Home/compLogoEncabezado.vue'

    export default {
        name: 'AdministracionView',
        components: {
            logoEncabezado,
            //cardGestionComunicacion,
            cardGestionConvocatorias,
            cardGestionDirigentes,
            cardPerfiles,
            cardUsuarios
        }
    }
</script>

<style>
    
</style>