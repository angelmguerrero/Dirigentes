<template>
    <b-list-group id="lstNiveles" style="text-align: right;" flush>
        <ul v-for="(nivel, cnt) in niveles"
            v-bind:key="cnt">
            <li>
                <b-row>
                    <b-col cols="1">
                        <label>{{nivel.indice}}</label>
                    </b-col>
                    <b-col cols="8">
                        <b-form-input id="txtNivelPrincipal"
                                      type="text" v-model="nivel.descripcion"></b-form-input>
                    </b-col>
                    <b-col cols="3" >
                        <b-button-group size="sm">
                            <b-button id="btnEliminarNivel" size="sm" v-if="nivel.indice != 1" variant="outline-danger" @click="deleteNivel(cnt)" style="margin-right: 2px;">
                                <i class="fa-solid fa-minus"></i>
                            </b-button>
                            <b-button id="btnAgregarNivel" size="sm" variant="outline-success" @click="addNivel" v-b-tooltip.hover title="Agregar Nivel" style="margin-right: 2px;">
                                <i class="fa-solid fa-plus"></i>
                            </b-button>
                            <b-button id="btnAgregarSubNivel" size="sm" v-model="nivel.id" class="fa-solid fa-plus" variant="outline-success" @click="addSubNivel(nivel.idConsecutivoPadre,cnt)" v-b-tooltip.hover title="Agregar SubNivel">
                                <i class="fa-solid fa-plus"></i>
                            </b-button>
                        </b-button-group>
                    </b-col>
                </b-row>
                <ul v-for="(subnivel, counter) in niveles[cnt].niveles"
                    v-bind:key="counter">
                    <li>
                        <b-row>
                            <b-col cols="1">
                                <label>{{subnivel.indice}}</label>
                            </b-col>
                            <b-col cols="8">
                                <b-form-input id="txtNivelPrincipal"
                                              type="text" v-model="subnivel.descripcion"></b-form-input>
                            </b-col>
                            <b-col cols="3" >
                                <b-button-group size="sm">
                                    <b-button id="btnEliminarNivel" size="sm" variant="outline-danger" @click="deleteSubNivel(cnt, counter)" style="margin-right: 2px;">
                                        <i class="fa-solid fa-minus"></i>
                                    </b-button>
                                    <b-button id="btnAgregarSubNivel" size="sm" v-model="subnivel.id" class="fa-solid fa-plus" variant="outline-success" @click="addSubNivel2(subnivel.idConsecutivoPadre,cnt,counter)">
                                        <i class="fa-solid fa-plus"></i>
                                    </b-button>
                                </b-button-group>
                            </b-col>
                        </b-row>
                        <ul v-for="(subnivel1, counter1) in niveles[cnt].niveles[counter].niveles"
                            v-bind:key="counter1">
                            <li>
                                <b-row>
                                    <b-col cols="1">
                                        <label>{{subnivel1.indice}}</label>
                                    </b-col>
                                    <b-col cols="8">
                                        <b-form-input id="txtNivelPrincipal"
                                                      type="text" v-model="subnivel1.descripcion"></b-form-input>
                                    </b-col>
                                    <b-col cols="3">
                                        <b-button-group size="sm">
                                            <b-button id="btnEliminarNivel" size="sm" variant="outline-danger" @click="deleteSubNivel1(cnt,counter,counter1)" style="margin-right: 2px;">
                                                <i class="fa-solid fa-minus"></i>
                                            </b-button>
                                            <b-button id="btnAgregarSubNivel" size="sm" class="fa-solid fa-plus" v-model="subnivel1.id" variant="outline-success" @click="addSubNivel3(subnivel1.idConsecutivoPadre,cnt,counter,counter1)">
                                                <i class="fa-solid fa-plus"></i>
                                            </b-button>
                                        </b-button-group>
                                    </b-col>
                                </b-row>
                                <ul v-for="(subnivel2, counter2) in niveles[cnt].niveles[counter].niveles[counter1].niveles"
                                    v-bind:key="counter2">
                                    <li>
                                        <b-row>
                                            <b-col cols="1">
                                                <label>{{subnivel2.indice}}</label>
                                            </b-col>
                                            <b-col cols="8">
                                                <b-form-input id="txtNivelPrincipal"
                                                              type="text" v-model="subnivel2.descripcion"></b-form-input>
                                            </b-col>
                                            <b-col cols="3">
                                                <b-button-group size="sm">
                                                    <b-button id="btnEliminarNivel" size="sm" variant="outline-danger" @click="deleteSubNivel2(cnt,counter,counter1,counter2)" style="margin-right: 2px;">
                                                        <i class="fa-solid fa-minus"></i>
                                                    </b-button>
                                                    <b-button id="btnAgregarSubNivel" size="sm" class="fa-solid fa-plus" v-model="subnivel2.id" variant="outline-success" @click="addSubNivel4(subnivel2.idConsecutivoPadre,cnt,counter,counter1,counter2)">
                                                        <i class="fa-solid fa-plus"></i>
                                                    </b-button>
                                                </b-button-group>
                                            </b-col>
                                        </b-row>
                                        <ul v-for="(subnivel3, counter3) in niveles[cnt].niveles[counter].niveles[counter1].niveles[counter2].niveles"
                                            v-bind:key="counter3">
                                            <li>
                                                <b-row>
                                                    <b-col cols="1">
                                                        <label>{{subnivel3.indice}}</label>
                                                    </b-col>
                                                    <b-col cols="8">
                                                        <b-form-input id="txtNivelPrincipal"
                                                                      type="text" v-model="subnivel3.descripcion"></b-form-input>
                                                    </b-col>
                                                    <b-col cols="3">
                                                        <b-button-group size="sm">
                                                            <b-button id="btnEliminarNivel" size="sm" variant="outline-danger" @click="deleteSubNivel3(cnt,counter,counter1,counter2,counter3)" style="margin-right: 2px;">
                                                                <i class="fa-solid fa-minus"></i>
                                                            </b-button>
                                                            <b-button id="btnAgregarSubNivel" size="sm" class="fa-solid fa-plus" v-model="subnivel3.id" variant="outline-success" @click="addSubNivel5(subnivel3.idConsecutivoPadre,cnt,counter,counter1,counter2,counter3)">
                                                                <i class="fa-solid fa-plus"></i>
                                                            </b-button>
                                                        </b-button-group>
                                                    </b-col>
                                                </b-row>
                                                <ul v-for="(subnivel4, counter4) in niveles[cnt].niveles[counter].niveles[counter1].niveles[counter2].niveles[counter3].niveles"
                                                    v-bind:key="counter4">
                                                    <li>
                                                        <b-row>
                                                            <b-col cols="1">
                                                                <label>{{subnivel4.indice}}</label>
                                                            </b-col>
                                                            <b-col cols="8">
                                                                <b-form-input id="txtNivelPrincipal"
                                                                              type="text" v-model="subnivel4.descripcion"></b-form-input>
                                                            </b-col>
                                                            <b-col cols="3">
                                                                <b-button-group size="sm">
                                                                    <b-button id="btnEliminarNivel" size="sm" variant="outline-danger" @click="deleteSubNivel4(cnt,counter,counter1,counter2,counter3,counter4)">
                                                                        <i class="fa-solid fa-minus"></i>
                                                                    </b-button>
                                                                </b-button-group>
                                                            </b-col>
                                                        </b-row>
                                                    </li>
                                                </ul>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                </ul>
            </li>
        </ul>

    </b-list-group>
