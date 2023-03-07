﻿namespace Moorit.Models
{
    public class LocationModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<MooringModel>? Moorings { get; set; }
    }
}
