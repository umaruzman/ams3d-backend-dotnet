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
                    Status = "active"
                }
            );

            modelBuilder.Entity<Branch>().HasData(
                new
                {
                    Id = 1,
                    Name = "TestOrganization",
                    Contact = "00000000",
                    Address = "",
                    OrganizationId = 1
                }
            );
        }
    }
}

