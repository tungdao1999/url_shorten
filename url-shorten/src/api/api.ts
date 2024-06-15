import axios from 'axios';
import urls from '../const/const';

const api = {
  async getApiData(path: string) {
    try {
      const response = await axios.get(`${urls.shortenServer}` + path);
      return response.data;
    } catch (error) {
      console.error('Error fetching data:', error);
      return null;
    }
  },

  async postApiData(path: string, data: any) {
    try {
      const response = await axios.post(`${urls.shortenServer}` + path, data);
      return response.data;
    } catch (error) {
      console.error('Error posting data:', error);
      return null;
    }
  },

  async putApiData(path: string, data: any) {
    try {
      const response = await axios.put(`${urls.shortenServer}` + path, data);
      return response.data;
    } catch (error) {
      console.error('Error updating data:', error);
      return null;
    }
  },

  async deleteApiData(id: number) {
    try {
      await axios.delete(`${urls.shortenServer}/${id}`);
      return true;
    } catch (error) {
      console.error('Error deleting data:', error);
      return false;
    }
  },
};

export default api;