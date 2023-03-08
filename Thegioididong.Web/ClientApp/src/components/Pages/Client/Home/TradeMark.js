// React
import React, { useEffect, useState } from 'react'
import ScrollContainer from 'react-indiana-drag-scroll'

// Style
import "../../../../assets/Styles/Client/Components/Home/TradeMark.css"


//Api
import TradeMarkApi from '../../../../data/TradeMark';

const TradeMark = () => {
    // Hook
    const [dataTradeMark, setDataTradeMark] = useState([]);

    useEffect(() => {
        fetchDataTradeMark();
    }, []);

    // Function
    const fetchDataTradeMark = async () => {
        let res = await TradeMarkApi;
        setDataTradeMark(res);
    }

    return (
        <>
            {
                dataTradeMark && dataTradeMark.length > 0 &&
                <div className='trademark'>
                    <div className='container'>
                        <div className='trademark__title'>
                            <h3 className='mb-0'>Chuyên trang thương hiệu</h3>
                        </div>
                        <ScrollContainer className='trademark__content d-flex gap-2'>
                            {
                                dataTradeMark && dataTradeMark.length > 0 &&
                                dataTradeMark.map((item, index) => {
                                    return (
                                        <div key={`trademark__item-${index}`} className='trademark__item d-flex flex-column justify-content-start align-items-center cursor-pointer gap-2'>
                                            <img className="trademark__item-img" src={item.image} alt="Discount Pay Online" />
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

export default TradeMark