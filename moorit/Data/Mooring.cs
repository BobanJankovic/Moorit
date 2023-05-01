using System.ComponentModel.DataAnnotations.Schema;

namespace Moorit.Data
{

    public enum Status
    {
        Available,
        ExpiresSoon,
        Occupied
    }

    [Table("Moorings")]
    public class Mooring
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public float Length { get; set; }

        public float Width { get; set; }

        public Boolean IsOccupied { get; set; }

        public float Latitude { get; set; }
        
        public float Longitude { get; set; }

        public float Price { get; set; }

        public int LocationId { get; set; }

        public virtual Location? Location { get; set; }

        public virtual ICollection<Booking>? Bookings { get; set; }

        public enum MooringStatus
        {
            Available,
            ExpiresSoon,
            Occupied
        }

      
        public MooringStatus Status { get; set; }

    }
}
