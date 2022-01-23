using Abc.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Business.UnitOffWorks
{
    interface IUnitOfWorks
    {
        IProductService productService { get; }
        ICategoryService categoryService { get; }
    }
}
