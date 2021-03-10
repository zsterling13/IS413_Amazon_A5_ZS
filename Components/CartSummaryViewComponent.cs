using IS413_Amazon_A5_ZS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Components
{
    //Have the CartSummaryViewComponent inherit from the ViewComponent class
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        //Constructor that sets the private cart variable to the passed-in value
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
