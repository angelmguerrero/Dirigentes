<template>
    <b-list-group id="lstNiveles" style="text-align: left;" flush>
        <ul v-for="(nivel, cnt) in niveles" v-bind:key="cnt">
            <li>
                <b-row>
                    <b-col sm="8">
                        <label>{{ nivel.indice }}. {{ nivel.descripcion }}</label>
                    </b-col>
                </b-row>
                <ul v-for="(subnivel, counter) in niveles[cnt].niveles" v-bind:key="counter">
                    <li>
                        <b-row>
                            <b-col sm="8">
                                <label>{{ subnivel.indice }}. {{ subnivel.descripcion }}</label>
                            </b-col>
                        </b-row>
                        <ul v-for="(subnivel1, counter1) in niveles[cnt].niveles[counter].niveles" v-bind:key="counter1">
                            <li>
                                <b-row>
                                    <b-col sm="8">
                                        <label>{{ subnivel1.indice }}. {{ subnivel1.descripcion }}</label>
                                    </b-col>
                                </b-row>
                                <ul v-for="(subnivel2, counter2) in niveles[cnt].niveles[counter].niveles[counter1].niveles"
                                    v-bind:key="counter2">
                                    <li>
                                        <b-row>
                                            <b-col sm="8">
                                                <label>{{ subnivel2.indice }}. {{ subnivel2.descripcion }}</label>
                                            </b-col>
                                        </b-row>
                                        <ul v-for="(subnivel3, counter3) in niveles[cnt].niveles[counter].niveles[counter1].niveles[counter2].niveles"
                                            v-bind:key="counter3">
                                            <li>
                                                <b-row>
                                                    <b-col sm="8">
                                                        <label>{{ subnivel3.indice }}. {{ subnivel3.descripcion }}</label>
                                                    </b-col>
                                                </b-row>
                                                <ul v-for="(subnivel4, counter4) in niveles[cnt].niveles[counter].niveles[counter1].niveles[counter2].niveles[counter3].niveles"
                                                    v-bind:key="counter4">
                                                    <li>
                                                        <b-row>
                                                            <b-col sm="8">
                                                                <label>{{ subnivel4.indice }}. {{ subnivel4.descripcion }}</label>
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
        id: Number,
        detalles: []
    },
    data() {
        return {
            count: 1,
            niveles: []
            }
        },
        mounted() {
            this.niveles = this.detalles;                   
        },
        methods: {           

    }
}

</script>
