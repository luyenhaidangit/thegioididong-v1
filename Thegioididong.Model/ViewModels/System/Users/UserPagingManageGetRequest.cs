using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Model.ViewModels.System.Users
{
    public class UserPagingManageGetRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
