import axios from 'axios';
/*import NProgress from 'nprogress';*/
/*import { store } from "../redux/store";*/

//NProgress.configure({
//    showSpinner: false,
//    trickleSpeed: 30,
//})

const instance = axios.create({
    baseURL: 'https://localhost:44396',
});

// Add a request interceptor
instance.interceptors.request.use(function (config) {
    //NProgress.start();

    // Do something before request is sent
    const access_token = store.getState()?.account?.user?.access_token;
    config.headers["Authorization"] = "Bearer" + access_token;
    return config;
}, function (error) {
    // Do something with request error
    // console.log("haha")
    return Promise.reject(error);
});

// Add a response interceptor
instance.interceptors.response.use(function (response) {
   /* NProgress.done();*/
    // Any status code that lie within the range of 2xx cause this function to trigger
    // Do something with response data
    return response && response.data ? response.data : response;
}, function (error) {
    // Any status codes that falls outside the range of 2xx cause this function to trigger
    // Do something with response error
    // console.log("hihi")
   /* console.log(error)*/
    NProgress.done();
    return Promise.reject(error);
});

export default instance;