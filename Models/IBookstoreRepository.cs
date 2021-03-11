using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public interface IBookstoreRepository //interface is used for inheritance unlike a class - defines structure
    {
        IQueryable<BookModel> Books { get; }
    }
}