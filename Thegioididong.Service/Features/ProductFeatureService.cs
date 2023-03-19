using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Common.Constants;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.Features.ProductFeature;

namespace Thegioididong.Service.Features
{
    public partial interface IProductFeatureService
    {
        // Manage

        
        // Public

        List<ProductFeatureHome> GetProductFeaturesHome();
    }

    public partial class ProductFeatureService : IProductFeatureService
    {
        private IProductFeatureRepository _productFeatureRepository;

        public ProductFeatureService(IProductFeatureRepository productFeatureRepository)
        {
            this._productFeatureRepository = productFeatureRepository;
        }

        #region Manage

        #endregion

        #region Public

        public List<ProductFeatureHome> GetProductFeaturesHome()
        {
            List<ProductFeatureHome> result = _productFeatureRepository.GetProductFeaturesHome();
            if(result != null)
            {
                foreach(var productFeature in result)
                {
                    if(productFeature.Slide!= null)
                    {
                        foreach(var slideItem in productFeature.Slide.SlideItems) 
                        {
                            slideItem.Image = ManageApiHostContant.baseURL + slideItem.Image;
                        }
                    }

                    if(productFeature.Products!= null)
                    {
                        foreach(var product in productFeature.Products)
                        {
                            product.Image = ManageApiHostContant.baseURL + product.Image;
                            if (product?.BadgeProduct != null)
                            {
                                product.BadgeProduct.Image = ManageApiHostContant.baseURL + product?.BadgeProduct?.Image;
                            }
                        }
                    }
                }
            }
            return result;
        }

        #endregion
    }
}
