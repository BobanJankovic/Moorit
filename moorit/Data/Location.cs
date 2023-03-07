
using System.ComponentModel.DataAnnotations.Schema;

namespace Moorit.Data
{
    [Table("Locations")]
    public class Location
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Mooring>? Moorings { get; set; }
    }
}
