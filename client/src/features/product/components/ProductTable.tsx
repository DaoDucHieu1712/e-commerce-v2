import { Switch } from "antd";

const ProductTable = () => {
  return (
    <>
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
              IsActive
            </th>
            <th className="py-4 px-6 text-left bg-slate-100 font-medium">
              Action
            </th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td className="py-4 px-6 text-left">#1</td>
            <td className="py-4 px-6 text-left">
              <img
                src="https://product.hstatic.net/1000281824/product/3f0dfdd8-83d9-41fc-8bc2-ee28708a229b_5befa0d288b244f79ca4b777875b8e8f_large.jpeg"
                alt=""
                className="object-cover w-[120px] h-[120px] border-[1px]"
              />
            </td>
            <td className="py-4 px-6 text-left">Test Basic Tee</td>
            <td className="py-4 px-6 text-left">
              <p className="whitespace-nowrap overflow-hidden text-ellipsis w-[65px]">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Sunt,
                ipsa? At, possimus accusamus! Aperiam praesentium voluptas
                optio, pariatur odio magni, voluptatum quis tenetur repudiandae
                quo odit obcaecati possimus, error fugit.
              </p>
            </td>
            <td className="py-4 px-6 text-left">120 $</td>
            <td className="py-4 px-6 text-left">
              <Switch defaultChecked onChange={() => console.log("OK")} />
            </td>
            <td className="py-4 px-6 text-left"></td>
          </tr>
        </tbody>
      </table>
    </>
  );
};

export default ProductTable;
