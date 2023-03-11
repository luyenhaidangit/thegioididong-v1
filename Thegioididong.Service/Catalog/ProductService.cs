using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Common.Constants;

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
            ProductDailySuggestGetResult result = _productRepository.GetProductDailySuggest();

            foreach (var product in result.LatestProducts)
            {
                product.Image = ManageApiHostContant.baseURL + product.Image;
                if (product.BadgeProduct != null)
                {
                    product.BadgeProduct.Image = ManageApiHostContant.baseURL + product.BadgeProduct?.Image;
                }
            }

            foreach (var product in result.PopularProducts)
            {
                product.Image = ManageApiHostContant.baseURL + product.Image;
                if (product.BadgeProduct != null)
                {
                    product.BadgeProduct.Image = ManageApiHostContant.baseURL + product.BadgeProduct?.Image;
                }
            }

            foreach (var product in result.BestSellingProducts)
            {
                product.Image = ManageApiHostContant.baseURL + product.Image;
                if (product.BadgeProduct != null)
                {
                    product.BadgeProduct.Image = ManageApiHostContant.baseURL + product.BadgeProduct?.Image;
                }
            }

            foreach (var product in result.TopRatedProducts)
            {
                product.Image = ManageApiHostContant.baseURL + product.Image;
                if (product.BadgeProduct != null)
                {
                    product.BadgeProduct.Image = ManageApiHostContant.baseURL + product.BadgeProduct?.Image;
                }
            }


            return result;
        }

        #endregion
    }
}
