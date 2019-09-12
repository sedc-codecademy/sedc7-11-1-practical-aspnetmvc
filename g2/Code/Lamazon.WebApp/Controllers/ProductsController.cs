using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamazon.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}