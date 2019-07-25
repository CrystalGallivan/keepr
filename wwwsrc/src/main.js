import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import AuthService from "./AuthService"
import VueSweetalert2 from "vue-sweetalert2"
import VuePackeryPlugin from "vue-packery-plugin"
import VueDraggabillyPlugin from "vue-packery-draggabilly-plugin"

//Vue.config.productionTip = false

async function init() {
  let user = await AuthService.Authenticate()
  if (user) { store.commit("setUser", user) }
  new Vue({
    router,
    store,
    render: h => h(App)
  }).$mount('#app')
}
init()
Vue.use(VueSweetalert2);
Vue.use(VuePackeryPlugin);
Vue.use(VueDraggabillyPlugin)

