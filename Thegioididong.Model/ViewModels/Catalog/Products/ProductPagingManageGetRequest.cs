using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class ProductPagingManageGetRequest : PagingRequestBase
    {
        public int CategoryId { get; set; }
    }
}
