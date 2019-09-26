using SEDC.Lamazon.WebModels_.Enums;
using SEDC.Lamazon.WebModels_.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id);
        OrderViewModel GetOrderById(int id, string userId);
        int CreateOrder(OrderViewModel order, string userId);
        int ChangeStatus(int orderId, string userId, StatusTypeViewModel status);
        int AddProduct(int orderId, int productId, string userId);
        int RemoveProduct(int orderId, int productId);
        OrderViewModel GetCurrentOrder(string userId);
    }
}
