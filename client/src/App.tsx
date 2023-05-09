import { Route, Routes } from "react-router-dom";
import HomePage from "./pages/HomePage";
import Layout from "./pages/Layout";
function App() {
  return (
    <>
      <Routes>
        <Route element={<Layout />}>
          <Route path="/" element={<HomePage />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
