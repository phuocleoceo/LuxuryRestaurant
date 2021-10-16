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
    [Migration("20211016062741_Edit")]
    partial class Edit
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
                            Description = "Miễn là nước mắm ngon",
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

            modelBuilder.Entity("Common.DAO.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Common.DAO.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCarts");
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
                            DisplayName = "Quản lý",
                            Password = "c4ca4238a0b923820dcc509a6f75849b",
                            Role = "Admin",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            DisplayName = "Bàn 1",
                            Password = "c4ca4238a0b923820dcc509a6f75849b",
                            Role = "Customer",
                            UserName = "ban1"
                        },
                        new
                        {
                            Id = 3,
                            DisplayName = "Bàn 2",
                            Password = "c4ca4238a0b923820dcc509a6f75849b",
                            Role = "Customer",
                            UserName = "ban2"
                        });
                });

            modelBuilder.Entity("Common.DAO.Order", b =>
                {
                    b.HasOne("Common.DAO.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Common.DAO.ShoppingCart", b =>
                {
                    b.HasOne("Common.DAO.Food", "Food")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.DAO.User", "User")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Common.DAO.Food", b =>
                {
                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("Common.DAO.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ShoppingCarts");
                });
#pragma warning restore 612, 618
        }
    }
}
