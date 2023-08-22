<template>
    <div>
        <br /><br /> <br />
        <logoEncabezado />
        <br />
        <b-card title="Padrón de Dirigentes" class="mb-2">
            <div class=" col-6 justify-content-center p-2" style="width:100px; height: 20px;background-color: #C8FE2E;"></div>
            <b-card-body>
                <data-table></data-table>
            </b-card-body>
        </b-card>



      
     


        <!--<b-card title="Padron de Dirigentes"
                class="mb-2">

            <div class=" col-6 justify-content-center p-2" style="width:100px; height: 20px;background-color: #C8FE2E;"></div>-->
            <!--<b-card-body>
                <b-row>
                    <b-col class="col-8"></b-col>
                    <b-col class="col-4">

                        <b-button-group size="sm">
                            <b-button variant="outline-success"><i class="fa-solid fa-file-excel"></i> Exportar</b-button>
                            <b-button variant="outline-success" v-b-modal.modalSol><i class="fa-solid fa-list"></i> Solicitudes</b-button>
                            <b-button variant="outline-success" v-b-modal.modalNuevo><i class="fa-solid fa-plus"></i> Nuevo</b-button>
                        </b-button-group>

                    </b-col>
                </b-row>
                <b-card-text>
                    <div>

                        <b-row class="justify-content-md-center sm-3">
                            <b-col col-4>
                                <div class="input-group input-group-sm ">

                                    <input type="text" class="form-control">
                                    <b-button size="sm">
                                        <i class="fa-solid fa-magnifying-glass"> </i>
                                        Buscar
                                    </b-button>

                                </div>
                            </b-col>
                            <b-col></b-col>
                        </b-row>
                        <br />

                        <b-table outlined
                                 small
                                 hover
                                 fixed
                                 no-border-collapse
                                 :items="itemsPadron"
                                 :fields="fieldsPadron"
                                 head-variant="light">

                            <template #cell(acciones)>
                                <b-row class="">
                                    <b-button class="mx-1" size="sm" v-b-modal.modalNuevo variant="light"><i class="fa-solid fa-eye"></i></b-button>
                                    <b-button class="mx-1" size="sm" v-b-modal.modalNuevo variant="light"><i class="fa-solid fa-pen-to-square"></i></b-button>
                                </b-row>
                            </template>

                        </b-table>

                    </div>
                </b-card-text>
            </b-card-body>-->





        <!--</b-card>-->




        <b-modal id="modalSol" size="xl" title="Solicitudes" header-bg-variant="light" ok-only no-stacking>
            <b-row>

                <div class="col-3 ">
                    <div class="input-group input-group-sm ">

                        <input type="text" class="form-control">
                        <b-button size="sm">
                            <i class="fa-solid fa-magnifying-glass"> </i>
                            Buscar:
                        </b-button>

                    </div>
                </div>
            </b-row>
            <hr />
            <b-row>
                <b-card>
                    <b-table outlined
                             small
                             hover
                             fixed
                             no-border-collapse
                             :items="itemsSolicitud"
                             :fields="fieldsSolicitud"
                             head-variant="light">
                        <template #cell(acciones)>
                            <b-row class="">

                                <b-button class="mx-1" size="sm" v-b-modal.modalestaSol variant="light"><i class="fa-solid fa-pen-to-square"></i></b-button>
                            </b-row>
                        </template>
                    </b-table>
                </b-card>

            </b-row>

            <template #modal-footer="{ ok, cancel }">


                <b-button size="sm" variant="success" @click="ok()">
                    Guardar
                </b-button>
                <b-button size="sm" variant="danger" @click="cancel()">
                    Cancelar
                </b-button>


            </template>
        </b-modal>


        <b-modal id="modalestaSol" size="lg" title=" Estatus Solicitud" header-bg-variant="light" body-bg-variant="light">


            <b-card>
                <b-card-text>

                    <b-form-group label-cols="4" label-cols-lg="2" label="Id" label-for="input-default">
                        <b-form-input id="input-default"></b-form-input>
                    </b-form-group>
                    <b-form-group label-cols="4" label-cols-lg="2" label="Nombre del Directivo" label-for="input-default">
                        <b-form-input id="input-default"></b-form-input>
                    </b-form-group>



                    <b-form-group label-cols="4" label-cols-lg="2" label="Plaza" label-for="input-default">
                        <b-form-input id="input-default"></b-form-input>
                    </b-form-group>
                    <b-form-group label-cols="4" label-cols-lg="2" label="Tipo de Movimiento" label-for="input-default">
                        <b-form-input id="input-default"></b-form-input>
                    </b-form-group>



                    <b-form-group label-cols="4" label-cols-lg="2" label="Tipo de Movimiento" label-for="input-default">
                        <b-form-input id="input-default"></b-form-input>
                    </b-form-group>
                    <b-form-group label-cols="4" label-cols-lg="2" label="Fecha de soliciud" label-for="input-default">
                        <b-form-input id="input-default"></b-form-input>
                    </b-form-group>
                    <b-row class="mb-3">
                        <b-col cols="2"><p> Estatus: </p></b-col>
                        <b-col cols="3"><b-form-select v-model="selectedEsta" :options="OptionsEstSol"></b-form-select></b-col>

                    </b-row>
                    <b-row class="mb-3">
                        <b-col sm="2">
                            <label for="textarea-large">Comentarios:</label>
                        </b-col>
                        <b-col sm="10">
                            <b-form-textarea id="textarea"
                                             v-model="comentarios"
                                             placeholder="..."
                                             rows="3"
                                             max-rows="6"></b-form-textarea>
                        </b-col>

                    </b-row>

                </b-card-text>

            </b-card>


            <template #modal-footer="{ ok, cancel }">


                <b-button size="sm" variant="success" @click="ok()">
                    Guardar
                </b-button>
                <b-button size="sm" variant="danger" @click="cancel()">
                    Cancelar
                </b-button>


            </template>


        </b-modal>

        <b-modal id="modalNuevo" size="xl" header-bg-variant="success" header-text-variant="light" body-bg-variant="light"
                 no-stacking>
            <ModalDirigentecom></ModalDirigentecom>
            <template #modal-footer="{ ok, cancel }">
                <b-button size="sm" variant="success" @click="ok()">
                    Guardar
                </b-button>
                <b-button size="sm" variant="danger" @click="cancel()">
                    Cancelar
                </b-button>
            </template>
        </b-modal>

    </div>




