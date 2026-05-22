using System;

namespace App.Core.Models
{
    public class Member
    {
        public Member()
        {
            Id = "M-" + Guid.NewGuid().ToString("N").Substring(0, 9);
        }

        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
