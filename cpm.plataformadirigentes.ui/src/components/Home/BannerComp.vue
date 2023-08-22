<template>
    <div class="container">
        <div>
            <b-carousel id="carousel-1"
                        v-model="slide"
                        :interval="4000"
                        controls
                        indicators
                        background="#ababab"
                        img-width="680"
                        img-height="280"
                        style="text-shadow: 1px 1px 2px #333;"
                        @sliding-start="onSlideStart"
                        @sliding-end="onSlideEnd">
                <!-- Text slides with image  0-->
                <b-carousel-slide caption="First slide">
                    <span class="ltext-101 cl2 ">
                        Información
                    </span>
                    <h2 class="ltext-201 cl2 p-t-19 p-b-43 ">
                        Texto
                    </h2>
                    <a class=" btn btn-dark">
                        Botton
                    </a>
                    <template #img>
                        <img class="d-block img-fluid w-100"
                             width="680"
                             height="280"
                             src='@/assets/cpm/corporat.png'
                             alt="image slot">
                    </template>
                </b-carousel-slide>
                <!-- Slides with custom text 1 -->
                <b-carousel-slide>
                    <template #img>
                        <img class="d-block img-fluid w-100"
                             width="680"
                             height="280"
                             src='@/assets/cpm/CORPO.jpg'
                             alt="image slot">
                    </template>
                    <h1>Hello world!</h1>
                </b-carousel-slide>

                <!-- Slides with image only 2-->
                <b-carousel-slide>
                    <template #img>
                        <img class="d-block img-fluid w-100"
                             width="680"
                             height="280"
                             src='@/assets/cpm/Slider2.jpg'
                             alt="image slot">
                    </template>

                </b-carousel-slide>

                <!-- Slides with img slot 3-->
                <!-- Note the classes .d-block and .img-fluid to prevent browser default image alignment -->
                <b-carousel-slide>
                    <template #img>
                        <img class="d-block img-fluid w-100"
                             width="680"
                             height="280"
                             src='@/assets/cpm/slide-03.jpg'
                             alt="image slot">
                    </template>
                </b-carousel-slide>

                <!-- Slide with blank fluid image to maintain slide aspect ratio  4-->

                <b-carousel-slide >
                    <template #img>
                        <img class="d-block img-fluid w-100"
                             width="680"
                             height="280"
                             src='@/assets/cpm/Slider.png'
                             alt="image slot">
                    </template>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse eros felis, tincidunt
                        a tincidunt eget, convallis vel est. Ut pellentesque ut lacus vel interdum.
                    </p>
                </b-carousel-slide>
            </b-carousel>
            <!--
            <p class="mt-4">
                Slide #: {{ slide }}<br>
                Sliding: {{ sliding }}
            </p>-->




        </div>


    </div>

</template>

<script>
    export default {
        data() {
            return {
                slide: 0,
                sliding: null,
                form: {
                    email: '',
                    name: '',
                    numero:'',

                    checked: []
                },
                show: true
            }
        },
        methods: {
            onSlideStart() {
                this.sliding = true
            },
            onSlideEnd() {
                this.sliding = false
            },
            onSubmit(event) {
                event.preventDefault()
                alert(JSON.stringify(this.form))
            },
            onReset(event) {
                event.preventDefault()
                // Reset our form values
                this.form.email = ''
                this.form.name = ''
                this.form.food = null
                this.form.checked = []
                // Trick to reset/clear native browser form validation state
                this.show = false
                this.$nextTick(() => {
                    this.show = true
                })
            }
        }
    }

</script>
