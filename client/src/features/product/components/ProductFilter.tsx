import { FilterOutlined } from "@ant-design/icons";
import { useQuery } from "@tanstack/react-query";
import { Button, Form, Input, Select, Slider } from "antd";
import CategoryApi from "../../../api/CategoryApi";
import { useAppDispatch } from "../../../app/hooks";
import { Category } from "../../../models/Category";
import { SearchProductParams } from "../../../models/Product";
import { fetchStudents } from "../productHandler";

const ProductFilter = () => {
  const dispatch = useAppDispatch();
  const [form] = Form.useForm();
  const onSubmitHandler = async (values: any) => {
    const data: SearchProductParams = {
      name: values.name,
      toPrice: values.price[0],
      fromPrice: values.price[1],
      categoryId: values.categoryId,
      sortType: values.sortType,
    };
    console.log(data);
    await fetchStudents(data, dispatch);
  };

  const onResetFilter = () => {
    form.resetFields();
  };

  const { data } = useQuery({
    queryKey: ["category"],
    queryFn: async () => await CategoryApi.getAllCategory().then((res) => res),
  });
  return (
    <>
      <Form className="my-3" onFinish={onSubmitHandler} form={form}>
        <div className="grid  md:grid-cols-6 gap-x-3 p-4 md:p-0">
          <Form.Item name="categoryId">
            <Select size="large" placeholder="select category ... ">
              {data?.map((item: Category) => (
                <Select.Option key={item.id} value={item.id}>
                  {item.name}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>
          <Form.Item name="price" initialValue={[0, 300]}>
            <Slider range={{ draggableTrack: true }} max={1000} />
          </Form.Item>
          <Form.Item name="sortType">
            <Select size="large" placeholder="sort .. ">
              <Select.Option value="name-asc">Name - A to Z</Select.Option>
              <Select.Option value="name-desc">Name - Z to A</Select.Option>
              <Select.Option value="price-asc">
                Price - Low to High
              </Select.Option>
              <Select.Option value="price-desc">
                Price - High to Low
              </Select.Option>
            </Select>
          </Form.Item>
          <Form.Item name="name">
            <Input size="large" placeholder="typing name product .. " />
          </Form.Item>
          <Form.Item>
            <Button
              htmlType="submit"
              size="large"
              type="primary"
              className="w-full flex items-center justify-center"
              danger
            >
              <FilterOutlined className="text-white text-xl" />
            </Button>
          </Form.Item>
          <Form.Item>
            <Button
              size="large"
              htmlType="button"
              type="primary"
              className="w-full"
              onClick={onResetFilter}
            >
              Reset
            </Button>
          </Form.Item>
        </div>
      </Form>
    </>
  );
};

export default ProductFilter;
