<template>
    <b-form class="mt-auto">
        <b-card class="mb-2" header-bg-variant="light">
            <b-card-body>
                <b-row align-h="end"><h3 class="text-success">Solicitud {{idsolicitud}}</h3></b-row>
                <h2>Datos Generales: </h2>
                <hr />
                <b-row>
 <b-iconstack font-scale="1" class="m-0 p-0" >
                    <b-icon stacked icon="exclamation-circle-fill" variant="warning" 
                                v-if="showpersona.apellidoPaterno"></b-icon>
                    </b-iconstack>
                    <b-col cols="4" >
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  
                                v-if="showpersona.apellidoMaterno"></b-icon>
                    </b-iconstack>
                    <b-col cols="4" >
                        <b-form-group id="Apellido Materno"
                                      label="Apellido Materno"
                                      label-for="apellidoMaterno">
                            <b-form-input id="apellidoMaterno"
                                          type="text"
                                          v-model="persona.apellidoMaterno"></b-form-input>
                        </b-form-group>
                    </b-col>
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.nombrePersona"></b-icon>
                    </b-iconstack>
                    <b-col cols="3">
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.fechaNacimiento"></b-icon>
                    </b-iconstack>
                    <b-col cols="4" >
                        <b-form-group id="fecha_nacimiento"
                                      label="Fecha Nacimiento"
                                      label-for="fechaNacimiento">
                            <b-form-input id="fechaNacimiento"
                                          type="text"
                                          v-model="fechaNacimientoformato"
                                          disable></b-form-input>
                        </b-form-group>
                    </b-col>
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.edad"></b-icon>
                    </b-iconstack>
                    <b-col cols="4" >
                        <b-form-group id="edad_"
                                      label="Edad"
                                      label-for="edad">

                            <b-form-input id="edad"
                                          type="text"
                                          v-model="persona.edad"
                                          disabled></b-form-input>
                        </b-form-group>
                    </b-col>
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.rfc"></b-icon>
                    </b-iconstack>
                    <b-col cols="3" >
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.curp"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.cif"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.idDirigente"></b-icon>
                    </b-iconstack>
                    <b-col cols="3">
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.plaza"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.sucursal"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.fechaIngreso"></b-icon>
                    </b-iconstack>
                    <b-col cols="3">
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.idGenero"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.idEstadoCivil"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.participacion"></b-icon>
                    </b-iconstack>
                    <b-col cols="3" >
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.correoPersonal"></b-icon>
                    </b-iconstack>
                    <b-col cols="4">
                        <b-form-group id="correo_acceso"
                                      label="Correo"
                                      label-for="correoAcceso">

                            <b-form-input id="correoAcceso"
                                          type="text"
                                          v-model="persona.correoPersonal"></b-form-input>
                        </b-form-group>
                    </b-col>
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning"  v-if="showpersona.celular"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.calle"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.numeroInterior"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.codigoPostal"></b-icon>
                    </b-iconstack>
                    <b-col cols="3">
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.colonia"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.estado"></b-icon>
                    </b-iconstack>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.municipio"></b-icon>
                    </b-iconstack>
                    <b-col cols="3">
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
                <h2>Informaci&oacute;n Acad&eacute;mica: </h2>
                <hr />
                <b-row class="mb-3">
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.idEscolaridad"></b-icon>
                    </b-iconstack>
                    <b-col cols="2"><b> Escolaridad: </b></b-col>
                    <b-col cols="3 p-1">
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
                    <b-col col-1></b-col>
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.idProfesion"></b-icon>
                    </b-iconstack>
                    <b-col cols="2"><b> Profesi&oacute;n: </b></b-col>
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.idProfesion"></b-icon>
                    </b-iconstack>
                    <b-col cols="2"><b> Clasificacion: </b></b-col>
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
                <b-row class="mb-3">
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.expedienteDigital"></b-icon>
                    </b-iconstack>
                    <b-col cols="2 "><b> Expediente Digital: </b></b-col>
                    <b-col cols="3 p-0 ">
                        <validation-provider name="Expediente"
                            :rules="{ required: true}"
                            v-slot="validationContext">
                        <b-form-file v-model="file1"
                                     :placeholder="file1"
                                     browse-text="Agregar"
                                     drop-placeholder="Expediente"
                                     accept=".zip"
                                     :state="Boolean(file1)"
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
                    <b-iconstack font-scale="1" class="m-0 p-0">
                        <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.curriculum"></b-icon>
                    </b-iconstack>
                    <b-col cols="2"><b> Curriculum Vitae: </b></b-col>
                    <b-col cols="3 p-0">
                        <validation-provider name="Curriculum"
                            :rules="{ required: true}"
                            v-slot="validationContext">
                        <b-form-file v-model="file2"
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
      <b-card>
        <b-card-text>
            <b-row>
    <b-card-sub-title class="mb-2 p-1">
        <h5>Formaci&oacute;n como Dirigente:</h5>
    </b-card-sub-title>
    <hr />
