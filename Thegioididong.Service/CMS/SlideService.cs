using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.CMS.Slides;

namespace Thegioididong.Service
{
    public partial interface ISlideService
    {
        bool Create(SlideCreateRequest request);
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
    }
}
