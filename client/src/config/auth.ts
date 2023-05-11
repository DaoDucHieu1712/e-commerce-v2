import Cookies from "js-cookie";
const accessTokenKey = "ecommerce_access_token";
const refreshTokenKey = "ecommerce_refresh_token";
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
  localStorage.removeItem("user");
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
