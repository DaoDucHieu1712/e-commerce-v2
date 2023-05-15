export interface Account {
  accountId: number;
  name: string;
  role: number;
  accessToken: string;
  refreshToken: string;
}

export interface SignIn {
  email: string;
  password: string;
}

export interface Token {
  accessToken: string | undefined;
  refreshToken: string | undefined;
}

export interface User {
  accountId: number;
  name: string;
  role: number;
}
