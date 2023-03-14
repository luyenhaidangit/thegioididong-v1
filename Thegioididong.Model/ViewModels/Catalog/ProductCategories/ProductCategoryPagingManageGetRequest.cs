using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Model.ViewModels.Catalog.ProductCategories
{
    public class ProductCategoryPagingManageGetRequest : PagingRequestBase
    {
        public string Name { get; set; }
    }
}
