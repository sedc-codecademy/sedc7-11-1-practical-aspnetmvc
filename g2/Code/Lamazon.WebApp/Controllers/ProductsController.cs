using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamazon.Domain.Models;
using Lamazon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var test = _productService.GetAllProducts();
            return View(test);
        }
    }
}