using System.ComponentModel.DataAnnotations;

namespace PROG3176_Assignment2.Entities
{
    public class Animal
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Species { get; set; }

        [Required]
        public int? Age { get; set; }

        public bool IsPet { get; set; } = false;
    }
}
