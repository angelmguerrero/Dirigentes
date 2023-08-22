<template>
    <b-container style="background-color: #F4F7F7 ">



        <div v-if="$store.getters['user/getAuthenticated']">
            <br />
            <br />
            <br />
            <div class="row m-2 p-2">
                <b-container style=" height:90%; width:90%; ">
                    <BannerComp></BannerComp>
                </b-container>
            </div>
            <div class="row m-3 p-3">
                <h2>Que tienes por hacer el día de hoy ? </h2>
                <br />
            </div>
            <div class="row ">
                <CardsComp> </CardsComp>
            </div>
            <h2>Noticias y Eventos </h2>
            <br />
            <div class="row " style="background-color:green">
                <div class=" col-12 ">
                    <NoticiasComp></NoticiasComp>
                </div>
            </div>
            <div class="row m-3 p-3">
                <h2>
                    Quienes somos
                </h2>
                <br />
            </div>
            <div class="row">
                <div class="col-3">
                    <div class="card " style="position:relative">
                        <img src='@/assets/cpm/Registro_1.jpg' class="card-img-top" alt="...">
                    </div>
                </div>
                <div class="col-3">
                    <div class="card " style="position:relative">
                        <img src='@/assets/cpm/Seguimiento.jpg' class="card-img-top" alt="...">
                    </div>
                </div>
                <div class="col-3">
                    <div class="card " style="position:relative">
                        <img src='@/assets/cpm/Seguimiento.jpg' class="card-img-top" alt="...">
                    </div>
                </div>
                <div class="col-3">
                    <div class="card " style="position:relative">
                        <img src='@/assets/cpm/Registro_1.jpg' class="card-img-top" alt="...">
                    </div>
                </div>
            </div>
            <br />
            <h2>
                Vínculos Cooperativismo
            </h2>
            <br />
            <div class="row ">
                <div class="col">
                    <b-card title="Card Title" :img-src=img2 img-alt="Image" img-top tag="article" style="max-width: 20rem;"
                        class="mb-2">
                        <b-card-text>
                            Some quick example text to build on the card title and make up the bulk of the card's content.
                        </b-card-text>
                        <b-button href="#" variant="primary">Go somewhere</b-button>
                    </b-card>
                </div>
                <div class="col">
                    <b-card title="Card Title" :img-src=img2 img-alt="Image" img-top tag="article" style="max-width: 20rem;"
                        class="mb-2">
                        <b-card-text>
                            Some quick example text to build on the card title and make up the bulk of the card's content.
                        </b-card-text>
                        <b-button href="#" variant="primary">Go somewhere</b-button>
                    </b-card>
                </div>
                <div class="col">
                    <b-card title="Card Title" :img-src=img2 img-alt="Image" img-top tag="article" style="max-width: 20rem;"
                        class="mb-2">
                        <b-card-text>
                            Some quick example text to build on the card title and make up the bulk of the card's content.
                        </b-card-text>
                        <b-button href="#" variant="primary">Go somewhere</b-button>
                    </b-card>
                </div>
                <div class="col">
                    <b-card title="Card Title" :img-src=img2 img-alt="Image" img-top tag="article" style="max-width: 20rem;"
                        class="mb-2">
                        <b-card-text>
                            Some quick example text to build on the card title and make up the bulk of the card's content.
                        </b-card-text>
                        <b-button href="#" variant="primary">Go somewhere</b-button>
                    </b-card>
                </div>
            </div>
        </div>
        <div v-else>
            <div class=" col-12 ">
                <AccessDenied></AccessDenied>
            </div>


        </div>
    </b-container>
</template>
<script>
import BannerComp from '..//Home/BannerComp.vue'
import CardsComp from '..//Home/CardsComp.vue'
import NoticiasComp from '..//Home/NoticiasComp.vue'
import img from '@/assets/cpm/CORPO2.png'
import AccessDenied from '@/views/Error/AccessDenied.vue'

export default {
    name: 'InicioView',
    components: {
        BannerComp,
        CardsComp,
        NoticiasComp,
        AccessDenied
    },
    data() {
        return {
            img2: img
        }
    }
}
</script>
