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
    public partial interface INewsRepository
    {
        // Manage
        PagedResult<News> Get(NewsPaingPublicGetRequest request);

        News GetById(int id);
    }

    public class NewsRepository : INewsRepository
    {
        private IDatabaseHelper _dbHelper;
        public NewsRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        #region Manage

        #endregion

        #region Public

        public PagedResult<News> Get(NewsPaingPublicGetRequest request)
        {
            string[] valueJsonColumns = { "Items" };
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_News_GetPublicNews", "@request", requestJson);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<PagedResult<News>>(valueJsonColumns).FirstOrDefault();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public News GetById(int id)
        {
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_News_GetPublicDetail", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<News>().FirstOrDefault();
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
