import Vue from "vue";
import moment from "moment";

Vue.mixin({
  methods: {
    formatDate(value) {
      if (value != null) return moment(value).format("DD/MM/YYYY");
      else return "";
    },
    ValidarRangoFechas(fechaInicial, fechaFinal) {
      return moment(fechaInicial).isAfter(fechaFinal); // true
    },
    ValidarRangoHoras(horaInicio, horaFin) {
      var beginningTime = moment(horaInicio, "h:mm");
      var endTime = moment(horaFin, "h:mm");
      return beginningTime.isAfter(endTime); // true
    },
    ValidarFechasIgual(fechaInicial, fechaFinal) {
      return moment(fechaInicial).isSame(fechaFinal); // true
    },
    ValidarRangoHorasMismaFecha(horaInicio, horaFin, horaInicioNext) {
      var beginningTime = moment(horaInicio, "h:mm");
      var endTime = moment(horaFin, "h:mm");
      var beginningTimeNext = moment(horaInicioNext, "h:mm");
      return moment(beginningTimeNext).isBetween(beginningTime, endTime);
    },
  },
});
