import Cookies from "js-cookie";
import { Account, User } from "../models/Account";
const accessTokenKey = "ecommerce_access_token_asp";
const refreshTokenKey = "ecommerce_refresh_token_asp";
const objCookies = {
  expires: 30,
  domain: "localhost",
};

export const saveToken = (
  access_token: string | undefined,
  refresh_token: string | undefined
) => {
  if (access_token && refresh_token) {
    Cookies.set(accessTokenKey, access_token, {
      ...objCookies,
    });
    Cookies.set(refreshTokenKey, refresh_token, {
      ...objCookies,
    });
  } else {
    Cookies.remove(accessTokenKey, {
      ...objCookies,
      path: "/",
      domain: "localhost",
    });
    Cookies.remove(refreshTokenKey, {
      ...objCookies,
      path: "/",
      domain: "localhost",
    });
  }
};

export const getToken = () => {
  const access_token = Cookies.get(accessTokenKey);
  const refresh_token = Cookies.get(refreshTokenKey);
  return {
    access_token,
    refresh_token,
  };
};

export const logOut = () => {
  const access_token = Cookies.get(accessTokenKey);
  localStorage.removeItem("user_ecommerce_asp");
  if (access_token) {
    Cookies.remove(accessTokenKey, {
      ...objCookies,
      path: "/",
      domain: "localhost",
    });
    Cookies.remove(refreshTokenKey, {
      ...objCookies,
      path: "/",
      domain: "localhost",
    });
  }
};

export const getCurrentUser = () => {
  const CurrentUser: User = JSON.parse(
    localStorage.getItem("user_ecommerce_asp") || "null"
  );
  return CurrentUser;
};

export const setUser = (res: Account) => {
  localStorage.setItem(
    "user_ecommerce_asp",
    JSON.stringify({
      accountId: res.accountId,
      name: res.name,
      role: res.role,
    })
  );
};
