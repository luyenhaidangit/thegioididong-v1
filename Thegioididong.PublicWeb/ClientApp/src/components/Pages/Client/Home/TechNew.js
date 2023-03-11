// React
import React, { useEffect, useState } from 'react'
import ScrollContainer from 'react-indiana-drag-scroll'

// Style
import "../../../../assets/Styles/Client/Components/Home/TechNew.css"

//Api
import TechNewApi from '../../../../data/TechNew';

// Imgage
import BannerNew from "../../../../assets/Images/TechNew/banner-new.webp"

const TechNew = () => {
    // Hook
    const [dataTechNew, setDataTechNew] = useState([]);

    useEffect(() => {
        fetchDataTechNew();
    }, []);

    // Function
    const fetchDataTechNew = async () => {
        let res = await TechNewApi;
        setDataTechNew(res);
    }


    return (
        <>
            {
                dataTechNew && dataTechNew.length > 0 &&
                <div className='tech-new'>
                    <div className='container d-flex justify-content-beetween gap-3'>
                        <div className='tech-new__new'>
                            <div className='tech-new__new-title d-flex justify-content-between align-items-center'>
                                <h3 className='mb-0'>24h công nghệ</h3>
                                <span className='mb-0 cursor-pointer' >Xem tất cả</span>
                            </div>
                            <div className='tech-new__new-content gap-3'>
                                <ScrollContainer className='tech-new__new-content-list-new gap-2'>
                                    {
                                        dataTechNew.map((item, index) => {
                                            return (
                                                <div key={`new__item-${index}`} className='tech-new__new-item cursor-pointer flex-1 gap-2' style={item.style}>
                                                    <img className='new__item-img' src={item.image} alt="New" />
                                                    <span className='new__item-title'>{item.title}</span>
                                                </div>
                                            )
                                        })
                                    }
                                </ScrollContainer>
                            </div>
                        </div>
                        <div className='tech-new__banner cursor-pointer'>
                            <img className='tech-new__banner-img' src={BannerNew} alt="Banner New" />
                        </div>
                    </div>
                </div>
            }
        </>
    )
}

export default TechNew