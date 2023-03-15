using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Catalog.ProductCategories
{
    public class ProductCategoryUpdateRequest
    {
        public int Id { get; set; }

        public int? ParentProductCategoryId { get; set; }

        public int? ProductCategoryGroupId { get; set; }

        public string Name { get; set; }

        public string? BadgeIcon { get; set; }

        public string? Image { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }
    }
}
