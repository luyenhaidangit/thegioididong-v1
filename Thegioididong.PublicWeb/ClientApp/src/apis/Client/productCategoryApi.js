import axios from '../../helpers/Apis/axiosCustomize';

const GetProductCategoryNavigation = () => {
    //Data
    let data = {
    }

    return axios.get('api/ProductCategory/GetProductCategoryNavigation', data);
}

export {
    GetProductCategoryNavigation
};