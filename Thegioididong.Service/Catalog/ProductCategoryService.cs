using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Common.Constants;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service.Common;

namespace Thegioididong.Service
{
    public partial interface IProductCategoryService
    {
        // Manage
        PagedResult<ProductCategory> GetProductCategories(ProductCategoryPagingManageGetRequest request);

        bool Create(ProductCategoryCreateRequest request);

        bool Update(ProductCategoryUpdateRequest request);

        bool Delete(int id);

        bool DeleteMulti(List<int> ids);

        // Public

        List<ProductCategoryHomeNavigation> GetProductCategoryNavigation();

        List<ProductCategoryFeatureHome> GetProductCategoriesFeaturesHome();

        ProductCategoryTopBannerGetResult GetProductCategoryTopBanner(int id);

        ProductCategoryBoxFilterGetResult GetProductCategoryBoxFilter(int id);
    }
    public partial class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            this._productCategoryRepository = productCategoryRepository;
        }

        #region Manage
        public PagedResult<ProductCategory> GetProductCategories(ProductCategoryPagingManageGetRequest request)
        {
            return _productCategoryRepository.GetProductCategories(request);
        }

        public bool Create(ProductCategoryCreateRequest request)
        {
            return _productCategoryRepository.Create(request);
        }

        public bool Update(ProductCategoryUpdateRequest request)
        {
            return _productCategoryRepository.Update(request);
        }

        public bool Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public bool DeleteMulti(List<int> ids)
        {
            return _productCategoryRepository.DeleteMulti(ids);
        }

        #endregion

        #region Public

        public List<ProductCategoryHomeNavigation> GetProductCategoryNavigation()
        {
            List<ProductCategoryHomeNavigation> result = _productCategoryRepository.GetProductCategoryNavigation();

            if (result != null)
            {
                foreach (var productCategory in result)
                {
                    if (productCategory.BadgeIcon != null)
                    {
                        productCategory.BadgeIcon = ManageApiHostContant.baseURL + productCategory.BadgeIcon;
                    }
                }
            }

            return result;
        }

        public List<ProductCategoryFeatureHome> GetProductCategoriesFeaturesHome()
        {
            List<ProductCategoryFeatureHome> result = _productCategoryRepository.GetProductCategoriesFeaturesHome();

            if (result != null)
            {
                foreach(var productCategory in result)
                {
                    if(productCategory.Image != null)
                    {
                        productCategory.Image = ManageApiHostContant.baseURL + productCategory.Image;
                    }
                }
            }

            return result;
        }

        public ProductCategoryTopBannerGetResult GetProductCategoryTopBanner(int id)
        {
            ProductCategoryTopBannerGetResult result = _productCategoryRepository.GetProductCategoryTopBanner(id);

            if (result != null)
            {
                if (result.Slide != null)
                {
                    foreach (var slideItem in result.Slide.SlideItems)
                    {
                        if (slideItem.Image != null)
                        {
                            slideItem.Image = ManageApiHostContant.baseURL + slideItem.Image;
                        }
                       
                    }
                }

                if (result.BannerFirst != null)
                {
                    if(result.BannerFirst.Image!= null)
                    {
                        result.BannerFirst.Image = ManageApiHostContant.baseURL + result.BannerFirst.Image;
                    }
                }

                if (result.BannerSecond != null)
                {
                    if (result.BannerSecond.Image != null)
                    {
                        result.BannerSecond.Image = ManageApiHostContant.baseURL + result.BannerSecond.Image;
                    }
                }
            }

            return result;
        }

        public ProductCategoryBoxFilterGetResult GetProductCategoryBoxFilter(int id)
        {
            ProductCategoryBoxFilterGetResult result = _productCategoryRepository.GetProductCategoryBoxFilter(id);
            if (result != null)
            {
                if(result.BrandsFilter != null && result.BrandsFilter.Count > 0)
                {
                    foreach(var brand in result.BrandsFilter)
                    {
                        if(brand.Image!= null)
                        {
                            brand.Image = ManageApiHostContant.baseURL + brand.Image;
                        }
                    }
                }
            }
            return result;
        }

        #endregion
    }
}
