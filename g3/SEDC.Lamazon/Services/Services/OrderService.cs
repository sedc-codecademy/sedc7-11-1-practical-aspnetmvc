using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Domain.Enumerations;
using Domain.Models;
using Services.Interfaces;
using WebModels.Enumerations;
using WebModels.ViewModels;

namespace Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> orderRepository,
            IRepository<Product> productRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            var orders = _orderRepository.GetAll();
            var mappedOrders = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return mappedOrders;
        }

        public IEnumerable<OrderViewModel> GetAll(string userId)
        {
            var user = _userRepository.GetById(userId);
            // user validation
            var orders = _orderRepository.GetAll().Where(x => x.UserId == userId);
            return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
        }

        public OrderViewModel GetById(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            // order validation
            return _mapper.Map<OrderViewModel>(order);
        }

        public OrderViewModel GetById(int orderId, string userId)
        {
            var order = _orderRepository
                .GetAll()
                .FirstOrDefault(x => x.Id == orderId && x.UserId == userId);

            return _mapper.Map<OrderViewModel>(order);
        }

        public OrderViewModel GetCurrentOrder(string userId)
        {
            var order = _orderRepository
                .GetAll()
                .LastOrDefault(x => x.UserId == userId);

            var productIds = order.ProductOrders.Select(x => x.ProductId);

            var products = new List<Product>();
            foreach (var productId in productIds)
            {
                var product = _productRepository.GetById(productId);
                products.Add(product);
            }

            var orderViewModel = _mapper.Map<OrderViewModel>(order);
            orderViewModel.Products = _mapper
                .Map<IEnumerable<ProductViewModel>>(products);

            return orderViewModel;
        }

        public int ChangeStatus(int orderId, string userId, OrderStatusViewType status)
        {
            var order = _orderRepository.GetById(orderId);
            var user = _userRepository.GetById(userId);

            order.Status = _mapper.Map<OrderStatusType>(status);

            if (status == OrderStatusViewType.Processing)
            {
                _orderRepository.Insert(
                    new Order()
                    {
                        User = user,
                        Status = OrderStatusType.Init
                    });
            }
            return _orderRepository.Update(order);
        }

        public int Insert(OrderViewModel model, string userId)
        {
            var user = _userRepository.GetById(userId);

            Order order = _mapper.Map<Order>(model);
            order.User = user;

            var isAdded = _orderRepository.Insert(order);
            // validation ....

            return isAdded;
        }

        public int RemoveProduct(ProductViewModel model, string userId)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateOrder(int productId, int orderId, string userId)
        {
            var order = _orderRepository.GetById(orderId);
            var product = _productRepository.GetById(productId);

            // to be reviewed
            var user = _userRepository.GetById(userId);

            order.ProductOrders.Add(
                new ProductOrder()
                {
                    Product = product,
                    Order = order
                });

            // to be reviewed
            order.User = user;

            return _orderRepository.Update(order);
        }
    }
}
