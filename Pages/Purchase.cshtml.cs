using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookstore.Infrastructure;
using Bookstore.Models;

namespace Bookstore.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreRepository repository;

        // Constructor for PurchaseModel
        public PurchaseModel(IBookstoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        // Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        // Methods
        public void OnGet(string returnUrl) // retrieves the users cart
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long BookId, string returnUrl) // sends the users cart
        {
            BookModel book = repository.Books.FirstOrDefault(b => b.BookId == BookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long BookId, string returnUrl)
        {
            Cart.RemoveItem(Cart.LineItems.First(cl =>
                cl.Book.BookId == BookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

    }
}