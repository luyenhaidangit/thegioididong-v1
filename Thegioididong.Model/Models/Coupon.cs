using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.Models
{
    public class Coupon
    {
        public int Id { get; set; }

        public string CouponCode { get; set; }

        public int DiscountType { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal MaximumDiscountValue { get; set; }

        public decimal MinimumPurchaseAmount { get; set; }

        public int RemainingUsageCount { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Description { get; set; }
    }
}
