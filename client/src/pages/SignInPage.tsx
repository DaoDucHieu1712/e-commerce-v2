import { Button, ConfigProvider, Form, Input } from "antd";
import { NavLink } from "react-router-dom";
const SignInPage = () => {
  return (
    <>
      <div className="header">
        <div className="container mx-auto">
          <img src="logo.png" alt="logo" className="w-[120px]" />
        </div>
      </div>
      <div className="container mx-auto">
        <div className="grid grid-cols-3 gap-4">
          <div></div>
          <div className="shadow-lg px-8 pt-10 pb-36">
            <div className="mb-10">
              <h1 className="font-bold text-3xl text-center p-3">
                Welcome back !!!
              </h1>
              <p className="text-center">
                Dont have an account?{" "}
                <NavLink to="/signup" className="text-blue-500">
                  Sign Up
                </NavLink>
              </p>
            </div>
            <ConfigProvider
              theme={{
                token: {
                  colorPrimary: "#1e2021",
                },
              }}
            >
              <Form layout="vertical">
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
                  <Input size="large" placeholder="type your email ..." />
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
                    size="large"
                    placeholder="type your password ..."
                  />
                </Form.Item>

                <Form.Item>
                  <Button
                    size="large"
                    block
                    htmlType="submit"
                    className="bg-slate-800 text-white hover: opacity-90 border-none outline-none"
                  >
                    Sign-In
                  </Button>
                </Form.Item>
              </Form>
            </ConfigProvider>
          </div>
          <div></div>
        </div>
      </div>
    </>
  );
};

export default SignInPage;
