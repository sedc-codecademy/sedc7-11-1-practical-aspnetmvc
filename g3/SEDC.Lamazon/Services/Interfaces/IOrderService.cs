using System.Collections;
using System.Collections.Generic;
using WebModels.Enumerations;
using WebModels.ViewModels;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetAll();
        IEnumerable<OrderViewModel> GetAll(string userId);
        OrderViewModel GetById(int orderId);
        OrderViewModel GetById(int orderId, string userId);
        OrderViewModel GetCurrentOrder(string userId);
        int ChangeStatus(int orderId, string userId, OrderStatusViewType status);
        int Insert(OrderViewModel model, string userId);
        int UpdateOrder(int productId, int orderId, string userId);

        // TODO: review should be in product service 
        int RemoveProduct(ProductViewModel model, string userId);
    }
}
