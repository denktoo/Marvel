using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Marvel.Models
{
    public class Planet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Climate { get; set; }

        public string Terrain { get; set; }

        public long Population { get; set; }

        // Navigation property for related characters
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}