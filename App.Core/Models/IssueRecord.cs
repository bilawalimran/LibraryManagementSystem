using System;

namespace App.Core.Models
{
    public class IssueRecord
    {
        public IssueRecord()
        {
            Id = "I-" + Guid.NewGuid().ToString("N").Substring(0, 9);
        }

        public string Id { get; set; }
        public string BookId { get; set; } = string.Empty;
        public string MemberId { get; set; } = string.Empty;
        public string BookName { get; set; } = string.Empty;
        public string MemberName { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; } = DateTime.Today;
        public DateTime? ReturnDate { get; set; }
    }
}
