using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class BadgeProductDailySuggest
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string BackgroundColor { get; set; }

    }

    public class ProductDailySuggest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public BadgeProductDailySuggest? BadgeProduct { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountedPrice { get; set; }

        public int DiscountPercent { get; set; }

        public double StarRating { get; set; }

        public int ReviewCount { get; set; }
    }

    public class ProductDailySuggestGetResult
    {
        public List<ProductDailySuggest> LatestProducts { get; set; }

        public List<ProductDailySuggest> PopularProducts { get; set; }

        public List<ProductDailySuggest> BestSellingProducts { get; set; }

        public List<ProductDailySuggest> TopRatedProducts { get; set; }
    }
}
