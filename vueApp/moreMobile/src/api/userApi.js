import AxiosInstance from '@/utils/axios.config.js';

const ROOT = 'https://localhost:7244';

export default {
  getUserData() {
    return AxiosInstance.get(`${ROOT}/User`);
  },
  modifyUserData(data) {
    return AxiosInstance.put(`${ROOT}/User`, data);
  },
  getUserByEmail(userEmail) {
    return AxiosInstance.get(`${ROOT}/User/${userEmail}`);
  },
  deleteUser(userEmail) {
    return AxiosInstance.delete(`${ROOT}/User/${userEmail}`);
  },
};
