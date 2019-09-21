using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamazon.Services.Interfaces;
using Lamazon.WebModels.Enums;
using Lamazon.WebModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public OrdersController(IOrderService orderService,
                                IUserService userService,
                                IProductService productService)
        {
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
        }
        

        [Authorize(Roles = "customer")]
        public IActionResult Order()
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            return View(_orderService.GetCurrentOrder(user.Id));
        }

        [Authorize(Roles = "customer")]
        public IActionResult OrderDetails(int id)
        {
            return View(_orderService.GetOrderById(id));
        }

        [Authorize(Roles = "customer")]
        public IActionResult ListOfOrders()
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            List<OrderViewModel> orders = _orderService.GetUserOrders(user.Id).ToList();
            return View(orders);
        }
        
        [HttpPost]
        //[Authorize(Roles = "customer")]
        public IActionResult AddProduct(int id)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            OrderViewModel order = _orderService.GetCurrentOrder(user.Id);

            _orderService.AddProduct(order.Id, id);

            return View();
        }

        [Authorize(Roles = "customer")]
        public IActionResult ChangeStatus(int id, int statusId)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            List<OrderViewModel> orders = _orderService.GetUserOrders(user.Id).ToList();

            _orderService.ChangeStatus(id, user.Id, (StatusTypeViewModel)statusId);
            return RedirectToAction("index", "products");
        }


        [Authorize(Roles = "admin")]
        public IActionResult ListAllOrders()
        {
            List<OrderViewModel> allOrders = _orderService.GetAllOrders().ToList();
            return View(allOrders);
        }

        [Authorize(Roles = "admin")]
        public IActionResult ConfirmOrder(int id)
        {
            OrderViewModel order = _orderService.GetOrderById(id);
            _orderService.ChangeStatus(order.Id, order.User.Id, StatusTypeViewModel.Confirmed);
            return RedirectToAction("listallorders");
        }
    }
}