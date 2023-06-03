using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int DeliveryMethod { get; set; }

        public int PaymentMethod { get; set; }

        public string Andress { get; set; }

        public string? Note { get; set; }

        public int Status { get; set; }

        public int? CouponId { get; set; }
    }
}