</b-row>
        <b-row class="mb-3">
            <b-iconstack font-scale="1" class="m-0 p-0">
            <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.idNivelDirigencialCat"></b-icon>
        </b-iconstack>
                <b-col cols="2"><b> Nivel Dirigencial: </b></b-col>
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
                <b-iconstack font-scale="1" class="m-0 p-0">
                    <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.periodo"></b-icon>
                </b-iconstack>
                <b-col cols="2"><b> Periodo: </b></b-col>
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
                <b-iconstack font-scale="1" class="m-0 p-0">
                    <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.fechaIngresoNivel"></b-icon>
                </b-iconstack>
                <b-col cols="2" class="mb-2"><b>Fecha de ingreso a nivel:</b></b-col>
                <b-col cols="3" class="mb-2">
                    <validation-provider name="Fecha de ingreso a Nivel"
                        :rules="{ required: true}"
                        v-slot="validationContext">
                    <b-form-datepicker v-model="fechaIngresoNivel" locale="es-MX"
                               placeholder="Selecciona una fecha"
                               :date-format-options="{ year: 'numeric', month: '2-digit', day: '2-digit' }"
                               :state="getValidationState(validationContext)"
                               >
                    </b-form-datepicker>
                    <b-form-invalid-feedback id="input-1-live-feedback">{{ validationContext.errors[0] }}</b-form-invalid-feedback>
                    </validation-provider>
                </b-col>
                <b-iconstack font-scale="1" class="m-0 p-0">
                    <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.aperiodo"></b-icon>
                </b-iconstack>
                <b-col cols="2" class="mb-2"><b>Año del Periodo:</b></b-col>
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
                <b-iconstack font-scale="1" class="m-0 p-0">
                    <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.idCondicionIngreso"></b-icon>
                </b-iconstack>
                <b-col cols="2" class="mb-2"><b>Condici&oacute;n de Ingreso:</b></b-col>
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
                <b-iconstack font-scale="1" class="m-0 p-0">
                    <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.finPeriodo"></b-icon>
                </b-iconstack>
                <b-col cols="2" class="mb-2"><b>Fin del periodo:</b></b-col>
                <b-col cols="3" class="mb-2">
                    <Datepicker
                    format="yyyy"
                    minimum-view="year"
                    v-model="finPeriodo"
                    ></Datepicker>                                                                                                                                                                                                                                                                                                                                                                                                             
                    
                </b-col>        
            </b-row>
            <b-row> 
                <b-iconstack font-scale="1" class="m-0 p-0">
                    <b-icon stacked icon="exclamation-circle-fill" variant="warning" v-if="showpersona.fechaIngresoNivel"></b-icon>
                </b-iconstack>
                <b-col cols="2" class="mb-2"><b>Antig&#252;edad:</b><div>(días)</div></b-col>                                    
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
                <b-row align-h="center" class="mt-4">        
                    <b-col cols="mb-3 p-2">
                    <b-button variant="success" @click="crearPersonaSolicitudHist">Guardar</b-button>
                    </b-col>
                    <b-row class="justify-content-md-center">
               </b-row>
               <loading-overlay :active='isLoading' color='#008000' />
        </b-row>
      </b-card>
    </b-form>
