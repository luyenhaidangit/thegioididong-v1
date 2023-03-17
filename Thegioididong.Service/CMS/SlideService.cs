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

        PagedResult<SlidePublicGetResult> GetSlides(SlidePagingPublicGetRequest request);
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

        public PagedResult<SlidePublicGetResult> GetSlides(SlidePagingPublicGetRequest request)
        {
            PagedResult<SlidePublicGetResult> result = _slideRepository.GetSlides(request);

            foreach (var slide in result.Items)
            {
                if (slide != null)
                {
                    foreach (var slideChild in slide.SlideItems)
                    {
                        if (slideChild != null && slideChild.Image!=null)
                        {
                            slideChild.Image = ManageApiHostContant.baseURL + slideChild.Image;
                        }
                    }
                } 
            }

            return result;
        }

        #endregion
    }
}
