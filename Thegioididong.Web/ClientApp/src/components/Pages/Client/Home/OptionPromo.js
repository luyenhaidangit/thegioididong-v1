// React
import React, { useEffect, useState } from 'react'

// Style
import "../../../../assets/Styles/Client/Components/Home/OptionPromo.css"

//Api
import OptionPromoApi from '../../../../data/OptionPromo';

const OptionPromo = () => {
    // Hook
    const [dataOptionPromo, setDataOptionPromo] = useState([]);

    useEffect(() => {
        fetchDataOptionPromo();
    }, []);

    // Function
    const fetchDataOptionPromo = async () => {
        let res = await OptionPromoApi;
        setDataOptionPromo(res);
    }

    return (
        <>
            {
                dataOptionPromo && dataOptionPromo.length > 0 &&
                <div className='option-promo'>
                    <div className='container d-flex justify-content-between align-items-center gap-4 mt-4'>
                        {
                            dataOptionPromo && dataOptionPromo.length > 0 &&
                            dataOptionPromo.map((item, index) => {
                                return (
                                    <div key={`option-promo__item-${index}`} className='option-promo__item d-flex justify-content-center align-items-center gap-2 w-100'>
                                        <img className='option-promo__item-img img-fluid' src={item.image} alt="option promo item" />
                                        <span className='option-promo__item-title'>{item.title}</span>
                                    </div>
                                )
                            })
                        }
                    </div>
                </div>
            }
        </>
    )
}

export default OptionPromo