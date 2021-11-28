using Abc.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Abc.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
