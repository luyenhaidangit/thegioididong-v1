using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public IEnumerable<T> Items { set; get; }
    }
}
