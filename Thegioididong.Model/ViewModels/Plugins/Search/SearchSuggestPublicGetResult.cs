using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Plugins.Search
{
    public class ProductSearchSuggestPublicGetResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int DiscountPercentage { get; set; }
    }

    public class ProductCategorySearchSuggestPublicGetResult
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class NewsSearchSuggestPublicGetResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }


    public class SearchSuggestPublicGetResult
    {
        public IEnumerable<ProductSearchSuggestPublicGetResult> Products { get; set; }

        public IEnumerable<ProductCategorySearchSuggestPublicGetResult> ProductCategories { get; set; }

        public IEnumerable<NewsSearchSuggestPublicGetResult> News { get; set; }
    }
}
