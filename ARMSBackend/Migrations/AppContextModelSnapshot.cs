﻿// <auto-generated />
using System;
using ARMSBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ARMSBackend.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("ARMSBackend.Models.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("AssetTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("ModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<object>("Properties")
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.HasIndex("ModelId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("ARMSBackend.Models.AssetModelItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("AssetId")
                        .HasColumnType("integer");

                    b.Property<int>("DBID")
                        .HasColumnType("integer");

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("ModelId");

                    b.ToTable("AssetModelItems");
                });

            modelBuilder.Entity("ARMSBackend.Models.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<object>("DefaultProperties")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AssetTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Asset Type 1"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Asset Type 2"
                        });
                });

            modelBuilder.Entity("ARMSBackend.Models.Metric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("AssetId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MetricTypeId")
                        .HasColumnType("integer");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("MetricTypeId");

                    b.ToTable("Metrics");
                });

            modelBuilder.Entity("ARMSBackend.Models.MetricType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Unit")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MetricsType");
                });

            modelBuilder.Entity("ARMSBackend.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<object>("ModelDetails")
                        .HasColumnType("jsonb");

                    b.Property<string>("ModelIdentifier")
                        .HasColumnType("text");

                    b.Property<string>("ModelName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ModelName = "Model 1"
                        });
                });

            modelBuilder.Entity("ARMSBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("integer");

                    b.Property<bool>("UserStatus")
                        .HasColumnType("boolean");

                    b.Property<string>("UserType")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 9, 29, 2, 47, 36, 564, DateTimeKind.Local).AddTicks(5635),
                            Email = "super@admin.com",
                            LastUpdate = new DateTime(2022, 9, 29, 2, 47, 36, 565, DateTimeKind.Local).AddTicks(7007),
                            Password = "password",
                            UserRoleId = 1,
                            UserStatus = true,
                            UserType = "super-admin",
                            Username = "superadmin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 9, 29, 2, 47, 36, 565, DateTimeKind.Local).AddTicks(8453),
                            Email = "first@admin.com",
                            LastUpdate = new DateTime(2022, 9, 29, 2, 47, 36, 565, DateTimeKind.Local).AddTicks(8461),
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
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

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

            modelBuilder.Entity("ARMSBackend.Models.Asset", b =>
                {
                    b.HasOne("ARMSBackend.Models.AssetType", "AssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeId");

                    b.HasOne("ARMSBackend.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");

                    b.Navigation("AssetType");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("ARMSBackend.Models.AssetModelItem", b =>
                {
                    b.HasOne("ARMSBackend.Models.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARMSBackend.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("ARMSBackend.Models.Metric", b =>
                {
                    b.HasOne("ARMSBackend.Models.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARMSBackend.Models.MetricType", "MetricType")
                        .WithMany()
                        .HasForeignKey("MetricTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("MetricType");
                });

            modelBuilder.Entity("ARMSBackend.Models.User", b =>
                {
                    b.HasOne("ARMSBackend.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
