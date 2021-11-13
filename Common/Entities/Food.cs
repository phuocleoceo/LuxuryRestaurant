using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public byte[] Image { get; set; }
    }
}