// React
import React, { useEffect, useState } from 'react'

// Bootstrap
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';

// Style
import "../../../../assets/Styles/Client/Components/Home/DailySuggest.css"
import IconGift from "../../../../assets/Images/Icon/icon-gift.png"
import { AiFillStar } from 'react-icons/ai'

//Api
import DailySuggestApi from '../../../../data/DailySuggest';

// Icon
import LastestIcon from "../../../../assets/Images/Icon/lastest-icon.webp";
import BestSellingIcon from "../../../../assets/Images/Icon/best-selling-icon.png";
import TopRatedIcon from "../../../../assets/Images/Icon/top-rated-icon.webp";
import PopularIcon from "../../../../assets/Images/Icon/popular-icon.webp";

// Helper
import FormatCurrency from '../../../../helpers/Strings/FormatCurrency';

// Api
import { GetProductDailySuggest } from "../../../../apis/Client/productApiService"

const DailySuggest = () => {

    // Hook
    const [dataDailySuggest, setDataDailySuggest] = useState([]);

    useEffect(() => {
        fetchDataDailySuggest();
    }, []);

    // Function
    const fetchDataDailySuggest = async () => {
        let res = await GetProductDailySuggest();
        setDataDailySuggest(res);
    }

    

    const { latestProducts } = dataDailySuggest;
    const { popularProducts } = dataDailySuggest;
    const { bestSellingProducts } = dataDailySuggest;
    const { topRatedProducts } = dataDailySuggest;


    return (
        <>
            {
                dataDailySuggest &&
                <div className='daily-suggest'>
                    <div className='container'>
                        <Tabs
                            defaultActiveKey="latestProducts"
                            id="justify-tab-example"
                            className="mb-3 gap-3"
                            justify
                        >
                            {
                                latestProducts &&
                                <Tab tabClassName='daily-suggest__tab' eventKey="latestProducts" title={<span><img className='daily-suggest__tab-img' src={LastestIcon} alt="Mới nhất" /> Mới nhất</span>}>
                                    <div className="row row-cols-xl-5 row-cols-lg-4 row-cols-md-3 row-cols-sm-2 row-cols-2 g-3">
                                        {
                                            latestProducts && latestProducts.length > 0 &&
                                            latestProducts.map((item, index) => {
                                                return (
                                                    <div className='col' key={`latestProducts-${index}`}>
                                                        <div className='product-card__item px-3 cursor-pointer' key={`hotdeal__item-${index}`}>
                                                            <div className='product-card__item-label d-flex gap-3 mb-3'>
                                                                <span className='product-card__item-label__item' style={{ backgroundColor: "#f1f1f1", color: "#333" }}>Trả góp 0%</span>
                                                            </div>
                                                            <div className='product-card__item-image d-flex justify-content-center mb-3'>
                                                                <img className='img-fluid' src={item.image} alt={"Product Card Imgae"} />
                                                            </div>
                                                            <div className='product-card__item-note d-flex gap-3 mb-2'>
                                                                <span className='product-card__item-note__item d-inline-flex align-items-center gap-1 cursor-pointer' style={{ backgroundColor: "#e91e63", borderRadius: "20px", color: "#fff", padding: "0 6px 0 0", }}>
                                                                    <img className='product-card__item-note__item-img' src={IconGift} alt="product-card__item-note__item" />
                                                                    Đặt trước đến 17/02
                                                                </span>
                                                            </div>
                                                            <h3 className='product-card__item-name mb-1'>
                                                                {item.name}
                                                            </h3>
                                                            <p className='product-card__item-availability mb-1'>
                                                                Hàng sắp về
                                                            </p>
                                                            <strong className='product-card__item-price mb-1'>{FormatCurrency(item.discountedPrice)} <small className='product-card__item-discount-percentage ms-2'>-{item.discountPercent}%</small></strong>
                                                            <p className='product-card__item-rating d-flex align-items-center mb-1'>
                                                                <b className='product-card__item-number-star d-flex align-items-center me-2'>4.8 <AiFillStar /></b>
                                                                (158)
                                                            </p>
                                                            <p className='product-card__item-comment p-0'>Giảm 3 triệu, Trả góp 0%, Thu cũ tài trợ 3 triệu, Ốp lưng BTS</p>
                                                        </div>
                                                    </div>
                                                )
                                            })
                                        }

                                    </div>
                                    <div className='readmore-btn d-flex justify-content-center mt-3 mb-0 cursor-pointer'>
                                        Xem tất cả
                                    </div>
                                </Tab>
                            }

                            {
                                bestSellingProducts &&
                                <Tab tabClassName='daily-suggest__tab' eventKey="popularProducts" title={<span><img className='daily-suggest__tab-img' src={PopularIcon} alt="Bán chạy" /> Bán chạy</span>}>
                                    <div className="row row-cols-xl-5 row-cols-lg-4 row-cols-md-3 row-cols-sm-2 row-cols-2 g-3">
                                        {
                                            bestSellingProducts && bestSellingProducts.length > 0 &&
                                            bestSellingProducts.map((item, index) => {
                                                return (
                                                    <div className='col' key={`bestSellingProducts-${index}`}>
                                                        <div className='product-card__item px-3 cursor-pointer' key={`hotdeal__item-${index}`}>
                                                            <div className='product-card__item-label d-flex gap-3 mb-3'>
                                                                <span className='product-card__item-label__item' style={{ backgroundColor: "#f1f1f1", color: "#333" }}>Trả góp 0%</span>
                                                            </div>
                                                            <div className='product-card__item-image d-flex justify-content-center mb-3'>
                                                                <img className='img-fluid' src={item.image} alt={"Product Card Imgae"} />
                                                            </div>
                                                            <div className='product-card__item-note d-flex gap-3 mb-2'>
                                                                <span className='product-card__item-note__item d-inline-flex align-items-center gap-1 cursor-pointer' style={{ backgroundColor: "#e91e63", borderRadius: "20px", color: "#fff", padding: "0 6px 0 0", }}>
                                                                    <img className='product-card__item-note__item-img' src={IconGift} alt="product-card__item-note__item" />
                                                                    Đặt trước đến 17/02
                                                                </span>
                                                            </div>
                                                            <h3 className='product-card__item-name mb-1'>
                                                                {item.name}
                                                            </h3>
                                                            <p className='product-card__item-availability mb-1'>
                                                                Hàng sắp về
                                                            </p>
                                                            <strong className='product-card__item-price mb-1'>{FormatCurrency(item.discountedPrice)} <small className='product-card__item-discount-percentage ms-2'>-{item.discountPercent}%</small></strong>
                                                            <p className='product-card__item-rating d-flex align-items-center mb-1'>
                                                                <b className='product-card__item-number-star d-flex align-items-center me-2'>4.8 <AiFillStar /></b>
                                                                (158)
                                                            </p>
                                                            <p className='product-card__item-comment p-0'>Giảm 3 triệu, Trả góp 0%, Thu cũ tài trợ 3 triệu, Ốp lưng BTS</p>
                                                        </div>
                                                    </div>
                                                )
                                            })
                                        }

                                    </div>
                                    <div className='readmore-btn d-flex justify-content-center mt-3 mb-0 cursor-pointer'>
                                        Xem tất cả
                                    </div>
                                </Tab>
                            }

                            {
                                popularProducts &&
                                <Tab tabClassName='daily-suggest__tab' eventKey="bestSellingProducts" title={<span><img className='daily-suggest__tab-img' src={BestSellingIcon} alt="Bán chạy" /> Giảm mạnh</span>}>
                                    <div className="row row-cols-xl-5 row-cols-lg-4 row-cols-md-3 row-cols-sm-2 row-cols-2 g-3">
                                        {
                                            popularProducts && popularProducts.length > 0 &&
                                            popularProducts.map((item, index) => {
                                                return (
                                                    <div className='col' key={`popularProducts-${index}`}>
                                                        <div className='product-card__item px-3 cursor-pointer' key={`hotdeal__item-${index}`}>
                                                            <div className='product-card__item-label d-flex gap-3 mb-3'>
                                                                <span className='product-card__item-label__item' style={{ backgroundColor: "#f1f1f1", color: "#333" }}>Trả góp 0%</span>
                                                            </div>
                                                            <div className='product-card__item-image d-flex justify-content-center mb-3'>
                                                                <img className='img-fluid' src={item.image} alt={"Product Card Imgae"} />
                                                            </div>
                                                            <div className='product-card__item-note d-flex gap-3 mb-2'>
                                                                <span className='product-card__item-note__item d-inline-flex align-items-center gap-1 cursor-pointer' style={{ backgroundColor: "#e91e63", borderRadius: "20px", color: "#fff", padding: "0 6px 0 0", }}>
                                                                    <img className='product-card__item-note__item-img' src={IconGift} alt="product-card__item-note__item" />
                                                                    Đặt trước đến 17/02
                                                                </span>
                                                            </div>
                                                            <h3 className='product-card__item-name mb-1'>
                                                                {item.name}
                                                            </h3>
                                                            <p className='product-card__item-availability mb-1'>
                                                                Hàng sắp về
                                                            </p>
                                                            <strong className='product-card__item-price mb-1'>{FormatCurrency(item.discountedPrice)} <small className='product-card__item-discount-percentage ms-2'>-{item.discountPercent}%</small></strong>
                                                            <p className='product-card__item-rating d-flex align-items-center mb-1'>
                                                                <b className='product-card__item-number-star d-flex align-items-center me-2'>4.8 <AiFillStar /></b>
                                                                (158)
                                                            </p>
                                                            <p className='product-card__item-comment p-0'>Giảm 3 triệu, Trả góp 0%, Thu cũ tài trợ 3 triệu, Ốp lưng BTS</p>
                                                        </div>
                                                    </div>
                                                )
                                            })
                                        }

                                    </div>
                                    <div className='readmore-btn d-flex justify-content-center mt-3 mb-0 cursor-pointer'>
                                        Xem tất cả
                                    </div>
                                </Tab>
                            }

                            {
                                topRatedProducts &&
                                <Tab tabClassName='daily-suggest__tab' eventKey="topRatedProducts" title={<span><img className='daily-suggest__tab-img' src={TopRatedIcon} alt="Đánh giá cao" /> Quan tâm</span>}>
                                    <div className="row row-cols-xl-5 row-cols-lg-4 row-cols-md-3 row-cols-sm-2 row-cols-2 g-3">
                                        {
                                            topRatedProducts && topRatedProducts.length > 0 &&
                                            topRatedProducts.map((item, index) => {
                                                return (
                                                    <div className='col' key={`topRatedProducts-${index}`}>
                                                        <div className='product-card__item px-3 cursor-pointer' key={`hotdeal__item-${index}`}>
                                                            <div className='product-card__item-label d-flex gap-3 mb-3'>
                                                                <span className='product-card__item-label__item' style={{ backgroundColor: "#f1f1f1", color: "#333" }}>Trả góp 0%</span>
                                                            </div>
                                                            <div className='product-card__item-image d-flex justify-content-center mb-3'>
                                                                <img className='img-fluid' src={item.image} alt={"Product Card Imgae"} />
                                                            </div>
                                                            <div className='product-card__item-note d-flex gap-3 mb-2'>
                                                                <span className='product-card__item-note__item d-inline-flex align-items-center gap-1 cursor-pointer' style={{ backgroundColor: "#e91e63", borderRadius: "20px", color: "#fff", padding: "0 6px 0 0", }}>
                                                                    <img className='product-card__item-note__item-img' src={IconGift} alt="product-card__item-note__item" />
                                                                    Đặt trước đến 17/02
                                                                </span>
                                                            </div>
                                                            <h3 className='product-card__item-name mb-1'>
                                                                {item.name}
                                                            </h3>
                                                            <p className='product-card__item-availability mb-1'>
                                                                Hàng sắp về
                                                            </p>
                                                            <strong className='product-card__item-price mb-1'>{FormatCurrency(item.discountedPrice)} <small className='product-card__item-discount-percentage ms-2'>-{item.discountPercent}%</small></strong>
                                                            <p className='product-card__item-rating d-flex align-items-center mb-1'>
                                                                <b className='product-card__item-number-star d-flex align-items-center me-2'>4.8 <AiFillStar /></b>
                                                                (158)
                                                            </p>
                                                            <p className='product-card__item-comment p-0'>Giảm 3 triệu, Trả góp 0%, Thu cũ tài trợ 3 triệu, Ốp lưng BTS</p>
                                                        </div>
                                                    </div>
                                                )
                                            })
                                        }
                                    </div>
                                    <div className='readmore-btn d-flex justify-content-center mt-3 mb-0 cursor-pointer'>
                                        Xem tất cả
                                    </div>
                                </Tab>
                            }
                        </Tabs>
                    </div>
                </div>
            }
        </>
    )
}

export default DailySuggest