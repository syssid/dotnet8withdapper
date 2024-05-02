using System.ComponentModel.DataAnnotations;

namespace golum.Models
{
    public class Login
    {
        public string? UserID { get; set; }
        public string? Password { get; set; }
        [MaxLength(10)]
        public string? Phone { get; set; }
    }
} 
