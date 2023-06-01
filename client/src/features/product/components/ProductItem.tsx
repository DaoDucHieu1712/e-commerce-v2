import { Image } from "antd";
import { useState } from "react";

interface ProductItemProps {
  id?: number | string;
  name: string;
  image: string;
  price: number;
}

const ProductItem = ({ id, name, image, price }: ProductItemProps) => {
  const [visible, setVisible] = useState(false);
  return (
    <>
      <div className="card cursor-pointer p-3  hover:shadow-xl">
        <div className="h-[280px] overflow-hidden">
          <Image
            preview={{ visible: false }}
            src={image}
            className="w-full"
            onClick={() => setVisible(true)}
          />
          <div style={{ display: "none" }}>
            <Image.PreviewGroup
              preview={{ visible, onVisibleChange: (vis) => setVisible(vis) }}
            >
              <Image src={image} />
            </Image.PreviewGroup>
          </div>
        </div>
        <p className="text-center my-3 font-medium min-h-[35px]">{name}</p>
        <p className="text-red-600 font-medium text-center">{price} $</p>
        <div className="flex items-center justify-between mt-12 gap-x-3">
          <a href={`/store/${id}`} className="w-full">
            <button className="border-none rounded-md outline-none py-2 px-3 bg-slate-900 text-white hover:opacity-90 w-full">
              Detail
            </button>
          </a>
          <button className="border-none rounded-md outline-none py-2 px-3 w-full bg-slate-900 text-white hover:opacity-90">
            Add to Cart
          </button>
        </div>
      </div>
    </>
  );
};

export default ProductItem;
