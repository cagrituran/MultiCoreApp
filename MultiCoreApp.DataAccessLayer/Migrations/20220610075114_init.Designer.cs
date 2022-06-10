﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiCoreApp.DataAccessLayer;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    [DbContext(typeof(MultiDbContext))]
    [Migration("20220610075114_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MultiCoreApp.Core.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tblCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8483e2d1-d39b-4f5a-b54d-c324e5e4bd3f"),
                            IsDeleted = false,
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = new Guid("90b46255-3b0d-48d6-a52e-2b5cff5ea49f"),
                            IsDeleted = false,
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblCustomers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8fce5dce-0308-4921-8be8-1e0346153bdf"),
                            Address = "istanbul",
                            City = "ist",
                            Email = "cgr@hotmail.com",
                            IsDeleted = false,
                            Name = "Mehmet Aga",
                            Phone = "555"
                        },
                        new
                        {
                            Id = new Guid("cd8bd2ec-4307-4cf6-83b1-c9ecafae98e8"),
                            Address = "ankara",
                            City = "ank",
                            Email = "feleket@hotmail.com",
                            IsDeleted = false,
                            Name = "Hasan Aga",
                            Phone = "333"
                        });
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("tblProducts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("4be9c56f-b471-4019-acaf-1ab7fc3593bc"),
                            CategoryId = new Guid("8483e2d1-d39b-4f5a-b54d-c324e5e4bd3f"),
                            IsDeleted = false,
                            Name = "Dolma Kalem",
                            Price = 122.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("7266fa7d-9d1a-4918-8d8f-a361c69ea6cc"),
                            CategoryId = new Guid("8483e2d1-d39b-4f5a-b54d-c324e5e4bd3f"),
                            IsDeleted = false,
                            Name = "Tukenmez Kalem",
                            Price = 18.06m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("08237e5f-26b6-4a8d-8218-dadbacb43ec7"),
                            CategoryId = new Guid("8483e2d1-d39b-4f5a-b54d-c324e5e4bd3f"),
                            IsDeleted = false,
                            Name = "Kursun Kalem",
                            Price = 62.13m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("df30adff-1ad1-4b26-9d0a-a52fa4aa8f1c"),
                            CategoryId = new Guid("90b46255-3b0d-48d6-a52e-2b5cff5ea49f"),
                            IsDeleted = false,
                            Name = "Cizgili Defter",
                            Price = 122.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("b592e445-3f44-4b6c-aa18-b90876cd8660"),
                            CategoryId = new Guid("90b46255-3b0d-48d6-a52e-2b5cff5ea49f"),
                            IsDeleted = false,
                            Name = "Kareli Defter",
                            Price = 18.06m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("9e334ce5-37aa-44e4-b067-feda84460c80"),
                            CategoryId = new Guid("90b46255-3b0d-48d6-a52e-2b5cff5ea49f"),
                            IsDeleted = false,
                            Name = "Dumduz Defter",
                            Price = 62.13m,
                            Stock = 0
                        });
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Product", b =>
                {
                    b.HasOne("MultiCoreApp.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}