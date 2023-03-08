// React
import React, { useEffect, useState } from 'react'

import ScrollContainer from 'react-indiana-drag-scroll'

// Style
import "../../../../assets/Styles/Client/Components/Home/NewChain.css"

//Api
import NewChainApi from '../../../../data/NewChain';

const NewChain = () => {
    // Hook
    const [dataNewChain, setDataNewChain] = useState([]);

    useEffect(() => {
        fetchDataNewChain();
    }, []);

    // Function
    const fetchDataNewChain = async () => {
        let res = await NewChainApi;
        setDataNewChain(res);
    }

    return (
        <>
            {
                dataNewChain && dataNewChain.length > 0 &&
                <div className='newchain'>
                    <div className='container'>
                        <div className='newchain__title'>
                            <h3 className='mb-0'>Chuỗi mới deal khủng</h3>
                        </div>
                        <ScrollContainer className='newchain__content d-flex gap-2'>
                            {
                                dataNewChain && dataNewChain.length > 0 &&
                                dataNewChain.map((item, index) => {
                                    return (
                                        <div key={`newchain__item-${index}`} className='newchain__item d-flex flex-column justify-content-start align-items-center cursor-pointer gap-2'>
                                            <img className="newchain__item-img" src={item.image} alt="Discount Pay Online" />
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

export default NewChain