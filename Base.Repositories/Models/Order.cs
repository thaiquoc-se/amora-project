using System;
using System.Collections.Generic;

namespace Base.Repositories.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? UserId { get; set; }
        public double? TotalPrice { get; set; }
        public string? Note { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
