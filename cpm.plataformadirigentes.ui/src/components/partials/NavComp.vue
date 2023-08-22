<script>
    import authPopup from "@/app/authPopup";

    export default {
        name: 'NavComp',
        
        methods: {
            btnSignIn() {
                authPopup.signIn((user) => {
                    this.loading = true;
                    this.user = user;
                    console.log("mi ususario" + user);
                });
            },
            btnSignOut() {
                authPopup.signOut();
            }
        }
    };
</script>



<template>
    <b-container v-if="$store.getters['user/getAuthenticated']">
        <div class="fixed-top">
            <b-navbar toggleable="lg md sm" variant="white" type="light">
                <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
                <div class="container col-1">

                    <b-navbar-brand sticky="true">
                        <a class=" align-top" alt="logo"> <img src='@/assets/cpm/CPM.png' style=" height:40px; width:auto;  "></a>
                    </b-navbar-brand>
                </div>
                <b-collapse id="nav-collapse" is-nav>
                    <b-navbar-nav>
                        <b-nav-item to="/">Inicio</b-nav-item>
                        <b-nav-item v-if="$store.getters['permisos/getPermisosByMenuPadronDirigencial'] > 0"
                                    to="/Padron">Padron Dirigencial</b-nav-item>
                        <b-nav-item v-if="$store.getters['permisos/getPermisosByMenuConvocatorias'] > 0"
                                    to="/Convocatorias">Convocatorias</b-nav-item>
                        <!--<b-nav-item to="/LogJocabs">Logistica Jocabs</b-nav-item>-->
                        <!--<b-nav-item to="/Indicadores">Indicadores y Reporteria</b-nav-item>-->
                        <b-nav-item v-if="$store.getters['permisos/getPermisosByMenuAdministracion'] > 0"
                                    to="/Administracion">Administraci&oacute;n</b-nav-item>

                        <div class="navbar-item">
                            <div class="buttons">
                                <!-- Check that the SDK client is not currently loading before accessing is methods -->
                                <div>
                                    <a @click="btnSignOut" target="_blank" rel="noopener noreferrer">
                                        <i class="fas fa-sign-out-alt fa-2x" style="color: #f4f5f6;" aria-hidden="false"></i>
                                    </a>
                                </div>
                                
                            </div>
                        </div>
                    </b-navbar-nav>
                    <div style="position: absolute; right: 0;">  
                    <i class="fa fa-user fa-fw"></i>
                    <label  >{{$store.getters['user/getNombreDirigente']}}</label>                                                                                 
                                </div>
                </b-collapse>
            </b-navbar>
        </div>
    </b-container>
</template>

