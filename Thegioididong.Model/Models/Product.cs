using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string BadgeText { get; set; }

        public string BadgeIcon { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string Image { get; set; }

        public int BrandId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
