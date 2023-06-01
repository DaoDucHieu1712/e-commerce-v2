import ProductTableItem from "./ProductTableItem";
import ProductCreateModal from "./ProductCreateModal";
import { useQuery } from "@tanstack/react-query";
import ProductApi from "../../../api/ProductApi";
import { Product } from "../../../models/Product";

const ProductTable = () => {
  const { data } = useQuery({
    queryKey: ["products"],
    queryFn: async () => {
      return await ProductApi.getAll();
    },
  });

  return (
    <>
      <ProductCreateModal></ProductCreateModal>
      <table className="table-auto w-[100%]">
        <thead className="">
          <tr>
            <th className="py-4 px-6 text-left bg-slate-100 font-medium">Id</th>
            <th className="py-4 px-6 text-left bg-slate-100 font-medium">
              Image
            </th>
            <th className="py-4 px-6 text-left bg-slate-100 font-medium">
              Product Name
            </th>
            <th className="py-4 px-6 text-left bg-slate-100 font-medium">
              Description
            </th>
            <th className="py-4 px-6 text-left bg-slate-100 font-medium">
              Price
            </th>
            <th className="py-4 px-6 text-left bg-slate-100 font-medium">
              Category
            </th>
            <th className="py-4 px-6 text-left bg-slate-100 font-medium">
              IsActive
            </th>
            <th className="py-4 px-6 text-left bg-slate-100 font-medium">
              Action
            </th>
          </tr>
        </thead>
        <tbody>
          {data?.map((item: Product) => {
            return (
              <ProductTableItem key={item.id} item={item}></ProductTableItem>
            );
          })}
        </tbody>
      </table>
    </>
  );
};

export default ProductTable;
