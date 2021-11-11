using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public byte[] Image { get; set; }
    }
}