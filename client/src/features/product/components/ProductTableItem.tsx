import { Switch } from "antd";
import ProductDeleteModal from "./ProductDeleteModal";
import ProductUpdateModal from "./ProductUpdateModal";

const ProductTableItem = () => {
  return (
    <>
      <tr className="border-b">
        <td className="py-4 px-6 text-left">#1</td>
        <td className="py-4 px-6 text-left">
          <img
            src="https://product.hstatic.net/1000281824/product/3f0dfdd8-83d9-41fc-8bc2-ee28708a229b_5befa0d288b244f79ca4b777875b8e8f_large.jpeg"
            alt=""
            className="object-cover w-[50px] h-[50px] border"
          />
        </td>
        <td className="py-4 px-6 text-left">Test Basic Tee</td>
        <td className="py-4 px-6 text-left">
          <p className="whitespace-nowrap overflow-hidden text-ellipsis w-[200px]">
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Sunt, ipsa?
            At, possimus accusamus! Aperiam praesentium voluptas optio, pariatur
            odio magni, voluptatum quis tenetur repudiandae quo odit obcaecati
            possimus, error fugit.
          </p>
        </td>
        <td className="py-4 px-6 text-left">120 $</td>
        <td className="py-4 px-6 text-left">Clothes</td>
        <td className="py-4 px-6 text-left">
          <Switch defaultChecked onChange={() => console.log("OK")} />
        </td>
        <td className="py-4 px-6 text-left flex items-center gap-x-3">
          <ProductUpdateModal></ProductUpdateModal>
          <ProductDeleteModal id="1" name="test"></ProductDeleteModal>
        </td>
      </tr>
    </>
  );
};

export default ProductTableItem;
