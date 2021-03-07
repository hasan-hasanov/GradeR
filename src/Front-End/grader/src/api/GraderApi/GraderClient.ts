import axios, { AxiosRequestConfig, AxiosResponse } from 'axios';

const client = axios.create({
    baseURL: process.env.VUE_APP_ROOT_API,
});

client.interceptors.request.use(request => {
    console.log('Initiating Request!', request);
    return request;
});

client.interceptors.response.use(
    response => {
        console.log('Request Successful!', response);
        return response;
    },
    error => {
        if (error.response) {
            console.log('Request Failed!', error.response);

            return Promise.reject(error.response);
        } else if (error.request) {
            console.log(error.request);

            const response: AxiosResponse<any> = {
                data: {
                    Error: "Network Error! Please check your internet connection and try again!"
                },
                status: 0,
                statusText: "",
                headers: null,
                config: {},
            };
            return Promise.reject(response);
        } else {
            const response: AxiosResponse<any> = {
                data: {
                    Error: "Something went wrong constructing the request!"
                },
                status: -1,
                statusText: "",
                headers: null,
                config: {},
            };

            return Promise.reject(response);
        }
    }
);

const graderClient = (options: AxiosRequestConfig) => {
    return client(options);
};

export default graderClient;