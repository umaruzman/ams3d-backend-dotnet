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

            modelBuilder.Entity<Organization>().HasData(
                new Organization
                {
                    Id = 1,
                    Name = "TestOrganization",
                    Contact = "00000000",
                    Status = "active",
                    CreatedAt = DateTime.Now,
                    LastUpdate = DateTime.Now
                }
            );

            modelBuilder.Entity<Branch>().HasData(
                new
                {
                    Id = 1,
                    Name = "TestOrganization",
                    Contact = "00000000",
                    Address = "",
                    OrganizationId = 1,
                    CreatedAt = DateTime.Now,
                    LastUpdate = DateTime.Now,
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
                    OrganizationId = 1,
                    BranchId = 1,
                    UserStatus = true,
                    UserRoleId = 1,
                    CreatedAt =  DateTime.Now,
                    LastUpdate = DateTime.Now
                }
            );
        }
    }
}

