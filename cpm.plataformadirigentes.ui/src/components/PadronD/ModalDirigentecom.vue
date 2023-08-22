<template>
    <b-container>



            <!--<span class="text-h5">{{ formTitle }}</span>-->
           
            <b-row>
                <div class="col-sm-2"><h5>Filtro:</h5> </div>
                <div class="col-sm-3">
                    <b-form-select v-model="selected" size="sm" :options="optionsfitro"></b-form-select>
                </div>
                <div class="col-3 ">
                    <div class="input-group input-group-sm ">

                        <input type="text" class="form-control">
                        <b-button size="sm">
                            <i class="fa-solid fa-magnifying-glass"> </i>
                            Buscar
                        </b-button>

                    </div>
                </div>


            </b-row>
            <hr />
            <br />


            <b-card class="mb-2" header-bg-variant="light">
                <b-card-body>
                    <b-row>

                        <b-card-sub-title class="mb-2 p-1">
                            <h5>Datos Generales :</h5>
                        </b-card-sub-title>

                    </b-row>
                    <hr />
                    <b-card-text>
                        <b-row class="mb-3">

                            <b-col cols="4"><B s>Estatus: <span style="color:dimgray"> {{estatusgeneral}}</span></B></b-col>
                        </b-row>
                        <b-row class="mb-3">
                            <b-col cols="4"><B s>Ap. Paterno: <span style="color:dimgray"> {{apaterno}}</span></B></b-col>
                            <b-col cols="4"><B>Ap. Materno: <span style="color:dimgray"> {{amaterno}}</span></B></b-col>
                            <b-col cols="4"><B>Nombres: <span style="color:dimgray"> {{nombres}}</span></B></b-col>
                        </b-row>
                        <b-row class="mb-3">
                            <b-col cols="4"><B s>Fec. Nacimiento: <span style="color:dimgray"> {{ fecNaciomiento}}</span></B></b-col>
                            <b-col cols="4"><B>Edad: <span style="color:dimgray"> {{edad}}</span></B></b-col>
                            <b-col cols="4"><B>RFC: <span style="color:dimgray"> {{rfc}}</span></B></b-col>
                        </b-row>
                        <b-row class="mb-3">
                            <b-col cols="4"><B s>Curp: <span style="color:dimgray"> {{curp}}</span></B></b-col>

                        </b-row>

                        <b-row class="mb-3">
                            <b-col cols="4 "><B>Plaza: <span style="color:dimgray"> {{plaza}}</span></B></b-col>
                            <b-col cols="4"><B>Sucursal: <span style="color:dimgray"> {{sucursal }}</span></B></b-col>
                            <b-col cols="4"><B>Fec. Ingreso: <span style="color:dimgray"> {{fecIngreso}}</span></B></b-col>
                        </b-row>

                        <b-row class="mb-3">
                            <b-col cols="4"><B s>Género: <span style="color:dimgray"> {{genero}}</span></B></b-col>
                            <b-col cols="4"><B>Edo. Civil: <span style="color:dimgray"> {{edoCivil}}</span></B></b-col>
                        </b-row>

                        <b-row class="mb-3">
                            <b-col cols="4"><B s>Email: <span style="color:dimgray"> {{email}}</span></B></b-col>
                            <b-col cols="4"><B>Celular: <span style="color:dimgray"> {{celular}}</span></B></b-col>
                        </b-row>


                    </b-card-text>
                </b-card-body>
            </b-card>


            <b-card class="mb-2" header-bg-variant="light">
                <b-card-body>
                    <b-card-body>
                        <b-row>

                            <b-card-sub-title class="mb-2 p-1">
                                <h5>Información Dirección:</h5>
                            </b-card-sub-title>

                        </b-row>
                        <hr />
                        <b-card-text>

                            <b-row class="mb-3">
                                <b-col cols="4"><B s>Calle: <span style="color:dimgray"> {{calle}}</span></B></b-col>
                                <b-col cols="4"><B>No Interior: <span style="color:dimgray"> {{nointerior}}</span></B></b-col>
                                <b-col cols="4"><B>CP:  <span style="color:dimgray"> {{cp}}</span></B></b-col>
                            </b-row>
                            <b-row class="mb-3">
                                <b-col cols="4"><B>Colonia:  <span style="color:dimgray"> {{colonia}}</span></B></b-col>
                                <b-col cols="4"><B>Estado:  <span style="color:dimgray"> {{estado}}</span></B></b-col>
                                <b-col cols="4"><B s>Municipio : <span style="color:dimgray"> {{ municipio }}</span></B></b-col>

                            </b-row>
                        </b-card-text>
                    </b-card-body>
                </b-card-body>
            </b-card>
            <b-card class="mb-2" header-bg-variant="light">
                <b-card-body>
                    <b-card-body>
                        <b-row>

                            <b-card-sub-title class="mb-2 p-1">
                                <h5>Formación académica:</h5>
                            </b-card-sub-title>

                        </b-row>
                        <hr />
                        <b-card-text>
                            <b-row class="mb-3">
                                <b-col cols="3"><b> Escolaridad: </b></b-col>
                                <b-col cols="3">

                                    <b-form-select v-model="selectedItem">
                                        <option :value="null" disabled> Selecciona una opción </option>
                                        <option v-for="escolaroption in escolaroptions" :key="escolaroption.id" :value="escolaroption">
                                            {{ escolaroption.descEscolaridad }}
                                        </option>
                                    </b-form-select>
                                    <!--Selected option: {{ selectedItem }}-->



                                </b-col>
                                <b-col cols="3"><b> Profesión: </b></b-col>
                                <b-col cols="3"><b-form-select v-model="selectedEsta" :options="optProfesion"></b-form-select></b-col>

                            </b-row>

                            <b-row class="mb-3">
                                <b-col cols="3"><b> Clasificación: </b></b-col>
                                <b-col cols="3"><b-form-select v-model="selectedEsta" :options="optClasificacion"></b-form-select></b-col>

                            </b-row>


                            <b-row>
                                <b-col cols="3"><b> Expediente Digital: </b></b-col>
                                <b-col cols="3">
                                    <b-form-file v-model="file1"
                                                 :state="Boolean(file1)"
                                                 placeholder="Expediente"
                                                 browse-text="Agregar"
                                                 drop-placeholder="Expediente"></b-form-file>
                                </b-col>
                                <b-col cols="3"><b> Curriculum Vitae: </b></b-col>
                                <b-col cols="3">
                                    <b-form-file v-model="file2"
                                                 :state="Boolean(file2)"
                                                 placeholder="Curriculum"
                                                 browse-text="Agregar"
                                                 drop-placeholder="Curriculum"></b-form-file>
                                </b-col>
                            </b-row>
                        </b-card-text>
                    </b-card-body>
                </b-card-body>
            </b-card>
            <b-card class="mb-2" header-bg-variant="light">
                <b-card-body>
                    <b-card-body>
                        <b-row>

                            <b-card-sub-title class="mb-2 p-1">
                                <h5>Formación como dirigente:</h5>
                            </b-card-sub-title>
                            <hr />

                        </b-row>

                        <b-card-text>
                            <b-row class="mb-3">
                                <b-col cols="4"><B>Nivel de órgano:  <span style="color:dimgray"> {{nivelorga}}</span></B></b-col>
                                <b-col cols="4"><B>Fec. Integración:  <span style="color:dimgray"> {{estado}}</span></B></b-col>
                                <b-col cols="4"><B>Cargo órgano : <span style="color:dimgray"> {{ municipio }}</span></B></b-col>

                            </b-row>

                        </b-card-text>
                    </b-card-body>
                </b-card-body>
            </b-card>

           
      

    </b-container>




