using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.DTO
{
    public class UserForLogin
    {
        [Required]
        [DisplayName("Tên đăng nhập")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
    }
}