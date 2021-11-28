using Abc.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        public IActionResult Index()
        {
            var result = productService.GetAllProducts();
            return View(result);
        }
    }
}
