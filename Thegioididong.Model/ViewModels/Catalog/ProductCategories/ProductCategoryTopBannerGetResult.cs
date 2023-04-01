using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.CMS.Banners;
using Thegioididong.Model.ViewModels.CMS.Slides;

namespace Thegioididong.Model.ViewModels.Catalog.ProductCategories
{
    public class ProductCategoryTopBannerGetResult
    {
        public SlidePublicGetResult Slide { get; set; }

        public BannerPublicGetResult BannerFirst { get; set; }

        public BannerPublicGetResult BannerSecond { get; set; }
    }
}
