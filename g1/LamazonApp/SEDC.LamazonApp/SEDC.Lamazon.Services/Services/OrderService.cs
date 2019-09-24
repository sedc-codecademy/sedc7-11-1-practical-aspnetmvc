using AutoMapper;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.WebModels_.Enums;
using SEDC.Lamazon.WebModels_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Product> productRepository,
                            IRepository<Order> orderRepository,
                            IUserRepository userRepository,
                            IMapper mapper)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public int AddProduct(int orderId, int productId, string userId)
        {
            Product product = _productRepository.GetById(productId);
            Order order = _orderRepository.GetById(orderId);

            User user = _userRepository.GetById(userId);
            order.ProductOrders.Add(
                new ProductOrder()
                {
                    Product = product,
                    Order = order
                });

            order.User = user;

            return _orderRepository.Update(order);
        }

        public int ChangeStatus(int orderId, StatusTypeViewModel status)
        {
            throw new NotImplementedException();
        }

        public int CreateOrder(OrderViewModel order, string userId)
        {
            User user = _userRepository.GetById(userId);

            Order mappedOrder = _mapper.Map<Order>(order);

            mappedOrder.User = user;
            return _orderRepository.Insert(mappedOrder);
        }

        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            return _mapper.Map<List<OrderViewModel>>(_orderRepository.GetAll());
        }

        public OrderViewModel GetCurrentOrder(string userId)
        {
            Order order = _orderRepository.GetAll()
                                          .Where(x => x.UserId == userId)
                                          .LastOrDefault();
            IEnumerable<Product> products = order.ProductOrders
                                                 .Select(x => 
                                                 _productRepository.GetById(x.ProductId));
            OrderViewModel orderModel = _mapper.Map<OrderViewModel>(order);

            orderModel.Products = _mapper.Map<List<ProductViewModel>>(products);

            return orderModel;
        }

        public OrderViewModel GetOrderById(int id)
        {
            return _mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }

        public OrderViewModel GetOrderById(int orderId, string userId)
        {
            User user = _userRepository.GetById(userId);
            return _mapper.Map<OrderViewModel>(_orderRepository.GetById(orderId));
        }

        public int RemoveProduct(int orderId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
