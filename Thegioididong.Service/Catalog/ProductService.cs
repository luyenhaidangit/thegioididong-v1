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
        PagedResult<Product> GetProducts(ProductPagingManageGetRequest request);
    }
    public partial class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public PagedResult<Product> GetProducts(ProductPagingManageGetRequest request)
        {
            return _productRepository.GetProducts(request);
        }
    }
}
