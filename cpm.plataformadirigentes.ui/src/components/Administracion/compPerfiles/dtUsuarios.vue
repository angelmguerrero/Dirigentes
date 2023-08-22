<template>
    <div>
        <table id="datatable" class="light">
            <thead>
                <tr>
                    <th>Id</th>                    
                    <th>Estatus</th>
                    <th>Correo Acceso</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="user in users" :key="user.idCargo">
                    <td>{{ user.idUsuario }}</td>
                    <td>{{ user.EstatusUsuario }}</td>
                    <td>{{ user.CorreoAcceso }}</td> 
                    <td>
                        <b-row class="">
                            <!--<b-button class="mx-1" size="sm" v-b-modal.modalNuevo variant="light"><i class="fa-solid fa-eye"></i></b-button>-->
                            <b-button class="mx-1" size="sm" v-b-modal.modalNuevo variant="light"><i class="fa-solid fa-pen-to-square"></i></b-button>
                            <!--//v-on:input="addToCart($event, ticket.id)"-->
                        </b-row>

                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>





<script>
    import "jquery/dist/jquery.min.js";
    import "datatables.net-dt/js/dataTables.dataTables";
    import "datatables.net-dt/css/jquery.dataTables.min.css";
    import languageDE from 'datatables.net-plugins/i18n/es-MX';
    import $ from "jquery";
    import { config } from "@/config/auth";

    export default {
        mounted() {
            fetch(config.auth.server_url_api + 'api/Usuarios/ConsultarUsuarios')
                .then((response) => response.json())
                .then((data) => {
                    this.users = data;
                    setTimeout(() => {
                        $("#datatable").DataTable({
                            lengthMenu: [
                                [5, 10, 25, 50, -1],
                                [5, 10, 25, 50, "All"],
                            ],
                            pageLength: 5,
                            language: languageDE,
                        });
                    });
                });
        },
        data: function () {
            return {
                users: [],
            };


        },
    };

</script>