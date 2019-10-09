using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.WebModels_.Enums;
using SEDC.Lamazon.WebModels_.ViewModels;

namespace SEDC.Lazamazon.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public InvoiceController(IInvoiceService invoiceService, IUserService userService, IOrderService orderService)
        {
            _invoiceService = invoiceService;
            _userService = userService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            InvoiceViewModel model = new InvoiceViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(string address, int paymentType, int orderId)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);

                InvoiceViewModel model = new InvoiceViewModel();
                model.Address = address;
                model.PaymentType = (PaymentTypeViewModel)paymentType;

                OrderViewModel order = _orderService.GetOrderById(orderId);

                if(order != null)
                {
                    model.Order = order;
                    _invoiceService.Insert(model, user.Id, orderId);
                }
            }
            return RedirectToAction("invoice", new { orderId });

        }

        public IActionResult Invoice(int orderId)
        {
            UserViewModel user = _userService.GetCurrentUser(User.Identity.Name);

            InvoiceViewModel model = _invoiceService.GetByOrderId(orderId, user.Id);

            return View(model);
        }
    }
}