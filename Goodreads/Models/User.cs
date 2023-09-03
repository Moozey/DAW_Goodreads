using Goodreads.Base;
using Goodreads.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Goodreads.Models
{
    public class User: BaseEntity
    {
        
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Ati introdus un email gresit!")]
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public UserPrivateDetails? UserPrivateDetails { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public Role Role { get; set; }



    }
}
