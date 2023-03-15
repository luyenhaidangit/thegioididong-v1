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
        public string? Name { get; set; }

        public bool? Published { get; set; }

        public bool? ShowOnHomePage { get; set; }

        public int? ProductCategoryId { get; set; }

        public int? BrandId { get; set; }

        public string? SortBy { get; set; }

        public string? OrderBy { get; set; }
    }
}
