export interface Product {
  id: number;
  name: string;
  image: string;
  description: string;
  price: number;
  categoryId: number;
  isActive: boolean;
  isDelete: boolean;
}

export interface ProductFilterAndPaging {
  products: Product[];
  total: number;
  pageIndex: number;
}

export interface FilterParams {
  pageIndex?: number | string;
  name?: string;
  toPrice?: number;
  fromPrice?: number;
  categoryId?: number;
  sortType?: number;
}

export interface SearchProductParams {
  name?: string;
  toPrice?: number;
  fromPrice?: number;
  categoryId?: number;
  sortType?: string;
}
