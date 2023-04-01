using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class ProductPaingPublicGetRequest : PagingRequestBase
    {
        public List<int> ProductCategoryId { get; set; }

        public List<int> BrandId { get; set; }

        public decimal StartPrice { get; set; }

        public decimal EndPrice { get; set; }

        public List<AttributeProductFilterGetResult> ProductAttributes { get; set; }

        public string? SortBy { get; set; }

        public string? OrderBy { get; set; }
    }
}
