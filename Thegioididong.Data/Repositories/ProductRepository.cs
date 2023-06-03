﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Data.Repositories
{
    public partial interface IProductRepository
    {
        // Manage

        PagedResult<ProductManageGetResult> Get(ProductPagingManageGetRequest request);

        bool Create(ProductManageCreateRequest request);

        bool Update(ProductManageUpdateRequest request);

        bool Delete(int id);

        // Public

        List<ProductItemCardDefault> GetProductsHotDeal();

        List<ProductItemCardDefault> GetProductsRelate(int id);

        List<ProductFeatureHome> GetProductFeaturesHome();

        ProductDailySuggest GetProductDailySuggest();

        ProductDetailPage GetProductDetailPage(int id);

        List<ProductItemCardDefault> GetProductsProductCategoryDetailPage(ProductPaingPublicGetRequest request);

        //List<ProductItemCardProductCategoryPage> GetProductsProductCategoryDetailPage1(ProductPaingPublicGetRequest request);
    }

    public class ProductRepository : IProductRepository
    {
        private IDatabaseHelper _dbHelper;
        public ProductRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        #region Manage

        public PagedResult<ProductManageGetResult> Get(ProductPagingManageGetRequest request)
        {
            string[] valueJsonColumns = { "Items" };
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_getproductsmanage", "@request", requestJson);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<PagedResult<ProductManageGetResult>>(valueJsonColumns).FirstOrDefault();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(ProductManageCreateRequest request)
        {
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_product_create",
                "@request", requestJson);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ProductManageUpdateRequest request)
        {
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_product_update",
                "@request", requestJson);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_product_delete",
                "@id", id
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Public

        public ProductDailySuggest GetProductDailySuggest()
        {
            string[] valueJsonColumns = { "LatestProducts", "PopularProducts", "SellingProducts", "TopRatedProducts" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetPublicDailySuggest");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<ProductDailySuggest>(valueJsonColumns).FirstOrDefault();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDetailPage GetProductDetailPage(int id)
        {
            //string[] valueJsonColumns = { "ProductVariants", "ProductAttributes" };
            string[] valueJsonColumns = { "ProductVariants" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_getproductdetailpage", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<ProductDetailPage>(valueJsonColumns).FirstOrDefault();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductItemCardDefault> GetProductsRelate(int id)
        {
            string[] valueJsonColumns = { "BadgeProduct" };

            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Products_GetPublicRelate", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<ProductItemCardDefault>(valueJsonColumns).ToList();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductItemCardDefault> GetProductsHotDeal()
        {
            string[] valueJsonColumns = { "BadgeProduct" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetPublicHotDeal");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<ProductItemCardDefault>(valueJsonColumns).ToList();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductItemCardDefault> GetProductsProductCategoryDetailPage(ProductPaingPublicGetRequest request)
        {
            string[] valueJsonColumns = { "BadgeProduct", "SpecialAttribute", "ProductAttributesOption" };
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetPublicProducts", "@request", requestJson);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<ProductItemCardDefault>(valueJsonColumns).ToList();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductFeatureHome> GetProductFeaturesHome()
        {
            string[] valueJsonColumns = { "Slide", "Products" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetPublicFeatures");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var productFeatures = dt.ConvertTo<ProductFeatureHome>(valueJsonColumns).ToList();
                return productFeatures;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
