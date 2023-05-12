import { Category } from "../models/Category";
import axiosClient from "./axiosClient";
const CategoryApi = {
  getCategory(id: number | string): Promise<Category> {
    const url = `/Category/${id}`;
    return axiosClient.get(url);
  },
};

export default CategoryApi;
