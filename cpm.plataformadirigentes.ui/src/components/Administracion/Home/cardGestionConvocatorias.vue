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
            header="Gestión de Convocatorias" class="text-center mb-3 p-2 "
            :img-src='imgsubmenu'
            img-alt="Image"
            img-top
            tag="article"
            style="max-width: 20rem;">
        <b-card-text></b-card-text>
        <b-list-group flush>

            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Diasinhabiles','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Diasinhabiles','Todos') " 
                             :to="{ name: 'adminDiasInhabiles' }">Días inhábiles</router-link>
            </b-list-group-item>
            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Diasparametrizables','Consultar')
                                || $store.getters['permisos/getPermisosByModulo']('Diasparametrizables','Todos') "
                             :to="{ name: 'adminLimitesInformes' }">Días Parametrizable</router-link>
            </b-list-group-item>
            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Estatusdeacuerdos','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Estatusdeacuerdos','Todos') "
                             :to="{ name: 'adminEstatusAcuerdos' }">Estatus de acuerdos</router-link>
            </b-list-group-item>
            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Ordendeldia','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Ordendeldia','Todos') "
                             :to="{ name: 'adminOrdenDia' }">Ordenes del día</router-link>
            </b-list-group-item>
            <b-list-group-item>
                <!--<router-link v-if="$store.getters['permisos/getPermisosByModulo']('Organosdirigenciales,funcionalesyrepresentaciones','Consultar')
                    || $store.getters['permisos/getPermisosByModulo']('Organosdirigenciales,funcionalesyrepresentaciones','Todos') "
                 :to="{ name: 'adminOrganosDirigenciales' }">Órganos dirigenciales, funcionales y representaciones</router-link>-->
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Organosdirigenciales,funcionalesyrepresentaciones','Consultar')
                                || $store.getters['permisos/getPermisosByModulo']('Organosdirigenciales,funcionalesyrepresentaciones','Todos') "
                             :to="{ name: 'adminOrganosDirigenciales' }">Administración de Órganos dirigenciales</router-link>
            </b-list-group-item>
            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Personaladministrativo','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Personaladministrativo','Todos') "
                             :to="{ name: 'adminPersonalAdministrativo' }">Personal Administrativo</router-link>
            </b-list-group-item>
            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Repositoriodefirmas','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Repositoriodefirmas','Todos') "
                             :to="{ name: 'adminFirmas' }">Repositorio de firmas</router-link>
            </b-list-group-item>
            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Tipodejuntaoconvocatoria','Consultar') 
                                || $store.getters['permisos/getPermisosByModulo']('Tipodejuntaoconvocatoria','Todos') "
                             :to="{ name: 'adminTiposJunta' }">Tipos de juntas</router-link>
            </b-list-group-item>

        </b-list-group>
    </b-card>
</template>