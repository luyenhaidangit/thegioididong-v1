using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public int ParentCategoryId { get; set; }

        public string Name { get; set; }

        public string BadgeIcon { get; set; }

        public string Image { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }

    }
}
