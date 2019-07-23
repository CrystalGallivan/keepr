import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    keep: {},
    vaults: [],
    vault: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeep(state, keep) {
      state.keep = keep
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVault(state, vault) {
      state.vault = vault
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    }

  },
  actions: {
    //#region Auth
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    //#endregion Auth


    //#region keeps
    async getAllKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps")
        console.log(res)
        commit("setKeeps", res.data)
      } catch (e) {
        console.error(e)
      }
    },
    async getKeepsById({ commit, dispatch }, id) {
      try {
        let res = await api.get("keeps/" + id)
        console.log(res)
        commit("setKeep", res.data)
      } catch (e) {
        console.error(e)
      }
    },
    async getByUser({ commit, dispatch }, user) {
      try {
        let res = await api.get("keeps/user", user)
        console.log(res)
        commit("setKeeps", res.data)
      } catch (e) {
        console.error(e)
      }
    },
    async CreateKeep({ commit, dispatch }, payload) {
      try {
        let res = await api.post("keeps", payload)
        console.log(res)
        dispatch("getAllKeeps")
        router.push("/")
      } catch (e) {
        console.error(e)
      }
    },
    async EditKeep({ commit, dispatch }, payload) {
      try {
        let res = await api.put("keeps/" + payload.id, payload)
        console.log(res)
        dispatch("getAllKeeps")
      } catch (e) {
        console.error(e)
      }
    },
    async DeleteKeep({ commit, dispatch }, id) {
      try {
        let res = await api.delete("keeps/" + id)
        console.log(res)
        dispatch("getAllKeeps")
      } catch (e) {
        console.error(e)
      }
    },

    //#endregion keeps


    //#region vaults
    async getAllVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults")
        console.log(res)
        commit("setVaults", res.data)
      } catch (e) {
        console.error(e)
      }
    },
    async getVaultsById({ commit, dispatch }, id) {
      try {
        let res = await api.get("vaults/" + id)
        console.log(res)
        commit("setVault", res.data)
      } catch (e) {
        console.error(e)
      }
    },
    async CreateVault({ commit, dispatch }, payload) {
      try {
        let res = await api.post("vaults", payload)
        console.log(res)
        dispatch("getAllVaults")
      } catch (e) {
        console.error(e)
      }
    },
    async EditVault({ commit, dispatch }, payload) {
      try {
        let res = await api.put("vaults/" + payload.id, payload)
        console.log(res)
        dispatch("getAllVaults")
      } catch (e) {
        console.error(e)
      }
    },
    async DeleteVault({ commit, dispatch }, id) {
      try {
        let res = await api.delete("vaults/" + id)
        console.log(res)
        dispatch("getAllVaults")
      } catch (e) {
        console.error(e)
      }
    },

    //#endregion vaults

  }
})
