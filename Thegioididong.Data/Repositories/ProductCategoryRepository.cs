using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Data.Repositories
{
    public partial interface IProductCategoryRepository
    {
        // Manage
        PagedResult<ProductCategory> GetProductCategories(ProductCategoryPagingManageGetRequest request);

        bool Create(ProductCategoryCreateRequest request);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> Search(int pageIndex, int pageSize, out long total, int? id, string name, string option);

        bool Update(ProductCategory model);

        // Public

        PagedResult<CategoryNavigationGetResult> GetProductCategoryNavigation();
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

        public IEnumerable<ProductCategory> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_productcategory_getall");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductCategory>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProductCategory> Search(int pageIndex, int pageSize, out long total, int? id, string name, string option)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_productcategory_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@name", name,
                    "@option", option,
                    "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ProductCategory>().ToList();
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

        public bool Update(ProductCategory model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_productcategory_update",
                "@Id", model.Id,
                "@ParentCategoryId", model.ParentProductCategoryId,
                "@Name", model.Name,
                "@DisplayOrder", model.DisplayOrder,
                "@Status", model.Published);
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

        public PagedResult<CategoryNavigationGetResult> GetProductCategoryNavigation()
        {
            string msgError = "";
            string[] valueJsonColumns = { "Items" };
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_productcategory_getproductcategorynavigation");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PagedResult<CategoryNavigationGetResult>>(valueJsonColumns).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
