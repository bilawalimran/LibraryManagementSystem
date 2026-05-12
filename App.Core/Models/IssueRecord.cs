using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Models
{
    public class IssueRecord 
    { 
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
