import { Image } from "antd";
import { useState } from "react";

interface ProductItemProps {
  id?: number | string;
  name: string;
  image: string;
  price: number;
}

const ProductItem = ({ name, image, price }: ProductItemProps) => {
  const [visible, setVisible] = useState(false);
  return (
    <>
      <div className="card cursor-pointer p-3  hover:shadow-xl">
        <div className="h-[280px] overflow-hidden">
          <Image
            preview={{ visible: false }}
            src={image}
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
        <p className="text-center my-3 font-medium">{name}</p>
        <div className="flex items-center justify-between mt-12">
          <span className="text-red-600 font-medium">{price} $</span>
          <button className="border-none outline-none py-2 px-3 bg-slate-600 text-white hover:opacity-90">
            Add to Cart
          </button>
        </div>
      </div>
    </>
  );
};

export default ProductItem;
