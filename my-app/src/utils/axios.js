import axios from "axios";

const axiosInstance = axios.create({ baseURL: 'https://localhost:7145/api' })
axiosInstance.interceptors.request.use((config) => {
    //const token = localStorage.getItem('jwtToken');
    // if (token) {
    //   config.headers['Authorization'] = `Bearer ${token}`;
    // }
    return config;
  });

export default axiosInstance