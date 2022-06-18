﻿// <auto-generated />
using System;
using ARMSBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ARMSBackend.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220618185532_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseSerialColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ARMSBackend.Models.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseSerialColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("ARMSBackend.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseSerialColumn();

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Contact")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "",
                            Contact = "00000000",
                            CreatedAt = new DateTime(2022, 6, 19, 0, 25, 32, 18, DateTimeKind.Local).AddTicks(4540),
                            LastUpdate = new DateTime(2022, 6, 19, 0, 25, 32, 18, DateTimeKind.Local).AddTicks(4550),
                            Name = "TestOrganization",
                            OrganizationId = 1
                        });
                });

            modelBuilder.Entity("ARMSBackend.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseSerialColumn();

                    b.Property<string>("Contact")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contact = "00000000",
                            CreatedAt = new DateTime(2022, 6, 19, 0, 25, 32, 1, DateTimeKind.Local).AddTicks(1750),
                            LastUpdate = new DateTime(2022, 6, 19, 0, 25, 32, 18, DateTimeKind.Local).AddTicks(3310),
                            Name = "TestOrganization",
                            Status = "active"
                        });
                });

            modelBuilder.Entity("ARMSBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseSerialColumn();

                    b.Property<int?>("BranchId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("integer");

                    b.Property<bool>("UserStatus")
                        .HasColumnType("boolean");

                    b.Property<string>("UserType")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 6, 19, 0, 25, 32, 18, DateTimeKind.Local).AddTicks(7110),
                            Email = "super@admin.com",
                            LastUpdate = new DateTime(2022, 6, 19, 0, 25, 32, 18, DateTimeKind.Local).AddTicks(7120),
                            Password = "password",
                            UserRoleId = 1,
                            UserStatus = true,
                            UserType = "super-admin",
                            Username = "superadmin"
                        },
                        new
                        {
                            Id = 2,
                            BranchId = 1,
                            CreatedAt = new DateTime(2022, 6, 19, 0, 25, 32, 18, DateTimeKind.Local).AddTicks(8580),
                            Email = "first@admin.com",
                            LastUpdate = new DateTime(2022, 6, 19, 0, 25, 32, 18, DateTimeKind.Local).AddTicks(8590),
                            OrganizationId = 1,
                            Password = "Password",
                            UserRoleId = 1,
                            UserStatus = true,
                            UserType = "admin",
                            Username = "admin1"
                        });
                });

            modelBuilder.Entity("ARMSBackend.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseSerialColumn();

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = "super-admin"
                        },
                        new
                        {
                            Id = 2,
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("ARMSBackend.Models.Branch", b =>
                {
                    b.HasOne("ARMSBackend.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("ARMSBackend.Models.User", b =>
                {
                    b.HasOne("ARMSBackend.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.HasOne("ARMSBackend.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("ARMSBackend.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");

                    b.Navigation("Branch");

                    b.Navigation("Organization");

                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}