import AxiosInstance from '@/utils/axios.config.js';

const ROOT = 'https://localhost:7244';

export default {
  getWarranty() {
    return AxiosInstance.get(`${ROOT}/Warranty`);
  },
  addWarranty(data) {
    return AxiosInstance.post(`${ROOT}/Warranty`, data);
  },
  modifyWarranty(data) {
    return AxiosInstance.put(`${ROOT}/Warranty`, data);
  },
  getUserWarranties() {
    return AxiosInstance.get(`${ROOT}/getUserWarranties`);
  },
  getWarrantyById(warrantyId) {
    return AxiosInstance.get(`${ROOT}/Warranty/${warrantyId}`);
  },
  deleteWarranty(warrantyId) {
    return AxiosInstance.delete(`${ROOT}/Warranty/${warrantyId}`);
  },
};
