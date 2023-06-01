import {
  FilterParams,
  Product,
  ProductFilterAndPaging,
  SearchProductParams,
} from "../models/Product";
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
  getProduct(id: number | string | undefined): Promise<Product> {
    const url = `/Product/${id}`;
    return axiosClient.get(url);
  },
  getProductsPagingAndFilter(
    params?: FilterParams
  ): Promise<ProductFilterAndPaging> {
    const url = `/Product/Filter?
    pageIndex=${params?.pageIndex == undefined ? 1 : params.pageIndex}
    &name=${params?.name == undefined ? "" : params.name}
    &toPrice=${params?.toPrice == undefined ? "" : params.toPrice}
    &fromPrice=${params?.fromPrice == undefined ? "" : params.fromPrice}
    &categoryId=${params?.categoryId == undefined ? "" : params.categoryId}
    &sortType=${params?.sortType == undefined ? "" : params.sortType}`;
    return axiosClient.get(url);
  },
  searchAdvance(params?: SearchProductParams): Promise<Product[]> {
    const url = `/Product/Search`;
    return axiosClient.post(url, params);
  },
};

export default ProductApi;
