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

        //bool Update(ProductCategoryUpdateRequest request);

        // Public

        PagedResult<CategoryNavigationGetResult> GetProductCategoryNavigation();
    }
    public partial class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "upload";

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IStorageService storageService)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._storageService = storageService;
        }

        #region Manage
        public PagedResult<ProductCategory> GetProductCategories(ProductCategoryPagingManageGetRequest request)
        {
            return _productCategoryRepository.GetProductCategories(request);
        }

        public bool Create(ProductCategoryCreateRequest request)
        {
            if (request.BadgeIconFile != null)
            {
                request.BadgeIcon = this.SaveFile(request.BadgeIconFile);
            }

            if (request.ImageFile != null)
            {
                request.Image = this.SaveFile(request.ImageFile);
            }

            return _productCategoryRepository.Create(request);
        }

        public bool Update(ProductCategoryCreateRequest request)
        {
            if (request.BadgeIconFile != null)
            {
                request.BadgeIcon = this.SaveFile(request.BadgeIconFile);
            }

            if (request.ImageFile != null)
            {
                request.Image = this.SaveFile(request.ImageFile);
            }

            return _productCategoryRepository.Create(request);
        }

        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
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
