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
            header="Gestión de comunicación" class="text-center mb-3 p-2 "
            :img-src='imgsubmenu'
            img-alt="Image"
            img-top
            tag="article"
            style="max-width: 20rem;">
        <b-card-text></b-card-text>
        <b-list-group flush>
            <b-list-group-item>
                <router-link :to="{ name: 'adminFelicitaciones' }">Felicitaciones</router-link>
            </b-list-group-item>
            <b-list-group-item>
                <router-link :to="{ name: 'adminGaleria' }">Galería fotográfica, videos y publicaciones</router-link>
            </b-list-group-item>
            <b-list-group-item>
                <router-link :to="{ name: 'adminNoticias' }">Noticias y eventos</router-link>
            </b-list-group-item>
            <b-list-group-item>
                <router-link :to="{ name: 'adminVinculos' }">Vinculación a otros sitios o portales</router-link>
            </b-list-group-item>


        </b-list-group>
    </b-card>
</template>