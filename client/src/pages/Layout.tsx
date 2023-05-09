import { NavLink, Outlet } from "react-router-dom";
import UserIcon from "../components/icon/UserIcon";
import BarIcon from "../components/icon/BarIcon";

const Layout = () => {
  return (
    <>
      <div className="header shadow-md">
        <div className="container mx-auto">
          <div className="grid grid-cols-2 lg:grid-cols-3 gap-4">
            <div className="flex items-center justify-center">
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
            <div className="flex items-center justify-center md:justify-center">
              <UserIcon></UserIcon>
            </div>
          </div>
        </div>
      </div>
      {/* RenderBody */}
      <Outlet></Outlet>
      {/* RenderBody */}
      <div className="footer">
        <div className="container mx-auto">
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4"></div>
        </div>
      </div>
    </>
  );
};

export default Layout;
