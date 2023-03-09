using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Banners;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Data.Repositories
{
    public partial interface IBannerRepository
    {
        // Manage

       

        // Public

        PagedResult<BannerPublicGetResult> GetBanners(BannerPagingPublicGetRequest request);
    }

    public class BannerRepository : IBannerRepository
    {
        private IDatabaseHelper _dbHelper;
        public BannerRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        #region Manage

        #endregion

        #region Public

        public PagedResult<BannerPublicGetResult> GetBanners(BannerPagingPublicGetRequest request)
        {
            string[] valueJsonColumns = { "Items" };
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_banner_getbannerspublic", "@request", requestJson);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var slides = dt.ConvertTo<PagedResult<BannerPublicGetResult>>(valueJsonColumns).FirstOrDefault();
                return slides;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
