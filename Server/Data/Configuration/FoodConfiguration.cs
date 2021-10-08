using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Common.DAO;
using System;

namespace Server.Data.Configuration
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasData
            (
                new Food
                {
                    Id = 1,
                    Name = "Trứng chiên",
                    Price = 15000,
                    Description = "Ăn hoài không chán, giàu protein",
                    Image = Array.Empty<byte>()
                },
                new Food
                {
                    Id = 2,
                    Name = "Cá chiên",
                    Price = 20000,
                    Description = "Cũng được nhưng cần nước mắm ngon",
                    Image = Array.Empty<byte>()
                },
                new Food
                {
                    Id = 3,
                    Name = "Thịt nướng",
                    Price = 17000,
                    Description = "Thêm bún thì hết nước chấm",
                    Image = Array.Empty<byte>()
                },
                new Food
                {
                    Id = 4,
                    Name = "Rau muống xào",
                    Price = 10000,
                    Description = "Ngon vcl, nhất là nước rau",
                    Image = Array.Empty<byte>()
                },
                new Food
                {
                    Id = 5,
                    Name = "Canh cà chua",
                    Price = 5000,
                    Description = "Cứ phải gọi là ổn áp",
                    Image = Array.Empty<byte>()
                }
            );
        }
    }
}
