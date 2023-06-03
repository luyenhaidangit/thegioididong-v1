using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.Models
{
    public class News
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string NewsCategoryId { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }

        public int ViewCount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
