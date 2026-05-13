using App.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Models
{
    public class Book 
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public BookCategory Category { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
