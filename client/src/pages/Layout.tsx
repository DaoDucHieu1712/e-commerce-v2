import { NavLink, Outlet } from "react-router-dom";
import UserIcon from "../components/icon/UserIcon";
import BarIcon from "../components/icon/BarIcon";

const Layout = () => {
  return (
    <>
      <div className="header shadow-md">
        <div className="container mx-auto">
          <div className="grid grid-cols-2 lg:grid-cols-3 gap-4">
            <div className="flex items-center justify-start">
              <div className="lg:hidden mr-1">
                <BarIcon></BarIcon>
              </div>
              <img src="logo.png" alt="" className="object-cover w-[100px]" />
            </div>
            <div className="hidden lg:flex items-center justify-center gap-x-12 text-lg">
              <NavLink to="/">Home</NavLink>
              <NavLink to="/about">About</NavLink>
              <NavLink to="/contact">Contact</NavLink>
              <NavLink to="/my-order">Order</NavLink>
            </div>
            <div className="flex items-center justify-center md:justify-end">
              <UserIcon></UserIcon>
            </div>
          </div>
        </div>
      </div>
      {/* RenderBody */}
      <Outlet></Outlet>
      {/* RenderBody */}
      <div className="footer bg-slate-900 text-white py-5">
        <div className="container mx-auto mt-5">
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-x-4">
            <div className="flex flex-col  gap-y-5">
              <h2 className="text-xl text-slate-300 font-bold">About Degrey</h2>
              <p>
                Lorem ipsum, dolor sit amet consectetur adipisicing elit. Illum
                reprehenderit similique, rem beatae voluptas ipsum incidunt quas
                eveniet voluptatum iste nulla animi neque, impedit quaerat
                suscipit nesciunt dolorum quo? Rerum!
              </p>
              <div className="item">
                <h1 className="text-lg font-bold">DEGREY TNHH</h1>
                <p>
                  Lorem ipsum dolor sit amet consectetur adipisicing elit.
                  Dolorum similique quo vel nihil? Blanditiis ab ducimus eos
                  sapiente reprehenderit quis enim corporis
                </p>
              </div>
            </div>
            <div className="flex flex-col gap-4">
              <h1 className="text-lg font-bold">Address</h1>
              <p>
                43 Huỳnh Văn Bánh P.17 Q.Phú Nhuận 1041 Luỹ Bán Bích P.Tân Thành
                Q.Tân Phú
              </p>
              <p>Dai Thinh - Me Linh - Ha Noi</p>
              <p>Ba Trieu</p>
              <p>Mai Hac De</p>
            </div>
            <div className="flex flex-col gap-4">
              <h1 className="text-lg font-bold">Customer Support</h1>
              <li>Lorem ipsum dolor sit amet</li>
              <li>Lorem ipsum dolor sit amet</li>
              <li>Lorem ipsum dolor sit amet</li>
              <li>Lorem ipsum dolor sit amet</li>
              <li>Lorem ipsum dolor sit amet</li>
              <li>Lorem ipsum dolor sit amet</li>
            </div>
            <div className="flex flex-col gap-4">
              <h1 className="text-lg font-bold">Services</h1>
              <p>Design by Dao Duc Hieu</p>
              <p>
                <strong>Phone :</strong>012344556676
              </p>
              <p>
                <strong>Email :</strong>hieuddhe151352@fpt.edu.vn
              </p>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Layout;
