using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Service
{
    public partial interface IProductService
    {
        // Manage

        PagedResult<Product> GetProducts(ProductPagingManageGetRequest request);

        // Public

        ProductDailySuggestGetResult GetProductDailySuggest();
    }
    public partial class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        #region Manage

        public PagedResult<Product> GetProducts(ProductPagingManageGetRequest request)
        {
            return _productRepository.GetProducts(request);
        }

        #endregion

        #region Public

        public ProductDailySuggestGetResult GetProductDailySuggest()
        {
            return _productRepository.GetProductDailySuggest();
        }

        #endregion
    }
}
