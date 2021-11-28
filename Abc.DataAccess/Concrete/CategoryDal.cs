using Abc.DataAccess.Abstract;
using Abc.DataAccess.EntityFramework;
using Abc.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.DataAccess.Concrete
{
    public class CategoryDal : EntityRepository<Category, NorthwindContext>, ICategoryDal
    {
    }
}
