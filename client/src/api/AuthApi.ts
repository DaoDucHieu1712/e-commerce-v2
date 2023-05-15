import { Account, SignIn, Token } from "../models/Account";
import axiosClient from "./axiosClient";

const AuthApi = {
  signIn(data: SignIn): Promise<Account> {
    const url = "/Auth/SignIn";
    return axiosClient.post(url, data);
  },
  signUp(data: any): Promise<string> {
    const url = "/Auth/SignUp";
    return axiosClient.post(url, data);
  },
  refreshToken(data: Token): Promise<Token> {
    const url = "/Auth/RefreshToken";
    return axiosClient.post(url, data);
  },
};

export default AuthApi;
