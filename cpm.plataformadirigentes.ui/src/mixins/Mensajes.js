import Vue from 'vue';


Vue.mixin({
    methods: {
        MensajeError(value) {
            this.$swal.fire({
                html: value,
                icon: 'error',
                confirmButtonText: 'Ok',
                timer: 3000,
            });

        },
        MensajeSuccess(value) {
            this.$swal.fire({
                html: value,
                icon: 'success',
                confirmButtonText: 'Ok',
                timer: 3000,
            });

        },
        MensajeWarning(value) {
            this.$swal.fire({
                html: value,
                icon: 'warning',
                confirmButtonText: 'Ok',
                timer: 3000,
            });

        },
        MensajeInfo(value) {
            this.$swal.fire({
                html: value,
                icon: 'info',
                confirmButtonText: 'Ok',
                timer: 3000,
            });

        },

    }
})
