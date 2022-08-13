using ARMSBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMSBackend
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,     
                    Role = "super-admin"
                },
                new UserRole
                {
                    Id = 2,
                    Role = "admin"
                }
            );




            modelBuilder.Entity<User>().HasData(
                new
                {
                    Id = 1,
                    Username = "superadmin",
                    Password = "password",
                    Email = "super@admin.com",
                    UserType = "super-admin",
                    UserStatus = true,
                    UserRoleId = 1,
                    CreatedAt =  DateTime.Now,
                    LastUpdate = DateTime.Now
                },
                new
                {
                    Id = 2,
                    Username = "admin1",
                    Password = "Password",
                    Email = "first@admin.com",
                    UserType = "admin",
                    UserStatus = true,
                    UserRoleId = 1,
                    CreatedAt =  DateTime.Now,
                    LastUpdate = DateTime.Now
                }
            );


            modelBuilder.Entity<AssetType>().HasData(
                new
                {
                    Id = 1,
                    Type = "Asset Type 1",
                },
                new
                {
                    Id = 2,
                    Type = "Asset Type 2",
                }
            );

            modelBuilder.Entity<Model>().HasData(
                new
                {
                    Id = 1,
                    ModelModelIdentifier = "5024",
                    ModelName = "Model 1"
                }
            );
        }
    }
}

