import axios from 'axios';
import { baseUrl } from '../constants.json';

const getAllProducts = () => new Promise((resolve, reject) => {
  axios.get(`${baseUrl}/products`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

const getTwentyProducts = () => new Promise((resolve, reject) => {
  axios.get(`${baseUrl}/products/Top`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

const getSearchedProducts = (searchWord) => new Promise((resolve, reject) => {
  axios.get(`${baseUrl}/products/search/${searchWord}`)
    .then((response) => {
      const products = response.data;
      console.error(response);
      console.error(searchWord);
      resolve(products);
    })
    .catch((error) => reject(error, 'error from getSeachedProducts'));
});

const getThreeProducts = () => new Promise((resolve, reject) => {
  axios.get(`${baseUrl}/products/TopThree`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

const getSingleProduct = (id) => axios.get(`${baseUrl}/products/${id}`);

export default {
  getAllProducts,
  getTwentyProducts,
  getSingleProduct,
  getThreeProducts,
  getSearchedProducts,
};
