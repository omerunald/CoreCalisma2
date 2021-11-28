using Abc.Business.Abstract;
using Abc.Entity.Concrete;
using Abc.UI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.UI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        ICategoryService categoryService;
        public CategoryListViewComponent(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel()
            {
                Categories = categoryService.GetAllCategories(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])
            };
            return View(model);
        }
    }
}
