using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.Catalog.Brands;

namespace Thegioididong.Model.ViewModels.Catalog.ProductCategories
{
    public class RangePriceProductCategoryGetResult
    {
        public string Name { get; set; }

        public decimal StartPrice { get; set; }

        public decimal EndPrice { get; set; }
    }

    public class RangePriceProductCategoryFilterGetResult
    {
        public List<RangePriceProductCategoryGetResult> RangePrices { get; set; }

        public decimal StartPrice { get; set; }

        public decimal EndPrice { get; set; }   
    }

    public class AttributeProductFilterGetResult
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<AttributeProductValueFilterGetResult> AttributeValueProducts { get; set; }
    }

    public class AttributeProductValueFilterGetResult
    {
        public string Id { get; set; }

        public string Value { get; set; }
    }

    public class ProductCategoryBoxFilterGetResult
    {
        public List<BrandPublicGetResult> BrandsFilter { get; set; }

        public RangePriceProductCategoryFilterGetResult RangePricesFilter { get; set; }

        public List<AttributeProductFilterGetResult> ProductAttributesFilter { get; set; }

    }
}
