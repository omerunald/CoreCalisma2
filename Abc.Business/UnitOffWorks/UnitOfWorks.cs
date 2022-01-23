using Abc.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Business.UnitOffWorks
{
    public class UnitOfWorks
    {
        IProductService _productService;
        ICategoryService _categoryService;
        public UnitOfWorks(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
    }
}
