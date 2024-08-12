import AxiosInstance from '@/utils/axiosConfig.js';

const ROOT = 'https://localhost:7244';

export default {
  register2(data) {
    return AxiosInstance.post(`${ROOT}/Auth/register`, data);
  },
  register(data) {
    return AxiosInstance.post(`${ROOT}/register`, data);
  },
  login(data) {
    return AxiosInstance.post(`${ROOT}/login`, data);
  },
  refresh(data) {
    return AxiosInstance.post(`${ROOT}/refresh`, data);
  },
  confirmEmail() {
    return AxiosInstance.get(`${ROOT}/confirmEmail`);
  },
  resendConfirmationEmail() {
    return AxiosInstance.post(`${ROOT}/resendConfirmationEmail`);
  },
  forgotPassword() {
    return AxiosInstance.post(`${ROOT}/forgotPassword`);
  },
  resetPassword() {
    return AxiosInstance.post(`${ROOT}/resetPassword`);
  },
  manage2fa() {
    return AxiosInstance.post(`${ROOT}/manage/2fa`);
  },
  getInfo() {
    return AxiosInstance.get(`${ROOT}/manage/info`);
  },
  postInfo() {
    return AxiosInstance.post(`${ROOT}/manage/info`);
  },
};
