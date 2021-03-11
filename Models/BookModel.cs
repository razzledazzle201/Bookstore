using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class BookModel
    {

        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string BookAuthorFirstName { get; set; } // AuthorFirstName
        [Required]
        public string BookAuthorMiddleName { get; set; } // AuthorMiddleInitial 
        [Required]
        public string BookAuthorLastName { get; set; } // AuthorLastName 
        [Required]
        public string BookPublisher { get; set; }
        [Required]
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$", ErrorMessage = "ISBN format is invalid.")] // Get regex for ###-##########
        public string BookISBN { get; set; }
        [Required]
        public string BookCategory { get; set; } // atomic
        [Required]
        public string BookClassification { get; set; } //atomic
        [Required]
        public double BookPrice { get; set; }

        [Required]
        public int BookPages { get; set; }

    }
}