</template>

<script>

    //import { HTTP } from '@/plugins/axios'

    export default {
        name: 'NivelOrden',
        props: {
            idDetalle: Number,
        },
        data() {
            return {
                count: 1,
                niveles: [
                    {
                        idConsecutivoPadre: 1,
                        descripcion: '',
                        indice: '1',
                        idPadre: 0,
                        idPlantillaOrdenDia: 0,
                        niveles: []
                    }
                ],
                subNivel: false
            }
        },
        mounted() {
            this.generarIndices();

        },
        methods: {
            getNiveles() {
                this.$emit("niveles", this.niveles)
            },
            addNivel() {
                this.count = this.count + 1;
                this.subNivel = true;
                this.niveles.push({
                    idConsecutivoPadre: this.count,
                    descripcion: '',
                    indice: '',
                    idPadre: 0,
                    idPlantillaOrdenDia: 0,
                    niveles: []
                })
                this.generarIndices();
            },
            addSubNivel(idPadre, indice) {
                this.count = this.count + 1;
                this.subNivel = true;
                this.niveles[indice].niveles.push({
                    idConsecutivoPadre: this.count,
                    descripcion: '',
                    indice: '',
                    idPadre: idPadre,
                    idPlantillaOrdenDia: 0,
                    niveles: []
                })
                this.generarIndices();
            },
            addSubNivel2(idPadre, indice, indice1) {
                this.count = this.count + 1;
                this.subNivel = true;
                this.niveles[indice].niveles[indice1].niveles.push({
                    idConsecutivoPadre: this.count,
                    descripcion: '',
                    indice: '',
                    idPadre: idPadre,
                    idPlantillaOrdenDia: 0,
                    niveles: []
                })
                this.generarIndices();
            },
            addSubNivel3(idPadre, indice, indice1, indice2) {
                this.count = this.count + 1;
                this.subNivel = true;
                this.niveles[indice].niveles[indice1].niveles[indice2].niveles.push({
                    idConsecutivoPadre: this.count,
                    descripcion: '',
                    indice: '',
                    idPadre: idPadre,
                    idPlantillaOrdenDia: 0,
                    niveles: []
                })
                this.generarIndices();
            },
            addSubNivel4(idPadre, indice, indice1, indice2, indice3) {
                this.count = this.count + 1;
                this.subNivel = true;
                this.niveles[indice].niveles[indice1].niveles[indice2].niveles[indice3].niveles.push({
                    idConsecutivoPadre: this.count,
                    descripcion: '',
                    indice: '',
                    idPadre: idPadre,
                    idPlantillaOrdenDia: 0,
                    niveles: []
                })
                this.generarIndices();
            },
            addSubNivel5(idPadre, indice, indice1, indice2, indice3, indice4) {
                this.count = this.count + 1;
                this.subNivel = true;
                this.niveles[indice].niveles[indice1].niveles[indice2].niveles[indice3].niveles[indice4].niveles.push({
                    idConsecutivoPadre: this.count,
                    descripcion: '',
                    indice: '',
                    idPadre: idPadre,
                    idPlantillaOrdenDia: 0,
                    niveles: []
                })
                this.generarIndices();
            },
            deleteNivel(indice) {
                this.niveles.splice(indice, 1);
                this.generarIndices();
            },
            deleteSubNivel(indice, indice1) {
                this.niveles[indice].niveles.splice(indice1, 1);
                this.generarIndices();
            },
            deleteSubNivel1(indice, indice1, indice2) {
                this.niveles[indice].niveles[indice1].niveles.splice(indice2, 1);
                this.generarIndices();
            },
            deleteSubNivel2(indice, indice1, indice2, indice3) {
                this.niveles[indice].niveles[indice1].niveles[indice2].niveles.splice(indice3, 1);
                this.generarIndices();
            },
            deleteSubNivel3(indice, indice1, indice2, indice3, indice4) {
                this.niveles[indice].niveles[indice1].niveles[indice2].niveles[indice3].niveles.splice(indice4, 1);
                this.generarIndices();
            },
            deleteSubNivel4(indice, indice1, indice2, indice3, indice4, indice5) {
                this.niveles[indice].niveles[indice1].niveles[indice2].niveles[indice3].niveles[indice4].niveles.splice(indice5, 1);
                this.generarIndices();
            },
            generarIndices() {
                for (let c = 0; c < this.niveles.length; c++) {

                    this.niveles[c].indice = (c + 1).toString();
                    for (let c1 = 0; c1 < this.niveles[c].niveles.length; c1++) {
                        this.niveles[c].niveles[c1].indice = (c + 1).toString() + '.' + (c1 + 1).toString();

                        for (let c2 = 0; c2 < this.niveles[c].niveles[c1].niveles.length; c2++) {
                            this.niveles[c].niveles[c1].niveles[c2].indice = (c + 1).toString() + '.' + (c1 + 1).toString() + '.' + (c2 + 1).toString();

                            for (let c3 = 0; c3 < this.niveles[c].niveles[c1].niveles[c2].niveles.length; c3++) {
                                this.niveles[c].niveles[c1].niveles[c2].niveles[c3].indice = (c + 1).toString() + '.' + (c1 + 1).toString() + '.' + (c2 + 1).toString() + '.' + (c3 + 1).toString();

                                for (let c4 = 0; c4 < this.niveles[c].niveles[c1].niveles[c2].niveles[c3].niveles.length; c4++) {
                                    this.niveles[c].niveles[c1].niveles[c2].niveles[c3].niveles[c4].indice = (c + 1).toString() + '.' + (c1 + 1).toString() + '.' + (c2 + 1).toString() + '.' + (c3 + 1).toString() + '.' + (c4 + 1).toString();

                                    for (let c5 = 0; c5 < this.niveles[c].niveles[c1].niveles[c2].niveles[c3].niveles[c4].niveles.length; c5++) {
                                        this.niveles[c].niveles[c1].niveles[c2].niveles[c3].niveles[c4].niveles[c5].indice = (c + 1).toString() + '.' + (c1 + 1).toString() + '.' + (c2 + 1).toString() + '.' + (c3 + 1).toString() + '.' + (c4 + 1).toString() + '.' + (c5 + 1).toString();

                                    }
                                }
                            }
                        }
                    }

                }
                this.getNiveles();
            }
        }
    }

</script>

