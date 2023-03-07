using System.ComponentModel.DataAnnotations.Schema;

namespace Moorit.Data
{
    [Table("Roles")]
    public class Role
    {
     
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
