using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.Models
{
    public class ProductCategoryGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductCategoryId { get; set; }

        public int ProductCategoryGroupId { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }

        public string Image { get; set; }
       
    }
}
