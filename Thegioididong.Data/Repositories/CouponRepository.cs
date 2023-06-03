using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.News;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Data.Repositories
{
    public partial interface ICounponRepository
    {
        // Manage
        List<Coupon> Get();

        Coupon GetById(int id);
    }

    public class CounponRepository : ICounponRepository
    {
        private IDatabaseHelper _dbHelper;
        public CounponRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        #region Manage

        #endregion

        #region Public

        public List<Coupon> Get()
        {
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Counpon_GetPublic");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<Coupon>().ToList();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Coupon GetById(int id)
        {
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Coupon_GetPublicDetail", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<Coupon>().FirstOrDefault();
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
