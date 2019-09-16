using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enumerations;

namespace Domain.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string Address { get; set; }
        public PaymentType PaymentType { get; set; }

        //relations
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
