﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sandbox.ApiService;

#nullable disable

namespace Sandbox.ApiService.Migrations.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20250315190432_CustomerModule")]
    partial class CustomerModule
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sandbox.ApiService.CustomerModule.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.ComplexProperty<Dictionary<string, object>>("Name", "Sandbox.ApiService.CustomerModule.Customer.Name#Name", b1 =>
                        {
                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");
                        });

                    b.HasKey("Id");

                    b.ToTable("Customers", "customer");
                });

            modelBuilder.Entity("Sandbox.ApiService.CustomerModule.CustomerAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "Sandbox.ApiService.CustomerModule.CustomerAddress.Address#Address", b1 =>
                        {
                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");
                        });

                    b.HasKey("Id");

                    b.ToTable("CustomerAddresses", "customer");

                    b.HasDiscriminator<string>("AddressType").HasValue("CustomerAddress");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Sandbox.ApiService.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Persons", "apiservice");
                });

            modelBuilder.Entity("Sandbox.ApiService.CustomerModule.CustomerBillingAddress", b =>
                {
                    b.HasBaseType("Sandbox.ApiService.CustomerModule.CustomerAddress");

                    b.HasIndex("CustomerId");

                    b.HasDiscriminator().HasValue("Billing");
                });

            modelBuilder.Entity("Sandbox.ApiService.CustomerModule.CustomerShippingAddress", b =>
                {
                    b.HasBaseType("Sandbox.ApiService.CustomerModule.CustomerAddress");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("CustomerId");

                    b.HasDiscriminator().HasValue("Shipping");
                });

            modelBuilder.Entity("Sandbox.ApiService.CustomerModule.CustomerBillingAddress", b =>
                {
                    b.HasOne("Sandbox.ApiService.CustomerModule.Customer", null)
                        .WithMany("BillingAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sandbox.ApiService.CustomerModule.CustomerShippingAddress", b =>
                {
                    b.HasOne("Sandbox.ApiService.CustomerModule.Customer", null)
                        .WithMany("ShippingAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sandbox.ApiService.CustomerModule.Customer", b =>
                {
                    b.Navigation("BillingAddresses");

                    b.Navigation("ShippingAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}
