using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace F15Team26.Models
{

    public class Cart
    {
        [Key]
        public int RecordID { get; set; }
        public int CartID { get; set; }
        public int BooksID { get; set; }
        public int Count { get; set; }
        //public System.DateTime DateCreated { get; set; }
        public virtual Books Books { get; set; }
    }
}