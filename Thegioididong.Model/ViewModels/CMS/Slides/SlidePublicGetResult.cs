using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.CMS.Slides
{
    public class SlideItemPublicGetResult
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string URL { get; set; }
    }

    public class SlidePublicGetResult
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Page { get; set; }

        public string Position { get; set; }

        public IEnumerable<SlideItemPublicGetResult> SlideItems { get;set; }
    }
}
