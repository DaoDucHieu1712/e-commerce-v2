import { Button, Form, Input, Modal } from "antd";
import { useState } from "react";

const ProductUpdateModal = () => {
  const [open, setOpen] = useState(false);
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
      .then((values: any) => {
        console.log(values);
      })
      .catch(() => {
        console.log("error");
      });
  };
  return (
    <div>
      <Button onClick={showModal}>Detail</Button>

      <Modal
        title="Detail Product"
        open={open}
        onOk={confirm}
        onCancel={hideModal}
        okText="Yes"
        cancelText="No"
        width={1440}
      >
        <Form form={form} layout="vertical" name="detail">
          <Form.Item
            name="name"
            label="Name"
            rules={[{ required: true, message: "Please enter the cat name" }]}
          >
            <Input />
          </Form.Item>
          <Form.Item
            name="price"
            label="Price"
            rules={[{ required: true, message: "Please enter the cat price" }]}
          >
            <Input type="number" />
          </Form.Item>
          <Form.Item
            name="origin"
            label="Origin"
            rules={[{ required: true, message: "Please enter the cat origin" }]}
          >
            <Input />
          </Form.Item>
          <Form.Item
            name="avatar"
            label="Avatar"
            rules={[
              { required: true, message: "Please enter the cat avatar URL" },
            ]}
          >
            <Input />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default ProductUpdateModal;
