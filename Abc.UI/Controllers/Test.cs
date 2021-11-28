using Abc.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.UI.Pages.Controllers
{
    public class Test : Controller
    {
        IProductService productService;
        public Test(IProductService product)
        {
            productService = product;
        }
        public IActionResult Index()
        {
            return View(productService.GetAllProducts());
        }
    }
}
