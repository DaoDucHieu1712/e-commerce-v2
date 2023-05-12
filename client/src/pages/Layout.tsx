import { NavLink, Outlet } from "react-router-dom";
import UserIcon from "../components/icon/UserIcon";
import BarIcon from "../components/icon/BarIcon";
import { useState } from "react";
import { Button, Drawer } from "antd";

const Layout = () => {
  const [open, setOpen] = useState(false);

  const showDrawer = () => {
    setOpen(true);
  };

  const onClose = () => {
    setOpen(false);
  };
  return (
    <>
      <div className="header shadow-md">
        <div className="container mx-auto">
          <div className="grid grid-cols-2 lg:grid-cols-3 gap-4">
            <div className="flex items-center justify-start">
              <div className="lg:hidden mr-1">
                <Button onClick={showDrawer} className="border-none">
                  <BarIcon></BarIcon>
                </Button>
                <Drawer
                  title="Hello, Dao Duc Hieu"
                  placement="right"
                  onClose={onClose}
                  open={open}
                >
                  <div className="flex flex-col items-center justify-center gap-y-12 text-lg">
                    <NavLink to="/">Home</NavLink>
                    <NavLink to="/about">About</NavLink>
                    <NavLink to="/contact">Contact</NavLink>
                    <NavLink to="/my-order">Order</NavLink>
                    <NavLink to="/sign-in">Logout</NavLink>
                  </div>
                </Drawer>
              </div>
              <img src="logo.png" alt="" className="object-cover w-[100px]" />
            </div>
            <div className="hidden lg:flex items-center justify-center gap-x-12 text-lg">
              <NavLink to="/">Home</NavLink>
              <NavLink to="/about">About</NavLink>
              <NavLink to="/contact">Contact</NavLink>
              <NavLink to="/my-order">Order</NavLink>
            </div>
            <div className="flex items-center justify-end">
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
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4">
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
              <p>43 Huỳnh Văn Bánh P.17 Q.Phú Nhuận 10</p>
              <p>41 Luỹ Bán Bích P.Tân Thành Q.Tân Phú</p>
              <p>Dai Thinh - Me Linh - Ha Noi</p>
              <p>Ba Trieu</p>
              <p>Mai Hac De</p>
              <p>Lorem ipsum dolor abc xyz</p>
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
                <strong>Phone : </strong>012344556676
              </p>
              <p>
                <strong>Email : </strong>hieuddhe151352@fpt.edu.vn
              </p>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Layout;
