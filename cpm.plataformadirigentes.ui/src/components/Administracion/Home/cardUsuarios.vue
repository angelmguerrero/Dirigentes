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
            header="Usuarios"
            class="text-center mb-3 p-2 "
            :img-src='imgsubmenu'
            img-alt="Image"
            img-top
            tag="article"
            style="max-width: 20rem;">
        <b-card-text></b-card-text>
        <b-list-group flush>
            <b-list-group-item>
                <router-link v-if="$store.getters['permisos/getPermisosByModulo']('Usuarios','Consultar') 
                            || $store.getters['permisos/getPermisosByModulo']('Usuarios','Todos') "
                             :to="{ name: 'adminUsuarios' }">Usuarios</router-link>
            </b-list-group-item>
        </b-list-group>
    </b-card>
</template>

