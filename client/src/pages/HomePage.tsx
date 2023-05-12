import Banner from "../components/banner/Banner";
import Feature from "../components/feature/Feature";
import ProductList from "../features/product/components/ProductList";

const HomePage = () => {
  return (
    <>
      <Banner></Banner>
      <Feature></Feature>
      <ProductList id="1"></ProductList>
      <ProductList id="2"></ProductList>
      <ProductList id="3"></ProductList>
      <ProductList id="4"></ProductList>
    </>
  );
};

export default HomePage;
