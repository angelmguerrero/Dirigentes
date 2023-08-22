<template>
    
<validation-observer ref="observer" v-slot="{ handleSubmit }">
    <b-form class="mt-auto" enctype="multipart/form-data" @submit.stop.prevent="handleSubmit(guardar)">
        <b-card class="mb-2" header-bg-variant="light">
            <b-card-body>
                <b-row align-h="end" v-if="reingreso"><h3 class="text-success">Reingreso</h3></b-row>
                <h2>Datos Generales: </h2>
                <hr />
                <b-row>
                    <b-col cols="4">
                        <validation-provider name="Apellido Paterno"
                                             :rules="{ required: true}"
                                             v-slot="validationContext">
                            <b-form-group id="apellido_paterno"
                                          label="Apellido Paterno"
                                          label-for="apellidoPaterno">
                                <b-form-input id="apellidoPaterno"
                                              type="text"
                                              v-model="persona.apellidoPaterno"
                                              :state="getValidationState(validationContext)"
                                              aria-describedby="input-1-live-feedback"
                                              trim></b-form-input>
                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                            </b-form-group>
                        </validation-provider>
                    </b-col>

                    <b-col cols="4">
                        <b-form-group id="Apellido Materno"
                                      label="Apellido Materno"
                                      label-for="apellidoMaterno">

                            <b-form-input id="apellidoMaterno"
                                          type="text"
                                          v-model="persona.apellidoMaterno"></b-form-input>
                        </b-form-group>
                    </b-col>

                    <b-col cols="4">
                        <validation-provider name="Nombre"
                                             :rules="{ required: true}"
                                             v-slot="validationContext">
                            <b-form-group id="nombres_"
                                          label="Nombres"
                                          label-for="nombres">

                                <b-form-input id="nombres"
                                              type="text"
                                              v-model="persona.nombrePersona"
                                              :state="getValidationState(validationContext)"
                                              aria-describedby="input-1-live-feedback"
                                              trim></b-form-input>
                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                            </b-form-group>
                        </validation-provider>
                    </b-col>

                </b-row>

                <b-row>
                    <b-col cols="4">
                        <validation-provider name="Fecha de Nacimiento"
                            :rules="{ required: true}"
                            v-slot="validationContext">
                            <b-form-group id="fecha_nacimiento"
                                label="Fecha Nacimiento"
                                label-for="fechaNacimiento">
                        <b-form-datepicker v-model="persona.fechaNacimiento" locale="es-MX"
                                   placeholder="Selecciona una fecha"
                                   :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"
                                   :state="getValidationState(validationContext)"
                                   >
                        </b-form-datepicker>
                        <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                    </b-form-group>    
                    </validation-provider>
                    </b-col>
                    <b-col cols="4">
                        <b-form-group id="edad_"
                                      label="Edad"
                                      label-for="edad">

                            <b-form-input id="edad"
                                          type="text"
                                          v-model="persona.edad"
                                          disabled></b-form-input>
                        </b-form-group>
                    </b-col>
                    <b-col cols="4">
                        <validation-provider name="RFC"
                                             :rules="{ required: true ,max:13}"
                                             v-slot="validationContext">
                            <b-form-group id="rfc_"
                                          label="Rfc"
                                          label-for="rfc">

                                <b-form-input id="rfc"
                                              type="text"
                                              v-model="persona.rfc"
                                              :state="getValidationState(validationContext)"
                                              aria-describedby="input-1-live-feedback"
                                              trim></b-form-input>
                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                            </b-form-group>
                        </validation-provider>
                    </b-col>
                </b-row>

                <b-row>
                    <b-col cols="4">
                        <validation-provider name="CURP"
                                             :rules="{ required: true ,max:18}"
                                             v-slot="validationContext">
                            <b-form-group id="curp_"
                                          label="CURP"
                                          label-for="curp">

                                <b-form-input id="curp"
                                              type="text"
                                              v-model="persona.curp"
                                              :state="getValidationState(validationContext)"
                                              aria-describedby="input-1-live-feedback"
                                              trim></b-form-input>
                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                            </b-form-group>
                        </validation-provider>
                    </b-col>
                    <b-col cols="4">
                        <b-form-group id="cif_"
                                      label="CIF"
                                      label-for="cif">

                            <b-form-input id="curp"
                                          type="text"
                                          v-model="persona.cif"
                                          disabled></b-form-input>
                        </b-form-group>
                    </b-col>

                    <b-col cols="4">
                        <!--<validation-provider name="Descripcion"
                                         :rules="{ required: true  }"
                                         v-slot="validationContext">-->
                        <b-form-group id="iddirigente_"
                                      label="ID Dirigente"
                                      label-for="iddirigente"
                                      disabled>

                            <b-form-input id="iddirigente"
                                          type="text"
                                          v-model="persona.idDirigente"
                                          disabled></b-form-input>
                            <!--<b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>-->
                        </b-form-group>
                        <!--</validation-provider>-->
                    </b-col>

                </b-row>

                <b-row>
                    <b-col cols="4">
                        <b-form-group id="plaza_"
                                      label="Plaza"
                                      label-for="plaza">

                            <b-form-input id="plaza"
                                          type="text"
                                          v-model="persona.plaza"
                                          disabled></b-form-input>


                        </b-form-group>
                    </b-col>

                    <b-col cols="4">
                        <b-form-group id="sucursal_"
                                      label="Sucursal"
                                      label-for="sucursal">

                            <b-form-input id="sucursal"
                                          type="text"
                                          v-model="persona.sucursal"
                                          disabled></b-form-input>


                        </b-form-group>
                    </b-col>

                    <b-col cols="4">
                        <b-form-group id="fecha_Ingreso"
                                      label="Fecha Ingreso"
                                      label-for="fechaIngreso">

                            <b-form-input id="fechaIngreso"
                                          type="text"
                                          v-model="fechaIngresoformato"
                                          disabled></b-form-input>
                        </b-form-group>
                    </b-col>

                </b-row>

                <b-row>
                    <b-col cols="4">
                        <validation-provider name=" G&eacute;nero"
                                             :rules="{ required: true }"
                                             v-slot="validationContext">
                            G&eacute;nero:
                            <b-form-select v-model="selectedgenero"
                                           :state="getValidationState(validationContext)"
                                           aria-describedby="input-1-live-feedback">
                                <option v-for="generooption in generooptions" :key="generooption.idGenero" :value="generooption.idGenero">
                                    {{ generooption.descripcion }}
                                </option>
                            </b-form-select>
                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </validation-provider>
                        <!--<Selected>option: {{ selectedgenero }}</Selected>-->
                    </b-col>
                    <b-col cols="4">
                        <validation-provider name="Estado Civil"
                                             :rules="{ required: true }"
                                             v-slot="validationContext">

                            Estado Civil:
                            <b-form-select v-model="selectedestadocivil"
                                           :state="getValidationState(validationContext)"
                                           aria-describedby="input-1-live-feedback">
                                <option v-for="estadociviloption in estadociviloptions" :key="estadociviloption.idEstadoCivil" :value="estadociviloption.idEstadoCivil">
                                    {{ estadociviloption.descripcion }}
                                </option>
                            </b-form-select>
                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </validation-provider>
                        <!--<Selected>option: {{ selectedestadocivil }}</Selected>-->
                    </b-col>
                <b-col cols="4">
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
                </b-col>
                </b-row>


                <b-row>
                    <b-col cols="4">
                <validation-provider name="Participación"
                     :rules="{ required: true }"
                     v-slot="validationContext">
                        <b-form-group id="correo_acceso"
                                      label="Correo"
                                      label-for="correoAcceso">

                            <b-form-input id="correoAcceso"
                                          type="text"
                                          v-model="persona.correoPersonal"
                                          :state="getValidationState(validationContext)"
                                          ></b-form-input>
                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </b-form-group>
                        
                </validation-provider>
                    </b-col>

                    <b-col cols="4">
                        <b-form-group id="celular_"
                                      label-for="celular">
                            <label>N&uacute;mero de tel&eacute;fono </label>

                            <b-form-input id="celular"
                                          type="text"
                                          v-model="persona.celular"></b-form-input>
                        </b-form-group>
                    </b-col>
                </b-row>
            </b-card-body>
        </b-card>
        <br />
       
        <b-card class="mb-2" header-bg-variant="light">
          
            <b-card-body>
                <h2>Informaci&oacute;n Direcci&oacute;n: </h2>

                <hr />


                <b-row>
                    <b-col cols="4">
                        <validation-provider name="Calle"
                                             :rules="{ required: true}"
                                             v-slot="validationContext">
                            <b-form-group id="calle_"
                                          label="Calle"
                                          label-for="calle">

                                <b-form-input id="calle"
                                              type="text"
                                              v-model="persona.calle"
                                              :state="getValidationState(validationContext)"
                                              aria-describedby="input-1-live-feedback"
                                              trim></b-form-input>
                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                            </b-form-group>
                        </validation-provider>
                    </b-col>

                    <b-col cols="4">
                        <validation-provider name="N&uacute;mero"
                                             :rules="{ required: true}"
                                             v-slot="validationContext">
                            <b-form-group id="numerointerior_"
                                          label-for="numeroInterior">
                                <label>N&uacute;mero</label>

                                <b-form-input id="numerointerior"
                                              type="text"
                                              v-model="persona.numeroInterior"
                                              :state="getValidationState(validationContext)"
                                              aria-describedby="input-1-live-feedback"
                                              trim></b-form-input>
                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                            </b-form-group>
                        </validation-provider>
                    </b-col>

                    <b-col cols="4">
                        <validation-provider name="Codigo Postal"
                                             :rules="{ required: true}"
                                             v-slot="validationContext">
                            <b-form-group id="codigopostal_"
                                          label="Codigo postal"
                                          label-for="codigoPostal">

                                <b-form-input id="codigopostal"
                                              type="text"
                                              v-model="persona.codigoPostal"
                                              :state="getValidationState(validationContext)"
                                              aria-describedby="input-1-live-feedback"
                                              trim></b-form-input>
                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                            </b-form-group>
                        </validation-provider>
                    </b-col>


                </b-row>

                <b-row>
                    <b-col cols="4">
                        <validation-provider name="Colonia"
                                             :rules="{ required: true}"
                                             v-slot="validationContext">
                            <b-form-group id="colonia_"
                                          label="Colonia"
                                          label-for="colonia">

                                <b-form-input id="colonia"
                                              type="text"
                                              v-model="persona.colonia"
                                              :state="getValidationState(validationContext)"
                                              aria-describedby="input-1-live-feedback"
                                              trim></b-form-input>
                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                            </b-form-group>
                        </validation-provider>
                    </b-col>

                    <b-col cols="4">
                        <validation-provider name="Estado"
                                             :rules="{ required: true}"
                                             v-slot="validationContext">
                            <b-form-group id="estado_"
                                          label="Estado"
                                          label-for="estado">

                                <b-form-input id="estado"
                                              type="text"
                                              v-model="persona.estado"
                                              :state="getValidationState(validationContext)"
                                              aria-describedby="input-1-live-feedback"
                                              trim></b-form-input>
                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                            </b-form-group>
                        </validation-provider>
                    </b-col>

                    <b-col cols="4">
                        <validation-provider name="Municipio"
                                             :rules="{ required: true}"
                                             v-slot="validationContext">
                            <b-form-group id="municipio_"
                                          label="Municipio"
                                          label-for="municipio">

                                <b-form-input id="municipio"
                                              type="text"
                                              v-model="persona.municipio" :state="getValidationState(validationContext)"
                                              aria-describedby="input-1-live-feedback"
                                              trim></b-form-input>
                                <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                            </b-form-group>
                        </validation-provider>
                    </b-col>
                </b-row>
            </b-card-body>
        </b-card>
        <br />
        <b-card class="mb-2" header-bg-variant="light">
            <b-card-body>                                                                                                                                 
                <loading-overlay :active='isLoading' color='#008000' />
                <h2>Informaci&oacute;n Acad&eacute;mica: </h2>
                <hr />
                <b-row class="mb-3">
                    <b-col cols="3"><b> Escolaridad: </b></b-col>
                    <b-col cols="3 p-0">
                        <validation-provider name="Escolaridad"
                                             :rules="{ required: true}"
                                             v-slot="validationContext">
                            <b-form-select v-model="selectedescolar" :state="getValidationState(validationContext)"
                                           aria-describedby="input-1-live-feedback">

                                <option v-for="escolaroption in escolaroptions" :key="escolaroption.value" :value="escolaroption.value">
                                    {{ escolaroption.text }}
                                </option>
                            </b-form-select>
                            <!--<Selected>option: {{ selectedescolar }}</Selected>-->
                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </validation-provider>
                    </b-col>

                    <b-col cols="3"><b> Profesi&oacute;n: </b></b-col>
                    <b-col cols="3 p-0">
                        <validation-provider name="Profesi&oacute;n"
                                             :rules="{ required: true}"
                                             v-slot="validationContext">
                            <b-form-select v-model="selectedProfesion" v-on:change="onChangeClasificacion"
                                           :state="getValidationState(validationContext)"
                                           aria-describedby="input-1-live-feedback">
                                <option v-for="optProfesion in optProfesiones" :key="optProfesion.id" :value="optProfesion.idProfesion">
                                    {{ optProfesion.descripcion }}
                                </option>
                            </b-form-select>
                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </validation-provider>
                        <!-- <Selected> option: {{ selectedProfesion }} </Selected>-->
                    </b-col>

                </b-row>
                <b-row class="mb-3">
                    <b-col cols="3"><b> Clasificacion: </b></b-col>
                    <b-col cols="3 p-0">
                        <b-form-select v-model="selecteClasificacion" disabled>
                            <option v-for="optClasificacion in optClasificaciones" :key="optClasificacion.id"
                                    :value="optClasificacion.idProfesion">

                                {{ optClasificacion.descripcionClasif }}
                            </option>
                        </b-form-select>
                        <!-- <Selected> option: {{ selecteClasificacion }} </Selected>-->
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
                <!--<b-row>
        <b-col cols="6">
            <b-form-group id="clasificacion_"
                          label-for="Clasificacion"
                          class="mb-3">
                <b> Clasificaci&oacute;n: </b>
                <b-form-input id="clasificacion"
                              type="text"
                              v-model="persona.descripcionClasificacion" disabled></b-form-input>
            </b-form-group>
        </b-col>
    </b-row>-->
                <b-row class="mb-3">
                    <b-col cols="3 "><b> Expediente Digital: </b></b-col>
                    <b-col cols="3 p-0 ">
                        <validation-provider name="Expediente"
                             :rules="{ required: true}"
                            v-slot="validationContext">
                        <b-form-file name="file1"
                                     v-model="file1"
                                     :placeholder="file1"
                                     browse-text="Agregar"
                                     drop-placeholder="Expediente"
                                     accept=".zip"
                                     :state="getValidationState(validationContext)"
                                     v-on:change="getFile($event)"
                                     trim></b-form-file>
                            <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </validation-provider>
                    </b-col>
                    <div v-show="file1">
                        <b-col cols="2 p-0 m-0">
                            <b-button variant="success" @click="DescargarExpediente">
                                <b-icon icon="cloud-download" aria-hidden="true"></b-icon>
                            </b-button>
                        </b-col>
                    </div>
                </b-row>
                <b-row class="mb-3">
                    <b-col cols="3"><b> Curriculum Vitae: </b></b-col>
                    <b-col cols="3 p-0">
                        <validation-provider name="Curriculum"
                             :rules="{ required: true}"
                            v-slot="validationContext">
                        <b-form-file name="file2"
                                     v-model="file2"
                                     :placeholder="file2"
                                     browse-text="Agregar"
                                     drop-placeholder="Curriculum"
                                     accept=".pdf"
                                     :state="getValidationState(validationContext)"
                                     v-on:change="getFile2($event)"
                                     trim></b-form-file>
                           <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                        </validation-provider>
                    </b-col>
                    <div v-show="file2">
                        <b-col cols="2 p-0 m-0">
                            <b-button variant="success" @click="DescargarCurriculum">
                                <b-icon icon="cloud-download" aria-hidden="true"></b-icon>
                            </b-button>
                        </b-col>
                    </div>
                </b-row>
            </b-card-body>
        </b-card>
        <br />
        <b-card class="mb-2" header-bg-variant="light">
            <b-card-body>
                <b-card-body>
                    <b-row>

                        <b-card-sub-title class="mb-2 p-1">
                            <h5>Formaci&oacute;n como Dirigente:</h5>
                        </b-card-sub-title>
                        <hr />

                    </b-row>
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
                                                <!-- <b-form-input  @input="ondatepickerselector"  v-model = "finPeriodo"    :state="getValidationState(validationContext)" aria-describedby="input-1-live-feedback" /> -->
                                                <Datepicker
                                                format="yyyy"
                                                :language="language"
                                                minimum-view="year"              
                                                name="datepicker"
                                                value="finPeriodo"
                                                v-model="finPeriodo"
                                                >{{ ondatepickerselector() }}</Datepicker>
                                                <p v-show="showdatepiker"  class="text-danger">El campo Fin del periodo es obligatorio</p>
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
                            <b-table outlined
                                     small
                                     hover
                                     fixed
                                     id="my-table"
                                     no-border-collapse
                                     :items="items"
                                     :fields="fields"
                                     head-variant="light"
                                     responsive="xl"
                                     class="text-center">
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
                <b-button variant="success" type="submit" >Guardar</b-button>
            </b-col>
            <b-col cols="mb-3 p-2">
                <b-button variant="danger" @click="triggerClose">Cancelar</b-button>
            </b-col>
        </b-row>
    </b-form>
