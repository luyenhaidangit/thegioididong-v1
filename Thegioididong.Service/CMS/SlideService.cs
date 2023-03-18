using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Common.Constants;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service.Common;

namespace Thegioididong.Service
{
    public partial interface ISlideService
    {
        // Manage

        bool Create(SlideCreateRequest request);

        bool Update(SlideUpdateRequest request);

        bool Delete(int id);

        PagedResult<SlideManageGetResult> GetSlides(SlidePagingManageGetRequest request);

        // Public

        SlidePublicGetResult GetSlideHeaderTop();

        SlidePublicGetResult GetSlideBigCampaign();
    }
    public partial class SlideService : ISlideService
    {
        private ISlideRepository _slideRepository;

        public SlideService(ISlideRepository slideRepository)
        {
            this._slideRepository = slideRepository;
        }

        #region Manage

        public bool Create(SlideCreateRequest request) 
        {
            return _slideRepository.Create(request);
        }

        public bool Delete(int id)
        {
            return _slideRepository.Delete(id);
        }

        public PagedResult<SlideManageGetResult> GetSlides(SlidePagingManageGetRequest request)
        {
            return _slideRepository.GetSlides(request);
        }

        public bool Update(SlideUpdateRequest request)
        {
            return _slideRepository.Update(request);
        }
        #endregion

        #region Public

        public SlidePublicGetResult GetSlideHeaderTop()
        {
            SlidePublicGetRequest request = new SlidePublicGetRequest()
            {
                Page = "client",
                Position = "header_top",
            };

            SlidePublicGetResult result = _slideRepository.GetSlides(request).FirstOrDefault();

            if(result!=null)
            {
                foreach (var slideItem in result.SlideItems)
                {
                    slideItem.Image = ManageApiHostContant.baseURL + slideItem.Image;
                }
            }

            return result;
        }

        public SlidePublicGetResult GetSlideBigCampaign()
        {
            SlidePublicGetRequest request = new SlidePublicGetRequest()
            {
                Page = "home",
                Position = "big_campaign",
            };

            SlidePublicGetResult result = _slideRepository.GetSlides(request).FirstOrDefault();

            if (result != null)
            {
                foreach (var slideItem in result.SlideItems)
                {
                    slideItem.Image = ManageApiHostContant.baseURL + slideItem.Image;
                }
            }

            return result;
        }


        #endregion
    }
}
