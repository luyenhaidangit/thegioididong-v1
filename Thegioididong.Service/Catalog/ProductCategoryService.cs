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
using Thegioididong.Service.Common;

namespace Thegioididong.Service
{
    public partial interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> Search(int pageIndex, int pageSize, out long total, int? id, string name, string option);

        bool Create(ProductCategoryCreateRequest request);

        bool Update(ProductCategory model);

        List<CategoryMainNavigation> GetCategoryMainNavigation();
    }
    public partial class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "Upload";

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IStorageService storageService)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._storageService = storageService;
        }
        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> Search(int pageIndex, int pageSize, out long total, int? MaDanhMuc, string TenDanhMuc, string option)
        {
            return _productCategoryRepository.Search(pageIndex, pageSize, out total, MaDanhMuc, TenDanhMuc, option);
        }

        //public bool Create(ProductCategory productCategory)
        //{
        //    return _productCategoryRepository.Create(productCategory);
        //}

        public bool Update(ProductCategory productCategory)
        {
            return _productCategoryRepository.Update(productCategory);
        }

        public List<CategoryMainNavigation> GetCategoryMainNavigation()
        {
            return _productCategoryRepository.GetCategoryMainNavigation();
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

        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}
