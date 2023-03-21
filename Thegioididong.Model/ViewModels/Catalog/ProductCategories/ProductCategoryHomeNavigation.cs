using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Thegioididong.Model.ViewModels.Catalog.ProductCategories
{
    public class ProductCategoryNavigation
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ProductCategoryGroupNavigation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductCategoryNavigation> ProductCategories { get; set; }

    }

    public class ProductCategoryHomeNavigation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BadgeIcon { get; set; }

        public List<ProductCategoryGroupNavigation> ProductCategoryGroups { get; set; }

        public List<ProductCategoryNavigation> ProductCategories { get; set; }
    }
}
