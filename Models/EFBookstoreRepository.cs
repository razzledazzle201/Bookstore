using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFBookstoreRepository : IBookstoreRepository // here is where we implement (use the template) 
    {
        private BookstoreDbContext _context; // private BookstoreDbContext type called context _ means private

        public EFBookstoreRepository(BookstoreDbContext context) // Constructor
        {
            _context = context;
        }
        public IQueryable<BookModel> Books => _context.BookModels;
    }
}