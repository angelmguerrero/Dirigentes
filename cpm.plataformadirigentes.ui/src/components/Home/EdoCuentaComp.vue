

<template>
    <div class="container">
      <div class="container p-4" ></div>
        <div>
            <img src='@/assets/cpm/fondoshort.jpg' style=" width: 150%; height: 100%;">
        </div>
            <div class="container p-4 body">
                <div>
                    <a class="logo"> <img src='@/assets/cpm/cpm-logo.png' style="margin-left:10px;"></a>
                </div>
                <div class="col-12 p-1">
                    <div class="row">
                        <div class="col-9">
                        </div>
                        <div class="col-3">
                            <div class="input-group input-group-sm mb-3 col-6">
                                <span class="input-group-text" id="inputGroup-sizing-sm"> id </span>
                                <input type="text" class="form-control" v-model="id"
                                       placeholder="Consultar Estado de cuenta :"
                                       aria-describedby="inputGroup-sizing-sm">
                                <b-button style="margin-right:10px;" @click="buscarEdoCuenta">
                                    <i class="fa-solid fa-magnifying-glass"> </i>
                                    Buscar
                                </b-button>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-1">
                            <p class="texto-vertical-2" style='text-align:left; font-weight:bolder;'>00017620 </p>
                        </div>
                        <div class="col-5">
                            <table class=" table table-hover table-responsive" style='text-align:left; font-weight:bolder;'>

                                <tr> <td>{{nombre}}</td></tr>
                                <tr><td>{{calle}}</td></tr>
                                <tr><td>{{colonia}}</td></tr>
                                <tr><td>{{ciudad}}</td></tr>
                                <tr>
                                    <td>CP. {{cp}}  CM: {{cm}}</td>

                                </tr>
                                <!-- <input v-model="barcodeValue" /><br>-->
                                <barcode :value="barcodeValue" style='text-align:left;'>
                                   
                                </barcode>
                            </table>
                        </div>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-3">
                                    <b-card overlay
                                            class="img-fluid"
                                            :img-src="cover"
                                            img-alt="Image"
                                            img-top>
                                    </b-card>
                                </div>
                                <div class=" col-6 ">
                                    <p style="text-align:left; font-size:xx-large;">Estado de Cuenta </p>
                                    <p style="text-align:left; font-size:x-large;">Tarjeta de Crédito</p>
                                    <p style="text-align:left; font-size:large;">Clásica</p>
                                    <table class="table">
                                        <tr>
                                            <th scope="col" class="m-2 p-1" style="background-color:black">  </th>
                                            <th scope="col" class="m-2 p-1" style="background-color:darkslategrey">  </th>
                                            <th scope="col" class="m-2 p-1" style="background-color:dimgrey">  </th>
                                            <th scope="col" class="m-2 p-1" style="background-color:grey">  </th>
                                            <th scope="col" class="m-2 p-1" style="background-color:lightgray">  </th>
                                        </tr>

                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row ">
                        <div class="col-6">
                            <b-overlay rounded="true" style="max-width: 450px;">
                                <b-container fluid>
                                    <b-card class=" grid">
                                        <table class=" table table-hover table-responsive" style='text-align:left; font-weight:bolder'>
                                            <tr>Numero  de Tarjeta: <td>{{noTarjeta}}</td></tr>
                                            <tr>Numero de Cuenta:   <td>{{noCuenta}}</td></tr>
                                            <tr>Fecha de Corte:     <td>{{fechaCorte}}</td></tr>
                                            <tr>Fecha de Limite:    <td>{{fechaLimite}}</td></tr>
                                        </table>
                                    </b-card>
                                </b-container>
                            </b-overlay>
                        </div>
                        <div class="col-6 " style='text-align:justify;'>
                            <table rounded="true" class="table table-responsive table-borderless ">
                                <thead>
                                    <tr class="p-2 " style='text-align:left; font-weight:bold; color:white; background-color:#009432; '>
                                        <td>PAGO MINIMO REQUERIDO</td>
                                        <td>{{minimo}}</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr class="p-2" style='text-align:left; font-weight:bold; color:black; background-color:#ecf0f1'>
                                        <td class="">PAGO MÍNIMO + MESES SIN INTERESES</td>
                                        <td class="">{{noIntereses}}</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr class="p-2 " style='text-align:left; font-weight:bold; color:white; background-color:#009432; '>
                                        <td> PAGO PARA NO GENERAR INTERESES: </td>
                                        <td> {{noIntereses}}</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr class="p-2" style='text-align:left; font-weight:bold; color:black; background-color:#ecf0f1'>
                                        <td>  LIMITE DE CRÉDITO:</td>
                                        <td class="m-3"> {{limiteCredito}}</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr class="p-2 " style='text-align:left; font-weight:bold; color:white; background-color:#009432; '>
                                        <td>CRÉDITO DISPONIBLE: </td>
                                        <td class="m-3"> {{disponible}}</td>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
                <br />

                <table class="table caption-top table-striped-  table-hover table-checkable text-center tableB " id="kt_table_2">
                    <caption style="text-align:center; font-weight:bold; background-color:#009432; color:white">Nivel de Uso</caption>
                    <thead>

                        <tr style="background-color:#ecf0f1;">
                            <th class="">Saldo Anterior</th>
                            <th class="">Saldo Vencido</th>
                            <th class="">Compras/Disponibles</th>
                            <th class="">Comisiones Cobradas</th>
                            <th class="">Intereses Cobrados</th>
                            <th class="">Iva</th>
                            <th class="">Pagos/ Rembolsos</th>
                            <th class="">Saldo Actual al Corte</th>
                            <th class="">Saldo Pagos Diferidos</th>
                            <th class="">Saldo Total</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <!-- Recorremos nuestro array -->
                            <td class=""> {{saldoAnterior }}</td>
                            <td class=""> {{saldoVencido  }}</td>
                            <td class=""> {{comprasDisposiciones}}</td>
                            <td class=""> {{comisionesCobradas}}</td>
                            <td class=""> {{interesesCargados}}</td>
                            <td class=""> {{iva}}</td>
                            <td class=""> {{pagos}}</td>
                            <td class=""> {{saldoActualCorte }}</td>
                            <td class=""> {{saldoPagoDiferido}}</td>
                            <td class=""> {{saldoTotal}}</td>

                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <div class="col-12">
                    <div class="row">
                        <div class="col-6">

                            <b-table-simple hover small caption-top responsive class="text-lg-start tableB">

                                <b-thead style="background-color:#7f8c8d;">
                                    <b-tr>
                                        <b-th>Tasa de Interés</b-th>
                                        <b-th>Mensual</b-th>
                                        <b-th>Anual</b-th>
                                    </b-tr>
                                </b-thead>
                                <b-tbody>
                                    <b-tr v-for="it in items1" :key="it.id">
                                        <b-td>{{it.TasaInteres}}</b-td>
                                        <b-td>{{it.Mensual}}</b-td>
                                        <b-td>{{it.Anual}}</b-td>
                                    </b-tr>
                                </b-tbody>
                                <br />
                                <br />
                                <br />

                                <b-tfoot>

                                    <b-tr><b-td colspan="2">Saldo a favor :</b-td> <b-td>{{ disponible}}</b-td></b-tr>
                                    <b-tr><b-td colspan="2">Tasa de saldo a favor: </b-td> <b-td>{{ limiteCredito}}</b-td></b-tr>
                                    <b-tr><b-td colspan="2">Rendimiento:</b-td> <b-td>{{ interesesCargados}}</b-td></b-tr>
                                    <b-tr style="background-color:#b2bec3;"><b-td colspan="2">Saldo promedio diario:</b-td> <b-td>{{ comprasDisposiciones}}</b-td></b-tr>


                                </b-tfoot>

                            </b-table-simple>

                        </div>
                        <div class="col-6">
                            <div class="row">
                                <div class="col-6 p-1">
                                    <table border="1" class="table table-striped- table-bordered table-hover table-checkable text-center" id="kt_table_2">
                                        <tbody>
                                            <tr><td style="background-color:yellow;"></td><td>Credito Disponible:</td> <td>{{ disponible}}</td></tr>
                                            <tr><td style="background-color:forestgreen;"></td><td>Limite de Crédito: </td> <td>{{ limiteCredito}}</td></tr>
                                            <tr><td style="background-color:deepskyblue;"></td><td>Intereses cobrados:</td> <td>{{ interesesCargados}}</td></tr>
                                            <tr><td style="background-color:lightgreen;"></td><td>Compras / disposiciones:</td> <td>{{ comprasDisposiciones}}</td></tr>
                                        </tbody>
                                    </table>

                                </div>
                                <div class="col-5">
                                    <b-progress :value="25" variant="success" striped :animated="animate"></b-progress>
                                    <b-progress :value="50" variant="info" striped :animated="animate" class="mt-2"></b-progress>
                                    <b-progress :value="75" variant="warning" striped :animated="animate" class="mt-2"></b-progress>
                                    <b-progress :value="100" variant="danger" :animated="animate" class="mt-3"></b-progress>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-3">
                                    <b-card overlay
                                            class="img-fluid"
                                            :img-src="puntosVerdes"
                                            img-alt="Image"
                                            img-top
                                            style="max-width: 120px;">
                                    </b-card>
                                </div>
                                <div class="col-9">
                                    <table border="1" class=" col-6 table table-striped- table-bordered table-hover table-checkable text-center m-1 p-2" id="kt_table_2">
                                        <tbody>
                                            <tr><td style="background-color:green;">Saldo en Puntos Verdes:</td><td style="background-color:lightgreen;">Puntos por vencer</td></tr>
                                            <tr><td style="background-color:green;">{{puntosVerde}}</td><td style="background-color:lightgreen;">{{puntosVencer}}</td></tr>
                                            <tr>
                                                <td style="background-color:lightgrey;" colspan="2">
                                                    Calculados al 31 de Mayo de 2020
                                                    Para canjear tus puntos visite el
                                                    catalogo de premios en www.puntosverdes.mx
                                                    o llame al 800 7100 800
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <b-table :items="arreglo2" striped hover class="tableB">
                    <template #thead-top>
                        <b-tr>
                            <b-th style="background-color:#009432;
                            border-radius: 4px; border-spacing: 0;">
                                Detalle de operaciones
                            </b-th>
                        </b-tr>
                    </template>

                </b-table>
                <b-table :items="arreglo2" striped hover class="tableB">
                    <template #thead-top>
                        <b-tr>
                            <b-th style="background-color:#009432;
                            border-radius: 4px; border-spacing: 0;">
                                Mensualidades sin intereses
                            </b-th>
                        </b-tr>
                    </template>

                </b-table>
                <div class="row">
                    <div class="col-6">

                        *El tiempo necesario para liquidar su saldo deudor
                        realizando solo el pago mínimo es 1 mes. Bajo el supuesto
                        de que no se efectúen consumos o compras adicionales.
                    </div>
                    <div class="col-6">
                        El monto para pagar su saldo deudor si se encuentra al día en
                        sus pagos es 12 meses de $ 212.08. No considera compras,
                        intereses, disposiciones ni comisiones posteriores a la presente
                        fecha de corte.
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
            </div>
            <div class="container m-2">
                <b-card overlay
                        class="img-fluid"
                        :img-src="logo"
                        img-alt="Image"
                        img-top
                        style="max-width: 120px;">
                </b-card>
                <br />
                <br />
                <table border="1" class=" table table-borderless text-start m-1 p-2">
                    <tbody>
                        <tr>
                            <td> Expedido en: {{ciudad}} {{cm}} a {{fulldate}} </td>
                        <tr>
                            <td colspan="1">Folio Fiscal: {{folioFiscal}}</td>
                            <td colspan="1" style='font-weight:bolder'>No. De Serie del Certificado del CSD:{{}}</td>
                        </tr>
                        <tr>
                            <td style='font-weight:bolder'>Tipo de Comprobante: {{ tipoComprobante}}</td>
                            <td>Forma de Pago: {{formaPago}}</td>
                        </tr>
                        <tr>
                            <td style='font-weight:bolder'>No. De Serie del Certificado del SAT :{{ serieCertificado}}</td>
                            <td>Fecha y hora de certificación: {{today}}</td>
                        </tr>
                        <tr>
                            <td> Sello Digital del CFDI: {{selloDig}}</td>
                        </tr>
                        <tr>
                            <td> Sello del SAT:: {{selloSat}}</td>
                        </tr>
                        <tr>
                            <td>
                                Este documento es una representación impresa de un CFDI
                                Ponemos a su disposición el archivo XML correspondiente a este
                                documento a través de su sucursal
                            </td>

                        </tr>

                    </tbody>
                </table>
                <br />
                <div class="container m-2 p-2">
                    <img src='@/assets/cpm/spei.jpg'>
                </div>
                <br />
                <br />
                <b-card overlay
                        class="img-fluid"
                        :img-src="logo"
                        img-alt="Image"
                        img-top
                        style="max-width: 120px;">
                </b-card>
                <label class="form-label mb-5 text-success text-center" style='font-weight:bolder; font-size:x-large'>Primer apatado</label>
                <br />
                <b-container fluid class="text-start">
                    <form>

                        <label class="form-label mb-3" style='font-weight:bolder; text-align:left; '> Sección A</label>

                        <b-form-textarea class="form-floating mb-3"
                                         id="textare1C"
                                         v-model="secciona"
                                         placeholder="Ejem. Días del Periodo: 63 días
                                                * La Tasa Anual es antes de impuestos
                                                *** CAT (Costo Anual Total) sin IVA para fines informativos y de comparación REFENCIA DE"
                                         rows="3"
                                         max-rows="6"
                                         :disabled="active">


                        </b-form-textarea>

                        <br />
                        <label class="form-label mb-3" style='font-weight:bolder; text-align:left; '> Sección B</label>

                        <b-form-textarea class="form-floating mb-3"
                                         id="textare1C"
                                         v-model="seccionb"
                                         placeholder="Primer Apatado Sección B"
                                         rows="3"
                                         max-rows="6"
                                         :disabled="active">
                        </b-form-textarea>
                        <label class="form-label mb-3" style='font-weight:bolder; text-align:left; '> Sección C</label>

                        <b-form-textarea class="form-floating mb-3"
                                         id="textare1C"
                                         v-model="seccionc"
                                         placeholder="Primer Apatado Sección C"
                                         rows="3"
                                         max-rows="6"
                                         :disabled="active">
                        </b-form-textarea>
                    </form>
                </b-container>
                <b-container>
                    <label class="form-label mb-5 text-success text-center" style='font-weight:bolder; font-size:x-large'>Segundo Apartado</label>
                    <br />
                    <b-form-textarea class="form-floating mb-3"
                                     id="textare1C"
                                     v-model="apartadoB"
                                     placeholder=" Segundo Apatado "
                                     rows="3"
                                     max-rows="6"
                                     :disabled="active">
                    </b-form-textarea>

                    <b-button type="button" class="btn btn-success m-2" @click="activeApart">Editar</b-button>
                    <button type="button" class="btn btn-success m-2" @click="ActualizaApart">Guardar</button>


                </b-container>
            </div>
        
    </div>


