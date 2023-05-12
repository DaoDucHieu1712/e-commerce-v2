import { useEffect, useState } from "react";
import { Product } from "../../models/Product";
import ProductApi from "../../api/ProductApi";

export default function useProductsByCategory(id: number | string) {
  const [products, setProducts] = useState<Product[]>();
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  useEffect(() => {
    apiHandler();
  }, []);

  const apiHandler = async () => {
    setLoading(true);
    await ProductApi.getProductByCategory(id)
      .then((res) => {
        setProducts(res);
        setLoading(false);
      })
      .catch((error) => setError(error));
  };

  return {
    products,
    loading,
    error,
  };
}
