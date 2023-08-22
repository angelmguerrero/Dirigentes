<template>
    <b-container class="text-center" style="height: 300px; width: 300px," fluid>
        <b-row>
            <b-col>
                <b-img :mainProps="mainProps" rounded :src=img2 fluid alt="Responsive image"></b-img>
            </b-col>
        </b-row>
    </b-container>
</template>


<script>
    import img from '@/assets/cpm/corporat.png'

    export default {
        data() {
            return {

                img2: img,
                mainProps: {
                    center: true,
                    fluidGrow: true,
                    blank: true,
                    blankColor: '#bbb',
                    width: 300,
                    height: 200,

                },

            }

        },
    }

</script>

