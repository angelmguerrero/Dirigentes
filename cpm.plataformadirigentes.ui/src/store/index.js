import Vue from 'vue'
import Vuex from 'vuex'
import UsersModule from '../store/user.module'
import PermisosModule from '../store/permisos.module'


Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        user: UsersModule,
        permisos: PermisosModule
    }
})