</validation-observer>
</template>

<script>
    import moment from 'moment';
    import { config } from "@/config/auth";
  import { HTTP } from '@/plugins/axios'
    import store from '@/store' 
    import Datepicker from 'vuejs-datepicker';


    export default {
        name: "EditModal",
        props: {
            id: {
                type: Number,
            },
            reingreso: {
                type: Boolean,
                default: false,
                required: true
            },

        },
        components: {
            Datepicker
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
            },
            finPeriodo(value){
              
                if(value != null){ 
                    this.showdatepiker= false
                    console.log('finp',this.showdatepiker)
                }
                else{
                    this.showdatepiker= true
                    console.log('finp',this.showdatepiker)
                }
                
            } 
            
            

            
                    
        },
        
        
        
        data() {
            return {
                showdatepiker:false,
                isLoading: false,
                persona: {},
                selectedgenero: null,
                generooptions: [],
                selectedestadocivil: null,
                estadociviloptions: [],
                selectedTipoPersona: null,
                optionsTiposPersona: [],
                selectedescolar: null,
                escolaroptions: [],
                selectedProfesion: null,
                optProfesiones: [],
                selecteClasificacion: null,
                optClasificaciones: [],
                selectedparticipacion:null,
                optionsparticipacions:[
                    {id:1, descripcion:"N/A" },    
                    {id:2, descripcion:"Ex-Colaborador" },
                    {id:3, descripcion:"Ex-Dirigente"},
                ],
                file1: null,
                file2: null,
                archivo: {},
                //solicitud
                solicitudEstatus: 'Pendiente',
                //fechaNacimientoformato: '',
                fechaIngresoformato: '',
                Organotable: false,
                fields: [
                    { key: 'descripcionOrgano', label: 'Organo', sortable: true },
                    { key: 'descripcionCargo', label: 'Cargo', sortable: true },
                    { key: 'fechaInicial', label: 'Fecha Inicia', sortable: true, formatter: "formatDate" },
                ],
                items: [],
                correoDirigente: '',
                idPersonaSolicitante: '',
                plazaPersonaSolicitante: '',
                idPlazaSolicitante: '',
                personaAutorizada: '',
                esdirigenteSolAct: '',
                actualizapersonaestatus: '',
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
                nivelDirigencial:null,
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

            };
        },
        
        mounted() {
            this.getday();
            this.getByID();
            this.ObtenerNivelDirigencialbyid();
            this.ObtenerEscolaridad();
            this.ObtenerProfesion();
            this.ObtenerTipoPersona();
            this.ObtenerEsODG();
            this.ObtenerPlazaSolicitante();
            this.ObtenerGenero();
            this.ObtenerEstadoCivil();
            this.ObtenercondicionIngreso();
            this.ObtenerNivelDirigencialCat();


        },
        methods: {
            triggerClose() {
                this.$emit("closeEditModal");
            },
            getValidationState({ dirty, validated, valid = null }) {
                return dirty || validated ? valid : null;
            },
            ondatepickerselector(){
                if(this.finPeriodo== null) {
                    this.showdatepiker= true
                }
                else{
                    this.showdatepiker= false
                }
                //this.$refs.datepickerselector.selected()
            },
            getByID() {
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.id)
                };

                console.log('reingreso', this.reingreso)

                fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/PersonabyId', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {
                        //debugger
                        this.persona = data;
                        this.ObtenerRepresentantePlaza();
                        //this.persona.fechaNacimiento = this.formatDate(this.persona.fechaNacimiento);
                        //this.persona.fechaIngreso = this.fechaFormato(this.persona.fechaIngreso);

                        //this.fechaNacimientoformato = this.formatDate(this.persona.fechaNacimiento);
                        this.fechaIngresoformato = this.fechaFormato(this.persona.fechaIngreso);
                        this.selectedescolar = this.persona.idEscolaridad
                        this.selectedProfesion = this.persona.idProfesion
                        this.selecteClasificacion = this.selectedProfesion
                        this.selectedTipoPersona = this.persona.idTipoPersona
                        this.selectedgenero = this.persona.idGenero
                        this.selectedestadocivil = this.persona.idEstadoCivil          
                        this.selectedparticipacion = this.persona.participacion
                        if(this.reingreso == false){
                            this.file1 = this.persona.expedienteDigital
                            this.file2 = this.persona.curriculum
                        } 
                        console.log("persona:------", this.persona)
                        console.log("persona:----file--", this.file1, this.file2)
                        this.Organotable = true
                        this.ObtenerClasificacion();
                        this.getDataByID();


                    })
                    .catch(error => {
                        console.error('Error:', error)
                        this.Organotable = false
                    });
            },

            guardar() {

               
                this.isLoading = true;
                if (this.idPlazaSolicitante == this.persona.idPlaza) {
                    console.log('Esde la plaza', this.persona.idPlaza)
                    this.crearsolicitud();
                }
                else {
                    console.log('No es de la plaza', this.idPlazaSolicitante, this.persona.idPlaza)
                    this.isLoading = false;
                    this.$swal.fire({
                        text: 'No puedes crear dirigentes que no sean de tu plaza',
                        icon: 'warning',
                        confirmButtonText: 'Ok',
                    });

                }

               
            },


            crearsolicitud() {
                //validar si eres de odg
                console.log(' creacionsolicitud--------')

                //esodg
                if (this.permisoSolicitud == true) {

                    console.log(' Es ODG  solicitud aprobada------')
                    //responsable plaza
                    if (this.responsable.idResponsablePlaza == null) {
                        console.log('no tiene representante')
                        this.$swal.fire({
                            text: 'No existe un representante para la plaza',
                            icon: 'warning',
                            confirmButtonText: 'Ok',
                            timer: 9000,
                        });

                    }
                    //responsable plaza
                    else {
                        //reingreso
                        if (this.reingreso == true) {
                              //debugger
                            this.update()
                            this.UpdateNivelDirigencialbyid()
                            //console.log('solicitud de reingreso', this.reingreso)
                           

                            var body = {

                                IdPersona: this.persona.idPersona,
                                estatus: 'Aprobado',
                                IdTipoMovimiento: 3,
                                observaciones: '',
                                IdMotivoBaja: 5,
                                EstatusSolicitud: false,
                                IdPersonaSolicitante: this.idPersonaSolicitante,

                            }
                            console.log('body--solicitud reingreso', body)
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
                                     this.$emit("closeEditModal");
                                    this.$emit("reloadDataTable");
                                    this.$emit("showSuccessAlert");
                                    this.isLoading = false;
                                    //this.crearPersonaSolicitudHist();
                                    //this.update();
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
                            //this.update();

                        }

                        //edicion
                        else {
                            // debugger
                            this.update()
                            this.UpdateNivelDirigencialbyid()
                            console.log('solicitud de edici�n')

                            var body2 = {

                                IdPersona: this.persona.idPersona,
                                estatus: 'Aprobado',
                                IdTipoMovimiento: 4,
                                observaciones: '',
                                IdMotivoBaja: 5,
                                EstatusSolicitud: false,
                                IdPersonaSolicitante: this.idPersonaSolicitante,

                            }
                            console.log('body---solicitudmodifica', body2)
                            const requestOptions = {
                                method: 'POST',
                                headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                                body: JSON.stringify(body2)
                            };
                            fetch(config.auth.server_url_api + 'api/Solicitud/SolicitudCrear', requestOptions)
                                .then((response) => response.json())
                                .then((data) => {


                                    this.solicituddata = data;
                                    console.log('solicitudid', this.solicituddata.idSolicitud)
                                    console.log('solicitud', this.solicituddata, this.solicituddata.idSolicitud)
                                    this.esdirigenteSolAct = false
                                       this.$emit("closeEditModal");
                                    this.$emit("reloadDataTable");
                                    this.$emit("showSuccessAlert");
                                    //this.UpdateNivelDirigencialbyid();
                                    this.onSelectedExpediente();
                                    this.isLoading = false;


                                    //this.crearPersonaSolicitudHist();
                                    //this.update();
                                })
                                .catch(error => {
                                    console.error('Error:', error)
                                });

                            //    .then(async response => {

                            //        if (response.status == 200) {

                            //            console.log('creacion solicitud')

                            //        }
                            //        else {
                            //            this.$swal.fire({
                            //                text: 'Se genero un error al editar  valide con su administrador',
                            //                icon: 'warning',
                            //                confirmButtonText: 'Ok',
                            //                timer: 3000,
                            //            });
                            //        }
                            //    })
                            //    .catch(error => {
                            //        this.errorMessage = error;
                            //        console.error('There was an error!', error);
                            //    });
                            //this.update();


                        }


                    }

                }

                //esodg
                else {
                    console.log(' No es ODG  solicitud aprobada------')

                    //responsable plaza
                    if (this.responsable.idResponsablePlaza == null) {
                        console.log('no tiene representante')
                        this.$swal.fire({
                            text: 'No existe un representante para la plaza',
                            icon: 'warning',
                            confirmButtonText: 'Ok',
                            timer: 9000,
                        });



                    }
                    //responsable plaza
                    else {
                        //reingreso
                        if (this.reingreso == true) {
                            console.log('solicitud de reingreso')

                            var body3 = {

                                IdPersona: this.persona.idPersona,
                                estatus: 'Pendiente',
                                IdTipoMovimiento: 3,
                                observaciones: '',
                                IdMotivoBaja: 5,
                                EstatusSolicitud: true,
                                IdPersonaSolicitante: this.idPersonaSolicitante,

                            }
                            console.log('body--no es odg reingreso', body3)
                            const requestOptions = {
                                method: 'POST',
                                headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                                body: JSON.stringify(body3)
                            };
                            fetch(config.auth.server_url_api + 'api/Solicitud/SolicitudCrear', requestOptions)
                                .then((response) => response.json())
                                .then((data) => {


                                    this.solicituddata = data;
                                    console.log('solicitudid', this.solicituddata.idSolicitud)
                                    console.log('solicitud', this.solicituddata, this.solicituddata.idSolicitud)
                                    this.esdirigenteSolAct = false
                                    this.crearPersonaSolicitudHist();
                                })
                                .catch(error => {
                                    console.error('Error:', error)
                                });
                            //    .then(async response => {

                            //        if (response.status == 200) {

                            //            console.log('creacion solicitud')

                            //        }
                            //        else {
                            //            this.$swal.fire({
                            //                text: 'Se genero un error al editar  valide con su administrador',
                            //                icon: 'warning',
                            //                confirmButtonText: 'Ok',
                            //                timer: 3000,
                            //            });
                            //        }
                            //    })
                            //    .catch(error => {
                            //        this.errorMessage = error;
                            //        console.error('There was an error!', error);
                            //    });
                            //this.update();

                        }

                        //edicion
                        else {

                            console.log('solicitud de edici�n')

                            var body4 = {

                                IdPersona: this.persona.idPersona,
                                estatus: 'Pendiente',
                                IdTipoMovimiento: 4,
                                observaciones: '',
                                IdMotivoBaja: 5,
                                EstatusSolicitud: true,
                                IdPersonaSolicitante: this.idPersonaSolicitante,

                            }
                            console.log('body', body4)
                            const requestOptions = {
                                method: 'POST',
                                headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                                body: JSON.stringify(body4)
                            };
                            fetch(config.auth.server_url_api + 'api/Solicitud/SolicitudCrear', requestOptions)
                                .then((response) => response.json())
                                .then((data) => {


                                    this.solicituddata = data;
                                    console.log('solicitudid', this.solicituddata.idSolicitud)
                                    console.log('solicitud', this.solicituddata, this.solicituddata.idSolicitud)
                                    this.esdirigenteSolAct = false
                                    this.crearPersonaSolicitudHist();
                                })
                                .catch(error => {
                                    console.error('Error:', error)
                                });
                            //    .then(async response => {

                            //        if (response.status == 200) {

                            //            console.log('creacion solicitud')

                            //        }
                            //        else {
                            //            this.$swal.fire({
                            //                text: 'Se genero un error al editar  valide con su administrador',
                            //                icon: 'warning',
                            //                confirmButtonText: 'Ok',
                            //                timer: 3000,
                            //            });
                            //        }
                            //    })
                            //    .catch(error => {
                            //        this.errorMessage = error;
                            //        console.error('There was an error!', error);
                            //    });
                            //this.update();


                        }

                    }

                }

            },

            update() {
                //debugger
                if (this.reingreso == true) {
                    this.actualizapersonaestatus = true


                }
                else {
                    this.actualizapersonaestatus = this.persona.estatusPersona
                }

                var body = {
                    idPersona: this.persona.idPersona,
                    nombrePersona: this.persona.nombrePersona,
                    estatusPersona: this.actualizapersonaestatus == 1 ? true : false,
                    idTipoPersona: this.selectedTipoPersona,
                    idCargo: this.persona.idCargo,
                    idSubUnidadOperativa: 1,
                    idGenero: this.selectedgenero,
                    idEstadoCivil: this.selectedestadocivil,
                    idOficio: this.persona.idOficio,
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
                    dirigente: this.persona.dirigente == 1 ? true : false,
                    idDirigente: this.persona.idDirigente,
                    idRepresententanteCargoCat: 1,
                    idProfesion: this.selectedProfesion,
                    calle: this.persona.calle,
                    numeroInterior: this.persona.numeroInterior,
                    colonia: this.persona.colonia,
                    estado: this.persona.estado,
                    municipio: this.persona.municipio,
                    plaza: this.persona.plaza,
                    sucursal: this.persona.sucursal,
                    correoPersonal: this.persona.correoPersonal,
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
                fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/PersonaUpdate', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            //this.$emit("closeEditModal");
                            //this.$emit("reloadDataTable");
                            //this.$emit("showSuccessAlert");
                            //this.onSelectedExpediente();
                            console.log('updateok')
                        }
                        else {
                            this.isLoading = false;
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

            fechaFormato(fecha) {

                let ano = new Date(fecha).getFullYear();
                let mes = new Date(fecha).getMonth() + 1;
                let dia = new Date(fecha).getDate();

                mes = mes < 10 ? "0" + mes : mes;
                dia = dia < 10 ? "0" + dia : dia;


                let salida = dia + '/' + mes + '/' + ano;
                //console.log('Sal', salida)
                return salida;

            },
            formatDate(value) {
                return moment(value).format('DD/MM/YYYY');
            },
            ObtenerEscolaridad() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoEscolaridad/ObtenerEscolaridadActivo', { headers })
                    .then((response) => response.json())
                    .then((data) => {


                        this.escolaroptions = data;

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
                       // console.log('profesion', this.optProfesiones )
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
                        console.log('optionsTiposPersona', this.optionsTiposPersona)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            ObtenerGenero() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoGenero/ConsultarActivo', { headers })
                    .then((response) => response.json())
                    .then((data) => {

                        this.generooptions = data;
                        console.log('ObtenerGenero', this.generooptions)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });

            },
            ObtenerEstadoCivil() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoEstadoCivil/ConsultarActivo', { headers })
                    .then((response) => response.json())
                    .then((data) => {

                        this.estadociviloptions = data;
                        console.log('ObtenerGenero', this.estadociviloptions)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });

            },



            onChangeClasificacion() {
                console.log('hola', this.selectedProfesion)
                this.ObtenerClasificacion();
                this.selecteClasificacion = this.selectedProfesion
            },
            ObtenerClasificacion() {
                const requestOptions = {
                    method: 'PUT',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.selectedProfesion)
                };
                console.log('obtenerclas', this.selectedProfesion)
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

            ObtenerRepresentantePlaza() {
                console.log('idplaza', this.persona.idPlaza)
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.persona.idPlaza)
                };


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
   

            getDataByID() {

                console.log('idpersona table', this.persona.idPersona)
                const requestOptions = {
                    method: 'PUT',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.persona.idPersona)
                };


                fetch(config.auth.server_url_api + 'api/PersonaPerfilCargoOrgano/ConsultarPersonaCargoOrganobyid', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {

                        this.items = data;
                        console.log('getdatatable', this.items)
                        this.Organotable = true
                    })
                    .catch(error => {
                        //this.MensajeError(error) //fechaActual(
                        console.log(error)
                        this.Organotable = false
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
                };
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
                        //this.MensajeError(error) //fechaActual(
                        console.log(error)
                        this.permisoSolicitud = false
                        console.log('No es odg', this.permisoSolicitud)

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
                console.log('correo', this.correoDirigente)

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


                    });



            },
           
            DescargarExpediente() {

                console.log('file1', this.file1)
                let [a, b] = this.file1.split('.')
                this.archivo.Extension = "."+b
                this.archivo.Nombre= a
                console.log('extension', this.archivo.Extension)
                console.log('nombre', this.archivo.Nombre)
                console.log('extension', this.archivo)
                HTTP.post(  `api/Dirigentes/DescargarDocumento`,
                    this.archivo
                    ,
                    {
                        responseType: 'blob',
                        headers: {
                            //'Content-Type': 'application/octet-stream',
                            //'Content-Type': 'application/json',
                            //'Response-Type': 'blob' // important
                            //'Response-Type': 'arraybuffer'
                        }
                    }).then(response => {
                        const url = window.URL.createObjectURL(new Blob([response.data]));
                        const link = document.createElement('a');
                        link.href = url;
                        link.setAttribute('download', this.archivo.Nombre + this.archivo.Extension);
                        document.body.appendChild(link);
                        link.click();
                    }).catch(error => {
                        this.MensajeError("Ocurrio un problema al cargar el archivo: " + error);
                    });
            },
            DescargarCurriculum() {
                console.log('file1', this.file2)
                let [a, b] = this.file2.split('.')
                this.archivo.Extension = "." + b
                this.archivo.Nombre = a
                console.log('extension', this.archivo.Extension)
                console.log('nombre', this.archivo.Nombre)
                console.log('extension', this.archivo)
                //HTTP.post(config.auth.server_url_api + `./api/Dirigentes/DescargarDocumento`,
                HTTP.post( `api/Dirigentes/DescargarDocumento`,
                    this.archivo
                    ,
                    {
                        responseType: 'blob',
                        headers: {
                            //'Content-Type': 'application/octet-stream',
                            //'Content-Type': 'application/json',
                            //'Response-Type': 'blob' // important
                            //'Response-Type': 'arraybuffer'
                        }
                    }).then(response => {
                       // debugger
                        const url = window.URL.createObjectURL(new Blob([response.data]));
                        const link = document.createElement('a');
                        link.href = url;
                        link.setAttribute('download', this.archivo.Nombre + this.archivo.Extension);
                        document.body.appendChild(link);
                        link.click();
                    }).catch(error => {
                        this.MensajeError("Ocurrio un problema al cargar el archivo: " + error);
                    });
            },


            getFile(event) {


                
                const nombre = event.target.files[0].name;
                let extension = nombre.split('.');
                let size = extension.length;
                if (extension[size - 1].toString() != "zip") {
                    this.file1 = false
                    this.MensajeError("Tipo de archivo invalido");

                }
                else {
                    this.file1 = event.target.files[0];
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


                let fileData = new FormData();
                //debugger
                console.log('file', this.file1.name)
                console.log('file', this.file2.name)
                if (this.file1.name == 0 || this.file1.name == null || this.file1.name == '' || this.file1.name == undefined
                    && this.file2.name == 0 || this.file2.name == null || this.file2.name == '' || this.file2.name == undefined)
                {
                    //console.log('Archivos no actualizados')
                      
                    if ( this.file2.name != undefined) {
                     fileData.append('file', this.file2, this.file2.name);
                     console.log('filedata', fileData)
                     HTTP.post(`api/Dirigentes/AgregarDocumentoUpdate`,
                         fileData,
                         {
                             headers: {
                                 'Content-Type': 'multipart/form-data'
                             }
                         }).then(response => {
                             this.MensajeSuccess("Archivo cargado: " + response.data);
                             //alert(`Total Mock File Uploaded: ${response.data}`);
                             this.UpdateArchivos();
                         }).catch(error => {
                             this.MensajeError("Ocurrio un problema al cargar el archivo: " + error);
                             //alert(`something went wrong: ${error}`);
                         });
                    }
                    if(this.file1.name != undefined) {
                        fileData.append('file', this.file1, this.file1.name);
                        console.log('filedata', fileData)
                        HTTP.post(`api/Dirigentes/AgregarDocumentoUpdate`,
                            fileData,
                            {
                                headers: {
                                    'Content-Type': 'multipart/form-data'
                                }
                            }).then(response => {
                                this.MensajeSuccess("Archivo cargado: " + response.data);
                                //alert(`Total Mock File Uploaded: ${response.data}`);
                                this.UpdateArchivos();
                            }).catch(error => {
                                this.MensajeError("Ocurrio un problema al cargar el archivo: " + error);
                                //alert(`something went wrong: ${error}`);
                            });
                    }
                }
                else { 
                fileData.append('file', this.file1, this.file1.name);
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
                        this.UpdateArchivos();
                    }).catch(error => {
                        this.MensajeError("Ocurrio un problema al cargar el archivo: " + error);
                        //alert(`something went wrong: ${error}`);
                    });
                }

            },
            UpdateArchivos() {
                //debugger
                console.log('cargaArchivo')

                
                if ( this.file1.name != undefined && this.file2.name != undefined) {
                    var body2 = {
                        expedienteDigital: this.file1.name,
                        curriculum: this.file2.name,
                        estatus: true,
                        idPersona: this.persona.idPersona

                    }
                    console.log('body', body2)
                    const requestOptions = {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                        body: JSON.stringify(body2)
                    };


                    fetch(config.auth.server_url_api + 'api/Dirigentes/crear', requestOptions)
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



                }
                else {
                    if (this.file1.name == 0 || this.file1.name == null || this.file1.name == undefined) {
                        var body3 = {
                            expedienteDigital: this.file1,
                            curriculum: this.file2.name,
                            estatus: true,
                            idPersona: this.persona.idPersona

                        }
                        console.log('body', body3)
                        const requestOptions = {
                            method: 'POST',
                            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                            body: JSON.stringify(body3)
                        };


                        fetch(config.auth.server_url_api + 'api/Dirigentes/Update', requestOptions)
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

                    }
                    else {
                        var body4 = {
                            expedienteDigital: this.file1.name,
                            estatus: true,
                            idPersona: this.persona.idPersona,
                            curriculum: this.file2,

                        }
                        console.log('body', body4)
                        const requestOptions = {
                            method: 'POST',
                            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                            body: JSON.stringify(body4)
                        };


                        fetch(config.auth.server_url_api + 'api/Dirigentes/Update', requestOptions)
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


                    }

                }
              
               

            },
            crearPersonaSolicitudHist() {
                console.log('crearPersonaSolicitudHist', this.persona, this.persona.sucursalId)
                let ano = new Date(this.finPeriodo).getFullYear();
               
                //debugger
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
                    idPlaza: this.persona.idPlaza,
                    idSucursal: this.persona.idSucursal,
                    sucursal: this.persona.sucursal,
                    correoPersonal: this.persona.correoPersonal,
                    fechaCreacion: this.persona.fechaIngreso,
                    cuentaMexicana: this.persona.cuentaMexicana,
                    expediente: this.file1.name,
                    curriculum: this.file2.name,
                    idSolicitud: this.solicituddata.idSolicitud,
                    estatusPersonSolicitud: true,
                     //niveldirigencial
                    idNivelDirigencialCat : this.selectedNivelDirigenciales,
                    FechaIngresoNivel:this.FechaIngresoNivel,
                    estatusNivelDirigencial:true,
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

                            this.$emit("closeEditModal");
                            this.$emit("reloadDataTable");
                            this.$emit("showSuccessAlert");
                           // this.UpdateNivelDirigencialbyid();
                            this.onSelectedExpediente();
                            this.isLoading = false;

                        }
                        else {
                            this.MensajeError('Error valide con su administrador')
                            this.isLoading = false;
                        }
                    })
                    .catch(error => {
                        this.errorMessage = error;
                        console.error('Error valide con su administrador', error);
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
                    console.log('fecha hoy', this.fechaactual, 'año', this.finPeriodo)
                }
            })
            .catch(function (error) {
               // this.MensajeError(error);
               console.log(error);
            });
        },
        getday(){
            //var myDate = new Date();
        //this.FinPeriodo=(myDate.getFullYear() + '-' +('0' + (myDate.getMonth()+1)).slice(-2)+ '-' +  ('0' + myDate.getDate()).slice(-2));
        this.fechaactual= new Date().getTime();
        //(myDate.getFullYear() + '-' +('0' + (myDate.getMonth()+1)).slice(-2)+ '-' +  ('0' + myDate.getDate()).slice(-2) + ' '+myDate.getHours()+ ':'+('0' + (myDate.getMinutes())).slice(-2)+ ':'+myDate.getSeconds())
        
        },
        getAntiguedad(value){
        
            var getant = new Date(value).getTime()
                console.log('Antiguedad', this.fechaactual, getant)
                this.antiguedad  =Math.round((this.fechaactual - getant)/(1000*60*60*24)-1)
                //console.log('Antiguedad', this.antiguedad)

        },
        ObtenerNivelDirigencialbyid(){
    //console.log('idpersonanivel', this.persona.idPersona)
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
        body: JSON.stringify(this.id)
    };
    fetch(config.auth.server_url_api + 'api/NivelDirigencia/RegistrobyIdPersona', requestOptions)
        .then((response) => response.json())
        .then((data) => {
            this.nivelDirigencial = data;

            var myDate = new Date();
            console.log('nivel dirigencial',this.nivelDirigencial )
            this.selectedAnoPeriodo = this.nivelDirigencial.aperiodo
            this.FechaIngresoNivel  = this.nivelDirigencial.fechaIngreso
            this.selectedNivelDirigenciales =this.nivelDirigencial.idNivelDirigencialCat
            this.finPeriodo = (this.nivelDirigencial.finPeriodo + '-' +('0' + (myDate.getMonth()+1)).slice(-2)+ '-' +  ('0' + myDate.getDate()).slice(-2))
            this.selectedPeriodo= this.nivelDirigencial.periodo== 'Primero' ? 1 : 2
            this.selectedcondicoines= this.nivelDirigencial.idCondicionIngreso
            console.log('finPeriodo',this.finPeriodo )
        })
        .catch(error => {
            //this.MensajeError(error) //fechaActual(
            console.log(error)
            
        });                                            

        },
        UpdateNivelDirigencialbyid(){
            //debugger
            let ano = new Date(this.finPeriodo).getFullYear();
            console.log('periodo',ano, this.finPeriodo)
                    var body = {
            idNivelDirigencialCat : this.selectedNivelDirigenciales,
            idPersona: this.persona.idPersona,
            fechaIngreso:this.FechaIngresoNivel,
            finPeriodo: ano,
            periodo: this.selectedPeriodo == 1 ? 'Primero' : 'Segundo',
            Aperiodo: this.selectedAnoPeriodo,
            idCondicionIngreso: this.selectedcondicoines,
            idNivelDirigencial: this.nivelDirigencial.idNivelDirigencial,         
            }
            
        console.log('body', body)
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
            body: JSON.stringify(body)
        };
        fetch(config.auth.server_url_api + 'api/NivelDirigencia/CrearOModificar', requestOptions)
            .then(async response => {
                if (response.status == 200) {
                      console.log('updateok')
                }
                else {
                    this.isLoading = false;
                    this.MensajeError(this.$messageConstants('Error al guardar Nivel Dirigencial'))
                }
            })
            .catch(error => {
                this.errorMessage = error;
                console.error('There was an error!', error);
            });
        
        }


        },
    };
</script>
