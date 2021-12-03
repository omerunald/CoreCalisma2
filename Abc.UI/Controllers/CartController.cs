using Abc.Business.Abstract;
using Abc.Business.Concrete;
using Abc.Entity.Concrete;
using Abc.UI.Model;
using Abc.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.UI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;

        }
        public IActionResult AddToCart(int ProductId)
        {
            var productToBeAdded = _productService.GetById(ProductId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Ürün :{0} eklendi", productToBeAdded.ProductName));
            return RedirectToAction("Index", "Product");
        }
        public IActionResult CartList()
        {
            var cart = _cartSessionService.GetCart();
            CartSummaryViewModel cartSummaryViewModel = new CartSummaryViewModel()
            {
                Cart = cart
            };
            return View(cartSummaryViewModel);

        }
        public IActionResult Remove(int ProductId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, ProductId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Ürün sepetten silindi!" ));
            return RedirectToAction("CartList");
        }
        public IActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel()
            {
                ShippingDetails = new Entity.Concrete.ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }
        [HttpPost]
        public  IActionResult Complete(ShippingDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View(model.ShippingDetails.FirstName);
        }
    }
}
