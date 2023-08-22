export default {
    namespaced: true,
    state: {
        permisos:[]
    },
    getters: {
        getPermisos: function (state) {
            return state.permisos;
        },
        getPermisosByModulo: (state) => (submodulo, permiso) => {
            let permisovalor = state.permisos.filter(permisos => permisos.submodulo === submodulo && permisos.permiso === permiso);
            return permisovalor[0].valor;
        },
        getPermisosByMenuAdministracion: (state) => {
            const allowedStatus = ['PerfilesyPermisos','Usuarios',"Cargopororganodirigencial","Clasificacionporprofesion","Condicionesdeingreso","Escolaridad","Estadocivil",
                "Genero", "MotivoBaja", "Plazas", "Profesion", "Sucursales", "Diasinhabiles", "Diasparametrizables", "Estatusdeacuerdos", "Ordendeldia", "Organosdirigenciales,funcionalesyrepresentaciones",
                "Personaladministrativo", "Repositoriodefirmas", "Tipodejuntaoconvocatoria", "TipoBaja", "Responsabledeplaza"];
            var filterPermisos = state.permisos.filter(o => allowedStatus.includes(o.submodulo) && o.valor == true);
            return filterPermisos.length;
        }, 
        getPermisosByMenuPadronDirigencial: (state) => {
            const allowedStatus = ['Padrondedirigentes(inicial)','Padrondedirigentes(solicitudes)'];
            var filterPermisos = state.permisos.filter(o => allowedStatus.includes(o.submodulo) && o.valor == true);
            return filterPermisos.length;
        },
        getPermisosByMenuConvocatorias: (state) => {
            const allowedStatus = ['Convocatoria','Material','Acuerdos','Actas','Resumenejecutivo','Correspondencia','Controldegastos'];
            var filterPermisos = state.permisos.filter(o => allowedStatus.includes(o.submodulo) && o.valor == true);
            return filterPermisos.length;
        }

    },
    mutations: {
        SET_PERMISOS(state, value) {
            state.permisos = value
        }
    },
    actions: {
        setPermisos(context, payload) {
            context.commit('SET_PERMISOS', payload)
        }
    }
   
}