using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebModels.ViewModels;

namespace WebApplication.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public OrdersController(IOrderService orderService,
                                IProductService productService,
                                IUserService userService)
        {
            _orderService = orderService;
            _productService = productService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Order()
        {
            var loggedUser = User.Identity.Name;
            UserViewModel user = _userService.GetCurrentUser(loggedUser);
            OrderViewModel currentOrder = _orderService.GetCurrentOrder(user.Id);
            return View(currentOrder);
        }

        [HttpGet]
        public IActionResult OrderDetails(int id)
        {
            var loggedUser = User.Identity.Name;
            UserViewModel user = _userService.GetCurrentUser(loggedUser);
            var order = _orderService.GetById(id, user.Id);
            return View(order);
        }

        [HttpPost]
        public IActionResult AddProduct(int id)
        {
            var loggedUser = User.Identity.Name;
            UserViewModel user = _userService.GetCurrentUser(loggedUser);
            OrderViewModel order = _orderService.GetCurrentOrder(user.Id);

            try
            {
                _orderService.UpdateOrder(id, order.Id, user.Id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}