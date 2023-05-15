import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { RootState } from "../../app/store";
import { User } from "../../models/Account";

interface AuthState {
  user: User | undefined;
  isLoading?: boolean;
  isError?: string;
}

const CurrentUser: User = JSON.parse(
  localStorage.getItem("user_ecommerce_asp") || "{}"
);

const initialState: AuthState = {
  user: CurrentUser,
  isLoading: false,
  isError: "",
};

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    login(state) {
      state.isLoading = true;
    },
    loginSuccess(state) {
      state.isLoading = false;
      state.isError = "";
    },
    loginFailed(state, action: PayloadAction<string>) {
      state.isError = action.payload;
    },
  },
});

//ACTIONS
export const authActions = authSlice.actions;
//SELECTORS
export const selectorAuth = (state: RootState) => state.auth;
//REDUCER
const authReducer = authSlice.reducer;
export default authReducer;
