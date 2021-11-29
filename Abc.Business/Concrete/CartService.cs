using Abc.Business.Abstract;
using Abc.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abc.Business.Concrete
{
    public class CartService : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            if (cartLine != null)
            {
                cartLine.Quantity++; return;
            }
            cart.CartLines.Add(new CartLine
            {
                Product = product,
                Quantity = 1
            });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int ProductId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(i => i.Product.ProductId == ProductId));
        }
    }
}
