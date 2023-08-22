<template>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
        <b-form class="mt-auto" enctype="multipart/form-data" @submit.stop.prevent="handleSubmit(validaExistenciasolicitudByCif)">
            <b-container>
                <b-row>
                    <div class="col-sm-2"><h5>Filtro:</h5> </div>
                    <div class="col-sm-4">
                        <b-form-select v-model="selected" size="sm" :options="optionsfitro" v-on:change="onChangeFiltro">
                        </b-form-select>
                    </div>
                    <div class="col-4 ">
                        <div class="input-group input-group-sm ">
                            <b-button size="sm" @click="ValidarTipoBusqudad">
                                <i class="fa-solid fa-magnifying-glass"> </i>
                                Buscar
                            </b-button>
                        </div>
                    </div>
                    <b-col cols="2">
                        <div class="text-center" id="divSpinner" v-if="spinner">
                            <b-spinner variant="success" label="Spinning"></b-spinner>
                        </div>
                    </b-col>
                </b-row>
                <hr />
                <b-row>
                    <b-col cols="4">
                        <input type="text" v-model.trim="inputbusqueda" class="form-control" placeholder="Nombres / CIF / Cuenta Mexicana" trim>
                    </b-col>
                    <b-col cols="2">
                        <input type="text" v-model="inputbusquedaApellidoPaterno"
                               class="form-control"  v-if="selectNombre" placeholder="Apellido Paterno">
                    </b-col>
                    <b-col cols="2">
                        <input type="text" v-model="inputbusquedaApellidoMaterno"
                               class="form-control"  v-if="selectNombre" placeholder="Apellido Materno">
                    </b-col>
                </b-row>
                <b-row>

                    <b-col cols="8" v-if="usuariosMultiples">
                        <span class="label label-default">{{totalRegistros}} registros encontrados</span>
                        <b-form-group id="id_perfil"
                                      label="Personas encontradas por Nombre"
                                      label-for="cif" >
                            <b-form-select v-model="selectedUsuarioDirigente" v-on:change="onChangeUsuariosDirigentes">
                                <option v-for="optUsuarioDirigente in optUsuariosDirigentes" :key="optUsuarioDirigente.id" :value="optUsuarioDirigente.cif">
                                    Nombre: {{ optUsuarioDirigente.nombrePersona }}   {{ optUsuarioDirigente.apellidoPaterno }}   {{ optUsuarioDirigente.apellidoMaterno }}  Cif: {{ optUsuarioDirigente.cif }}  Plaza: {{ optUsuarioDirigente.plaza }}
                                </option>
                            </b-form-select>
                        </b-form-group>
                    </b-col>
                </b-row>
                <br/>
                <div v-if="resultadoBusqueda">
                    <b-card class="mb-2" header-bg-variant="light">
                        <b-card-body>
                            <b-row>

                                <b-card-sub-title class="mb-2 p-1">
                                    <h5>Datos Generales :</h5>
                                </b-card-sub-title>
                            </b-row>
                            <hr />
                            <b-card-text>
                                <!--<b-row align-h="center" class="mb-3">
                <b-form-checkbox id="checkbox-1"
                                 v-model="persona.dirigente"
                                 name="checkbox-1"
                                 value="true"
                                 unchecked-value="not_accepted">
                    Dirigente
                </b-form-checkbox>-->
                                <!--<div>State: <strong>{{ persona.dirigente }}</strong></div>-->
                                <!--</b-row>-->
                                <b-row class="mb-3">

                                    <b-col cols="4" v-if="persona.estatusPersona"><B s>Estatus: <span style="color:dimgray"> {{estatusPersona}}</span></B></b-col>
                                    <b-col cols="4"><B>CIF: <span style="color:dimgray"> {{persona.cif}}</span></B></b-col>
                                    <b-col cols="4">
                                        <b-form-group id="IdDirigente"
                                                      label="IdDirigente"
                                                      label-for="idDirigente">

                                            <b-form-input id="IdDirigente"
                                                          type="text"
                                                          v-model="persona.idDirigente"
                                                          trim></b-form-input>
                                        </b-form-group>
                                    </b-col>

                                </b-row>
                                <b-row class="mb-3">
                                    <b-col cols="4"><B s>Ap. Paterno: <span style="color:dimgray"> {{persona.apellidoPaterno}}</span></B></b-col>
                                    <b-col cols="4"><B>Ap. Materno: <span style="color:dimgray"> {{ persona.apellidoMaterno}}</span></B></b-col>
                                    <b-col cols="4"><B>Nombres: <span style="color:dimgray"> {{persona.nombrePersona}}</span></B></b-col>
                                </b-row>
                                <b-row class="mb-3">
                                    <b-col cols="4"><B s>Fec. Nacimiento: <span style="color:dimgray"> {{ persona.fechaNacimiento}}</span></B></b-col>
                                    <b-col cols="4"><B>Edad: <span style="color:dimgray"> {{persona.edad}}</span></B></b-col>
                                    <b-col cols="4"><B>RFC: <span style="color:dimgray"> {{persona.rfc }}</span></B></b-col>
                                </b-row>
                                <b-row class="mb-3">
                                    <b-col cols="4"><B s>Curp: <span style="color:dimgray"> {{persona.curp}}</span></B></b-col>

                                </b-row>

                                <b-row class="mb-3">
                                    <b-col cols="4 "><B>Plaza: <span style="color:dimgray"> {{persona.plaza}}</span></B></b-col>
                                    <b-col cols="4"><B>Sucursal: <span style="color:dimgray"> {{persona.sucursal }}</span></B></b-col>
                                    <b-col cols="4"><B>Fec. Ingreso: <span style="color:dimgray"> {{persona.fechaIngreso}}</span></B></b-col>
                                </b-row>

                                <b-row class="mb-3">
                                    <b-col cols="4"><B s>Genero: <span style="color:dimgray"> {{persona.genero}}</span></B></b-col>
                                    <b-col cols="4"><B>Edo. Civil: <span style="color:dimgray"> {{persona.estadoCivil}}</span></B></b-col>
                                    <validation-provider name="Participación"
                                                     :rules="{ required: true }"
                                                     v-slot="validationContext">
                                    Participación:
                                    <b-form-select v-model="selectedparticipacion"
                                                   :state="getValidationState(validationContext)"
                                                   aria-describedby="input-1-live-feedback">
                                        <option v-for="optionsparticipacion in optionsparticipacions" :key="optionsparticipacion.id" :value="optionsparticipacion.descripcion">
                                            {{ optionsparticipacion.descripcion }}
                                        </option>
                                    </b-form-select>
                                    <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                                </validation-provider>
                                 <!-- <Selected>option: {{ selectedparticipacion }}</Selected> -->
                                </b-row>
                                <b-row class="mb-3">
                                    <b-col cols="4"><B s>Email: <span style="color:dimgray"> {{persona.correoAcceso}}</span></B></b-col>
                                    <b-col cols="4"><B>N&uacute;mero de tel&eacute;fono : <span style="color:dimgray"> {{persona.celular}}</span></B></b-col>
                                </b-row>


                            </b-card-text>
                        </b-card-body>
                    </b-card>


                    <b-card class="mb-2" header-bg-variant="light">
                        <b-card-body>
                            <b-card-body>
                                <b-row>
                                    <b-card-sub-title class="mb-2 p-1">
                                        <h5>Informaci&oacute;n Direcci&oacute;n:</h5>
                                    </b-card-sub-title>
                                </b-row>
                                <loading-overlay :active='isLoading' color='#008000' />
                                <!-- <b-row class="justify-content-md-center"> -->
                                    <!-- <b-col col lg="2"></b-col> -->
                                    <!-- <b-col cols="12" md="auto"> -->
                                        <!-- <div class="text-center" style="position:absolute;" v-if="spinnerGuardar"> -->
                                            <!-- <b-spinner style="width: 6rem; height: 6rem;" variant="success" label="Spinner"></b-spinner> -->
                                            <!-- <b-spinner  variant="success" label="Spinner"></b-spinner> -->
                                        <!-- </div> -->
                                    <!-- </b-col> -->
                                    <!-- <b-col col lg="2"></b-col> -->
                                <!-- </b-row> -->
                                <hr />
                                <b-card-text>
                                    <b-row class="mb-3">
                                        <b-col cols="4"><B s>Calle: <span style="color:dimgray"> {{persona.calle}}</span></B></b-col>
                                        <b-col cols="4"><B>N&uacute;mero: <span style="color:dimgray"> {{persona.numeroInterior}}</span></B></b-col>
                                        <b-col cols="4"><B>CP:  <span style="color:dimgray"> {{persona.codigoPostal}}</span></B></b-col>
                                    </b-row>
                                    <b-row class="mb-3">
                                        <b-col cols="4"><B>Colonia:  <span style="color:dimgray"> {{persona.colonia}}</span></B></b-col>
                                        <b-col cols="4"><B>Estado:  <span style="color:dimgray"> {{persona.estado}}</span></B></b-col>
                                        <b-col cols="4"><B s>Municipio : <span style="color:dimgray"> {{ persona.municipio }}</span></B></b-col>
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
                                        <h5>Formaci&oacute;n Acad&eacute;mica:</h5>
                                    </b-card-sub-title>
                                </b-row>
                                <hr />
                                <b-card-text>
                                    <b-row class="mb-3">
                                        <b-col cols="3"><b> Escolaridad: </b></b-col>
                                        <b-col cols="3">
                                            <validation-provider name="Escolaridad"
                                                                 :rules="{ required: true}"
                                                                 v-slot="validationContext">
                                                <b-form-select v-model="selectedescolar"
                                                               :state="getValidationState(validationContext)"
                                                               aria-describedby="input-1-live-feedback"
                                                               trim>
                                                    <option v-for="escolaroption in escolaroptions" :key="escolaroption.value" :value="escolaroption.value">
                                                        {{ escolaroption.text }}
                                                    </option>
                                                </b-form-select>
                                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                                            </validation-provider>

                                            <!-- Selected option: {{ selectedescolar }}-->
                                        </b-col>
                                        <b-col cols="3"><b> Profesi&oacute;n: </b></b-col>
                                        <b-col cols="3">
                                            <validation-provider name="Profesion"
                                                                 :rules="{ required: true}"
                                                                 v-slot="validationContext">
                                                <b-form-select v-model="selectedProfesion" v-on:change="onChangeClasificacion"
                                                               :state="getValidationState(validationContext)"
                                                               aria-describedby="input-1-live-feedback"
                                                               trim>
                                                    <option v-for="optProfesion in optProfesiones" :key="optProfesion.id"
                                                            :value="optProfesion.idProfesion">
                                                        {{ optProfesion.descripcion }}
                                                    </option>
                                                </b-form-select>
                                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                                            </validation-provider>
                                            <!--<Selected> option: {{ selecteClasificacion }} </Selected>-->
                                        </b-col>
                                    </b-row>
                                    <!--<b-row>
                        <b-col cols="6">
                            <b-form-group id="clasificacion_"
                                          label-for="Clasificacion"
                                          class="mb-3">
                                <b> Clasificaci&oacute;n: </b>
                                <b-form-input id="clasificacion"
                                              type="text"
                                              v-model="optClasificaciones.descripcionClasif" disabled></b-form-input>
                            </b-form-group>
                        </b-col>
                    </b-row>-->
                                    <b-row class="mb-3">
                                        <b-col cols="3"><b> Clasificacion: </b></b-col>
                                        <b-col cols="3">
                                            <b-form-select v-model="selecteClasificacion" disabled>
                                                <option v-for="optClasificacion in optClasificaciones" :key="optClasificacion.id"
                                                        :value="optClasificacion.idProfesion">
                                                    {{ optClasificacion.descripcionClasif }}
                                                </option>
                                            </b-form-select>
                                            <!--<Selected> option: {{ selecteClasificacion }} </Selected>-->
                                        </b-col>

                                    </b-row>
                                    <!--<b-row class="mb-3">
                        <b-col cols="3"><b> Tipo persona: </b></b-col>
                        <b-col cols="3">
                            <b-form-select v-model="selectedTipoPersona">
                                <option v-for="optionsTipoPersona in optionsTiposPersona" :key="optionsTipoPersona.id" :value="optionsTipoPersona.idTipoPersona">
                                    {{ optionsTipoPersona.descripcion }}
                                </option>
                            </b-form-select>
                        </b-col>
                    </b-row>-->
                                    <b-row>
                                        <b-col cols="3"><b> Expediente Digital: </b></b-col>
                                        <b-col cols="3">
                                        <validation-provider name="Expediente"
                                            :rules="{ required: true}"
                                            v-slot="validationContext">
                                            <b-form-file name="file"
                                                         v-model="file"
                                                         placeholder="Expediente"
                                                         browse-text="Agregar"
                                                         drop-placeholder="Expediente"
                                                         v-on:change="getFile($event)"
                                                         accept=".zip"
                                                         :state="getValidationState(validationContext)"
                                                         trim></b-form-file>
                                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                                         </validation-provider>
                                        </b-col>
                                        <b-col cols="3"><b> Curriculum Vitae: </b></b-col>
                                        <b-col cols="3">
                                            <validation-provider name="Curriculum"
                                                :rules="{ required: true}"
                                                v-slot="validationContext">
                                            <b-form-file v-model="file2"
                                                         placeholder="Curriculum"
                                                         browse-text="Agregar"
                                                         drop-placeholder="Curriculum"
                                                         v-on:change="getFile2($event)"
                                                         accept=".pdf"
                                                         :state="getValidationState(validationContext)"
                                                         aria-describedby="El campo Profesion es obligatorio"></b-form-file>
                                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                                            </validation-provider>
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
                                        <h5>Formaci&oacute;n como Dirigente:</h5>
                                    </b-card-sub-title>
                                    <hr />
                                </b-row>
                                <hr/>
                                    <b-card-text>  
                                        <b-row class="mb-3">
                                            <b-col cols="3"><b> Nivel Dirigencial: </b></b-col>
                                            <b-col cols="3">
        <validation-provider name="Nivel Dirigencial"
                             :rules="{ required: true}"
                             v-slot="validationContext">
            <b-form-select v-model="selectedNivelDirigenciales"
                           :state="getValidationState(validationContext)"
                           aria-describedby="input-1-live-feedback"
                           trim>
                <option v-for="optionNivelDirigencial in optionNivelDirigenciales" 
                :key="optionNivelDirigencial.idNivelDirigencialCat" :value="optionNivelDirigencial.idNivelDirigencialCat">
                    {{ optionNivelDirigencial.descripcion }}
                </option>
            </b-form-select>
            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
        </validation-provider>
        <!-- Selected option: {{ selectedescolar }}-->
                                            </b-col>
                                            <b-col cols="3"><b> Periodo: </b></b-col>
                                            <b-col cols="3">
                                                <validation-provider name="Periodo"
                                                                     :rules="{ required: true}"
                                                                     v-slot="validationContext">
                                                    <b-form-select v-model="selectedPeriodo" 
                                                                   :state="getValidationState(validationContext)"
                                                                   aria-describedby="input-1-live-feedback"
                                                                   trim>
                                                        <option v-for="optPeriodo in optPeriodos" :key="optPeriodo.id"
                                                                :value="optPeriodo.id">
                                                            {{ optPeriodo.text }}
                                                        </option>
                                                    </b-form-select>
                                                    <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                                                </validation-provider>
                                                <!-- <Selected> option: {{ selectedPeriodo }} </Selected> -->
                                            </b-col>
                                        </b-row>
                                        <b-row>
                                            <b-col cols="3" class="mb-2"><b>Fecha de ingreso a nivel:</b></b-col>
                                            <b-col cols="3" class="mb-2">
                                                <validation-provider name="Fecha de ingreso a Nivel"
                                                    :rules="{ required: true}"
                                                    v-slot="validationContext">
                                                <b-form-datepicker v-model="FechaIngresoNivel" locale="es-MX"
                                                           placeholder="Selecciona una fecha"
                                                           :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"
                                                           :state="getValidationState(validationContext)"
                                                           >
                                                </b-form-datepicker>
                                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>    
                                            </validation-provider>
                                            </b-col>
                                            <b-col cols="3" class="mb-2"><b>Año del Periodo:</b></b-col>
                                            <b-col cols="3" class="mb-2">
                                                    <validation-provider name="Año del Periodo"
                                                                         :rules="{ required: true}"
                                                                         v-slot="validationContext">
                                                        <b-form-select v-model="selectedAnoPeriodo" 
                                                                       :state="getValidationState(validationContext)"
                                                                       aria-describedby="input-1-live-feedback"
                                                                       trim>
                                                            <option v-for="optAnoPeriodo in optAnoPeriodos" :key="optAnoPeriodo.id"
                                                                    :value="optAnoPeriodo.id">
                                                                {{ optAnoPeriodo.text }}
                                                            </option>
                                                        </b-form-select>
                                                        <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                                                    </validation-provider>
                                                    <!--<Selected> option: {{ selecteClasificacion }} </Selected>-->
                                            </b-col>        
                                        </b-row>
                                        <b-row>
                                            <b-col cols="3" class="mb-2"><b>Condici&oacute;n de Ingreso:</b></b-col>
                                            <b-col cols="3" class="mb-2">
                                                    <validation-provider name="Condición de Ingreso"
                                                                         :rules="{ required: true}"
                                                                         v-slot="validationContext">
                                                        <b-form-select v-model="selectedcondicoines" 
                                                                       :state="getValidationState(validationContext)"
                                                                       aria-describedby="input-1-live-feedback"
                                                                       trim>
                                                            <option v-for="optioncondicoin in optioncondicoines" :key="optioncondicoin.id"
                                                                    :value="optioncondicoin.idCondicion">
                                                                {{ optioncondicoin.condicionIngreso }}
                                                            </option>
                                                        </b-form-select>
                                                        <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                                                    </validation-provider>
                                                    <!--<Selected> option: {{ selecteClasificacion }} </Selected>-->
                                            </b-col>
                                            <b-col cols="3" class="mb-2"><b>Fin del periodo:</b></b-col>
                                            <b-col cols="3" class="mb-2">
                                                <validation-provider name="Fin del periodo"
                                                    :rules="{ required: true}"
                                                     v-slot="validationContext">
                                                <Datepicker
                                                format="yyyy"
                                                :language="language"
                                                minimum-view="year"              
                                                name="datepicker"
                                                value="finPeriodo"
                                                :state="getValidationState(validationContext)"
                                                v-model="finPeriodo"
                                                :required="getValidationState(validationContext)"></Datepicker>
                                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                                                </validation-provider> 
                                            </b-col>        
                                        </b-row>
                                        <b-row> 
                                            <b-col cols="3" class="mb-2"><b>Antig&#252;edad:</b><div>(días)</div></b-col>                                    
                                            <b-col cols="3" class="mb-2">
                                                <b-form-group>  
                                                <b-form-input id="antiguedad"
                                                      type="text"
                                                      v-model="antiguedad"
                                                      trim
                                                      disabled>
                                                </b-form-input>     
                                            </b-form-group>
                                            </b-col>
                                        </b-row>
                                    </b-card-text>
                                    <div v-if="Organotable">
                                        <br/>
                                        <b-table outlined
                                                 small
                                                 hover
                                                 fixed
                                                 id="my-table"
                                                 no-border-collapse
                                                 :per-page="perPage"
                                                 :items="items"
                                                 :fields="fields"
                                                 head-variant="light"
                                                 responsive="xl"
                                                 :filter="filter"
                                                 class="text-center">

                                            <template #cel(idCargoOrgano)="data">
                                                {{
        `${data.item.idCargoOrgano} ${data.item.persona} ${data.item.organo}${data.item.cargo}${data.item.suplente}
        ${data.item.firmante}${data.item.fechaNombramiento}${data.item.fechaActaDesignacion}${data.item.fechaInicial}${data.item.fechaFinal}
        ${data.item.fechaIngresoSocio}${data.item.necesario}${data.item.plaza}${data.item.nivelGestion}`
                                                }}
                                            </template>

                                            <template #cell(estatusCargoOrgano)="data">
                                                <b-icon-bookmark-check-fill variant="success"
                                                                            v-if="data.item.estatusCargoOrgano"></b-icon-bookmark-check-fill>
                                                <b-icon-bookmark-x-fill variant="danger"
                                                                        v-else></b-icon-bookmark-x-fill>
                                            </template>



                                            <template v-slot:cell(acciones)="data">
                                                <b-row>
                                                    <b-icon-pencil-square class="action-item mx-1"
                                                                          size="sm" variant="primary"
                                                                          @click="getRowData(data.item.idCargoOrgano)">
                                                    </b-icon-pencil-square>

                                                    <b-icon-trash-fill class="action-item mx-1"
                                                                       size="sm" variant="danger"
                                                                       @click="showDeleteModal(data.item.idCargoOrgano)">
                                                    </b-icon-trash-fill>
                                                </b-row>
                                            </template>
                                        </b-table>

                                    </div>
                                <div v-else>
                                    <h3>No tiene cargo asignado</h3>
                                </div>
                            </b-card-body>
                        </b-card-body>
                    </b-card>
                    <hr />
                    <b-row align-h="end" class="mt-4">
                        <b-col cols="mb-3 p-2">
                            <b-button variant="success" type="submit">Guardar</b-button>
                        </b-col>
                        <b-col cols="mb-3 p-2">
                            <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
                        </b-col>
                    </b-row>
                </div>            
            </b-container>
        </b-form>
    </validation-observer>