</template>
<script>
  
    import img from "../assets/cpm/TDClasi.jpg"
    import img2 from "../assets/cpm/puntosVerdes.jpg"
    import img3 from "../assets/cpm/cpm-logo.png"
   // import CurrencyInput from './CurrencyInput'
    import VueBarcode from 'vue-barcode';
    import swal from 'sweetalert';

    export default {
        
        components: {

     //       CurrencyInput,
           'barcode': VueBarcode,

        },
        data() {
            return {

               // dataserver: AppConfiguration.Setting().ApplicationSettings.DataServer,
                cover: img,
                puntosVerdes: img2,
                logo:img3,
                //nombre: 'J MARCOS PEREZ QUINTANA',
                calle: '',
                colonia: '',
                ciudad:'',
                cp: '',
                cm:'GTO',
                noTarjeta: '',
                noCuenta:  '',
                fechaCorte:    '',
                fechaLimite:   '',
                fecEdoC: '',
                minimo:    '',
                pagoMinSI: '',
                noIntereses: '',
                limiteCredito: '',
                disponible: '',

                saldoAnterior :'',
                saldoVencido :'',
                comprasDisposiciones :'',
                comisionesCobradas :'',
                interesesCargados :'',
                iva :'',
                pagos:'',
                saldoActualCorte :'',
                saldoPagoDiferido :'',
                saldoTotal :'',

                barcodeValue: '1PTV000421934260001762',
                id: '',
                nombre: '',



                fields1: [
                    {
                        key: 'TasaInteres',
                        label: 'Tasa de Interés',
                        sortable: true,


                    },
                    {
                        key: 'Mensual',
                        label: 'Mensual ',
                        sortable: true,


                    },
                    {
                        key: 'Anual',
                        label: 'Anual ',
                        sortable: true,


                    },

                ],

                items1: [
                    { id:1, TasaInteres: 'Ordinaria', Mensual: '40.75%', Anual: '' },
                    { id: 2, TasaInteres: 'Moratoria', Mensual: '40.75%', Anual: '',},
                    { id: 3, TasaInteres: 'Cat', Mensual: '40.75%', Anual: '0.41%', },
                    { id: 4, TasaInteres: 'Cat', Mensual: '40.75%', Anual: '0.41%',},


                ],


                animate: true,
                active: true,

                Fecha: '',
                Descripcion : '',
                MontoMonedaExt: '',
                TipoCambio: '',
                SignoMonedaLocal: '',
                SimboloMonedaLocal: '',
                MontoMonedaLocal: ' ',
                arreglo2: [],
                arregloMen: [],
                FechaMen:'',
                DescipcionMen:'',
                MontoOriginal:'',
                MensualidadRestantes:'',
                SaldoPendiente: '',
                puntosVerde: '1,250',
                puntosVencer: '900',
                today: '',
                fulldate: '',
                folioFiscal: '6646DE94-EAAB-4F31-A41A-9C4332714981',
                tipoComprobante: 'Ingreso',
                formaPago: 'Una sola exhibición',
                serieCertificado: '00001000000505619865',
                selloDig: 'N8nDW6AmXMFU/yEzW3t2bHF502AJRytk47fIYH6mzWie55omf0',
                selloSat: 'N8nDW6AmXMFU/yEzW3t2bHF502AJRytk47fIYH6mzWie55omf0j',
                secciona: '',
                seccionb: '',
                seccionc: '',
                id_apartado:1,
                estatus: 1,
                apartadoB:'',





            }
        },
        methods: {



            Calcular: function () {








            },

            buscarEdoCuenta() {
                var init = {
                    method: 'get',
                    headers: {
                        'Content-Type': 'application/json'
                    }

                };
                let dato = this.id == null || this.id == '' ? 0 : this.id;
                //console.log('prov:', dato)
                fetch("api/EdoCuentas/EdoCuentas/" + dato, init)
                    .then(res => res.json())
                    .then(data => this.setResult(data))

                    .catch(error => {
                        //Swal.fire("Error", "Error al obtener informacion del servidor", "error");
                        console.error('Error:', error)
                    });

                this.buscarDetalleOp();
                this.buscarMensaualidad();
                //this.obtenerApartado();



            },
            setResult(data) {
                this.arreglo = data;
                //console.log('arrglo:', data)

                function humanizeNumber(n) {
                    n = n.toString()

                    return n
                }

                const formatter = new Intl.NumberFormat('es-MX', {
                    style: 'currency',
                    currency: 'MXN',
                    minimumFractionDigits: 2
                })


                if (this.arreglo.length == 1) {

                    this.id = this.arreglo[0].id;
                    this.nombre = this.arreglo[0].nombre;
                    this.calle = this.arreglo[0].calle;
                    this.colonia = this.arreglo[0].colonia;
                    this.ciudad = this.arreglo[0].ciudad;
                    this.cp = this.arreglo[0].cp;


                    this.noTarjeta = this.arreglo[0].noTarjeta;
                    this.noCuenta = this.arreglo[0].noCuenta;
                    this.fechaCorte = this.arreglo[0].fechaCorte;
                    this.fechaLimite = this.arreglo[0].fechaLimite;

                    this.minimo = humanizeNumber(formatter.format(this.arreglo[0].minimo.toFixed(4)));
                    this.noIntereses = humanizeNumber(formatter.format(this.arreglo[0].noIntereses.toFixed(4)));
                    this.limiteCredito = humanizeNumber(formatter.format(this.arreglo[0].limiteCredito.toFixed(4)));
                    this.disponible = humanizeNumber(formatter.format(this.arreglo[0].disponible.toFixed(4)));

                    this.saldoAnterior = humanizeNumber(formatter.format(this.arreglo[0].saldoAnterior.toFixed(4)));
                    this.saldoVencido = humanizeNumber(formatter.format(this.arreglo[0].saldoVencido.toFixed(4)));
                    this.comprasDisposiciones = humanizeNumber(formatter.format(this.arreglo[0].comprasDisposiciones.toFixed(4)));
                    this.comisionesCobradas = humanizeNumber(formatter.format(this.arreglo[0].comisionesCobradas.toFixed(4)));
                    this.interesesCargados = humanizeNumber(formatter.format(this.arreglo[0].interesesCargados.toFixed(4)));
                    this.comprasDisposiciones = humanizeNumber(formatter.format(this.arreglo[0].comprasDisposiciones.toFixed(4)));
                    this.iva = humanizeNumber(formatter.format(this.arreglo[0].iva.toFixed(4)));
                    this.pagos = humanizeNumber(formatter.format(this.arreglo[0].pagos.toFixed(4)));
                    this.saldoActualCorte = humanizeNumber(formatter.format(this.arreglo[0].saldoActualCorte.toFixed(4)));
                    this.saldoPagoDiferido = humanizeNumber(formatter.format(this.arreglo[0].saldoPagoDiferido.toFixed(4)));
                    this.saldoTotal = humanizeNumber(formatter.format(this.arreglo[0].saldoPagoDiferido.toFixed(4)));
                }


            },


            buscarDetalleOp() {

                var init = {
                    method: 'get',
                    headers: {
                        'Content-Type': 'application/json'
                    }

                };
                let dato = this.id == null || this.id == '' ? 0 : this.id;
                //console.log('detalle:', dato)
                fetch("api/DetalleEdoCuentas/DetalleEdoCuentas/" + dato, init)
                    .then(res => res.json())
                    .then(data => this.setResultDet(data))

                    .catch(error => {
                        //Swal.fire("Error", "Error al obtener informacion del servidor", "error");
                        console.error('Error:', error)
                    });

            },
            setResultDet(data) {
                this.arreglo2 = data;
                //console.log('arrglodetalle:', data)



                if (this.arreglo2.length == 1) {


                    this.Fecha = this.fechaFormato(this.arreglo2[0].Fecha);
                    this.Descripcion = this.arreglo2[0].Descripcion;
                    this.MontoMonedaExt = this.arreglo2[0].MontoMonedaExt;
                    this.TipoCambio = this.arreglo2[0].TipoCambio;
                    this.SignoMonedaLocal = this.arreglo2[0].noSignoMonedaLocalmbre;
                    this.SimboloMonedaLocal = this.arreglo2[0].SimboloMonedaLocal;
                    this.MontoMonedaLocal = this.arreglo2[0].MontoMonedaLocal;

                }

            },
            fechaFormato(fecha) {
                //console.log('hola ', fecha);
                let año = new Date(fecha).getFullYear();
                let mes = new Date(fecha).getMonth() + 1;
                let dia = new Date(fecha).getDate();

                mes = mes < 10 ? "0" + mes : mes;
                dia = dia < 10 ? "0" + dia : dia;

                //console.log('mes', mes)
                //console.log('dia', dia)

                let salida = año + '-' + mes + '-' + dia;
                //console.log('Sal', salida)
                return salida;

            },

            buscarMensaualidad() {

                var init = {
                    method: 'get',
                    headers: {
                        'Content-Type': 'application/json'
                    }

                };
                let dato = this.id == null || this.id == '' ? 0 : this.id;
                //console.log('MEN:', dato)
                fetch("api/MenEdoCta/MenEdoCta/" + dato, init)
                    .then(res => res.json())
                    .then(data => this.setResultMen(data))

                    .catch(error => {
                        //Swal.fire("Error", "Error al obtener informacion del servidor", "error");
                        console.error('Error:', error)
                    });

            },
            setResultMen(data) {
                this.arregloMen = data;
                console.log('arrgloMendata:', data)
                console.log('arrgloMen:', this.arregloMen)


                if (this.arregloMen.length == 1) {


                    this.FechaMen = this.arregloMen[0].fecha;
                    this.DescipcionMen = this.arregloMen[0].descipcion;
                    this.MontoOriginal = this.arregloMen[0].montoOriginal;
                    this.MensualidadRestantes = this.arregloMen[0].mensualidadRestantes;
                    this.SaldoPendiente = this.arregloMen[0].saldoPendiente;

                    //console.log('fecha', this.arregloMen[0].fecha)
                    //console.log('fecha', this.FechaMen)
                }

            },

            obtenerFechaActual() {
                let date = new Date();
                let hour = date.getHours() + " hrs";
                let min = date.getMinutes() + " min";
                let sec = date.getSeconds() + " sec";

                let output = String(date.getDate()).padStart(2, '0') + ' de ' + String(date.getMonth() + 1).padStart(2, '0') + ' del ' + date.getFullYear();
                //console.log('otherdate',output);
                //const [month, day, year] = [date.getMonth(), date.getDate(), date.getFullYear()];

                this.today = this.fechaFormato(date) + ' ' + hour + ' ' + min + ' ' + sec;
                this.fulldate = output;
                // console.log('fechaActual', date)
                //console.log('fechaorde', this.today)

            },

            obtenerApartado() {

                var init = {
                    method: 'get',
                    headers: {
                        'Content-Type': 'application/json'
                    }

                };
                let dato = this.id_apartado == null || this.id_apartado == '' ? 0 : this.id_apartado;

               // console.log('detalle:', this.id_apartado)
                fetch("api/Apartado/Apartado/" + dato, init)
                    .then(res => res.json())
                    .then(data => this.setResultApart(data))

                    .catch(error => {
                        //Swal.fire("Error", "Error al obtener informacion del servidor", "error");
                        console.error('Error:', error)
                    });

            },
            setResultApart(data) {
                this.arreglo3 = data;
               // console.log('arreglo3:', data)



                if (this.arreglo3.length == 1) {


                    this.secciona = this.arreglo3[0].secciona;
                    this.seccionb = this.arreglo3[0].seccionb;
                    this.seccionc = this.arreglo3[0].seccionc;
                    this.apartadoB = this.arreglo3[0].apartadoB;


                }
            },
            ActualizaApart() {
                var body = {

                    id_apartado: this.id_apartado,
                    secciona: this.secciona,
                    seccionb: this.seccionb,
                    seccionc: this.seccionc,
                    estatus: this.estatus == 1 ? true : false,
                    apartadoB: this.apartadoB,


                }
               //console.log('body',body)
                var init = {
                    method: 'PUT',
                    body: JSON.stringify(body),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                };

                fetch("api/Apartado/ActualizarApart", init)
                    .then(res => res.json())
                    .then(data => {
                        if (data > 0) {
                          //  console.log('Si se actualizo'),
                                this.AlertSav();

                        }
                    })
                    .catch(error => {
                        //Swal.fire("Error", "Error al obtener informacion del servidor", "error");
                        console.error('Error:', error)
                    });
                this.active = true;



            },

            activeApart() {
                this.active = false;

            },
             AlertSav() {
                 swal({
                     position: 'top-end',
                     icon: 'success',
                     title: 'Registro Guardado',
                     showConfirmButton: false,
                     timer: 1500
                      })
             },
        },

        mounted() {
            this.Calcular();
            this.obtenerFechaActual();
            this.obtenerApartado();
        }
    }

</script>




<style scoped>
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }

    .body {
        background-image: url('@/assets/cpm/fondofreem.jpg');
        background-size: 100%;
        height: auto;
        margin: auto;
        background-repeat: repeat;
        /*background-position: center;
        width: 100%;
        height: auto;
        margin: auto;*/
    }

    img {
        max-width: 100%;
        max-height: 100%;
    }


    .grid {
        background-color: #ecf0f1;
        width: 100%;
        height: 100%;
    }

    .contenedor1 {
        background-color: #ecf0f1;
        height: auto;
        width: auto;
        border-radius: 10px;
    }

    .contenedor2 {
        background-color: #009432;
        height: auto;
        width: auto;
        border-radius: 10px;
    }

    tr td {
        border-radius: 4px;
        border-spacing: 0;
    }

    .tableB {
        border-collapse: collapse;
        border-radius: 25px;
        box-shadow: inset 0 0 0 1px;
    }

    .texto-vertical-2 {
        writing-mode: vertical-lr;
        transform: rotate(180deg);
    }
</style>
