import { toast } from "react-toastify";
import { logOut, saveToken, setUser } from "../../config/auth";
import { authActions } from "./authSlice";
import AuthApi from "../../api/AuthApi";

export const loginHandler = async (data: any, dispatch: any, navigate: any) => {
  dispatch(authActions.login());
  try {
    logOut();
    const res = await AuthApi.signIn(data);
    console.log(res);
    setUser(res);
    dispatch(authActions.loginSuccess());
    saveToken(res.accessToken, res.refreshToken);
    navigate("/");
  } catch (error) {
    dispatch(authActions.loginFailed(`${error}`));
    toast.error(`${error}`);
  }
};
