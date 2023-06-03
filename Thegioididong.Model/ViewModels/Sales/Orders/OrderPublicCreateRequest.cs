using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Sales.Orders
{
    public class CustomerOrderPublicCreateRequest
    {
        public string Name { get; set; }

        public string Sex { get; set; }

        public string? NumberPhone { get; set; }

        public string Email { get; set; }
    }

    public class OrderDetailOrderPublicCreateRequest
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }

    public class OrderPublicCreateRequest
    {
        public CustomerOrderPublicCreateRequest Customer { get; set; }

        public int DeliveryMethod { get; set; }


        public int PaymentMethod { get; set; }

        public string Andress { get; set; }

        public string Note { get; set; }

        public int Status { get; set; }

        public int? CouponId { get; set; }

        public List<OrderDetailOrderPublicCreateRequest> OrderDetails { get; set; }
    }
}
