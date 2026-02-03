import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api';

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const contactService = {
  addContact: async (contact) => {
    const response = await api.post('/contact', contact);
    return response.data;
  },

  getAllContacts: async () => {
    const response = await api.get('/contact');
    return response.data;
  },
};
