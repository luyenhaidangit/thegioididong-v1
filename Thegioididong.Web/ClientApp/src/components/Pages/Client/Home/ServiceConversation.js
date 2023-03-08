// React
import React, { useEffect, useState } from 'react'

// Style
import "../../../../assets/Styles/Client/Components/Home/ServiceConversation.css"

//Api
import ServiceConversationApi from '../../../../data/ServiceConversation'

const ServiceConversation = () => {
    // Hook
    const [dataServiceConversation, setDataServiceConversation] = useState([]);

    useEffect(() => {
        fetchDataServiceConversation();
    }, []);

    // Function
    const fetchDataServiceConversation = async () => {
        let res = await ServiceConversationApi;
        setDataServiceConversation(res);
    }

    return (
        <>
            {
                dataServiceConversation && dataServiceConversation.length > 0 &&
                <div className='service-conversation'>
                    <div className='container'>
                        <div className='service-conversation__title d-flex justify-content-between align-items-center'>
                            <h3 className='mb-0'>Dịch vụ tiện ích</h3>
                            <span className='mb-0 cursor-pointer' >Xem thêm dịch vụ</span>
                        </div>
                        <div className='service-conversation__content d-flex justify-content-center gap-2'>
                            {
                                dataServiceConversation && dataServiceConversation.length > 0 &&
                                dataServiceConversation.map((item, index) => {
                                    return (
                                        <div key={`service-conversation__item-${index}`} className='service-conversation__item cursor-pointer d-flex flex-column gap-1' style={item.style}>
                                            <div className='service-conversation__item-left d-flex align-items-center'>
                                                {
                                                    item.image
                                                }
                                                <span className="service-conversation__item-title ms-2">{item.title}</span>
                                            </div>
                                            <div className='service-conversation__item-right'>
                                                {
                                                    item.bold_description &&
                                                    <strong>{item.bold_description}</strong>
                                                }
                                                {
                                                    item.description &&
                                                    <span>{item.description}</span>
                                                }
                                            </div>
                                            {/* <img className="service-conversation__item-img img-fluid" src={item.image} alt="Shopping Trend" /> */}

                                            {/* <span className="service-conversation__item-title position-absolute">{item.title}</span>
                                            <span className="service-conversation__item-description position-absolute">{item.description}</span> */}
                                        </div>
                                    )
                                })
                            }
                        </div>
                    </div>
                </div>
            }
        </>
    )
}

export default ServiceConversation