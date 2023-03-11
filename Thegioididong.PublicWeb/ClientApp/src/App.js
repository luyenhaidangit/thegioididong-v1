// Library
import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

// Client
import Layout from './components/Layouts/Client/Layout';
import Home from "./pages/Client/Home"
import Product from './pages/Client/Product';

// Style
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/Styles/Client/Common/Common.css'
import ProductCategory from './pages/Client/ProductCategory';

function App() {
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<Layout />}>
            <Route index element={<Home />} />
            <Route path='product' element={<Product />} />
            <Route path='productcategory' element={<ProductCategory />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
