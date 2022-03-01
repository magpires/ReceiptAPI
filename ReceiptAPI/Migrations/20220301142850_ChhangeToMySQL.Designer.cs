﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReceiptAPI.Context;

namespace ReceiptAPI.Migrations
{
    [DbContext(typeof(ReceiptContext))]
    [Migration("20220301142850_ChhangeToMySQL")]
    partial class ChhangeToMySQL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("ReceiptAPI.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("city");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("district");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("integer")
                        .HasColumnName("house_number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("phone_number");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("postal_code");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("street");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("ReceiptAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}