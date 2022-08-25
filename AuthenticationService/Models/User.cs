using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       // public string Role { get; set; }
        [NotMapped]
        public string Token { get; set; }

        [NotMapped]
        public DateTime ExpirationDate { get; set; }
    }
}
