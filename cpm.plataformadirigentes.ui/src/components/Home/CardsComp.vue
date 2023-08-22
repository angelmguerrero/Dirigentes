
<template>
    
       
            <b-card-group class="mb-3 p-2">

                <b-card border-variant="light"
                        header=" Gestión de Convocatorias"
                        class="text-center mb-3 p-2 "
                        :img-src='imgsubmenu'
                        img-alt="Image"
                        img-top
                        tag="article"
                        style="max-width: 20rem;">
                    <b-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</b-card-text>
                    <b-list-group flush>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Cargos</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Cargo por &Oacute;rgano Dirigencial</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Clasificaci&oacute;n por profesi&oacute;n</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Escolaridad</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Estado Civil</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> G&eacute;nero</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Motivos de Baja</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Plazas</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Profesiones</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Sucursales</a></b-list-group-item>
                    </b-list-group>
                </b-card>



                <b-card border-variant="light"
                        header="Gestion de Dirigentes"
                        class="text-center mb-3 p-2 "
                        :img-src='imgsubmenu'
                        img-alt="Image"
                        img-top
                        tag="article"
                        style="max-width: 20rem;">
                    <b-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</b-card-text>
                    <b-list-group flush>

                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Días Inhábiles</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Días Límite Informes</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Estatus de Acuerdos</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Órdenes del Día</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Organos Dirigenciales, funcionales </a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Personal Administrativo</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Repositorio de Firmas</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Tipos de Juntas</a></b-list-group-item>
                    </b-list-group>
                </b-card>


                <b-card border-variant="light"
                        header="Gestión de Convocatorias" class="text-center mb-3 p-2"
                        :img-src='imgsubmenu'
                        img-alt="Image"
                        img-top
                        tag="article"
                        style="max-width: 20rem;">
                    <b-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</b-card-text>
                    <b-list-group flush>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Felicitaciones</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Galeria fotográfica, videos y publicaciones</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue">  Noticias y Eventos</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue">  Vinculacion a otros sitios o portales</a></b-list-group-item>


                    </b-list-group>
                </b-card>
                <b-card border-variant="light"
                        header=" Convocatorias" class="text-center mb-3 p-2 "
                        :img-src='imgsubmenu'
                        img-alt="Image"
                        img-top
                        tag="article"
                        style="max-width: 20rem;">
                    <b-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</b-card-text>
                    <b-list-group flush>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Convocatorias</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Material</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue">  Acuerdos</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue">  Actas</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Resumen Ejecutivo</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue"> Correspondencia</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue">  Registro de participantes y Hospedaje</a></b-list-group-item>
                        <b-list-group-item><a href="" class="card-link" style="color:blue">  Control de gastos</a></b-list-group-item>


                    </b-list-group>
                </b-card>






            </b-card-group>
      




</template>

<script>

    import img from '@/assets/cpm/Registro.png'

    export default {
        name: 'CProvComp',

     

        data() {

            return {
                hover: false,
                //menus: [
                //    { id: 0, nombre: 'Gestion de Dirigentes', descripcion: 'Some quick example text to build on the card title and make up the bulk of the cards content' },
                //    { id: 2, nombre: 'Gestión de Convocatorias', descripcion: 'Some quick example text to build on the card title and make up the bulk of the cards content' },
                //    { id: 3, nombre: 'Gestión de Comunicación', descripcion: 'Some quick example text to build on the card title and make up the bulk of the cards content' },
                //    { id: 4, nombre: 'Convocatorias', descripcion: 'Some quick example text to build on the card title and make up the bulk of the cards content' },

                //],
                descripcion2: 'Some quick example text to build on the card title and make up the bulk of the cards content',
                imgsubmenu:img,
                



            }




        },
       




    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>


    .active {
        background-color: lightgrey;
        -webkit-transition: all 0.3s;
        -o-transition: all 0.3s;
        -moz-transition: all 0.3s;
        transition: all 0.3s;
    }

    a:hover {
        color: #ffed58;
        text-decoration: underline;
    }


    .block1-txt-child2 {
        border-bottom: 2px solid #fff;
        overflow: hidden;
        -webkit-transform: scaleX(0);
        -moz-transform: scaleX(0);
        -ms-transform: scaleX(0);
        -o-transform: scaleX(0);
        transform: scaleX(0);
    }

    .block1-link {
        -webkit-transform: translateY(250%);
        -moz-transform: translateY(250%);
        -ms-transform: translateY(250%);
        -o-transform: translateY(250%);
        transform: translateY(250%);
    }
</style>
