import AxiosInstance from '@/utils/axiosConfig.js';

const ROOT = 'https://localhost:7244';

export default {
  getServiceType() {
    return AxiosInstance.get(`${ROOT}/ServiceType`);
  },
  postServiceType(data) {
    return AxiosInstance.post(`${ROOT}/ServiceType`, data);
  },
  modifyServiceType(data) {
    return AxiosInstance.put(`${ROOT}/ServiceType`, data);
  },
  getServiceTypeById(serviceTypeId) {
    return AxiosInstance.get(`${ROOT}/ServiceType/${serviceTypeId}`);
  },
  deleteServiceType(serviceTypeId) {
    return AxiosInstance.delete(`${ROOT}/ServiceType/${serviceTypeId}`);
  },
};
