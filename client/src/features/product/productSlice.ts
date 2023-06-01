import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { RootState } from "../../app/store";
import { Product, ProductFilterAndPaging } from "../../models/Product";

interface ProductState {
  data?: Product[];
  error: string;
  isLoading: boolean;
}

const initialState: ProductState = {
  data: undefined,
  error: "",
  isLoading: false,
};

const productSlice = createSlice({
  name: "product",
  initialState,
  reducers: {
    fetchStudents(state) {
      state.isLoading = true;
    },
    fetchStudentsSuccess(state, action: PayloadAction<Product[]>) {
      state.data = action.payload;
    },
    fetchStudentsError(state, action: PayloadAction<string>) {
      state.error = action.payload;
    },
  },
});

//ACTIONS
export const productAction = productSlice.actions;
//SELECTORS
export const productSelector = (state: RootState) => state.product;
//REDUCER
const productReducer = productSlice.reducer;
export default productReducer;
