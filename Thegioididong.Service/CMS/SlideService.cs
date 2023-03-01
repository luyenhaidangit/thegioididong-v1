using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Service
{
    public partial interface ISlideService
    {
        bool Create(SlideCreateRequest request);

        bool Update(SlideUpdateRequest request);

        PagedResult<Slide> GetSlides(SlidePagingManageGetRequest request);
    }
    public partial class SlideService : ISlideService
    {
        private ISlideRepository _slideRepository;

        public SlideService(ISlideRepository slideRepository)
        {
            this._slideRepository = slideRepository;
        }
        
        public bool Create(SlideCreateRequest request) 
        {
            return _slideRepository.Create(request);
        }

        public PagedResult<Slide> GetSlides(SlidePagingManageGetRequest request)
        {
            return _slideRepository.GetSlides(request);
        }

        public bool Update(SlideUpdateRequest request)
        {
            return _slideRepository.Update(request);
        }
    }
}
