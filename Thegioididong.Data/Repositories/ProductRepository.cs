using System;
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

        ProductDailySuggestGetResult GetProductDailySuggest();
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

        public ProductDailySuggestGetResult GetProductDailySuggest()
        {
            string[] valueJsonColumns = { "LatestProducts", "PopularProducts", "BestSellingProducts", "TopRatedProducts" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_getproductdailysuggest");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<ProductDailySuggestGetResult>(valueJsonColumns).FirstOrDefault();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
