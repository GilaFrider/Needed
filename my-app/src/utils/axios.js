import axios from "axios";

const axiosInstance = axios.create({ baseURL: 'https://localhost:7038/api' })

export default axiosInstance