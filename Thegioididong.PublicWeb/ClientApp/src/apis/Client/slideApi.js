import axios from '../../helpers/Apis/axiosCustomize';

const GetSlideHeaderTopClient = () => {
    //Data
    return axios.get('api/Slide/GetSlides?Page=client&Position=header_top');
}

export {
    GetSlideHeaderTopClient
};