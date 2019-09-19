using System;
using System.Collections.Generic;
using System.Text;
using WebModels.ViewModels;

namespace Services.Interfaces
{
    public interface IInvoiceService
    {
        IEnumerable<InvoiceViewModel> GetAll();
        InvoiceViewModel GetById(int id);
        InvoiceViewModel GetByOrderId(int id);
        int Insert(InvoiceViewModel model, int orderId);
    }
}
