using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.WebModels_.Enums;
using SEDC.Lamazon.WebModels_.ViewModels;
using SEDC.Lazamazon.Web.Models;

namespace SEDC.Lazamazon.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IInvoiceService _invoiceService;
        private readonly IToastNotification _toastNotification;

        public OrderController(IOrderService orderService,
                               IUserService userService,
                               IProductService productService,
                               IInvoiceService invoiceService,
                               IToastNotification toastNotification)
        {
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
            _invoiceService = invoiceService;
            _toastNotification = toastNotification;
        }

        [Authorize(Roles = "user")]
        public IActionResult Order(int? orderId = null)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            var order = _orderService.GetCurrentOrder(user.Id);
            if (order.Invoice == null)
            {
                order.Invoice = new InvoiceViewModel();
            }

            return View(order);
        }

        [Authorize(Roles = "user")]
        public IActionResult OrderDetails(int orderId)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            OrderViewModel order = _orderService.GetOrderById(orderId, user.Id);

            if (order.Id > 0)
            {
                return View("order", order);
            }
            else
            {
                // Add view to show an error message 
                //throw new Exception();
                return View("Error", new ErrorViewModel());
            }

        }

        [Authorize(Roles = "user")]
        public int AddProduct(int productId)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            OrderViewModel order = _orderService.GetCurrentOrder(user.Id);

            string productName;
            int result = _orderService.AddProduct(order.Id, productId, user.Id, out productName);

            if (result >= 0)
            {
                //string message1 = $"Product {productName} added to cart successfully!";
                string message = String.Format("Product {0} added to cart successfully!", productName);
                _toastNotification.AddSuccessToastMessage(message);
                return result;
            }
            else
            {
                string message = String.Format("Something went wrong while adding {0} into cart!", productName);
                _toastNotification.AddErrorToastMessage(message);
                return result;
            }
        }

        //public IActionResult GetMessageResult(int result)
        //{
        //    List<ProductViewModel> products = _productService.GetAllProducts().ToList();
        //    if(result >= 0)
        //    {
        //        _toastNotification.AddInfoToastMessage("Successfully added!");
        //    }
        //    else
        //    {
        //        _toastNotification.AddErrorToastMessage("Error");
        //    }
        //    return View("~/Views/Product/Products.cshtml", products);
        //}


        [Authorize(Roles = "user")]
        public IActionResult ListOrders()
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            List<OrderViewModel> userOrders = _orderService
                                               .GetAllOrders()
                                               .Where(x => x.User.Id == user.Id).ToList();

            return View(userOrders);
        }

        [Authorize(Roles = "user")]
        public IActionResult ChangeStatus(int orderId, int statusId)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            //List<OrderViewModel> orders = _orderService
            //                                .GetAllOrders()
            //                                .Where(x => x.User.Id == user.Id)
            //                                .ToList();
            _orderService.ChangeStatus(orderId, user.Id, (StatusTypeViewModel)statusId);

            return RedirectToAction("ListOrders", "order");

        }

        [Authorize(Roles = "admin")]
        public IActionResult ListAllOrders()
        {
            List<OrderViewModel> orders = _orderService.GetAllOrders().ToList();
            return View(orders);
        }

        [Authorize(Roles = "admin")]
        public IActionResult ConfirmOrder(int orderId)
        {
            OrderViewModel order = _orderService.GetOrderById(orderId);
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);
            _orderService.ChangeStatus(orderId, order.User.Id, StatusTypeViewModel.Confirmed);
            return RedirectToAction("listallorders");
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeclineOrder(int orderId)
        {
            OrderViewModel order = _orderService.GetOrderById(orderId);
            _orderService.ChangeStatus(orderId, order.User.Id, StatusTypeViewModel.Declined);
            return RedirectToAction("listallorders");
        }


        //Test and see how query parameters work! If you want to test, go to TestOrder.cshtml
        public IActionResult TestOrder(string name = "Martin", string lastname = "Panovski")
        {
            ViewBag.FirstName = name;
            ViewBag.LastName = lastname;

            return View();
        }
    }
}