import { useEffect, useState } from "react";
import { Product } from "../../models/Product";
import ProductApi from "../../api/ProductApi";

export default function useProductById(id: number | string) {
  const [product, setProduct] = useState<Product>();
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  useEffect(() => {
    apiHandler();
  }, []);

  const apiHandler = async () => {
    setLoading(true);
    await ProductApi.getProduct(id)
      .then((res) => {
        setProduct(res);
        setLoading(false);
      })
      .catch((error) => setError(error));
  };

  return {
    product,
    loading,
    error,
  };
}
