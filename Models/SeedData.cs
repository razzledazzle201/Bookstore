//Data
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BookstoreDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BookstoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate(); // Migrate pending migrations
            }

            if (!context.BookModels.Any()) // if there are no entries context has no data 
            {
                context.BookModels.AddRange(

                    new BookModel
                    {
                        BookTitle = "Les Miserables",
                        BookAuthorFirstName = "Victor",
                        BookAuthorMiddleName = "",
                        BookAuthorLastName = "Hugo",
                        BookPublisher = "Signet",
                        BookISBN = "978-0451419439",
                        BookClassification = "Fiction",
                        BookCategory = "Classic",
                        BookPrice = 9.95,
                    },

                    new BookModel
                    {
                        BookTitle = "Team of Rivals",
                        BookAuthorFirstName = "Doris",
                        BookAuthorMiddleName = "Kearns",
                        BookAuthorLastName = "Goodwin",
                        BookPublisher = "Simon & Schuster",
                        BookISBN = "978-0743270755",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Biography",
                        BookPrice = 14.58,
                    },

                    new BookModel
                    {
                        BookTitle = "The Snowball",
                        BookAuthorFirstName = "Alice",
                        BookAuthorMiddleName = "",
                        BookAuthorLastName = "Schroeder",
                        BookPublisher = "Bantam",
                        BookISBN = "978-0553384611",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Biography",
                        BookPrice = 21.54,
                    },

                    new BookModel
                    {
                        BookTitle = "American Ulysses",
                        BookAuthorFirstName = "Alice",
                        BookAuthorMiddleName = "C.",
                        BookAuthorLastName = "White",
                        BookPublisher = "Random House",
                        BookISBN = "978-0812981254",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Biography",
                        BookPrice = 11.61,
                    },

                    new BookModel
                    {
                        BookTitle = "Unbroken",
                        BookAuthorFirstName = "Laura",
                        BookAuthorMiddleName = "",
                        BookAuthorLastName = "Hillenbrand",
                        BookPublisher = "Random House",
                        BookISBN = "978-0812974492",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Historical",
                        BookPrice = 13.33,
                    },

                    new BookModel
                    {
                        BookTitle = "The Great Train Robbery",
                        BookAuthorFirstName = "Michael",
                        BookAuthorMiddleName = "",
                        BookAuthorLastName = "Crichton",
                        BookPublisher = "Vintage",
                        BookISBN = "978-0804171281",
                        BookClassification = "Fiction",
                        BookCategory = "Historical Fiction",
                        BookPrice = 15.95,
                    },

                    new BookModel
                    {
                        BookTitle = "Deep  Work",
                        BookAuthorFirstName = "Cal",
                        BookAuthorMiddleName = "",
                        BookAuthorLastName = "Newport",
                        BookPublisher = "Grand Central Publishing",
                        BookISBN = "978-1455586691",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Self-Help",
                        BookPrice = 14.99,
                    },

                    new BookModel
                    {
                        BookTitle = "It's Your Ship",
                        BookAuthorFirstName = "Michael",
                        BookAuthorMiddleName = "",
                        BookAuthorLastName = "Abrashoff",
                        BookPublisher = "Grand Central Publishing",
                        BookISBN = "978-1455523023",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Self-Help",
                        BookPrice = 21.66,
                    },

                    new BookModel
                    {
                        BookTitle = "The Virgin Way",
                        BookAuthorFirstName = "Richard",
                        BookAuthorMiddleName = "",
                        BookAuthorLastName = "Branson",
                        BookPublisher = "Portfolio",
                        BookISBN = "978-1591847984",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Business",
                        BookPrice = 29.16,
                    },

                    new BookModel
                    {
                        BookTitle = "Sycamore Row",
                        BookAuthorFirstName = "John",
                        BookAuthorMiddleName = "",
                        BookAuthorLastName = "Grisham",
                        BookPublisher = "Bantam",
                        BookISBN = "978-0553393613",
                        BookClassification = "Fiction",
                        BookCategory = "Thrillers",
                        BookPrice = 15.03,
                    }
                );;

                context.SaveChanges(); // save this to the DB
            }
        }
    }
}
