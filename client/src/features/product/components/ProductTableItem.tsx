import { Switch } from "antd";
import useCategory from "../../../hooks/category/useCategory";
import { Product } from "../../../models/Product";
import ProductDeleteModal from "./ProductDeleteModal";
import ProductUpdateModal from "./ProductUpdateModal";

interface ProductTableProps {
  item: Product;
}
const ProductTableItem = ({ item }: ProductTableProps) => {
  const { category } = useCategory(item.categoryId);
  return (
    <>
      <tr className="border-b">
        <td className="py-4 px-6 text-left">#{item.id}</td>
        <td className="py-4 px-6 text-left">
          <img
            src={item.image}
            alt=""
            className="object-cover w-[50px] h-[50px] border"
          />
        </td>
        <td className="py-4 px-6 text-left">{item.name}</td>
        <td className="py-4 px-6 text-left">
          <p className="whitespace-nowrap overflow-hidden text-ellipsis w-[200px]">
            {item.description}
          </p>
        </td>
        <td className="py-4 px-6 text-left">{item.price} $</td>
        <td className="py-4 px-6 text-left">{category?.name}</td>
        <td className="py-4 px-6 text-left">
          <Switch
            defaultChecked={!item.isActive}
            onChange={() => console.log("OK")}
          />
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
