<template>

    <div class="container body" style="box-shadow: 2px 2px 8px #999">
        <div>
            <h3 class="p-5 "> </h3>
            <h3 class="p-5 "> </h3>
            <br />
        </div>

        <div class=container>
            <div class="d-flex h-100 justify-content-center align-items-center p-4 ">
                <div class=" text-center ">
                    <b-card tag="article" style="max-width: 88rem; ">
                        <b-card style="background-color:green; background: linear-gradient(10deg, green, white); height:100%; width:100%; left: 0%; top: 0;box-shadow: 2px 2px 8px #999">
                            <b-card-text clas="text-center" style="color:white; ">

                                <!-- <h2>Iniciar Sesi&oacute;n</h2> -->
                                <h2>{{$messageConstants("inicioSesion")}}</h2>
                                <img src='@/assets/cpm/cpm-logo.png' style="height:50px; width:50px;">
                            </b-card-text>
                        </b-card>

                        <div class="flex-grow-1 d-flex align-items-center">
                            <button :disabled="$store.getters['user/getLoading']" class="btn btn-primary w-100 p-3" @click="btnSignIn">
                                <span v-if="$store.getters['user/getLoading']">
                                    <i class="fa fa-cog fa-spin mr-2"></i> {{ $store.getters['user/getMensajeLogin'] }}
                                </span>
                                <span v-else>
                                    {{ $store.getters['user/getMensajeLogin'] }}
                                </span>
                            </button>
                        </div>


                        <br />
                    </b-card>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import authPopup from "@/app/authPopup";
    export default {
        name: "loginView",
        data() {
            return {
            }
        },
        methods: {
            btnSignIn() {
                authPopup.signIn();
            }
        },
    }

</script>


<style>
    .eye {
        position: absolute;
        z-index: 1;
    }

    .heaven {
        position: absolute;
        z-index: -1;
    }

    .body {
        background-image: url('@/assets/cpm/city.jpg');
        background-size: auto;
        height: auto;
        margin: auto;
        background-repeat: no-repeat;
    }
</style>

