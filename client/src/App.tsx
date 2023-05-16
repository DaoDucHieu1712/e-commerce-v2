import { Route, Routes } from "react-router-dom";
import HomePage from "./pages/HomePage";
import Layout from "./pages/Layout";
import SignInPage from "./pages/SignInPage";
import DashBoardLayout from "./pages/DashBoardLayout";
import SignUpPage from "./pages/SignUpPage";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import ProductTable from "./features/product/components/ProductTable";

const queryClient = new QueryClient();
function App() {
  return (
    <>
      <QueryClientProvider client={queryClient}>
        <Routes>
          <Route element={<Layout />}>
            <Route path="/" element={<HomePage />} />
          </Route>
          <Route element={<DashBoardLayout />}>
            <Route path="/dashboard" element={<>Day la dashboard</>}></Route>
            <Route path="/dashboard/product" element={<ProductTable />}></Route>
            <Route
              path="/dashboard/product/category"
              element={<>Day la product category</>}
            ></Route>
            <Route
              path="/dashboard/bill"
              element={<>Day la bill list</>}
            ></Route>
            <Route
              path="/dashboard/bill/create"
              element={<>Day la create bill</>}
            ></Route>
            <Route
              path="/dashboard/bill/total"
              element={<>Day la total bill</>}
            ></Route>
            <Route
              path="/dashboard/customer"
              element={<>Day la customer</>}
            ></Route>
            <Route
              path="/dashboard/employee"
              element={<>Day la employee</>}
            ></Route>
            <Route
              path="/dashboard/chart"
              element={<>Day la chart page</>}
            ></Route>
            <Route
              path="/dashboard/setting"
              element={<>Day la setting</>}
            ></Route>
          </Route>
          <Route path="/signin" element={<SignInPage />}></Route>
          <Route path="/signup" element={<SignUpPage />}></Route>
          <Route path="*" element={<>404 Not found !</>}></Route>
        </Routes>
      </QueryClientProvider>
    </>
  );
}

export default App;
