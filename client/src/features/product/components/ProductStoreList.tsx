import { useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../../app/hooks";
import { fetchStudents } from "../productHandler";
import { productSelector } from "../productSlice";
import ProductFilter from "./ProductFilter";
import ProductItem from "./ProductItem";

const ProductStoreList = () => {
  const { data } = useAppSelector(productSelector);
  const dispatch = useAppDispatch();
  const navigate = useNavigate();
  useEffect(() => {
    fetchProducts();
  }, []);

  const fetchProducts = async () => {
    await fetchStudents({}, dispatch);
  };

  return (
    <>
      <div className="container mx-auto my-20">
        <ProductFilter></ProductFilter>
        <div className="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-6 mb-3">
          {data?.length === 0 ? (
            <h1>Product Empty!</h1>
          ) : (
            data?.map((item) => {
              return (
                <ProductItem
                  key={item.id}
                  id={item.id}
                  image={item.image}
                  name={item.name}
                  price={item.price}
                />
              );
            })
          )}
        </div>
      </div>
    </>
  );
};

export default ProductStoreList;
