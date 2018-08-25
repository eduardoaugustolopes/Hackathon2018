import axios from 'axios';

const api = axios.create({
    baseURL: 'http://192.168.0.135:9591/api/',
    timeout: 1000,
});

export default api;