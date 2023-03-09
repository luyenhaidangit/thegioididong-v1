using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Model.ViewModels.CMS.Banners
{
    public class BannerPagingPublicGetRequest : PagingRequestBase
    {
        public string Page { get; set; }

        public string Position { get; set; }
    }
}
