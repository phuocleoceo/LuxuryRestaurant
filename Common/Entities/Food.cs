using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [MaxLength(500)]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Giá")]
        public double Price { get; set; }

        [DisplayName("Hình ảnh")]
        public byte[] Image { get; set; }
    }
}