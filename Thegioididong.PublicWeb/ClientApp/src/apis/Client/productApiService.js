import axios from '../../helpers/Apis/axiosCustomize';

const GetProductDailySuggest = () => {
    //Data
    return axios.get('api/Product/GetProductDailySuggest');
}

export {
    GetProductDailySuggest
};