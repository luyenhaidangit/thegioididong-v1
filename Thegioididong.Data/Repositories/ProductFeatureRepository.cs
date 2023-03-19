using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.Features.ProductFeature;

namespace Thegioididong.Data.Repositories
{
    public partial interface IProductFeatureRepository
    {
        // Manage



        // Public

        List<ProductFeatureHome> GetProductFeaturesHome();
    }

    public class ProductFeatureRepository : IProductFeatureRepository
    {
        private IDatabaseHelper _dbHelper;
        public ProductFeatureRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        #region Manage

        #endregion

        #region Public

        public List<ProductFeatureHome> GetProductFeaturesHome()
        {
            string[] valueJsonColumns = { "Slide", "Products" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_productfeature_getproductfeatureshome");
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
