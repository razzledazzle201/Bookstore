using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Bookstore.Infrastructure;
namespace Bookstore.Models
{
    public class SessionCart : Cart
    { // The SessionCart class subclasses the Cart class and overrides the AddItem, RemoveLine, and 
      // Clear methods so they call the base implementations and then store the updated state in the 
      // session using the extension methods on the ISession interface.
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(BookModel book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("cart", this);
        }
        public override void RemoveItem(BookModel book)
        {
            base.RemoveItem(book);
            Session.SetJson("cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("cart");
        }
    }
}