</template>

<script>

  import moment from 'moment';
  import { config } from "@/config/auth";
  import { HTTP } from '@/plugins/axios'
  import store from '@/store'


    export default {
        name: "DetalleSolicitud",
        watch:{
            fechaIngresoNivel (value, olValue){
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

        },
        props: {
            idsolicitud: {
                type: Number,
                required: true,
            },
            idpersonanivel:{
                type: Number,
                required: true,
            }
            

        },
        data() {
            return {
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
                fechaNacimientoformato: '',
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
                //alertamodificaci
                actualizapersonaestatus: '',
                showpersona: {},
                 //formacion como dirigente
                selectedcondicoines:null,
                optioncondicoines:[],
                selectedNivelDirigenciales:null,
                optionNivelDirigenciales:[],
                selectedPeriodo:null,
                optPeriodos:[{id:1, text:'Primero'}, {id:2, text:'Segundo'}],
                fechaIngresoNivel:'',
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
            this.ObtenerEscolaridad();
            this.ObtenerProfesion();
            this.ObtenerTipoPersona();
            this.ObtenerCambiosPersona();
            this.ObtenerEsODG();
            this.ObtenerPlazaSolicitante();
            this.ObtenerGenero();
            this.ObtenerEstadoCivil();
            this.ObtenercondicionIngreso();
            this.ObtenerNivelDirigencialCat();
            //this.ObtenerNivelDirigencialbyid();
          

        },



        
        methods: {
            triggerClose() {
                this.$emit("closeEditModal");
            },
            getValidationState({ dirty, validated, valid = null }) {
                return dirty || validated ? valid : null;
            },
            getByID() {
                console.log('IDSOLICITUD', this.idsolicitud)
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.idsolicitud)
                };

                console.log('reingreso', this.reingreso)

                fetch(config.auth.server_url_api + 'api/PersonaSolicitudHist/RegistrobyIdsolicitud', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {
                        //debugger
                        this.persona = data;

                        var myDate = new Date();
                        console.log("persona:------solicitud>", this.persona, this.persona.fechaIngresoNivel)
                        //this.persona.fechaNacimiento = this.formatDate(this.persona.fechaNacimiento);
                        //this.persona.fechaIngreso = this.fechaFormato(this.persona.fechaIngreso);
                        this.selectedescolar = this.persona.idEscolaridad
                        this.selectedProfesion = this.persona.idProfesion
                        this.selecteClasificacion = this.selectedProfesion
                        this.selectedTipoPersona = this.persona.idTipoPersona
                        this.selectedgenero = this.persona.idGenero
                        this.selectedestadocivil = this.persona.idEstadoCivil
                        this.file1 = this.persona.expedienteDigital
                        this.file2 = this.persona.curriculum
                        this.selectedAnoPeriodo = this.persona.aperiodo
                        this.fechaIngresoNivel  = this.persona.fechaIngresoNivel
                        this.selectedNivelDirigenciales =this.persona.idNivelDirigencialCat
                        this.finPeriodo = (this.persona.finPeriodo + '-' +('0' + (myDate.getMonth()+1)).slice(-2)+ '-' +  ('0' + myDate.getDate()).slice(-2))
                        this.selectedPeriodo= this.persona.periodo== 'Primero' ? 1 : 2
                        this.selectedcondicoines= this.persona.idCondicionIngreso
                        this.selectedparticipacion = this.persona.participacion
                        console.log("persona:sle", this.selectedAnoPeriodo, this.fechaIngresoNivel)
                        this.fechaNacimientoformato = this.formatDate(this.persona.fechaNacimiento)
                        this.fechaIngresoformato = this.fechaFormato(this.persona.fechaIngreso)
                        
                        
                        
                        
                        
                        
                        
                        this.ObtenerClasificacion()
                        



                    })
                    .catch(error => {
                        console.error('Error:', error)
                        this.Organotable = false
                    });
            },


            ObtenerEscolaridad() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoEscolaridad/ObtenerEscolaridadActivo', { headers })
                    .then((response) => response.json())
                    .then((data) => {


                        this.escolaroptions = data;

                        //console.log('escolaridad', this.escolaroptions)
                    })
                    .catch(error => {
                        console.error('Error:', error)
                    });
            },
            ObtenerProfesion() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoProfesion/Consultar', { headers })
                    .then((response) => response.json())
                    .then((data) => {


                        this.optProfesiones = data;
                        //console.log('profesion', this.optProfesiones )
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
            ObtenerGenero() {
                const headers = { 'Authorization': 'Bearer ' + store.getters['user/getToken'] };
                fetch(config.auth.server_url_api + 'api/CatalogoGenero/ConsultarActivo', { headers })
                    .then((response) => response.json())
                    .then((data) => {

                        this.generooptions = data;
                        //console.log('ObtenerGenero', this.generooptions)
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
                        //console.log('ObtenerGenero', this.estadociviloptions)
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

           


          
            formatDate(value) {
                return moment(value).format('DD/MM/YYYY');
            },
            formatDated(value) {
                return moment(value).format('DD-MM-YYYY');
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
            ObtenerCambiosPersona() {
                console.log('IDSOLICITUD', this.idsolicitud)
                const requestOptions = {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
                    body: JSON.stringify(this.idsolicitud)
                };
                fetch(config.auth.server_url_api + 'api/PersonaSolicitudHist/CompararPersonaSolHistbyIdsolicitud', requestOptions)
                    .then((response) => response.json())
                    .then((data) => {


                        this.showpersona = data;

                        console.log('personacompara', this.showpersona)
                    })
                    .catch(error => {
                        console.error('Error:', error)
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

                    if (this.file1.name == 0 || this.file1.name == null || this.file1.name == '' || this.file1.name == undefined ) {
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
                    else {
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

            DescargarExpediente() {

                console.log('file1', this.file1)
                let [a, b] = this.file1.split('.')
                this.archivo.Extension = "."+b
                this.archivo.Nombre= a
                console.log('extension', this.archivo.Extension)
                console.log('nombre', this.archivo.Nombre)
                console.log('extension', this.archivo)
                HTTP.post(config.auth.server_url_api + `./api/Dirigentes/DescargarDocumento`,
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
                HTTP.post(config.auth.server_url_api + `./api/Herramientas/DescargarDocumento`,
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

            crearPersonaSolicitudHist() {
                this.isLoading = true
                console.log('crearPersonaSolicitudHist', this.persona)
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
                    dirigente: this.persona.dirigente,
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
                    idSolicitud: this.idsolicitud,
                    estatusPersonSolicitud: true,
                    //niveldirigencial
                    idNivelDirigencialCat : this.selectedNivelDirigenciales,
                    fechaIngresoNivel:this.fechaIngresoNivel,
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
                fetch(config.auth.server_url_api + 'api/PersonaSolicitudHist/ModificarPersonaSolicitudHist', requestOptions)
                    .then(async response => {

                        if (response.status == 200) {
                            console.log('PersonaSolicitudHis creada')

                            //this.$emit("closeCreateModal");
                            //this.$emit("reloadDataTable");
                            this.onSelectedExpediente();
                            this.$emit("showSuccessAlert");
                            this.$emit("detalles")
                    
                            this.isLoading = false


                        }
                        else {
                            this.MensajeError('Error valide con su administrador')
                        }
                    })
                    .catch(error => {
                        this.errorMessage = error;
                        console.error('Error valide con su administrador', error);
                        this.isLoading = false
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
           
    console.log('idpersonanivel',this.idpersonanivel )
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + store.getters['user/getToken'] },
        body: JSON.stringify(this.idpersonanivel)
    };
    fetch(config.auth.server_url_api + 'api/NivelDirigencia/RegistrobyIdPersona', requestOptions)
        .then((response) => response.json())
        .then((data) => {
            this.nivelDirigencial = data;
            
            var myDate = new Date();
            console.log('nivel dirigencial',this.nivelDirigencial )
            this.selectedAnoPeriodo = this.nivelDirigencial.aperiodo
            this.fechaIngresoNivel  = this.nivelDirigencial.fechaIngreso
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
        

        },

    };
</script>
