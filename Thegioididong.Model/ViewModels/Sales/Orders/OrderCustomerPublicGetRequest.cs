using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.Common;

namespace Thegioididong.Model.ViewModels.Sales.Orders
{
    public class OrderCustomerPublicGetRequest : PagingRequestBase
    {
        [JsonIgnore]
        public int? CustomerId { get; set; }

        public int? Status { get; set; }

        //public DateOnly StartDate { get; set; }

        //public DateOnly EndDate { get; set;}
    }
}
