import { useMutation } from "@tanstack/react-query";
import { Button, ConfigProvider, DatePicker, Form, Input, Select } from "antd";
import { NavLink, useNavigate } from "react-router-dom";
import AuthApi from "../api/AuthApi";
import { toast } from "react-toastify";

const SignUpPage = () => {
  const navigate = useNavigate();
  const mutation = useMutation({
    mutationFn: async (data: any) => {
      await AuthApi.signUp(data).then((res) => res);
    },
  });

  const handleSignIn = async (values: any) => {
    const data = {
      customer: { ...values, image: "" },
      email: values.email,
      password: values.password,
    };
    mutation.mutate(data);
  };

  if (mutation.isSuccess) {
    toast("register successful !!!!!");
    navigate("/signin");
  }

  return (
    <>
      <div className="header">
        <div className="container mx-auto">
          <NavLink to="/">
            <img src="logo.png" alt="logo" className="w-[120px]" />
          </NavLink>
        </div>
      </div>
      <div className="container mx-auto">
        <div className="grid grid-cols-1 md:grid-cols-1 lg:grid-cols-3 gap-4">
          <div className="hidden lg:block"></div>
          <div className="shadow-lg px-8 pt-10 pb-8">
            <div className="mb-10">
              <h1 className="font-bold text-3xl text-center p-3">Register</h1>
              <p className="text-center">
                You have an account?{" "}
                <NavLink to="/signin" className="text-blue-500">
                  Sign In
                </NavLink>
              </p>
            </div>
            <ConfigProvider
              theme={{
                token: {
                  colorText: "white",
                  colorTextBase: "white",
                },
              }}
            >
              {mutation.isError ? (
                <p className="text-red-500 text-sm text-center my-3">
                  {mutation.error.message}
                </p>
              ) : null}

              <Form layout="vertical" onFinish={handleSignIn}>
                <Form.Item
                  name="fullName"
                  rules={[
                    {
                      required: true,
                      message: "Please enter your full name",
                    },
                    { whitespace: true },
                    { min: 3 },
                  ]}
                  hasFeedback
                  label="Full Name"
                >
                  <Input size="middle" placeholder="type your full name ..." />
                </Form.Item>
                <Form.Item
                  name="gender"
                  rules={[
                    { required: true, message: "please select gender !!" },
                  ]}
                  label="Gender"
                  hasFeedback
                >
                  <Select size="middle" placeholder="Select your gender">
                    <Select.Option value={true}>Male</Select.Option>
                    <Select.Option value={false}>Female</Select.Option>
                  </Select>
                </Form.Item>
                <Form.Item
                  name="dayOfBirth"
                  rules={[
                    {
                      required: true,
                      message: "Please provide your date of birth",
                    },
                  ]}
                  label="Day of birth"
                  hasFeedback
                >
                  <DatePicker
                    size="middle"
                    style={{ width: "100%" }}
                    picker="date"
                    placeholder="Chose date of birth"
                    format={"YYYY-MM-DD"}
                  />
                </Form.Item>
                <Form.Item
                  name="address"
                  rules={[
                    {
                      required: true,
                      message: "Please enter your address",
                    },
                    { whitespace: true },
                    { min: 3 },
                  ]}
                  hasFeedback
                  label="Address"
                >
                  <Input size="middle" placeholder="type your address ..." />
                </Form.Item>
                <Form.Item
                  name="phone"
                  rules={[
                    {
                      required: true,
                      message: "Please enter your phone",
                    },
                    { whitespace: true },
                    { min: 3 },
                  ]}
                  hasFeedback
                  label="Address"
                >
                  <Input size="middle" placeholder="type your phone ..." />
                </Form.Item>
                <Form.Item
                  name="email"
                  rules={[
                    {
                      required: true,
                      message: "Please enter your email",
                    },
                    { whitespace: true },
                    { min: 1 },
                  ]}
                  hasFeedback
                  label="Email"
                  className="mb-6"
                >
                  <Input size="middle" placeholder="type your email ..." />
                </Form.Item>
                <Form.Item
                  name="password"
                  rules={[
                    {
                      required: true,
                      message: "Please enter your password",
                    },
                    { whitespace: true },
                    { min: 3 },
                  ]}
                  hasFeedback
                  label="Password"
                >
                  <Input.Password
                    size="middle"
                    placeholder="type your password ..."
                  />
                </Form.Item>
                <Form.Item>
                  <Button
                    size="middle"
                    block
                    htmlType="submit"
                    className="bg-slate-800 text-white hover: opacity-90 border-none outline-none"
                  >
                    Register
                  </Button>
                </Form.Item>
              </Form>
            </ConfigProvider>
          </div>
          <div className="hidden lg:block"></div>
        </div>
      </div>
    </>
  );
};

export default SignUpPage;
