import axios from "axios";
import { useEffect } from "react";
import { toast } from "react-toastify";

interface UploadImageProps {
  setUrl: React.Dispatch<React.SetStateAction<string>>;
  name?: string;
}

const UploadImage = ({ setUrl }: UploadImageProps) => {
  useEffect(() => {
    console.log("reload");
  }, [setUrl]);

  const handleUploadImage = async (e: any) => {
    const file = e.target.files;
    if (!file) toast.error("File not exist !!");
    const bodyFormData = new FormData();
    bodyFormData.append("image", file[0]);
    const res = await axios({
      method: "post",
      url: `https://api.imgbb.com/1/upload?key=7eef4b3d48ffb2383bf921eeb1dd5117`,
      data: bodyFormData,
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });

    const ImageData = res.data.data;
    if (!ImageData) {
      toast.error("Can not upload image !!");
      return;
    }
    const url_image = ImageData.thumb.url;
    setUrl(url_image.toString());
  };

  return (
    <label className="flex items-center justify-center w-full cursor-pointer h-[206px] border boder-gray-200 border-dashed rounded-lg mb-3">
      <input type="file" onChange={handleUploadImage} hidden />
      {/* <UploadOutlined /> */}
    </label>
  );
};

export default UploadImage;
