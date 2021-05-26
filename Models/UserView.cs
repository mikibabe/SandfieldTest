
using System;

namespace SandfieldTest.Models
{
    public class UserView
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }
        public string AccessLevel { get; set; }
        public string PartName { get; set; }
        public DateTime? DOB { get; set; }

    }
}