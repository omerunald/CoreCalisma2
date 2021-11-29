using Abc.UI.Model;
using Abc.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.UI.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        ICartSessionService _cartSessionService;
        public CartSummaryViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }
        public IViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel()
            {
                Cart = _cartSessionService.GetCart()
            };
            return View(model);
        }
    }
}
