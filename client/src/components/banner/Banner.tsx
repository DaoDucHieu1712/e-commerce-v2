import { Carousel } from "antd";

const Banner = () => {
  return (
    <>
      <Carousel autoplay>
        <img
          src="https://file.hstatic.net/1000281824/file/2ecedf6f821d5e43070c_fe5354733485427890bf420999152c7d.jpg"
          alt=""
          className="h-[900px] object-cover"
        />
        <img
          src="https://file.hstatic.net/1000281824/file/a8104da010d2cc8c95c3_9bb8f82b04a1418896740f2ef4a9b668.jpg"
          alt=""
          className="h-[900px] object-cover"
        />
        <img
          src="https://file.hstatic.net/1000281824/file/f0bdcce291904dce1481_23b37e67574d4bc4922e7e53c880fa58.jpg"
          alt=""
          className="h-[900px] object-cover"
        />
      </Carousel>
    </>
  );
};

export default Banner;
