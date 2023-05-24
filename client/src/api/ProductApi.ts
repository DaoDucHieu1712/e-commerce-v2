import { Product } from "../models/Product";
import axiosClient from "./axiosClient";

const ProductApi = {
  getAll(): Promise<Product[]> {
    const url = "/Product";
    return axiosClient.get(url);
  },
  getProductByCategory(id: number | string): Promise<Product[]> {
    const url = `/Product/Category/${id}`;
    return axiosClient.get(url);
  },
  create(data: any): Promise<string> {
    const url = `/Product`;
    return axiosClient.post(url, data);
  },
};

export default ProductApi;
