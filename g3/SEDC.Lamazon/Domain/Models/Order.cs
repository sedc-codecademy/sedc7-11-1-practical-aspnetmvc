using Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateOfOrder { get; set; }
        public OrderStatusType Status { get; set; }

        public double Price => ProductOrders.Sum(x => x.Order.Price);

        //relations
        public string UserId{ get; set; }
        public User User{ get; set; }

        public Invoice Invoice { get; set; }

        public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    }
}
