using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.CMS.Slides
{
    public class SlideItemUpdateRequest
    {
        public int? Id { get; set; }

        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? URL { get; set; }
    }

    public class SlideUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Page { get; set; }

        public string Position { get; set; }

        public bool Published { get; set; }

        public List<SlideItemUpdateRequest?>? SlideItems { get; set; }
    }
}
