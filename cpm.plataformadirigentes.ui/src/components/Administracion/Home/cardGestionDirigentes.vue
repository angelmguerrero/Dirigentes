<script>
    import imglogo from '@/assets/cpm/Registro.png'

    export default {
        data() {
            return {
                imgsubmenu: imglogo,
            }

        },
    }
</script>

<template>
    <b-card border-variant="light"
            header="Gestión de dirigentes" class="text-center mb-3 p-2"
            :img-src='imgsubmenu'
            img-alt="Image"
            img-top
            tag="article"
            style="max-width: 20rem;">
        <b-card-text></b-card-text>
        <b-list-group flush>
            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Cargopororganodirigencial','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Cargopororganodirigencial','Todos') "
                             :to="{ name: 'adminCargosOrganoDirigencial' }">
                    Cargos por Órgano Dirigencial
                </router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Responsabledeplaza','Consultar')
                                 | $store.getters['permisos/getPermisosByModulo']('Responsabledeplaza','Todos') "
                             :to="{ name: 'adminResponsablePlaza' }">
                    Administración de Analistas asignados por plaza
                </router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Clasificacionporprofesion','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Clasificacionporprofesion','Todos') "
                             :to="{ name: 'adminClasificacionProfesion' }">Clasificación por profesión</router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Condicionesdeingreso','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Condicionesdeingreso','Todos') "
                             :to="{ name: 'adminCondicionesIngreso' }">Condiciones de ingreso</router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link  v-if="$store.getters['permisos/getPermisosByModulo']('Escolaridad','Consultar') 
                                 || $store.getters['permisos/getPermisosByModulo']('Escolaridad','Todos') " 
                             :to="{ name: 'adminEscolaridad' }">Escolaridad</router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link
                             v-if="$store.getters['permisos/getPermisosByModulo']('Estadocivil','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Estadocivil','Todos') "
                             :to="{ name: 'adminEstadoCivil' }">Estado civil</router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Genero','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Genero','Todos') "
                             :to="{ name: 'adminGenero' }">Género</router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('MotivoBaja','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('MotivoBaja','Todos') "
                             :to="{ name: 'adminMotivosBaja' }">Motivo de Baja</router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('TipoBaja','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('TipoBaja','Todos') "
                             :to="{ name: 'adminTiposBaja' }">Tipo de Baja</router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Plazas','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Plazas','Todos') "
                             :to="{ name: 'adminPlaza' }">Plazas</router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link 
                             v-if="$store.getters['permisos/getPermisosByModulo']('Profesion','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Profesion','Todos') "
                             :to="{ name: 'adminProfesion' }">Profesión</router-link>
            </b-list-group-item>

            <b-list-group-item>
                <router-link 
                             v-if="$store.getters['permisos/getPermisosByModulo']('Sucursales','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Sucursales','Todos') "
                             :to="{ name: 'adminSucursales' }">Sucursales</router-link>
            </b-list-group-item>


        </b-list-group>
    </b-card>
</template>