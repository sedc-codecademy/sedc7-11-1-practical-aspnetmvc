using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;

namespace SEDC.Lazamazon.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = "user")]
        public IActionResult Products()
        {
            var products = _productService.GetAllProducts().ToList();
            return View(products);
        }
    }
}