import axios from "axios";
import store from '@/store'
import { config } from "@/config/auth";

export const HTTP = axios.create({
    baseURL: config.auth.server_url_api,
    headers: {
        Authorization: "Bearer " + store.getters['user/getToken'],
        'Content-Type': 'application/json'
    },  
    
})