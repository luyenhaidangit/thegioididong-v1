using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class ProductManageCreateRequest
    {
        public int ProductCategoryId { get; set; }

        public int BrandId { get; set; }

        public int UnitId { get; set; }

        public string Name { get; set; }

        public string SKU { get; set; }

        public int BadgeProductId { get; set; }

        public string? ShortDescription { get; set; }

        public string? FullDescription { get; set; }

        public string? Image { get; set; }

        public bool IsInterest { get; set; }

        public bool ShowOnHomePage { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }
    }
}
