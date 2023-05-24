import { Breadcrumb } from "antd";
import { NavLink, useLocation } from "react-router-dom";

const Breadcumb = () => {
  const location = useLocation();
  const breadCrumbView = () => {
    const { pathname } = location;
    const pathnames = pathname.split("/").filter((item) => item);
    const capatilize = (s: string) => s.charAt(0).toUpperCase() + s.slice(1);
    return (
      <Breadcrumb>
        {pathnames.map((name, index) => {
          const routeTo = `/${pathnames.slice(0, index + 1).join("/")}`;
          const isLast = index === pathnames.length - 1;
          return isLast ? (
            <Breadcrumb.Item key={name}>{capatilize(name)}</Breadcrumb.Item>
          ) : (
            <Breadcrumb.Item key={name}>
              <NavLink to={`${routeTo}`}>{capatilize(name)}</NavLink>
            </Breadcrumb.Item>
          );
        })}
      </Breadcrumb>
    );
  };

  return <>{breadCrumbView()}</>;
};

export default Breadcumb;
