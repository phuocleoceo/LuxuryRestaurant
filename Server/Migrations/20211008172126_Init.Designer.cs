﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Data;

namespace Server.Migrations
{
    [DbContext(typeof(LuxuryContext))]
    [Migration("20211008172126_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Common.DAO.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ăn hoài không chán, giàu protein",
                            Image = new byte[0],
                            Name = "Trứng chiên",
                            Price = 15000.0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Cũng được nhưng cần nước mắm ngon",
                            Image = new byte[0],
                            Name = "Cá chiên",
                            Price = 20000.0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Thêm bún thì hết nước chấm",
                            Image = new byte[0],
                            Name = "Thịt nướng",
                            Price = 17000.0
                        },
                        new
                        {
                            Id = 4,
                            Description = "Ngon vcl, nhất là nước rau",
                            Image = new byte[0],
                            Name = "Rau muống xào",
                            Price = 10000.0
                        },
                        new
                        {
                            Id = 5,
                            Description = "Cứ phải gọi là ổn áp",
                            Image = new byte[0],
                            Name = "Canh cà chua",
                            Price = 5000.0
                        });
                });

            modelBuilder.Entity("Common.DAO.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "c4ca4238a0b923820dcc509a6f75849b",
                            Role = "Admin",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "c4ca4238a0b923820dcc509a6f75849b",
                            Role = "Guest",
                            UserName = "guest"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
