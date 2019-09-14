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
        int CreateOrder(OrderViewModel order);
        int ChangeStatus(int orderId, StatusTypeViewModel status);
        int AddProduct(int orderId, int productId);
        int RemoveProduct(int orderId, int productId);
    }
}