</template>

<script>
    import { config } from "@/config/auth";
    import store from '@/store'
    import { HTTP } from '@/plugins/axios'
    import Datepicker from 'vuejs-datepicker';

    export default {
        name: "CreateModal",

        components: {
            Datepicker
         },
        data() {
            return {
                registro: {},
                spinner: false,
                //spinnerGuardar: false,
                isLoading: false,
                //modal
                disabled: 1,
                selected: null,
                selectedUsuarioDirigente: null,
                optUsuariosDirigentes: [],
                inputbusqueda: null,
                inputbusquedaApellidoPaterno: null,
                inputbusquedaApellidoMaterno: null,
                valorBusqueda: '',
                registroNombreApellidos: {},
                optionsfitro: [
                    { value: 1, text: 'CIF' },
                    { value: 2, text: 'Nombre' },
                    { value: 3, text: 'Cuenta Mexicana' },

                ],
                selectedEsta: [
                    { value: 1, text: 'Selecciona una Opci�n' },
                    { value: 2, text: 'Activo' },
                    { value: 3, text: 'Inactivo' },
                ],
                selectedparticipacion:null,
                optionsparticipacions:[
                    {id:1, descripcion:"N/A" },  
                    {id:2, descripcion:"Ex-Colaborador" },
                    {id:3, descripcion:"Ex-Dirigente"}
                ],

                //datosGenerales
                dirigente: false,
                estatusgeneral: 1,
                persona: {},
                Organotable: false,
                selectedescolar: null,
                escolaroptions: [],
                selectedProfesion: null,
                optProfesiones: [],
                selecteClasificacion: null,
                optClasificaciones: [],
                selectedTipoPersona: null,
                optionsTiposPersona: [],
                fechaBaja: null,
                file: '',
                placeholder: "Expediente",
                file2: '',
                //formacion Dirigente
                nivelorga: "",
                fecintegracion: '',
                cargoorgano: " ",
                idEscolaridad: 0,
                fechaCreacion: '',
                //table cargo
                idpersonatable: null,
                fields: [
                    //{ key: 'idCargoOrgano', label: 'Id', sortable: true },
                    //{ key: 'persona', label: 'Nombre', sortable: true },
                    { key: 'descripcionOrgano', label: 'Organo', sortable: true },
                    { key: 'descripcionCargo', label: 'Cargo', sortable: true },
                    { key: 'fechaInicial', label: 'Fecha Inicia', sortable: true, formatter: "formatDate" },
                ],
                items: [],
                id: 0,
                tableHeader: "",
                perPage: 10,  //Numero de registros por pagina
                sortDesc: false,
                filter: null,
                showSuccessAlert: false,
                alertMessage: "",
                /*   currentPage: 1,*/
                //solicitud
                solicitudEstatus: 'Pendiente',
                responsable: [],
                solicitud: '',
                cifBusqueda: '',
                cif: '',
                //solicitudBusqueda:null,

                correoprueba: 'cynthiacervantes@gmail.com',
                permisoSolicitud: false,
                //'cynthiacervantes@gmail.com',
                correoDirigente: '',
                idPersonaSolicitante: '',
                plazaPersonaSolicitante: '',
                idPlazaSolicitante: '',
                personaAutorizada: '',
                esdirigenteSolAct: false,
                resultadoBusqueda: false,
                selectNombre : false,
                usuariosMultiples: false,
                totalRegistros: 0,
                solicituddata: null,
                //formacion como dirigente
                selectedcondicoines:null,
                optioncondicoines:[],
                selectedNivelDirigenciales:null,
                optionNivelDirigenciales:[],
                selectedPeriodo:null,
                optPeriodos:[{id:1, text:'Primero'}, {id:2, text:'Segundo'}],
                FechaIngresoNivel:'',
                selectedAnoPeriodo:null,
                optAnoPeriodos:[{id:1, text:1}, {id:2, text:2} , {id:3, text:3}],
                
                //datayear
                finPeriodo:null,
                language:{
                    language: 'es-MX', 
                    months: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'], 
                    monthsAbbr: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dec'], 
                    days: ['Domingo','Lunes', 'martes', 'miércoles', 'jueves', 'viernes', 'sábado,'], 
                    rtl: false, 
                    ymd: false, 
                    yearSuffix: ' Año'
                },
                fechaactual: null,
                antiguedad :null,

            }
        },
        computed: {

            estatusGnl() {
                return this.estatusgeneral === 1 ? 'Activo' : 'Inactivo'
            },


            estatusPersona() {
                return this.persona.estatusPersona === true ? 'Activo' : 'Inactivo'
            },

        },
        watch:{
            FechaIngresoNivel (value, olValue){
                console.log('fechaingresonivel',{value, olValue})
                //debugger
                if(value ==''|| value ==null) return;
                else{
                    
                    var getant = new Date(value).getTime()
                    console.log('Antiguedad', this.fechaactual, getant)
                    this.antiguedad  =Math.round((this.fechaactual - getant)/(1000*60*60*24)-1)

                    //console.log('Antiguedad', this.antiguedad)
                }                    
            } 
        },

        methods: {
            getValidationState({ dirty, validated, valid = null }) {
                return dirty || validated ? valid : null;
            },
            triggerClose() {
                this.$emit("closeCreateModal");
            },
            onChangeFiltro: function () {
                console.log('selected: ', this.selected)
                if (this.selected ==2)
                    this.selectNombre = true
                else 
                   this.selectNombre = false
            },
            onChangeUsuariosDirigentes: function () {
                //debugger
                console.log('changeusuariodirigente')

                console.log('select usu', this.selectedUsuarioDirigente)
                this.inputbusqueda = this.selectedUsuarioDirigente
                this.getByCIF();



                //this.ObtenerSocioCifNombreApellidos();
                // this.ObtenerSucursalbyIdPlazaParametro(this.selectedEsta)
            },

            //inicial
            ObtenerEscolaridad() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoEscolaridad/ObtenerEscolaridadActivo', { headers })
                    .then((response) => response.json())
                    .then((data) => {


                        this.escolaroptions = data;
                        //this.selectedescolar = this.escolaroptions;

                        console.log('escolaridad', this.escolaroptions)


                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            ObtenerProfesion() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoProfesion/ConsultarActivas', { headers })
                    .then((response) => response.json())
                    .then((data) => {


                        this.optProfesiones = data;
                        console.log('profesion', this.optProfesiones)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            onChangeClasificacion() {
                // console.log('hola', this.selectedProfesion)
                this.ObtenerClasificacion();
                this.selecteClasificacion = this.selectedProfesion
            },
            ObtenerClasificacion() {
                const requestOptions = {
                    method: 'PUT',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.selectedProfesion)
                }


                fetch(config.auth.server_url_api + 'api/CatalogoClasificacionProfesion/ObtenerClasificacionProfesionPorDescripcionbyid', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.optClasificaciones = data;
                        console.log('clasificacion', this.optClasificaciones)

                        //const [{  descripcionClasif  }] = descripcionClasif
                        //console.log('clasificaciondes', descripcionClasif)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            ObtenerTipoPersona() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoTipoPersona/Consultar', { headers })
                    .then((response) => response.json())
                    .then((data) => {

                        this.optionsTiposPersona = data;
                        //console.log('optionsTiposPersona', this.optionsTiposPersona)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            ObtenerEsODG() {
                //obtener correo usuario odg
                var correoDir = this.$store.getters['user/getCorreoDirigente'];
                this.correoDirigente = correoDir;
                console.log("correoDirigente:", this.correoDirigente)

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.correoDirigente)
                }
                console.log('correo', this.correoDirigente)

                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilPermisoSolicitudDirigencialbyCorreo', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.personaAutorizada = data;
                        console.log('personaAutorizada', this.personaAutorizada)



                        if (this.personaAutorizada == '' || this.personaAutorizada == null || this.personaAutorizada == 0) {
                            this.permisoSolicitud = false
                            console.log('No es odg', this.permisoSolicitud)
                        }
                        else {
                            this.permisoSolicitud = true
                            console.log('Usuario con permisos ODG', this.permisoSolicitud)
                        }

                    })
                    .catch(error => {
                        // this.MensajeError(error) //fechaActual(
                        console.log(error)
                        this.permisoSolicitud = false
                        console.log('No es odg', this.permisoSolicitud)

                    });

            },
            //validarbusqueda
            ValidarTipoBusqudad() {
                //1, text: 'CIF'
                //2, text: 'Nombre'
                //3, text: 'Cuenta mexicana'
               // debugger
                
                if (this.inputbusqueda != null && this.inputbusqueda != '' && this.selected != null && this.selected != '') {

                    if (this.selected == 1) {
                        //this.ObtenerSocioCif();
                        this.getByCIF();
                    }

                    if (this.selected == 2) {
                        //this.ObtenerSocioNombre();
                        this.ObtenerSocioNombreApellidos();
                    }

                    if (this.selected == 3) {
                        this.ObtenerSocioCuentaMexicana();
                    }

                }
                else {
                    this.$swal.fire({
                        text: 'Favor de capturar filtro y texto de busqueda.',
                        icon: 'warning',
                        confirmButtonText: 'Ok',

                    });
                }


            },
            ObtenerSocioNombreApellidos() {
                
                this.spinner = true
                if (this.inputbusqueda != null && this.inputbusqueda != '' && this.selected != null && this.selected != '') {
                    if (this.selected == 2) {
                        this.valorBusqueda = (this.inputbusquedaApellidoPaterno == null || this.inputbusquedaApellidoPaterno == '' ? '' : this.inputbusquedaApellidoPaterno) + ' ' + (this.inputbusquedaApellidoMaterno == null || this.inputbusquedaApellidoMaterno == '' ? '' : this.inputbusquedaApellidoMaterno) + ' ' + this.inputbusqueda
                        this.registroNombreApellidos.nombrePersona = this.inputbusqueda;
                        this.registroNombreApellidos.apellidoPaterno = (this.inputbusquedaApellidoPaterno == null || this.inputbusquedaApellidoPaterno == '' ? '' : this.inputbusquedaApellidoPaterno);
                        this.registroNombreApellidos.apellidoMaterno = (this.inputbusquedaApellidoMaterno == null || this.inputbusquedaApellidoMaterno == '' ? '' : this.inputbusquedaApellidoMaterno);


                    }
                    console.log('valorbusqueda', this.valorBusqueda)
                    console.log('this.inputbusqueda: ', this.inputbusqueda)
                    console.log('this.registroNombreApellidos: ', this.registroNombreApellidos)

                    const requestOptions = {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                        body: JSON.stringify(this.registroNombreApellidos)
                    };
                    fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilbyNombreApellidoPadron', requestOptions)
                        .then((response) => response.json())
                        .then((data) => {
                            
                            console.log('Data', data)
                           
                            if (data.length == 0)
                                return this.MensajeInfo(this.$messageConstants('usuarioNoEncontrado'));

                            if (data.length == 1) {
                                for (var i = 0; i < data.length; i++) {

                                    var [dataApellido] = data
                                    console.log('datafor', dataApellido.plazaId)
                                    //
                                    if (this.idPlazaSolicitante == dataApellido.plazaId) {
                                        this.resultadoBusqueda = true
                                        console.log('Esde la plaza', data.plazaId,)
                                        this.persona = dataApellido


                                        this.persona.fechaNacimiento = this.fechaFormato(this.persona.fechaNacimiento);
                                        this.persona.fechaIngreso = this.fechaFormato(this.persona.fechaIngreso);

                                        //this.selectedescolar = this.persona.idEscolaridad
                                        //this.selectedProfesion = this.persona.idProfesion
                                        //this.selecteClasificacion = this.persona.idProfesion
                                        this.selectedTipoPersona = this.persona.idTipoPersona
                                        this.cif = this.persona.cif
                                        //obtenerformaci�n como dirigente
                                        this.idpersonatable = this.persona.idPersona;
                                        this.getDataByID();
                                        this.ObtenerRepresentantePlaza();
                                    }
                                    else {
                                        this.MensajeError('Solo se tiene acceso a socios de su plaza')
                                        this.spinner = false
                                    }


                                }
                                //this.optUsuariosDirigentes = data;
                                //console.log(' this.optUsuariosDirigentes: ', this.optUsuariosDirigentes)
                                this.disabled = 1;
                            }
                            else {
                                this.totalRegistros = data.length;
                                this.optUsuariosDirigentes = data;
                                this.usuariosMultiples = true;
                            }
                            this.spinner = false
                        })
                        .catch(error => {
                            console.error('Error:', error)
                            if (error == 'SyntaxError: Unexpected end of JSON input') {
                                this.$swal.fire({
                                    text: 'El usuario no existe, se debe de crear el alta en usuarios',
                                    icon: 'warning',
                                    confirmButtonText: 'Ok',
                                    timer: 6000,
                                });
                            }
                            this.spinner = false
                        });


                }
                this.spinner = false
            },
            ObtenerSocioNombre() {

                this.spinner = true
                console.log('por nombre', this.inputbusqueda)

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.inputbusqueda)
                };
                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilbyNombrePadron', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {
                        
                        if (this.idPlazaSolicitante == data.plazaId) {
                            this.resultadoBusqueda = true
                            console.log('Esde la plaza', data.plazaId,)
                            this.persona = data;
                            console.log("usuario:", this.persona)

                            this.persona.fechaNacimiento = this.fechaFormato(this.persona.fechaNacimiento);
                            this.persona.fechaIngreso = this.fechaFormato(this.persona.fechaIngreso);
                            this.persona.cuentaMexicana
                            //this.selectedescolar = this.persona.idEscolaridad
                            //this.selectedProfesion = this.persona.idProfesion
                            //this.selecteClasificacion = this.persona.idProfesion
                            this.selectedTipoPersona = this.persona.idTipoPersona
                            this.cif = this.persona.cif
                            //obtenerformaci�n como dirigente
                            this.idpersonatable = this.persona.idPersona;
                            this.getDataByID();
                            this.ObtenerRepresentantePlaza();

                        }
                        else {
                            this.MensajeError('Solo se tiene acceso a socios de su plaza')
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error)
                        if (error == 'SyntaxError: Unexpected end of JSON input') {
                            this.$swal.fire({
                                text: 'El usuario no existe, se debe de crear el alta en usuarios',
                                icon: 'warning',
                                confirmButtonText: 'Ok',
                                timer: 6000,
                            });
                        }
                    });
                this.spinner = false

            },
            ObtenerSocioCuentaMexicana() {
                
                console.log('por cuenta mexicana')
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.inputbusqueda)
                }


                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilbyCuentaMexicanaPadron', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {
                        

                        if (this.idPlazaSolicitante == data.plazaId) {
                            console.log('Esde la plaza', data.plazaId,)
                            this.resultadoBusqueda = true
                            this.persona = data;

                            console.log("usuario:", this.persona)
                            this.persona.fechaNacimiento = this.fechaFormato(this.persona.fechaNacimiento);
                            this.persona.fechaIngreso = this.fechaFormato(this.persona.fechaIngreso);
                            this.persona.cuentaMexicana
                            //this.selectedescolar = this.persona.idEscolaridad
                            //this.selectedProfesion = this.persona.idProfesion
                            this.selectedTipoPersona = this.persona.idTipoPersona
                            this.cif = this.persona.cif
                            //obtenerformaci�n como dirigente
                            //this.idpersonatable = this.persona.idPersona;
                            this.getDataByID();
                            this.ObtenerRepresentantePlaza();
                            //console.log('idpersona-get cuenta', this.persona.cuentaMexicana)
                        }
                        else {
                            this.MensajeError('Solo se tiene acceso a socios de su plaza')
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error)
                        if (error == 'SyntaxError: Unexpected end of JSON input') {
                            this.$swal.fire({
                                text: 'El ususaio no existe, se debe de crear el alta en usuarios',
                                icon: 'warning',
                                confirmButtonText: 'Ok',
                                timer: 6000,
                            });
                        }
                    });


            },
            getByCIF() {
                

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.inputbusqueda)
                };


                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilbyCifPadron', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        


                        if (this.idPlazaSolicitante == data.plazaId) {
                            this.resultadoBusqueda = true;
                            console.log('Esde la plaza', data.plazaId, )

                            this.persona = data;
                            console.log("usuario:", this.persona, this.persona.sucursalId)
                            this.persona.fechaNacimiento = this.fechaFormato(this.persona.fechaNacimiento);
                            this.persona.fechaIngreso = this.fechaFormato(this.persona.fechaIngreso);
                            //this.persona.cuentaMexicana
                            //this.selectedescolar = this.persona.idEscolaridad
                            //this.selectedProfesion = this.persona.idProfesion
                            this.selectedTipoPersona = this.persona.idTipoPersona
                            this.cif = this.persona.cif
                            //obtenerformaci�n como dirigente
                            this.idpersonatable = this.persona.idPersona;
                            this.getDataByID();

                            this.ObtenerRepresentantePlaza();
                            //console.log('idpersona-get cuenta', this.persona.cuentaMexicana)
                        }
                        else {
                            this.MensajeError('Solo se tiene acceso a socios de su plaza')
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error)
                        if (error == 'SyntaxError: Unexpected end of JSON input') {
                            this.$swal.fire({
                                text: 'El ususaio no existe, se debe de crear el alta en usuarios',
                                icon: 'warning',
                                confirmButtonText: 'Ok',
                                timer: 6000,
                            });
                        }

                    });



            },


            //termino validar busqueda
            //addNew() {
            //    //console.log('update', this.persona)
            //    var body = {
            //        //idPersona: this.idPersona,
            //        nombrePersona: this.nombres,
            //        estatusPersona: this.estatusPersona == 1 ? true : false,
            //        idTipoPersona: this.idTipoPersona,
            //        idCargo: 1, //this.idCargo,
            //        idSubUnidadOperativa: 1,
            //        idGenero: this.persona.idGenero,
            //        idEstadoCivil: 1,//this.idEstadoCivil,
            //        idOficio: 1,//this.idOficio,
            //        idEscolaridad: this.idEscolaridad,
            //        apellidoMaterno: this.amaterno,
            //        apellidoPaterno: this.apaterno,
            //        fechaNacimiento: this.fechaFormato(this.registro.fecNacD),
            //        rfc: this.rfc,
            //        curp: this.curp,
            //        edad: this.edad,
            //        codigoPostal: this.codigoPostal,
            //        celular: 0, //this.celular,
            //        fechaIngreso: this.fechaFormato(this.registro.fecNacD),//this.fechaIngreso,
            //        fechaBaja: this.fechaBaja,
            //        cif: this.cif,
            //        dirigente: this.dirigente == true ? 1 : 0,
            //        idDirigente: this.idDirigente,
            //        idRepresententanteCargoCat: 1,
            //        idProfesion: this.idProfesion,
            //        calle: this.calle,
            //        numeroInterior: this.nointerior,
            //        colonia: 'Valle',//this.colonia,
            //        estado: this.estado,
            //        municipio: this.municipio,
            //        plaza: this.plaza,
            //        sucursal: this.sucursal,
            //        correoPersonal: this.correoPersonal,
            //        fechaCreacion: null

            //    }
            //    console.log('body', body)
            //    const requestOptions = {
            //        method: 'POST',
            //        headers: { 'Content-Type': 'application/json' },
            //        body: JSON.stringify(body)
            //    };
            //    fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/PersonaCrear', requestOptions)
            //        .then(async response => {

            //            if (response.status == 200) {
            //                this.$emit("closeEditModal");
            //                this.$emit("reloadDataTable");
            //                this.$emit("showSuccessAlert");
            //            }
            //            else {
            //                this.$swal.fire({
            //                    text: 'Se genero un error al editar  valide con su administrador',
            //                    icon: 'error',
            //                    confirmButtonText: 'Ok',
            //                    timer: 3000,
            //                });
            //            }
            //        })
            //        .catch(error => {
            //            this.errorMessage = error;
            //            console.error('There was an error!', error);
            //        });

            //},





            update() {
                //debugger

                console.log('crear alta')
                var body = {
                    idPersona: this.persona.idPersona,
                    nombrePersona: this.persona.nombrePersona,
                    estatusPersona: this.persona.estatusPersona == 1 ? true : false,
                    idTipoPersona: 1,//this.selectedTipoPersona,
                    idCargo: this.persona.idCargo,
                    idSubUnidadOperativa: 1,
                    idGenero: this.persona.idGenero,
                    idEstadoCivil: this.persona.idEstadoCivil,
                    idOficio: this.persona.idOficio,
                    //idEscolaridad: this.persona.idEscolaridad,
                    idEscolaridad: this.selectedescolar,
                    apellidoMaterno: this.persona.apellidoMaterno,
                    apellidoPaterno: this.persona.apellidoPaterno,
                    fechaNacimiento: this.persona.fechaNacimiento,
                    rfc: this.persona.rfc,
                    curp: this.persona.curp,
                    edad: this.persona.edad,
                    codigoPostal: this.persona.codigoPostal,
                    celular: this.persona.celular,
                    fechaIngreso: this.persona.fechaIngreso,
                    fechaBaja: this.persona.fechaBaja,
                    cif: this.persona.cif,
                    dirigente:true,
                    //this.esdirigenteSolAct == 1 ? true : false,
                    idDirigente: this.persona.idDirigente,
                    idRepresententanteCargoCat: 1,
                    //idProfesion: this.persona.idProfesion,
                    idProfesion: this.selectedProfesion,
                    calle: this.persona.calle,
                    numeroInterior: this.persona.numeroInterior,
                    colonia: this.persona.colonia,
                    estado: this.persona.estado,
                    municipio: this.persona.municipio,
                    plaza: this.persona.plaza,
                    plazaId: this.persona.plazaId,
                    sucursal: this.persona.sucursal,
                    correoPersonal: this.persona.correoAcceso,
                    fechaCreacion: this.persona.fechaIngreso,
                    cuentaMexicana: this.persona.cuentaMexicana,
                    participacion: this.selectedparticipacion,

                }
                console.log('body', body)
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(body)
                };

                fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/PersonaUpdate', requestOptions,)
                    .then(async response => {



                        if (response.status == 200) {
                            //this.$emit("closeCreateModal");
                            //this.$emit("reloadDataTable");
                            //this.$emit("showSuccessAlert");
                            //this.onSelectedExpediente();
                           

                        }
                        else {
                            this.$swal.fire({
                                text: 'Se genero un error al editar  valide con su administrador',
                                icon: 'error',
                                confirmButtonText: 'Ok',
                                timer: 3000,
                            });

                        }
                    })
                    .catch(error => {
                        this.errorMessage = error;
                        console.error('There was an error!', error);

                    });


            },
            validaExistenciasolicitudByCif() {
                //this.spinnerGuardar = true
                this.isLoading = true;

                //this.validaExistenciaByCorreoAcceso();

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.cif)
                };
                console.log('cif gets', this.cif)


                fetch(config.auth.server_url_api + 'api/Solicitud/SolicitudpersonaResponsablebyCif', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.validarcif = data;
                        console.log('validarcif...', this.validarcif)
                        console.log('validarcif...cif', this.validarcif.cif)


                        if (this.validarcif.cif == '' || this.validarcif.cif == null || this.validarcif.cif == 0) {
                            console.log('no tiene alta con estatus permitir crear alta')
                            console.log('validacif false----')
                            //console.log('esodg', this.permisoSolicitud)
                            this.crearsolicitud();


                        }
                        else {
                            console.log('Tiene  alta con estatus aprobada no crear')
                            //debugger
                            this.spinner = false
                            this.$swal.fire({
                                text: 'Ya existe una solicitud de alta con el CIF ingresado, favor de validar',
                                icon: 'warning',
                                confirmButtonText: 'Ok',

                            });
                            

                        }
                    })
                    .catch(error => {
                        //this.MensajeError(error) //fechaActual(
                        console.log(error)
                        this.Organotable = false

                    });

               
            },
            getDataByID() {
                console.log('idpersona', this.persona.idPersona)
                const requestOptions = {
                    method: 'PUT',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.persona.idPersona)
                };

                console.log('getbytable')


                fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/ConsultarPersonaCargoOrganobyid', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.items = data;
                        console.log('getdatatable...', this.items)

                        if (this.items == '' || this.items == null || this.items == 0) {
                            this.Organotable = false
                        }
                        else {
                            this.Organotable = true
                        }
                    })
                    .catch(error => {
                        //this.MensajeError(error) //fechaActual(
                        console.log(error)
                        this.Organotable = false
                    });
            },
            ObtenerRepresentantePlaza() {
                console.log('idplaza', this.persona.plazaId)
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.persona.plazaId)
                };

                console.log('getbytable')

                fetch(config.auth.server_url_api + 'api/ResponsablePlazas/ResponsablePlazaPersonabyIdplaza', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.responsable = data;
                        console.log('responsaplaza', this.responsable)

                    })
                    .catch(error => {

                        console.log(error)

                    });
            },
            ObtenerPlazaSolicitante() {
                //obtener correo usuario
                var correoDir = this.$store.getters['user/getCorreoDirigente'];
                this.correoDirigente = correoDir;
                console.log("solicitante--plaza:", this.correoDirigente)

                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.correoDirigente)
                };

                fetch(config.auth.server_url_api + 'api/Usuarios/UsuarioPersonaPerfilPermisoPlaza', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.personasolicitante = data;
                        console.log('personasolicitante', this.personasolicitante)
                        this.idPersonaSolicitante = this.personasolicitante.idPersona
                        this.plazaPersonaSolicitante = this.personasolicitante.plaza
                        this.idPlazaSolicitante = this.personasolicitante.plazaId

                        console.log('IDPERSONASOLICITANTE plaza', this.idPersonaSolicitante, this.plazaPersonaSolicitante, this.idPlazaSolicitante)

                    })
                    .catch(error => {
                        this.MensajeError(error) //fechaActual(
                        console.log(error)
                        this.permisoSolicitud = false
                        console.log('No es odg', this.permisoSolicitud)

                    });
            },
            crearsolicitud() {
                //validar si eres de odg
                console.log(' creacionsolicitud--------')
                if (this.permisoSolicitud == true) {
                    //this.update();
                    console.log(' Es ODG  solicitud aprobada------')
                    if (this.responsable.idResponsablePlaza == null) {
                        console.log('no tiene representante')
                        this.$swal.fire({
                            text: 'No existe un representante para la plaza',
                            icon: 'warning',
                            confirmButtonText: 'Ok',
                            timer: 9000,
                        });

                    }
                    else {
                        console.log('crear solicituddd--representante---')
                      
                        //debugger
                        this.update()
                        this.createNiveldirigencial()
                        this.solicitud = 'A'
                        var body = {

                            IdPersona: this.persona.idPersona,
                            estatus: 'Aprobado',
                            IdTipoMovimiento: 1,
                            observaciones: '',
                            IdMotivoBaja: 5,
                            EstatusSolicitud: false,
                            IdPersonaSolicitante: this.idPersonaSolicitante,

                        }
                        console.log('body', body)
                        const requestOptions = {
                            method: 'POST',
                            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                            body: JSON.stringify(body)
                        };


                        fetch(config.auth.server_url_api + 'api/Solicitud/SolicitudCrear', requestOptions)
                            .then((response) => response.json())
                            .then((data) => {


                                this.solicituddata = data;
                                console.log('solicitudid', this.solicituddata.idSolicitud)
                                console.log('solicitud', this.solicituddata, this.solicituddata.idSolicitud)
                                this.esdirigenteSolAct = false

                               
                                this.onSelectedExpediente();
                                //this.spinnerGuardar = false
                                this.isLoading = false;
                                this.$emit("closeCreateModal");
                                this.$emit("reloadDataTable");
                                this.$emit("showSuccessAlert");
                                //this.crearPersonaSolicitudHist();

                            })
                            .catch(error => {
                                console.error('Error:', error)
                            });
                        //.then(async response => {

                            //    if (response.status == 200) {

                            //        console.log('creacion solicitud')

                            //    }
                            //    else {

                            //        this.MensajeError('Se genero un error al crear solicitud valide con su administrador');

                            //    }
                            //})
                            //.catch(error => {
                            //    this.errorMessage = error;
                            //    console.error('There was an error!', error);

                            //});
                        this.esdirigenteSolAct = true
                       
                       
                    }
                }
                else {
                    //no eres de odg
                    console.log('Crear solicitud pendiente')
                    if (this.responsable.idResponsablePlaza == null) {
                        console.log('no tiene representante')
                        this.$swal.fire({
                            text: 'No existe un representante para la plaza',
                            icon: 'warning',
                            confirmButtonText: 'Ok',
                            timer: 9000,
                        });
                    }

                    else {
                        console.log('crear solicituddd--representante')
                        this.solicitud = 'A'
                        var body2 = {

                            IdPersona: this.persona.idPersona,
                            estatus: 'Pendiente',
                            IdTipoMovimiento: 1,
                            observaciones: '',
                            IdMotivoBaja: 5,
                            EstatusSolicitud: true,
                            IdPersonaSolicitante: this.idPersonaSolicitante,
                        }
                        console.log('body', body2)
                        const requestOptions = {
                            method: 'POST',
                            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                            body: JSON.stringify(body2)
                        };


                        fetch(config.auth.server_url_api + 'api/Solicitud/SolicitudCrear', requestOptions)
                            .then((response) => response.json())
                            .then((data) => {

                                
                                 this.solicituddata  = data;
                                console.log('solicitudid', this.solicituddata.idSolicitud)
                                console.log('solicitud', this.solicituddata, this.solicituddata.idSolicitud)
                                this.esdirigenteSolAct = false
                                this.crearPersonaSolicitudHist();
                            })
                            .catch(error => {
                                console.error('Error:', error)
                            });

                        //.then(async response => {

                            //    if (response.status == 200) {
                            //        console.log('creacion solicitud')
                            //    }
                            //    else {
                            //        this.$swal.fire({
                            //            text: 'Se genero un error al editar  valide con su administrador',
                            //            icon: 'warning',
                            //            confirmButtonText: 'Ok',
                            //            timer: 3000,
                            //        });
                            //    }
                            //})
                            //.catch(error => {
                            //    this.errorMessage = error;
                            //    console.error('There was an error!', error);
                            //});
                       
                     
                        //this.update();---solo cuando esta aprobado
                    }
                }
            },
            getFile(event) {


                
                const nombre = event.target.files[0].name;
                let extension = nombre.split('.');
                let size = extension.length;
                if (extension[size - 1].toString() != "zip") {
                    this.file = false
                    this.MensajeError("Tipo de archivo invalido");

                }
                else {
                    this.file = event.target.files[0];
                    console.log('fileExpediente', this.file);
                }

            },
            getFile2(event) {

                
                const nombre = event.target.files[0].name;
                let extension = nombre.split('.');
                let size = extension.length;
                if (extension[size - 1].toString() != "pdf") {
                    this.MensajeError("Tipo de archivo invalido");
                    this.file2 = false
                } else {
                    this.file2 = event.target.files[0];
                    console.log('filedos', this.file2);
                }



            },
            onSelectedExpediente() {

               //debugger
                let fileData = new FormData();

                console.log('file', this.file.name)
                fileData.append('file', this.file, this.file.name);
                fileData.append('file', this.file2, this.file2.name);
                console.log('filedata', fileData)
                HTTP.post(`api/Dirigentes/AgregarDocumentos`,
                    fileData,
                    {
                       
                        headers: {
                            'Content-Type': 'multipart/form-data'
                        }
                    }).then(response => {
                        this.MensajeSuccess("Archivo cargado: " + response.data);
                        //alert(`Total Mock File Uploaded: ${response.data}`);
                        this.cargaArchivos();
                    }).catch(error => {
                        this.MensajeError("Ocurrio un problema al cargar el archivo: " + error);
                        //alert(`something went wrong: ${error}`);
                    });

            },
            cargaArchivos() {

                console.log('cargaArchivo')
              
                var body = {
                    expedienteDigital: this.file.name,
                    curriculum: this.file2.name,
                    estatus: true,
                    idPersona: this.persona.idPersona,

                }
                console.log('body', body)
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(body)
                };


                fetch(config.auth.server_url_api + 'api/Dirigentes/Crear', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            console.log('expediente creado')

                        }
                        else {
                            this.errorMessage('Se genero un error al valide con su administrador al guarda documento')

                        }
                    })
                    .catch(error => {
                        this.errorMessage = error;
                        console.error('There was an error!', error);
                    });


            },
            fechaFormato(fecha) {

                let ano = new Date(fecha).getFullYear();
                let mes = new Date(fecha).getMonth() + 1;
                let dia = new Date(fecha).getDate();

                mes = mes < 10 ? "0" + mes : mes;
                dia = dia < 10 ? "0" + dia : dia;


                let salida = ano + '-' + mes + '-' + dia;
                return salida;

            },
            crearPersonaSolicitudHist() {
                console.log('crearPersonaSolicitudHist', this.persona, this.persona.sucursalId)
                //debugger
                let ano = new Date(this.finPeriodo).getFullYear();
                console.log('periodo',ano, this.finPeriodo)
                var body = {
                    idPersona: this.persona.idPersona,
                    nombrePersona: this.persona.nombrePersona,
                    estatusPersona: this.persona.estatusPersona == 1 ? true : false,
                    idTipoPersona: 1,//this.selectedTipoPersona,
                    idCargo: this.persona.idCargo,
                    idSubUnidadOperativa: 1,
                    idGenero: this.persona.idGenero,
                    idEstadoCivil: this.persona.idEstadoCivil,
                    idOficio: this.persona.idOficio,
                    //idEscolaridad: this.persona.idEscolaridad,
                    idEscolaridad: this.selectedescolar,
                    apellidoMaterno: this.persona.apellidoMaterno,
                    apellidoPaterno: this.persona.apellidoPaterno,
                    fechaNacimiento: this.persona.fechaNacimiento,
                    rfc: this.persona.rfc,
                    curp: this.persona.curp,
                    edad: this.persona.edad,
                    codigoPostal: this.persona.codigoPostal,
                    celular: this.persona.celular,
                    fechaIngreso: this.persona.fechaIngreso,
                    fechaBaja: this.persona.fechaBaja,
                    cif: this.persona.cif,
                    dirigente: this.esdirigenteSolAct,
                    idDirigente: this.persona.idDirigente,
                    idRepresententanteCargoCat: 1,
                    //idProfesion: this.persona.idProfesion,
                    idProfesion: this.selectedProfesion,
                    calle: this.persona.calle,
                    numeroInterior: this.persona.numeroInterior,
                    colonia: this.persona.colonia,
                    estado: this.persona.estado,
                    municipio: this.persona.municipio,
                    plaza: this.persona.plaza,
                    idPlaza: this.persona.plazaId,
                    idSucursal: this.persona.sucursalId,
                    sucursal: this.persona.sucursal,
                    correoPersonal: this.persona.correoAcceso,
                    fechaCreacion: this.persona.fechaIngreso,
                    cuentaMexicana: this.persona.cuentaMexicana,
                    expediente: this.file.name,
                    curriculum: this.file2.name,
                    idSolicitud: this.solicituddata.idSolicitud,
                    estatusPersonSolicitud: true,
                    //niveldirigencial
                    idNivelDirigencialCat : this.selectedNivelDirigenciales,
                    FechaIngresoNivel:this.FechaIngresoNivel,
                    finPeriodo:ano,
                    periodo: this.selectedPeriodo == 1 ? 'Primero' : 'Segundo',
                    Aperiodo: this.selectedAnoPeriodo,
                    idCondicionIngreso: this.selectedcondicoines,
                    participacion: this.selectedparticipacion,




                }
                console.log('body', body)
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(body)
                };
                fetch(config.auth.server_url_api + 'api/PersonaSolicitudHist/Crear', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            console.log('PersonaSolicitudHis creada')

                            this.$emit("closeCreateModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showSuccessAlert");
                            //this.createNiveldirigencial();
                            this.onSelectedExpediente();
                            //this.spinnerGuardar = false
                            this.isLoading = false;
                          
                        }
                        else {
                            this.MensajeError('Error valide con su administrador')
                        }
                    })
                    .catch(error => {
                        this.errorMessage = error;
                        console.error('Error valide con su administrador', error);
                        //this.spinnerGuardar = 
                        this.isLoading = false;
                    });

            },
        ObtenercondicionIngreso() {
        HTTP
        .get('api/CatalogoCondicionIngreso/ConsultarActivas')
        .then(response => {
            if (response.status == 401)
                throw new Error(this.$messageConstants('apiError'));
            if (response.status == 200) {
               
                this.optioncondicoines = response.data;
                //console.log('condiciones Ingreso', this.optioncondicoines)
            }
        })
        .catch(function (error) {
           // this.MensajeError(error);
           console.log(error);
        });
        },

        ObtenerNivelDirigencialCat() {
        HTTP
        .get('api/NivelDirigencialCat/ConsultarActivas')
        .then(response => {
            if (response.status == 401)
                throw new Error(this.$messageConstants('apiError'));
            if (response.status == 200) {
            
                this.optionNivelDirigenciales = response.data;
                //console.log('condiciones Ingreso', this.optionNivelDirigenciales)
                //console.log('fecha hoy', this.fechaactual, 'año', this.finPeriodo)
            }
            })
            .catch(function (error) {
               // this.MensajeError(error);
               console.log(error);
            });
            },
            getday(){
                var myDate = new Date();
            this.finPeriodo=(myDate.getFullYear() + '-' +('0' + (myDate.getMonth()+1)).slice(-2)+ '-' +  ('0' + myDate.getDate()).slice(-2));
            this.fechaactual= new Date().getTime();
            //(myDate.getFullYear() + '-' +('0' + (myDate.getMonth()+1)).slice(-2)+ '-' +  ('0' + myDate.getDate()).slice(-2) + ' '+myDate.getHours()+ ':'+('0' + (myDate.getMinutes())).slice(-2)+ ':'+myDate.getSeconds())
            
            },
