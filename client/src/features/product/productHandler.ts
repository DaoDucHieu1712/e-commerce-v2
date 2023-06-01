import ProductApi from "../../api/ProductApi";
import { SearchProductParams } from "./../../models/Product";
import { productAction } from "./productSlice";

export const fetchStudents = async (
  params: SearchProductParams,
  dispatch: any
) => {
  dispatch(productAction.fetchStudents());
  try {
    const response = await ProductApi.searchAdvance(params);
    dispatch(productAction.fetchStudentsSuccess(response));
  } catch (error) {
    dispatch(productAction.fetchStudentsError(`${error}`));
  }
};
