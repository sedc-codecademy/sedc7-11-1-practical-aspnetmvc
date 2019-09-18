using System;
using System.Collections.Generic;
using System.Text;
using WebModels.Enumerations;

namespace WebModels.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public PaymentViewType PaymentType { get; set; }
        public OrderViewModel Order { get; set; }
    }
}
