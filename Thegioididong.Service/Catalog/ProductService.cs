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
using Thegioididong.Model.ViewModels.CMS.Slides;

namespace Thegioididong.Service
{
    public partial interface IProductService
    {
        // Manage

        PagedResult<ProductManageGetResult> Get(ProductPagingManageGetRequest request);

        bool Create(ProductManageCreateRequest request);

        bool Update(ProductManageUpdateRequest request);

        bool Delete(int id);

        // Public

        ProductDailySuggest GetProductDailySuggest();

        List<ProductItemCardDefault> GetProductsHotDeal();

        List<ProductFeatureHome> GetProductFeaturesHome();

        ProductDetailPage GetProductDetailPage(int id);

        List<ProductItemCardDefault> GetProductsRelate(int id);

        List<Coupon> GetCouponProduct(int id);

        PagedResult<ProductItemCardDefault> GetProductsProductCategoryDetailPage(ProductPaingPublicGetRequest request);
    }
    public partial class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        #region Manage

        public PagedResult<ProductManageGetResult> Get(ProductPagingManageGetRequest request)
        {
            return _productRepository.Get(request);
        }

        public bool Create(ProductManageCreateRequest request)
        {
            return _productRepository.Create(request);
        }

        public bool Update(ProductManageUpdateRequest request)
        {
            return _productRepository.Update(request);
        }

        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        #endregion

        #region Public

        public ProductDailySuggest GetProductDailySuggest()
        {
            ProductDailySuggest result = _productRepository.GetProductDailySuggest();

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

            foreach (var product in result.SellingProducts)
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

        public List<ProductItemCardDefault> GetProductsHotDeal()
        {
            List<ProductItemCardDefault> result = _productRepository.GetProductsHotDeal();

            if (result != null)
            {
                foreach (var product in result)
                {
                    product.Image = ManageApiHostContant.baseURL + product.Image;
                    if (product?.BadgeProduct != null)
                    {
                        product.BadgeProduct.Image = ManageApiHostContant.baseURL + product?.BadgeProduct?.Image;
                    }
                }
            }

            return result;
        }

        public List<ProductItemCardDefault> GetProductsRelate(int id)
        {
            List<ProductItemCardDefault> result = _productRepository.GetProductsRelate(id);

            if (result != null)
            {
                foreach (var product in result)
                {
                    product.Image = ManageApiHostContant.baseURL + product.Image;
                    if (product?.BadgeProduct != null)
                    {
                        product.BadgeProduct.Image = ManageApiHostContant.baseURL + product?.BadgeProduct?.Image;
                    }
                }
            }

            return result;
        }

        public List<ProductFeatureHome> GetProductFeaturesHome()
        {
            List<ProductFeatureHome> result = _productRepository.GetProductFeaturesHome();
            if (result != null)
            {
                foreach (var productFeature in result)
                {
                    if (productFeature.Slide != null)
                    {
                        foreach (var slideItem in productFeature.Slide.SlideItems)
                        {
                            slideItem.Image = ManageApiHostContant.baseURL + slideItem.Image;
                        }
                    }

                    if (productFeature.Products != null)
                    {
                        foreach (var product in productFeature.Products)
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

        public ProductDetailPage GetProductDetailPage(int id)
        {
            return _productRepository.GetProductDetailPage(id);
        }

        public PagedResult<ProductItemCardDefault> GetProductsProductCategoryDetailPage(ProductPaingPublicGetRequest request)
        {
            List<ProductItemCardDefault> result = _productRepository.GetProductsProductCategoryDetailPage(request);
            if (result != null && result.Count > 0)
            {
                foreach (var product in result)
                {
                    if (product.Image != null)
                    {
                        product.Image = ManageApiHostContant.baseURL + product.Image;
                    }

                    if (product.BadgeProduct != null)
                    {
                        if (product.BadgeProduct.Image != null)
                        {
                            product.BadgeProduct.Image = ManageApiHostContant.baseURL + product.BadgeProduct.Image;
                        }
                    }
                }
            }

            //Tính toán trang hiện tại
            int currentPageIndex = request.PageIndex.GetValueOrDefault(1);
            int pageSize = request.PageSize.GetValueOrDefault(0);
            int pageIndex = request.PageIndex.GetValueOrDefault(1);

            int totalItems = result.Count;
            int totalPages = (int)Math.Ceiling(totalItems / (double)request.PageSize);

            //Lấy danh sách sản phẩm cho trang hiện tại
            result = result.Skip((currentPageIndex - 1) * pageSize).Take(pageSize).ToList();

            PagedResult<ProductItemCardDefault> result1 = new PagedResult<ProductItemCardDefault>();
            result1.Items = result;
            result1.PageIndex = pageIndex;
            result1.PageSize = pageSize;
            result1.TotalPages = totalPages;
            result1.TotalRecords = result.Count;

            return result1;
        }

        public List<Coupon> GetCouponProduct(int id)
        {
            return _productRepository.GetCouponProduct(id);
        }

        #endregion
    }
}
