using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.Models;

namespace Thegioididong.Model.ViewModels.CMS.Slides
{
    public class SlideItemCreateRequest
    {
        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? URL { get; set; }
    }

    public class SlideCreateRequest
    {
        public string Name { get; set; }

        public string Page { get; set; }

        public string Position { get; set; }

        public bool Published { get; set; }

        public List<SlideItemCreateRequest?>? SlideItems { get; set; }
    }
}
