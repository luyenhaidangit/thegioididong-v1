using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Thegioididong.Model.ViewModels.Page.Public.Common
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ProductCategoryGroupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductCategoryViewModel> ProductCategoriesJson { get; set; }

    }

    public class CategoryMainNavigation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BadgeIcon { get; set; }

        public List<ProductCategoryGroupViewModel> ProductCategoryGroupsJson { get; set; }

        public List<ProductCategoryViewModel> ProductCategoriesJson { get; set; }
    }
}
