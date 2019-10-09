using SEDC.Lamazon.WebModels_.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.WebModels_.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public StatusTypeViewModel Status { get; set; }
        public double Price => Products.Sum(p => p.Price);
        public UserViewModel User { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public InvoiceViewModel Invoice { get; set; }
    }
}
