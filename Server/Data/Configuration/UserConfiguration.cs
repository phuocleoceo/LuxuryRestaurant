using Common.Entities;
using Common.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    DisplayName = "Quản lý",
                    Password = "c4ca4238a0b923820dcc509a6f75849b",
                    Role = Constant.Role_Admin
                },
                new User
                {
                    Id = 2,
                    UserName = "ban1",
                    DisplayName = "Bàn 1",
                    Password = "c4ca4238a0b923820dcc509a6f75849b",
                    Role = Constant.Role_Customer
                },
                new User
                {
                    Id = 3,
                    UserName = "ban2",
                    DisplayName = "Bàn 2",
                    Password = "c4ca4238a0b923820dcc509a6f75849b",
                    Role = Constant.Role_Customer
                }
            );
        }
    }
}
