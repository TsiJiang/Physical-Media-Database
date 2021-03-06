﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MediaDatabase.Models;

namespace Step_11.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200629205212_DataFix")]
    partial class DataFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Step_13.Models.MediaEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<string>("SizeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MediaEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastModified = new DateTime(2018, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "My First Manga Vol 1",
                            Size = 30.0,
                            SizeType = "PG",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            LastModified = new DateTime(2018, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "My First Manga Vol 2",
                            Size = 45.0,
                            SizeType = "PG",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            LastModified = new DateTime(2018, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "My First Manga Vol 5",
                            Size = 55.0,
                            SizeType = "PG",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            LastModified = new DateTime(2019, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Game A",
                            Size = 0.0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            LastModified = new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Game B",
                            Size = 0.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            LastModified = new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Game C",
                            Size = 0.0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 7,
                            LastModified = new DateTime(2015, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Game D",
                            Size = 0.0,
                            UserId = 4
                        },
                        new
                        {
                            Id = 8,
                            LastModified = new DateTime(2016, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Game E",
                            Size = 0.0,
                            UserId = 4
                        },
                        new
                        {
                            Id = 9,
                            LastModified = new DateTime(2017, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Game F",
                            Size = 0.0,
                            UserId = 4
                        },
                        new
                        {
                            Id = 10,
                            LastModified = new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Game A Guidebook",
                            Size = 256.0,
                            SizeType = "PG",
                            UserId = 2
                        },
                        new
                        {
                            Id = 11,
                            LastModified = new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Game B Guidebook",
                            Size = 117.0,
                            SizeType = "PG",
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            LastModified = new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Game C Guidebook",
                            Size = 400.0,
                            SizeType = "PG",
                            UserId = 3
                        },
                        new
                        {
                            Id = 13,
                            LastModified = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Time Life Music Collection",
                            Size = 7.0,
                            SizeType = "TR",
                            UserId = 4
                        },
                        new
                        {
                            Id = 14,
                            LastModified = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Greatest Hits: Volume 12",
                            Size = 9.0,
                            SizeType = "TR",
                            UserId = 4
                        },
                        new
                        {
                            Id = 15,
                            LastModified = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Now Thats What I Call Music",
                            Size = 10.0,
                            SizeType = "TR",
                            UserId = 4
                        });
                });

            modelBuilder.Entity("Step_13.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "xavier.long4@outlook.com",
                            Password = "P@$$w0rd1234!@#$"
                        },
                        new
                        {
                            Id = 2,
                            Email = "tsijiang@hotmail.com",
                            Password = "qwer1234QWER!@#$"
                        },
                        new
                        {
                            Id = 3,
                            Email = "longx@my.erau.edu",
                            Password = "Pa$$w0rd11!!"
                        },
                        new
                        {
                            Id = 4,
                            Email = "tsijiang@gmail.com",
                            Password = "P4$$w0rd"
                        },
                        new
                        {
                            Id = 5,
                            Email = "tsijiang@yahoo.com",
                            Password = "wh4tPa$$w0rd"
                        },
                        new
                        {
                            Id = 6,
                            Email = "tsijiang@aol.com",
                            Password = "password"
                        });
                });

            modelBuilder.Entity("Step_13.Models.MediaEntry", b =>
                {
                    b.HasOne("Step_13.Models.User", "User")
                        .WithMany("MediaEntries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