</template>
<script>


    import { config } from "@/config/auth";
       import store from '@/store' 




    export default {
        name: 'ModalDirigentecom',
        components: {




        },
        data() {
            return {



                //modal
                selected: null,
                optionsfitro: [
                    { value: 1, text: 'CIF' },
                    { value: 2, text: 'Nombre' },
                    { value: 3, text: 'Cuenta Mexicana' },

                ],
                selectedEsta: [
                    { value: 1, text: 'Selecciona una Opción' },
                    { value: 2, text: 'Activo' },
                    { value: 3, text: 'Inactivo' },
                ],

                //datosGenerales
                estatusgeneral: 'Activo',
                apaterno: "Montaño",
                amaterno: "Montaño",
                nombres: "Guadalupe",
                fecNaciomiento: "09/05/1976",
                edad: 46,
                rfc: "MOJG760509TF2",
                curp: "MOJG760509MVZNRD01",
                plaza: "Coatzacoalcos",
                sucursal: "Acayucan",
                fecIngreso: "30/04/2022",
                genero: "Mujer",
                edoCivil: "Soltero",
                email: "mojg760509_ca@cpm.coop",
                celular: "4772345678",
                //informacidireccion
                calle: "Brisas del lago",
                nointerior: "127",
                cp: "37569",
                colonia: "Brisa",
                estado: "veracruz",
                municipio: "coatzacoalcos",
                //formaciónacademica

                selectedItem: null,
                escolaroptions: [],
                optProfesion: [],
                optClasificacion: [
                    { value: 1, text: 'Artistica' },
                    { value: 2, text: 'Ciencias' },
                    { value: 3, text: 'Ingenierías' },
                ],

                file1: null,
                file2: null,
                //formacion Dirigente
                nivelorga: "Coprosu",
                fecintegracion: "17/04/2022",
                cargoorgano: "Vocal",

            }

        },
        computed: {

        },
        methods: {
            //ObtenerEscolaridad() {
            //    fetch(config.auth.server_url_api + 'api/Catalogos/ConsultarProfesiones')
            //        .then(res => res.json()).then(data => this.setResultMen(data))
            //        .catch(error => {
            //            //Swal.fire("Error", "Error al obtener informacion del servidor", "error");
            //            console.error('Error:', error)
            //        });

            //},
            //setResultMen(data) {
            //    this.arregloMen = data;
            //    //console.log('arrgloMendata:', data)

            //    const { id, tex } = this.arregloMen
            //    this.escolaroptions = this.arregloMen
            //    console.log('Objetoescolar2', this.escolaroptions)
            //},
           
             ObtenerProfesiones() {

                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] }; 
                fetch(config.auth.server_url_api + 'api/CatalogoProfesion/ConsultarProfesiones', {headers})
                    .then(res => res.json()).then(data => this.setResultMenta(data))
                    .catch(error => {
                        //Swal.fire("Error", "Error al obtener informacion del servidor", "error");
                        console.error('Error:', error)
                    });

               
                },

                 setResultMenta(data) {
                    this.arreglo = data;
                    console.log('arrgloMendata:', data)

                    //const { id, tex } = this.arregloMen
                    //this.escolaroptions = this.arregloMen
                    //console.log('Objetoescolar', this.escolaroptions)
                }


        },

      
         

         mounted() {
            this.ObtenerProfesiones()

        }

    }









</script>
<style scoped>
    container-login100 {
        width: 100%;
        min-height: 100vh;
        display: -webkit-box;
        display: -webkit-flex;
        display: -moz-box;
        display: -ms-flexbox;
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        align-items: center;
        padding: 15px;
        background-repeat: no-repeat;
        background-position: center;
        background-size: cover;
        position: relative;
        z-index: 1;
    }
</style>