using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Banners;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Service.CMS
{
    public partial interface IBannerService
    {
        // Manage

        // Public

        PagedResult<BannerPublicGetResult> GetBanners(BannerPagingPublicGetRequest request);
    }

    public partial class BannerService : IBannerService
    {
        private IBannerRepository _bannerRepository;

        public BannerService(IBannerRepository bannerRepository)
        {
            this._bannerRepository = bannerRepository;
        }

        #region Manage


        #endregion

        #region Public
        public PagedResult<BannerPublicGetResult> GetBanners(BannerPagingPublicGetRequest request)
        {
            return _bannerRepository.GetBanners(request);   
        }

        #endregion
    }
}
