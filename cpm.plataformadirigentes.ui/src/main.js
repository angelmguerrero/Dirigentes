import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import JsonExcel from "vue-json-excel";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import VueSweetalert2 from "vue-sweetalert2";
import "sweetalert2/dist/sweetalert2.min.css";
import "@/mixins/Mensajes";
import "@/mixins/FormatoFecha";
import {
  ValidationObserver,
  ValidationProvider,
  extend,
  localize,
} from "vee-validate";

import es from "vee-validate/dist/locale/es.json";
import * as rules from "vee-validate/dist/rules";
import messageConstants from "./config/messageConstants";
import { CalendarView, CalendarViewHeader } from "vue-simple-calendar";
import "vue-simple-calendar/static/css/default.css";

import Loading from "vue-loading-overlay";
import "vue-loading-overlay/dist/vue-loading.css";

Vue.component("loading-overlay", Loading);

//import "vue-simple-calendar/static/css/holidays-us.css"
Vue.component("CalendarView", CalendarView);
Vue.component("CalendarViewHeader", CalendarViewHeader);
// Install VeeValidate rules and localization
Object.keys(rules).forEach((rule) => {
  extend(rule, rules[rule]);
});

localize("es", es);

// Install VeeValidate components globally
Vue.component("ValidationObserver", ValidationObserver);
Vue.component("ValidationProvider", ValidationProvider);
Vue.use(messageConstants);
Vue.use(VueSweetalert2);
Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

Vue.config.productionTip = false;
Vue.component("downloadExcel", JsonExcel);

new Vue({
  store,
  router,
  render: (h) => h(App),
}).$mount("#app");
