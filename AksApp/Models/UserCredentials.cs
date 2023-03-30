using System.ComponentModel.DataAnnotations;

namespace AksApp.Models
{
    public class UserCredentials
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        
        public string Password { get; set; }

        public bool KeepLoggedIn { get; set; }
    }
}
