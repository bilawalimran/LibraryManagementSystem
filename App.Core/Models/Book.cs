using App.Core.Enums;
using System;

namespace App.Core.Models
{
    public class Book
    {
        public Book()
        {
            Id = "B-" + Guid.NewGuid().ToString("N").Substring(0, 9);
        }

        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public BookCategory Category { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Today;
    }
}
