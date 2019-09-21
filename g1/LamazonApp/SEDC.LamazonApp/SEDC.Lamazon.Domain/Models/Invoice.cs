using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SEDC.Lamazon.Models.Domain
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Address { get; set; }
        public PaymentType PaymentType { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
