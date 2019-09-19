using System;
using System.Collections.Generic;
using System.Text;
using WebModels.ViewModels;

namespace Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAll();
        int RemoveProduct(int id);
    }
}
