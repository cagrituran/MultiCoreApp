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
    [Migration("20220418180155_sa")]
    partial class sa
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
                            Id = new Guid("8e943cf6-ee67-444c-9b52-a6c0047d0e2e"),
                            IsDeleted = false,
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = new Guid("1c6a967a-ab1d-4421-bc07-9197f78a5b42"),
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
                            Id = new Guid("f8f10a86-c942-4f34-90a1-b78c8455d309"),
                            Address = "istanbul",
                            City = "ist",
                            Email = "cgr@hotmail.com",
                            IsDeleted = false,
                            Name = "Mehmet Aga",
                            Phone = "555"
                        },
                        new
                        {
                            Id = new Guid("cfa58c5b-0445-44f6-a1a7-ea5b09cec4a5"),
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
                            Id = new Guid("c011a66d-9eba-4f36-9048-9b295b7f614f"),
                            CategoryId = new Guid("8e943cf6-ee67-444c-9b52-a6c0047d0e2e"),
                            IsDeleted = false,
                            Name = "Dolma Kalem",
                            Price = 122.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("d7a96b84-7d6c-4f3d-a849-47a48713fab5"),
                            CategoryId = new Guid("8e943cf6-ee67-444c-9b52-a6c0047d0e2e"),
                            IsDeleted = false,
                            Name = "Tukenmez Kalem",
                            Price = 18.06m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("863a6e43-ca77-4310-a674-209b5eb7d7bc"),
                            CategoryId = new Guid("8e943cf6-ee67-444c-9b52-a6c0047d0e2e"),
                            IsDeleted = false,
                            Name = "Kursun Kalem",
                            Price = 62.13m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("d8873e83-65d3-498e-8d9b-bb9fe1d6d39d"),
                            CategoryId = new Guid("1c6a967a-ab1d-4421-bc07-9197f78a5b42"),
                            IsDeleted = false,
                            Name = "Cizgili Defter",
                            Price = 122.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("d2fa75f7-a722-4568-8b3f-0674d51e15a7"),
                            CategoryId = new Guid("1c6a967a-ab1d-4421-bc07-9197f78a5b42"),
                            IsDeleted = false,
                            Name = "Kareli Defter",
                            Price = 18.06m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("8d75fcf3-81a0-41d0-ad9f-1582e4ae8107"),
                            CategoryId = new Guid("1c6a967a-ab1d-4421-bc07-9197f78a5b42"),
                            IsDeleted = false,
                            Name = "Dumduz Defter",
                            Price = 62.13m,
                            Stock = 0
                        });
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