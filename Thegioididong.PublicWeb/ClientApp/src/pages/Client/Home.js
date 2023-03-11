// React
import React from 'react'

// Components
import BannerTopzone from '../../components/Pages/Client/Home/BannerTopzone'
import BigBanner from '../../components/Pages/Client/Home/BigBanner'
import BigCampaign from '../../components/Pages/Client/Home/BigCampaign'
import CategoryFeature from '../../components/Pages/Client/Home/CategoryFeature'
import DailySuggest from '../../components/Pages/Client/Home/DailySuggest'
import DiscountPayOnline from '../../components/Pages/Client/Home/DiscountPayOnline'
import HotDeal from '../../components/Pages/Client/Home/HotDeal'
import NewChain from '../../components/Pages/Client/Home/NewChain'
import OptionPromo from '../../components/Pages/Client/Home/OptionPromo'
import PromoAnother from '../../components/Pages/Client/Home/PromoAnother'
import ServiceConversation from '../../components/Pages/Client/Home/ServiceConversation'
import ShoppingTrend from '../../components/Pages/Client/Home/ShoppingTrend'
import TechNew from '../../components/Pages/Client/Home/TechNew'
import TradeMark from '../../components/Pages/Client/Home/TradeMark'

const Home = () => {
    return (
        <div className='content'>
            <BigBanner />
            <div className='main-content position-relative'>
                <BigCampaign />
                <OptionPromo />
                <BannerTopzone />
                <HotDeal />
                <PromoAnother />
                <ShoppingTrend />
                <CategoryFeature />
                <DiscountPayOnline />
                <ServiceConversation />
                <DailySuggest />
                <TechNew />
                <TradeMark />
                <NewChain />
            </div>
        </div>
    )
}

export default Home