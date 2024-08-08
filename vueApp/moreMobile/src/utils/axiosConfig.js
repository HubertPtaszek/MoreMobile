import axios from 'axios';
import router from '../router/index';
// import storage from "@/utils/ionicStorage";

import { useAuthStore } from '@/stores/authStore.js';
/*
    Customowy nagłówek
*/
// const auth = {
//   baseURL: '',
//   withCredentials: true,
//   xsrfHeaderName: 'X-XSRF-TOKEN',
//   xsrfCookieName: 'XSRF-TOKEN',
//   headers: {
//     Authorization: '',
//     'Content-Type': 'application/json; charset=utf-8',
//     Accept: 'application/json; charset=utf-8',
//   },
// };

/*
    Instancja axiosa
*/
const axiosInstance = axios.create();

/*
    Interceptory
*/
const requestFulfilled = async (request) => {
  let mainStore = useAuthStore();
  request.baseURL = `${mainStore.getConfig().BASE_URI}/api`;
  //const token = await storage.get("token");
//   if (token) {
//     request.headers['Authorization'] = `Bearer ` + token;
//   }
  return request;
};

const requestRejected = (error) => {
  router.push('/error');
  return Promise.reject(error);
};

const responseFulfilled = (response) => response;

const responseRejected = (error) => {
  if (axios.isCancel(error)) {
    return Promise.reject(error);
  }
  if (axiosInstance.isHandled) {
    return Promise.reject(error);
  } else {
    if (error.response) {
      if (error.response.status !== 401) {
        router.push('/error');
      }
      else if (error.response.status === 401) {
        useAuthStore().logout();
        router.push({ name: 'Auth' });
        useAuthStore().setErrorMessage()
      }
    }
    return Promise.reject(error);
  }
};

axiosInstance.interceptors.request.use(requestFulfilled, requestRejected);
axiosInstance.interceptors.response.use(responseFulfilled, responseRejected);

export default axiosInstance;
