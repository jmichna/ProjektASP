using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<LibraryEntity> Library { get; set; }
        public DbSet<PublishingHouseEntity> PublishingHouse { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "library.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();
            string ROLE2_ID = Guid.NewGuid().ToString();

            // dodanie roli administratora
            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            },
            new IdentityRole()
            {
                Name = "user",
                NormalizedName= "USER",
                Id = ROLE2_ID,
                ConcurrencyStamp = ROLE2_ID
            }
            );

            // utworzenie administratora jako użytkownika
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "jakub@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "jakub",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "JAKUB@WSEI.EDU.PL"
            };
            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "user@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "USER",
                NormalizedEmail = "USER@WSEI.EDU.PL"
            };

            // haszowanie hasła
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");
            user.PasswordHash = ph.HashPassword(user, "1234abcd!@#$ABCD");

            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityRole>().HasData(user);

            // przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(
            new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            },
            new IdentityUserRole<string>
            {
                RoleId = ROLE2_ID,
                UserId = USER_ID
            });

            modelBuilder.Entity<LibraryEntity>(entity =>
                {
                   entity.HasKey(x => x.Id);
                   entity.HasOne(e => e.PublishingHouse)
                         .WithMany(o => o.Library)
                         .HasForeignKey(e => e.PublishingHouseId);
                });

            modelBuilder.Entity<PublishingHouseEntity>(entity =>
                {
                    entity.HasKey(y => y.Id);
                    entity.HasOne(e => e.Address)
                          .WithMany(o => o.PublishingHouseEntity)
                          .HasForeignKey(e => e.AddressId);
                }

            );

            modelBuilder.Entity<Address>().HasData(
                new Address()
                {
                    Id = 1,
                    City = "A",
                    Street = "A",
                    PostalCode = "A",
                    Region = "A"
                }
                );

            modelBuilder.Entity<PublishingHouseEntity>().HasData(
                new PublishingHouseEntity()
                {
                    Id = 1,
                    PublishingHouseName = "PenguinRandomHouse",
                    Region = "12343221224",
                    AddressId = 1
                },
                new PublishingHouseEntity()
                {
                    Id = 2,
                    PublishingHouseName = "OxfordUniversityPress",
                    Region = "84730192837",
                    AddressId = 1
                },
                new PublishingHouseEntity()
                {
                    Id = 3,
                    PublishingHouseName = "CambridgeUniversityPress",
                    Region = "912872162237",
                    AddressId = 1
                }
            );

            modelBuilder.Entity<LibraryEntity>().HasData(
                new LibraryEntity()
                {
                    Id = 1,
                    Title = "Title",
                    Autor = "Adam Abc",
                    PageNumber = 69,
                    ISBN = "12345678987654321",
                    DateOfRelease = new DateTime(2000,01,10),
                    PublishingHouseId = 1,
                    Rating = 1
                },
                new LibraryEntity()
                {
                    Id = 2,
                    Title = "Titleeeeee",
                    Autor = "Dawid GBC",
                    PageNumber = 213,
                    ISBN = "98765432123456789",
                    DateOfRelease = new DateTime(1999, 06, 30),
                    PublishingHouseId = 2,
                    Rating = 3
                }
            );
        }
    }
}
