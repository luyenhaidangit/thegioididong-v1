using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.CMS.Banners
{
    public class BannerManageUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Image { get; set; }

        public string? URL { get; set; }

        public string Page { get; set; }

        public string Position { get; set; }

        public bool Published { get; set; }
    }
}
