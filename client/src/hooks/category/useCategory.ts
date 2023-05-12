import { useEffect, useState } from "react";
import { Category } from "../../models/Category";
import CategoryApi from "../../api/CategoryApi";

export default function useCategory(id: number | string) {
  const [category, setCategory] = useState<Category>();
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  useEffect(() => {
    apiHandler();
  }, []);

  const apiHandler = async () => {
    setLoading(true);
    await CategoryApi.getCategory(id)
      .then((res) => {
        console.log(res);
        setCategory(res);
        setLoading(false);
      })
      .catch((error) => setError(error));
  };

  return {
    category,
    loading,
    error,
  };
}
