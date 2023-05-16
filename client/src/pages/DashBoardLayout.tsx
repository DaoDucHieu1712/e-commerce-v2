import React, { useState } from "react";
import {
  LineChartOutlined,
  FileOutlined,
  PieChartOutlined,
  TeamOutlined,
  ShoppingOutlined,
  SettingOutlined,
  LogoutOutlined,
  UserOutlined,
} from "@ant-design/icons";
import { Avatar, MenuProps, Popover } from "antd";
import { Breadcrumb, Layout, Menu, theme } from "antd";
import { NavLink, Outlet, useLocation, useNavigate } from "react-router-dom";
import Breadcumb from "../components/breadcumb/Breadcumb";

const { Header, Content, Footer, Sider } = Layout;

type MenuItem = Required<MenuProps>["items"][number];

function getItem(
  label: React.ReactNode,
  key: React.Key,
  icon?: React.ReactNode,
  children?: MenuItem[]
): MenuItem {
  return {
    key,
    icon,
    children,
    label,
  } as MenuItem;
}

const items: MenuItem[] = [
  getItem("Dashboard", "/dashboard", <PieChartOutlined />),
  getItem("Chart", "/dashboard/chart", <LineChartOutlined />),
  getItem("Product", "sub1", <ShoppingOutlined />, [
    getItem("List", "/dashboard/product"),
    getItem("Category", "/dashboard/product/category"),
  ]),
  getItem("Bill", "sub2", <FileOutlined />, [
    getItem("List", "/dashboard/bill"),
    getItem("Create", "/dashboard/bill/create"),
    getItem("Total", "/dashboard/bill/total"),
  ]),
  getItem("User", "sub3", <TeamOutlined />, [
    getItem("Customer", "/dashboard/customer"),
    getItem("Employee", "/dashboard/employee"),
  ]),
  getItem("Setting", "/dashboard/setting", <SettingOutlined />),
  getItem("Logout", "/logout", <LogoutOutlined />),
];

const DashBoardLayout: React.FC = () => {
  const [collapsed, setCollapsed] = useState(false);
  const {
    token: { colorBgContainer },
  } = theme.useToken();

  const navigate = useNavigate();

  const handlerRedirect = (redirect: any) => {
    console.log(redirect.key);
    navigate(redirect.key);
  };

  return (
    <Layout style={{ minHeight: "100vh" }}>
      <Sider
        collapsible
        collapsed={collapsed}
        onCollapse={(value) => setCollapsed(value)}
        theme="light"
      >
        <NavLink to="/" className="block">
          <img
            src="logo.png"
            alt=""
            className="w-[100px] mx-auto justify-center"
          />
        </NavLink>
        <Menu
          onClick={handlerRedirect}
          theme="light"
          defaultSelectedKeys={["1"]}
          mode="inline"
          items={items}
        />
      </Sider>
      <Layout className="site-layout">
        <Header className="p-6 bg-white flex flex-row-reverse">
          <div className="flex justify-center items-center gap-x-3">
            <span className="text-sm font-extralight">
              Welcome , Dao Duc Hieu !!
            </span>
            <Popover
              placement="bottomRight"
              content={
                <div>
                  <p>Content</p>
                  <p>Content</p>
                </div>
              }
              trigger="click"
            >
              <Avatar icon={<UserOutlined />} className="cursor-pointer" />
            </Popover>
          </div>
        </Header>
        <Content style={{ margin: "16px 16px" }}>
          <Breadcumb></Breadcumb>
          <div
            style={{
              padding: 24,
              minHeight: 360,
              background: colorBgContainer,
            }}
          >
            <Outlet></Outlet>
          </div>
        </Content>
        <Footer className="text-center">
          Ant Design ©2023 Created by Ant UED
        </Footer>
      </Layout>
    </Layout>
  );
};

export default DashBoardLayout;