getAntiguedad(value){

    var getant = new Date(value).getTime()
        console.log('Antiguedad', this.fechaactual, getant)
        this.antiguedad  =Math.round((this.fechaactual - getant)/(1000*60*60*24)-1)
        //console.log('Antiguedad', this.antiguedad)
    
},
createNiveldirigencial(){
    //debugger
    console.log('createNiveldirigencial' )
    let ano = new Date(this.finPeriodo).getFullYear();

var body = {
    idNivelDirigencialCat : this.selectedNivelDirigenciales,
    idPersona: this.persona.idPersona,
    fechaIngreso:this.FechaIngresoNivel,
    finPeriodo: ano,
    periodo: this.selectedPeriodo == 1 ? 'Primero' : 'Segundo',
    Aperiodo: this.selectedAnoPeriodo,
    idCondicionIngreso: this.selectedcondicoines
}
console.log('body', body)
const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
    body: JSON.stringify(body)
};
fetch(config.auth.server_url_api + 'api/NivelDirigencia/Crear', requestOptions)
    .then(async response => {
        if (response.status == 200) {
            console.log('createNiveldirigencial creada')
            // this.$emit("closeCreateModal");
            // this.$emit("reloadDataTable");
            // this.$emit("showSuccessAlert");
            // this.onSelectedExpediente();
            // this.spinnerGuardar = false
          
        }
        else {
            this.MensajeError('Error valide con su administrador')
        }
    })
    .catch(error => {
        this.errorMessage = error;
        console.error('Error valide con su administrador', error);
        //this.spinnerGuardar = false
        this.isLoading = false;
    });


}


        },
        mounted() {
            this.getday();
            this.ObtenerProfesion();
            this.ObtenerEscolaridad();
            //this.ObtenerClasificacion();
            this.ObtenerTipoPersona();
            this.ObtenerEsODG();
            this.ObtenerPlazaSolicitante();
            this.ObtenercondicionIngreso();
            this.ObtenerNivelDirigencialCat();
            



        }
    };
</script>
