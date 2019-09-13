using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Enums;
using Lamazon.Domain.Models;
using Lamazon.Services.Interfaces;
using Lamazon.WebModels.Enums;
using Lamazon.WebModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lamazon.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepo;

        public OrderService(IRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            return _orderRepo.GetAll()
                .Select(o =>
                    new OrderViewModel
                    {
                        Id = o.Id,
                        Status = (StatusTypeViewModel)o.Status,
                        User = new UserViewModel
                        {
                            Id = o.User.Id,
                            Username = o.User.Username,
                            FullName = $"{o.User.Firstname} {o.User.Lastname}",
                            Address = o.User.Address
                        },
                        Products = o.OrdersProducts.Select(op => new ProductViewModel
                        {
                            Id = op.Product.Id,
                            Name = op.Product.Name,
                            Description = op.Product.Description,
                            Category = (CategoryTypeViewModel)op.Product.Category,
                            Price = op.Product.Price
                        }).ToList()
                    }
            );
        }

        public OrderViewModel GetOrderById(int id)
        {
            Order order = _orderRepo.GetById(id);

            return new OrderViewModel
            {
                Id = order.Id,
                Status = (StatusTypeViewModel)order.Status,
                User = new UserViewModel
                {
                    Id = order.User.Id,
                    Username = order.User.Username,
                    FullName = $"{order.User.Firstname} {order.User.Lastname}",
                    Address = order.User.Address
                },
                Products = order.OrdersProducts.Select(op => new ProductViewModel
                {
                    Id = op.Product.Id,
                    Name = op.Product.Name,
                    Description = op.Product.Description,
                    Category = (CategoryTypeViewModel)op.Product.Category,
                    Price = op.Product.Price
                }).ToList()
            };
        }

        public void CreateOrder(OrderViewModel order)
        {
            Order orderDomain = new Order
            {
                Status = StatusType.Init,
                Paid = false,
                UserId = order.UserId,
            };

            _orderRepo.Insert(orderDomain);
        }

        public OrderViewModel GetCurrentOrder()
        {
            Order order = _orderRepo.GetAll().LastOrDefault();

            return new OrderViewModel
            {
                Id = order.Id,
                Status = (StatusTypeViewModel)order.Status,
                User = new UserViewModel
                {
                    Id = order.User.Id,
                    Username = order.User.Username,
                    FullName = $"{order.User.Firstname} {order.User.Lastname}",
                    Address = order.User.Address
                },
                Products = order.OrdersProducts.Select(op => new ProductViewModel
                {
                    Id = op.Product.Id,
                    Name = op.Product.Name,
                    Description = op.Product.Description,
                    Category = (CategoryTypeViewModel)op.Product.Category,
                    Price = op.Product.Price
                }).ToList()
            };
        }

        public void ChangeStatus(int orderId, StatusTypeViewModel status)
        {
            _orderRepo.Update(
                new Order
                {
                    Id = orderId,
                    Status = (StatusType)status
                }
            );
        }

        public void AddProduct(int orderId, int productId)
        {
            //Order order = _orderRepo.GetById(orderId);
            //order.OrdersProducts.
            throw new NotImplementedException();
        }

        public void RemoveProduct(int orderId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
