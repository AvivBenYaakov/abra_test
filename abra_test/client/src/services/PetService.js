import axios from 'axios';

const API_BASE_URL = 'https://localhost:7262/api/Pet';

export const getPets = async () => {
    try {
        const response = await axios.get(API_BASE_URL);
        return response.data;
    } catch (error) {
        console.error('Error fetching pets', error);
        throw error;
    }
};

export const getPetById = async (id) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/${id}`);
        return response.data;
    } catch (error) {
        console.error(`Error fetching pet with id ${id}`, error);
        throw error;
    }
};

export const addPet = async (pet) => {
    try {
        const response = await axios.post(API_BASE_URL, pet);
        return response.data;
    } catch (error) {
        console.error('Error adding pet', error);
        throw error;
    }
};

