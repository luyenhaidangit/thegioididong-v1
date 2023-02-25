using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;

namespace Thegioididong.Service
{
    public partial interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> Search(int pageIndex, int pageSize, out long total, int? id, string name, string option);

        bool Create(ProductCategory productCategory);

        bool Update(ProductCategory model);

        List<CategoryMainNavigation> GetCategoryMainNavigation();
    }
    public partial class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            this._productCategoryRepository = productCategoryRepository;
        }
        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> Search(int pageIndex, int pageSize, out long total, int? MaDanhMuc, string TenDanhMuc, string option)
        {
            return _productCategoryRepository.Search(pageIndex, pageSize, out total, MaDanhMuc, TenDanhMuc, option);
        }

        public bool Create(ProductCategory productCategory)
        {
            return _productCategoryRepository.Create(productCategory);
        }

        public bool Update(ProductCategory productCategory)
        {
            return _productCategoryRepository.Update(productCategory);
        }

        public List<CategoryMainNavigation> GetCategoryMainNavigation()
        {
            return _productCategoryRepository.GetCategoryMainNavigation();
        }
    }
}
