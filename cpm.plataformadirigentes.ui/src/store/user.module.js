export default {
    namespaced: true,
    state: {
        isAuthenicated: false,
        loading: false,
        mensajelogin: null,
        nombreDirigente: '',
        correoDirigente: '',
        perfilesDirigente: [],
        token:''

    },
    getters: {
        getAuthenticated: function (state) {
            return state.isAuthenicated;
        },
        getLoading: function (state) {
            return state.loading
        },
        getMensajeLogin: function (state) {
            return state.mensajelogin
        },
        getNombreDirigente: function (state) {
            return state.nombreDirigente;
        },
        getCorreoDirigente: function (state) {
            return state.correoDirigente;
        },
        getPerfilesDirigente: function (state) {
            return state.perfilesDirigente;
        },
        getToken: function (state) {
            return state.token;
        }
    },
    mutations: {
        
        SET_AUTEHNTICATION(state, payload) {
            state.isAuthenicated = payload
        },
        SET_LOADING(state, value) {
            state.loading = value
        },
        SET_MENSAJELOGIN(state, value) {
            state.mensajelogin = value
        },
        SET_NOMBRE_DIRIGENTE(state, value) {
            state.nombreDirigente = value
        },
        SET_CORREO_DIRIGENTE(state, value) {
            state.correoDirigente = value
        },
        SET_PERFILES(state, value) {
            state.perfilesDirigente = value
        },
        SET_TOKEN(state, value) {
            state.token = value
        }

    },
    actions: {
        
        setAutehntication(context, payload) {
            context.commit('SET_AUTEHNTICATION', payload)
        },
        setLoading(context, value) {
            context.commit('SET_LOADING', value)
        },
        setMensajeLogin(context, value) {
            context.commit('SET_MENSAJELOGIN', value)
        },
        setNombreDirigente(context, value) {
            context.commit('SET_NOMBRE_DIRIGENTE', value)
        },
        setCorreoDirigente(context, value) {
            context.commit('SET_CORREO_DIRIGENTE', value)
        },
        setPerfiles(context, payload) {
            context.commit('SET_PERFILES', payload)
        },
        setToken(context, payload) {
            context.commit('SET_TOKEN', payload)
        }


    }

    
}