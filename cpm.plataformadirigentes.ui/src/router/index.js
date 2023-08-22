import Vue from "vue";
import VueRouter from "vue-router";
import InicioViewVue from "../components/Home/InicioView.vue";
import store from "@/store";
Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "inicio",
    component: InicioViewVue,
  },
  {
    path: "/login",
    name: "login",
    component: () => import("@/views/Login/LoginView.vue"),
  },
  {
    path: "/convocatorias",
    name: "Convocatorias",
    component: () => import("@/views/Convocatorias/ConvocatoriasView.vue"),
  },
  {
    path: "/indicadores",
    name: "Indicadores",
    component: () => import("@/components/Indicadores/IndicadoresView.vue"),
  },
  {
    path: "/logJocabs",
    name: "LogJocabs",
    component: () => import("@/components/LogJocabs/LogJocabsView.vue"),
  },
  {
    path: "/padron",
    name: "Padron",
    component: () => import("@/views/PadronDirigencial/PadronView.vue"),
  },
  {
    path: "/administracion",
    name: "Administracion",
    component: () => import("@/views/Administracion/AdministracionView.vue"),
  },
  //Gestion Dirigentes
  {
    path: "/administracion/CargosOrganoDirigencial",
    name: "adminCargosOrganoDirigencial",
    component: () =>
      import(
        "@/views/Administracion/GestionDirigentes/adminCargosOrganoDirigencial.vue"
      ),
  },
  {
    path: "/administracion/ClasificacionProfesion",
    name: "adminClasificacionProfesion",
    component: () =>
      import(
        "@/views/Administracion/GestionDirigentes/adminClasificacionProfesion.vue"
      ),
  },
  {
    path: "/administracion/CondicionesIngreso",
    name: "adminCondicionesIngreso",
    component: () =>
      import(
        "@/views/Administracion/GestionDirigentes/adminCondicionesIngreso.vue"
      ),
  },
  {
    path: "/administracion/Escolaridad",
    name: "adminEscolaridad",
    component: () =>
      import("@/views/Administracion/GestionDirigentes/adminEscolaridad.vue"),
  },
  {
    path: "/administracion/EstadoCivil",
    name: "adminEstadoCivil",
    component: () =>
      import("@/views/Administracion/GestionDirigentes/adminEstadoCivil.vue"),
  },
  {
    path: "/administracion/Genero",
    name: "adminGenero",
    component: () =>
      import("@/views/Administracion/GestionDirigentes/adminGenero.vue"),
  },
  {
    path: "/administracion/MotivosBaja",
    name: "adminMotivosBaja",
    component: () =>
      import("@/views/Administracion/GestionDirigentes/adminMotivosBaja.vue"),
  },
  {
    path: "/administracion/TiposBaja",
    name: "adminTiposBaja",
    component: () =>
      import("@/views/Administracion/GestionDirigentes/adminTiposBaja.vue"),
  },
  {
    path: "/administracion/Plaza",
    name: "adminPlaza",
    component: () =>
      import("@/views/Administracion/GestionDirigentes/adminPlaza.vue"),
  },
  {
    path: "/administracion/Profesion",
    name: "adminProfesion",
    component: () =>
      import("@/views/Administracion/GestionDirigentes/adminProfesion.vue"),
  },
  {
    path: "/administracion/Sucursales",
    name: "adminSucursales",
    component: () =>
      import("@/views/Administracion/GestionDirigentes/adminSucursales.vue"),
  },
  {
    path: "/administracion/ResponsablePlaza",
    name: "adminResponsablePlaza",
    component: () =>
      import(
        "@/views/Administracion/GestionDirigentes/adminResponsablePlaza.vue"
      ),
  },
  //Gestion Convocatorias
  {
    path: "/administracion/DiasInhabiles",
    name: "adminDiasInhabiles",
    component: () =>
      import(
        "@/views/Administracion/GestionConvocatorias/adminDiasInhabiles.vue"
      ),
  },
  {
    path: "/administracion/LimitesInformes",
    name: "adminLimitesInformes",
    component: () =>
      import(
        "@/views/Administracion/GestionConvocatorias/adminLimitesInformes.vue"
      ),
  },
  {
    path: "/administracion/EstatusAcuerdos",
    name: "adminEstatusAcuerdos",
    component: () =>
      import(
        "@/views/Administracion/GestionConvocatorias/adminEstatusAcuerdos.vue"
      ),
  },
  {
    path: "/administracion/OrdenDia",
    name: "adminOrdenDia",
    component: () =>
      import("@/views/Administracion/GestionConvocatorias/adminOrdenDia.vue"),
  },
  {
    path: "/administracion/OrganosDirigenciales",
    name: "adminOrganosDirigenciales",
    component: () =>
      import("@/views/Administracion/GestionConvocatorias/adminOrganos.vue"),
  },
  {
    path: "/administracion/Firmas",
    name: "adminFirmas",
    component: () =>
      import("@/views/Administracion/GestionConvocatorias/adminFirmas.vue"),
  },
  {
    path: "/administracion/PersonalAdministrativo",
    name: "adminPersonalAdministrativo",
    component: () =>
      import(
        "@/views/Administracion/GestionConvocatorias/adminPersonalAdministrativo.vue"
      ),
  },
  {
    path: "/administracion/TiposJunta",
    name: "adminTiposJunta",
    component: () =>
      import("@/views/Administracion/GestionConvocatorias/adminTiposJunta.vue"),
  },
  //Gestion Comunicacion
  {
    path: "/administracion/Felicitaciones",
    name: "adminFelicitaciones",
    component: () =>
      import(
        "@/views/Administracion/GestionComunicacion/adminFelicitaciones.vue"
      ),
  },
  {
    path: "/administracion/Galeria",
    name: "adminGaleria",
    component: () =>
      import("@/views/Administracion/GestionComunicacion/adminGaleria.vue"),
  },
  {
    path: "/administracion/Noticias",
    name: "adminNoticias",
    component: () =>
      import("@/views/Administracion/GestionComunicacion/adminNoticias.vue"),
  },
  {
    path: "/administracion/Vinculos",
    name: "adminVinculos",
    component: () =>
      import("@/views/Administracion/GestionComunicacion/adminVinculos.vue"),
  },
  //Usuarios
  {
    path: "/administracion",
    name: "adminUsuarios",
    component: () =>
      import("@/views/Administracion/Usuarios/adminUsuarios.vue"),
  },
  //Perfiles
  {
    path: "/administracion",
    name: "adminPerfiles",
    component: () =>
      import("@/views/Administracion/Perfiles/adminPerfiles.vue"),
  },
  //Convocatorias
  {
    path: "/convocatorias/crear",
    name: "crearConvocatoria",
    component: () =>
      import("@/components/Convocatorias/compCreateConvocatorias.vue"),
  },
  {
    path: "*",
    beforeEnter: (to, from, next) => {
      console.log(
        "beforeEach",
        to.path + " - Auth: " + store.getters["user/getAuthenticated"]
      );
      if (
        to.path !== "/login" &&
        to.path !== "login" &&
        !store.getters["user/getAuthenticated"]
      ) {
        next({ path: "/login" });
      } else if (
        (to.path === "/login" || to.path === "login") &&
        store.getters["user/getAuthenticated"]
      ) {
        next({ path: "/" });
      } else {
        next();
      }
    },
  },
  {
    path: "/:pathMatch(.*)*",
    name: "nopagefound",
    component: () => import("@/views/Error/NotFound.vue"),
  },
];

const router = new VueRouter({
  base: process.env.BASE_URL,
  routes,
});

router.safeNavigate = function (route, dest) {
  if (route.name != dest) this.push({ name: dest });
};

export default router;
