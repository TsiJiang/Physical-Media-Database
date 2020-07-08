using Microsoft.EntityFrameworkCore;
using System;

namespace MediaDatabase.Models
{
    public class AppDbContext : DbContext
    {
        //   F i e l d s   &   P r o p e t r i e s

        public DbSet<User> Users { get; set; }
        public DbSet<MediaEntry> MediaEntries { get; set; }

        //   C o n s t r u c t o r s

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        //   M e t h o d s
        protected override void OnModelCreating
            (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData
               (new User
               {
                   Id = 1,
                   Email = "xavier.long4@outlook.com",
                   Password = "P@$$w0rd1234!@#$"
               });
            modelBuilder.Entity<User>().HasData
               (new User
               {
                   Id = 2,
                   Email = "tsijiang@hotmail.com",
                   Password = "qwer1234QWER!@#$"
               });
            modelBuilder.Entity<User>().HasData
               (new User
               {
                   Id = 3,
                   Email = "longx@my.erau.edu",
                   Password = "Pa$$w0rd11!!"
               });
            modelBuilder.Entity<User>().HasData
               (new User
               {
                   Id = 4,
                   Email = "tsijiang@gmail.com",
                   Password = "P4$$w0rd"
               });
            modelBuilder.Entity<User>().HasData
               (new User
               {
                   Id = 5,
                   Email = "tsijiang@yahoo.com",
                   Password = "wh4tPa$$w0rd"
               });
            modelBuilder.Entity<User>().HasData
                (new User
                {
                    Id = 6,
                    Email = "tsijiang@aol.com",
                    Password = "password"
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 1,
                    Name = "My First Manga Vol 1",
                    LastModified = new DateTime(2018, 12, 30),
                    Size = 30,
                    SizeType = "PG",
                    UserId = 1
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 2,
                    Name = "My First Manga Vol 2",
                    LastModified = new DateTime(2018, 12, 30),
                    Size = 45,
                    SizeType = "PG",
                    UserId = 1
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 3,
                    Name = "My First Manga Vol 5",
                    LastModified = new DateTime(2018, 12, 31),
                    Size = 55,
                    SizeType = "PG",
                    UserId = 3
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 4,
                    Name = "Game A",
                    LastModified = new DateTime(2019, 05, 02),
                    UserId = 2
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 5,
                    Name = "Game B",
                    LastModified = new DateTime(2020, 01, 25),
                    UserId = 1
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 6,
                    Name = "Game C",
                    LastModified = new DateTime(2020, 03, 15),
                    UserId = 3
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 7,
                    Name = "Game D",
                    LastModified = new DateTime(2015, 10, 03),
                    UserId = 4
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 8,
                    Name = "Game E",
                    LastModified = new DateTime(2016, 06, 05),
                    UserId = 4
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 9,
                    Name = "Game F",
                    LastModified = new DateTime(2017, 05, 05),
                    UserId = 4
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 10,
                    Name = "Game A Guidebook",
                    LastModified = new DateTime(2020, 05, 15),
                    Size = 256,
                    SizeType = "PG",
                    UserId = 2
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 11,
                    Name = "Game B Guidebook",
                    LastModified = new DateTime(2020, 05, 15),
                    Size = 117,
                    SizeType = "PG",
                    UserId = 1
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 12,
                    Name = "Game C Guidebook",
                    LastModified = new DateTime(2020, 05, 15),
                    Size = 400,
                    SizeType = "PG",
                    UserId = 3
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 13,
                    Name = "Time Life Music Collection",
                    LastModified = new DateTime(2020, 01, 01),
                    Size = 7,
                    SizeType = "TR",
                    UserId = 4
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 14,
                    Name = "Greatest Hits: Volume 12",
                    LastModified = new DateTime(2020, 01, 01),
                    Size = 9,
                    SizeType = "TR",
                    UserId = 4
                });
            modelBuilder.Entity<MediaEntry>().HasData
                (new MediaEntry
                {
                    Id = 15,
                    Name = "Now Thats What I Call Music",
                    LastModified = new DateTime(2020, 01, 01),
                    Size = 10,
                    SizeType = "TR",
                    UserId = 4
                });
        }
    }
}
