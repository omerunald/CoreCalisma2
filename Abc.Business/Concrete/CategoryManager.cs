using Abc.Business.Abstract;
using Abc.DataAccess.Abstract;
using Abc.DataAccess.Concrete;
using Abc.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal category)
        {
            categoryDal = category;
        }
        public void Add(Category category)
        {
            categoryDal.Add(category);
        }
        public void Delete(Category category)
        {
            categoryDal.Delete(category);
        }

        public List<Category> GetAllCategories()
        {
            return categoryDal.GetList();
        }

        public void Update(Category category)
        {
            categoryDal.Update(category);
        }
    }
}
