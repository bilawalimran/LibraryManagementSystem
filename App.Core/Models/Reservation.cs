using App.Core.Enums;
using System;

namespace App.Core.Models
{
    public class Reservation
    {
        public Reservation()
        {
            Id = "R-" + Guid.NewGuid().ToString("N").Substring(0, 9);
        }

        public string Id { get; set; }
        public string BookId { get; set; } = string.Empty;
        public string MemberId { get; set; } = string.Empty;
        public string BookName { get; set; } = string.Empty;
        public string MemberName { get; set; } = string.Empty;
        public DateTime ReservationDate { get; set; } = DateTime.Today;
        public DateTime? ExpiryDate { get; set; }
        public ReservationStatus Status { get; set; } 
    }
}
