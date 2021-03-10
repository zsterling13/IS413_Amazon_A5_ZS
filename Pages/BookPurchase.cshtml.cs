using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IS413_Amazon_A5_ZS.Infrastructure;
using IS413_Amazon_A5_ZS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IS413_Amazon_A5_ZS.Pages
{
    public class BookPurchaseModel : PageModel
    {
        private IBookRepository _repository;

        //Constructor that sets the private repository variable
        public BookPurchaseModel (IBookRepository repo, Cart cartService)
        {
            _repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        //Methods

        //Set the returned URL to what is passed in, and if the passed in parameter is null then set the returned URL as a single /
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = _repository.Books.FirstOrDefault(predicate => predicate.BookId == bookId);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookId == bookID).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
