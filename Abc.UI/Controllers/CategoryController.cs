using Abc.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.UI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService category)
        {
            categoryService = category;
        }
        public IActionResult Index()
        {
            var result = categoryService.GetAllCategories();
            return View(result);
        }
    }
}
