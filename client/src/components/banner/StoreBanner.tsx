import BannerStore from "../../assets/store_banner.jpg";
const StoreBanner = () => {
  return (
    <div className="container mx-auto mb-5 my-24">
      <img
        src={BannerStore}
        alt="storebanner"
        className="object-cover h-[350px] w-full"
      />
    </div>
  );
};

export default StoreBanner;
