using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Data.Repositories
{
    public partial interface IProductCategoryRepository
    {
        // Manage
        List<ProductCategoryFilterSelect> GetProductCategoryParentAndGroupSelectFilter(string name);

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
    public partial class ProductCategorytRepository : IProductCategoryRepository
    {
        private IDatabaseHelper _dbHelper;
        public ProductCategorytRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        #region Manage

        public PagedResult<ProductCategory> GetProductCategories(ProductCategoryPagingManageGetRequest request)
        {
            string[] valueJsonColumns = { "Items" };
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_productcategory_getproductcategoriesmanage", "@request", requestJson);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var productCategories = dt.ConvertTo<PagedResult<ProductCategory>>(valueJsonColumns).FirstOrDefault();
                return productCategories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(ProductCategoryCreateRequest request)
        {
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_productcategory_create",
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

        public bool Update(ProductCategoryUpdateRequest request)
        {
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_productcategory_update",
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_productcategory_delete",
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

        public bool DeleteMulti(List<int> ids)
        {
            try
            {
                string msgError = "";
                var requestJson = ids != null ? MessageConvert.SerializeObject(ids) : null;
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_productcategory_deletemulti",
                "@ids", requestJson
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

        public List<ProductCategoryHomeNavigation> GetProductCategoryNavigation()
        {
            string[] valueJsonColumns = { "ProductCategoryGroups" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_ProductCategory_GetPublicNavigation");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var productFeatures = dt.ConvertTo<ProductCategoryHomeNavigation>(valueJsonColumns).ToList();
                return productFeatures;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductCategoryFeatureHome> GetProductCategoriesFeaturesHome()
        {
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_ProductCategory_GetPublicFeatures");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var productFeatures = dt.ConvertTo<ProductCategoryFeatureHome>().ToList();
                return productFeatures;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductCategoryTopBannerGetResult GetProductCategoryTopBanner(int id)
        {
            string[] valueJsonColumns = { "Slide", "BannerFirst", "BannerSecond" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_productcategory_getproductcategorytopbanner", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var productCategories = dt.ConvertTo<ProductCategoryTopBannerGetResult>(valueJsonColumns).FirstOrDefault();
                return productCategories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductCategoryBoxFilterGetResult GetProductCategoryBoxFilter(int id)
        {
            string[] valueJsonColumns = { "BrandsFilter", "RangePricesFilter", "ProductAttributesFilter" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_productcategory_getproductcategoryboxfilter", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var productCategories = dt.ConvertTo<ProductCategoryBoxFilterGetResult>(valueJsonColumns).FirstOrDefault();
                return productCategories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductCategoryFilterSelect> GetProductCategoryParentAndGroupSelectFilter(string? name)
        {
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_productcategory_getproductcategoryparentandgroupfilter","@name",name);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var productFeatures = dt.ConvertTo<ProductCategoryFilterSelect>().ToList();
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
