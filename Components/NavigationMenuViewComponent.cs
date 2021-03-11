using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Components;
using Bookstore.Models;

namespace Bookstore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookstoreRepository repository;

        public NavigationMenuViewComponent(IBookstoreRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke() // data type is a view 
        {
            ViewBag.Selected = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.BookCategory)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}