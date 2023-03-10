using Moorit.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moorit.Data
{
    [Table("Bookings")]
    public class Booking
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public float Price { get; set; }

        public string ApplicationUserModelId { get; set; }

        public virtual ApplicationUserModel? User { get; set; }

        public int MooringId { get; set; }

        public virtual Mooring? Mooring { get; set; }

    }
}