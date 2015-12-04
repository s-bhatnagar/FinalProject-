using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace F15Team26.Models
{
    public class Books
    {

        public int BooksID { get; set; }
        public String UniqueNumber { get; set; }

        [Required]
        [Display(Name= "Author First Name")]
        public String AuthorFirst { get; set; }

        [Required]
        [Display(Name = "Author Last Name")]
        public String AuthorLast { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage= "Please enter a valid price")]

        public Decimal Price { get; set; }

        [Required]
        //[validation]
        //write try catch validation
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }

        [Required]
        [Display(Name = "Price Last Paid")]
        [Range(0.0, Double.MaxValue, ErrorMessage= "Please enter a valid price")]
        public Decimal PriceLastPaid { get; set; }

        [Required]
        public int Inventory { get; set; }

        [Required]
        [Display(Name = "Reorder Point")]
        public int ReorderPoint { get; set; }

        [Required]
        public String Reviews { get; set; }

        [Required]
        public virtual List<Employees> Employee { get; set; }

        [Required]
        public Decimal Ratings { get; set; }

        [Required]
        public String Genre { get; set; }
    }
}
