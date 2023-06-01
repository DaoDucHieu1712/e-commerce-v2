import { Collapse, Image, Spin } from "antd";
import Breadcumb from "../../../components/breadcumb/Breadcumb";
import ProductList from "./ProductList";
import { useParams } from "react-router-dom";
import useProductById from "../../../hooks/product/useProductById";
const { Panel } = Collapse;
const ProductDetail = () => {
  const { id } = useParams();
  const onChange = (key: string | string[]) => {
    console.log(key);
  };
  const { product, loading } = useProductById(Number(id));
  return (
    <>
      <div className="container mx-auto mb-10 mt-32">
        <Breadcumb></Breadcumb>
        {loading ? (
          <Spin />
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 gap-x-10">
            <div className="flex items-center justify-center">
              <Image src={product?.image} alt="ads" className="w-[500px]" />
            </div>
            <div className="">
              <p className="text-3xl font-bold uppercase text-center mb-10">
                {product?.name}
              </p>
              <div className="flex flex-col gap-y-3">
                <p className="text-2xl font-medium text-red-500">
                  Price : {product?.price},000 $
                </p>
                <p className="description">{product?.description}</p>
                <div className="flex gap-x-3 mt-3">
                  <p className="py-6 px-9 bg-slate-100 cursor-pointer font-medium">
                    Freeship for orders worth over 1 million
                  </p>
                  <p className="py-6 px-9 bg-slate-100 cursor-pointer font-medium">
                    Freeship for orders worth over 1 million
                  </p>
                </div>
                <span className="block mt-3 text-center py-4 px-12 bg-slate-500 text-white cursor-pointer hover:opacity-90">
                  Add to cart
                </span>
                <Collapse
                  defaultActiveKey={["1"]}
                  onChange={onChange}
                  className="my-10"
                >
                  <Panel header="Infomation Product" key="1">
                    <p>
                      Lorem ipsum dolor sit amet consectetur adipisicing elit.
                      Aperiam amet alias, odio dicta veniam sunt ipsum mollitia,
                      eius ipsam soluta laborum ratione, explicabo eos suscipit
                      deleniti in dolorum fugit possimus.
                    </p>
                  </Panel>
                  <Panel header="Support Customer" key="2">
                    <p>
                      Lorem ipsum dolor sit amet consectetur adipisicing elit.
                      Aperiam amet alias, odio dicta veniam sunt ipsum mollitia,
                      eius ipsam soluta laborum ratione, explicabo eos suscipit
                      deleniti in dolorum fugit possimus.
                    </p>
                  </Panel>
                  <Panel header="Services" key="3">
                    <p>
                      Lorem ipsum dolor sit amet consectetur adipisicing elit.
                      Aperiam amet alias, odio dicta veniam sunt ipsum mollitia,
                      eius ipsam soluta laborum ratione, explicabo eos suscipit
                      deleniti in dolorum fugit possimus.
                    </p>
                  </Panel>
                </Collapse>
              </div>
            </div>
          </div>
        )}
      </div>
      <div className="container mx-auto">
        <ProductList id="1"></ProductList>
      </div>
    </>
  );
};

export default ProductDetail;
