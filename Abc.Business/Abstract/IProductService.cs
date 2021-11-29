using Abc.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int ProductId);
        List<Product> GetAllProducts();
        List<Product> ProductGetByCategories(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
