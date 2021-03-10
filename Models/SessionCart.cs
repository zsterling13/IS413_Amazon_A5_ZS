using IS413_Amazon_A5_ZS.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Models
{
    //Class that inherits from the Cart class and is meant to store information for the user's current session
    public class SessionCart : Cart
    {
        //Method that helps gather or get information for the current session of the cart
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }

        //Method that adds an item to the cart's current session
        public override void AddItem(Book book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("Cart", this);
        }

        //Method that removes an item from the cart's current session
        public override void RemoveLine(Book book)
        {
            base.RemoveLine(book);
            Session.SetJson("Cart", this);
        }

        //Method that completely clears the cart's current session of all items
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}