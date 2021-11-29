using Abc.Business.Abstract;
using Abc.DataAccess.Abstract;
using Abc.DataAccess.Concrete;
using Abc.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal productDal;
        public ProductManager(IProductDal product)
        {
            productDal = product;
        }
        public void Add(Product product)
        {
            productDal.Add(product);
        }

        public void Delete(Product product)
        {
            productDal.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            return productDal.GetList();
        }

        public Product GetById(int ProductId)
        {
            return productDal.Get(i=>i.ProductId == ProductId);
        }

        public List<Product> ProductGetByCategories(int id)
        {
            return productDal.GetList(i => i.CategoryId == id || id == 0);
        }
        public void Update(Product product)
        {
            productDal.Update(product);
        }
    }
}
