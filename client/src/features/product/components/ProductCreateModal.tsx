import { useQuery } from "@tanstack/react-query";
import { Button, Form, Input, InputNumber, Modal, Select } from "antd";
import { useState } from "react";
import { toast } from "react-toastify";
import CategoryApi from "../../../api/CategoryApi";
import ProductApi from "../../../api/ProductApi";
import UploadImage from "../../../components/uploadImage/UploadImage";

const ProductCreateModal = () => {
  const [open, setOpen] = useState(false);
  const [UrlImage, setUrlImage] = useState<string>("");
  const [form] = Form.useForm();
  const showModal = () => {
    setOpen(true);
  };

  const hideModal = () => {
    setOpen(false);
  };

  const confirm = async () => {
    form
      .validateFields()
      .then(async (values: any) => {
        const NewProduct = { image: UrlImage, ...values };
        console.log(NewProduct);
        await ProductApi.create(NewProduct)
          .then(() => {
            toast.success("Add new Product successful !!");
            setOpen(false);
            form.resetFields();
            setUrlImage("");
          })
          .catch((error) => {
            toast.error(`Uh Oh, an error : ${error} !!`);
          });
      })
      .catch(() => {
        console.log("error");
      });
  };
  const { data } = useQuery({
    queryKey: ["category"],
    queryFn: async () => await CategoryApi.getAllCategory().then((res) => res),
  });
  return (
    <div className="my-3">
      <Button onClick={showModal}>Add new a product</Button>
      <Modal
        title="Detail Product"
        open={open}
        onOk={confirm}
        onCancel={hideModal}
        okText="Yes"
        cancelText="No"
        width={1000}
      >
        <Form
          form={form}
          layout="vertical"
          name="detail"
          className="flex gap-x-8 justify-center my-7"
        >
          <div className="w-full flex flex-col gap-y-3">
            <Form.Item
              name="name"
              label="Name"
              rules={[
                { required: true, message: "please enter the product name !!" },
              ]}
              hasFeedback
            >
              <Input placeholder="type product name ..." />
            </Form.Item>
            <UploadImage setUrl={setUrlImage} />
            <Form.Item
              name="price"
              rules={[{ required: true, message: "please select price !!" }]}
              label="Price"
            >
              <InputNumber min={0} size="large" className="w-full" />
            </Form.Item>
          </div>
          <div className="w-full">
            <Form.Item
              name="description"
              label="Description"
              rules={[
                { required: true, message: "please enter decription !!" },
              ]}
              className="w-full"
            >
              <Input.TextArea
                maxLength={200}
                style={{ resize: "none" }}
                rows={12}
                showCount
                placeholder="type description ..."
              />
            </Form.Item>

            <Form.Item
              name="categoryId"
              rules={[{ required: true, message: "please select category !!" }]}
              label="Category"
              hasFeedback
            >
              <Select size="large" placeholder="select category ... ">
                {data?.map((item) => {
                  return (
                    <Select.Option key={item.id} value={item.id}>
                      {item.name}
                    </Select.Option>
                  );
                })}
              </Select>
            </Form.Item>
          </div>
        </Form>
      </Modal>
    </div>
  );
};

export default ProductCreateModal;
