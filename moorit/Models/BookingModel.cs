

namespace Moorit.Models
{
    public class BookingModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public float Price { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser? User { get; set; }

        public int MooringId { get; set; }

        public virtual MooringModel? Mooring { get; set; }
    }
}
