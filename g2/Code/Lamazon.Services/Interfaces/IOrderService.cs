using Lamazon.WebModels.Enums;
using Lamazon.WebModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lamazon.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id);
        OrderViewModel GetCurrentOrder();
        void CreateOrder(OrderViewModel order);
        void ChangeStatus(int orderId, StatusTypeViewModel status);
        void AddProduct(int orderId, int productId);
        void RemoveProduct(int orderId, int productId);
    }
}
