using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.WebModels_.ViewModels;

namespace SEDC.Lazamazon.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService,
                               IUserService userService,
                               IProductService productService)
        {
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
        }


        public IActionResult Order()
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            var order = _orderService.GetCurrentOrder(user.Id);
            return View(order);
        }

        
        public IActionResult OrderDetails(int orderId)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            OrderViewModel order = _orderService.GetOrderById(orderId, user.Id);

            return View("order", order);
        }

        public int AddProduct(int productId)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            OrderViewModel order = _orderService.GetCurrentOrder(user.Id);

           return _orderService.AddProduct(order.Id, productId, user.Id);
        }

        public IActionResult ListOrders()
        {

        }

        public IActionResult ChangeStatus(int orderId, int statusId)
        {

        }

        public IActionResult ListAllOrders()
        {

        }

        public IActionResult ConfirmOrder(int orderId)
        {

        }




    }
}