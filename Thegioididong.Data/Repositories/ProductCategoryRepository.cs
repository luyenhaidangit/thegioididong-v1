using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;

namespace Thegioididong.Data.Repositories
{
    public partial interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> Search(int pageIndex, int pageSize, out long total, int? id, string name, string option);

        bool Create(ProductCategory model);

        bool Update(ProductCategory model);

        List<CategoryMainNavigation> GetCategoryMainNavigation();
    }
    public partial class ProductCategorytRepository : IProductCategoryRepository
    {
        private IDatabaseHelper _dbHelper;
        public ProductCategorytRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
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

        public List<CategoryMainNavigation> GetCategoryMainNavigation()
        {
            string msgError = "";
            string[] valueJsonColumns = { "ProductCategoryGroups", "ProductCategories" };
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_home_GetMainNavigationData");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CategoryMainNavigation>(valueJsonColumns).ToList();
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

        public bool Create(ProductCategory model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_productcategory_create",
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
    }
}
