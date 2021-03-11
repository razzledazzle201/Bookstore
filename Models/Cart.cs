using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Cart
    {
        public List<LineItem> LineItems { get; set; } = new List<LineItem>(); // LineItems is a list of LineItem

        // add an item
        public virtual void AddItem(BookModel book, int quantity) // method adds new line item of a book to the list of LineItems and group them together
        {                                                         // virtual keyword can override the cart class members
            LineItem line = LineItems.Where(b => b.Book.BookId == book.BookId).FirstOrDefault();

            if (line == null)
            {
                LineItems.Add(new LineItem
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        // remove an item
        public virtual void RemoveItem(BookModel book) =>
            LineItems.RemoveAll(x => x.Book.BookId == book.BookId);

        // remove all line items
        public virtual void Clear() => LineItems.Clear();

        // Calulate total
        public decimal ComputeTotalSum() => (decimal)LineItems.Sum(e => e.Book.BookPrice * e.Quantity);


        public class LineItem
        {
            public int LineItemId { get; set; }
            public BookModel Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}