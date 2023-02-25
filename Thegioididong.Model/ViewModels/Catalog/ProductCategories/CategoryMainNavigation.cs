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
    public class ProductCategoryMainNavigation
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ProductCategoryGroupMainNavigation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductCategoryMainNavigation> ProductCategories { get; set; }

    }

    public class CategoryMainNavigation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BadgeIcon { get; set; }

        public List<ProductCategoryGroupMainNavigation> ProductCategoryGroups { get; set; }

        public List<ProductCategoryMainNavigation> ProductCategories { get; set; }
    }
}
