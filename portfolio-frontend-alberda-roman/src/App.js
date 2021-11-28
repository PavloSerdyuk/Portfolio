import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "shards-ui/dist/css/shards.min.css";

import AuthWindow from "./components/auth";
import Representation from "./components/representation";
import "ag-grid-community/dist/styles/ag-grid.css";
import "ag-grid-community/dist/styles/ag-theme-alpine.css";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Representation />} />
          <Route path="/login" element={<AuthWindow />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
