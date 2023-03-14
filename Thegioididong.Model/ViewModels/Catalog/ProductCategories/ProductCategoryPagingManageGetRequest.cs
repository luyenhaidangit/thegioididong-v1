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
        public int? ParentProductCategoryId { get; set; }

        public int? ProductCategoryGroupId { get; set; }

        public string? Name { get; set; }

        public string? SortBy { get; set; }

        public string? OrderBy { get; set; }
    }
}
