<template>
    <b-list-group id="lstNiveles" flush>
        <b-list-group-item v-for="(applicant, counter) in applicants"
                           v-bind:key="counter">
            <b-row>
                <b-col sm="1">
                    <label v-if="primerNivel && subNivel == false">{{cont}}</label>
                    <label v-else>{{cont}}.{{applicant.consecutivo}}</label>
                </b-col>
                <b-col sm="9">
                    <b-form-input id="txtNivelPrincipal"
                                  type="text"></b-form-input>
                </b-col>
                <b-col sm="1">
                    <b-button id="btnAgregarNivel" variant="success" @click="addNivel">
                        <i class="fa-solid fa-plus"></i>
                    </b-button>
                </b-col>
                <b-col sm="1">
                    <b-button id="btnAgregarNivel" variant="danger" @click="deleteNivel(counter)">
                        <i class="fa-solid fa-minus"></i>
                    </b-button>
                </b-col>
            </b-row>
        </b-list-group-item>
    </b-list-group>
</template>

<script>

    export default {
        name: 'NivelOrden',
        props: {
            msg: String,
            cont: {
                type: Number,
                default: 0,
            },
            primerNivel: {
                type: Boolean,
                default: false,
            }
        },
        data() {
            return {
                count: 0,
                applicants: [
                    {
                        previous: '',
                        expiration: '',
                        consecutivo: 0
                    }
                ],
                subNivel: false
            }
        },
        methods: {
            addNivel() {
                this.count = this.count + 1;
                this.subNivel = true;
                this.applicants.push({
                    previous: '',
                    expiration: '',
                    consecutivo: this.count
                })
            },
            deleteNivel(counter) {
                this.count = this.count - 1;
                for (let c = counter; c < this.applicants.length; c++) { 

                    this.applicants[c].consecutivo = this.applicants[c].consecutivo - 1;

                }
                this.applicants.splice(counter, 1);
            }
        }
    }

</script>