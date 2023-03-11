// React
import React, { useEffect, useState } from 'react'

import ScrollContainer from 'react-indiana-drag-scroll'

// Style
import "../../../../assets/Styles/Client/Components/Home/DiscountPayOnline.css"

//Api
import DiscountPayOnlineApi from '../../../../data/DiscountPayOnline';

const DiscountPayOnline = () => {
    // Hook
    const [dataDiscountPayOnline, setDataDiscountPayOnline] = useState([]);

    useEffect(() => {
        fetchDataDiscountPayOnline();
    }, []);

    // Function
    const fetchDataDiscountPayOnline = async () => {
        let res = await DiscountPayOnlineApi;
        setDataDiscountPayOnline(res);
    }

    return (
        <>
            {
                dataDiscountPayOnline && dataDiscountPayOnline.length > 0 &&
                <div className='discount-pay-online'>
                    <div className='container'>
                        <div className='discount-pay-online__title'>
                            <h3 className='mb-0'>Giảm thêm khi thanh toán online</h3>
                        </div>
                        <ScrollContainer className='discount-pay-online__content d-flex gap-4'>
                            {
                                dataDiscountPayOnline && dataDiscountPayOnline.length > 0 &&
                                dataDiscountPayOnline.map((item, index) => {
                                    return (
                                        <div key={`discount-pay-online__item-${index}`} className='discount-pay-online__item d-flex flex-column justify-content-start align-items-center cursor-pointer gap-2'>
                                            <img className="dicount-pay-online__item-img" src={item.image} alt="Discount Pay Online" />
                                        </div>
                                    )
                                })
                            }
                        </ScrollContainer>
                    </div>
                </div>
            }
        </>
    )
}

export default DiscountPayOnline