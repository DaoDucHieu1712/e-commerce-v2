import { Button, Modal } from "antd";
import { useState } from "react";

interface ProductDeleteModalProps {
  id: string;
  name?: string;
  onLoad?: () => Promise<void>;
}
const ProductDeleteModal = ({ id, name }: ProductDeleteModalProps) => {
  const [open, setOpen] = useState(false);

  const showModal = () => {
    setOpen(true);
  };

  const hideModal = () => {
    setOpen(false);
  };

  const confirm = async (id: string) => {
    console.log(id);
  };

  return (
    <div className="text-lg text-yellow-400 font-medium">
      <Button type="primary" onClick={showModal}>
        Delete
      </Button>
      <Modal
        title="Delete Student"
        open={open}
        onOk={() => confirm(id)}
        onCancel={hideModal}
        okText="Yes"
        cancelText="No"
      >
        <p>
          Do you want to delete <span className="abc">{name}</span>
        </p>
      </Modal>
    </div>
  );
};

export default ProductDeleteModal;
