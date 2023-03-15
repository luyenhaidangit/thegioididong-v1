using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
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

        // Public

        PagedResult<CategoryNavigationGetResult> GetProductCategoryNavigation();
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

        #endregion

        #region Public

        public PagedResult<CategoryNavigationGetResult> GetProductCategoryNavigation()
        {
            return _productCategoryRepository.GetProductCategoryNavigation();
        }

        

        #endregion
    }
}
