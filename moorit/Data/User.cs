using System.ComponentModel.DataAnnotations.Schema;

namespace Moorit.Data
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }

        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
