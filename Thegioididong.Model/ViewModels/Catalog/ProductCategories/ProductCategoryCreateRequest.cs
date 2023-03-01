using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using NSwag.Annotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Thegioididong.Model.ViewModels.Catalog.ProductCategories
{
    public class ProductCategoryCreateRequest
    {

        public int? ParentProductCategoryId { get; set; }

        public int? ProductCategoryGroupId { get; set; }

        public string Name { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? BadgeIcon { get; set; }

        public IFormFile BadgeIconFile { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }

        public IFormFile ImageFile { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }
    }
}
