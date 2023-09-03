using Goodreads.Base;
using System.Text.Json.Serialization;

namespace Goodreads.Models
{
    public class UserPrivateDetails : BaseEntity
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public string? PreferredBook { get; set; }
        public string? ColorPreference { get; set; }

        public string? Language { get; set; }
        public bool ReceiveNotifications { get; set; }

        
    }
}
