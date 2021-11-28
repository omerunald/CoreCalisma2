using Abc.DataAccess.EntityFramework;
using Abc.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
