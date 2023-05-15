import { NavLink } from "react-router-dom";
import ProductItem from "./ProductItem";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/scss";
import useCategory from "../../../hooks/category/useCategory";
import useProductsByCategory from "../../../hooks/product/useProductsByCategory";
import { Spin } from "antd";

interface ProductListProps {
  id: string | number;
}

const ProductList = ({ id }: ProductListProps) => {
  const { category, loading, error } = useCategory(id);
  const { products } = useProductsByCategory(id);
  return (
    <>
      <div className="container mx-auto my-24">
        {loading ? (
          <Spin />
        ) : (
          <>
            <h1 className="text-xl font-medium mb-10 uppercase">
              {category?.name}
            </h1>
            <Swiper grabCursor={true} spaceBetween={1} slidesPerView={"auto"}>
              <div className="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-5 gap-4 p-3">
                {products?.map((item) => {
                  return (
                    <SwiperSlide key={item.id}>
                      <ProductItem
                        id={item.id}
                        name={item.name}
                        price={item.price}
                        image={item.image}
                      ></ProductItem>
                    </SwiperSlide>
                  );
                })}
              </div>
            </Swiper>
            <div className="flex justify-center items-center my-10">
              <NavLink
                to="/"
                className="py-3 px-12 bg-slate-900 text-white hover:opacity-90"
              >
                See more ...{" "}
              </NavLink>
            </div>
          </>
        )}
      </div>
    </>
  );
};

export default ProductList;