</template>
<script>
    import logoEncabezado from '@/components/Administracion/Home/compLogoEncabezado.vue'
    import DataTable from "@/components/PadronD/DataTable.vue";

        import { config } from "@/config/auth";


   
 

    export default {
        name: 'PadronView',
        components: {

            logoEncabezado,
            DataTable,
            


        },
        data() {
            return {

                
                mainProps: {
                    center: true,
                    fluidGrow: true,
                    blank: true,
                    blankColor: '#bbb',
                    width: 300,
                    height: 200,

                },
                fieldsPadron: [ 'nombre','noSocio','plaza','sucursal','organo', 'estatus',  'acciones'],
                itemsPadron: [
                    {  nombre: 'Luz María Arenas Rivera', noSocio: '1188788', plaza: 'Fresnillo',  sucursal: '317 Santa María', organo: 'CAP', estatus: 'Activo'   },
                    { nombre: 'Luz María Arenas Rivera', noSocio: '1188788', plaza: 'Fresnillo', sucursal: '317 Santa María', organo: 'CAP', estatus: 'Activo'   },
                ],
                acciones:1,
               
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
                estatusgeneral:'Activo',
                apaterno: "Montaño",
                amaterno: "Montaño",
                nombres: "Guadalupe",
                fecNaciomiento:"09/05/1976",
                edad:46,
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
                municipio:"coatzacoalcos",
                //formaciónacademica
                
                selectedItem: null,
                escolaroptions: [ ],
                optProfesion: [
                    { value: 1, text: 'Abogado' },
                    { value: 2, text: 'Arquitecto' },
                    { value: 3, text: 'Ingeniero' },
                    { value: 3, text: 'Maestro' },
                ],
                optClasificacion: [
                    { value: 1, text: 'Artistica' },
                    { value: 2, text: 'Ciencias' },
                    { value: 3, text: 'Ingenierías' },
                ],

                file1: null,
                file2: null,
                //formacion Dirigente
                nivelorga:"Coprosu",
                fecintegracion:"17/04/2022",
                cargoorgano:"Vocal",
                //modal solicitud
                fieldsSolicitud: ['id', 'NombreDirectivo', 'plaza', 'tipoMovimiento', 'fechaSolicitud', 'estatus','comentarios', 'acciones'],
                itemsSolicitud: [
                    { id: '1', NombreDirectivo: 'Luz María Arenas Rivera', plaza: 'Fresnillo', tipoMovimiento: '317 Santa María', fechaSolicitud: '15/05/2022', estatus: 'pendiente', comentarios:'observaciones',},
                    { id: '2', NombreDirectivo: 'Luz María Arenas Rivera', plaza: 'Fresnillo', tipoMovimiento: '317 Santa María', fechaSolicitud: '15/05/2022', estatus: 'pendiente', comentarios: '',},
                ],
                comentarios: '',
                OptionsEstSol: [
                    { value: 1, text: 'Aprobada' },
                    { value: 2, text: 'Observada' },
                ],
            }

            },
        computed: {
            formTitle() {
               return this.acciones === -1 ? "Nuevo Requerimiento" : "Editar";
            },
        },
        methods: {
            ObtenerEstatus() {
                fetch(config.auth.server_url_api + 'api/Catalogos/Test')
                    .then(res => res.json()).then(data => this.setResultMen(data))
                    .catch(error => {
                        //Swal.fire("Error", "Error al obtener informacion del servidor", "error");
                        console.error('Error:', error)
                    });

            },
            setResultMen(data) {
                this.arregloMen = data;
                //console.log('arrgloMendata:', data)
                // eslint-disable-next-line
                const { id, tex } = this.arregloMen // eslint-disable-line no-use-before-define
                this.escolaroptions = this.arregloMen
                console.log('Objetoescolar', this.escolaroptions)
                }
        },

       // created() {
           
         //   this.ObtenerEstatus()
        //}


        }


       






    </script>
<style scoped >
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