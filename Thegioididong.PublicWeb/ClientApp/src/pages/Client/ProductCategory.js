// React
import React from 'react'
import BoxFilter from '../../components/Pages/Client/ProductCategory/BoxFilter'
import ProductList from '../../components/Pages/Client/ProductCategory/ProductList'
import TopBanner from '../../components/Pages/Client/ProductCategory/TopBanner'

// Components


const ProductCategory = () => {
    return (
        <div className='content'>
            <TopBanner />
            <BoxFilter />
            <ProductList />
        </div>
    )
}

export default ProductCategory