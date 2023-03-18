using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Common.Constants;
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

        PagedResult<BannerManageGetResult> Get(BannerPagingManageGetRequest request);

        bool Create(BannerManageCreateRequest request);

        bool Update(BannerManageUpdateRequest request);

        bool Delete(int id);

        // Public

        BannerPublicGetResult GetBannerMain();
    }

    public partial class BannerService : IBannerService
    {
        private IBannerRepository _bannerRepository;

        public BannerService(IBannerRepository bannerRepository)
        {
            this._bannerRepository = bannerRepository;
        }

        #region Manage

        public PagedResult<BannerManageGetResult> Get(BannerPagingManageGetRequest request)
        {
            return _bannerRepository.Get(request);
        }

        public bool Create(BannerManageCreateRequest request)
        {
            return _bannerRepository.Create(request);
        }

        public bool Update(BannerManageUpdateRequest request)
        {
            return _bannerRepository.Update(request);
        }

        public bool Delete(int id)
        {
            return _bannerRepository.Delete(id);
        }

        #endregion

        #region Public
        public BannerPublicGetResult GetBannerMain()
        {
            BannerPublicGetRequest request = new BannerPublicGetRequest()
            {
                Page = "home",
                Position = "main",
            };

            BannerPublicGetResult result = _bannerRepository.Get(request).FirstOrDefault();

            if (result != null)
            {
                result.Image = ManageApiHostContant.baseURL + result.Image;
            }

            return result;
        }
        #endregion
    }
}
