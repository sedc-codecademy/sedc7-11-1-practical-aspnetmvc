using System.Collections.Generic;
using System.Linq;
using WebModels.Enumerations;

namespace WebModels.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string DateOfOrder { get; set; }
        public OrderStatusViewType Status { get; set; }
        public UserViewModel User { get; set; }
        public InvoiceViewModel Invoice { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }

        public double Price => Products.Sum(x => 0);

        //public double Price1
        //{
        //    get
        //    {
        //        return Products.Sum(x => 0);
        //    }
        //}
    }
}