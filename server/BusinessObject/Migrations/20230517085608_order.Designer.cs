﻿// <auto-generated />
using System;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObject.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    [Migration("20230517085608_order")]
    partial class order
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BusinessObject.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("BusinessObject.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("BusinessObject.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DayOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("BusinessObject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DayOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("BusinessObject.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("ShipAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("BusinessObject.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("PK_Order_Details");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("BusinessObject.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("BusinessObject.Models.RefreshToken", b =>
                {
                    b.Property<string>("TokenId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("JwtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TokenId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("BusinessObject.Models.Account", b =>
                {
                    b.HasOne("BusinessObject.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Account_Customer");

                    b.HasOne("BusinessObject.Models.Employee", "Employee")
                        .WithMany("Accounts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Account_Employee");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BusinessObject.Models.Order", b =>
                {
                    b.HasOne("BusinessObject.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Order_Customer");

                    b.HasOne("BusinessObject.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Order_Employee");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BusinessObject.Models.OrderDetail", b =>
                {
                    b.HasOne("BusinessObject.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Order_OrderDetail");

                    b.HasOne("BusinessObject.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Order_Product");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BusinessObject.Models.Product", b =>
                {
                    b.HasOne("BusinessObject.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Product_Category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BusinessObject.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BusinessObject.Models.Customer", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BusinessObject.Models.Employee", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BusinessObject.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BusinessObject.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
