﻿
namespace SandfieldTest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Group { get; set; }
        public string Role { get; set; }
        public string AccessLevel { get; set; }
        public int PartId { get; set; }

    }
}