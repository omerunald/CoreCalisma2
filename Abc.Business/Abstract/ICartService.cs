using Abc.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Product product);
        void RemoveFromCart(Cart cart, int ProductId);
        List<CartLine> List(Cart cart);
    }
}
