import { Button, ConfigProvider, Form, Input } from "antd";
import { NavLink, useNavigate } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { loginHandler } from "../features/auth/authHandler";
import { selectorAuth } from "../features/auth/authSlice";
const SignInPage = () => {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  const handleSignIn = async (values: FormData) => {
    await loginHandler(values, dispatch, navigate);
  };

  const auth = useAppSelector(selectorAuth);

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
              <p className="text-red-500 text-sm text-center my-3">
                {auth.isError}
              </p>
              <Form layout="vertical" onFinish={handleSignIn}>
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
          <div className="hidden lg:block"></div>
        </div>
      </div>
    </>
  );
};

export default SignInPage;
