using Abc.Business.Abstract;
using Abc.Entity.Concrete;
using Abc.UI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.UI.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        IDistributedCache _distributedCache;
        public AdminController(IProductService productService, ICategoryService categoryService,IDistributedCache distributedCache)
        {
            _productService = productService;
            _categoryService = categoryService;
            _distributedCache = distributedCache;
        }
        public IActionResult Index()
        {
            ProductListViewModel model = new ProductListViewModel()
            {
                Product = _productService.GetAllProducts()
            };
            return View(model);
        }

        public IActionResult Add()
        {
           
            var model = new ProductAddViewModel()
            {

                Product = new Product(),
                Categories = _categoryService.GetAllCategories()

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);

            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int ProductId)
        {
            var model = new ProductUpdateViewModel()
            {
                Product = _productService.GetById(ProductId),
                Categories = _categoryService.GetAllCategories()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(Product product)
        {
            if (ModelState.IsValid)
            {

                _productService.GetById(product.ProductId);
                _productService.Delete(product);
                TempData.Add("message", "Product removed succesfly");
            }
            return RedirectToAction("Index");
        }
    }
}
