using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.CMS.Slides;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class ProductFeatureHome
    {
        public int? Id { get; set; }

        public string? Title { get; set; }

        public string? BackgroundColor { get; set; }

        public SlidePublicGetResult Slide { get; set; }

        public List<ProductItemCardDefault> Products { get; set; }
    }
}
